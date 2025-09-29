using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ExtrInfo_PaymentPlanWork
	/// <summary>
	///                      �x���\��\���o�������[�N���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �x���\��\���o�������[�N���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ExtrInfo_PaymentPlanWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�o�͑Ώۋ��_</summary>
		/// <remarks>null�̏ꍇ�͑S���_</remarks>
		private string[] _paymentAddupSecCodeList;

		/// <summary>������</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _addUpDate;

		/// <summary>�o�͏�</summary>
		/// <remarks>1:�d���揇 2:�S���ҏ� 3:�S���ҕʎx������ 4:�x������ 5:�x�����ʎx��������</remarks>
		private Int32 _sortOrderDiv;

		/// <summary>�J�n�S���҃R�[�h</summary>
		/// <remarks>�d���S��</remarks>
		private string _st_EmployeeCode = "";

		/// <summary>�I���S���҃R�[�h</summary>
		/// <remarks>�d���S��</remarks>
		private string _ed_EmployeeCode = "";

		/// <summary>�J�n�x����R�[�h</summary>
		private Int32 _st_PayeeCode;

		/// <summary>�I���x����R�[�h</summary>
		private Int32 _ed_PayeeCode;

		/// <summary>����</summary>
		/// <remarks>99�w�莞��28���ȍ~�S��</remarks>
        private Int32 _cAddUpUpdExecDate;

		/// <summary>���������w��</summary>
		/// <remarks>true:28�`31�S�� false:�w������̂�</remarks>
		private Boolean _isLastDayCAddUpUpdExecDate;

		/// <summary>�x���\���</summary>
		/// <remarks>���񐿋����̎x���i�����j�\���</remarks>
        private Int32 _paymentSchedule;

		/// <summary>�x���\��������w��</summary>
		/// <remarks>true:28�`31�S�� false:�w��x���\����̂�</remarks>
		private Boolean _isLastDayPaymentSchedule;

		/// <summary>�x������</summary>
		/// <remarks>�I�����ꂽ�����ނ��i�[ 10:�����Ȃ�(�}�X�^�ݒ�ɂ��) null�̏ꍇ�͑S��</remarks>
		private Int32[] _paymentCond;


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

		/// public propaty name  :  PaymentAddupSecCodeList
		/// <summary>�o�͑Ώۋ��_�v���p�e�B</summary>
		/// <value>null�̏ꍇ�͑S���_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͑Ώۋ��_�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public string[] PaymentAddupSecCodeList
		{
			get{return _paymentAddupSecCodeList;}
			set{_paymentAddupSecCodeList = value;}
		}

		/// public propaty name  :  AddUpDate
		/// <summary>�������v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AddUpDate
		{
			get{return _addUpDate;}
			set{_addUpDate = value;}
		}

		/// public propaty name  :  SortOrderDiv
		/// <summary>�o�͏��v���p�e�B</summary>
		/// <value>1:�d���揇 2:�S���ҏ� 3:�S���ҕʎx������ 4:�x������ 5:�x�����ʎx��������</value>
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

		/// public propaty name  :  St_EmployeeCode
		/// <summary>�J�n�S���҃R�[�h�v���p�e�B</summary>
		/// <value>�d���S��</value>
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
		/// <value>�d���S��</value>
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

		/// public propaty name  :  St_PayeeCode
		/// <summary>�J�n�x����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�x����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_PayeeCode
		{
			get{return _st_PayeeCode;}
			set{_st_PayeeCode = value;}
		}

		/// public propaty name  :  Ed_PayeeCode
		/// <summary>�I���x����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���x����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_PayeeCode
		{
			get{return _ed_PayeeCode;}
			set{_ed_PayeeCode = value;}
		}

		/// public propaty name  :  CAddUpUpdExecDate
		/// <summary>�����v���p�e�B</summary>
		/// <value>99�w�莞��28���ȍ~�S��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int32 CAddUpUpdExecDate
		{
			get{return _cAddUpUpdExecDate;}
			set{_cAddUpUpdExecDate = value;}
		}

		/// public propaty name  :  IsLastDayCAddUpUpdExecDate
		/// <summary>���������w��v���p�e�B</summary>
		/// <value>true:28�`31�S�� false:�w������̂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������w��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean IsLastDayCAddUpUpdExecDate
		{
			get{return _isLastDayCAddUpUpdExecDate;}
			set{_isLastDayCAddUpUpdExecDate = value;}
		}

		/// public propaty name  :  PaymentSchedule
		/// <summary>�x���\����v���p�e�B</summary>
		/// <value>���񐿋����̎x���i�����j�\���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���\����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int32 PaymentSchedule
		{
			get{return _paymentSchedule;}
			set{_paymentSchedule = value;}
		}

		/// public propaty name  :  IsLastDayPaymentSchedule
		/// <summary>�x���\��������w��v���p�e�B</summary>
		/// <value>true:28�`31�S�� false:�w��x���\����̂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���\��������w��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean IsLastDayPaymentSchedule
		{
			get{return _isLastDayPaymentSchedule;}
			set{_isLastDayPaymentSchedule = value;}
		}

		/// public propaty name  :  PaymentCond
		/// <summary>�x�������v���p�e�B</summary>
		/// <value>�I�����ꂽ�����ނ��i�[ 10:�����Ȃ�(�}�X�^�ݒ�ɂ��) null�̏ꍇ�͑S��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x�������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32[] PaymentCond
		{
			get{return _paymentCond;}
			set{_paymentCond = value;}
		}


		/// <summary>
		/// �x���\��\���o�������[�N���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>ExtrInfo_PaymentPlanWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_PaymentPlanWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_PaymentPlanWork()
		{
		}

	}

}
