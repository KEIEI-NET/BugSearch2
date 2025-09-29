using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustomerSet
    /// <summary>
    ///                      得意先マスタ（印刷）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先マスタ（印刷）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class CustomerSet 
    {
        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>カナ</summary>
        private string _kana = "";

        /// <summary>電話番号（勤務先）</summary>
        private string _officeTelNo = "";

        /// <summary>電話番号（携帯）</summary>
        private string _portableTelNo = "";

        /// <summary>FAX番号（勤務先）</summary>
        private string _officeFaxNo = "";

        /// <summary>締日</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>集金月区分名称</summary>
        /// <remarks>当月,翌月,翌々月</remarks>
        private string _collectMoneyName = "";

        /// <summary>集金日</summary>
        /// <remarks>DD</remarks>
        private Int32 _collectMoneyDay;

        /// <summary>顧客担当従業員コード</summary>
        /// <remarks>文字型</remarks>
        private string _customerAgentCd = "";

        /// <summary>顧客担当従業員名称</summary>
        private string _customerAgentName = "";

        /// <summary>販売エリアコード</summary>
        private Int32 _salesAreaCode;

        /// <summary>販売エリア名称</summary>
        private string _salesAreaName = "";

        /// <summary>業種コード</summary>
        private Int32 _businessTypeCode;

        /// <summary>業種名称</summary>
        private string _businessTypeName = "";

        /// <summary>請求拠点コード</summary>
        private string _claimSectionCode = "";

        /// <summary>請求先コード</summary>
        private Int32 _claimCode;

        /// <summary>集金担当従業員コード</summary>
        private string _billCollecterCd = "";

        /// <summary>郵便番号</summary>
        private string _postNo = "";

        /// <summary>住所1（都道府県市区郡・町村・字）</summary>
        private string _address1 = "";

        /// <summary>住所3（番地）</summary>
        private string _address3 = "";

        /// <summary>住所4（アパート名称）</summary>
        private string _address4 = "";

        /// <summary>管理拠点コード</summary>
        private string _mngSectionCode = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>得意先優先倉庫コード</summary>
        private string _custWarehouseCd;

        /// <summary>名称</summary>
        private string _name = "";

        /// <summary>名称2</summary>
        private string _name2 = "";

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>純正区分</summary>
        /// <remarks>0:純正、1:優良</remarks>
        private Int32 _pureCode;

        /// <summary>商品メーカーコード</summary>
        /// <remarks>例)純正区分=「0:純正」の場合に使用 00:純正ALL、01～25:カーメーカー</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>得意先掛率グループコード</summary>
        private Int32 _custRateGrpCode;


        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
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
            get { return _kana; }
            set { _kana = value; }
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
            get { return _officeTelNo; }
            set { _officeTelNo = value; }
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
            get { return _portableTelNo; }
            set { _portableTelNo = value; }
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
            get { return _officeFaxNo; }
            set { _officeFaxNo = value; }
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
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  CollectMoneyName
        /// <summary>集金月区分名称プロパティ</summary>
        /// <value>当月,翌月,翌々月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金月区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CollectMoneyName
        {
            get { return _collectMoneyName; }
            set { _collectMoneyName = value; }
        }

        /// public propaty name  :  CollectMoneyDay
        /// <summary>集金日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectMoneyDay
        {
            get { return _collectMoneyDay; }
            set { _collectMoneyDay = value; }
        }

        /// public propaty name  :  CustomerAgentCd
        /// <summary>顧客担当従業員コードプロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentCd
        {
            get { return _customerAgentCd; }
            set { _customerAgentCd = value; }
        }

        /// public propaty name  :  CustomerAgentName
        /// <summary>顧客担当従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentName
        {
            get { return _customerAgentName; }
            set { _customerAgentName = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>販売エリアコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>販売エリア名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリア名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>業種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>業種名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }

        /// public propaty name  :  ClaimSectionCode
        /// <summary>請求拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimSectionCode
        {
            get { return _claimSectionCode; }
            set { _claimSectionCode = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>請求先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  BillCollecterCd
        /// <summary>集金担当従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillCollecterCd
        {
            get { return _billCollecterCd; }
            set { _billCollecterCd = value; }
        }

        /// public propaty name  :  PostNo
        /// <summary>郵便番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PostNo
        {
            get { return _postNo; }
            set { _postNo = value; }
        }

        /// public propaty name  :  Address1
        /// <summary>住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        /// public propaty name  :  Address3
        /// <summary>住所3（番地）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address3
        {
            get { return _address3; }
            set { _address3 = value; }
        }

        /// public propaty name  :  Address4
        /// <summary>住所4（アパート名称）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address4
        {
            get { return _address4; }
            set { _address4 = value; }
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

        /// public propaty name  :  SectionGuideSnm
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>帳票印字用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  CustWarehouseCd
        /// <summary>得意先優先倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先優先倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustWarehouseCd
        {
            get { return _custWarehouseCd; }
            set { _custWarehouseCd = value; }
        }

        /// public propaty name  :  Name
        /// <summary>名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  Name2
        /// <summary>名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Name2
        {
            get { return _name2; }
            set { _name2 = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  PureCode
        /// <summary>純正区分プロパティ</summary>
        /// <value>0:純正、1:優良</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PureCode
        {
            get { return _pureCode; }
            set { _pureCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>例)純正区分=「0:純正」の場合に使用 00:純正ALL、01～25:カーメーカー</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  CustRateGrpCode
        /// <summary>得意先掛率グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
        }			

        /// <summary>
        /// 得意先（印刷）データクラス複製処理
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustomerSet Clone()
        {
            return new CustomerSet(this._customerCode, this._kana, this._officeTelNo, this._portableTelNo, this._officeFaxNo, this._totalDay, this._collectMoneyName, this._collectMoneyDay, this._customerAgentCd, this._customerAgentName, this._salesAreaCode, this._salesAreaName, this._businessTypeCode, this._businessTypeName, this._claimSectionCode, this._claimCode, this._billCollecterCd, this._postNo, this._address1, this._address3, this._address4, this._mngSectionCode, this._sectionGuideSnm, this._custWarehouseCd, this._name, this._name2, this._customerSnm, this._pureCode, this._goodsMakerCd, this._custRateGrpCode);
        }

        /// <summary>
		/// 得意先（印刷）データクラスワークコンストラクタ
		/// </summary>
		/// <returns>CustomerSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerSetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustomerSet()
		{
		}
        
        /// <summary>
        /// 得意先（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="CustomerCode"></param>
        /// <param name="Kana"></param>
        /// <param name="OfficeTelNo"></param>
        /// <param name="PortableTelNo"></param>
        /// <param name="OfficeFaxNo"></param>
        /// <param name="TotalDay"></param>
        /// <param name="CollectMoneyName"></param>
        /// <param name="CollectMoneyDay"></param>
        /// <param name="CustomerAgentCd"></param>
        /// <param name="CustomerAgentName"></param>
        /// <param name="SalesAreaCode"></param>
        /// <param name="SalesAreaName"></param>
        /// <param name="BusinessTypeCode"></param>
        /// <param name="BusinessTypeName"></param>
        /// <param name="ClaimSectionCode"></param>
        /// <param name="ClaimCode"></param>
        /// <param name="BillCollecterCd"></param>
        /// <param name="PostNo"></param>
        /// <param name="Address1"></param>
        /// <param name="Address3"></param>
        /// <param name="Address4"></param>
        /// <param name="MngSectionCode"></param>
        /// <param name="SectionGuideSnm"></param>
        /// <param name="CustWarehouseCd"></param>
        /// <param name="Name"></param>
        /// <param name="Name2"></param>
        /// <param name="CustomerSnm"></param>
        /// <param name="CustRateGrpCode"></param>
        /// <param name="GoodsMakerCd"></param>
        /// <param name="PureCode"></param>
        public CustomerSet(Int32 CustomerCode, string Kana, string OfficeTelNo, string PortableTelNo, string OfficeFaxNo, Int32 TotalDay, string CollectMoneyName, Int32 CollectMoneyDay, string CustomerAgentCd, string CustomerAgentName, Int32 SalesAreaCode, string SalesAreaName, Int32 BusinessTypeCode, string BusinessTypeName, string ClaimSectionCode, Int32 ClaimCode, string BillCollecterCd, string PostNo, string Address1, string Address3, string Address4, string MngSectionCode, string SectionGuideSnm, string CustWarehouseCd, string Name, string Name2, string CustomerSnm, Int32 PureCode, Int32 GoodsMakerCd, Int32 CustRateGrpCode)
        {

            this._customerCode = CustomerCode;
            this._kana = Kana;
            this._officeTelNo = OfficeTelNo;
            this._portableTelNo = PortableTelNo;
            this._officeFaxNo = OfficeFaxNo;
            this._totalDay = TotalDay;
            this._collectMoneyName = CollectMoneyName;
            this._collectMoneyDay = CollectMoneyDay;
            this._customerAgentCd = CustomerAgentCd;
            this._customerAgentName = CustomerAgentName;
            this._salesAreaCode = SalesAreaCode;
            this._salesAreaName = SalesAreaName;
            this._businessTypeCode = BusinessTypeCode;
            this._businessTypeName = BusinessTypeName;
            this._claimSectionCode = ClaimSectionCode;
            this._claimCode = ClaimCode;
            this._billCollecterCd = BillCollecterCd;
            this._postNo = PostNo;
            this._address1 = Address1;
            this._address3 = Address3;
            this._address4 = Address4;
            this._mngSectionCode = MngSectionCode;
            this._sectionGuideSnm = SectionGuideSnm;
            this._custWarehouseCd = CustWarehouseCd;
            this._name = Name;
            this._name2 = Name2;
            this._customerSnm = CustomerSnm;
            this._pureCode = PureCode;
            this._goodsMakerCd = GoodsMakerCd;
            this._custRateGrpCode = CustRateGrpCode;
        }
    }
}
