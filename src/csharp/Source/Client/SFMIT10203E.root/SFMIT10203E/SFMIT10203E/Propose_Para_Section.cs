using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   Propose_Para_Section
	/// <summary>
	///                      ��ď��i�N���p�����[�^�N���X�i���_�j
	/// </summary>
	/// <remarks>
	/// <br>note             :   ��ď��i�N���p�����[�^�N���X�i���_�j�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2016/5/24</br>
	/// <br>Genarated Date   :   2016/05/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class Propose_Para_Section
	{
		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

		/// <summary>���_�K�C�h����</summary>
		private string _sectionGuideNm = "";

		/// <summary>�{�Ћ@�\�t���O</summary>
		/// <remarks>0:���_ 1:�{��</remarks>
		private Int32 _mainOfficeFuncFlag;


		/// public propaty name  :  SectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  SectionGuideNm
		/// <summary>���_�K�C�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionGuideNm
		{
			get{return _sectionGuideNm;}
			set{_sectionGuideNm = value;}
		}

		/// public propaty name  :  MainOfficeFuncFlag
		/// <summary>�{�Ћ@�\�t���O�v���p�e�B</summary>
		/// <value>0:���_ 1:�{��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �{�Ћ@�\�t���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MainOfficeFuncFlag
		{
			get{return _mainOfficeFuncFlag;}
			set{_mainOfficeFuncFlag = value;}
		}


		/// <summary>
		/// ��ď��i�N���p�����[�^�N���X�i���_�j�R���X�g���N�^
		/// </summary>
		/// <returns>Propose_Para_Section�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Propose_Para_Section�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Propose_Para_Section()
		{
		}

		/// <summary>
		/// ��ď��i�N���p�����[�^�N���X�i���_�j�R���X�g���N�^
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="sectionGuideNm">���_�K�C�h����</param>
		/// <param name="mainOfficeFuncFlag">�{�Ћ@�\�t���O(0:���_ 1:�{��)</param>
		/// <returns>Propose_Para_Section�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Propose_Para_Section�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Propose_Para_Section(string sectionCode,string sectionGuideNm,Int32 mainOfficeFuncFlag)
		{
			this._sectionCode = sectionCode;
			this._sectionGuideNm = sectionGuideNm;
			this._mainOfficeFuncFlag = mainOfficeFuncFlag;

		}

		/// <summary>
		/// ��ď��i�N���p�����[�^�N���X�i���_�j��������
		/// </summary>
		/// <returns>Propose_Para_Section�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����Propose_Para_Section�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Propose_Para_Section Clone()
		{
			return new Propose_Para_Section(this._sectionCode,this._sectionGuideNm,this._mainOfficeFuncFlag);
		}

		/// <summary>
		/// ��ď��i�N���p�����[�^�N���X�i���_�j��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�Propose_Para_Section�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Propose_Para_Section�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(Propose_Para_Section target)
		{
			return ((this.SectionCode == target.SectionCode)
				 && (this.SectionGuideNm == target.SectionGuideNm)
				 && (this.MainOfficeFuncFlag == target.MainOfficeFuncFlag));
		}

		/// <summary>
		/// ��ď��i�N���p�����[�^�N���X�i���_�j��r����
		/// </summary>
		/// <param name="propose_Para_Section1">
		///                    ��r����Propose_Para_Section�N���X�̃C���X�^���X
		/// </param>
		/// <param name="propose_Para_Section2">��r����Propose_Para_Section�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Propose_Para_Section�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(Propose_Para_Section propose_Para_Section1, Propose_Para_Section propose_Para_Section2)
		{
			return ((propose_Para_Section1.SectionCode == propose_Para_Section2.SectionCode)
				 && (propose_Para_Section1.SectionGuideNm == propose_Para_Section2.SectionGuideNm)
				 && (propose_Para_Section1.MainOfficeFuncFlag == propose_Para_Section2.MainOfficeFuncFlag));
		}
		/// <summary>
		/// ��ď��i�N���p�����[�^�N���X�i���_�j��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�Propose_Para_Section�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Propose_Para_Section�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(Propose_Para_Section target)
		{
			ArrayList resList = new ArrayList();
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.SectionGuideNm != target.SectionGuideNm)resList.Add("SectionGuideNm");
			if(this.MainOfficeFuncFlag != target.MainOfficeFuncFlag)resList.Add("MainOfficeFuncFlag");

			return resList;
		}

		/// <summary>
		/// ��ď��i�N���p�����[�^�N���X�i���_�j��r����
		/// </summary>
		/// <param name="propose_Para_Section1">��r����Propose_Para_Section�N���X�̃C���X�^���X</param>
		/// <param name="propose_Para_Section2">��r����Propose_Para_Section�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Propose_Para_Section�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(Propose_Para_Section propose_Para_Section1, Propose_Para_Section propose_Para_Section2)
		{
			ArrayList resList = new ArrayList();
			if(propose_Para_Section1.SectionCode != propose_Para_Section2.SectionCode)resList.Add("SectionCode");
			if(propose_Para_Section1.SectionGuideNm != propose_Para_Section2.SectionGuideNm)resList.Add("SectionGuideNm");
			if(propose_Para_Section1.MainOfficeFuncFlag != propose_Para_Section2.MainOfficeFuncFlag)resList.Add("MainOfficeFuncFlag");

			return resList;
		}
	}
}
