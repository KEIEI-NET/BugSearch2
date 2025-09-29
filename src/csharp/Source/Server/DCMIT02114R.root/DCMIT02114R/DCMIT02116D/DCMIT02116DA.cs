using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   EstimateListCndtnWork
	/// <summary>
	///                      ���ϊm�F�\���o�����N���X���[�N���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���ϊm�F�\���o�����N���X���[�N���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/07/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class EstimateListCndtnWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
		private string[] _sectionCodes;

		/// <summary>�J�n���ϓ��t</summary>
		private DateTime _st_SalesDate;

		/// <summary>�I�����ϓ��t</summary>
		private DateTime _ed_SalesDate;

		/// <summary>�J�n���͓��t</summary>
		private DateTime _st_SearchSlipDate;

		/// <summary>�I�����͓��t</summary>
		private DateTime _ed_SearchSlipDate;

		/// <summary>�J�n���Ӑ�R�[�h</summary>
		private Int32 _st_CustomerCode;

		/// <summary>�I�����Ӑ�R�[�h</summary>
		private Int32 _ed_CustomerCode;

		/// <summary>�J�n�̔��]�ƈ��R�[�h</summary>
		private string _st_SalesEmployeeCd = "";

		/// <summary>�I���̔��]�ƈ��R�[�h</summary>
		private string _ed_SalesEmployeeCd = "";

		/// <summary>���σ^�C�v</summary>
		/// <remarks>0:������͕�,1:�������ϕ�,-1:�S��</remarks>
		private Int32 _estimateDivide;

		/// <summary>���s�^�C�v</summary>
		/// <remarks>0:���όv��,-1:�S��</remarks>
		private Int32 _printDiv;

        // 2011/11/11 add start ----------------------------------------------->>
        /// <summary>���s�^�C�v</summary>
        /// <remarks>0:�A�g�`�[���܂܂Ȃ�,1:�A�g�`�[���܂�,2:�A�g�`�[�̂ݑΏ�</remarks>
        private Int32 _autoAnswerDivSCMRF;

        /// <summary>���s�^�C�v</summary>
        /// <remarks>0:PCCforNS�����܂�,1:BL�߰µ��ް�����܂�</remarks>
        private Int16 _acceptOrOrderKindRF;
        // 2011/11/11 add end -----------------------------------------------<<


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

		/// public propaty name  :  St_SalesDate
		/// <summary>�J�n���ϓ��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���ϓ��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime St_SalesDate
		{
			get{return _st_SalesDate;}
			set{_st_SalesDate = value;}
		}

		/// public propaty name  :  Ed_SalesDate
		/// <summary>�I�����ϓ��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����ϓ��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime Ed_SalesDate
		{
			get{return _ed_SalesDate;}
			set{_ed_SalesDate = value;}
		}

		/// public propaty name  :  St_SearchSlipDate
		/// <summary>�J�n���͓��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���͓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime St_SearchSlipDate
		{
			get{return _st_SearchSlipDate;}
			set{_st_SearchSlipDate = value;}
		}

		/// public propaty name  :  Ed_SearchSlipDate
		/// <summary>�I�����͓��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����͓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime Ed_SearchSlipDate
		{
			get{return _ed_SearchSlipDate;}
			set{_ed_SearchSlipDate = value;}
		}

		/// public propaty name  :  St_CustomerCode
		/// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_CustomerCode
		{
			get{return _st_CustomerCode;}
			set{_st_CustomerCode = value;}
		}

		/// public propaty name  :  Ed_CustomerCode
		/// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_CustomerCode
		{
			get{return _ed_CustomerCode;}
			set{_ed_CustomerCode = value;}
		}

		/// public propaty name  :  St_SalesEmployeeCd
		/// <summary>�J�n�̔��]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�̔��]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_SalesEmployeeCd
		{
			get{return _st_SalesEmployeeCd;}
			set{_st_SalesEmployeeCd = value;}
		}

		/// public propaty name  :  Ed_SalesEmployeeCd
		/// <summary>�I���̔��]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���̔��]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_SalesEmployeeCd
		{
			get{return _ed_SalesEmployeeCd;}
			set{_ed_SalesEmployeeCd = value;}
		}

		/// public propaty name  :  EstimateDivide
		/// <summary>���σ^�C�v�v���p�e�B</summary>
		/// <value>0:������͕�,1:�������ϕ�,-1:�S��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���σ^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EstimateDivide
		{
			get{return _estimateDivide;}
			set{_estimateDivide = value;}
		}

		/// public propaty name  :  PrintDiv
		/// <summary>���s�^�C�v�v���p�e�B</summary>
		/// <value>0:���όv��,-1:�S��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���s�^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintDiv
		{
			get{return _printDiv;}
			set{_printDiv = value;}
		}

        // 2011/11/11 add start ----------------------------------------------->>
        /// public propaty name  :  AutoAnswerDivSCMRF
        /// <summary>�A�g�`�[�o�͋敪�v���p�e�B</summary>
        /// <value>0:�A�g�`�[���܂܂Ȃ�,1:�A�g�`�[���܂�,2:�A�g�`�[�̂ݑΏ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�g�`�[�o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   x_zhuxk</br>
        /// </remarks>
        public Int32 AutoAnswerDivSCMRF
        {
            get { return _autoAnswerDivSCMRF; }
            set { _autoAnswerDivSCMRF = value; }
        }

        /// public propaty name  :  PrintDiv
        /// <summary>�A�g�`�[�Ώۋ敪�v���p�e�B</summary>
        /// <value>0:PCCforNS�����܂�,1:BL�߰µ��ް�����܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�g�`�[�Ώۋ敪�v���p�e�B</br>
        /// <br>Programer        :   x_zhuxk</br>
        /// </remarks>
        public Int16 AcceptOrOrderKindRF
        {
            get { return _acceptOrOrderKindRF; }
            set { _acceptOrOrderKindRF = value; }
        }
        // 2011/11/11 add end -----------------------------------------------<<

		/// <summary>
		/// ���ϊm�F�\���o�����N���X���[�N���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>EstimateListCndtnWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EstimateListCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public EstimateListCndtnWork()
		{
		}

	}

}
