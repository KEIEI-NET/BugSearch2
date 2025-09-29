//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���ꊇ�o�^�E�C���U���o�����N���X
// �v���O�����T�v   : ��`�E�������y�уC���X�^���X�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �v��
// �� �� ��  2013/02/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Rate2SearchParam
	/// <summary>
    ///                      �|���ꊇ�o�^�E�C���U���o�����N���X
	/// </summary>
	/// <remarks>
    /// <br>note             :   �|���ꊇ�o�^�E�C���U���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2013/02/19  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class Rate2SearchParam
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���null</remarks>
		private String[] _sectionCode;

		/// <summary>�d����R�[�h</summary>
		private Int32 _supplierCd;

        /// <summary>�d���於��</summary>
        private string _supplierNm;

        /// <summary>�o�͋敪</summary>
        private string _outputDiv;

        /// <summary>���_����</summary>
        /// <remarks>(�z��)/remarks>
        private String[] _sectionName;

		/// <summary>���i�|���O���[�v�R�[�h</summary>
		private Int32 _goodsRateGrpCode;

        /// <summary>���i�|�������N</summary>
        /// <remarks>�w��</remarks>
        private string _goodsRateRank;

        /// <summary>���i�ؑփ��[�h</summary>
        /// <remarks>0:���i�|��G 1:�w��</remarks>
        private Int32 _goodsChangeMode;

        /// <summary>�O���[�v�R�[�h</summary>
        private Int32 _groupCd;

        /// <summary>BL�R�[�h</summary>
        private Int32 _blCd;

		/// <summary>���i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCd;

        /// <summary>���i���[�J�[����</summary>
        private string _goodsMakerNm;

		/// <summary>���Ӑ�R�[�h</summary>
		/// <remarks>(�z��) null�̏ꍇ�͑S��</remarks>
		private Int32[] _customerCode;

		/// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
		/// <remarks>(�z��) null�̏ꍇ�͑S��</remarks>
		private Int32[] _custRateGrpCode;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

        /// <summary>���O�C�����_�R�[�h</summary>
        /// <remarks></remarks>
        private String[] _prmSectionCode;

        /// <summary>���Ӑ挟�����[�h</summary>
        /// <remarks>�i0: ���Ӑ�|���f; 1 : ���Ӑ�b�c</remarks>
        private Int32 _customerSearchMode;

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
		public String[] SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
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
			get{return _supplierCd;}
			set{_supplierCd = value;}
		}

        /// public propaty name  :  SupplierCd
		/// <summary>�d���於�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
        /// <br>note             :   �d���於�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SupplierNm
		{
            get { return _supplierNm; }
            set { _supplierNm = value; }
		}

        /// public propaty name  :  �o�͋敪
        /// <summary>�o�͋敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
        /// <br>note             :   �o�͋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public string OutputDiv
		{
            get { return _outputDiv; }
            set { _outputDiv = value; }
		}


        /// public propaty name  :  SectionName
        /// <summary>���_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String[] SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        

		/// public propaty name  :  GoodsRateGrpCode
		/// <summary>���i�|���O���[�v�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�|���O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsRateGrpCode
		{
			get{return _goodsRateGrpCode;}
			set{_goodsRateGrpCode = value;}
		}

        /// public propaty name  :  GoodsRateRank
        /// <summary>���i�|�������N�v���p�e�B</summary>
        /// <value>�w��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|�������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  CustomerSearchMode
        /// <summary>���i�ؑփ��[�h�v���p�e�B</summary>
        /// <value>0:���i�|��G 1:�w��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ؑփ��[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsChangeMode
        {
            get { return _goodsChangeMode; }
            set { _goodsChangeMode = value; }
        }

        /// public propaty name  :  GroupCd
        /// <summary>�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GroupCd
        {
            get { return _groupCd; }
            set { _groupCd = value; }
        }

        /// public propaty name  :  BlCd
        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BlCd
        {
            get { return _blCd; }
            set { _blCd = value; }
        }

		/// public propaty name  :  GoodsMakerCd
		/// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  GoodsMakerNm
		/// <summary>���i���[�J�[����</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���[�J�[���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public string GoodsMakerNm
		{
            get { return _goodsMakerNm; }
            set { _goodsMakerNm = value; }
		}

        

		/// public propaty name  :  CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// <value>(�z��) null�̏ꍇ�͑S��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32[] CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  CustRateGrpCode
		/// <summary>���Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
		/// <value>(�z��) null�̏ꍇ�͑S��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32[] CustRateGrpCode
		{
			get{return _custRateGrpCode;}
			set{_custRateGrpCode = value;}
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

        /// public propaty name  :  SectionCode
        /// <summary>���O�C�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String[] PrmSectionCode
        {
            get { return _prmSectionCode; }
            set { _prmSectionCode = value; }
        }

        /// public propaty name  :  CustomerSearchMode
        /// <summary>���Ӑ挟�����[�h�i0: ���Ӑ�|���f; 1 : ���Ӑ�b�c</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ挟�����[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerSearchMode
        {
            get { return _customerSearchMode; }
            set { _customerSearchMode = value; }
        }

		/// <summary>
        /// �|���ꊇ�o�^�E�C���U���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>Rate2SearchParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Rate2SearchParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Rate2SearchParam()
		{
		}

		/// <summary>
        /// �|���ꊇ�o�^�E�C���U���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="sectionCode">���_�R�[�h((�z��)�@�S�Ўw���null)</param>
		/// <param name="supplierCd">�d����R�[�h</param>
		/// <param name="goodsRateGrpCode">���i�|���O���[�v�R�[�h</param>
        /// <param name="goodsRateRank">�w��</param>
        /// <param name="goodChangeMode">���i�ؑփ��[�h</param>
		/// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h((�z��) null�̏ꍇ�͑S��)</param>
		/// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h((�z��) null�̏ꍇ�͑S��)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="prmSectionCode">���O�C�����_�R�[�h</param>
		/// <returns>Rate2SearchParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Rate2SearchParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Rate2SearchParam(string enterpriseCode, String[] sectionCode, Int32 supplierCd, Int32 goodsRateGrpCode, string goodsRateRank, Int32 goodsChangeMode, Int32 groupCd, Int32 blCd, Int32 goodsMakerCd, Int32[] customerCode, Int32[] custRateGrpCode, string enterpriseName, String[] prmSectionCode)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._supplierCd = supplierCd;
			this._goodsRateGrpCode = goodsRateGrpCode;
            this._goodsRateRank = goodsRateRank;
            this._goodsChangeMode = goodsChangeMode;
            this._groupCd = groupCd;
            this._blCd = blCd;
			this._goodsMakerCd = goodsMakerCd;
			this._customerCode = customerCode;
			this._custRateGrpCode = custRateGrpCode;
			this._enterpriseName = enterpriseName;
            this._prmSectionCode = prmSectionCode;
		}

		/// <summary>
        /// �|���ꊇ�o�^�E�C���U���o�����N���X��������
		/// </summary>
		/// <returns>Rate2SearchParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����Rate2SearchParam�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Rate2SearchParam Clone()
		{
			return new Rate2SearchParam(this._enterpriseCode,this._sectionCode,this._supplierCd,this._goodsRateGrpCode, this._goodsRateRank,this._goodsChangeMode,this._groupCd,this._blCd, this._goodsMakerCd, this._customerCode,this._custRateGrpCode,this._enterpriseName, this._prmSectionCode);
		}

		/// <summary>
        /// �|���ꊇ�o�^�E�C���U���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�Rate2SearchParam�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Rate2SearchParam�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(Rate2SearchParam target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.GoodsRateGrpCode == target.GoodsRateGrpCode)
                 && (this.GoodsRateRank == target.GoodsRateRank)
                 && (this.GoodsChangeMode == target.GoodsChangeMode)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.CustRateGrpCode == target.CustRateGrpCode)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.PrmSectionCode == target.PrmSectionCode));
		}

		/// <summary>
        /// �|���ꊇ�o�^�E�C���U���o�����N���X��r����
		/// </summary>
		/// <param name="rateSearchParam1">
		///                    ��r����Rate2SearchParam�N���X�̃C���X�^���X
		/// </param>
		/// <param name="rateSearchParam2">��r����Rate2SearchParam�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Rate2SearchParam�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(Rate2SearchParam rateSearchParam1, Rate2SearchParam rateSearchParam2)
		{
			return ((rateSearchParam1.EnterpriseCode == rateSearchParam2.EnterpriseCode)
				 && (rateSearchParam1.SectionCode == rateSearchParam2.SectionCode)
				 && (rateSearchParam1.SupplierCd == rateSearchParam2.SupplierCd)
				 && (rateSearchParam1.GoodsRateGrpCode == rateSearchParam2.GoodsRateGrpCode)
                 && (rateSearchParam1.GoodsRateRank == rateSearchParam2.GoodsRateRank)
                 && (rateSearchParam1.GoodsChangeMode == rateSearchParam2.GoodsChangeMode)
				 && (rateSearchParam1.GoodsMakerCd == rateSearchParam2.GoodsMakerCd)
				 && (rateSearchParam1.CustomerCode == rateSearchParam2.CustomerCode)
				 && (rateSearchParam1.CustRateGrpCode == rateSearchParam2.CustRateGrpCode)
				 && (rateSearchParam1.EnterpriseName == rateSearchParam2.EnterpriseName)
                 && (rateSearchParam1.PrmSectionCode == rateSearchParam2.PrmSectionCode));
		}
		/// <summary>
        /// �|���ꊇ�o�^�E�C���U���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�Rate2SearchParam�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Rate2SearchParam�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(Rate2SearchParam target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.GoodsRateGrpCode != target.GoodsRateGrpCode)resList.Add("GoodsRateGrpCode");
            if (this.GoodsRateRank != target.GoodsRateRank) resList.Add("GoodsRateRank");
            if (this.GoodsChangeMode != target.GoodsChangeMode) resList.Add("GoodsChangeMode");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.CustRateGrpCode != target.CustRateGrpCode)resList.Add("CustRateGrpCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.PrmSectionCode != target.PrmSectionCode) resList.Add("PrmSectionCode");

			return resList;
		}

		/// <summary>
        /// �|���ꊇ�o�^�E�C���U���o�����N���X��r����
		/// </summary>
		/// <param name="rateSearchParam1">��r����Rate2SearchParam�N���X�̃C���X�^���X</param>
		/// <param name="rateSearchParam2">��r����Rate2SearchParam�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Rate2SearchParam�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(Rate2SearchParam rateSearchParam1, Rate2SearchParam rateSearchParam2)
		{
			ArrayList resList = new ArrayList();
			if(rateSearchParam1.EnterpriseCode != rateSearchParam2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(rateSearchParam1.SectionCode != rateSearchParam2.SectionCode)resList.Add("SectionCode");
			if(rateSearchParam1.SupplierCd != rateSearchParam2.SupplierCd)resList.Add("SupplierCd");
			if(rateSearchParam1.GoodsRateGrpCode != rateSearchParam2.GoodsRateGrpCode)resList.Add("GoodsRateGrpCode");
            if (rateSearchParam1.GoodsRateRank != rateSearchParam2.GoodsRateRank) resList.Add("GoodsRateRank");
            if (rateSearchParam1.GoodsChangeMode != rateSearchParam2.GoodsChangeMode) resList.Add("GoodsChangeMode");
			if(rateSearchParam1.GoodsMakerCd != rateSearchParam2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(rateSearchParam1.CustomerCode != rateSearchParam2.CustomerCode)resList.Add("CustomerCode");
			if(rateSearchParam1.CustRateGrpCode != rateSearchParam2.CustRateGrpCode)resList.Add("CustRateGrpCode");
            if (rateSearchParam1.EnterpriseName != rateSearchParam2.EnterpriseName) resList.Add("EnterpriseName");
            if (rateSearchParam1.PrmSectionCode != rateSearchParam2.PrmSectionCode) resList.Add("PrmSectionCode");

			return resList;
		}
	}
}
