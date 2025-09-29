//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �x���ꗗ�\�i�����j
// �v���O�����T�v   : �x���ꗗ�\�i�����j�̈󎚂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI���@���j
// �� �� ��  2012/09/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ExtrInfo_SumPaymentTotalWork
	/// <summary>
	///                      �x���ꗗ�\�i�����j���o�������[�N���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �x���ꗗ�\�i�����j���o�������[�N���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2012/09/04  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ExtrInfo_SumPaymentTotalWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�I���x���v�㋒�_�R�[�h</summary>
		/// <remarks>null�̏ꍇ�͑S���_</remarks>
		private string[] _paymentAddupSecCodeList;

		/// <summary>����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _cAddUpUpdExecDate;

		/// <summary>�J�n�x����R�[�h</summary>
		private Int32 _st_PayeeCode;

		/// <summary>�I���x����R�[�h</summary>
		private Int32 _ed_PayeeCode;


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
		/// <summary>�I���x���v�㋒�_�R�[�h�v���p�e�B</summary>
		/// <value>null�̏ꍇ�͑S���_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���x���v�㋒�_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public string[] PaymentAddupSecCodeList
		{
			get{return _paymentAddupSecCodeList;}
			set{_paymentAddupSecCodeList = value;}
		}

		/// public propaty name  :  CAddUpUpdExecDate
		/// <summary>�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime CAddUpUpdExecDate
		{
			get{return _cAddUpUpdExecDate;}
			set{_cAddUpUpdExecDate = value;}
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


		/// <summary>
		/// �x���ꗗ�\�i�����j���o�������[�N���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>ExtrInfo_SumPaymentTotalWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note             :   ExtrInfo_SumPaymentTotalWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_SumPaymentTotalWork()
		{
		}

	}

}
