using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SendBeforOrderCndtnWork
	/// <summary>
	///                      ���M�O���X�g���o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���M�O���X�g���o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/08  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SendBeforOrderCndtnWork
	{
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";
        
        /// <summary>�V�X�e���敪</summary>
		/// <remarks>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</remarks>
		private Int32 _systemDivCd;

		/// <summary>�J�n�I�����C���ԍ�</summary>
		private Int32 _st_OnlineNo;

		/// <summary>�I���I�����C���ԍ�</summary>
		private Int32 _ed_OnlineNo;

		/// <summary>���_�R�[�h�i�����w��j</summary>
		private string[] _sectionCodes;

		/// <summary>�J�nUOE������R�[�h</summary>
		private Int32 _st_UOESupplierCd;

		/// <summary>�I��UOE������R�[�h</summary>
		private Int32 _ed_UOESupplierCd;


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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        
        /// public propaty name  :  SystemDivCd
		/// <summary>�V�X�e���敪�v���p�e�B</summary>
		/// <value>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �V�X�e���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SystemDivCd
		{
			get{return _systemDivCd;}
			set{_systemDivCd = value;}
		}

		/// public propaty name  :  St_OnlineNo
		/// <summary>�J�n�I�����C���ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�I�����C���ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_OnlineNo
		{
			get{return _st_OnlineNo;}
			set{_st_OnlineNo = value;}
		}

		/// public propaty name  :  Ed_OnlineNo
		/// <summary>�I���I�����C���ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���I�����C���ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_OnlineNo
		{
			get{return _ed_OnlineNo;}
			set{_ed_OnlineNo = value;}
		}

		/// public propaty name  :  SectionCodes
		/// <summary>���_�R�[�h�i�����w��j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�i�����w��j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  St_UOESupplierCd
		/// <summary>�J�nUOE������R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�nUOE������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_UOESupplierCd
		{
			get{return _st_UOESupplierCd;}
			set{_st_UOESupplierCd = value;}
		}

		/// public propaty name  :  Ed_UOESupplierCd
		/// <summary>�I��UOE������R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I��UOE������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_UOESupplierCd
		{
			get{return _ed_UOESupplierCd;}
			set{_ed_UOESupplierCd = value;}
		}


		/// <summary>
		/// ���M�O���X�g���o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SendBeforOrderCndtnWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SendBeforOrderCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SendBeforOrderCndtnWork()
		{
		}

	}
}




