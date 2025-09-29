using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 支払情報取得用パラメータ
	/// </summary>
	public class SearchPaymentParameter
	{
		#region PrivateMember
		/// <summary>企業コード</summary>
		private string _enterpriseCode;
		/// <summary>計上拠点</summary>
		private string _addUpSecCode;

        // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
        ///// <summary>得意先コード</summary>
        //private Int32 _customerCode;
        /// <summary>仕入先コード</summary>
        private Int32 _supplierCode;
        // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<

        /// <summary>支払先コード</summary>
        private Int32 _payeeCode;
        /// <summary>計上日</summary>
		private DateTime _addUpADate;
		#endregion

		#region Property
		/// <summary>企業コード プロパティ</summary>
		public string EnterpriseCode
		{
			get { return _enterpriseCode; }
			set { _enterpriseCode = value; }
		}

		/// <summary>計上拠点 プロパティ</summary>
		public string AddUpSecCode
		{
			get { return _addUpSecCode; }
			set { _addUpSecCode = value; }
		}

        // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
        ///// <summary>得意先コード プロパティ</summary>
        //public Int32 CustomerCode
        //{
        //    get { return _customerCode; }
        //    set { _customerCode = value; }
        //}
        /// <summary>仕入先コード プロパティ</summary>
        public Int32 SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }
        // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<

        /// <summary>支払先コード プロパティ</summary>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

		/// <summary>計上日 プロパティ</summary>
		public DateTime AddUpADate
		{
			get { return _addUpADate; }
			set { _addUpADate = value; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
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
