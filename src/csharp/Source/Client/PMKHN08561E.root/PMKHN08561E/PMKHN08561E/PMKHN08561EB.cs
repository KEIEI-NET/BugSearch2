using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SupplierSet
    /// <summary>
    ///                      �����}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class SupplierSet 
    {
        /// <summary>�����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>��������</summary>
        private string _supplierSnm = "";

        /// <summary>�����J�i</summary>
        private string _supplierKana = "";

        /// <summary>�����d�b�ԍ�</summary>
        private string _supplierTelNo = "";

        /// <summary>�����d�b�ԍ�1</summary>
        private string _supplierTelNo1 = "";

        /// <summary>�����d�b�ԍ�2</summary>
        private string _supplierTelNo2 = "";

        /// <summary>�����X�֔ԍ�</summary>
        private string _supplierPostNo = "";

        /// <summary>�����Z��1�i�s���{���s��S�E�����E���j</summary>
        private string _supplierAddr1 = "";

        /// <summary>�����Z��3�i�Ԓn�j</summary>
        private string _supplierAddr3 = "";

        /// <summary>�����Z��4�i�A�p�[�g���́j</summary>
        private string _supplierAddr4 = "";

        /// <summary>�x������</summary>
        private Int32 _paymentTotalDay;

        /// <summary>�x������</summary>
        /// <remarks>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</remarks>
        private Int32 _paymentCond;

        /// <summary>�x�����敪����</summary>
        /// <remarks>�����A�����A���X��</remarks>
        private string _paymentMonthName = "";

        /// <summary>�x����</summary>
        /// <remarks>DD</remarks>
        private Int32 _paymentDay;

        /// <summary>�d���S���҃R�[�h</summary>
        private string _stockAgentCode = "";

        /// <summary>�d���S���Җ���</summary>
        private string _stockAgentName = "";

        /// <summary>�Ǘ����_�R�[�h</summary>
        private string _mngSectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideNm = "";

        /// <summary>�x�����_�R�[�h</summary>
        /// <remarks>�������s�����_</remarks>
        private string _paymentSectionCode = "";

        /// <summary>�x����R�[�h</summary>
        private Int32 _payeeCode;

        /// <summary>�x����旪��</summary>
        private string _payeeSnm = "";


        /// public propaty name  :  SupplierCd
        /// <summary>�����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>�����J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierKana
        {
            get { return _supplierKana; }
            set { _supplierKana = value; }
        }
        

        /// public propaty name  :  SupplierTelNo
        /// <summary>�����d�b�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����d�b�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierTelNo
        {
            get { return _supplierTelNo; }
            set { _supplierTelNo = value; }
        }

        /// public propaty name  :  SupplierTelNo1
        /// <summary>�����d�b�ԍ�1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����d�b�ԍ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierTelNo1
        {
            get { return _supplierTelNo1; }
            set { _supplierTelNo1 = value; }
        }

        /// public propaty name  :  SupplierTelNo2
        /// <summary>�����d�b�ԍ�2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����d�b�ԍ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierTelNo2
        {
            get { return _supplierTelNo2; }
            set { _supplierTelNo2 = value; }
        }

        /// public propaty name  :  SupplierPostNo
        /// <summary>�����X�֔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierPostNo
        {
            get { return _supplierPostNo; }
            set { _supplierPostNo = value; }
        }

        /// public propaty name  :  SupplierAddr1
        /// <summary>�����Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierAddr1
        {
            get { return _supplierAddr1; }
            set { _supplierAddr1 = value; }
        }

        /// public propaty name  :  SupplierAddr3
        /// <summary>�����Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierAddr3
        {
            get { return _supplierAddr3; }
            set { _supplierAddr3 = value; }
        }

        /// public propaty name  :  SupplierAddr4
        /// <summary>�����Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierAddr4
        {
            get { return _supplierAddr4; }
            set { _supplierAddr4 = value; }
        }

        /// public propaty name  :  PaymentTotalDay
        /// <summary>�x�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentTotalDay
        {
            get { return _paymentTotalDay; }
            set { _paymentTotalDay = value; }
        }

        /// public propaty name  :  PaymentCond
        /// <summary>�x�������v���p�e�B</summary>
        /// <value>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentCond
        {
            get { return _paymentCond; }
            set { _paymentCond = value; }
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
            get { return _paymentMonthName; }
            set { _paymentMonthName = value; }
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
            get { return _paymentDay; }
            set { _paymentDay = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>�d���S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>�d���S���Җ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���Җ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }
        
        /// public propaty name  :  MngSectionCode
        /// <summary>�Ǘ����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
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
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  PaymentSectionCode
        /// <summary>�x�����_�R�[�h�v���p�e�B</summary>
        /// <value>�������s�����_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentSectionCode
        {
            get { return _paymentSectionCode; }
            set { _paymentSectionCode = value; }
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
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  PayeeSnm
        /// <summary>�x����旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x����旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
        }

        /// <summary>
        /// �����i����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SupplierSet Clone()
        {
            return new SupplierSet(this._supplierCd, this._supplierSnm, this._supplierKana, this._supplierTelNo, this._supplierTelNo1, this._supplierTelNo2, this._supplierPostNo, this._supplierAddr1, this._supplierAddr3, this._supplierAddr4, this._paymentTotalDay, this._paymentCond, this._paymentMonthName, this._paymentDay, this._stockAgentCode, this._stockAgentName, this._mngSectionCode, this._sectionGuideNm, this._paymentSectionCode, this._payeeCode, this._payeeSnm);

        }

        /// <summary>
		/// �����i����j�f�[�^�N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>EmployeeSetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EmployeeSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SupplierSet()
		{
		}

        /// <summary>
        /// �����i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="SupplierCd"></param>
        /// <param name="SupplierSnm"></param>
        /// <param name="SupplierKana"></param>
        /// <param name="SupplierTelNo"></param>
        /// <param name="SupplierTelNo1"></param>
        /// <param name="SupplierTelNo2"></param>
        /// <param name="SupplierPostNo"></param>
        /// <param name="SupplierAddr1"></param>
        /// <param name="SupplierAddr3"></param>
        /// <param name="SupplierAddr4"></param>
        /// <param name="PaymentTotalDay"></param>
        /// <param name="PaymentCond"></param>
        /// <param name="PaymentMonthName"></param>
        /// <param name="PaymentDay"></param>
        /// <param name="StockAgentCode"></param>
        /// <param name="StockAgentName"></param>
        /// <param name="MngSectionCode"></param>
        /// <param name="SectionGuideNm"></param>
        /// <param name="PaymentSectionCode"></param>
        /// <param name="PayeeCode"></param>
        /// <param name="PayeeSnm"></param>
        public SupplierSet(Int32 SupplierCd, string SupplierSnm, string SupplierKana, string SupplierTelNo, string SupplierTelNo1, string SupplierTelNo2, string SupplierPostNo, string SupplierAddr1, string SupplierAddr3, string SupplierAddr4, Int32 PaymentTotalDay, Int32 PaymentCond, string PaymentMonthName, Int32 PaymentDay, string StockAgentCode, string StockAgentName, string MngSectionCode, string SectionGuideNm, string PaymentSectionCode, Int32 PayeeCode, string PayeeSnm)
        {
            this._supplierCd = SupplierCd;
            this._supplierSnm = SupplierSnm;
            this._supplierKana = SupplierKana;
            this._supplierTelNo = SupplierTelNo;
            this._supplierTelNo1 = SupplierTelNo1;
            this._supplierTelNo2 = SupplierTelNo2;
            this._supplierPostNo = SupplierPostNo;
            this._supplierAddr1 = SupplierAddr1;
            this._supplierAddr3 = SupplierAddr3;
            this._supplierAddr4 = SupplierAddr4;
            this._paymentTotalDay = PaymentTotalDay;
            this._paymentCond = PaymentCond;
            this._paymentMonthName = PaymentMonthName;
            this._paymentDay = PaymentDay;
            this._stockAgentCode = StockAgentCode;
            this._stockAgentName = StockAgentName;
            this._mngSectionCode = MngSectionCode;
            this._sectionGuideNm = SectionGuideNm;
            this._paymentSectionCode = PaymentSectionCode;
            this._payeeCode = PayeeCode;
            this._payeeSnm = PayeeSnm;

        }
    }
}
