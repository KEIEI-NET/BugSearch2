using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SalesSlipYearContrastParamWork
	/// <summary>
	///                      ����d���Δ�\(����N��)���o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ����d���Δ�\(����N��)���o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/18  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SalesSlipYearContrastParamWork 
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���null</remarks>
		private string[] _sectionCodes;

		/// <summary>�J�n�v��N��(����)</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _stAddUpYearMonth;

		/// <summary>�I���v��N��(����)</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _edAddUpYearMonth;

		/// <summary>�J�n�v��N��(����)</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _stAnnualAddUpYearMonth;

		/// <summary>�I���v��N��(����)</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _edAnnualAddUpYearMonth;

		/// <summary>�J�n�d����R�[�h</summary>
		private Int32 _stSupplierCd;

		/// <summary>�I���d����R�[�h</summary>
		private Int32 _edSupplierCd;


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

		/// public propaty name  :  StAddUpYearMonth
		/// <summary>�J�n�v��N��(����)�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�v��N��(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StAddUpYearMonth
		{
			get{return _stAddUpYearMonth;}
			set{_stAddUpYearMonth = value;}
		}

		/// public propaty name  :  EdAddUpYearMonth
		/// <summary>�I���v��N��(����)�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���v��N��(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdAddUpYearMonth
		{
			get{return _edAddUpYearMonth;}
			set{_edAddUpYearMonth = value;}
		}

		/// public propaty name  :  StAnnualAddUpYearMonth
		/// <summary>�J�n�v��N��(����)�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�v��N��(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StAnnualAddUpYearMonth
		{
			get{return _stAnnualAddUpYearMonth;}
			set{_stAnnualAddUpYearMonth = value;}
		}

		/// public propaty name  :  EdAnnualAddUpYearMonth
		/// <summary>�I���v��N��(����)�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���v��N��(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdAnnualAddUpYearMonth
		{
			get{return _edAnnualAddUpYearMonth;}
			set{_edAnnualAddUpYearMonth = value;}
		}

		/// public propaty name  :  StSupplierCd
		/// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StSupplierCd
		{
			get{return _stSupplierCd;}
			set{_stSupplierCd = value;}
		}

		/// public propaty name  :  EdSupplierCd
		/// <summary>�I���d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdSupplierCd
		{
			get{return _edSupplierCd;}
			set{_edSupplierCd = value;}
		}


		/// <summary>
		/// ����d���Δ�\(����N��)���o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SalesSlipYearContrastParamWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesSlipYearContrastParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SalesSlipYearContrastParamWork()
		{
		}

	}
}




