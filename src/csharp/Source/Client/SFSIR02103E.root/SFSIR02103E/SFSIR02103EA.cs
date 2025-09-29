using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SearchCustSuppliRet
	/// <summary>
	///                      �����p�d����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �����p�d����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2007/07/25</br>
	/// <br>Genarated Date   :   2007/07/25  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SearchCustSuppliRet
	{
        // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
        ///// <summary>���Ӑ�R�[�h</summary>
        //private Int32 _customerCode;
        /// <summary>�d�����R�[�h</summary>
        private Int32 _supplierCode;
        // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<

		/// <summary>����</summary>
		private string _name = "";

		/// <summary>���̂Q</summary>
		private string _name2 = "";

		/// <summary>�J�i</summary>
		private string _kana = "";

		/// <summary>�d�b�ԍ��i����j</summary>
		/// <remarks>�n�C�t�����܂߂�16���̔ԍ�</remarks>
		private string _homeTelNo = "";

		/// <summary>�d�b�ԍ��i�Ζ���j</summary>
		private string _officeTelNo = "";

		/// <summary>�d�b�ԍ��i�g�сj</summary>
		private string _portableTelNo = "";

		/// <summary>FAX�ԍ��i����j</summary>
		private string _homeFaxNo = "";

		/// <summary>FAX�ԍ��i�Ζ���j</summary>
		private string _officeFaxNo = "";

		/// <summary>�d�b�ԍ��i���̑��j</summary>
		private string _othersTelNo = "";

		/// <summary>��A����敪</summary>
		/// <remarks>0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���</remarks>
		private Int32 _mainContactCode;

		/// <summary>����</summary>
		/// <remarks>DD</remarks>
		private Int32 _totalDay;

		/// <summary>�x�����敪�R�[�h</summary>
		/// <remarks>0:���� 1:���� 2:���X��</remarks>
		private Int32 _paymentMonthCode;

		/// <summary>�x�����敪����</summary>
		/// <remarks>�����A�����A���X��</remarks>
		private string _paymentMonthName = "";

		/// <summary>�x����</summary>
		/// <remarks>DD</remarks>
		private Int32 _paymentDay;

		/// <summary>�d�������œ]�ŕ�������</summary>
		/// <remarks>�`�[�P�ʁA���גP�ʁA�����P��</remarks>
		private string _suppCTaxLayMethodNm = "";

		/// <summary>�x�����ԁi�J�n�j</summary>
		private Int32 _startDateSpan;

		/// <summary>�x�����ԁi�I���j</summary>
		private Int32 _endDateSpan;

		/// <summary>���i�d����敪</summary>
		private Int32 _partsSupplierDivCd;

		/// <summary>�ԗ��d����敪</summary>
		private Int32 _carSupplierDivCd;

		/// <summary>�O���d����敪</summary>
		private Int32 _osrcSupplierDivCd;

        /// <summary>����</summary>
        private string _sNm = "";

        /// <summary>�x����R�[�h</summary>
        private Int32 _payeeCode;

        /// <summary>�x���於��</summary>
        private string _pName = "";

        /// <summary>�x���於�̂Q</summary>
        private string _pName2 = "";

        /// <summary>�x���旪��</summary>
        private string _pSnm = "";

        // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
        ///// public propaty name  :  CustomerCode
        ///// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 CustomerCode
        //{
        //    get{return _customerCode;}
        //    set{_customerCode = value;}
        //}
        /// public property name  :  SupplierCode
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/07/08</br>
        /// </remarks>
        public Int32 SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }
        // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<

		/// public propaty name  :  Name
		/// <summary>���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Name
		{
			get{return _name;}
			set{_name = value;}
		}

		/// public propaty name  :  Name2
		/// <summary>���̂Q�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���̂Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Name2
		{
			get{return _name2;}
			set{_name2 = value;}
		}

		/// public propaty name  :  Kana
		/// <summary>�J�i�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�i�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Kana
		{
			get{return _kana;}
			set{_kana = value;}
		}

        /// public propaty name  :  HomeTelNo
		/// <summary>�d�b�ԍ��i����j�v���p�e�B</summary>
		/// <value>�n�C�t�����܂߂�16���̔ԍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�b�ԍ��i����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string HomeTelNo
		{
			get{return _homeTelNo;}
			set{_homeTelNo = value;}
		}

		/// public propaty name  :  OfficeTelNo
		/// <summary>�d�b�ԍ��i�Ζ���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�b�ԍ��i�Ζ���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OfficeTelNo
		{
			get{return _officeTelNo;}
			set{_officeTelNo = value;}
		}

		/// public propaty name  :  PortableTelNo
		/// <summary>�d�b�ԍ��i�g�сj�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�b�ԍ��i�g�сj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PortableTelNo
		{
			get{return _portableTelNo;}
			set{_portableTelNo = value;}
		}

		/// public propaty name  :  HomeFaxNo
		/// <summary>FAX�ԍ��i����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   FAX�ԍ��i����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string HomeFaxNo
		{
			get{return _homeFaxNo;}
			set{_homeFaxNo = value;}
		}

		/// public propaty name  :  OfficeFaxNo
		/// <summary>FAX�ԍ��i�Ζ���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   FAX�ԍ��i�Ζ���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OfficeFaxNo
		{
			get{return _officeFaxNo;}
			set{_officeFaxNo = value;}
		}

		/// public propaty name  :  OthersTelNo
		/// <summary>�d�b�ԍ��i���̑��j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�b�ԍ��i���̑��j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OthersTelNo
		{
			get{return _othersTelNo;}
			set{_othersTelNo = value;}
		}

		/// public propaty name  :  MainContactCode
		/// <summary>��A����敪�v���p�e�B</summary>
		/// <value>0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��A����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MainContactCode
		{
			get{return _mainContactCode;}
			set{_mainContactCode = value;}
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

		/// public propaty name  :  PaymentMonthCode
		/// <summary>�x�����敪�R�[�h�v���p�e�B</summary>
		/// <value>0:���� 1:���� 2:���X��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x�����敪�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PaymentMonthCode
		{
			get{return _paymentMonthCode;}
			set{_paymentMonthCode = value;}
		}

		/// public propaty name  :  PaymentMonthName
		/// <summary>�x�����敪���̃v���p�e�B</summary>
		/// <value>�����A�����A���X��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x�����敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PaymentMonthName
		{
			get{return _paymentMonthName;}
			set{_paymentMonthName = value;}
		}

		/// public propaty name  :  PaymentDay
		/// <summary>�x�����v���p�e�B</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PaymentDay
		{
			get{return _paymentDay;}
			set{_paymentDay = value;}
		}

		/// public propaty name  :  SuppCTaxLayMethodNm
		/// <summary>�d�������œ]�ŕ������̃v���p�e�B</summary>
		/// <value>�`�[�P�ʁA���גP�ʁA�����P��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�������œ]�ŕ������̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SuppCTaxLayMethodNm
		{
			get{return _suppCTaxLayMethodNm;}
			set{_suppCTaxLayMethodNm = value;}
		}

		/// public propaty name  :  StartDateSpan
		/// <summary>�x�����ԁi�J�n�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x�����ԁi�J�n�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StartDateSpan
		{
			get{return _startDateSpan;}
			set{_startDateSpan = value;}
		}

		/// public propaty name  :  EndDateSpan
		/// <summary>�x�����ԁi�I���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x�����ԁi�I���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EndDateSpan
		{
			get{return _endDateSpan;}
			set{_endDateSpan = value;}
		}

		/// public propaty name  :  PartsSupplierDivCd
		/// <summary>���i�d����敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�d����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PartsSupplierDivCd
		{
			get{return _partsSupplierDivCd;}
			set{_partsSupplierDivCd = value;}
		}

		/// public propaty name  :  CarSupplierDivCd
		/// <summary>�ԗ��d����敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԗ��d����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CarSupplierDivCd
		{
			get{return _carSupplierDivCd;}
			set{_carSupplierDivCd = value;}
		}

		/// public propaty name  :  OsrcSupplierDivCd
		/// <summary>�O���d����敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O���d����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OsrcSupplierDivCd
		{
			get{return _osrcSupplierDivCd;}
			set{_osrcSupplierDivCd = value;}
		}

        /// public propaty name  :  SNm
        /// <summary>���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SNm
        {
            get { return _sNm; }
            set { _sNm = value; }
        }

		/// public propaty name  :  PayeeCode
		/// <summary>�x����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PayeeCode
		{
			get{return _payeeCode;}
			set{_payeeCode = value;}
		}

        /// public propaty name  :  PName
        /// <summary>�x���於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PName
        {
            get { return _pName; }
            set { _pName = value; }
        }

        /// public propaty name  :  PName
        /// <summary>�x���於�̂Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���於�̂Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PName2
        {
            get { return _pName2; }
            set { _pName2 = value; }
        }

        /// public propaty name  :  PSNm
        /// <summary>�x���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PSNm
        {
            get { return _pSnm; }
            set { _pSnm = value; }
        }

		/// <summary>
		/// �����p�d����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>SearchCustSuppliRet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SearchCustSuppliRet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SearchCustSuppliRet()
		{
		}

		/// <summary>
		/// �����p�d����N���X�R���X�g���N�^
		/// </summary>
        /// <param name="supplierCode">�d����R�[�h</param>
		/// <param name="name">����</param>
		/// <param name="name2">���̂Q</param>
		/// <param name="kana">�J�i</param>
		/// <param name="homeTelNo">�d�b�ԍ��i����j(�n�C�t�����܂߂�16���̔ԍ�)</param>
		/// <param name="officeTelNo">�d�b�ԍ��i�Ζ���j</param>
		/// <param name="portableTelNo">�d�b�ԍ��i�g�сj</param>
		/// <param name="homeFaxNo">FAX�ԍ��i����j</param>
		/// <param name="officeFaxNo">FAX�ԍ��i�Ζ���j</param>
		/// <param name="othersTelNo">�d�b�ԍ��i���̑��j</param>
		/// <param name="mainContactCode">��A����敪(0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���)</param>
		/// <param name="totalDay">����(DD)</param>
		/// <param name="paymentMonthCode">�x�����敪�R�[�h(0:���� 1:���� 2:���X��)</param>
		/// <param name="paymentMonthName">�x�����敪����(�����A�����A���X��)</param>
		/// <param name="paymentDay">�x����(DD)</param>
		/// <param name="suppCTaxLayMethodNm">�d�������œ]�ŕ�������(�`�[�P�ʁA���גP�ʁA�����P��)</param>
		/// <param name="startDateSpan">�x�����ԁi�J�n�j</param>
		/// <param name="endDateSpan">�x�����ԁi�I���j</param>
		/// <param name="partsSupplierDivCd">���i�d����敪</param>
		/// <param name="carSupplierDivCd">�ԗ��d����敪</param>
		/// <param name="osrcSupplierDivCd">�O���d����敪</param>
        /// <param name="sNm">����</param>
        /// <param name="payeeCode">�x����R�[�h</param>
        /// <param name="pName">�x���於��</param>
        /// <param name="pName2">�x���於�̂Q</param>
        /// <param name="pSnm">�x���旪��</param>
        /// <returns>SearchCustSuppliRet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SearchCustSuppliRet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
        //public SearchCustSuppliRet(Int32 customerCode, string name, string name2, string kana, string homeTelNo, string officeTelNo, string portableTelNo, string homeFaxNo, string officeFaxNo, string othersTelNo, Int32 mainContactCode, Int32 totalDay, Int32 paymentMonthCode, string paymentMonthName, Int32 paymentDay, string suppCTaxLayMethodNm, Int32 startDateSpan, Int32 endDateSpan, Int32 partsSupplierDivCd, Int32 carSupplierDivCd, Int32 osrcSupplierDivCd, string sNm, Int32 payeeCode, string pName, string pName2, string pSnm)
        public SearchCustSuppliRet(Int32 supplierCode, string name, string name2, string kana, string homeTelNo, string officeTelNo, string portableTelNo, string homeFaxNo, string officeFaxNo, string othersTelNo, Int32 mainContactCode, Int32 totalDay, Int32 paymentMonthCode, string paymentMonthName, Int32 paymentDay, string suppCTaxLayMethodNm, Int32 startDateSpan, Int32 endDateSpan, Int32 partsSupplierDivCd, Int32 carSupplierDivCd, Int32 osrcSupplierDivCd, string sNm, Int32 payeeCode, string pName, string pName2, string pSnm)
        // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
        {
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //this._customerCode = customerCode;
            this._supplierCode = supplierCode;
            // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
            this._name = name;
			this._name2 = name2;
			this._kana = kana;
			this._homeTelNo = homeTelNo;
			this._officeTelNo = officeTelNo;
			this._portableTelNo = portableTelNo;
			this._homeFaxNo = homeFaxNo;
			this._officeFaxNo = officeFaxNo;
			this._othersTelNo = othersTelNo;
			this._mainContactCode = mainContactCode;
			this._totalDay = totalDay;
			this._paymentMonthCode = paymentMonthCode;
			this._paymentMonthName = paymentMonthName;
			this._paymentDay = paymentDay;
			this._suppCTaxLayMethodNm = suppCTaxLayMethodNm;
			this._startDateSpan = startDateSpan;
			this._endDateSpan = endDateSpan;
			this._partsSupplierDivCd = partsSupplierDivCd;
			this._carSupplierDivCd = carSupplierDivCd;
			this._osrcSupplierDivCd = osrcSupplierDivCd;
            this._sNm = sNm;
			this._payeeCode = payeeCode;
            this._pName = pName;
            this._pName2 = pName2;
            this._pSnm = pSnm;
		}

		/// <summary>
		/// �����p�d����N���X��������
		/// </summary>
		/// <returns>SearchCustSuppliRet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SearchCustSuppliRet�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SearchCustSuppliRet Clone()
		{
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //return new SearchCustSuppliRet(this._customerCode, this._name, this._name2, this._kana, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._othersTelNo, this._mainContactCode, this._totalDay, this._paymentMonthCode, this._paymentMonthName, this._paymentDay, this._suppCTaxLayMethodNm, this._startDateSpan, this._endDateSpan, this._partsSupplierDivCd, this._carSupplierDivCd, this._osrcSupplierDivCd, this._sNm, this._payeeCode, this._pName, this._pName2, this._pSnm);
            return new SearchCustSuppliRet(this._supplierCode, this._name, this._name2, this._kana, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._othersTelNo, this._mainContactCode, this._totalDay, this._paymentMonthCode, this._paymentMonthName, this._paymentDay, this._suppCTaxLayMethodNm, this._startDateSpan, this._endDateSpan, this._partsSupplierDivCd, this._carSupplierDivCd, this._osrcSupplierDivCd, this._sNm, this._payeeCode, this._pName, this._pName2, this._pSnm);
            // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
        }

		/// <summary>
		/// �����p�d����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SearchCustSuppliRet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SearchCustSuppliRet�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(SearchCustSuppliRet target)
		{
			return (
                    // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
                    //(this.CustomerCode == target.CustomerCode)
                    (this.SupplierCode == target.SupplierCode)
                    // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
				 && (this.Name == target.Name)
				 && (this.Name2 == target.Name2)
				 && (this.Kana == target.Kana)
				 && (this.HomeTelNo == target.HomeTelNo)
				 && (this.OfficeTelNo == target.OfficeTelNo)
				 && (this.PortableTelNo == target.PortableTelNo)
				 && (this.HomeFaxNo == target.HomeFaxNo)
				 && (this.OfficeFaxNo == target.OfficeFaxNo)
				 && (this.OthersTelNo == target.OthersTelNo)
				 && (this.MainContactCode == target.MainContactCode)
				 && (this.TotalDay == target.TotalDay)
				 && (this.PaymentMonthCode == target.PaymentMonthCode)
				 && (this.PaymentMonthName == target.PaymentMonthName)
				 && (this.PaymentDay == target.PaymentDay)
				 && (this.SuppCTaxLayMethodNm == target.SuppCTaxLayMethodNm)
				 && (this.StartDateSpan == target.StartDateSpan)
				 && (this.EndDateSpan == target.EndDateSpan)
				 && (this.PartsSupplierDivCd == target.PartsSupplierDivCd)
				 && (this.CarSupplierDivCd == target.CarSupplierDivCd)
				 && (this.OsrcSupplierDivCd == target.OsrcSupplierDivCd)
                 && (this.SNm == target.SNm)
				 && (this.PayeeCode == target.PayeeCode)
                 && (this.PName == target.PName)
                 && (this.PName2 == target.PName2)
                 && (this.PSNm == target.PSNm));
		}

		/// <summary>
		/// �����p�d����N���X��r����
		/// </summary>
		/// <param name="searchCustSuppliRet1">
		///                    ��r����SearchCustSuppliRet�N���X�̃C���X�^���X
		/// </param>
		/// <param name="searchCustSuppliRet2">��r����SearchCustSuppliRet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SearchCustSuppliRet�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(SearchCustSuppliRet searchCustSuppliRet1, SearchCustSuppliRet searchCustSuppliRet2)
		{
			return (
                    // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
                    //(searchCustSuppliRet1.CustomerCode == searchCustSuppliRet2.CustomerCode)
                    (searchCustSuppliRet1.SupplierCode == searchCustSuppliRet2.SupplierCode)
                    // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
                 && (searchCustSuppliRet1.Name == searchCustSuppliRet2.Name)
				 && (searchCustSuppliRet1.Name2 == searchCustSuppliRet2.Name2)
				 && (searchCustSuppliRet1.Kana == searchCustSuppliRet2.Kana)
				 && (searchCustSuppliRet1.HomeTelNo == searchCustSuppliRet2.HomeTelNo)
				 && (searchCustSuppliRet1.OfficeTelNo == searchCustSuppliRet2.OfficeTelNo)
				 && (searchCustSuppliRet1.PortableTelNo == searchCustSuppliRet2.PortableTelNo)
				 && (searchCustSuppliRet1.HomeFaxNo == searchCustSuppliRet2.HomeFaxNo)
				 && (searchCustSuppliRet1.OfficeFaxNo == searchCustSuppliRet2.OfficeFaxNo)
				 && (searchCustSuppliRet1.OthersTelNo == searchCustSuppliRet2.OthersTelNo)
				 && (searchCustSuppliRet1.MainContactCode == searchCustSuppliRet2.MainContactCode)
				 && (searchCustSuppliRet1.TotalDay == searchCustSuppliRet2.TotalDay)
				 && (searchCustSuppliRet1.PaymentMonthCode == searchCustSuppliRet2.PaymentMonthCode)
				 && (searchCustSuppliRet1.PaymentMonthName == searchCustSuppliRet2.PaymentMonthName)
				 && (searchCustSuppliRet1.PaymentDay == searchCustSuppliRet2.PaymentDay)
				 && (searchCustSuppliRet1.SuppCTaxLayMethodNm == searchCustSuppliRet2.SuppCTaxLayMethodNm)
				 && (searchCustSuppliRet1.StartDateSpan == searchCustSuppliRet2.StartDateSpan)
				 && (searchCustSuppliRet1.EndDateSpan == searchCustSuppliRet2.EndDateSpan)
				 && (searchCustSuppliRet1.PartsSupplierDivCd == searchCustSuppliRet2.PartsSupplierDivCd)
				 && (searchCustSuppliRet1.CarSupplierDivCd == searchCustSuppliRet2.CarSupplierDivCd)
				 && (searchCustSuppliRet1.OsrcSupplierDivCd == searchCustSuppliRet2.OsrcSupplierDivCd)
                 && (searchCustSuppliRet1.SNm == searchCustSuppliRet2.SNm)
                 && (searchCustSuppliRet1.PayeeCode == searchCustSuppliRet2.PayeeCode)
                 && (searchCustSuppliRet1.PName == searchCustSuppliRet2.PName)
                 && (searchCustSuppliRet1.PName2 == searchCustSuppliRet2.PName2)
                 && (searchCustSuppliRet1.PSNm == searchCustSuppliRet2.PSNm)
                 );
		}
		/// <summary>
		/// �����p�d����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SearchCustSuppliRet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SearchCustSuppliRet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SearchCustSuppliRet target)
		{
			ArrayList resList = new ArrayList();
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.SupplierCode != target.SupplierCode) resList.Add("SupplierCode");
            // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
			if(this.Name != target.Name)resList.Add("Name");
			if(this.Name2 != target.Name2)resList.Add("Name2");
			if(this.Kana != target.Kana)resList.Add("Kana");
			if(this.HomeTelNo != target.HomeTelNo)resList.Add("HomeTelNo");
			if(this.OfficeTelNo != target.OfficeTelNo)resList.Add("OfficeTelNo");
			if(this.PortableTelNo != target.PortableTelNo)resList.Add("PortableTelNo");
			if(this.HomeFaxNo != target.HomeFaxNo)resList.Add("HomeFaxNo");
			if(this.OfficeFaxNo != target.OfficeFaxNo)resList.Add("OfficeFaxNo");
			if(this.OthersTelNo != target.OthersTelNo)resList.Add("OthersTelNo");
			if(this.MainContactCode != target.MainContactCode)resList.Add("MainContactCode");
			if(this.TotalDay != target.TotalDay)resList.Add("TotalDay");
			if(this.PaymentMonthCode != target.PaymentMonthCode)resList.Add("PaymentMonthCode");
			if(this.PaymentMonthName != target.PaymentMonthName)resList.Add("PaymentMonthName");
			if(this.PaymentDay != target.PaymentDay)resList.Add("PaymentDay");
			if(this.SuppCTaxLayMethodNm != target.SuppCTaxLayMethodNm)resList.Add("SuppCTaxLayMethodNm");
			if(this.StartDateSpan != target.StartDateSpan)resList.Add("StartDateSpan");
			if(this.EndDateSpan != target.EndDateSpan)resList.Add("EndDateSpan");
			if(this.PartsSupplierDivCd != target.PartsSupplierDivCd)resList.Add("PartsSupplierDivCd");
			if(this.CarSupplierDivCd != target.CarSupplierDivCd)resList.Add("CarSupplierDivCd");
			if(this.OsrcSupplierDivCd != target.OsrcSupplierDivCd)resList.Add("OsrcSupplierDivCd");
            if(this.SNm != target.SNm) resList.Add("SNm");
            if(this.PayeeCode != target.PayeeCode)resList.Add("PayeeCode");
            if(this.PName != target.PName) resList.Add("PName");
            if(this.PName2 != target.PName2) resList.Add("PName2");
            if(this.PSNm != target.PSNm) resList.Add("PSNm");

			return resList;
		}

		/// <summary>
		/// �����p�d����N���X��r����
		/// </summary>
		/// <param name="searchCustSuppliRet1">��r����SearchCustSuppliRet�N���X�̃C���X�^���X</param>
		/// <param name="searchCustSuppliRet2">��r����SearchCustSuppliRet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SearchCustSuppliRet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SearchCustSuppliRet searchCustSuppliRet1, SearchCustSuppliRet searchCustSuppliRet2)
		{
			ArrayList resList = new ArrayList();
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //if (searchCustSuppliRet1.CustomerCode != searchCustSuppliRet2.CustomerCode) resList.Add("CustomerCode");
            if (searchCustSuppliRet1.SupplierCode != searchCustSuppliRet2.SupplierCode) resList.Add("SupplierCode");
            // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
            if(searchCustSuppliRet1.Name != searchCustSuppliRet2.Name)resList.Add("Name");
			if(searchCustSuppliRet1.Name2 != searchCustSuppliRet2.Name2)resList.Add("Name2");
			if(searchCustSuppliRet1.Kana != searchCustSuppliRet2.Kana)resList.Add("Kana");
			if(searchCustSuppliRet1.HomeTelNo != searchCustSuppliRet2.HomeTelNo)resList.Add("HomeTelNo");
			if(searchCustSuppliRet1.OfficeTelNo != searchCustSuppliRet2.OfficeTelNo)resList.Add("OfficeTelNo");
			if(searchCustSuppliRet1.PortableTelNo != searchCustSuppliRet2.PortableTelNo)resList.Add("PortableTelNo");
			if(searchCustSuppliRet1.HomeFaxNo != searchCustSuppliRet2.HomeFaxNo)resList.Add("HomeFaxNo");
			if(searchCustSuppliRet1.OfficeFaxNo != searchCustSuppliRet2.OfficeFaxNo)resList.Add("OfficeFaxNo");
			if(searchCustSuppliRet1.OthersTelNo != searchCustSuppliRet2.OthersTelNo)resList.Add("OthersTelNo");
			if(searchCustSuppliRet1.MainContactCode != searchCustSuppliRet2.MainContactCode)resList.Add("MainContactCode");
			if(searchCustSuppliRet1.TotalDay != searchCustSuppliRet2.TotalDay)resList.Add("TotalDay");
			if(searchCustSuppliRet1.PaymentMonthCode != searchCustSuppliRet2.PaymentMonthCode)resList.Add("PaymentMonthCode");
			if(searchCustSuppliRet1.PaymentMonthName != searchCustSuppliRet2.PaymentMonthName)resList.Add("PaymentMonthName");
			if(searchCustSuppliRet1.PaymentDay != searchCustSuppliRet2.PaymentDay)resList.Add("PaymentDay");
			if(searchCustSuppliRet1.SuppCTaxLayMethodNm != searchCustSuppliRet2.SuppCTaxLayMethodNm)resList.Add("SuppCTaxLayMethodNm");
			if(searchCustSuppliRet1.StartDateSpan != searchCustSuppliRet2.StartDateSpan)resList.Add("StartDateSpan");
			if(searchCustSuppliRet1.EndDateSpan != searchCustSuppliRet2.EndDateSpan)resList.Add("EndDateSpan");
			if(searchCustSuppliRet1.PartsSupplierDivCd != searchCustSuppliRet2.PartsSupplierDivCd)resList.Add("PartsSupplierDivCd");
			if(searchCustSuppliRet1.CarSupplierDivCd != searchCustSuppliRet2.CarSupplierDivCd)resList.Add("CarSupplierDivCd");
			if(searchCustSuppliRet1.OsrcSupplierDivCd != searchCustSuppliRet2.OsrcSupplierDivCd)resList.Add("OsrcSupplierDivCd");
            if(searchCustSuppliRet1.SNm != searchCustSuppliRet2.SNm) resList.Add("SNm");
            if(searchCustSuppliRet1.PayeeCode != searchCustSuppliRet2.PayeeCode)resList.Add("PayeeCode");
            if (searchCustSuppliRet1.PName != searchCustSuppliRet2.PName) resList.Add("PName");
            if (searchCustSuppliRet1.PName2 != searchCustSuppliRet2.PName2) resList.Add("PName2");
            if (searchCustSuppliRet1.PSNm != searchCustSuppliRet2.PSNm) resList.Add("PSNm");

			return resList;
		}
	}
}
