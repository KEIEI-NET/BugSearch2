using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SuplierPayInfGetParameter
	/// <summary>
	///                      �d���挳��(�x������)���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �d���挳��(�x������)���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/12/17  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SuplierPayInfGetParameter
    {
        ///// <summary>���_�I�v�V����</summary>
        //private bool _isOptSection = false;

		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h�i�����w��j</summary>
		/// <remarks>�i�z��j</remarks>
		private string[] _addUpSecCodeList;

		/// <summary>�J�n�v��N��</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _startAddUpYearMonth;

		/// <summary>�I���v��N��</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _endAddUpYearMonth;

		/// <summary>�J�n�d����R�[�h</summary>
		private Int32 _startCustomerCode;

		/// <summary>�I���d����R�[�h</summary>
		private Int32 _endCustomerCode;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

        /// <summary>�o�͒��[�敪</summary>
        private Int32 _outputSlipDiv = 0;

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

		/// public propaty name  :  AddUpSecCodeList
		/// <summary>���_�R�[�h�i�����w��j�v���p�e�B</summary>
		/// <value>�i�z��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�i�����w��j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] AddUpSecCodeList
		{
			get{return _addUpSecCodeList;}
			set{_addUpSecCodeList = value;}
		}

		/// public propaty name  :  StartAddUpYearMonth
		/// <summary>�J�n�v��N���v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�v��N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StartAddUpYearMonth
		{
			get{return _startAddUpYearMonth;}
			set{_startAddUpYearMonth = value;}
		}

		/// public propaty name  :  EndAddUpYearMonth
		/// <summary>�I���v��N���v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���v��N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EndAddUpYearMonth
		{
			get{return _endAddUpYearMonth;}
			set{_endAddUpYearMonth = value;}
		}

		/// public propaty name  :  StartCustomerCode
		/// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StartCustomerCode
		{
			get{return _startCustomerCode;}
			set{_startCustomerCode = value;}
		}

		/// public propaty name  :  EndCustomerCode
		/// <summary>�I���d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EndCustomerCode
		{
			get{return _endCustomerCode;}
			set{_endCustomerCode = value;}
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

        /// public propaty name  :  OutputSlipDiv
        /// <summary>�o�͒��[�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͒��[�敪</br>
        /// <br>Programer        :   �菑��</br>
        /// </remarks>
        public Int32 OutputSlipDiv
        {
            get { return _outputSlipDiv; }
            set { _outputSlipDiv = value; }
        }

		/// <summary>
		/// �d���挳��(�x������)���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>SuplierPayInfGetParameter�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplierPayInfGetParameter�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SuplierPayInfGetParameter()
		{
		}

		/// <summary>
		/// �d���挳��(�x������)���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="addUpSecCodeList">���_�R�[�h�i�����w��j(�i�z��j)</param>
		/// <param name="startAddUpYearMonth">�J�n�v��N��(YYYYMM)</param>
		/// <param name="endAddUpYearMonth">�I���v��N��(YYYYMM)</param>
		/// <param name="startCustomerCode">�J�n�d����R�[�h</param>
		/// <param name="endCustomerCode">�I���d����R�[�h</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <returns>SuplierPayInfGetParameter�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplierPayInfGetParameter�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public SuplierPayInfGetParameter(string enterpriseCode, string[] addUpSecCodeList, Int32 startAddUpYearMonth, Int32 endAddUpYearMonth, Int32 startCustomerCode, Int32 endCustomerCode, string enterpriseName)
		{
			this._enterpriseCode = enterpriseCode;
			this._addUpSecCodeList = addUpSecCodeList;
			this._startAddUpYearMonth = startAddUpYearMonth;
			this._endAddUpYearMonth = endAddUpYearMonth;
			this._startCustomerCode = startCustomerCode;
			this._endCustomerCode = endCustomerCode;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// �d���挳��(�x������)���o�����N���X��������
		/// </summary>
		/// <returns>SuplierPayInfGetParameter�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SuplierPayInfGetParameter�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SuplierPayInfGetParameter Clone()
		{
			return new SuplierPayInfGetParameter(this._enterpriseCode,this._addUpSecCodeList,this._startAddUpYearMonth,this._endAddUpYearMonth,this._startCustomerCode,this._endCustomerCode,this._enterpriseName);
		}

		/// <summary>
		/// �d���挳��(�x������)���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SuplierPayInfGetParameter�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplierPayInfGetParameter�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(SuplierPayInfGetParameter target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.AddUpSecCodeList == target.AddUpSecCodeList)
				 && (this.StartAddUpYearMonth == target.StartAddUpYearMonth)
				 && (this.EndAddUpYearMonth == target.EndAddUpYearMonth)
				 && (this.StartCustomerCode == target.StartCustomerCode)
				 && (this.EndCustomerCode == target.EndCustomerCode)
				 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// �d���挳��(�x������)���o�����N���X��r����
		/// </summary>
		/// <param name="suplierPayInfGetParameter1">
		///                    ��r����SuplierPayInfGetParameter�N���X�̃C���X�^���X
		/// </param>
		/// <param name="suplierPayInfGetParameter2">��r����SuplierPayInfGetParameter�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplierPayInfGetParameter�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(SuplierPayInfGetParameter suplierPayInfGetParameter1, SuplierPayInfGetParameter suplierPayInfGetParameter2)
		{
			return ((suplierPayInfGetParameter1.EnterpriseCode == suplierPayInfGetParameter2.EnterpriseCode)
				 && (suplierPayInfGetParameter1.AddUpSecCodeList == suplierPayInfGetParameter2.AddUpSecCodeList)
				 && (suplierPayInfGetParameter1.StartAddUpYearMonth == suplierPayInfGetParameter2.StartAddUpYearMonth)
				 && (suplierPayInfGetParameter1.EndAddUpYearMonth == suplierPayInfGetParameter2.EndAddUpYearMonth)
				 && (suplierPayInfGetParameter1.StartCustomerCode == suplierPayInfGetParameter2.StartCustomerCode)
				 && (suplierPayInfGetParameter1.EndCustomerCode == suplierPayInfGetParameter2.EndCustomerCode)
				 && (suplierPayInfGetParameter1.EnterpriseName == suplierPayInfGetParameter2.EnterpriseName));
		}
		/// <summary>
		/// �d���挳��(�x������)���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SuplierPayInfGetParameter�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplierPayInfGetParameter�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SuplierPayInfGetParameter target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.AddUpSecCodeList != target.AddUpSecCodeList)resList.Add("AddUpSecCodeList");
			if(this.StartAddUpYearMonth != target.StartAddUpYearMonth)resList.Add("StartAddUpYearMonth");
			if(this.EndAddUpYearMonth != target.EndAddUpYearMonth)resList.Add("EndAddUpYearMonth");
			if(this.StartCustomerCode != target.StartCustomerCode)resList.Add("StartCustomerCode");
			if(this.EndCustomerCode != target.EndCustomerCode)resList.Add("EndCustomerCode");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// �d���挳��(�x������)���o�����N���X��r����
		/// </summary>
		/// <param name="suplierPayInfGetParameter1">��r����SuplierPayInfGetParameter�N���X�̃C���X�^���X</param>
		/// <param name="suplierPayInfGetParameter2">��r����SuplierPayInfGetParameter�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplierPayInfGetParameter�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SuplierPayInfGetParameter suplierPayInfGetParameter1, SuplierPayInfGetParameter suplierPayInfGetParameter2)
		{
			ArrayList resList = new ArrayList();
			if(suplierPayInfGetParameter1.EnterpriseCode != suplierPayInfGetParameter2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(suplierPayInfGetParameter1.AddUpSecCodeList != suplierPayInfGetParameter2.AddUpSecCodeList)resList.Add("AddUpSecCodeList");
			if(suplierPayInfGetParameter1.StartAddUpYearMonth != suplierPayInfGetParameter2.StartAddUpYearMonth)resList.Add("StartAddUpYearMonth");
			if(suplierPayInfGetParameter1.EndAddUpYearMonth != suplierPayInfGetParameter2.EndAddUpYearMonth)resList.Add("EndAddUpYearMonth");
			if(suplierPayInfGetParameter1.StartCustomerCode != suplierPayInfGetParameter2.StartCustomerCode)resList.Add("StartCustomerCode");
			if(suplierPayInfGetParameter1.EndCustomerCode != suplierPayInfGetParameter2.EndCustomerCode)resList.Add("EndCustomerCode");
			if(suplierPayInfGetParameter1.EnterpriseName != suplierPayInfGetParameter2.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}
	}
}
