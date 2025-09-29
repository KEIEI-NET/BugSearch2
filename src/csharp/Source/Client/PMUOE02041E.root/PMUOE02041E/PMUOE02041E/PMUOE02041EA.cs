using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   PublicationConfOrderCndtn
	/// <summary>
	///                      ���s�m�F�ꗗ�\���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���s�m�F�ꗗ�\���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/12/02  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008.12.24 30009 �a�J ��� �v���p�e�B�ǉ�</br>
	/// </remarks>
	public class PublicationConfOrderCndtn
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�V�X�e���敪</summary>
		/// <remarks>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</remarks>
		private Int32 _systemDivCd;

		/// <summary>���_�R�[�h�i�����w��j</summary>
		private string[] _sectionCodes;

		/// <summary>�J�n��M���t</summary>
		private DateTime _st_ReceiveDate;

		/// <summary>�I����M���t</summary>
        private DateTime _ed_ReceiveDate;

		/// <summary>�������</summary>
		/// <remarks>0:�`�F�b�N���̂� 1:�S��</remarks>
		private Int32 _printCndtn;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";


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

        /// public propaty name  :  IsSelectAllSection
        /// <summary>�S�БI���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S�БI���v���p�e�B</br>
        /// <br>Programer        :   30009 �a�J ���</br>
        /// </remarks>
        public bool IsSelectAllSection
        {
            get
            {
                bool isSelAlSec = false;
                if ((this._sectionCodes.Length == 1) && (this._sectionCodes[0].CompareTo("0") == 0))
                {
                    isSelAlSec = true;
                }
                return isSelAlSec;
            }
        }

        /// public propaty name  :  St_ReceiveDate
		/// <summary>�J�n��M���t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n��M���t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime St_ReceiveDate
		{
			get{return _st_ReceiveDate;}
			set{_st_ReceiveDate = value;}
		}

		/// public propaty name  :  Ed_ReceiveDate
		/// <summary>�I����M���t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I����M���t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime Ed_ReceiveDate
		{
			get{return _ed_ReceiveDate;}
			set{_ed_ReceiveDate = value;}
		}

		/// public propaty name  :  PrintCndtn
		/// <summary>��������v���p�e�B</summary>
		/// <value>0:�`�F�b�N���̂� 1:�S��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintCndtn
		{
			get{return _printCndtn;}
			set{_printCndtn = value;}
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>��Ɩ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��Ɩ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}


		/// <summary>
		/// ���s�m�F�ꗗ�\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>PublicationConfOrderCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PublicationConfOrderCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public PublicationConfOrderCndtn()
		{
		}

		/// <summary>
		/// ���s�m�F�ꗗ�\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="systemDivCd">�V�X�e���敪(0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[)</param>
		/// <param name="sectionCodes">���_�R�[�h�i�����w��j</param>
		/// <param name="st_ReceiveDate">�J�n��M���t</param>
		/// <param name="ed_ReceiveDate">�I����M���t</param>
		/// <param name="printCndtn">�������(0:�`�F�b�N���̂� 1:�S��)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <returns>PublicationConfOrderCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PublicationConfOrderCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public PublicationConfOrderCndtn(string enterpriseCode, Int32 systemDivCd, string[] sectionCodes, DateTime st_ReceiveDate, DateTime ed_ReceiveDate, Int32 printCndtn, string enterpriseName)
		{
			this._enterpriseCode = enterpriseCode;
			this._systemDivCd = systemDivCd;
			this._sectionCodes = sectionCodes;
			this._st_ReceiveDate = st_ReceiveDate;
			this._ed_ReceiveDate = ed_ReceiveDate;
			this._printCndtn = printCndtn;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// ���s�m�F�ꗗ�\���o�����N���X��������
		/// </summary>
		/// <returns>PublicationConfOrderCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PublicationConfOrderCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public PublicationConfOrderCndtn Clone()
		{
			return new PublicationConfOrderCndtn(this._enterpriseCode,this._systemDivCd,this._sectionCodes,this._st_ReceiveDate,this._ed_ReceiveDate,this._printCndtn,this._enterpriseName);
		}

		/// <summary>
		/// ���s�m�F�ꗗ�\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�PublicationConfOrderCndtn�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PublicationConfOrderCndtn�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(PublicationConfOrderCndtn target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SystemDivCd == target.SystemDivCd)
				 && (this.SectionCodes == target.SectionCodes)
				 && (this.St_ReceiveDate == target.St_ReceiveDate)
				 && (this.Ed_ReceiveDate == target.Ed_ReceiveDate)
				 && (this.PrintCndtn == target.PrintCndtn)
				 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// ���s�m�F�ꗗ�\���o�����N���X��r����
		/// </summary>
		/// <param name="publicationConfOrderCndtn1">
		///                    ��r����PublicationConfOrderCndtn�N���X�̃C���X�^���X
		/// </param>
		/// <param name="publicationConfOrderCndtn2">��r����PublicationConfOrderCndtn�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PublicationConfOrderCndtn�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(PublicationConfOrderCndtn publicationConfOrderCndtn1, PublicationConfOrderCndtn publicationConfOrderCndtn2)
		{
			return ((publicationConfOrderCndtn1.EnterpriseCode == publicationConfOrderCndtn2.EnterpriseCode)
				 && (publicationConfOrderCndtn1.SystemDivCd == publicationConfOrderCndtn2.SystemDivCd)
				 && (publicationConfOrderCndtn1.SectionCodes == publicationConfOrderCndtn2.SectionCodes)
				 && (publicationConfOrderCndtn1.St_ReceiveDate == publicationConfOrderCndtn2.St_ReceiveDate)
				 && (publicationConfOrderCndtn1.Ed_ReceiveDate == publicationConfOrderCndtn2.Ed_ReceiveDate)
				 && (publicationConfOrderCndtn1.PrintCndtn == publicationConfOrderCndtn2.PrintCndtn)
				 && (publicationConfOrderCndtn1.EnterpriseName == publicationConfOrderCndtn2.EnterpriseName));
		}
		/// <summary>
		/// ���s�m�F�ꗗ�\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�PublicationConfOrderCndtn�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PublicationConfOrderCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(PublicationConfOrderCndtn target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SystemDivCd != target.SystemDivCd)resList.Add("SystemDivCd");
			if(this.SectionCodes != target.SectionCodes)resList.Add("SectionCodes");
			if(this.St_ReceiveDate != target.St_ReceiveDate)resList.Add("St_ReceiveDate");
			if(this.Ed_ReceiveDate != target.Ed_ReceiveDate)resList.Add("Ed_ReceiveDate");
			if(this.PrintCndtn != target.PrintCndtn)resList.Add("PrintCndtn");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// ���s�m�F�ꗗ�\���o�����N���X��r����
		/// </summary>
		/// <param name="publicationConfOrderCndtn1">��r����PublicationConfOrderCndtn�N���X�̃C���X�^���X</param>
		/// <param name="publicationConfOrderCndtn2">��r����PublicationConfOrderCndtn�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PublicationConfOrderCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(PublicationConfOrderCndtn publicationConfOrderCndtn1, PublicationConfOrderCndtn publicationConfOrderCndtn2)
		{
			ArrayList resList = new ArrayList();
			if(publicationConfOrderCndtn1.EnterpriseCode != publicationConfOrderCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(publicationConfOrderCndtn1.SystemDivCd != publicationConfOrderCndtn2.SystemDivCd)resList.Add("SystemDivCd");
			if(publicationConfOrderCndtn1.SectionCodes != publicationConfOrderCndtn2.SectionCodes)resList.Add("SectionCodes");
			if(publicationConfOrderCndtn1.St_ReceiveDate != publicationConfOrderCndtn2.St_ReceiveDate)resList.Add("St_ReceiveDate");
			if(publicationConfOrderCndtn1.Ed_ReceiveDate != publicationConfOrderCndtn2.Ed_ReceiveDate)resList.Add("Ed_ReceiveDate");
			if(publicationConfOrderCndtn1.PrintCndtn != publicationConfOrderCndtn2.PrintCndtn)resList.Add("PrintCndtn");
			if(publicationConfOrderCndtn1.EnterpriseName != publicationConfOrderCndtn2.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}
	}
}
