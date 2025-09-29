using System;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.UIData
{
	/// public class name:   Propose_Para_Main
	/// <summary>
	///                      ��ď��i�N���p�����[�^�N���X�i���C���j
	/// </summary>
	/// <remarks>
	/// <br>note             :   ��ď��i�N���p�����[�^�N���X�i���C���j�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2016/5/24</br>
	/// <br>Genarated Date   :   2016/05/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class Propose_Para_Main
	{
		/// <summary>�N�����[�h</summary>
		private Int16 _bootMode;

		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		private string _sectionCode  = "";

		/// <summary>�]�ƈ��R�[�h</summary>
		private string _employeeCode = "";

		/// <summary>�]�ƈ�����</summary>
		private string _employeeName = "";

		/// <summary>��ď��i�A���N���X���X�g</summary>
		private List<Propose_Goods> _propose_GoodsList;

		/// <summary>��ď��i�N���p�����[�^�N���X�iSCM��Ƌ��_�A���j</summary>
		private List<Propose_Para_SCM> _propose_Para_SCM;

		/// <summary>��ď��i�N���p�����[�^�N���X�i���_�j</summary>
		private List<Propose_Para_Section> _propose_Para_Section;

		/// <summary>��ď��i�N���p�����[�^�N���X�i���[�J�[�j</summary>
		private List<Propose_Para_Maker> _propose_Para_Maker;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";


		/// public propaty name  :  BootMode
		/// <summary>�N�����[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �N�����[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int16 BootMode
		{
			get{return _bootMode;}
			set{_bootMode = value;}
		}

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

		/// public propaty name  :  SectionCode 
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionCode 
		{
			get{return _sectionCode ;}
			set{_sectionCode  = value;}
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

		/// public propaty name  :  EmployeeName
		/// <summary>�]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EmployeeName
		{
			get{return _employeeName;}
			set{_employeeName = value;}
		}

		/// public propaty name  :  Propose_GoodsList
		/// <summary>��ď��i�A���N���X���X�g�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��ď��i�A���N���X���X�g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public List<Propose_Goods> Propose_GoodsList
		{
			get{return _propose_GoodsList;}
			set{_propose_GoodsList = value;}
		}

		/// public propaty name  :  Propose_Para_SCM
		/// <summary>��ď��i�N���p�����[�^�N���X�iSCM��Ƌ��_�A���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��ď��i�N���p�����[�^�N���X�iSCM��Ƌ��_�A���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public List<Propose_Para_SCM> Propose_Para_SCM
		{
			get{return _propose_Para_SCM;}
			set{_propose_Para_SCM = value;}
		}

		/// public propaty name  :  Propose_Para_Section
		/// <summary>��ď��i�N���p�����[�^�N���X�i���_�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��ď��i�N���p�����[�^�N���X�i���_�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public List<Propose_Para_Section> Propose_Para_Section
		{
			get{return _propose_Para_Section;}
			set{_propose_Para_Section = value;}
		}

		/// public propaty name  :  Propose_Para_Maker
		/// <summary>��ď��i�N���p�����[�^�N���X�i���[�J�[�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��ď��i�N���p�����[�^�N���X�i���[�J�[�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public List<Propose_Para_Maker> Propose_Para_Maker
		{
			get{return _propose_Para_Maker;}
			set{_propose_Para_Maker = value;}
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
		/// ��ď��i�N���p�����[�^�N���X�i���C���j�R���X�g���N�^
		/// </summary>
		/// <returns>Propose_Para_Main�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Propose_Para_Main�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Propose_Para_Main()
		{
		}

		/// <summary>
		/// ��ď��i�N���p�����[�^�N���X�i���C���j�R���X�g���N�^
		/// </summary>
		/// <param name="bootMode">�N�����[�h</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="sectionCode ">���_�R�[�h</param>
		/// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <param name="employeeName">�]�ƈ�����</param>
		/// <param name="propose_GoodsList">��ď��i�A���N���X���X�g</param>
		/// <param name="propose_Para_SCM">��ď��i�N���p�����[�^�N���X�iSCM��Ƌ��_�A���j</param>
		/// <param name="propose_Para_Section">��ď��i�N���p�����[�^�N���X�i���_�j</param>
		/// <param name="propose_Para_Maker">��ď��i�N���p�����[�^�N���X�i���[�J�[�j</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <returns>Propose_Para_Main�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Propose_Para_Main�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Propose_Para_Main(Int16 bootMode,string enterpriseCode,string sectionCode ,string employeeCode,string employeeName,List<Propose_Goods> propose_GoodsList,List<Propose_Para_SCM> propose_Para_SCM,List<Propose_Para_Section> propose_Para_Section, List<Propose_Para_Maker> propose_Para_Maker,string enterpriseName)
		{
			this._bootMode = bootMode;
			this._enterpriseCode = enterpriseCode;
			this._sectionCode  = sectionCode ;
			this._employeeCode = employeeCode;
			this._employeeName = employeeName;
			this._propose_GoodsList = propose_GoodsList;
			this._propose_Para_SCM = propose_Para_SCM;
			this._propose_Para_Section = propose_Para_Section;
			this._propose_Para_Maker = propose_Para_Maker;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// ��ď��i�N���p�����[�^�N���X�i���C���j��������
		/// </summary>
		/// <returns>Propose_Para_Main�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����Propose_Para_Main�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Propose_Para_Main Clone()
		{
			return new Propose_Para_Main(this._bootMode,this._enterpriseCode,this._sectionCode ,this._employeeCode,this._employeeName,this._propose_GoodsList,this._propose_Para_SCM,this._propose_Para_Section,this._propose_Para_Maker,this._enterpriseName);
        }

        #region �g�p���Ȃ��̂ō폜
        ///// <summary>
        ///// ��ď��i�N���p�����[�^�N���X�i���C���j��r����
        ///// </summary>
        ///// <param name="target">��r�Ώۂ�Propose_Para_Main�N���X�̃C���X�^���X</param>
        ///// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        ///// <remarks>
        ///// <br>Note�@�@�@�@�@�@ :   Propose_Para_Main�N���X�̓��e����v���邩��r���܂�</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public bool Equals(Propose_Para_Main target)
        //{
        //    return ((this.BootMode == target.BootMode)
        //         && (this.EnterpriseCode == target.EnterpriseCode)
        //         && (this.SectionCode  == target.SectionCode )
        //         && (this.EmployeeCode == target.EmployeeCode)
        //         && (this.EmployeeName == target.EmployeeName)
        //         && (this.Propose_GoodsList == target.Propose_GoodsList)
        //         && (this.Propose_Para_SCM == target.Propose_Para_SCM)
        //         && (this.Propose_Para_Section == target.Propose_Para_Section)
        //         && (this.Propose_Para_Maker == target.Propose_Para_Maker)
        //         && (this.EnterpriseName == target.EnterpriseName));
        //}

        ///// <summary>
        ///// ��ď��i�N���p�����[�^�N���X�i���C���j��r����
        ///// </summary>
        ///// <param name="propose_Para_Main1">
        /////                    ��r����Propose_Para_Main�N���X�̃C���X�^���X
        ///// </param>
        ///// <param name="propose_Para_Main2">��r����Propose_Para_Main�N���X�̃C���X�^���X</param>
        ///// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        ///// <remarks>
        ///// <br>Note�@�@�@�@�@�@ :   Propose_Para_Main�N���X�̓��e����v���邩��r���܂�</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public static bool Equals(Propose_Para_Main propose_Para_Main1, Propose_Para_Main propose_Para_Main2)
        //{
        //    return ((propose_Para_Main1.BootMode == propose_Para_Main2.BootMode)
        //         && (propose_Para_Main1.EnterpriseCode == propose_Para_Main2.EnterpriseCode)
        //         && (propose_Para_Main1.SectionCode  == propose_Para_Main2.SectionCode )
        //         && (propose_Para_Main1.EmployeeCode == propose_Para_Main2.EmployeeCode)
        //         && (propose_Para_Main1.EmployeeName == propose_Para_Main2.EmployeeName)
        //         && (propose_Para_Main1.Propose_GoodsList == propose_Para_Main2.Propose_GoodsList)
        //         && (propose_Para_Main1.Propose_Para_SCM == propose_Para_Main2.Propose_Para_SCM)
        //         && (propose_Para_Main1.Propose_Para_Section == propose_Para_Main2.Propose_Para_Section)
        //         && (propose_Para_Main1.Propose_Para_Maker == propose_Para_Main2.Propose_Para_Maker)
        //         && (propose_Para_Main1.EnterpriseName == propose_Para_Main2.EnterpriseName));
        //}
        ///// <summary>
        ///// ��ď��i�N���p�����[�^�N���X�i���C���j��r����
        ///// </summary>
        ///// <param name="target">��r�Ώۂ�Propose_Para_Main�N���X�̃C���X�^���X</param>
        ///// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        ///// <remarks>
        ///// <br>Note�@�@�@�@�@�@ :   Propose_Para_Main�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public ArrayList Compare(Propose_Para_Main target)
        //{
        //    ArrayList resList = new ArrayList();
        //    if(this.BootMode != target.BootMode)resList.Add("BootMode");
        //    if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
        //    if(this.SectionCode  != target.SectionCode )resList.Add("SectionCode ");
        //    if(this.EmployeeCode != target.EmployeeCode)resList.Add("EmployeeCode");
        //    if(this.EmployeeName != target.EmployeeName)resList.Add("EmployeeName");
        //    if(this.Propose_GoodsList != target.Propose_GoodsList)resList.Add("Propose_GoodsList");
        //    if(this.Propose_Para_SCM != target.Propose_Para_SCM)resList.Add("Propose_Para_SCM");
        //    if(this.Propose_Para_Section != target.Propose_Para_Section)resList.Add("Propose_Para_Section");
        //    if(this.Propose_Para_Maker != target.Propose_Para_Maker)resList.Add("Propose_Para_Maker");
        //    if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");

        //    return resList;
        //}

        ///// <summary>
        ///// ��ď��i�N���p�����[�^�N���X�i���C���j��r����
        ///// </summary>
        ///// <param name="propose_Para_Main1">��r����Propose_Para_Main�N���X�̃C���X�^���X</param>
        ///// <param name="propose_Para_Main2">��r����Propose_Para_Main�N���X�̃C���X�^���X</param>
        ///// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        ///// <remarks>
        ///// <br>Note�@�@�@�@�@�@ :   Propose_Para_Main�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public static ArrayList Compare(Propose_Para_Main propose_Para_Main1, Propose_Para_Main propose_Para_Main2)
        //{
        //    ArrayList resList = new ArrayList();
        //    if(propose_Para_Main1.BootMode != propose_Para_Main2.BootMode)resList.Add("BootMode");
        //    if(propose_Para_Main1.EnterpriseCode != propose_Para_Main2.EnterpriseCode)resList.Add("EnterpriseCode");
        //    if(propose_Para_Main1.SectionCode  != propose_Para_Main2.SectionCode )resList.Add("SectionCode ");
        //    if(propose_Para_Main1.EmployeeCode != propose_Para_Main2.EmployeeCode)resList.Add("EmployeeCode");
        //    if(propose_Para_Main1.EmployeeName != propose_Para_Main2.EmployeeName)resList.Add("EmployeeName");
        //    if(propose_Para_Main1.Propose_GoodsList != propose_Para_Main2.Propose_GoodsList)resList.Add("Propose_GoodsList");
        //    if(propose_Para_Main1.Propose_Para_SCM != propose_Para_Main2.Propose_Para_SCM)resList.Add("Propose_Para_SCM");
        //    if(propose_Para_Main1.Propose_Para_Section != propose_Para_Main2.Propose_Para_Section)resList.Add("Propose_Para_Section");
        //    if(propose_Para_Main1.Propose_Para_Maker != propose_Para_Main2.Propose_Para_Maker)resList.Add("Propose_Para_Maker");
        //    if(propose_Para_Main1.EnterpriseName != propose_Para_Main2.EnterpriseName)resList.Add("EnterpriseName");

        //    return resList;
        //}
        #endregion
    }
}
