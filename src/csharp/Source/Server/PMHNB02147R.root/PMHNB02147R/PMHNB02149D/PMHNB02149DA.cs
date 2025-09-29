using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ShipGdsPrimeListCndtnWork
	/// <summary>
	///                      �o�׏��i�D�ǑΉ��\���o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �o�׏��i�D�ǑΉ��\���o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/30  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>Update Note      :   2014/12/30 ������</br>
    /// <br>�Ǘ��ԍ�         :   11070263-00</br>
    /// <br>                 :   �����Y�ƗlSeiken�i�ԕύX</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ShipGdsPrimeListCndtnWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��) null�őS�Ўw��</remarks>
		private string[] _sectionCodes;

		/// <summary>�J�n�Ώ۔N��</summary>
		private DateTime _st_AddUpYearMonth;

		/// <summary>�I���Ώ۔N��</summary>
		private DateTime _ed_AddUpYearMonth;

        //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
        /// <summary>�i�ԏW�v�敪</summary>
        /// <remarks>0:�ʁX 1:���Z</remarks>
        private Int32 _goodsNoTtlDiv;

        /// <summary>�i�ԕ\���敪</summary>
        /// <remarks>0:�V�i�� 1:���i��</remarks>
        private Int32 _goodsNoShowDiv;
        //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
        
		/// <summary>�J�n���[�J�[�R�[�h</summary>
		private Int32 _st_GoodsMakerCd;

		/// <summary>�I�����[�J�[�R�[�h</summary>
		private Int32 _ed_GoodsMakerCd;

		/// <summary>�J�n�啪�ރR�[�h</summary>
		/// <remarks>�O���[�v�R�[�h�}�X�^</remarks>
		private Int32 _st_GoodsLGroup;

		/// <summary>�I���啪�ރR�[�h</summary>
		/// <remarks>�O���[�v�R�[�h�}�X�^</remarks>
		private Int32 _ed_GoodsLGroup;

		/// <summary>�J�n�����ރR�[�h</summary>
		/// <remarks>�O���[�v�R�[�h�}�X�^</remarks>
		private Int32 _st_GoodsMGroup;

		/// <summary>�I�������ރR�[�h</summary>
		/// <remarks>�O���[�v�R�[�h�}�X�^</remarks>
		private Int32 _ed_GoodsMGroup;

		/// <summary>�J�n�O���[�v�R�[�h</summary>
		/// <remarks>BL�R�[�h�}�X�^</remarks>
		private Int32 _st_BLGroupCode;

		/// <summary>�I���O���[�v�R�[�h</summary>
		/// <remarks>BL�R�[�h�}�X�^</remarks>
		private Int32 _ed_BLGroupCode;

		/// <summary>�J�n�a�k�R�[�h</summary>
		private Int32 _st_BLGoodsCode;

		/// <summary>�I���a�k�R�[�h</summary>
		private Int32 _ed_BLGoodsCode;

		/// <summary>�o�׉�</summary>
		/// <remarks>���U�Ŏg�p</remarks>
		private Int32 _shipCount;


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
		/// <value>(�z��) null�őS�Ўw��</value>
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

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>�J�n�Ώ۔N���v���p�e�B</summary>
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

        //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
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
        //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<

		/// public propaty name  :  St_GoodsMakerCd
		/// <summary>�J�n���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_GoodsMakerCd
		{
			get{return _st_GoodsMakerCd;}
			set{_st_GoodsMakerCd = value;}
		}

		/// public propaty name  :  Ed_GoodsMakerCd
		/// <summary>�I�����[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_GoodsMakerCd
		{
			get{return _ed_GoodsMakerCd;}
			set{_ed_GoodsMakerCd = value;}
		}

		/// public propaty name  :  St_GoodsLGroup
		/// <summary>�J�n�啪�ރR�[�h�v���p�e�B</summary>
		/// <value>�O���[�v�R�[�h�}�X�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�啪�ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_GoodsLGroup
		{
			get{return _st_GoodsLGroup;}
			set{_st_GoodsLGroup = value;}
		}

		/// public propaty name  :  Ed_GoodsLGroup
		/// <summary>�I���啪�ރR�[�h�v���p�e�B</summary>
		/// <value>�O���[�v�R�[�h�}�X�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���啪�ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_GoodsLGroup
		{
			get{return _ed_GoodsLGroup;}
			set{_ed_GoodsLGroup = value;}
		}

		/// public propaty name  :  St_GoodsMGroup
		/// <summary>�J�n�����ރR�[�h�v���p�e�B</summary>
		/// <value>�O���[�v�R�[�h�}�X�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�����ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_GoodsMGroup
		{
			get{return _st_GoodsMGroup;}
			set{_st_GoodsMGroup = value;}
		}

		/// public propaty name  :  Ed_GoodsMGroup
		/// <summary>�I�������ރR�[�h�v���p�e�B</summary>
		/// <value>�O���[�v�R�[�h�}�X�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�������ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_GoodsMGroup
		{
			get{return _ed_GoodsMGroup;}
			set{_ed_GoodsMGroup = value;}
		}

		/// public propaty name  :  St_BLGroupCode
		/// <summary>�J�n�O���[�v�R�[�h�v���p�e�B</summary>
		/// <value>BL�R�[�h�}�X�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_BLGroupCode
		{
			get{return _st_BLGroupCode;}
			set{_st_BLGroupCode = value;}
		}

		/// public propaty name  :  Ed_BLGroupCode
		/// <summary>�I���O���[�v�R�[�h�v���p�e�B</summary>
		/// <value>BL�R�[�h�}�X�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_BLGroupCode
		{
			get{return _ed_BLGroupCode;}
			set{_ed_BLGroupCode = value;}
		}

		/// public propaty name  :  St_BLGoodsCode
		/// <summary>�J�n�a�k�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�a�k�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_BLGoodsCode
		{
			get{return _st_BLGoodsCode;}
			set{_st_BLGoodsCode = value;}
		}

		/// public propaty name  :  Ed_BLGoodsCode
		/// <summary>�I���a�k�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���a�k�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_BLGoodsCode
		{
			get{return _ed_BLGoodsCode;}
			set{_ed_BLGoodsCode = value;}
		}

		/// public propaty name  :  ShipCount
		/// <summary>�o�׉񐔃v���p�e�B</summary>
		/// <value>���U�Ŏg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�׉񐔃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ShipCount
		{
			get{return _shipCount;}
			set{_shipCount = value;}
		}


		/// <summary>
		/// �o�׏��i�D�ǑΉ��\���o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>ShipGdsPrimeListCndtnWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ShipGdsPrimeListCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ShipGdsPrimeListCndtnWork()
		{
		}

	}
}




