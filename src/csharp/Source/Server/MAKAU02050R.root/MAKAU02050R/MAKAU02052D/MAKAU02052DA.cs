using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ExtrInfo_DemandDetailWork
	/// <summary>
	///                      ������(���׏����)���o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ������(���׏����)���o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/05/17  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ExtrInfo_DemandDetailWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�v�㋒�_�R�[�h</summary>
		/// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
		private string _addUpSecCode = "";

		/// <summary>���o�Ώیv���(�J�n)</summary>
		/// <remarks>"YYYYMMDD"  ������J�n�v����ƂȂ�N����</remarks>
		private DateTime _addUpADateSt;

		/// <summary>���o�Ώیv���(�I��)</summary>
		/// <remarks>"YYYYMMDD"  ������I���v����ƂȂ�N����</remarks>
        private DateTime _addUpADateEd;

		/// <summary>������R�[�h</summary>
		private Int32 _claimCode;

		/// <summary>�������ג��o�L��</summary>
		private bool _isExtractDepo;

		/// <summary>���גP��</summary>
        /// <remarks>0:�ڍגP�� 1:���גP�� 2:�`�[�P��</remarks>
		private Int32 _detailsUnit;


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

		/// public propaty name  :  AddUpADateSt
		/// <summary>���o�Ώیv���(�J�n)�v���p�e�B</summary>
		/// <value>"YYYYMMDD"  ������J�n�v����ƂȂ�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�Ώیv���(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime AddUpADateSt
		{
			get{return _addUpADateSt;}
			set{_addUpADateSt = value;}
		}

		/// public propaty name  :  AddUpADateEd
		/// <summary>���o�Ώیv���(�I��)�v���p�e�B</summary>
		/// <value>"YYYYMMDD"  ������I���v����ƂȂ�N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�Ώیv���(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime AddUpADateEd
		{
			get{return _addUpADateEd;}
			set{_addUpADateEd = value;}
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

		/// public propaty name  :  IsExtractDepo
		/// <summary>�������ג��o�L���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������ג��o�L���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool IsExtractDepo
		{
			get{return _isExtractDepo;}
			set{_isExtractDepo = value;}
		}

		/// public propaty name  :  DetailsUnit
		/// <summary>���גP�ʃv���p�e�B</summary>
        /// <value>0:�ڍגP�� 1:���גP�� 2:�`�[�P��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���גP�ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DetailsUnit
		{
			get{return _detailsUnit;}
			set{_detailsUnit = value;}
		}


		/// <summary>
		/// ������(���׏����)���o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>ExtrInfo_DemandDetailWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandDetailWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_DemandDetailWork()
		{
		}

	}
}