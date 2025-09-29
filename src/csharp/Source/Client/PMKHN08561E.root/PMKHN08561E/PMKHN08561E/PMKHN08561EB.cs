using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SupplierSet
    /// <summary>
    ///                      結合マスタ（印刷）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   結合マスタ（印刷）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class SupplierSet 
    {
        /// <summary>結合コード</summary>
        private Int32 _supplierCd;

        /// <summary>結合略称</summary>
        private string _supplierSnm = "";

        /// <summary>結合カナ</summary>
        private string _supplierKana = "";

        /// <summary>結合電話番号</summary>
        private string _supplierTelNo = "";

        /// <summary>結合電話番号1</summary>
        private string _supplierTelNo1 = "";

        /// <summary>結合電話番号2</summary>
        private string _supplierTelNo2 = "";

        /// <summary>結合郵便番号</summary>
        private string _supplierPostNo = "";

        /// <summary>結合住所1（都道府県市区郡・町村・字）</summary>
        private string _supplierAddr1 = "";

        /// <summary>結合住所3（番地）</summary>
        private string _supplierAddr3 = "";

        /// <summary>結合住所4（アパート名称）</summary>
        private string _supplierAddr4 = "";

        /// <summary>支払締日</summary>
        private Int32 _paymentTotalDay;

        /// <summary>支払条件</summary>
        /// <remarks>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</remarks>
        private Int32 _paymentCond;

        /// <summary>支払月区分名称</summary>
        /// <remarks>当月、翌月、翌々月</remarks>
        private string _paymentMonthName = "";

        /// <summary>支払日</summary>
        /// <remarks>DD</remarks>
        private Int32 _paymentDay;

        /// <summary>仕入担当者コード</summary>
        private string _stockAgentCode = "";

        /// <summary>仕入担当者名称</summary>
        private string _stockAgentName = "";

        /// <summary>管理拠点コード</summary>
        private string _mngSectionCode = "";

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";

        /// <summary>支払拠点コード</summary>
        /// <remarks>請求を行う拠点</remarks>
        private string _paymentSectionCode = "";

        /// <summary>支払先コード</summary>
        private Int32 _payeeCode;

        /// <summary>支払先先略称</summary>
        private string _payeeSnm = "";


        /// public propaty name  :  SupplierCd
        /// <summary>結合コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>結合略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>結合カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierKana
        {
            get { return _supplierKana; }
            set { _supplierKana = value; }
        }
        

        /// public propaty name  :  SupplierTelNo
        /// <summary>結合電話番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合電話番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierTelNo
        {
            get { return _supplierTelNo; }
            set { _supplierTelNo = value; }
        }

        /// public propaty name  :  SupplierTelNo1
        /// <summary>結合電話番号1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合電話番号1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierTelNo1
        {
            get { return _supplierTelNo1; }
            set { _supplierTelNo1 = value; }
        }

        /// public propaty name  :  SupplierTelNo2
        /// <summary>結合電話番号2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合電話番号2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierTelNo2
        {
            get { return _supplierTelNo2; }
            set { _supplierTelNo2 = value; }
        }

        /// public propaty name  :  SupplierPostNo
        /// <summary>結合郵便番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierPostNo
        {
            get { return _supplierPostNo; }
            set { _supplierPostNo = value; }
        }

        /// public propaty name  :  SupplierAddr1
        /// <summary>結合住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierAddr1
        {
            get { return _supplierAddr1; }
            set { _supplierAddr1 = value; }
        }

        /// public propaty name  :  SupplierAddr3
        /// <summary>結合住所3（番地）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierAddr3
        {
            get { return _supplierAddr3; }
            set { _supplierAddr3 = value; }
        }

        /// public propaty name  :  SupplierAddr4
        /// <summary>結合住所4（アパート名称）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierAddr4
        {
            get { return _supplierAddr4; }
            set { _supplierAddr4 = value; }
        }

        /// public propaty name  :  PaymentTotalDay
        /// <summary>支払締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentTotalDay
        {
            get { return _paymentTotalDay; }
            set { _paymentTotalDay = value; }
        }

        /// public propaty name  :  PaymentCond
        /// <summary>支払条件プロパティ</summary>
        /// <value>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払条件プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentCond
        {
            get { return _paymentCond; }
            set { _paymentCond = value; }
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
            get { return _paymentMonthName; }
            set { _paymentMonthName = value; }
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
            get { return _paymentDay; }
            set { _paymentDay = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>仕入担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>仕入担当者名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }
        
        /// public propaty name  :  MngSectionCode
        /// <summary>管理拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  PaymentSectionCode
        /// <summary>支払拠点コードプロパティ</summary>
        /// <value>請求を行う拠点</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentSectionCode
        {
            get { return _paymentSectionCode; }
            set { _paymentSectionCode = value; }
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
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  PayeeSnm
        /// <summary>支払先先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
        }

        /// <summary>
        /// 結合（印刷）データクラス複製処理
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SupplierSet Clone()
        {
            return new SupplierSet(this._supplierCd, this._supplierSnm, this._supplierKana, this._supplierTelNo, this._supplierTelNo1, this._supplierTelNo2, this._supplierPostNo, this._supplierAddr1, this._supplierAddr3, this._supplierAddr4, this._paymentTotalDay, this._paymentCond, this._paymentMonthName, this._paymentDay, this._stockAgentCode, this._stockAgentName, this._mngSectionCode, this._sectionGuideNm, this._paymentSectionCode, this._payeeCode, this._payeeSnm);

        }

        /// <summary>
		/// 結合（印刷）データクラスワークコンストラクタ
		/// </summary>
		/// <returns>EmployeeSetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EmployeeSetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SupplierSet()
		{
		}

        /// <summary>
        /// 結合（印刷）データクラスワークコンストラクタ
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
