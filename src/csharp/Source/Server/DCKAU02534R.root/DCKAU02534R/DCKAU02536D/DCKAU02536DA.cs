using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ExtrInfo_CollectPlanWork
	/// <summary>
	///                      ����\��\���o�������[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ����\��\���o�������[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/08  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   12/25  �R�c</br>
	/// <br>                 :   ���������w���ǉ�</br>
	/// <br>                 :   ����\��������w���ǉ�</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ExtrInfo_CollectPlanWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�o�͑Ώۋ��_</summary>
		/// <remarks>null�̏ꍇ�͑S���_</remarks>
		private string[] _collectAddupSecCodeList;

		/// <summary>������</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _addUpDate;

		/// <summary>�o�͏�</summary>
		/// <remarks>1:���Ӑ揇 2:�S���ҏ� 3:�n�揇 4:�S���ҕʉ������ 5:�n��ʉ������ 6:�W������ 7:�W�����ʉ��������</remarks>
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

		/// <summary>����</summary>
		/// <remarks>99�w�莞�͑S��</remarks>
		private Int32 _totalDay;

		/// <summary>���������w��</summary>
		/// <remarks>true:28�`31�S�� false:�w������̂�</remarks>
		private Boolean _isLastDayTotalDay;

		/// <summary>����\���</summary>
		private Int32 _collectSchedule;

		/// <summary>����\��������w��</summary>
		/// <remarks>true:28�`31�S�� false:�w������̂�</remarks>
		private Boolean _isLastDayCollectSchedule;

		/// <summary>�������</summary>
		/// <remarks>�I�����ꂽ�����ނ��i�[ 10:�����Ȃ�(�}�X�^�ݒ�ɂ��) null�̏ꍇ�͑S��</remarks>
		private Int32[] _collectCond;


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

		/// public propaty name  :  CollectAddupSecCodeList
		/// <summary>�o�͑Ώۋ��_�v���p�e�B</summary>
		/// <value>null�̏ꍇ�͑S���_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͑Ώۋ��_�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] CollectAddupSecCodeList
		{
			get{return _collectAddupSecCodeList;}
			set{_collectAddupSecCodeList = value;}
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
		/// <value>1:���Ӑ揇 2:�S���ҏ� 3:�n�揇 4:�S���ҕʉ������ 5:�n��ʉ������ 6:�W������ 7:�W�����ʉ��������</value>
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

		/// public propaty name  :  TotalDay
		/// <summary>�����v���p�e�B</summary>
		/// <value>99�w�莞�͑S��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TotalDay
		{
			get{return _totalDay;}
			set{_totalDay = value;}
		}

		/// public propaty name  :  IsLastDayTotalDay
		/// <summary>���������w��v���p�e�B</summary>
		/// <value>true:28�`31�S�� false:�w������̂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������w��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean IsLastDayTotalDay
		{
			get{return _isLastDayTotalDay;}
			set{_isLastDayTotalDay = value;}
		}

		/// public propaty name  :  CollectSchedule
		/// <summary>����\����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����\����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CollectSchedule
		{
			get{return _collectSchedule;}
			set{_collectSchedule = value;}
		}

		/// public propaty name  :  IsLastDayCollectSchedule
		/// <summary>����\��������w��v���p�e�B</summary>
		/// <value>true:28�`31�S�� false:�w������̂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����\��������w��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean IsLastDayCollectSchedule
		{
			get{return _isLastDayCollectSchedule;}
			set{_isLastDayCollectSchedule = value;}
		}

		/// public propaty name  :  CollectCond
		/// <summary>��������v���p�e�B</summary>
		/// <value>�I�����ꂽ�����ނ��i�[ 10:�����Ȃ�(�}�X�^�ݒ�ɂ��) null�̏ꍇ�͑S��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32[] CollectCond
		{
			get{return _collectCond;}
			set{_collectCond = value;}
		}


		/// <summary>
		/// ����\��\���o�������[�N�R���X�g���N�^
		/// </summary>
		/// <returns>ExtrInfo_CollectPlanWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_CollectPlanWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_CollectPlanWork()
		{
		}

	}

}
