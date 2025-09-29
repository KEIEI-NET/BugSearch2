using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   DepsitMainListParamWork
	/// <summary>
	///                      �����m�F�\�����������[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �����m�F�\�����������[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/9/24  �v�ۓc</br>
	/// <br>                 :   �����敪�𕜊�</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class DepsitMainListParamWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h���X�g</summary>
		/// <remarks>�����^�@���z�񍀖�</remarks>
		private string[] _depositAddupSecCodeList;

		/// <summary>�J�n�����v����t</summary>
		private Int32 _st_AddUpADate;

		/// <summary>�I�������v����t</summary>
		private Int32 _ed_AddUpADate;

		/// <summary>�J�n���͓��t</summary>
		private Int32 _st_CreateDate;

		/// <summary>�I�����͓��t</summary>
		private Int32 _ed_CreateDate;

		/// <summary>�J�n���Ӑ�R�[�h</summary>
		private Int32 _st_CustomerCode;

		/// <summary>�I�����Ӑ�R�[�h</summary>
		private Int32 _ed_CustomerCode;

		/// <summary>�J�n���Ӑ�J�i</summary>
		private string _st_CustomerKana = "";

		/// <summary>�I�����Ӑ�J�i</summary>
		private string _ed_CustomerKana = "";

		/// <summary>�S���Ҏ��</summary>
		/// <remarks>0:���Ӑ�S����,1:�W���S����,2:�����S����,3:�������͒S����</remarks>
		private Int32 _employeeKind;

		/// <summary>�J�n�]�ƈ��R�[�h</summary>
		private string _st_EmployeeCd = "";

		/// <summary>�I���]�ƈ��R�[�h</summary>
		private string _ed_EmployeeCd = "";

		/// <summary>�J�n�����ԍ�</summary>
		private Int32 _st_DepositSlipNo;

		/// <summary>�I�������ԍ�</summary>
		private Int32 _ed_DepositSlipNo;

		/// <summary>��������</summary>
		/// <remarks>(-1:�S��,����R�[�h�F���햼�́j</remarks>
		private ArrayList _depositCdKind;

		/// <summary>�����敪</summary>
		/// <remarks>0:�S��,1:�����ς�,2:�ꕔ����,3:������</remarks>
		private Int32 _allowanceDiv;

		/// <summary>���[�^�C�v�敪</summary>
		/// <remarks>1:�����v,2:�Ȉ�,3:����ʏW�v</remarks>
		private Int32 _printDiv;

		/// <summary>�����敪</summary>
		/// <remarks>0:�S��,1:�ʏ�����̂�,2:���������̂�</remarks>
		private Int32 _depositDiv;


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

		/// public propaty name  :  DepositAddupSecCodeList
		/// <summary>���_�R�[�h���X�g�v���p�e�B</summary>
		/// <value>�����^�@���z�񍀖�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h���X�g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] DepositAddupSecCodeList
		{
			get{return _depositAddupSecCodeList;}
			set{_depositAddupSecCodeList = value;}
		}

		/// public propaty name  :  St_AddUpADate
		/// <summary>�J�n�����v����t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�����v����t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_AddUpADate
		{
			get{return _st_AddUpADate;}
			set{_st_AddUpADate = value;}
		}

		/// public propaty name  :  Ed_AddUpADate
		/// <summary>�I�������v����t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�������v����t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_AddUpADate
		{
			get{return _ed_AddUpADate;}
			set{_ed_AddUpADate = value;}
		}

		/// public propaty name  :  St_CreateDate
		/// <summary>�J�n���͓��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���͓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_CreateDate
		{
			get{return _st_CreateDate;}
			set{_st_CreateDate = value;}
		}

		/// public propaty name  :  Ed_CreateDate
		/// <summary>�I�����͓��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����͓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_CreateDate
		{
			get{return _ed_CreateDate;}
			set{_ed_CreateDate = value;}
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

		/// public propaty name  :  St_CustomerKana
		/// <summary>�J�n���Ӑ�J�i�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���Ӑ�J�i�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_CustomerKana
		{
			get{return _st_CustomerKana;}
			set{_st_CustomerKana = value;}
		}

		/// public propaty name  :  Ed_CustomerKana
		/// <summary>�I�����Ӑ�J�i�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����Ӑ�J�i�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_CustomerKana
		{
			get{return _ed_CustomerKana;}
			set{_ed_CustomerKana = value;}
		}

		/// public propaty name  :  EmployeeKind
		/// <summary>�S���Ҏ�ʃv���p�e�B</summary>
		/// <value>0:���Ӑ�S����,1:�W���S����,2:�����S����,3:�������͒S����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �S���Ҏ�ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EmployeeKind
		{
			get{return _employeeKind;}
			set{_employeeKind = value;}
		}

		/// public propaty name  :  St_EmployeeCd
		/// <summary>�J�n�]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_EmployeeCd
		{
			get{return _st_EmployeeCd;}
			set{_st_EmployeeCd = value;}
		}

		/// public propaty name  :  Ed_EmployeeCd
		/// <summary>�I���]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_EmployeeCd
		{
			get{return _ed_EmployeeCd;}
			set{_ed_EmployeeCd = value;}
		}

		/// public propaty name  :  St_DepositSlipNo
		/// <summary>�J�n�����ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�����ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_DepositSlipNo
		{
			get{return _st_DepositSlipNo;}
			set{_st_DepositSlipNo = value;}
		}

		/// public propaty name  :  Ed_DepositSlipNo
		/// <summary>�I�������ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�������ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_DepositSlipNo
		{
			get{return _ed_DepositSlipNo;}
			set{_ed_DepositSlipNo = value;}
		}

		/// public propaty name  :  DepositCdKind
		/// <summary>��������v���p�e�B</summary>
		/// <value>(-1:�S��,����R�[�h�F���햼�́j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList DepositCdKind
		{
			get{return _depositCdKind;}
			set{_depositCdKind = value;}
		}

		/// public propaty name  :  AllowanceDiv
		/// <summary>�����敪�v���p�e�B</summary>
		/// <value>0:�S��,1:�����ς�,2:�ꕔ����,3:������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AllowanceDiv
		{
			get{return _allowanceDiv;}
			set{_allowanceDiv = value;}
		}

		/// public propaty name  :  PrintDiv
		/// <summary>���[�^�C�v�敪�v���p�e�B</summary>
		/// <value>1:�����v,2:�Ȉ�,3:����ʏW�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�^�C�v�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintDiv
		{
			get{return _printDiv;}
			set{_printDiv = value;}
		}

		/// public propaty name  :  DepositDiv
		/// <summary>�����敪�v���p�e�B</summary>
		/// <value>0:�S��,1:�ʏ�����̂�,2:���������̂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DepositDiv
		{
			get{return _depositDiv;}
			set{_depositDiv = value;}
		}


		/// <summary>
		/// �����m�F�\�����������[�N�R���X�g���N�^
		/// </summary>
		/// <returns>DepsitMainListParamWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   DepsitMainListParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DepsitMainListParamWork()
		{
		}

	}
}
