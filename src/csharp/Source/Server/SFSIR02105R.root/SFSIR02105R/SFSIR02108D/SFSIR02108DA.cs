using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SearchParaChartAccept2
	/// <summary>
	///                      支払伝票検索パラメータクラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   支払伝票検索パラメータクラスヘッダファイル</br>
    /// <br>Programmer       :   99033 岩本　勇</br>
    /// <br>Date             :   2005/8/16</br>
    /// <br></br>
    /// <br>Update Note      :   980081  山田 明友</br>
    /// <br>                 :   2008.01.30 自動支払区分・仕入伝票番号を追加</br>
    /// </remarks>
	[Serializable]
	public class SearchParaPaymentRead
	{
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>計上拠点コード</summary>
        private string _addUpSecCode;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>支払伝票番号</summary>
        private Int32 _paymentSlipNo;

		/// <summary>入金日(開始)</summary>
		private DateTime _paymentCallMonthsStart;

		/// <summary>入金日(終了)</summary>
		private DateTime _paymentCallMonthsEnd;
        // ↓ 2008.01.30 980081 a
        /// <summary>自動支払区分</summary>
        /// <remarks>0:通常支払,　1:自動支払</remarks>
        private Int32 _autoPayment;

        /// <summary>仕入伝票番号</summary>
        private Int32 _supplierSlipNo;
        // ↑ 2008.01.30 980081 a

        /// public propaty name  :  enterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get{return _enterpriseCode;}
            set{_enterpriseCode = value;}
        }

        /// public propaty name  :  addUpSecCode
        /// <summary>計上拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コードプロパティ</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get{return _addUpSecCode;}
            set{_addUpSecCode = value;}
        }

        /// public propaty name  :  supplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get{return _supplierCd;}
            set{_supplierCd = value;}
        }

        /// public propaty name  :  PaymentSlipNo
        /// <summary>支払伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払伝票番号プロパティ</br>
        /// </remarks>
        public Int32 PaymentSlipNo
        {
            get{return _paymentSlipNo;}
            set{_paymentSlipNo = value;}
        }

		/// public propaty name  :  depositCallMonthsStart
		/// <summary>支払日(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払日(開始)プロパティ</br>
		/// </remarks>
		public DateTime PaymentCallMonthsStart
		{
			get{return _paymentCallMonthsStart;}
			set{_paymentCallMonthsStart = value;}
		}

		/// public propaty name  :  depositCallMonthsEnd
		/// <summary>支払日(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払日(終了)プロパティ</br>
		/// </remarks>
		public DateTime PaymentCallMonthsEnd
		{
			get{return _paymentCallMonthsEnd;}
			set{_paymentCallMonthsEnd = value;}
		}
        // ↓ 2008.01.30 980081 a
        /// public propaty name  :  AutoPayment
        /// <summary>自動支払区分プロパティ</summary>
        /// <value>0:通常支払,　1:自動支払</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動支払区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoPayment
        {
            get { return _autoPayment; }
            set { _autoPayment = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }
        // ↑ 2008.01.30 980081 a

		/// <summary>
		/// 仕入検索パラメータクラスコンストラクタ
		/// </summary>
		/// <returns>SearchParaPaymentReadクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SearchParaPaymentReadクラスの新しいインスタンスを生成します</br>
		/// </remarks>
		public SearchParaPaymentRead()
		{

		}

		/// <summary>
		/// 支払検索パラメータクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 企業コード、計上拠点コード、仕入先コード、支払伝票番号、支払日(開始)、支払日(終了) をセットします。</br>
		/// <br>Programmer : 90027 高口  勝</br>
		/// <br>Date       : 2005.08.16</br>
        /// <br></br>
        /// <br>Update Note: 980081  山田 明友</br>
        /// <br>           : 2008.01.30 自動支払区分・仕入伝票番号を追加</br>
        /// </remarks>
        // ↓ 2008.01.30 980081 c
        //public SearchParaPaymentRead(string enterpriseCode, string addUpSecCode, Int32 supplierCd,  Int32 paymentSlipNo, DateTime paymentCallMonthsStart, DateTime paymentCallMonthsEnd)
		//{
		//	this._enterpriseCode          = enterpriseCode;
		//	this._addUpSecCode		      = addUpSecCode;
		//	this._supplierCd            = supplierCd;
        //    this._paymentSlipNo = paymentSlipNo;
		//	this._paymentCallMonthsStart  = paymentCallMonthsStart;
        //    this._paymentCallMonthsEnd    = paymentCallMonthsEnd;
        //}
        public SearchParaPaymentRead(string enterpriseCode, string addUpSecCode, Int32 supplierCd, Int32 paymentSlipNo, DateTime paymentCallMonthsStart, DateTime paymentCallMonthsEnd, Int32 autoPayment, Int32 supplierSlipNo)
        {
            this._enterpriseCode = enterpriseCode;
            this._addUpSecCode = addUpSecCode;
            this._supplierCd = supplierCd;
            this._paymentSlipNo = paymentSlipNo;
            this._paymentCallMonthsStart = paymentCallMonthsStart;
            this._paymentCallMonthsEnd = paymentCallMonthsEnd;
            this._autoPayment = autoPayment;
            this._supplierSlipNo = supplierSlipNo;
        }
        // ↑ 2008.01.30 980081 c


	}
}
