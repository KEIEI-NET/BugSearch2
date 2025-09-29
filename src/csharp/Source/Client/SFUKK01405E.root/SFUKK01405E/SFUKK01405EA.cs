using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   DepositCustomer
	/// <summary>
	///                      �������Ӑ���N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �������Ӑ���N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2005/04/1</br>
	/// <br>Genarated Date   :   2006/08/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class DepositCustomer
	{
        /// <summary>������R�[�h</summary>
        private Int32 _claimCode;

        /// <summary>�����於�̂P</summary>
        private string _cName = "";

        /// <summary>�����於�̂Q</summary>
        private string _cName2 = "";

        /// <summary>�����旪��</summary>
        private string _cSnm = "";

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>���Ӑ於�̂P</summary>
		private string _name = "";

		/// <summary>���Ӑ於�̂Q</summary>
		private string _name2 = "";

        /// <summary>���Ӑ旪��</summary>
        private string _sNm = "";

		/// <summary>�h��</summary>
		private string _honorificTitle = "";

		/// <summary>����</summary>
		/// <remarks>DD</remarks>
		private Int32 _totalDay;

		/// <summary>�W�����敪����</summary>
		/// <remarks>����,����,���X��</remarks>
		private string _collectMoneyName = "";

		/// <summary>�W����</summary>
		/// <remarks>DD</remarks>
		private Int32 _collectMoneyDay;

		/// <summary>�O������X�V�N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _cAddUpUpdDate;

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  CName
        /// <summary>�����於�̂P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於�̂P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CName
        {
            get { return _cName; }
            set { _cName = value; }
        }

        /// public propaty name  :  CName2
        /// <summary>�����於�̂Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於�̂Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CName2
        {
            get { return _cName2; }
            set { _cName2 = value; }
        }

        /// public propaty name  :  CSnm
        /// <summary>�����旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSnm
        {
            get { return _cSnm; }
            set { _cSnm = value; }
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

		/// public propaty name  :  Name
		/// <summary>���Ӑ於�̂P�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ於�̂P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Name
		{
			get{return _name;}
			set{_name = value;}
		}

		/// public propaty name  :  Name2
		/// <summary>���Ӑ於�̂Q�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ於�̂Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Name2
		{
			get{return _name2;}
			set{_name2 = value;}
		}

        /// public propaty name  :  SNm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SNm
        {
            get { return _sNm; }
            set { _sNm = value; }
        }

		/// public propaty name  :  HonorificTitle
		/// <summary>�h�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �h�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string HonorificTitle
		{
			get {return _honorificTitle;}
			set {_honorificTitle = value;}
		}

		/// public propaty name  :  TotalDay
		/// <summary>�����v���p�e�B</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TotalDay
		{
			get{return _totalDay;}
			set{_totalDay = value;}
		}

		/// public propaty name  :  CollectMoneyName
		/// <summary>�W�����敪���̃v���p�e�B</summary>
		/// <value>����,����,���X��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �W�����敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CollectMoneyName
		{
			get{return _collectMoneyName;}
			set{_collectMoneyName = value;}
		}

		/// public propaty name  :  CollectMoneyDay
		/// <summary>�W�����v���p�e�B</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �W�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CollectMoneyDay
		{
			get{return _collectMoneyDay;}
			set{_collectMoneyDay = value;}
		}

		/// public propaty name  :  CAddUpUpdDate
		/// <summary>�O������X�V�N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O������X�V�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CAddUpUpdDate
		{
			get{return _cAddUpUpdDate;}
			set{_cAddUpUpdDate = value;}
		}


		/// <summary>
		/// �������Ӑ���N���X�R���X�g���N�^
		/// </summary>
		/// <returns>DepositCustomer�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   DepositCustomer�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DepositCustomer()
		{
		}

		/// <summary>
		/// �������Ӑ���N���X�R���X�g���N�^
		/// </summary>
		/// <param name="claimCode">������R�[�h</param>
		/// <param name="cName">�����於�̂P</param>
		/// <param name="cName2">�����於�̂Q</param>
        /// <param name="cSnm">�����旪��</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="name">���Ӑ於�̂P</param>
		/// <param name="name2">���Ӑ於�̂Q</param>
		/// <param name="sNm">���Ӑ�旪��</param>
        /// <param name="honorificTitle">�h��</param>
		/// <param name="totalDay">����(DD)</param>
		/// <param name="collectMoneyName">�W�����敪����(����,����,���X��)</param>
		/// <param name="collectMoneyDay">�W����(DD)</param>
		/// <param name="cAddUpUpdDate">�O������X�V�N����(YYYYMMDD)</param>
		/// <returns>DepositCustomer�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   DepositCustomer�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DepositCustomer(Int32 claimCode, string cName, string cName2, string cSnm, Int32 customerCode, string name, string name2, string sNm, string honorificTitle, Int32 totalDay, string collectMoneyName, Int32 collectMoneyDay, Int32 cAddUpUpdDate)
		{
            this._claimCode = claimCode;
            this._cName = cName;
            this._cName2 = cName2;
            this._cSnm = cSnm;
			this._customerCode = customerCode;
			this._name = name;
			this._name2 = name2;
            this._sNm = sNm; 
			this._honorificTitle = honorificTitle;
			this._totalDay = totalDay;
			this._collectMoneyName = collectMoneyName;
			this._collectMoneyDay = collectMoneyDay;
			this._cAddUpUpdDate = cAddUpUpdDate;

		}

		/// <summary>
		/// �������Ӑ���N���X��������
		/// </summary>
		/// <returns>DepositCustomer�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����DepositCustomer�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DepositCustomer Clone()
		{
            return new DepositCustomer(this._claimCode, this._cName, this._cName2, this._cSnm, this._customerCode, this._name, this._name2, this._sNm, this._honorificTitle, this._totalDay, this._collectMoneyName, this._collectMoneyDay, this._cAddUpUpdDate);
		}

		/// <summary>
		/// �������Ӑ���N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�DepositCustomer�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   DepositCustomer�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(DepositCustomer target)
		{
			return ((this.ClaimCode == target.ClaimCode)
                 && (this.CName == target.CName)
                 && (this.CName2 == target.CName2)
                 && (this.CSnm == target.CSnm)
                 && (this.CustomerCode == target.CustomerCode)
				 && (this.Name == target.Name)
				 && (this.Name2 == target.Name2)
				 && (this.SNm == target.SNm)
                 && (this.HonorificTitle == target.HonorificTitle)
				 && (this.TotalDay == target.TotalDay)
				 && (this.CollectMoneyName == target.CollectMoneyName)
				 && (this.CollectMoneyDay == target.CollectMoneyDay)
				 && (this.CAddUpUpdDate == target.CAddUpUpdDate));
		}

		/// <summary>
		/// �������Ӑ���N���X��r����
		/// </summary>
		/// <param name="depositCustomer1">
		///                    ��r����DepositCustomer�N���X�̃C���X�^���X
		/// </param>
		/// <param name="depositCustomer2">��r����DepositCustomer�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   DepositCustomer�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(DepositCustomer depositCustomer1, DepositCustomer depositCustomer2)
		{
			return ((depositCustomer1.ClaimCode == depositCustomer2.ClaimCode)
                 && (depositCustomer1.CName == depositCustomer2.CName)
                 && (depositCustomer1.CName2 == depositCustomer2.CName2)
                 && (depositCustomer1.CSnm == depositCustomer2.CSnm)
                 && (depositCustomer1.CustomerCode == depositCustomer2.CustomerCode)
				 && (depositCustomer1.Name == depositCustomer2.Name)
				 && (depositCustomer1.Name2 == depositCustomer2.Name2)
                 && (depositCustomer1.SNm == depositCustomer2.SNm)
				 && (depositCustomer1.HonorificTitle == depositCustomer2.HonorificTitle)
				 && (depositCustomer1.TotalDay == depositCustomer2.TotalDay)
				 && (depositCustomer1.CollectMoneyName == depositCustomer2.CollectMoneyName)
				 && (depositCustomer1.CollectMoneyDay == depositCustomer2.CollectMoneyDay)
				 && (depositCustomer1.CAddUpUpdDate == depositCustomer2.CAddUpUpdDate));
		}
		/// <summary>
		/// �������Ӑ���N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�DepositCustomer�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   DepositCustomer�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(DepositCustomer target)
		{
			ArrayList resList = new ArrayList();
            if(this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if(this.CName != target.CName) resList.Add("CName");
            if(this.CName2 != target.CName2) resList.Add("CName2");
            if(this.CSnm != target.CSnm) resList.Add("CSnm");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.Name != target.Name)resList.Add("Name");
			if(this.Name2 != target.Name2) resList.Add("Name2");
            if(this.SNm != target.SNm) resList.Add("Snm");
			if(this.HonorificTitle != target.HonorificTitle) resList.Add("HonorificTitle");
			if(this.TotalDay != target.TotalDay) resList.Add("TotalDay");
			if(this.CollectMoneyName != target.CollectMoneyName)resList.Add("CollectMoneyName");
			if(this.CollectMoneyDay != target.CollectMoneyDay)resList.Add("CollectMoneyDay");
			if(this.CAddUpUpdDate != target.CAddUpUpdDate)resList.Add("CAddUpUpdDate");

			return resList;
		}

		/// <summary>
		/// �������Ӑ���N���X��r����
		/// </summary>
		/// <param name="depositCustomer1">��r����DepositCustomer�N���X�̃C���X�^���X</param>
		/// <param name="depositCustomer2">��r����DepositCustomer�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   DepositCustomer�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(DepositCustomer depositCustomer1, DepositCustomer depositCustomer2)
		{
			ArrayList resList = new ArrayList();
            if (depositCustomer1.ClaimCode != depositCustomer2.ClaimCode) resList.Add("ClaimCode");
            if (depositCustomer1.CName != depositCustomer2.CName) resList.Add("CName");
            if (depositCustomer1.CName2 != depositCustomer2.CName2) resList.Add("CName2");
            if (depositCustomer1.CSnm != depositCustomer2.CSnm) resList.Add("CSnm");
            if(depositCustomer1.CustomerCode != depositCustomer2.CustomerCode)resList.Add("CustomerCode");
			if(depositCustomer1.Name != depositCustomer2.Name)resList.Add("Name");
			if(depositCustomer1.Name2 != depositCustomer2.Name2) resList.Add("Name2");
            if (depositCustomer1.SNm != depositCustomer2.SNm) resList.Add("SNm");
			if(depositCustomer1.HonorificTitle != depositCustomer2.HonorificTitle) resList.Add("HonorificTitle");
			if(depositCustomer1.TotalDay != depositCustomer2.TotalDay) resList.Add("TotalDay");
			if(depositCustomer1.CollectMoneyName != depositCustomer2.CollectMoneyName)resList.Add("CollectMoneyName");
			if(depositCustomer1.CollectMoneyDay != depositCustomer2.CollectMoneyDay)resList.Add("CollectMoneyDay");
			if(depositCustomer1.CAddUpUpdDate != depositCustomer2.CAddUpUpdDate)resList.Add("CAddUpUpdDate");

			return resList;
		}
	}
}
