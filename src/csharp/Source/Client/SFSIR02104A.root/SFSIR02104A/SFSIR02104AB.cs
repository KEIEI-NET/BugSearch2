using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �x���`�[���擾�p�p�����[�^
	/// </summary>
	public class SearchPaySlpInfoParameter
	{
		#region PrivateMember
		/// <summary>��ƃR�[�h</summary>
		private string _enterpriseCode;
		/// <summary>�v�㋒�_</summary>
		private string _addUpSecCode;
        // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
        ///// <summary>���Ӑ�R�[�h</summary>
        //private Int32 _customerCode;
        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCode;
        // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
        /// <summary>�x����R�[�h</summary>
        private Int32 _payeeCode;
		/// <summary>�x���`�[�ԍ�</summary>
		private Int32 _paymentSlipNo;
		/// <summary>�x���� �J�n</summary>
		private DateTime _paymentCallMonthsStart;
		/// <summary>�x���� �I��</summary>
		private DateTime _paymentCallMonthsEnd;
		/// <summary>�v���</summary>
		private DateTime _addUpADate;
        /// <summary>�����x���敪</summary>
        private Int32 _autoPayment;
		#endregion

		#region Property
		/// <summary>��ƃR�[�h �v���p�e�B</summary>
		public string EnterpriseCode
		{
			get { return _enterpriseCode; }
			set { _enterpriseCode = value; }
		}

		/// <summary>�v�㋒�_ �v���p�e�B</summary>
		public string AddUpSecCode
		{
			get { return _addUpSecCode; }
			set { _addUpSecCode = value; }
		}

        // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
        ///// <summary>���Ӑ�R�[�h �v���p�e�B</summary>
        //public Int32 CustomerCode
        //{
        //    get { return _customerCode; }
        //    set { _customerCode = value; }
        //}
        /// <summary>�d����R�[�h �v���p�e�B</summary>
        public Int32 SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }
        // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<

        /// <summary>�x����R�[�h �v���p�e�B</summary>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

		/// <summary>�x���`�[�ԍ� �v���p�e�B</summary>
		public Int32 PaymentSlipNo
		{
			get { return _paymentSlipNo; }
			set { _paymentSlipNo = value; }
		}

		/// <summary>�x���� �J�n �v���p�e�B</summary>
		public DateTime PaymentCallMonthsStart
		{
			get { return _paymentCallMonthsStart; }
			set { _paymentCallMonthsStart = value; }
		}

		/// <summary>�x���� �I�� �v���p�e�B</summary>
		public DateTime PaymentCallMonthsEnd
		{
			get { return _paymentCallMonthsEnd; }
			set { _paymentCallMonthsEnd = value; }
		}

		/// <summary>�v��� �v���p�e�B</summary>
		public DateTime AddUpADate
		{
			get { return _addUpADate; }
			set { _addUpADate = value; }
		}

        /// <summary>�����x���敪�v���p�e�B</summary>
        public Int32 AutoPayment
        {
            get { return _autoPayment; }
            set { _autoPayment = value; }
        }
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SearchPaySlpInfoParameter()
		{
			_enterpriseCode = "";
			_addUpSecCode = "";
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //_customerCode = 0;
            _supplierCode = 0;
            // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
            _payeeCode = 0;
			_paymentSlipNo = 0;
			_paymentCallMonthsStart = DateTime.MinValue;
			_paymentCallMonthsEnd = DateTime.MinValue;
			_addUpADate = DateTime.MinValue;
            _autoPayment = -1;
		}
		#endregion
	}
}
