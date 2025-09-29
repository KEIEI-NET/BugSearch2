using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PaymentSlpCndtnWork
    /// <summary>
    ///                      支払確認表抽出条件ワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   支払確認表抽出条件ワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/07/07  田中</br>
    /// <br>                 :   Partsman.NS対応</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PaymentSlpCndtnWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点オプション導入区分</summary>
        /// <remarks>true:全社選択　false:各拠点選択</remarks>
        private Boolean _isOptSection;

        /// <summary>本社機能</summary>
        /// <remarks>※未使用</remarks>
        private Boolean _isMainOfficeFunc;

        /// <summary>選択支払計上拠点コード</summary>
        private string[] _paymentAddupSecCodeList;

        /// <summary>開始支払計上日</summary>
        private DateTime _st_AddUpADate;

        /// <summary>終了支払計上日</summary>
        private DateTime _ed_AddUpADate;

        /// <summary>開始支払入力日</summary>
        private DateTime _st_InputDate;

        /// <summary>終了支払入力日</summary>
        private DateTime _ed_InputDate;

        /// <summary>帳票タイプ区分</summary>
        /// <remarks>1:総合計,2:簡易,3:金種別集計</remarks>
        private Int32 _printDiv;

        /// <summary>帳票タイプ区分名称</summary>
        /// <remarks>※未使用</remarks>
        private string _printDivName = "";

        /// <summary>小計区分</summary>
        /// <remarks>0：日計、1：支払先計、2：金種計、3：支払番号　※未使用</remarks>
        private Int32 _sumDivState;

        /// <summary>小計区分毎改ページ</summary>
        /// <remarks>※未使用</remarks>
        private Boolean _sumDiv;

        /// <summary>開始支払先コード</summary>
        private Int32 _st_PayeeCode;

        /// <summary>終了支払先コード</summary>
        private Int32 _ed_PayeeCode;

        /// <summary>開始支払先カナ</summary>
        private string _st_PayeeKana = "";

        /// <summary>終了支払先カナ</summary>
        private string _ed_PayeeKana = "";

        /// <summary>担当者区分</summary>
        /// <remarks>0:支払担当 1:入力担当</remarks>
        private Int32 _employeeKindDiv;

        /// <summary>開始担当者コード</summary>
        private string _st_EmployeeCode = "";

        /// <summary>終了担当者コード</summary>
        private string _ed_EmployeeCode = "";

        /// <summary>開始支払番号</summary>
        private Int32 _st_PaymentSlipNo;

        /// <summary>終了支払番号</summary>
        private Int32 _ed_PaymentSlipNo;

        /// <summary>支払金種</summary>
        /// <remarks>Key:金種コード,Value:金種名称</remarks>
        private ArrayList _paymentKind;


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

        /// public propaty name  :  IsOptSection
        /// <summary>拠点オプション導入区分プロパティ</summary>
        /// <value>true:全社選択　false:各拠点選択</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点オプション導入区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// public propaty name  :  IsMainOfficeFunc
        /// <summary>本社機能プロパティ</summary>
        /// <value>※未使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   本社機能プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// public propaty name  :  PaymentAddupSecCodeList
        /// <summary>選択支払計上拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択支払計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] PaymentAddupSecCodeList
        {
            get { return _paymentAddupSecCodeList; }
            set { _paymentAddupSecCodeList = value; }
        }

        /// public propaty name  :  St_AddUpADate
        /// <summary>開始支払計上日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始支払計上日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_AddUpADate
        {
            get { return _st_AddUpADate; }
            set { _st_AddUpADate = value; }
        }

        /// public propaty name  :  Ed_AddUpADate
        /// <summary>終了支払計上日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了支払計上日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_AddUpADate
        {
            get { return _ed_AddUpADate; }
            set { _ed_AddUpADate = value; }
        }

        /// public propaty name  :  St_InputDate
        /// <summary>開始支払入力日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始支払入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_InputDate
        {
            get { return _st_InputDate; }
            set { _st_InputDate = value; }
        }

        /// public propaty name  :  Ed_InputDate
        /// <summary>終了支払入力日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了支払入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_InputDate
        {
            get { return _ed_InputDate; }
            set { _ed_InputDate = value; }
        }

        /// public propaty name  :  PrintDiv
        /// <summary>帳票タイプ区分プロパティ</summary>
        /// <value>1:総合計,2:簡易,3:金種別集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票タイプ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintDiv
        {
            get { return _printDiv; }
            set { _printDiv = value; }
        }

        /// public propaty name  :  PrintDivName
        /// <summary>帳票タイプ区分名称プロパティ</summary>
        /// <value>※未使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票タイプ区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrintDivName
        {
            get { return _printDivName; }
            set { _printDivName = value; }
        }

        /// public propaty name  :  SumDivState
        /// <summary>小計区分プロパティ</summary>
        /// <value>0：日計、1：支払先計、2：金種計、3：支払番号　※未使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小計区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SumDivState
        {
            get { return _sumDivState; }
            set { _sumDivState = value; }
        }

        /// public propaty name  :  SumDiv
        /// <summary>小計区分毎改ページプロパティ</summary>
        /// <value>※未使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小計区分毎改ページプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean SumDiv
        {
            get { return _sumDiv; }
            set { _sumDiv = value; }
        }

        /// public propaty name  :  St_PayeeCode
        /// <summary>開始支払先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始支払先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_PayeeCode
        {
            get { return _st_PayeeCode; }
            set { _st_PayeeCode = value; }
        }

        /// public propaty name  :  Ed_PayeeCode
        /// <summary>終了支払先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了支払先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_PayeeCode
        {
            get { return _ed_PayeeCode; }
            set { _ed_PayeeCode = value; }
        }

        /// public propaty name  :  St_PayeeKana
        /// <summary>開始支払先カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始支払先カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_PayeeKana
        {
            get { return _st_PayeeKana; }
            set { _st_PayeeKana = value; }
        }

        /// public propaty name  :  Ed_PayeeKana
        /// <summary>終了支払先カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了支払先カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_PayeeKana
        {
            get { return _ed_PayeeKana; }
            set { _ed_PayeeKana = value; }
        }

        /// public propaty name  :  EmployeeKindDiv
        /// <summary>担当者区分プロパティ</summary>
        /// <value>0:支払担当 1:入力担当</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployeeKindDiv
        {
            get { return _employeeKindDiv; }
            set { _employeeKindDiv = value; }
        }

        /// public propaty name  :  St_EmployeeCode
        /// <summary>開始担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_EmployeeCode
        {
            get { return _st_EmployeeCode; }
            set { _st_EmployeeCode = value; }
        }

        /// public propaty name  :  Ed_EmployeeCode
        /// <summary>終了担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_EmployeeCode
        {
            get { return _ed_EmployeeCode; }
            set { _ed_EmployeeCode = value; }
        }

        /// public propaty name  :  St_PaymentSlipNo
        /// <summary>開始支払番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始支払番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_PaymentSlipNo
        {
            get { return _st_PaymentSlipNo; }
            set { _st_PaymentSlipNo = value; }
        }

        /// public propaty name  :  Ed_PaymentSlipNo
        /// <summary>終了支払番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了支払番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_PaymentSlipNo
        {
            get { return _ed_PaymentSlipNo; }
            set { _ed_PaymentSlipNo = value; }
        }

        /// public propaty name  :  PaymentKind
        /// <summary>支払金種プロパティ</summary>
        /// <value>Key:金種コード,Value:金種名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金種プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList PaymentKind
        {
            get { return _paymentKind; }
            set { _paymentKind = value; }
        }


        /// <summary>
        /// 支払確認表抽出条件ワークワークコンストラクタ
        /// </summary>
        /// <returns>PaymentSlpCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentSlpCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PaymentSlpCndtnWork()
        {
        }

    }
}
