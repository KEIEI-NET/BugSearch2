//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ茟���p�����[�^���[�N
// �v���O�����T�v   : �����f�[�^�e�L�X�g�ϊ������N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// �Ǘ��ԍ�  11500865-00  �쐬�S�� : 杍^
// �� �� ��  2019/09/02   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SearchEmpScSalesTargetParaWork
	/// <summary>
    ///                      �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ茟���p�����[�^���[�N
	/// </summary>
	/// <remarks>
    /// <br>note             :   �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ茟���p�����[�^���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
    /// <br>Genarated Date   :   2019/09/02  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SearchEmpScSalesTargetParaWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�_���폜�敪</summary>
		private Int32 _logicalDeleteCode;

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

        /// <summary>�]�ƈ��R�[�h</summary>
		private string _employeeCode = "";

        /// <summary>�̔��敪�R�[�h</summary>
        private Int32 _salesCode;

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

        /// public propaty name  :  SalesCode
        /// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
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
        /// <returns>SearchEmpScSalesTargetParaWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchEmpScSalesTargetParaWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public SearchEmpScSalesTargetParaWork()
		{
		}

	}
}
