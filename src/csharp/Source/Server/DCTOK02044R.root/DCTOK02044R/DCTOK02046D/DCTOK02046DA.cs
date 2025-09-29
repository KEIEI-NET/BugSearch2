using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SalStcCompReportParamWork
	/// <summary>
	///                      ����d���Δ�\(���񌎕�)���o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ����d���Δ�\(���񌎕�)���o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/20  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SalStcCompReportParamWork 
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
		private string[] _sectionCode;

		/// <summary>�J�n�Ώۓ��t</summary>
		private Int32 _stReportDate;

		/// <summary>�I���Ώۓ��t</summary>
		private Int32 _edReportDate;

		/// <summary>�J�n�Ώۓ��t(�݌v)</summary>
		/// <remarks>�݌v���o�͈͂̊J�n���t���Z�b�g</remarks>
		private Int32 _stMonthReportDate;

		/// <summary>�I���Ώۓ��t(�݌v)</summary>
		/// <remarks>�I�����t���Z�b�g</remarks>
		private Int32 _edMonthReportDate;

		/// <summary>�J�n���Ӑ�R�[�h</summary>
		private Int32 _stSupplierCd;

		/// <summary>�I�����Ӑ�R�[�h</summary>
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

		/// public propaty name  :  StReportDate
		/// <summary>�J�n�Ώۓ��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�Ώۓ��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StReportDate
		{
			get{return _stReportDate;}
			set{_stReportDate = value;}
		}

		/// public propaty name  :  EdReportDate
		/// <summary>�I���Ώۓ��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���Ώۓ��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdReportDate
		{
			get{return _edReportDate;}
			set{_edReportDate = value;}
		}

		/// public propaty name  :  StMonthReportDate
		/// <summary>�J�n�Ώۓ��t(�݌v)�v���p�e�B</summary>
		/// <value>�݌v���o�͈͂̊J�n���t���Z�b�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�Ώۓ��t(�݌v)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StMonthReportDate
		{
			get{return _stMonthReportDate;}
			set{_stMonthReportDate = value;}
		}

		/// public propaty name  :  EdMonthReportDate
		/// <summary>�I���Ώۓ��t(�݌v)�v���p�e�B</summary>
		/// <value>�I�����t���Z�b�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���Ώۓ��t(�݌v)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdMonthReportDate
		{
			get{return _edMonthReportDate;}
			set{_edMonthReportDate = value;}
		}

		/// public propaty name  :  StSupplierCd
		/// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StSupplierCd
		{
			get{return _stSupplierCd;}
			set{_stSupplierCd = value;}
		}

		/// public propaty name  :  EdSupplierCd
		/// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdSupplierCd
		{
			get{return _edSupplierCd;}
			set{_edSupplierCd = value;}
		}


		/// <summary>
		/// ����d���Δ�\(���񌎕�)���o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SalStcCompReportParamWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalStcCompReportParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SalStcCompReportParamWork()
		{
		}

	}
}




