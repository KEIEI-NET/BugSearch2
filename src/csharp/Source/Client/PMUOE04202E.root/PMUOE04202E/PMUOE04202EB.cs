using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UOEAnswerLedgerOrderCndtn
    /// <summary>
    ///                      UOE回答表示(元帳タイプ)抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE回答表示(元帳タイプ)抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UOEAnswerLedgerOrderCndtn
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>システム区分</summary>
        /// <remarks>0:手入力 1:伝発 2:検索 3：一括 4：補充　-1:全て</remarks>
        private Int32 _systemDivCd;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>UOE発注先コード</summary>
        private Int32 _uOESupplierCd;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>開始受信日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_ReceiveDate;

        /// <summary>終了受信日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_ReceiveDate;

        /// <summary>開始受信時刻</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_ReceiveTime;

        /// <summary>終了受信時刻</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_ReceiveTime;

        /// <summary>従業員コード</summary>
        /// <remarks>依頼者コード</remarks>
        private string _employeeCode = "";

        /// <summary>UOE納品区分</summary>
        private string _uOEDeliGoodsDiv = "";

        /// <summary>フォロー納品区分</summary>
        private string _followDeliGoodsDiv = "";

        /// <summary>仕入伝票番号</summary>
        private Int32 _supplierSlipNo;

        /// <summary>UOE発注番号</summary>
        private Int32 _uOESalesOrderNo;

        /// <summary>ＵＯＥリマーク１</summary>
        private string _uoeRemark1 = "";

        /// <summary>ＵＯＥリマーク２</summary>
        private string _uoeRemark2 = "";

        /// <summary>UOE種別</summary>
        /// <remarks>0:UOE 1:卸商仕入受信</remarks>
        private Int32 _uOEKind;

        /// <summary>入力日(開始)</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _st_InputDay;

        /// <summary>入力日(終了)</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _ed_InputDay;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        // --- 手動生成 ----------------------------->>>>>
        /// <summary>システム区分名称</summary>
        private string _systemDivName = "";

        /// <summary>UOE発注先名称</summary>
        private string _uoeSupplierName = "";

        /// <summary>得意先名称</summary>
        private string _customerName = "";
        // ------------------------------------------<<<<<

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SystemDivCd
        /// <summary>システム区分プロパティ</summary>
        /// <value>0:手入力 1:伝発 2:検索 3：一括 4：補充　-1:全て</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   システム区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SystemDivCd
        {
            get { return _systemDivCd; }
            set { _systemDivCd = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE発注先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

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

        /// public propaty name  :  St_ReceiveDate
        /// <summary>開始受信日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始受信日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_ReceiveDate
        {
            get { return _st_ReceiveDate; }
            set { _st_ReceiveDate = value; }
        }

        /// public propaty name  :  Ed_ReceiveDate
        /// <summary>終了受信日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了受信日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_ReceiveDate
        {
            get { return _ed_ReceiveDate; }
            set { _ed_ReceiveDate = value; }
        }

        /// public propaty name  :  St_ReceiveTime
        /// <summary>開始受信時刻プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始受信時刻プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_ReceiveTime
        {
            get { return _st_ReceiveTime; }
            set { _st_ReceiveTime = value; }
        }

        /// public propaty name  :  Ed_ReceiveTime
        /// <summary>終了受信時刻プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了受信時刻プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_ReceiveTime
        {
            get { return _ed_ReceiveTime; }
            set { _ed_ReceiveTime = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// <value>依頼者コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  UOEDeliGoodsDiv
        /// <summary>UOE納品区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEDeliGoodsDiv
        {
            get { return _uOEDeliGoodsDiv; }
            set { _uOEDeliGoodsDiv = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDiv
        /// <summary>フォロー納品区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   フォロー納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FollowDeliGoodsDiv
        {
            get { return _followDeliGoodsDiv; }
            set { _followDeliGoodsDiv = value; }
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

        /// public propaty name  :  UOESalesOrderNo
        /// <summary>UOE発注番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESalesOrderNo
        {
            get { return _uOESalesOrderNo; }
            set { _uOESalesOrderNo = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>ＵＯＥリマーク１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>ＵＯＥリマーク２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  UOEKind
        /// <summary>UOE種別プロパティ</summary>
        /// <value>0:UOE 1:卸商仕入受信</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOEKind
        {
            get { return _uOEKind; }
            set { _uOEKind = value; }
        }

        /// public propaty name  :  St_InputDay
        /// <summary>入力日(開始)プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_InputDay
        {
            get { return _st_InputDay; }
            set { _st_InputDay = value; }
        }

        /// public propaty name  :  Ed_InputDay
        /// <summary>入力日(終了)プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_InputDay
        {
            get { return _ed_InputDay; }
            set { _ed_InputDay = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        // --- 手動生成 ----------------------------------------------------------->>>>>
        /// public propaty name  :  SystemDivName
        /// <summary>拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   手動生成</br>
        /// </remarks>
        public string SystemDivName
        {
            get { return _systemDivName; }
            set { _systemDivName = value; }
        }
        /// public propaty name  :  UOESupplierName
        /// <summary>UOE発注先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先名称プロパティ</br>
        /// <br>Programer        :   手動生成</br>
        /// </remarks>
        public string UOESupplierName
        {
            get { return _uoeSupplierName; }
            set { _uoeSupplierName = value; }
        }
        /// public propaty name  :  CustomerName
        /// <summary>得意先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称プロパティ</br>
        /// <br>Programer        :   手動生成</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
        // ------------------------------------------------------------------------<<<<<

        /// <summary>
        /// UOE回答表示(元帳タイプ)抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>UOEAnswerLedgerOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEAnswerLedgerOrderCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOEAnswerLedgerOrderCndtn()
        {
        }

        /// <summary>
        /// UOE回答表示(元帳タイプ)抽出条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="systemDivCd">システム区分(0:手入力 1:伝発 2:検索 3：一括 4：補充　-1:全て)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="st_ReceiveDate">開始受信日付(YYYYMMDD)</param>
        /// <param name="ed_ReceiveDate">終了受信日付(YYYYMMDD)</param>
        /// <param name="st_ReceiveTime">開始受信時刻(YYYYMMDD)</param>
        /// <param name="ed_ReceiveTime">終了受信時刻(YYYYMMDD)</param>
        /// <param name="employeeCode">従業員コード(依頼者コード)</param>
        /// <param name="uOEDeliGoodsDiv">UOE納品区分</param>
        /// <param name="followDeliGoodsDiv">フォロー納品区分</param>
        /// <param name="supplierSlipNo">仕入伝票番号</param>
        /// <param name="uOESalesOrderNo">UOE発注番号</param>
        /// <param name="uoeRemark1">ＵＯＥリマーク１</param>
        /// <param name="uoeRemark2">ＵＯＥリマーク２</param>
        /// <param name="uOEKind">UOE種別(0:UOE 1:卸商仕入受信)</param>
        /// <param name="st_InputDay">入力日(開始)(YYYYMMDD　（更新年月日）)</param>
        /// <param name="ed_InputDay">入力日(終了)(YYYYMMDD　（更新年月日）)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>UOEAnswerLedgerOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEAnswerLedgerOrderCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOEAnswerLedgerOrderCndtn(string enterpriseCode, Int32 systemDivCd, string sectionCode, Int32 uOESupplierCd, Int32 customerCode, DateTime st_ReceiveDate, DateTime ed_ReceiveDate, DateTime st_ReceiveTime, DateTime ed_ReceiveTime, string employeeCode, string uOEDeliGoodsDiv, string followDeliGoodsDiv, Int32 supplierSlipNo, Int32 uOESalesOrderNo, string uoeRemark1, string uoeRemark2, Int32 uOEKind, DateTime st_InputDay, DateTime ed_InputDay, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._systemDivCd = systemDivCd;
            this._sectionCode = sectionCode;
            this._uOESupplierCd = uOESupplierCd;
            this._customerCode = customerCode;
            this._st_ReceiveDate = st_ReceiveDate;
            this._ed_ReceiveDate = ed_ReceiveDate;
            this._st_ReceiveTime = st_ReceiveTime;
            this._ed_ReceiveTime = ed_ReceiveTime;
            this._employeeCode = employeeCode;
            this._uOEDeliGoodsDiv = uOEDeliGoodsDiv;
            this._followDeliGoodsDiv = followDeliGoodsDiv;
            this._supplierSlipNo = supplierSlipNo;
            this._uOESalesOrderNo = uOESalesOrderNo;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this._uOEKind = uOEKind;
            this._st_InputDay = st_InputDay;
            this._ed_InputDay = ed_InputDay;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// UOE回答表示(元帳タイプ)抽出条件クラス複製処理
        /// </summary>
        /// <returns>UOEAnswerLedgerOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいUOEAnswerLedgerOrderCndtnクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOEAnswerLedgerOrderCndtn Clone()
        {
            return new UOEAnswerLedgerOrderCndtn(this._enterpriseCode, this._systemDivCd, this._sectionCode, this._uOESupplierCd, this._customerCode, this._st_ReceiveDate, this._ed_ReceiveDate, this._st_ReceiveTime, this._ed_ReceiveTime, this._employeeCode, this._uOEDeliGoodsDiv, this._followDeliGoodsDiv, this._supplierSlipNo, this._uOESalesOrderNo, this._uoeRemark1, this._uoeRemark2, this._uOEKind, this._st_InputDay, this._ed_InputDay, this._enterpriseName);
        }

        /// <summary>
        /// UOE回答表示(元帳タイプ)抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のUOEAnswerLedgerOrderCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEAnswerLedgerOrderCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(UOEAnswerLedgerOrderCndtn target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SystemDivCd == target.SystemDivCd)
                 && (this.SectionCode == target.SectionCode)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.St_ReceiveDate == target.St_ReceiveDate)
                 && (this.Ed_ReceiveDate == target.Ed_ReceiveDate)
                 && (this.St_ReceiveTime == target.St_ReceiveTime)
                 && (this.Ed_ReceiveTime == target.Ed_ReceiveTime)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.UOEDeliGoodsDiv == target.UOEDeliGoodsDiv)
                 && (this.FollowDeliGoodsDiv == target.FollowDeliGoodsDiv)
                 && (this.SupplierSlipNo == target.SupplierSlipNo)
                 && (this.UOESalesOrderNo == target.UOESalesOrderNo)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.UOEKind == target.UOEKind)
                 && (this.St_InputDay == target.St_InputDay)
                 && (this.Ed_InputDay == target.Ed_InputDay)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// UOE回答表示(元帳タイプ)抽出条件クラス比較処理
        /// </summary>
        /// <param name="uOEAnswerLedgerOrderCndtn1">
        ///                    比較するUOEAnswerLedgerOrderCndtnクラスのインスタンス
        /// </param>
        /// <param name="uOEAnswerLedgerOrderCndtn2">比較するUOEAnswerLedgerOrderCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEAnswerLedgerOrderCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(UOEAnswerLedgerOrderCndtn uOEAnswerLedgerOrderCndtn1, UOEAnswerLedgerOrderCndtn uOEAnswerLedgerOrderCndtn2)
        {
            return ((uOEAnswerLedgerOrderCndtn1.EnterpriseCode == uOEAnswerLedgerOrderCndtn2.EnterpriseCode)
                 && (uOEAnswerLedgerOrderCndtn1.SystemDivCd == uOEAnswerLedgerOrderCndtn2.SystemDivCd)
                 && (uOEAnswerLedgerOrderCndtn1.SectionCode == uOEAnswerLedgerOrderCndtn2.SectionCode)
                 && (uOEAnswerLedgerOrderCndtn1.UOESupplierCd == uOEAnswerLedgerOrderCndtn2.UOESupplierCd)
                 && (uOEAnswerLedgerOrderCndtn1.CustomerCode == uOEAnswerLedgerOrderCndtn2.CustomerCode)
                 && (uOEAnswerLedgerOrderCndtn1.St_ReceiveDate == uOEAnswerLedgerOrderCndtn2.St_ReceiveDate)
                 && (uOEAnswerLedgerOrderCndtn1.Ed_ReceiveDate == uOEAnswerLedgerOrderCndtn2.Ed_ReceiveDate)
                 && (uOEAnswerLedgerOrderCndtn1.St_ReceiveTime == uOEAnswerLedgerOrderCndtn2.St_ReceiveTime)
                 && (uOEAnswerLedgerOrderCndtn1.Ed_ReceiveTime == uOEAnswerLedgerOrderCndtn2.Ed_ReceiveTime)
                 && (uOEAnswerLedgerOrderCndtn1.EmployeeCode == uOEAnswerLedgerOrderCndtn2.EmployeeCode)
                 && (uOEAnswerLedgerOrderCndtn1.UOEDeliGoodsDiv == uOEAnswerLedgerOrderCndtn2.UOEDeliGoodsDiv)
                 && (uOEAnswerLedgerOrderCndtn1.FollowDeliGoodsDiv == uOEAnswerLedgerOrderCndtn2.FollowDeliGoodsDiv)
                 && (uOEAnswerLedgerOrderCndtn1.SupplierSlipNo == uOEAnswerLedgerOrderCndtn2.SupplierSlipNo)
                 && (uOEAnswerLedgerOrderCndtn1.UOESalesOrderNo == uOEAnswerLedgerOrderCndtn2.UOESalesOrderNo)
                 && (uOEAnswerLedgerOrderCndtn1.UoeRemark1 == uOEAnswerLedgerOrderCndtn2.UoeRemark1)
                 && (uOEAnswerLedgerOrderCndtn1.UoeRemark2 == uOEAnswerLedgerOrderCndtn2.UoeRemark2)
                 && (uOEAnswerLedgerOrderCndtn1.UOEKind == uOEAnswerLedgerOrderCndtn2.UOEKind)
                 && (uOEAnswerLedgerOrderCndtn1.St_InputDay == uOEAnswerLedgerOrderCndtn2.St_InputDay)
                 && (uOEAnswerLedgerOrderCndtn1.Ed_InputDay == uOEAnswerLedgerOrderCndtn2.Ed_InputDay)
                 && (uOEAnswerLedgerOrderCndtn1.EnterpriseName == uOEAnswerLedgerOrderCndtn2.EnterpriseName));
        }
        /// <summary>
        /// UOE回答表示(元帳タイプ)抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のUOEAnswerLedgerOrderCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEAnswerLedgerOrderCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(UOEAnswerLedgerOrderCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SystemDivCd != target.SystemDivCd) resList.Add("SystemDivCd");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.St_ReceiveDate != target.St_ReceiveDate) resList.Add("St_ReceiveDate");
            if (this.Ed_ReceiveDate != target.Ed_ReceiveDate) resList.Add("Ed_ReceiveDate");
            if (this.St_ReceiveTime != target.St_ReceiveTime) resList.Add("St_ReceiveTime");
            if (this.Ed_ReceiveTime != target.Ed_ReceiveTime) resList.Add("Ed_ReceiveTime");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.UOEDeliGoodsDiv != target.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (this.FollowDeliGoodsDiv != target.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (this.SupplierSlipNo != target.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (this.UOESalesOrderNo != target.UOESalesOrderNo) resList.Add("UOESalesOrderNo");
            if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
            if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
            if (this.UOEKind != target.UOEKind) resList.Add("UOEKind");
            if (this.St_InputDay != target.St_InputDay) resList.Add("St_InputDay");
            if (this.Ed_InputDay != target.Ed_InputDay) resList.Add("Ed_InputDay");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// UOE回答表示(元帳タイプ)抽出条件クラス比較処理
        /// </summary>
        /// <param name="uOEAnswerLedgerOrderCndtn1">比較するUOEAnswerLedgerOrderCndtnクラスのインスタンス</param>
        /// <param name="uOEAnswerLedgerOrderCndtn2">比較するUOEAnswerLedgerOrderCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEAnswerLedgerOrderCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(UOEAnswerLedgerOrderCndtn uOEAnswerLedgerOrderCndtn1, UOEAnswerLedgerOrderCndtn uOEAnswerLedgerOrderCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (uOEAnswerLedgerOrderCndtn1.EnterpriseCode != uOEAnswerLedgerOrderCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (uOEAnswerLedgerOrderCndtn1.SystemDivCd != uOEAnswerLedgerOrderCndtn2.SystemDivCd) resList.Add("SystemDivCd");
            if (uOEAnswerLedgerOrderCndtn1.SectionCode != uOEAnswerLedgerOrderCndtn2.SectionCode) resList.Add("SectionCode");
            if (uOEAnswerLedgerOrderCndtn1.UOESupplierCd != uOEAnswerLedgerOrderCndtn2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (uOEAnswerLedgerOrderCndtn1.CustomerCode != uOEAnswerLedgerOrderCndtn2.CustomerCode) resList.Add("CustomerCode");
            if (uOEAnswerLedgerOrderCndtn1.St_ReceiveDate != uOEAnswerLedgerOrderCndtn2.St_ReceiveDate) resList.Add("St_ReceiveDate");
            if (uOEAnswerLedgerOrderCndtn1.Ed_ReceiveDate != uOEAnswerLedgerOrderCndtn2.Ed_ReceiveDate) resList.Add("Ed_ReceiveDate");
            if (uOEAnswerLedgerOrderCndtn1.St_ReceiveTime != uOEAnswerLedgerOrderCndtn2.St_ReceiveTime) resList.Add("St_ReceiveTime");
            if (uOEAnswerLedgerOrderCndtn1.Ed_ReceiveTime != uOEAnswerLedgerOrderCndtn2.Ed_ReceiveTime) resList.Add("Ed_ReceiveTime");
            if (uOEAnswerLedgerOrderCndtn1.EmployeeCode != uOEAnswerLedgerOrderCndtn2.EmployeeCode) resList.Add("EmployeeCode");
            if (uOEAnswerLedgerOrderCndtn1.UOEDeliGoodsDiv != uOEAnswerLedgerOrderCndtn2.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (uOEAnswerLedgerOrderCndtn1.FollowDeliGoodsDiv != uOEAnswerLedgerOrderCndtn2.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (uOEAnswerLedgerOrderCndtn1.SupplierSlipNo != uOEAnswerLedgerOrderCndtn2.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (uOEAnswerLedgerOrderCndtn1.UOESalesOrderNo != uOEAnswerLedgerOrderCndtn2.UOESalesOrderNo) resList.Add("UOESalesOrderNo");
            if (uOEAnswerLedgerOrderCndtn1.UoeRemark1 != uOEAnswerLedgerOrderCndtn2.UoeRemark1) resList.Add("UoeRemark1");
            if (uOEAnswerLedgerOrderCndtn1.UoeRemark2 != uOEAnswerLedgerOrderCndtn2.UoeRemark2) resList.Add("UoeRemark2");
            if (uOEAnswerLedgerOrderCndtn1.UOEKind != uOEAnswerLedgerOrderCndtn2.UOEKind) resList.Add("UOEKind");
            if (uOEAnswerLedgerOrderCndtn1.St_InputDay != uOEAnswerLedgerOrderCndtn2.St_InputDay) resList.Add("St_InputDay");
            if (uOEAnswerLedgerOrderCndtn1.Ed_InputDay != uOEAnswerLedgerOrderCndtn2.Ed_InputDay) resList.Add("Ed_InputDay");
            if (uOEAnswerLedgerOrderCndtn1.EnterpriseName != uOEAnswerLedgerOrderCndtn2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}

/*
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UOEAnswerLedgerOrderCndtn
    /// <summary>
    ///                      UOE回答表示(元帳タイプ)抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE回答表示(元帳タイプ)抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UOEAnswerLedgerOrderCndtn
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>システム区分</summary>
        /// <remarks>0:手入力 1:伝発 2:検索 3：一括 4：補充　-1:全て</remarks>
        private Int32 _systemDivCd;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>UOE発注先コード</summary>
        private Int32 _uOESupplierCd;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>開始受信日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_ReceiveDate;

        /// <summary>終了受信日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_ReceiveDate;

        /// <summary>開始受信時刻</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _st_ReceiveTime;

        /// <summary>終了受信時刻</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _ed_ReceiveTime;

        /// <summary>従業員コード</summary>
        /// <remarks>依頼者コード</remarks>
        private string _employeeCode = "";

        /// <summary>納品区分</summary>
        private Int32 _deliveredGoodsDiv;

        /// <summary>フォロー納品区分</summary>
        private string _followDeliGoodsDiv = "";

        /// <summary>仕入伝票番号</summary>
        private Int32 _supplierSlipNo;

        /// <summary>UOE発注番号</summary>
        private Int32 _uOESalesOrderNo;

        /// <summary>ＵＯＥリマーク１</summary>
        private string _uoeRemark1 = "";

        /// <summary>ＵＯＥリマーク２</summary>
        private string _uoeRemark2 = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        // --- 手動生成 ----------------------------->>>>>
        /// <summary>システム区分名称</summary>
        private string _systemDivName = "";

        /// <summary>UOE発注先名称</summary>
        private string _uoeSupplierName = "";

        /// <summary>得意先名称</summary>
        private string _customerName = "";
        // ------------------------------------------<<<<<

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SystemDivCd
        /// <summary>システム区分プロパティ</summary>
        /// <value>0:手入力 1:伝発 2:検索 3：一括 4：補充　-1:全て</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   システム区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SystemDivCd
        {
            get { return _systemDivCd; }
            set { _systemDivCd = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE発注先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

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

        /// public propaty name  :  St_ReceiveDate
        /// <summary>開始受信日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始受信日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_ReceiveDate
        {
            get { return _st_ReceiveDate; }
            set { _st_ReceiveDate = value; }
        }

        /// public propaty name  :  Ed_ReceiveDate
        /// <summary>終了受信日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了受信日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_ReceiveDate
        {
            get { return _ed_ReceiveDate; }
            set { _ed_ReceiveDate = value; }
        }

        /// public propaty name  :  St_ReceiveTime
        /// <summary>開始受信時刻プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始受信時刻プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_ReceiveTime
        {
            get { return _st_ReceiveTime; }
            set { _st_ReceiveTime = value; }
        }

        /// public propaty name  :  Ed_ReceiveTime
        /// <summary>終了受信時刻プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了受信時刻プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_ReceiveTime
        {
            get { return _ed_ReceiveTime; }
            set { _ed_ReceiveTime = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// <value>依頼者コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>納品区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDiv
        /// <summary>フォロー納品区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   フォロー納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FollowDeliGoodsDiv
        {
            get { return _followDeliGoodsDiv; }
            set { _followDeliGoodsDiv = value; }
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

        /// public propaty name  :  UOESalesOrderNo
        /// <summary>UOE発注番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESalesOrderNo
        {
            get { return _uOESalesOrderNo; }
            set { _uOESalesOrderNo = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>ＵＯＥリマーク１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>ＵＯＥリマーク２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        // --- 手動生成 ----------------------------------------------------------->>>>>
        /// public propaty name  :  SystemDivName
        /// <summary>拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   手動生成</br>
        /// </remarks>
        public string SystemDivName
        {
            get { return _systemDivName; }
            set { _systemDivName = value; }
        }
        /// public propaty name  :  UOESupplierName
        /// <summary>UOE発注先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先名称プロパティ</br>
        /// <br>Programer        :   手動生成</br>
        /// </remarks>
        public string UOESupplierName
        {
            get { return _uoeSupplierName; }
            set { _uoeSupplierName = value; }
        }
        /// public propaty name  :  CustomerName
        /// <summary>得意先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称プロパティ</br>
        /// <br>Programer        :   手動生成</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
        // ------------------------------------------------------------------------<<<<<

        /// <summary>
        /// UOE回答表示(元帳タイプ)抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>UOEAnswerLedgerOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEAnswerLedgerOrderCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOEAnswerLedgerOrderCndtn()
        {
        }

        /// <summary>
        /// UOE回答表示(元帳タイプ)抽出条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="systemDivCd">システム区分(0:手入力 1:伝発 2:検索 3：一括 4：補充　-1:全て)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="st_ReceiveDate">開始受信日付(YYYYMMDD)</param>
        /// <param name="ed_ReceiveDate">終了受信日付(YYYYMMDD)</param>
        /// <param name="st_ReceiveTime">開始受信時刻(YYYYMMDD)</param>
        /// <param name="ed_ReceiveTime">終了受信時刻(YYYYMMDD)</param>
        /// <param name="employeeCode">従業員コード(依頼者コード)</param>
        /// <param name="deliveredGoodsDiv">納品区分</param>
        /// <param name="followDeliGoodsDiv">フォロー納品区分</param>
        /// <param name="supplierSlipNo">仕入伝票番号</param>
        /// <param name="uOESalesOrderNo">UOE発注番号</param>
        /// <param name="uoeRemark1">ＵＯＥリマーク１</param>
        /// <param name="uoeRemark2">ＵＯＥリマーク２</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>UOEAnswerLedgerOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEAnswerLedgerOrderCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOEAnswerLedgerOrderCndtn(string enterpriseCode, Int32 systemDivCd, string sectionCode, Int32 uOESupplierCd, Int32 customerCode, DateTime st_ReceiveDate, DateTime ed_ReceiveDate, Int32 st_ReceiveTime, Int32 ed_ReceiveTime, string employeeCode, Int32 deliveredGoodsDiv, string followDeliGoodsDiv, Int32 supplierSlipNo, Int32 uOESalesOrderNo, string uoeRemark1, string uoeRemark2, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._systemDivCd = systemDivCd;
            this._sectionCode = sectionCode;
            this._uOESupplierCd = uOESupplierCd;
            this._customerCode = customerCode;
            this._st_ReceiveDate = st_ReceiveDate;
            this._ed_ReceiveDate = ed_ReceiveDate;
            this._st_ReceiveTime = st_ReceiveTime;
            this._ed_ReceiveTime = ed_ReceiveTime;
            this._employeeCode = employeeCode;
            this._deliveredGoodsDiv = deliveredGoodsDiv;
            this._followDeliGoodsDiv = followDeliGoodsDiv;
            this._supplierSlipNo = supplierSlipNo;
            this._uOESalesOrderNo = uOESalesOrderNo;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// UOE回答表示(元帳タイプ)抽出条件クラス複製処理
        /// </summary>
        /// <returns>UOEAnswerLedgerOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいUOEAnswerLedgerOrderCndtnクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOEAnswerLedgerOrderCndtn Clone()
        {
            return new UOEAnswerLedgerOrderCndtn(this._enterpriseCode, this._systemDivCd, this._sectionCode, this._uOESupplierCd, this._customerCode, this._st_ReceiveDate, this._ed_ReceiveDate, this._st_ReceiveTime, this._ed_ReceiveTime, this._employeeCode, this._deliveredGoodsDiv, this._followDeliGoodsDiv, this._supplierSlipNo, this._uOESalesOrderNo, this._uoeRemark1, this._uoeRemark2, this._enterpriseName);
        }

        /// <summary>
        /// UOE回答表示(元帳タイプ)抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のUOEAnswerLedgerOrderCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEAnswerLedgerOrderCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(UOEAnswerLedgerOrderCndtn target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SystemDivCd == target.SystemDivCd)
                 && (this.SectionCode == target.SectionCode)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.St_ReceiveDate == target.St_ReceiveDate)
                 && (this.Ed_ReceiveDate == target.Ed_ReceiveDate)
                 && (this.St_ReceiveTime == target.St_ReceiveTime)
                 && (this.Ed_ReceiveTime == target.Ed_ReceiveTime)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
                 && (this.FollowDeliGoodsDiv == target.FollowDeliGoodsDiv)
                 && (this.SupplierSlipNo == target.SupplierSlipNo)
                 && (this.UOESalesOrderNo == target.UOESalesOrderNo)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// UOE回答表示(元帳タイプ)抽出条件クラス比較処理
        /// </summary>
        /// <param name="uOEAnswerLedgerOrderCndtn1">
        ///                    比較するUOEAnswerLedgerOrderCndtnクラスのインスタンス
        /// </param>
        /// <param name="uOEAnswerLedgerOrderCndtn2">比較するUOEAnswerLedgerOrderCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEAnswerLedgerOrderCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(UOEAnswerLedgerOrderCndtn uOEAnswerLedgerOrderCndtn1, UOEAnswerLedgerOrderCndtn uOEAnswerLedgerOrderCndtn2)
        {
            return ((uOEAnswerLedgerOrderCndtn1.EnterpriseCode == uOEAnswerLedgerOrderCndtn2.EnterpriseCode)
                 && (uOEAnswerLedgerOrderCndtn1.SystemDivCd == uOEAnswerLedgerOrderCndtn2.SystemDivCd)
                 && (uOEAnswerLedgerOrderCndtn1.SectionCode == uOEAnswerLedgerOrderCndtn2.SectionCode)
                 && (uOEAnswerLedgerOrderCndtn1.UOESupplierCd == uOEAnswerLedgerOrderCndtn2.UOESupplierCd)
                 && (uOEAnswerLedgerOrderCndtn1.CustomerCode == uOEAnswerLedgerOrderCndtn2.CustomerCode)
                 && (uOEAnswerLedgerOrderCndtn1.St_ReceiveDate == uOEAnswerLedgerOrderCndtn2.St_ReceiveDate)
                 && (uOEAnswerLedgerOrderCndtn1.Ed_ReceiveDate == uOEAnswerLedgerOrderCndtn2.Ed_ReceiveDate)
                 && (uOEAnswerLedgerOrderCndtn1.St_ReceiveTime == uOEAnswerLedgerOrderCndtn2.St_ReceiveTime)
                 && (uOEAnswerLedgerOrderCndtn1.Ed_ReceiveTime == uOEAnswerLedgerOrderCndtn2.Ed_ReceiveTime)
                 && (uOEAnswerLedgerOrderCndtn1.EmployeeCode == uOEAnswerLedgerOrderCndtn2.EmployeeCode)
                 && (uOEAnswerLedgerOrderCndtn1.DeliveredGoodsDiv == uOEAnswerLedgerOrderCndtn2.DeliveredGoodsDiv)
                 && (uOEAnswerLedgerOrderCndtn1.FollowDeliGoodsDiv == uOEAnswerLedgerOrderCndtn2.FollowDeliGoodsDiv)
                 && (uOEAnswerLedgerOrderCndtn1.SupplierSlipNo == uOEAnswerLedgerOrderCndtn2.SupplierSlipNo)
                 && (uOEAnswerLedgerOrderCndtn1.UOESalesOrderNo == uOEAnswerLedgerOrderCndtn2.UOESalesOrderNo)
                 && (uOEAnswerLedgerOrderCndtn1.UoeRemark1 == uOEAnswerLedgerOrderCndtn2.UoeRemark1)
                 && (uOEAnswerLedgerOrderCndtn1.UoeRemark2 == uOEAnswerLedgerOrderCndtn2.UoeRemark2)
                 && (uOEAnswerLedgerOrderCndtn1.EnterpriseName == uOEAnswerLedgerOrderCndtn2.EnterpriseName));
        }
        /// <summary>
        /// UOE回答表示(元帳タイプ)抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のUOEAnswerLedgerOrderCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEAnswerLedgerOrderCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(UOEAnswerLedgerOrderCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SystemDivCd != target.SystemDivCd) resList.Add("SystemDivCd");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.St_ReceiveDate != target.St_ReceiveDate) resList.Add("St_ReceiveDate");
            if (this.Ed_ReceiveDate != target.Ed_ReceiveDate) resList.Add("Ed_ReceiveDate");
            if (this.St_ReceiveTime != target.St_ReceiveTime) resList.Add("St_ReceiveTime");
            if (this.Ed_ReceiveTime != target.Ed_ReceiveTime) resList.Add("Ed_ReceiveTime");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (this.FollowDeliGoodsDiv != target.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (this.SupplierSlipNo != target.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (this.UOESalesOrderNo != target.UOESalesOrderNo) resList.Add("UOESalesOrderNo");
            if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
            if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// UOE回答表示(元帳タイプ)抽出条件クラス比較処理
        /// </summary>
        /// <param name="uOEAnswerLedgerOrderCndtn1">比較するUOEAnswerLedgerOrderCndtnクラスのインスタンス</param>
        /// <param name="uOEAnswerLedgerOrderCndtn2">比較するUOEAnswerLedgerOrderCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEAnswerLedgerOrderCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(UOEAnswerLedgerOrderCndtn uOEAnswerLedgerOrderCndtn1, UOEAnswerLedgerOrderCndtn uOEAnswerLedgerOrderCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (uOEAnswerLedgerOrderCndtn1.EnterpriseCode != uOEAnswerLedgerOrderCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (uOEAnswerLedgerOrderCndtn1.SystemDivCd != uOEAnswerLedgerOrderCndtn2.SystemDivCd) resList.Add("SystemDivCd");
            if (uOEAnswerLedgerOrderCndtn1.SectionCode != uOEAnswerLedgerOrderCndtn2.SectionCode) resList.Add("SectionCode");
            if (uOEAnswerLedgerOrderCndtn1.UOESupplierCd != uOEAnswerLedgerOrderCndtn2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (uOEAnswerLedgerOrderCndtn1.CustomerCode != uOEAnswerLedgerOrderCndtn2.CustomerCode) resList.Add("CustomerCode");
            if (uOEAnswerLedgerOrderCndtn1.St_ReceiveDate != uOEAnswerLedgerOrderCndtn2.St_ReceiveDate) resList.Add("St_ReceiveDate");
            if (uOEAnswerLedgerOrderCndtn1.Ed_ReceiveDate != uOEAnswerLedgerOrderCndtn2.Ed_ReceiveDate) resList.Add("Ed_ReceiveDate");
            if (uOEAnswerLedgerOrderCndtn1.St_ReceiveTime != uOEAnswerLedgerOrderCndtn2.St_ReceiveTime) resList.Add("St_ReceiveTime");
            if (uOEAnswerLedgerOrderCndtn1.Ed_ReceiveTime != uOEAnswerLedgerOrderCndtn2.Ed_ReceiveTime) resList.Add("Ed_ReceiveTime");
            if (uOEAnswerLedgerOrderCndtn1.EmployeeCode != uOEAnswerLedgerOrderCndtn2.EmployeeCode) resList.Add("EmployeeCode");
            if (uOEAnswerLedgerOrderCndtn1.DeliveredGoodsDiv != uOEAnswerLedgerOrderCndtn2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (uOEAnswerLedgerOrderCndtn1.FollowDeliGoodsDiv != uOEAnswerLedgerOrderCndtn2.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (uOEAnswerLedgerOrderCndtn1.SupplierSlipNo != uOEAnswerLedgerOrderCndtn2.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (uOEAnswerLedgerOrderCndtn1.UOESalesOrderNo != uOEAnswerLedgerOrderCndtn2.UOESalesOrderNo) resList.Add("UOESalesOrderNo");
            if (uOEAnswerLedgerOrderCndtn1.UoeRemark1 != uOEAnswerLedgerOrderCndtn2.UoeRemark1) resList.Add("UoeRemark1");
            if (uOEAnswerLedgerOrderCndtn1.UoeRemark2 != uOEAnswerLedgerOrderCndtn2.UoeRemark2) resList.Add("UoeRemark2");
            if (uOEAnswerLedgerOrderCndtn1.EnterpriseName != uOEAnswerLedgerOrderCndtn2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
*/