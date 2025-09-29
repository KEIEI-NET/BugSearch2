using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SalesTransListCndtnWork
	/// <summary>
	///                      ���㐄�ڕ\���o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���㐄�ڕ\���o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>Update Note      :   2014/12/16 ����</br>
    /// <br>�Ǘ��ԍ�         :   11070263-00</br>
    /// <br>                 :   �����Y�ƗlSeiken�i�ԕύX</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SalesTransListCndtnWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
		private string[] _sectionCodes;

		/// <summary>�W�v�P��</summary>
		/// <remarks>0:���i�� 1:���Ӑ�� 2:�S���ҕ� 3:�d����</remarks>
		private Int32 _totalType;

		/// <summary>�W�v���@</summary>
		/// <remarks>0:�S�� 1:���_��</remarks>
		private Int32 _ttlType;

		/// <summary>�݌Ɏ�񂹋敪</summary>
		/// <remarks>0:���v 1:�݌�, 2:���</remarks>
		private Int32 _rsltTtlDivCd;

		/// <summary>���[�J�[�ʈ��</summary>
		/// <remarks>0:���Ȃ� 1:����</remarks>
		private Int32 _makerPrintDiv;

		/// <summary>���גP��</summary>
		private Int32 _detail;

        //------ ADD START 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------>>>>>
        /// <summary>�i�ԏW�v�敪</summary>
        /// <remarks>0:�ʁX 1:���Z</remarks>
        private Int32 _goodsNoTtlDiv;
        /// <summary>�i�ԕ\���敪</summary>
        /// <remarks>0:�V�i�� 1:���i��</remarks>
        private Int32 _goodsNoShowDiv;
        //------ ADD END 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------<<<<<

		/// <summary>�J�n�Ώ۔N��</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonthSt;

		/// <summary>�I���Ώ۔N��</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonthEd;

		/// <summary>�J�n����͈͎w��</summary>
		private Int32 _printRangeSt;

		/// <summary>�I������͈͎w��</summary>
		private Int32 _printRangeEd;

		/// <summary>�J�n���Ӑ�R�[�h</summary>
		private Int32 _customerCodeSt;

		/// <summary>�I�����Ӑ�R�[�h</summary>
		private Int32 _customerCodeEd;

        /// <summary>�J�n�d����R�[�h</summary>
        private Int32 _supplierCodeSt;�@�@�@�@�@// ADD 2009/04/15

        /// <summary>�I���d����R�[�h</summary>
        private Int32 _supplierCodeEd;�@�@�@�@�@// ADD 2009/04/15

		/// <summary>�J�n�]�ƈ��R�[�h</summary>
		private string _employeeCodeSt = "";

		/// <summary>�I���]�ƈ��R�[�h</summary>
		private string _employeeCodeEd = "";

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
		/// <value>(�z��)�@�S�Ўw���{""}</value>
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

		/// public propaty name  :  TotalType
		/// <summary>�W�v�P�ʃv���p�e�B</summary>
		/// <value>0:���i�� 1:���Ӑ�� 2:�S���ҕ� 3:�d����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �W�v�P�ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TotalType
		{
			get{return _totalType;}
			set{_totalType = value;}
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

		/// public propaty name  :  MakerPrintDiv
		/// <summary>���[�J�[�ʈ���v���p�e�B</summary>
		/// <value>0:���Ȃ� 1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�ʈ���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MakerPrintDiv
		{
			get{return _makerPrintDiv;}
			set{_makerPrintDiv = value;}
		}

		/// public propaty name  :  Detail
		/// <summary>���גP�ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���גP�ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Detail
		{
			get{return _detail;}
			set{_detail = value;}
		}

        //------ ADD START 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------>>>>>
        /// public propaty name  :  GoodsNoTtlDiv
        /// <summary>�i�ԏW�v�敪�v���p�e�B</summary>
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
        //------ ADD END 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------<<<<<

		/// public propaty name  :  AddUpYearMonthSt
		/// <summary>�J�n�Ώ۔N���v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�Ώ۔N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AddUpYearMonthSt
		{
			get{return _addUpYearMonthSt;}
			set{_addUpYearMonthSt = value;}
		}

		/// public propaty name  :  AddUpYearMonthEd
		/// <summary>�I���Ώ۔N���v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���Ώ۔N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AddUpYearMonthEd
		{
			get{return _addUpYearMonthEd;}
			set{_addUpYearMonthEd = value;}
		}

		/// public propaty name  :  PrintRangeSt
		/// <summary>�J�n����͈͎w��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n����͈͎w��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintRangeSt
		{
			get{return _printRangeSt;}
			set{_printRangeSt = value;}
		}

		/// public propaty name  :  PrintRangeEd
		/// <summary>�I������͈͎w��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I������͈͎w��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintRangeEd
		{
			get{return _printRangeEd;}
			set{_printRangeEd = value;}
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

        // --- ADD 2009/04/15 -------------------------------->>>>>
        /// public propaty name  :  SupplierCodeSt
        /// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCodeSt
        {
            get { return _supplierCodeSt; }
            set { _supplierCodeSt = value; }
        }

        /// public propaty name  :  SupplierCodeEd
        /// <summary>�I���d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCodeEd
        {
            get { return _supplierCodeEd; }
            set { _supplierCodeEd = value; }
        }
        // --- ADD 2009/04/15 --------------------------------<<<<<

		/// public propaty name  :  EmployeeCodeSt
		/// <summary>�J�n�]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EmployeeCodeSt
		{
			get{return _employeeCodeSt;}
			set{_employeeCodeSt = value;}
		}

		/// public propaty name  :  EmployeeCodeEd
		/// <summary>�I���]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EmployeeCodeEd
		{
			get{return _employeeCodeEd;}
			set{_employeeCodeEd = value;}
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
		/// ���㐄�ڕ\���o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SalesTransListCndtnWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesTransListCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SalesTransListCndtnWork()
		{
		}

	}
}
