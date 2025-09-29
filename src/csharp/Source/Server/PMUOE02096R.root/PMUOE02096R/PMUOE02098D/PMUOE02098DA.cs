using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   UOEAnswerLedgerOrderCndtnWork
    /// <summary>
    ///                      UOE回答表示(元帳タイプ)抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE回答表示(元帳タイプ)抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class UOEAnswerLedgerOrderCndtnWork
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


        /// <summary>
        /// UOE回答表示(元帳タイプ)抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>UOEAnswerLedgerOrderCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEAnswerLedgerOrderCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOEAnswerLedgerOrderCndtnWork()
        {
        }

    }
}




