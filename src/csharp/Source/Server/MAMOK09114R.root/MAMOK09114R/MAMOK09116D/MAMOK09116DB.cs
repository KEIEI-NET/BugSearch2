using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SearchEmpSalesTargetParaWork
	/// <summary>
	///                      �]�ƈ��ʔ���ڕW�ݒ茟���p�����[�^���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �]�ƈ��ʔ���ڕW�ݒ茟���p�����[�^���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/11/26  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SearchEmpSalesTargetParaWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�_���폜�敪</summary>
		private Int32 _logicalDeleteCode;

		/// <summary>�S���_�I���i��ƒP�ʁj</summary>
		/// <remarks>true�F�S���_�I���i��ƒP�ʁj�@false�F�ʋ��_�I��</remarks>
		private bool _allSecSelEpUnit;

		/// <summary>�S���_�I���i���_�P�ʁj</summary>
		/// <remarks>true�F�S���_�I���i���_�P�ʁj�@false�F�ʋ��_�I��</remarks>
		private bool _allSecSelSecUnit;

		/// <summary>���_�R�[�h</summary>
		/// <remarks>�z��ŕ������_�w��@�S���_�̏ꍇ��NULL</remarks>
		private String[] _selectSectCd;

		/// <summary>�ڕW�ݒ�敪</summary>
		/// <remarks>10�F���ԖڕW,20�F�ʊ��ԖڕW</remarks>
		private Int32 _targetSetCd;

		/// <summary>�ڕW�Δ�敪</summary>
        /// <remarks>10:���_,20:���_+����,21:���_+����+��,22:���_+�]�ƈ�,30:���_+�Ǝ�,31:���_+�Ǝ�+���Ӑ�,32:���_+�̔��ر,33:���_+�̔��ر+���Ӑ�,40:���_+Ұ��,41:���_+Ұ��+���i</remarks>
		private Int32 _targetContrastCd;

		/// <summary>�ڕW�敪�R�[�h</summary>
		/// <remarks>���ԖڕW�FYYYYMM�A�ʊ��ԖڕW�F�C�ӃR�[�h</remarks>
		private string _targetDivideCode = "";

		/// <summary>�ڕW�敪����</summary>
		private string _targetDivideName = "";

        /// <summary>�]�ƈ��敪</summary>
        private Int32 _employeeDivCd;

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /// <summary>�]�ƈ��R�[�h</summary>
		private string _employeeCode = "";

		/// <summary>�K�p�J�n���i�J�n�j</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _startApplyStaDate;

		/// <summary>�K�p�J�n���i�I���j</summary>
		/// <remarks>YYYYMMDD</remarks>
        private DateTime _endApplyStaDate;

		/// <summary>�K�p�I�����i�J�n�j</summary>
		/// <remarks>YYYYMMDD</remarks>
        private DateTime _startApplyEndDate;

		/// <summary>�K�p�I�����i�I���j</summary>
		/// <remarks>YYYYMMDD</remarks>
        private DateTime _endApplyEndDate;


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

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>�_���폜�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �_���폜�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  AllSecSelEpUnit
		/// <summary>�S���_�I���i��ƒP�ʁj�v���p�e�B</summary>
		/// <value>true�F�S���_�I���i��ƒP�ʁj�@false�F�ʋ��_�I��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �S���_�I���i��ƒP�ʁj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool AllSecSelEpUnit
		{
			get{return _allSecSelEpUnit;}
			set{_allSecSelEpUnit = value;}
		}

		/// public propaty name  :  AllSecSelSecUnit
		/// <summary>�S���_�I���i���_�P�ʁj�v���p�e�B</summary>
		/// <value>true�F�S���_�I���i���_�P�ʁj�@false�F�ʋ��_�I��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �S���_�I���i���_�P�ʁj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool AllSecSelSecUnit
		{
			get{return _allSecSelSecUnit;}
			set{_allSecSelSecUnit = value;}
		}

		/// public propaty name  :  SelectSectCd
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// <value>�z��ŕ������_�w��@�S���_�̏ꍇ��NULL</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String[] SelectSectCd
		{
			get{return _selectSectCd;}
			set{_selectSectCd = value;}
		}

		/// public propaty name  :  TargetSetCd
		/// <summary>�ڕW�ݒ�敪�v���p�e�B</summary>
		/// <value>10�F���ԖڕW,20�F�ʊ��ԖڕW</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ڕW�ݒ�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TargetSetCd
		{
			get{return _targetSetCd;}
			set{_targetSetCd = value;}
		}

		/// public propaty name  :  TargetContrastCd
		/// <summary>�ڕW�Δ�敪�v���p�e�B</summary>
		/// <value>10:���_,20:���_+�]�ƈ�,30:���_+��ر����+�@����,40:���_+Ұ������+���i����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ڕW�Δ�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TargetContrastCd
		{
			get{return _targetContrastCd;}
			set{_targetContrastCd = value;}
		}

		/// public propaty name  :  TargetDivideCode
		/// <summary>�ڕW�敪�R�[�h�v���p�e�B</summary>
		/// <value>���ԖڕW�FYYYYMM�A�ʊ��ԖڕW�F�C�ӃR�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ڕW�敪�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TargetDivideCode
		{
			get{return _targetDivideCode;}
			set{_targetDivideCode = value;}
		}

		/// public propaty name  :  TargetDivideName
		/// <summary>�ڕW�敪���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ڕW�敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TargetDivideName
		{
			get{return _targetDivideName;}
			set{_targetDivideName = value;}
		}

        /// public propaty name  :  EmployeeDivCd
        /// <summary>�]�ƈ��敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EmployeeDivCd
        {
            get { return _employeeDivCd; }
            set { _employeeDivCd = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }

        /// public propaty name  :  EmployeeCode
		/// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EmployeeCode
		{
			get{return _employeeCode;}
			set{_employeeCode = value;}
		}

		/// public propaty name  :  StartApplyStaDate
		/// <summary>�K�p�J�n���i�J�n�j�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �K�p�J�n���i�J�n�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime StartApplyStaDate
		{
			get{return _startApplyStaDate;}
			set{_startApplyStaDate = value;}
		}

		/// public propaty name  :  EndApplyStaDate
		/// <summary>�K�p�J�n���i�I���j�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �K�p�J�n���i�I���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime EndApplyStaDate
		{
			get{return _endApplyStaDate;}
			set{_endApplyStaDate = value;}
		}

		/// public propaty name  :  StartApplyEndDate
		/// <summary>�K�p�I�����i�J�n�j�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �K�p�I�����i�J�n�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime StartApplyEndDate
		{
			get{return _startApplyEndDate;}
			set{_startApplyEndDate = value;}
		}

		/// public propaty name  :  EndApplyEndDate
		/// <summary>�K�p�I�����i�I���j�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �K�p�I�����i�I���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime EndApplyEndDate
		{
			get{return _endApplyEndDate;}
			set{_endApplyEndDate = value;}
		}


		/// <summary>
		/// �]�ƈ��ʔ���ڕW�ݒ茟���p�����[�^���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SearchEmpSalesTargetParaWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SearchEmpSalesTargetParaWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SearchEmpSalesTargetParaWork()
		{
		}

	}
}
