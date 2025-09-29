using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SalesSlipDetailSearch
	/// <summary>
	///                      ����`�[���׌�������
	/// </summary>
	/// <remarks>
	/// <br>note             :   ����`�[���׌��������w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/10/16  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SalesSlipDetailSearch
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�󒍃X�e�[�^�X</summary>
		/// <remarks>10:����,20:��,30:����,40:�o��</remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>����`�[�ԍ�</summary>
		private string _salesSlipNum = "";

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
			get { return _enterpriseCode; }
			set { _enterpriseCode = value; }
		}

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
			get { return _acptAnOdrStatus; }
			set { _acptAnOdrStatus = value; }
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
			get { return _salesSlipNum; }
			set { _salesSlipNum = value; }
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
			get { return _enterpriseName; }
			set { _enterpriseName = value; }
		}


		/// <summary>
		/// ����`�[���׌��������R���X�g���N�^
		/// </summary>
		/// <returns>SalesSlipDetailSearch�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesSlipDetailSearch�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SalesSlipDetailSearch()
		{
		}

		/// <summary>
		/// ����`�[���׌��������R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(10:����,20:��,30:����,40:�o��)</param>
		/// <param name="salesSlipNum">����`�[�ԍ�</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <returns>SalesSlipDetailSearch�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesSlipDetailSearch�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SalesSlipDetailSearch(string enterpriseCode, Int32 acptAnOdrStatus, string salesSlipNum, string enterpriseName)
		{
			this._enterpriseCode = enterpriseCode;
			this._acptAnOdrStatus = acptAnOdrStatus;
			this._salesSlipNum = salesSlipNum;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// ����`�[���׌���������������
		/// </summary>
		/// <returns>SalesSlipDetailSearch�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SalesSlipDetailSearch�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SalesSlipDetailSearch Clone()
		{
			return new SalesSlipDetailSearch(this._enterpriseCode, this._acptAnOdrStatus, this._salesSlipNum, this._enterpriseName);
		}

		/// <summary>
		/// ����`�[���׌���������r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SalesSlipDetailSearch�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesSlipDetailSearch�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(SalesSlipDetailSearch target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
				 && (this.SalesSlipNum == target.SalesSlipNum)
				 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// ����`�[���׌���������r����
		/// </summary>
		/// <param name="salesSlipDetailSearch1">
		///                    ��r����SalesSlipDetailSearch�N���X�̃C���X�^���X
		/// </param>
		/// <param name="salesSlipDetailSearch2">��r����SalesSlipDetailSearch�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesSlipDetailSearch�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(SalesSlipDetailSearch salesSlipDetailSearch1, SalesSlipDetailSearch salesSlipDetailSearch2)
		{
			return ((salesSlipDetailSearch1.EnterpriseCode == salesSlipDetailSearch2.EnterpriseCode)
				 && (salesSlipDetailSearch1.AcptAnOdrStatus == salesSlipDetailSearch2.AcptAnOdrStatus)
				 && (salesSlipDetailSearch1.SalesSlipNum == salesSlipDetailSearch2.SalesSlipNum)
				 && (salesSlipDetailSearch1.EnterpriseName == salesSlipDetailSearch2.EnterpriseName));
		}
		/// <summary>
		/// ����`�[���׌���������r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SalesSlipDetailSearch�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesSlipDetailSearch�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SalesSlipDetailSearch target)
		{
			ArrayList resList = new ArrayList();
			if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
			if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
			if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// ����`�[���׌���������r����
		/// </summary>
		/// <param name="salesSlipDetailSearch1">��r����SalesSlipDetailSearch�N���X�̃C���X�^���X</param>
		/// <param name="salesSlipDetailSearch2">��r����SalesSlipDetailSearch�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesSlipDetailSearch�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SalesSlipDetailSearch salesSlipDetailSearch1, SalesSlipDetailSearch salesSlipDetailSearch2)
		{
			ArrayList resList = new ArrayList();
			if (salesSlipDetailSearch1.EnterpriseCode != salesSlipDetailSearch2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (salesSlipDetailSearch1.AcptAnOdrStatus != salesSlipDetailSearch2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
			if (salesSlipDetailSearch1.SalesSlipNum != salesSlipDetailSearch2.SalesSlipNum) resList.Add("SalesSlipNum");
			if (salesSlipDetailSearch1.EnterpriseName != salesSlipDetailSearch2.EnterpriseName) resList.Add("EnterpriseName");

			return resList;
		}
	}
}
