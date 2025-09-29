using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ExtrInfo_BillBalanceWork
	/// <summary>
	///                      ���|�c���ꗗ�\���o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���|�c���ꗗ�\���o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/22  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>UpdateNote       :   11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer       :   3H ������</br>
    /// <br>Date	         :   2020/02/28</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ExtrInfo_BillBalanceWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
		private string[] _sectionCodes;

		/// <summary>�v��N����</summary>
		/// <remarks>YYYYMMDD ������������߂���t�B</remarks>
		private DateTime _addUpDate;

		/// <summary>�Ώ۔N��</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonth;

		/// <summary>�o�͏�</summary>
		/// <remarks>0:���Ӑ揇 1:�S���ҏ� 2:�n�揇</remarks>
		private Int32 _sortOrderDiv;

		/// <summary>�S���ҋ敪</summary>
		/// <remarks>0:���Ӑ�S�� 1:�W���S��</remarks>
		private Int32 _employeeKindDiv;

		/// <summary>�J�n�S���҃R�[�h</summary>
		private string _st_EmployeeCode = "";

		/// <summary>�I���S���҃R�[�h</summary>
		private string _ed_EmployeeCode = "";

		/// <summary>�J�n�̔��G���A�R�[�h</summary>
		private Int32 _st_SalesAreaCode;

		/// <summary>�I���̔��G���A�R�[�h</summary>
		private Int32 _ed_SalesAreaCode;

		/// <summary>�J�n������R�[�h</summary>
		private Int32 _st_ClaimCode;

		/// <summary>�I��������R�[�h</summary>
		private Int32 _ed_ClaimCode;

		/// <summary>�o�͋��z�敪</summary>
		/// <remarks>0:�S�� 1:0����׽ 2:��׽�̂� 3:0�̂� 4:0�ȊO 5:0��ϲŽ 6:ϲŽ�̂�</remarks>
		private Int32 _outMoneyDiv;

		/// <summary>��������敪</summary>
		/// <remarks>0:�󎚂��� 1:�󎚂��Ȃ�</remarks>
		private Int32 _depoDtlDiv;

		// --- ADD START 3H ������ 2020/02/28 ---------->>>>>
        /// <summary>�ŕʓ���󎚋敪</summary>
        /// <remarks>0:�󎚂��� 1:�󎚂��Ȃ�</remarks>
        private Int32 _taxPrintDiv;

        /// <summary>�ŗ�1</summary>
        /// <remarks>�ŗ�1</remarks>
        private Double _taxRate1;

        /// <summary>�ŗ�2</summary>
        /// <remarks>�ŗ�2</remarks>
        private Double _taxRate2;
        // --- ADD END 3H ������ 2020/02/28 ----------<<<<<

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

		/// public propaty name  :  AddUpDate
		/// <summary>�v��N�����v���p�e�B</summary>
		/// <value>YYYYMMDD ������������߂���t�B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AddUpDate
		{
			get{return _addUpDate;}
			set{_addUpDate = value;}
		}

		/// public propaty name  :  AddUpYearMonth
		/// <summary>�Ώ۔N���v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ώ۔N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AddUpYearMonth
		{
			get{return _addUpYearMonth;}
			set{_addUpYearMonth = value;}
		}

		/// public propaty name  :  SortOrderDiv
		/// <summary>�o�͏��v���p�e�B</summary>
		/// <value>0:���Ӑ揇 1:�S���ҏ� 2:�n�揇</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͏��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SortOrderDiv
		{
			get{return _sortOrderDiv;}
			set{_sortOrderDiv = value;}
		}

		/// public propaty name  :  EmployeeKindDiv
		/// <summary>�S���ҋ敪�v���p�e�B</summary>
		/// <value>0:���Ӑ�S�� 1:�W���S��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �S���ҋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EmployeeKindDiv
		{
			get{return _employeeKindDiv;}
			set{_employeeKindDiv = value;}
		}

		/// public propaty name  :  St_EmployeeCode
		/// <summary>�J�n�S���҃R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�S���҃R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_EmployeeCode
		{
			get{return _st_EmployeeCode;}
			set{_st_EmployeeCode = value;}
		}

		/// public propaty name  :  Ed_EmployeeCode
		/// <summary>�I���S���҃R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���S���҃R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_EmployeeCode
		{
			get{return _ed_EmployeeCode;}
			set{_ed_EmployeeCode = value;}
		}

		/// public propaty name  :  St_SalesAreaCode
		/// <summary>�J�n�̔��G���A�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�̔��G���A�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_SalesAreaCode
		{
			get{return _st_SalesAreaCode;}
			set{_st_SalesAreaCode = value;}
		}

		/// public propaty name  :  Ed_SalesAreaCode
		/// <summary>�I���̔��G���A�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���̔��G���A�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_SalesAreaCode
		{
			get{return _ed_SalesAreaCode;}
			set{_ed_SalesAreaCode = value;}
		}

		/// public propaty name  :  St_ClaimCode
		/// <summary>�J�n������R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_ClaimCode
		{
			get{return _st_ClaimCode;}
			set{_st_ClaimCode = value;}
		}

		/// public propaty name  :  Ed_ClaimCode
		/// <summary>�I��������R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I��������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_ClaimCode
		{
			get{return _ed_ClaimCode;}
			set{_ed_ClaimCode = value;}
		}

		/// public propaty name  :  OutMoneyDiv
		/// <summary>�o�͋��z�敪�v���p�e�B</summary>
		/// <value>0:�S�� 1:0����׽ 2:��׽�̂� 3:0�̂� 4:0�ȊO 5:0��ϲŽ 6:ϲŽ�̂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͋��z�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OutMoneyDiv
		{
			get{return _outMoneyDiv;}
			set{_outMoneyDiv = value;}
		}

		/// public propaty name  :  DepoDtlDiv
		/// <summary>��������敪�v���p�e�B</summary>
		/// <value>0:�󎚂��� 1:�󎚂��Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DepoDtlDiv
		{
			get{return _depoDtlDiv;}
			set{_depoDtlDiv = value;}
		}

        // --- ADD START 3H ������ 2020/02/28 ---------->>>>>
        /// public propaty name  :  TaxPrintDiv
        /// <summary>�ŕʓ���󎚋敪</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŕʓ���󎚋敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxPrintDiv
        {
            get { return _taxPrintDiv; }
            set { _taxPrintDiv = value; }
        }

        /// public propaty name  :  TaxRate1
        /// <summary>�ŗ�1</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�1</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TaxRate1
        {
            get { return _taxRate1; }
            set { _taxRate1 = value; }
        }

        /// public propaty name  :  TaxRate2
        /// <summary>�ŗ�2</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�2</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TaxRate2
        {
            get { return _taxRate2; }
            set { _taxRate2 = value; }
        }
        // --- ADD END 3H ������ 2020/02/28 ----------<<<<<

		/// <summary>
		/// ���|�c���ꗗ�\���o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>ExtrInfo_BillBalanceWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_BillBalanceWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_BillBalanceWork()
		{
		}

	}
}
