using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ExtrInfo_ShipGoodsAnalyzeWork
	/// <summary>
	///                      �o�׏��i���͕\���o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �o�׏��i���͕\���o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/29  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>Update Note      :   2014/12/22 ������</br>
    /// <br>�Ǘ��ԍ�         :   11070263-00</br>
    /// <br>                 :   �����Y�ƗlSeiken�i�ԕύX</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ExtrInfo_ShipGoodsAnalyzeWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���null</remarks>
		private string[] _sectionCodes;

		/// <summary>�W�v���@</summary>
		/// <remarks>0:�S�� 1:���_��</remarks>
		private Int32 _ttlType;

		/// <summary>�J�n�Ώ۔N��</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _st_AddUpYearMonth;

		/// <summary>�I���Ώ۔N��</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _ed_AddUpYearMonth;

		/// <summary>�݌ɓo�^��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _ex_StockCreateDate;

		/// <summary>�݌ɓo�^�������敪</summary>
		/// <remarks>0:�ȑO 1:�Ȍ�</remarks>
		private Int32 _beforeAfter;

		/// <summary>�݌Ɏ�񂹋敪</summary>
		/// <remarks>0:���v 1:�݌�, 2:���</remarks>
		private Int32 _rsltTtlDivCd;

        //------ ADD START 2014/12/23 ������ FOR Redmine#44209���� ------>>>>>
        /// <summary>�i�ԏW�v�敪</summary>
        /// <remarks>0:�ʁX 1:���Z</remarks>
        private Int32 _goodsNoTtlDiv;

        /// <summary>�i�ԕ\���敪</summary>
        /// <remarks>0:�V�i�� 1:���i��</remarks>
        private Int32 _goodsNoShowDiv;
        //------ ADD END 2014/12/23 ������ FOR Redmine#44209���� ------<<<<<
        
		/// <summary>�J�n�d����R�[�h</summary>
		private Int32 _supplierCdSt;

		/// <summary>�I���d����R�[�h</summary>
		private Int32 _supplierCdEd;

		/// <summary>�J�n���i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCdSt;

		/// <summary>�I�����i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCdEd;

		/// <summary>�J�n���i�啪�ރR�[�h</summary>
		private Int32 _goodsLGroupSt;

		/// <summary>�I�����i�啪�ރR�[�h</summary>
		private Int32 _goodsLGroupEd;

		/// <summary>�J�n���i�����ރR�[�h</summary>
		private Int32 _goodsMGroupSt;

		/// <summary>�I�����i�����ރR�[�h</summary>
		private Int32 _goodsMGroupEd;

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

		/// public propaty name  :  SectionCodes
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// <value>(�z��)�@�S�Ўw���null</value>
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

		/// public propaty name  :  TtlType
		/// <summary>�W�v���@�v���p�e�B</summary>
		/// <value>0:�S�� 1:���_��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �W�v���@�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TtlType
		{
			get{return _ttlType;}
			set{_ttlType = value;}
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>�J�n�Ώ۔N���v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�Ώ۔N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime St_AddUpYearMonth
		{
			get{return _st_AddUpYearMonth;}
			set{_st_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>�I���Ώ۔N���v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���Ώ۔N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime Ed_AddUpYearMonth
		{
			get{return _ed_AddUpYearMonth;}
			set{_ed_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ex_StockCreateDate
		/// <summary>�݌ɓo�^���v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɓo�^���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime Ex_StockCreateDate
		{
			get{return _ex_StockCreateDate;}
			set{_ex_StockCreateDate = value;}
		}

		/// public propaty name  :  BeforeAfter
		/// <summary>�݌ɓo�^�������敪�v���p�e�B</summary>
		/// <value>0:�ȑO 1:�Ȍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɓo�^�������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BeforeAfter
		{
			get{return _beforeAfter;}
			set{_beforeAfter = value;}
		}

		/// public propaty name  :  RsltTtlDivCd
		/// <summary>�݌Ɏ�񂹋敪�v���p�e�B</summary>
		/// <value>0:���v 1:�݌�, 2:���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌Ɏ�񂹋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RsltTtlDivCd
		{
			get{return _rsltTtlDivCd;}
			set{_rsltTtlDivCd = value;}
		}

        //------ ADD START 2014/12/23 ������ FOR Redmine#44209���� ------>>>>>
        /// public propaty name  :  GoodsNoTtlDiv
        /// <summary>�i�ԏW�v�敪�v���p�e�B</summary>
        /// <value>0:�ʁX 1:���Z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԏW�v�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNoTtlDiv
        {
            get { return _goodsNoTtlDiv; }
            set { _goodsNoTtlDiv = value; }
        }

        /// public propaty name  :  GoodsNoShowDiv
        /// <summary>�i�ԕ\���敪�v���p�e�B</summary>
        /// <value>0:�V�i�� 1:���i��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNoShowDiv
        {
            get { return _goodsNoShowDiv; }
            set { _goodsNoShowDiv = value; }
        }
        //------ ADD END 2014/12/23 ������ FOR Redmine#44209���� ------<<<<<

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

		/// public propaty name  :  GoodsLGroupSt
		/// <summary>�J�n���i�啪�ރR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���i�啪�ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsLGroupSt
		{
			get{return _goodsLGroupSt;}
			set{_goodsLGroupSt = value;}
		}

		/// public propaty name  :  GoodsLGroupEd
		/// <summary>�I�����i�啪�ރR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����i�啪�ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsLGroupEd
		{
			get{return _goodsLGroupEd;}
			set{_goodsLGroupEd = value;}
		}

		/// public propaty name  :  GoodsMGroupSt
		/// <summary>�J�n���i�����ރR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���i�����ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMGroupSt
		{
			get{return _goodsMGroupSt;}
			set{_goodsMGroupSt = value;}
		}

		/// public propaty name  :  GoodsMGroupEd
		/// <summary>�I�����i�����ރR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����i�����ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMGroupEd
		{
			get{return _goodsMGroupEd;}
			set{_goodsMGroupEd = value;}
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
		/// �o�׏��i���͕\���o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>ExtrInfo_ShipGoodsAnalyzeWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_ShipGoodsAnalyzeWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_ShipGoodsAnalyzeWork()
		{
		}

	}
}
