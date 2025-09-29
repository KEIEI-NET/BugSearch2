//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �P�i�����ݒ�ꊇ�o�^�E�C��
// �v���O�����T�v   : �|���}�X�^�̒P�i�ݒ蕪��ΏۂɁA�������ꊇ�œo�^�E�C���A�ꊇ�폜�A���p�o�^���s���B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2010/08/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   GoodsRateSetSearchParam
	/// <summary>
	///                      �P�i�����ݒ�ꊇ�o�^�E�C�����o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �P�i�����ݒ�ꊇ�o�^�E�C�����o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/08/04  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class GoodsRateSetSearchParam
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���null</remarks>
		private String[] _sectionCode;

		/// <summary>�d����R�[�h</summary>
		private Int32 _supplierCd;

		/// <summary>���i�|���O���[�v�R�[�h</summary>
		private Int32 _goodsRateGrpCode;

		/// <summary>���i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCd;

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

        /// <summary>�i��</summary>
        /// <remarks></remarks>
        private String _goodsNo;

        /// <summary>BL�R�[�h</summary>
        /// <remarks></remarks>
        private Int32 _blGoodsCode;

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks></remarks>
        private Int32 _blGroupCode;

        /// <summary>�Ώۋ敪</summary>
        /// <remarks></remarks>
        private String _objectDiv;

        /// <summary>���ݒ�</summary>
        /// <remarks></remarks>
        private bool _unSettingFlg;

        /// <summary>�|���ݒ�敪�i���i�j</summary>
        /// <remarks>A�`O�@</remarks>
        private string _rateMngGoodsCd = "";

        /// <summary>�|���ݒ�敪�i���Ӑ�j</summary>
        /// <remarks>1�`9�@</remarks>
        private string _rateMngCustCd = "";

        //-----ADD 2010/08/31----->>>>>
        /// <summary>�t�@�C����</summary>
        private string _fileName = "";
        //-----ADD 2010/08/31-----<<<<<

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

        /// public propaty name  :  GoodsNo
        /// <summary>�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  BlGoodsCode
        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BlGoodsCode
        {
            get { return _blGoodsCode; }
            set { _blGoodsCode = value; }
        }

        /// public propaty name  :  BlGroupCodes
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BlGroupCode
        {
            get { return _blGroupCode; }
            set { _blGroupCode = value; }
        }

        /// public propaty name  :  ObjectDiv
        /// <summary>�Ώۋ敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ώۋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ObjectDiv
        {
            get { return _objectDiv; }
            set { _objectDiv = value; }
        }

        /// public propaty name  :  UnSettingFlg
        /// <summary>���ݒ�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ݒ�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool UnSettingFlg
        {
            get { return _unSettingFlg; }
            set { _unSettingFlg = value; }
        }

        /// public propaty name  :  RateMngGoodsCd
        /// <summary>�|���ݒ�敪�i���i�j�v���p�e�B</summary>
        /// <value>A�`O�@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ�敪�i���i�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateMngGoodsCd
        {
            get { return _rateMngGoodsCd; }
            set { _rateMngGoodsCd = value; }
        }

        /// public propaty name  :  RateMngCustCd
        /// <summary>�|���ݒ�敪�i���Ӑ�j�v���p�e�B</summary>
        /// <value>1�`9�@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ�敪�i���Ӑ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateMngCustCd
        {
            get { return _rateMngCustCd; }
            set { _rateMngCustCd = value; }
        }


        //-----ADD 2010/08/31----->>>>>
        /// public propaty name  :  FileName
        /// <summary>�t�@�C�����v���p�e�B</summary>
        /// <value>1�`9�@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        //-----ADD 2010/08/31-----<<<<<

		/// <summary>
		/// �P�i�����ݒ�ꊇ�o�^�E�C�����o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>GoodsRateSetSearchParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsRateSetSearchParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public GoodsRateSetSearchParam()
		{
		}

		/// <summary>
		/// �P�i�����ݒ�ꊇ�o�^�E�C�����o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="sectionCode">���_�R�[�h((�z��)�@�S�Ўw���null)</param>
		/// <param name="supplierCd">�d����R�[�h</param>
		/// <param name="goodsRateGrpCode">���i�|���O���[�v�R�[�h</param>
		/// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h((�z��) null�̏ꍇ�͑S��)</param>
		/// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h((�z��) null�̏ꍇ�͑S��)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="prmSectionCode">���O�C�����_�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="BlGoodsCode">BL�R�[�h</param>
        /// <param name="BlGroupCode">BL�O���[�v�R�[�h</param>
        /// <param name="objectDiv">�Ώۋ敪</param>
        /// <param name="unSettingFlg">���ݒ�</param>
		/// <returns>GoodsRateSetSearchParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsRateSetSearchParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public GoodsRateSetSearchParam(string enterpriseCode, String[] sectionCode, Int32 supplierCd, Int32 goodsRateGrpCode, Int32 goodsMakerCd, Int32[] customerCode, Int32[] custRateGrpCode, string enterpriseName, String[] prmSectionCode, string goodsNo, Int32 blGoodsCode, Int32 blGroupCode, string objectDiv, bool unSettingFlg)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._supplierCd = supplierCd;
			this._goodsRateGrpCode = goodsRateGrpCode;
			this._goodsMakerCd = goodsMakerCd;
			this._customerCode = customerCode;
			this._custRateGrpCode = custRateGrpCode;
			this._enterpriseName = enterpriseName;
            this._prmSectionCode = prmSectionCode;
            this._goodsNo = goodsNo;
            this._blGoodsCode = blGoodsCode;
            this._blGroupCode = blGroupCode;
            this._objectDiv = objectDiv;
            this._unSettingFlg = unSettingFlg;
		}

		/// <summary>
		/// �P�i�����ݒ�ꊇ�o�^�E�C�����o�����N���X��������
		/// </summary>
		/// <returns>GoodsRateSetSearchParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����GoodsRateSetSearchParam�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public GoodsRateSetSearchParam Clone()
		{
            return new GoodsRateSetSearchParam(this._enterpriseCode, this._sectionCode, this._supplierCd, this._goodsRateGrpCode, this._goodsMakerCd, this._customerCode, this._custRateGrpCode, this._enterpriseName, this._prmSectionCode, this._goodsNo, this._blGoodsCode, this._blGroupCode, this._objectDiv, this._unSettingFlg);
		}

		/// <summary>
		/// �P�i�����ݒ�ꊇ�o�^�E�C�����o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�GoodsRateSetSearchParam�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsRateSetSearchParam�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(GoodsRateSetSearchParam target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.GoodsRateGrpCode == target.GoodsRateGrpCode)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.CustRateGrpCode == target.CustRateGrpCode)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.PrmSectionCode == target.PrmSectionCode)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.BlGoodsCode == target.BlGoodsCode)
                 && (this.BlGroupCode == target.BlGroupCode)
                 && (this.ObjectDiv == target.ObjectDiv)
                 && (this.UnSettingFlg == target.UnSettingFlg));
		}

		/// <summary>
		/// �P�i�����ݒ�ꊇ�o�^�E�C�����o�����N���X��r����
		/// </summary>
		/// <param name="rateSearchParam1">
		///                    ��r����GoodsRateSetSearchParam�N���X�̃C���X�^���X
		/// </param>
		/// <param name="rateSearchParam2">��r����GoodsRateSetSearchParam�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsRateSetSearchParam�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(GoodsRateSetSearchParam rateSearchParam1, GoodsRateSetSearchParam rateSearchParam2)
		{
			return ((rateSearchParam1.EnterpriseCode == rateSearchParam2.EnterpriseCode)
				 && (rateSearchParam1.SectionCode == rateSearchParam2.SectionCode)
				 && (rateSearchParam1.SupplierCd == rateSearchParam2.SupplierCd)
				 && (rateSearchParam1.GoodsRateGrpCode == rateSearchParam2.GoodsRateGrpCode)
				 && (rateSearchParam1.GoodsMakerCd == rateSearchParam2.GoodsMakerCd)
				 && (rateSearchParam1.CustomerCode == rateSearchParam2.CustomerCode)
				 && (rateSearchParam1.CustRateGrpCode == rateSearchParam2.CustRateGrpCode)
				 && (rateSearchParam1.EnterpriseName == rateSearchParam2.EnterpriseName)
                 && (rateSearchParam1.PrmSectionCode == rateSearchParam2.PrmSectionCode)
                 && (rateSearchParam1.GoodsNo == rateSearchParam2.GoodsNo)
                 && (rateSearchParam1.BlGoodsCode == rateSearchParam2.BlGoodsCode)
                 && (rateSearchParam1.BlGroupCode == rateSearchParam2.BlGroupCode)
                 && (rateSearchParam1.ObjectDiv == rateSearchParam2.ObjectDiv)
                 && (rateSearchParam1.UnSettingFlg == rateSearchParam2.UnSettingFlg));
		}
		/// <summary>
		/// �P�i�����ݒ�ꊇ�o�^�E�C�����o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�GoodsRateSetSearchParam�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsRateSetSearchParam�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(GoodsRateSetSearchParam target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.GoodsRateGrpCode != target.GoodsRateGrpCode)resList.Add("GoodsRateGrpCode");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.CustRateGrpCode != target.CustRateGrpCode)resList.Add("CustRateGrpCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.PrmSectionCode != target.PrmSectionCode) resList.Add("PrmSectionCode");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.BlGoodsCode != target.BlGoodsCode) resList.Add("BlGoodsCode");
            if (this.BlGroupCode != target.BlGroupCode) resList.Add("BlGroupCode");
            if (this.ObjectDiv != target.ObjectDiv) resList.Add("ObjectDiv");
            if (this.UnSettingFlg != target.UnSettingFlg) resList.Add("UnSettingFlg");

			return resList;
		}

		/// <summary>
		/// �P�i�����ݒ�ꊇ�o�^�E�C�����o�����N���X��r����
		/// </summary>
		/// <param name="rateSearchParam1">��r����GoodsRateSetSearchParam�N���X�̃C���X�^���X</param>
		/// <param name="rateSearchParam2">��r����GoodsRateSetSearchParam�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsRateSetSearchParam�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(GoodsRateSetSearchParam rateSearchParam1, GoodsRateSetSearchParam rateSearchParam2)
		{
			ArrayList resList = new ArrayList();
			if(rateSearchParam1.EnterpriseCode != rateSearchParam2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(rateSearchParam1.SectionCode != rateSearchParam2.SectionCode)resList.Add("SectionCode");
			if(rateSearchParam1.SupplierCd != rateSearchParam2.SupplierCd)resList.Add("SupplierCd");
			if(rateSearchParam1.GoodsRateGrpCode != rateSearchParam2.GoodsRateGrpCode)resList.Add("GoodsRateGrpCode");
			if(rateSearchParam1.GoodsMakerCd != rateSearchParam2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(rateSearchParam1.CustomerCode != rateSearchParam2.CustomerCode)resList.Add("CustomerCode");
			if(rateSearchParam1.CustRateGrpCode != rateSearchParam2.CustRateGrpCode)resList.Add("CustRateGrpCode");
            if (rateSearchParam1.EnterpriseName != rateSearchParam2.EnterpriseName) resList.Add("EnterpriseName");
            if (rateSearchParam1.PrmSectionCode != rateSearchParam2.PrmSectionCode) resList.Add("PrmSectionCode");
            if (rateSearchParam1.GoodsNo != rateSearchParam2.GoodsNo) resList.Add("GoodsNo");
            if (rateSearchParam1.BlGoodsCode != rateSearchParam2.BlGoodsCode) resList.Add("BlGoodsCode");
            if (rateSearchParam1.BlGroupCode != rateSearchParam2.BlGroupCode) resList.Add("BlGroupCode");
            if (rateSearchParam1.ObjectDiv != rateSearchParam2.ObjectDiv) resList.Add("ObjectDiv");
            if (rateSearchParam1.UnSettingFlg != rateSearchParam2.UnSettingFlg) resList.Add("UnSettingFlg");

			return resList;
		}
	}
}
