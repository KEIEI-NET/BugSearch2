using System;
using System.Collections;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SearchParaDepositRead
	/// <summary>
	///                      ����/���������p�����[�^�N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ����/���������p�����[�^�N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2007/1/24</br>
	/// <br>Genarated Date   :   2007/05/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2007/05/14  �ؑ� ����</br>
    /// <br>Update Note      :   2007/10/12  �R�c ���F</br>
    /// <br>                 :     �󒍃X�e�[�^�X�̐�����DC�p�ɕύX</br>
    /// <br>                 :     �󒍔ԍ��E�󒍓`�[�ԍ��E�T�[�r�X�`�[�敪�̍폜</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SearchParaDepositRead
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�v�㋒�_�R�[�h</summary>
		/// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
		private string _addUpSecCode = "";

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>������R�[�h</summary>
		private Int32 _claimCode;

		///// <summary>�󒍔ԍ�</summary>
		//private Int32 _acceptAnOrderNo;

		/// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>����`�[�ԍ�</summary>
		private string _salesSlipNum = "";

		///// <summary>�󒍓`�[�ԍ�</summary>
		//private Int32 _acptAnOdrSlipNum;

		/// <summary>�����`�[�ԍ�</summary>
		private Int32 _depositSlipNo;

		/// <summary>������(�J�n)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _depositCallMonthsStart;

		/// <summary>������(�I��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _depositCallMonthsEnd;

		/// <summary>�����ϓ����`�[�ďo�敪</summary>
		private Int32 _alwcDepositCall;

		/// <summary>���������敪</summary>
		/// <remarks>0:�ʏ����,1:��������</remarks>
		private Int32 _autoDepositCd;

		///// <summary>�T�[�r�X�`�[�敪</summary>
		///// <remarks>0:OFF, 1:ON</remarks>
		//private Int32 _serviceSlipCd;


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

		/// public propaty name  :  AddUpSecCode
		/// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
		/// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpSecCode
		{
			get{return _addUpSecCode;}
			set{_addUpSecCode = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  ClaimCode
		/// <summary>������R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ClaimCode
		{
			get{return _claimCode;}
			set{_claimCode = value;}
		}

		///// public propaty name  :  AcceptAnOrderNo
		///// <summary>�󒍔ԍ��v���p�e�B</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note             :   �󒍔ԍ��v���p�e�B</br>
		///// <br>Programer        :   ��������</br>
		///// </remarks>
		//public Int32 AcceptAnOrderNo
		//{
		//	get{return _acceptAnOrderNo;}
		//	set{_acceptAnOrderNo = value;}
		//}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  SalesSlipNum
		/// <summary>����`�[�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesSlipNum
		{
			get{return _salesSlipNum;}
			set{_salesSlipNum = value;}
		}

		///// public propaty name  :  AcptAnOdrSlipNum
		///// <summary>�󒍓`�[�ԍ��v���p�e�B</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note             :   �󒍓`�[�ԍ��v���p�e�B</br>
		///// <br>Programer        :   ��������</br>
		///// </remarks>
		//public Int32 AcptAnOdrSlipNum
		//{
		//	get{return _acptAnOdrSlipNum;}
		//	set{_acptAnOdrSlipNum = value;}
		//}

		/// public propaty name  :  DepositSlipNo
		/// <summary>�����`�[�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DepositSlipNo
		{
			get{return _depositSlipNo;}
			set{_depositSlipNo = value;}
		}

		/// public propaty name  :  DepositCallMonthsStart
		/// <summary>������(�J�n)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DepositCallMonthsStart
		{
			get{return _depositCallMonthsStart;}
			set{_depositCallMonthsStart = value;}
		}

		/// public propaty name  :  DepositCallMonthsEnd
		/// <summary>������(�I��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DepositCallMonthsEnd
		{
			get{return _depositCallMonthsEnd;}
			set{_depositCallMonthsEnd = value;}
		}

		/// public propaty name  :  AlwcDepositCall
		/// <summary>�����ϓ����`�[�ďo�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����ϓ����`�[�ďo�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AlwcDepositCall
		{
			get{return _alwcDepositCall;}
			set{_alwcDepositCall = value;}
		}

		/// public propaty name  :  AutoDepositCd
		/// <summary>���������敪�v���p�e�B</summary>
		/// <value>0:�ʏ����,1:��������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AutoDepositCd
		{
			get{return _autoDepositCd;}
			set{_autoDepositCd = value;}
		}

		///// public propaty name  :  ServiceSlipCd
		///// <summary>�T�[�r�X�`�[�敪�v���p�e�B</summary>
		///// <value>0:OFF, 1:ON</value>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note             :   �T�[�r�X�`�[�敪�v���p�e�B</br>
		///// <br>Programer        :   ��������</br>
		///// </remarks>
		//public Int32 ServiceSlipCd
		//{
		//	get{return _serviceSlipCd;}
		//	set{_serviceSlipCd = value;}
		//}


		/// <summary>
		/// ����/���������p�����[�^�N���X�R���X�g���N�^
		/// </summary>
		/// <returns>SearchParaDepositRead�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SearchParaDepositRead�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SearchParaDepositRead()
		{
		}

	}
}
