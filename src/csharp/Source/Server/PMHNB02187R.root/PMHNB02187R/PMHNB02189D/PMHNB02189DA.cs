using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   CustSalesDistributionReportParamWork
	/// <summary>
	///                      ���Ӑ�ʎ�����z�\���o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���Ӑ�ʎ�����z�\���o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/21  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class CustSalesDistributionReportParamWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
		private string[] _sectionCode;

		/// <summary>�J�n�Ώۓ��t</summary>
		private Int32 _stSalesDate;

		/// <summary>�I���Ώۓ��t</summary>
		private Int32 _edSalesDate;

		/// <summary>�J�n�̔��]�ƈ��R�[�h</summary>
		private string _stSalesEmployeeCd = "";

		/// <summary>�I���̔��]�ƈ��R�[�h</summary>
		private string _edSalesEmployeeCd = "";

		/// <summary>�̔��G���A�R�[�h</summary>
		/// <remarks>�n��R�[�h</remarks>
		private Int32 _stSalesAreaCode;

		/// <summary>�̔��G���A�R�[�h</summary>
		/// <remarks>�n��R�[�h</remarks>
		private Int32 _edSalesAreaCode;

		/// <summary>�J�n���Ӑ�R�[�h</summary>
		private Int32 _stCustomerCode;

		/// <summary>�I�����Ӑ�R�[�h</summary>
		private Int32 _edCustomerCode;

		/// <summary>���s�^�C�v</summary>
		/// <remarks>0:���Ӑ� 1:�S���� 2:�n��</remarks>
		private Int32 _printDiv;

		/// <summary>���і�����敪</summary>
		/// <remarks>0:���� 1:���Ȃ�</remarks>
		private Int32 _searchDiv;


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
		/// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
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

		/// public propaty name  :  StSalesDate
		/// <summary>�J�n�Ώۓ��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�Ώۓ��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StSalesDate
		{
			get{return _stSalesDate;}
			set{_stSalesDate = value;}
		}

		/// public propaty name  :  EdSalesDate
		/// <summary>�I���Ώۓ��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���Ώۓ��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdSalesDate
		{
			get{return _edSalesDate;}
			set{_edSalesDate = value;}
		}

		/// public propaty name  :  StSalesEmployeeCd
		/// <summary>�J�n�̔��]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�̔��]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StSalesEmployeeCd
		{
			get{return _stSalesEmployeeCd;}
			set{_stSalesEmployeeCd = value;}
		}

		/// public propaty name  :  EdSalesEmployeeCd
		/// <summary>�I���̔��]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���̔��]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EdSalesEmployeeCd
		{
			get{return _edSalesEmployeeCd;}
			set{_edSalesEmployeeCd = value;}
		}

		/// public propaty name  :  StSalesAreaCode
		/// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
		/// <value>�n��R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StSalesAreaCode
		{
			get{return _stSalesAreaCode;}
			set{_stSalesAreaCode = value;}
		}

		/// public propaty name  :  EdSalesAreaCode
		/// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
		/// <value>�n��R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdSalesAreaCode
		{
			get{return _edSalesAreaCode;}
			set{_edSalesAreaCode = value;}
		}

		/// public propaty name  :  StCustomerCode
		/// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StCustomerCode
		{
			get{return _stCustomerCode;}
			set{_stCustomerCode = value;}
		}

		/// public propaty name  :  EdCustomerCode
		/// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdCustomerCode
		{
			get{return _edCustomerCode;}
			set{_edCustomerCode = value;}
		}

		/// public propaty name  :  PrintDiv
		/// <summary>���s�^�C�v�v���p�e�B</summary>
		/// <value>0:���Ӑ� 1:�S���� 2:�n��</value>
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

		/// public propaty name  :  SearchDiv
		/// <summary>���і�����敪�v���p�e�B</summary>
		/// <value>0:���� 1:���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���і�����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SearchDiv
		{
			get{return _searchDiv;}
			set{_searchDiv = value;}
		}


		/// <summary>
		/// ���Ӑ�ʎ�����z�\���o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>CustSalesDistributionReportParamWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustSalesDistributionReportParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustSalesDistributionReportParamWork()
		{
		}

	}
}
