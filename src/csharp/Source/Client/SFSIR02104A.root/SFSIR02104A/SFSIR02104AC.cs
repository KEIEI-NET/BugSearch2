using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �x�����擾�p�p�����[�^
	/// </summary>
	public class SearchPaymentParameter
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
        /// <summary>�v���</summary>
		private DateTime _addUpADate;
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

		/// <summary>�v��� �v���p�e�B</summary>
		public DateTime AddUpADate
		{
			get { return _addUpADate; }
			set { _addUpADate = value; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SearchPaymentParameter()
		{
			_enterpriseCode = "";
			_addUpSecCode = "";
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //_customerCode = 0;
            _supplierCode = 0;
            // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
            _payeeCode = 0;
			_addUpADate = DateTime.MinValue;
		}
		#endregion
	}
}
