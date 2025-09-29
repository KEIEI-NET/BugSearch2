using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SalesMonthYearReportParamWork
	/// <summary>
	///                      ���㌎��N��o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���㌎��N��o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/08  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SalesMonthYearReportParamWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
		private string[] _sectionCodes;

		/// <summary>�W�v�P��</summary>
		/// <remarks>0:���Ӑ�� 1:�S���ҕ� 2:�󒍎ҕ� 3:���s�ҕ� 4:�n��� 5:�Ǝ�� 6:�̔��敪��</remarks>
		private Int32 _totalType;

		/// <summary>�W�v���@</summary>
		/// <remarks>0:�S�� 1:���_��</remarks>
		private Int32 _ttlType;

		/// <summary>����^�C�v</summary>
		/// <remarks>0:���� 1:���� 2:����������</remarks>
		private Int32 _printType;

		/// <summary>�o�͏�</summary>
		/// <remarks>���o�͏��ɂ��ĎQ��</remarks>
		private Int32 _outType;

		/// <summary>�J�n�Ώ۔N��(����)</summary>
		/// <remarks>�v��N��(YYYYMM)</remarks>
		private DateTime _addUpYearMonthSt;

		/// <summary>�I���Ώ۔N��(����)</summary>
		/// <remarks>�v��N��(YYYYMM)</remarks>
		private DateTime _addUpYearMonthEd;

		/// <summary>�J�n�Ώ۔N��(����)</summary>
		/// <remarks>����(YYYYMM)</remarks>
		private DateTime _annualAddUpYearMonthSt;

		/// <summary>�I���Ώ۔N��(����)</summary>
		/// <remarks>�v��N��(YYYYMM)</remarks>
		private DateTime _annualAddUpYaerMonthEd;

		/// <summary>�J�n���Ӑ�R�[�h</summary>
		private Int32 _customerCodeSt;

		/// <summary>�I�����Ӑ�R�[�h</summary>
		private Int32 _customerCodeEd;

		/// <summary>�J�n�����R�[�h</summary>
		/// <remarks>XXX�R�[�h���Z�b�g�@�W�v�P�ʂɂ��ω�(�W�v�P��=0:�Ȃ� 1:�S���� 2:�󒍎� 3:���s�� 4:�n�� 5:�Ǝ� 6:�̔��敪)</remarks>
		private string _srchCodeSt = "";

		/// <summary>�I�������R�[�h</summary>
		/// <remarks>XXX�R�[�h���Z�b�g�@�W�v�P�ʂɂ��ω�(�W�v�P��=0:�Ȃ� 1:�S���� 2:�󒍎� 3:���s�� 4:�n�� 5:�Ǝ� 6:�̔��敪)</remarks>
		private string _srchCodeEd = "";


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
		/// <value>0:���Ӑ�� 1:�S���ҕ� 2:�󒍎ҕ� 3:���s�ҕ� 4:�n��� 5:�Ǝ�� 6:�̔��敪��</value>
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

		/// public propaty name  :  PrintType
		/// <summary>����^�C�v�v���p�e�B</summary>
		/// <value>0:���� 1:���� 2:����������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintType
		{
			get{return _printType;}
			set{_printType = value;}
		}

		/// public propaty name  :  OutType
		/// <summary>�o�͏��v���p�e�B</summary>
		/// <value>���o�͏��ɂ��ĎQ��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͏��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OutType
		{
			get{return _outType;}
			set{_outType = value;}
		}

		/// public propaty name  :  AddUpYearMonthSt
		/// <summary>�J�n�Ώ۔N��(����)�v���p�e�B</summary>
		/// <value>�v��N��(YYYYMM)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�Ώ۔N��(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AddUpYearMonthSt
		{
			get{return _addUpYearMonthSt;}
			set{_addUpYearMonthSt = value;}
		}

		/// public propaty name  :  AddUpYearMonthEd
		/// <summary>�I���Ώ۔N��(����)�v���p�e�B</summary>
		/// <value>�v��N��(YYYYMM)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���Ώ۔N��(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AddUpYearMonthEd
		{
			get{return _addUpYearMonthEd;}
			set{_addUpYearMonthEd = value;}
		}

		/// public propaty name  :  AnnualAddUpYearMonthSt
		/// <summary>�J�n�Ώ۔N��(����)�v���p�e�B</summary>
		/// <value>����(YYYYMM)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�Ώ۔N��(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AnnualAddUpYearMonthSt
		{
			get{return _annualAddUpYearMonthSt;}
			set{_annualAddUpYearMonthSt = value;}
		}

		/// public propaty name  :  AnnualAddUpYaerMonthEd
		/// <summary>�I���Ώ۔N��(����)�v���p�e�B</summary>
		/// <value>�v��N��(YYYYMM)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���Ώ۔N��(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AnnualAddUpYaerMonthEd
		{
			get{return _annualAddUpYaerMonthEd;}
			set{_annualAddUpYaerMonthEd = value;}
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

		/// public propaty name  :  SrchCodeSt
		/// <summary>�J�n�����R�[�h�v���p�e�B</summary>
		/// <value>XXX�R�[�h���Z�b�g�@�W�v�P�ʂɂ��ω�(�W�v�P��=0:�Ȃ� 1:�S���� 2:�󒍎� 3:���s�� 4:�n�� 5:�Ǝ� 6:�̔��敪)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SrchCodeSt
		{
			get{return _srchCodeSt;}
			set{_srchCodeSt = value;}
		}

		/// public propaty name  :  SrchCodeEd
		/// <summary>�I�������R�[�h�v���p�e�B</summary>
		/// <value>XXX�R�[�h���Z�b�g�@�W�v�P�ʂɂ��ω�(�W�v�P��=0:�Ȃ� 1:�S���� 2:�󒍎� 3:���s�� 4:�n�� 5:�Ǝ� 6:�̔��敪)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SrchCodeEd
		{
			get{return _srchCodeEd;}
			set{_srchCodeEd = value;}
		}


		/// <summary>
		/// ���㌎��N��o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SalesMonthYearReportParamWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesMonthYearReportParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SalesMonthYearReportParamWork()
		{
		}

	}
}
