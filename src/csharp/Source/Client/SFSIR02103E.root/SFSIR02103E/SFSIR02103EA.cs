using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SearchCustSuppliRet
	/// <summary>
	///                      検索用仕入先クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   検索用仕入先クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/07/25</br>
	/// <br>Genarated Date   :   2007/07/25  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SearchCustSuppliRet
	{
        // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
        ///// <summary>得意先コード</summary>
        //private Int32 _customerCode;
        /// <summary>仕入先先コード</summary>
        private Int32 _supplierCode;
        // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<

		/// <summary>名称</summary>
		private string _name = "";

		/// <summary>名称２</summary>
		private string _name2 = "";

		/// <summary>カナ</summary>
		private string _kana = "";

		/// <summary>電話番号（自宅）</summary>
		/// <remarks>ハイフンを含めた16桁の番号</remarks>
		private string _homeTelNo = "";

		/// <summary>電話番号（勤務先）</summary>
		private string _officeTelNo = "";

		/// <summary>電話番号（携帯）</summary>
		private string _portableTelNo = "";

		/// <summary>FAX番号（自宅）</summary>
		private string _homeFaxNo = "";

		/// <summary>FAX番号（勤務先）</summary>
		private string _officeFaxNo = "";

		/// <summary>電話番号（その他）</summary>
		private string _othersTelNo = "";

		/// <summary>主連絡先区分</summary>
		/// <remarks>0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･</remarks>
		private Int32 _mainContactCode;

		/// <summary>締日</summary>
		/// <remarks>DD</remarks>
		private Int32 _totalDay;

		/// <summary>支払月区分コード</summary>
		/// <remarks>0:当月 1:翌月 2:翌々月</remarks>
		private Int32 _paymentMonthCode;

		/// <summary>支払月区分名称</summary>
		/// <remarks>当月、翌月、翌々月</remarks>
		private string _paymentMonthName = "";

		/// <summary>支払日</summary>
		/// <remarks>DD</remarks>
		private Int32 _paymentDay;

		/// <summary>仕入先消費税転嫁方式名称</summary>
		/// <remarks>伝票単位、明細単位、請求単位</remarks>
		private string _suppCTaxLayMethodNm = "";

		/// <summary>支払期間（開始）</summary>
		private Int32 _startDateSpan;

		/// <summary>支払期間（終了）</summary>
		private Int32 _endDateSpan;

		/// <summary>部品仕入先区分</summary>
		private Int32 _partsSupplierDivCd;

		/// <summary>車両仕入先区分</summary>
		private Int32 _carSupplierDivCd;

		/// <summary>外注仕入先区分</summary>
		private Int32 _osrcSupplierDivCd;

        /// <summary>略称</summary>
        private string _sNm = "";

        /// <summary>支払先コード</summary>
        private Int32 _payeeCode;

        /// <summary>支払先名称</summary>
        private string _pName = "";

        /// <summary>支払先名称２</summary>
        private string _pName2 = "";

        /// <summary>支払先略称</summary>
        private string _pSnm = "";

        // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
        ///// public propaty name  :  CustomerCode
        ///// <summary>得意先コードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustomerCode
        //{
        //    get{return _customerCode;}
        //    set{_customerCode = value;}
        //}
        /// public property name  :  SupplierCode
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/07/08</br>
        /// </remarks>
        public Int32 SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }
        // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<

		/// public propaty name  :  Name
		/// <summary>名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Name
		{
			get{return _name;}
			set{_name = value;}
		}

		/// public propaty name  :  Name2
		/// <summary>名称２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   名称２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Name2
		{
			get{return _name2;}
			set{_name2 = value;}
		}

		/// public propaty name  :  Kana
		/// <summary>カナプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Kana
		{
			get{return _kana;}
			set{_kana = value;}
		}

        /// public propaty name  :  HomeTelNo
		/// <summary>電話番号（自宅）プロパティ</summary>
		/// <value>ハイフンを含めた16桁の番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（自宅）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string HomeTelNo
		{
			get{return _homeTelNo;}
			set{_homeTelNo = value;}
		}

		/// public propaty name  :  OfficeTelNo
		/// <summary>電話番号（勤務先）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（勤務先）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OfficeTelNo
		{
			get{return _officeTelNo;}
			set{_officeTelNo = value;}
		}

		/// public propaty name  :  PortableTelNo
		/// <summary>電話番号（携帯）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（携帯）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PortableTelNo
		{
			get{return _portableTelNo;}
			set{_portableTelNo = value;}
		}

		/// public propaty name  :  HomeFaxNo
		/// <summary>FAX番号（自宅）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   FAX番号（自宅）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string HomeFaxNo
		{
			get{return _homeFaxNo;}
			set{_homeFaxNo = value;}
		}

		/// public propaty name  :  OfficeFaxNo
		/// <summary>FAX番号（勤務先）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   FAX番号（勤務先）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OfficeFaxNo
		{
			get{return _officeFaxNo;}
			set{_officeFaxNo = value;}
		}

		/// public propaty name  :  OthersTelNo
		/// <summary>電話番号（その他）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（その他）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OthersTelNo
		{
			get{return _othersTelNo;}
			set{_othersTelNo = value;}
		}

		/// public propaty name  :  MainContactCode
		/// <summary>主連絡先区分プロパティ</summary>
		/// <value>0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   主連絡先区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MainContactCode
		{
			get{return _mainContactCode;}
			set{_mainContactCode = value;}
		}

		/// public propaty name  :  TotalDay
		/// <summary>締日プロパティ</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TotalDay
		{
			get{return _totalDay;}
			set{_totalDay = value;}
		}

		/// public propaty name  :  PaymentMonthCode
		/// <summary>支払月区分コードプロパティ</summary>
		/// <value>0:当月 1:翌月 2:翌々月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払月区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PaymentMonthCode
		{
			get{return _paymentMonthCode;}
			set{_paymentMonthCode = value;}
		}

		/// public propaty name  :  PaymentMonthName
		/// <summary>支払月区分名称プロパティ</summary>
		/// <value>当月、翌月、翌々月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払月区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PaymentMonthName
		{
			get{return _paymentMonthName;}
			set{_paymentMonthName = value;}
		}

		/// public propaty name  :  PaymentDay
		/// <summary>支払日プロパティ</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PaymentDay
		{
			get{return _paymentDay;}
			set{_paymentDay = value;}
		}

		/// public propaty name  :  SuppCTaxLayMethodNm
		/// <summary>仕入先消費税転嫁方式名称プロパティ</summary>
		/// <value>伝票単位、明細単位、請求単位</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先消費税転嫁方式名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SuppCTaxLayMethodNm
		{
			get{return _suppCTaxLayMethodNm;}
			set{_suppCTaxLayMethodNm = value;}
		}

		/// public propaty name  :  StartDateSpan
		/// <summary>支払期間（開始）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払期間（開始）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartDateSpan
		{
			get{return _startDateSpan;}
			set{_startDateSpan = value;}
		}

		/// public propaty name  :  EndDateSpan
		/// <summary>支払期間（終了）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払期間（終了）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EndDateSpan
		{
			get{return _endDateSpan;}
			set{_endDateSpan = value;}
		}

		/// public propaty name  :  PartsSupplierDivCd
		/// <summary>部品仕入先区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部品仕入先区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PartsSupplierDivCd
		{
			get{return _partsSupplierDivCd;}
			set{_partsSupplierDivCd = value;}
		}

		/// public propaty name  :  CarSupplierDivCd
		/// <summary>車両仕入先区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両仕入先区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CarSupplierDivCd
		{
			get{return _carSupplierDivCd;}
			set{_carSupplierDivCd = value;}
		}

		/// public propaty name  :  OsrcSupplierDivCd
		/// <summary>外注仕入先区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   外注仕入先区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OsrcSupplierDivCd
		{
			get{return _osrcSupplierDivCd;}
			set{_osrcSupplierDivCd = value;}
		}

        /// public propaty name  :  SNm
        /// <summary>略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SNm
        {
            get { return _sNm; }
            set { _sNm = value; }
        }

		/// public propaty name  :  PayeeCode
		/// <summary>支払先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PayeeCode
		{
			get{return _payeeCode;}
			set{_payeeCode = value;}
		}

        /// public propaty name  :  PName
        /// <summary>支払先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PName
        {
            get { return _pName; }
            set { _pName = value; }
        }

        /// public propaty name  :  PName
        /// <summary>支払先名称２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先名称２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PName2
        {
            get { return _pName2; }
            set { _pName2 = value; }
        }

        /// public propaty name  :  PSNm
        /// <summary>支払先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PSNm
        {
            get { return _pSnm; }
            set { _pSnm = value; }
        }

		/// <summary>
		/// 検索用仕入先クラスコンストラクタ
		/// </summary>
		/// <returns>SearchCustSuppliRetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SearchCustSuppliRetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SearchCustSuppliRet()
		{
		}

		/// <summary>
		/// 検索用仕入先クラスコンストラクタ
		/// </summary>
        /// <param name="supplierCode">仕入先コード</param>
		/// <param name="name">名称</param>
		/// <param name="name2">名称２</param>
		/// <param name="kana">カナ</param>
		/// <param name="homeTelNo">電話番号（自宅）(ハイフンを含めた16桁の番号)</param>
		/// <param name="officeTelNo">電話番号（勤務先）</param>
		/// <param name="portableTelNo">電話番号（携帯）</param>
		/// <param name="homeFaxNo">FAX番号（自宅）</param>
		/// <param name="officeFaxNo">FAX番号（勤務先）</param>
		/// <param name="othersTelNo">電話番号（その他）</param>
		/// <param name="mainContactCode">主連絡先区分(0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･)</param>
		/// <param name="totalDay">締日(DD)</param>
		/// <param name="paymentMonthCode">支払月区分コード(0:当月 1:翌月 2:翌々月)</param>
		/// <param name="paymentMonthName">支払月区分名称(当月、翌月、翌々月)</param>
		/// <param name="paymentDay">支払日(DD)</param>
		/// <param name="suppCTaxLayMethodNm">仕入先消費税転嫁方式名称(伝票単位、明細単位、請求単位)</param>
		/// <param name="startDateSpan">支払期間（開始）</param>
		/// <param name="endDateSpan">支払期間（終了）</param>
		/// <param name="partsSupplierDivCd">部品仕入先区分</param>
		/// <param name="carSupplierDivCd">車両仕入先区分</param>
		/// <param name="osrcSupplierDivCd">外注仕入先区分</param>
        /// <param name="sNm">略称</param>
        /// <param name="payeeCode">支払先コード</param>
        /// <param name="pName">支払先名称</param>
        /// <param name="pName2">支払先名称２</param>
        /// <param name="pSnm">支払先略称</param>
        /// <returns>SearchCustSuppliRetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SearchCustSuppliRetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
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
		/// 検索用仕入先クラス複製処理
		/// </summary>
		/// <returns>SearchCustSuppliRetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSearchCustSuppliRetクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SearchCustSuppliRet Clone()
		{
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //return new SearchCustSuppliRet(this._customerCode, this._name, this._name2, this._kana, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._othersTelNo, this._mainContactCode, this._totalDay, this._paymentMonthCode, this._paymentMonthName, this._paymentDay, this._suppCTaxLayMethodNm, this._startDateSpan, this._endDateSpan, this._partsSupplierDivCd, this._carSupplierDivCd, this._osrcSupplierDivCd, this._sNm, this._payeeCode, this._pName, this._pName2, this._pSnm);
            return new SearchCustSuppliRet(this._supplierCode, this._name, this._name2, this._kana, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._othersTelNo, this._mainContactCode, this._totalDay, this._paymentMonthCode, this._paymentMonthName, this._paymentDay, this._suppCTaxLayMethodNm, this._startDateSpan, this._endDateSpan, this._partsSupplierDivCd, this._carSupplierDivCd, this._osrcSupplierDivCd, this._sNm, this._payeeCode, this._pName, this._pName2, this._pSnm);
            // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
        }

		/// <summary>
		/// 検索用仕入先クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSearchCustSuppliRetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SearchCustSuppliRetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
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
		/// 検索用仕入先クラス比較処理
		/// </summary>
		/// <param name="searchCustSuppliRet1">
		///                    比較するSearchCustSuppliRetクラスのインスタンス
		/// </param>
		/// <param name="searchCustSuppliRet2">比較するSearchCustSuppliRetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SearchCustSuppliRetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
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
		/// 検索用仕入先クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSearchCustSuppliRetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SearchCustSuppliRetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
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
		/// 検索用仕入先クラス比較処理
		/// </summary>
		/// <param name="searchCustSuppliRet1">比較するSearchCustSuppliRetクラスのインスタンス</param>
		/// <param name="searchCustSuppliRet2">比較するSearchCustSuppliRetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SearchCustSuppliRetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
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
