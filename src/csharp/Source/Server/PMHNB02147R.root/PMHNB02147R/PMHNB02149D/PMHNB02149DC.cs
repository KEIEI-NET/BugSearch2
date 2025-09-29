using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ShipGdsPrmListCndtnPartnerWork
	/// <summary>
	///                      �o�׏��i�D�ǑΉ��\(�Ή��i�ԗp)���o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �o�׏��i�D�ǑΉ��\(�Ή��i�ԗp)���o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/31  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>Update Note      :   2014/12/30 ������</br>
    /// <br>�Ǘ��ԍ�         :   11070263-00</br>
    /// <br>                 :   �����Y�ƗlSeiken�i�ԕύX</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ShipGdsPrmListCndtnPartnerWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		private string _sectionCode;

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

		/// <summary>���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCd;

		/// <summary>�i��</summary>
		private string _goodsNo;


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

        /// public propaty name  :  GoodsNoShowDivCd
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


		/// <summary>
		/// �o�׏��i�D�ǑΉ��\(�Ή��i�ԗp)���o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>ShipGdsPrmListCndtnPartnerWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ShipGdsPrmListCndtnPartnerWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ShipGdsPrmListCndtnPartnerWork()
		{
		}

	}
}




