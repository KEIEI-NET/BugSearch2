using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    # region --- DEL 2008/08/25 M.Kubota --->>>
    # if false
    /// public class name:   IOWriteMASIRPaymentWork
    /// <summary>
    ///                      仕入支払データワーク(IOWriteMASIRPayment)ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入支払データワーク(IOWriteMASIRPayment)ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/01/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class IOWriteMASIRPaymentWork : IFileHeader
    {
        /// <summary>作成日時</summary>
        /// <remarks>リモート側で設定</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>リモート側で設定</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>リモート側で設定</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>リモート側で設定</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>リモート側で設定</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>リモート側で設定</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>リモート側で設定</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>リモート側で設定</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>赤伝区分</summary>
        /// <remarks>仕入データより</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>支払伝票番号</summary>
        /// <remarks>未設定</remarks>
        private Int32 _paymentSlipNo;

        /// <summary>仕入形式</summary>
        /// <remarks>仕入データより</remarks>
        private Int32 _supplierFormal;

        /// <summary>仕入伝票番号</summary>
        /// <remarks>仕入データより</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>得意先コード</summary>
        /// <remarks>仕入データより</remarks>
        private Int32 _customerCode;

        /// <summary>得意先名称</summary>
        /// <remarks>仕入データより</remarks>
        private string _customerName = "";

        /// <summary>得意先名称2</summary>
        /// <remarks>仕入データより</remarks>
        private string _customerName2 = "";

        /// <summary>得意先略称</summary>
        /// <remarks>仕入データより</remarks>
        private string _customerSnm = "";

        /// <summary>支払先コード</summary>
        /// <remarks>仕入データより</remarks>
        private Int32 _payeeCode;

        /// <summary>支払先名称</summary>
        /// <remarks>仕入データより</remarks>
        private string _payeeName = "";

        /// <summary>支払先名称2</summary>
        /// <remarks>仕入データより</remarks>
        private string _payeeName2 = "";

        /// <summary>支払先略称</summary>
        /// <remarks>仕入データより</remarks>
        private string _payeeSnm = "";

        /// <summary>支払入力拠点コード</summary>
        /// <remarks>仕入拠点コードをセット</remarks>
        private string _paymentInpSectionCd = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>仕入計上拠点コードをセット</remarks>
        private string _addUpSecCode = "";

        /// <summary>更新拠点コード</summary>
        /// <remarks>拠点コードをセット</remarks>
        private string _updateSecCd = "";

        /// <summary>部門コード</summary>
        /// <remarks>仕入データより</remarks>
        private Int32 _subSectionCode;

        /// <summary>課コード</summary>
        /// <remarks>仕入データより</remarks>
        private Int32 _minSectionCode;

        /// <summary>支払日付</summary>
        /// <remarks>仕入日をセット</remarks>
        private DateTime _paymentDate;

        /// <summary>計上日付</summary>
        /// <remarks>仕入計上日付をセット</remarks>
        private DateTime _addUpADate;

        /// <summary>支払金種コード</summary>
        /// <remarks>UI側で設定</remarks>
        private Int32 _paymentMoneyKindCode;

        /// <summary>支払金種名称</summary>
        /// <remarks>UI側で設定</remarks>
        private string _paymentMoneyKindName = "";

        /// <summary>支払金種区分</summary>
        /// <remarks>UI側で設定</remarks>
        private Int32 _paymentMoneyKindDiv;

        /// <summary>支払計</summary>
        /// <remarks>仕入金額合計をセット</remarks>
        private Int64 _paymentTotal;

        /// <summary>支払金額</summary>
        /// <remarks>仕入金額合計をセット</remarks>
        private Int64 _payment;

        /// <summary>手数料支払額</summary>
        /// <remarks>未設定</remarks>
        private Int64 _feePayment;

        /// <summary>値引支払額</summary>
        /// <remarks>未設定</remarks>
        private Int64 _discountPayment;

        /// <summary>リベート支払額</summary>
        /// <remarks>未設定</remarks>
        private Int64 _rebatePayment;

        /// <summary>自動支払区分</summary>
        /// <remarks>仕入データより</remarks>
        private Int32 _autoPayment;

        /// <summary>クレジット／ローン区分</summary>
        /// <remarks>未設定</remarks>
        private Int32 _creditOrLoanCd;

        /// <summary>クレジット会社コード</summary>
        /// <remarks>未設定</remarks>
        private string _creditCompanyCode = "";

        /// <summary>手形振出日</summary>
        /// <remarks>未設定</remarks>
        private DateTime _draftDrawingDate;

        /// <summary>手形支払期日</summary>
        /// <remarks>未設定</remarks>
        private DateTime _draftPayTimeLimit;

        /// <summary>手形種類</summary>
        /// <remarks>未設定</remarks>
        private Int32 _draftKind;

        /// <summary>手形種類名称</summary>
        /// <remarks>未設定</remarks>
        private string _draftKindName = "";

        /// <summary>手形区分</summary>
        /// <remarks>未設定</remarks>
        private Int32 _draftDivide;

        /// <summary>手形区分名称</summary>
        /// <remarks>未設定</remarks>
        private string _draftDivideName = "";

        /// <summary>手形番号</summary>
        /// <remarks>未設定</remarks>
        private string _draftNo = "";

        /// <summary>赤黒支払連結番号</summary>
        /// <remarks>未設定</remarks>
        private Int32 _debitNoteLinkPayNo;

        /// <summary>支払担当者コード</summary>
        /// <remarks>仕入担当者コードをセット</remarks>
        private string _paymentAgentCode = "";

        /// <summary>支払担当者名称</summary>
        /// <remarks>仕入担当者名称をセット</remarks>
        private string _paymentAgentName = "";

        /// <summary>支払入力者コード</summary>
        /// <remarks>仕入入力者コードをセット</remarks>
        private string _paymentInputAgentCd = "";

        /// <summary>支払入力者名称</summary>
        /// <remarks>仕入入力者名称をセット</remarks>
        private string _paymentInputAgentNm = "";

        /// <summary>伝票摘要</summary>
        /// <remarks>仕入伝票番号をセット</remarks>
        private string _outline = "";

        /// <summary>銀行コード</summary>
        /// <remarks>未設定</remarks>
        private Int32 _bankCode;

        /// <summary>銀行名称</summary>
        /// <remarks>未設定</remarks>
        private string _bankName = "";

        /// <summary>ＥＤＩ送信日</summary>
        /// <remarks>未設定</remarks>
        private DateTime _ediSendDate;

        /// <summary>ＥＤＩ取込日</summary>
        /// <remarks>未設定</remarks>
        private DateTime _ediTakeInDate;


        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>リモート側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>リモート側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>リモート側で設定</value>
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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>リモート側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>リモート側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>リモート側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>リモート側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>リモート側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>仕入データより</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  PaymentSlipNo
        /// <summary>支払伝票番号プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentSlipNo
        {
            get { return _paymentSlipNo; }
            set { _paymentSlipNo = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>仕入形式プロパティ</summary>
        /// <value>仕入データより</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// <value>仕入データより</value>
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

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>仕入データより</value>
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

        /// public propaty name  :  CustomerName
        /// <summary>得意先名称プロパティ</summary>
        /// <value>仕入データより</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  CustomerName2
        /// <summary>得意先名称2プロパティ</summary>
        /// <value>仕入データより</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerName2
        {
            get { return _customerName2; }
            set { _customerName2 = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// <value>仕入データより</value>
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

        /// public propaty name  :  PayeeCode
        /// <summary>支払先コードプロパティ</summary>
        /// <value>仕入データより</value>
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

        /// public propaty name  :  PayeeName
        /// <summary>支払先名称プロパティ</summary>
        /// <value>仕入データより</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeName
        {
            get { return _payeeName; }
            set { _payeeName = value; }
        }

        /// public propaty name  :  PayeeName2
        /// <summary>支払先名称2プロパティ</summary>
        /// <value>仕入データより</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeName2
        {
            get { return _payeeName2; }
            set { _payeeName2 = value; }
        }

        /// public propaty name  :  PayeeSnm
        /// <summary>支払先略称プロパティ</summary>
        /// <value>仕入データより</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
        }

        /// public propaty name  :  PaymentInpSectionCd
        /// <summary>支払入力拠点コードプロパティ</summary>
        /// <value>仕入拠点コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払入力拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentInpSectionCd
        {
            get { return _paymentInpSectionCd; }
            set { _paymentInpSectionCd = value; }
        }

        /// public propaty name  :  AddUpSecCode
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>仕入計上拠点コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  UpdateSecCd
        /// <summary>更新拠点コードプロパティ</summary>
        /// <value>拠点コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateSecCd
        {
            get { return _updateSecCd; }
            set { _updateSecCd = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>部門コードプロパティ</summary>
        /// <value>仕入データより</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }

        /// public propaty name  :  MinSectionCode
        /// <summary>課コードプロパティ</summary>
        /// <value>仕入データより</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MinSectionCode
        {
            get { return _minSectionCode; }
            set { _minSectionCode = value; }
        }

        /// public propaty name  :  PaymentDate
        /// <summary>支払日付プロパティ</summary>
        /// <value>仕入日をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PaymentDate
        {
            get { return _paymentDate; }
            set { _paymentDate = value; }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>計上日付プロパティ</summary>
        /// <value>仕入計上日付をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpADate
        {
            get { return _addUpADate; }
            set { _addUpADate = value; }
        }

        /// public propaty name  :  PaymentMoneyKindCode
        /// <summary>支払金種コードプロパティ</summary>
        /// <value>UI側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentMoneyKindCode
        {
            get { return _paymentMoneyKindCode; }
            set { _paymentMoneyKindCode = value; }
        }

        /// public propaty name  :  PaymentMoneyKindName
        /// <summary>支払金種名称プロパティ</summary>
        /// <value>UI側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentMoneyKindName
        {
            get { return _paymentMoneyKindName; }
            set { _paymentMoneyKindName = value; }
        }

        /// public propaty name  :  PaymentMoneyKindDiv
        /// <summary>支払金種区分プロパティ</summary>
        /// <value>UI側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金種区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentMoneyKindDiv
        {
            get { return _paymentMoneyKindDiv; }
            set { _paymentMoneyKindDiv = value; }
        }

        /// public propaty name  :  PaymentTotal
        /// <summary>支払計プロパティ</summary>
        /// <value>仕入金額合計をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PaymentTotal
        {
            get { return _paymentTotal; }
            set { _paymentTotal = value; }
        }

        /// public propaty name  :  Payment
        /// <summary>支払金額プロパティ</summary>
        /// <value>仕入金額合計をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Payment
        {
            get { return _payment; }
            set { _payment = value; }
        }

        /// public propaty name  :  FeePayment
        /// <summary>手数料支払額プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手数料支払額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 FeePayment
        {
            get { return _feePayment; }
            set { _feePayment = value; }
        }

        /// public propaty name  :  DiscountPayment
        /// <summary>値引支払額プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引支払額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DiscountPayment
        {
            get { return _discountPayment; }
            set { _discountPayment = value; }
        }

        /// public propaty name  :  RebatePayment
        /// <summary>リベート支払額プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   リベート支払額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 RebatePayment
        {
            get { return _rebatePayment; }
            set { _rebatePayment = value; }
        }

        /// public propaty name  :  AutoPayment
        /// <summary>自動支払区分プロパティ</summary>
        /// <value>仕入データより</value>
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

        /// public propaty name  :  CreditOrLoanCd
        /// <summary>クレジット／ローン区分プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   クレジット／ローン区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CreditOrLoanCd
        {
            get { return _creditOrLoanCd; }
            set { _creditOrLoanCd = value; }
        }

        /// public propaty name  :  CreditCompanyCode
        /// <summary>クレジット会社コードプロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   クレジット会社コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreditCompanyCode
        {
            get { return _creditCompanyCode; }
            set { _creditCompanyCode = value; }
        }

        /// public propaty name  :  DraftDrawingDate
        /// <summary>手形振出日プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DraftDrawingDate
        {
            get { return _draftDrawingDate; }
            set { _draftDrawingDate = value; }
        }

        /// public propaty name  :  DraftPayTimeLimit
        /// <summary>手形支払期日プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形支払期日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DraftPayTimeLimit
        {
            get { return _draftPayTimeLimit; }
            set { _draftPayTimeLimit = value; }
        }

        /// public propaty name  :  DraftKind
        /// <summary>手形種類プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形種類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DraftKind
        {
            get { return _draftKind; }
            set { _draftKind = value; }
        }

        /// public propaty name  :  DraftKindName
        /// <summary>手形種類名称プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形種類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DraftKindName
        {
            get { return _draftKindName; }
            set { _draftKindName = value; }
        }

        /// public propaty name  :  DraftDivide
        /// <summary>手形区分プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DraftDivide
        {
            get { return _draftDivide; }
            set { _draftDivide = value; }
        }

        /// public propaty name  :  DraftDivideName
        /// <summary>手形区分名称プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DraftDivideName
        {
            get { return _draftDivideName; }
            set { _draftDivideName = value; }
        }

        /// public propaty name  :  DraftNo
        /// <summary>手形番号プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DraftNo
        {
            get { return _draftNo; }
            set { _draftNo = value; }
        }

        /// public propaty name  :  DebitNoteLinkPayNo
        /// <summary>赤黒支払連結番号プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤黒支払連結番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteLinkPayNo
        {
            get { return _debitNoteLinkPayNo; }
            set { _debitNoteLinkPayNo = value; }
        }

        /// public propaty name  :  PaymentAgentCode
        /// <summary>支払担当者コードプロパティ</summary>
        /// <value>仕入担当者コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentAgentCode
        {
            get { return _paymentAgentCode; }
            set { _paymentAgentCode = value; }
        }

        /// public propaty name  :  PaymentAgentName
        /// <summary>支払担当者名称プロパティ</summary>
        /// <value>仕入担当者名称をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentAgentName
        {
            get { return _paymentAgentName; }
            set { _paymentAgentName = value; }
        }

        /// public propaty name  :  PaymentInputAgentCd
        /// <summary>支払入力者コードプロパティ</summary>
        /// <value>仕入入力者コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentInputAgentCd
        {
            get { return _paymentInputAgentCd; }
            set { _paymentInputAgentCd = value; }
        }

        /// public propaty name  :  PaymentInputAgentNm
        /// <summary>支払入力者名称プロパティ</summary>
        /// <value>仕入入力者名称をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払入力者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentInputAgentNm
        {
            get { return _paymentInputAgentNm; }
            set { _paymentInputAgentNm = value; }
        }

        /// public propaty name  :  Outline
        /// <summary>伝票摘要プロパティ</summary>
        /// <value>仕入伝票番号をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票摘要プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Outline
        {
            get { return _outline; }
            set { _outline = value; }
        }

        /// public propaty name  :  BankCode
        /// <summary>銀行コードプロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BankCode
        {
            get { return _bankCode; }
            set { _bankCode = value; }
        }

        /// public propaty name  :  BankName
        /// <summary>銀行名称プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }

        /// public propaty name  :  EdiSendDate
        /// <summary>ＥＤＩ送信日プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ送信日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime EdiSendDate
        {
            get { return _ediSendDate; }
            set { _ediSendDate = value; }
        }

        /// public propaty name  :  EdiTakeInDate
        /// <summary>ＥＤＩ取込日プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ取込日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime EdiTakeInDate
        {
            get { return _ediTakeInDate; }
            set { _ediTakeInDate = value; }
        }


        /// <summary>
        /// 仕入支払データワーク(IOWriteMASIRPayment)ワークコンストラクタ
        /// </summary>
        /// <returns>IOWriteMASIRPaymentWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRPaymentWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public IOWriteMASIRPaymentWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>IOWriteMASIRPaymentWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   IOWriteMASIRPaymentWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class IOWriteMASIRPaymentWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
    #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRPaymentWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  IOWriteMASIRPaymentWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is IOWriteMASIRPaymentWork || graph is ArrayList || graph is IOWriteMASIRPaymentWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(IOWriteMASIRPaymentWork).FullName));

            if (graph != null && graph is IOWriteMASIRPaymentWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.IOWriteMASIRPaymentWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is IOWriteMASIRPaymentWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((IOWriteMASIRPaymentWork[])graph).Length;
            }
            else if (graph is IOWriteMASIRPaymentWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //赤伝区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //支払伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentSlipNo
            //仕入形式
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //得意先名称2
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //支払先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //支払先名称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName
            //支払先名称2
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName2
            //支払先略称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //支払入力拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInpSectionCd
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //更新拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdateSecCd
            //部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //課コード
            serInfo.MemberInfo.Add(typeof(Int32)); //MinSectionCode
            //支払日付
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentDate
            //計上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //支払金種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentMoneyKindCode
            //支払金種名称
            serInfo.MemberInfo.Add(typeof(string)); //PaymentMoneyKindName
            //支払金種区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentMoneyKindDiv
            //支払計
            serInfo.MemberInfo.Add(typeof(Int64)); //PaymentTotal
            //支払金額
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment
            //手数料支払額
            serInfo.MemberInfo.Add(typeof(Int64)); //FeePayment
            //値引支払額
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountPayment
            //リベート支払額
            serInfo.MemberInfo.Add(typeof(Int64)); //RebatePayment
            //自動支払区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoPayment
            //クレジット／ローン区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CreditOrLoanCd
            //クレジット会社コード
            serInfo.MemberInfo.Add(typeof(string)); //CreditCompanyCode
            //手形振出日
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftDrawingDate
            //手形支払期日
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftPayTimeLimit
            //手形種類
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftKind
            //手形種類名称
            serInfo.MemberInfo.Add(typeof(string)); //DraftKindName
            //手形区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftDivide
            //手形区分名称
            serInfo.MemberInfo.Add(typeof(string)); //DraftDivideName
            //手形番号
            serInfo.MemberInfo.Add(typeof(string)); //DraftNo
            //赤黒支払連結番号
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteLinkPayNo
            //支払担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //PaymentAgentCode
            //支払担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //PaymentAgentName
            //支払入力者コード
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInputAgentCd
            //支払入力者名称
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInputAgentNm
            //伝票摘要
            serInfo.MemberInfo.Add(typeof(string)); //Outline
            //銀行コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BankCode
            //銀行名称
            serInfo.MemberInfo.Add(typeof(string)); //BankName
            //ＥＤＩ送信日
            serInfo.MemberInfo.Add(typeof(Int32)); //EdiSendDate
            //ＥＤＩ取込日
            serInfo.MemberInfo.Add(typeof(Int32)); //EdiTakeInDate


            serInfo.Serialize(writer, serInfo);
            if (graph is IOWriteMASIRPaymentWork)
            {
                IOWriteMASIRPaymentWork temp = (IOWriteMASIRPaymentWork)graph;

                SetIOWriteMASIRPaymentWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is IOWriteMASIRPaymentWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((IOWriteMASIRPaymentWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (IOWriteMASIRPaymentWork temp in lst)
                {
                    SetIOWriteMASIRPaymentWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// IOWriteMASIRPaymentWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 55;

        /// <summary>
        ///  IOWriteMASIRPaymentWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRPaymentWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetIOWriteMASIRPaymentWork(System.IO.BinaryWriter writer, IOWriteMASIRPaymentWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //赤伝区分
            writer.Write(temp.DebitNoteDiv);
            //支払伝票番号
            writer.Write(temp.PaymentSlipNo);
            //仕入形式
            writer.Write(temp.SupplierFormal);
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先名称
            writer.Write(temp.CustomerName);
            //得意先名称2
            writer.Write(temp.CustomerName2);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //支払先コード
            writer.Write(temp.PayeeCode);
            //支払先名称
            writer.Write(temp.PayeeName);
            //支払先名称2
            writer.Write(temp.PayeeName2);
            //支払先略称
            writer.Write(temp.PayeeSnm);
            //支払入力拠点コード
            writer.Write(temp.PaymentInpSectionCd);
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //更新拠点コード
            writer.Write(temp.UpdateSecCd);
            //部門コード
            writer.Write(temp.SubSectionCode);
            //課コード
            writer.Write(temp.MinSectionCode);
            //支払日付
            writer.Write((Int64)temp.PaymentDate.Ticks);
            //計上日付
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //支払金種コード
            writer.Write(temp.PaymentMoneyKindCode);
            //支払金種名称
            writer.Write(temp.PaymentMoneyKindName);
            //支払金種区分
            writer.Write(temp.PaymentMoneyKindDiv);
            //支払計
            writer.Write(temp.PaymentTotal);
            //支払金額
            writer.Write(temp.Payment);
            //手数料支払額
            writer.Write(temp.FeePayment);
            //値引支払額
            writer.Write(temp.DiscountPayment);
            //リベート支払額
            writer.Write(temp.RebatePayment);
            //自動支払区分
            writer.Write(temp.AutoPayment);
            //クレジット／ローン区分
            writer.Write(temp.CreditOrLoanCd);
            //クレジット会社コード
            writer.Write(temp.CreditCompanyCode);
            //手形振出日
            writer.Write((Int64)temp.DraftDrawingDate.Ticks);
            //手形支払期日
            writer.Write((Int64)temp.DraftPayTimeLimit.Ticks);
            //手形種類
            writer.Write(temp.DraftKind);
            //手形種類名称
            writer.Write(temp.DraftKindName);
            //手形区分
            writer.Write(temp.DraftDivide);
            //手形区分名称
            writer.Write(temp.DraftDivideName);
            //手形番号
            writer.Write(temp.DraftNo);
            //赤黒支払連結番号
            writer.Write(temp.DebitNoteLinkPayNo);
            //支払担当者コード
            writer.Write(temp.PaymentAgentCode);
            //支払担当者名称
            writer.Write(temp.PaymentAgentName);
            //支払入力者コード
            writer.Write(temp.PaymentInputAgentCd);
            //支払入力者名称
            writer.Write(temp.PaymentInputAgentNm);
            //伝票摘要
            writer.Write(temp.Outline);
            //銀行コード
            writer.Write(temp.BankCode);
            //銀行名称
            writer.Write(temp.BankName);
            //ＥＤＩ送信日
            writer.Write((Int64)temp.EdiSendDate.Ticks);
            //ＥＤＩ取込日
            writer.Write((Int64)temp.EdiTakeInDate.Ticks);

        }

        /// <summary>
        ///  IOWriteMASIRPaymentWorkインスタンス取得
        /// </summary>
        /// <returns>IOWriteMASIRPaymentWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRPaymentWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private IOWriteMASIRPaymentWork GetIOWriteMASIRPaymentWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            IOWriteMASIRPaymentWork temp = new IOWriteMASIRPaymentWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //赤伝区分
            temp.DebitNoteDiv = reader.ReadInt32();
            //支払伝票番号
            temp.PaymentSlipNo = reader.ReadInt32();
            //仕入形式
            temp.SupplierFormal = reader.ReadInt32();
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先名称
            temp.CustomerName = reader.ReadString();
            //得意先名称2
            temp.CustomerName2 = reader.ReadString();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //支払先コード
            temp.PayeeCode = reader.ReadInt32();
            //支払先名称
            temp.PayeeName = reader.ReadString();
            //支払先名称2
            temp.PayeeName2 = reader.ReadString();
            //支払先略称
            temp.PayeeSnm = reader.ReadString();
            //支払入力拠点コード
            temp.PaymentInpSectionCd = reader.ReadString();
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //更新拠点コード
            temp.UpdateSecCd = reader.ReadString();
            //部門コード
            temp.SubSectionCode = reader.ReadInt32();
            //課コード
            temp.MinSectionCode = reader.ReadInt32();
            //支払日付
            temp.PaymentDate = new DateTime(reader.ReadInt64());
            //計上日付
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //支払金種コード
            temp.PaymentMoneyKindCode = reader.ReadInt32();
            //支払金種名称
            temp.PaymentMoneyKindName = reader.ReadString();
            //支払金種区分
            temp.PaymentMoneyKindDiv = reader.ReadInt32();
            //支払計
            temp.PaymentTotal = reader.ReadInt64();
            //支払金額
            temp.Payment = reader.ReadInt64();
            //手数料支払額
            temp.FeePayment = reader.ReadInt64();
            //値引支払額
            temp.DiscountPayment = reader.ReadInt64();
            //リベート支払額
            temp.RebatePayment = reader.ReadInt64();
            //自動支払区分
            temp.AutoPayment = reader.ReadInt32();
            //クレジット／ローン区分
            temp.CreditOrLoanCd = reader.ReadInt32();
            //クレジット会社コード
            temp.CreditCompanyCode = reader.ReadString();
            //手形振出日
            temp.DraftDrawingDate = new DateTime(reader.ReadInt64());
            //手形支払期日
            temp.DraftPayTimeLimit = new DateTime(reader.ReadInt64());
            //手形種類
            temp.DraftKind = reader.ReadInt32();
            //手形種類名称
            temp.DraftKindName = reader.ReadString();
            //手形区分
            temp.DraftDivide = reader.ReadInt32();
            //手形区分名称
            temp.DraftDivideName = reader.ReadString();
            //手形番号
            temp.DraftNo = reader.ReadString();
            //赤黒支払連結番号
            temp.DebitNoteLinkPayNo = reader.ReadInt32();
            //支払担当者コード
            temp.PaymentAgentCode = reader.ReadString();
            //支払担当者名称
            temp.PaymentAgentName = reader.ReadString();
            //支払入力者コード
            temp.PaymentInputAgentCd = reader.ReadString();
            //支払入力者名称
            temp.PaymentInputAgentNm = reader.ReadString();
            //伝票摘要
            temp.Outline = reader.ReadString();
            //銀行コード
            temp.BankCode = reader.ReadInt32();
            //銀行名称
            temp.BankName = reader.ReadString();
            //ＥＤＩ送信日
            temp.EdiSendDate = new DateTime(reader.ReadInt64());
            //ＥＤＩ取込日
            temp.EdiTakeInDate = new DateTime(reader.ReadInt64());


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>IOWriteMASIRPaymentWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRPaymentWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                IOWriteMASIRPaymentWork temp = GetIOWriteMASIRPaymentWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (IOWriteMASIRPaymentWork[])lst.ToArray(typeof(IOWriteMASIRPaymentWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
# endif
    # endregion --- DEL 2008/08/25 M.Kubota ---<<<

    /// public class name:   IOWriteMASIRPaymentWork
    /// <summary>
    ///                      仕入支払データワーク(IOWriteMASIRPayment)ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入支払データワーク(IOWriteMASIRPayment)ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/08/26  久保田</br>
    /// <br>                 :   仕入先コード 追加</br>
    /// <br>                 :   仕入先名１・２・略称 追加</br>
    /// <br>                 :   リベート支払額 削除</br>
    /// <br>                 :   クレジット／ローン区分・クレジット会社コード 削除</br>
    /// <br>                 :   手形支払期日 </br>
    /// <br>                 :   ＥＤＩ送信日・ＥＤＩ取込日 削除</br>
    /// <br>                 :   得意先コード 削除</br>
    /// <br>                 :   得意先名称・名称２・略称 削除</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class IOWriteMASIRPaymentWork : IFileHeader
    {
        /// <summary>作成日時</summary>
        /// <remarks>リモート側で設定</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>リモート側で設定</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>仕入データより</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>リモート側で設定</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>リモート側で設定</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>リモート側で設定</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>リモート側で設定</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>リモート側で設定</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>赤伝区分</summary>
        /// <remarks>仕入データより</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>支払伝票番号</summary>
        /// <remarks>未設定</remarks>
        private Int32 _paymentSlipNo;

        /// <summary>仕入形式</summary>
        /// <remarks>仕入データより</remarks>
        private Int32 _supplierFormal;

        /// <summary>仕入伝票番号</summary>
        /// <remarks>仕入データより</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>支払先コード</summary>
        /// <remarks>仕入データより</remarks>
        private Int32 _payeeCode;

        /// <summary>支払先名称</summary>
        /// <remarks>UI側で設定</remarks>
        private string _payeeName = "";

        /// <summary>支払先名称2</summary>
        /// <remarks>UI側で設定</remarks>
        private string _payeeName2 = "";

        /// <summary>支払先略称</summary>
        /// <remarks>仕入データより</remarks>
        private string _payeeSnm = "";

        /// <summary>仕入先コード</summary>
        /// <remarks>仕入データより</remarks>
        private Int32 _supplierCd;

        /// <summary>仕入先名1</summary>
        /// <remarks>仕入データより</remarks>
        private string _supplierNm1 = "";

        /// <summary>仕入先名2</summary>
        /// <remarks>仕入データより</remarks>
        private string _supplierNm2 = "";

        /// <summary>仕入先略称</summary>
        /// <remarks>仕入データより</remarks>
        private string _supplierSnm = "";

        /// <summary>支払入力拠点コード</summary>
        /// <remarks>仕入拠点コードをセット</remarks>
        private string _paymentInpSectionCd = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>仕入計上拠点コードをセット</remarks>
        private string _addUpSecCode = "";

        /// <summary>更新拠点コード</summary>
        /// <remarks>拠点コードをセット</remarks>
        private string _updateSecCd = "";

        /// <summary>部門コード</summary>
        /// <remarks>仕入データより</remarks>
        private Int32 _subSectionCode;

        /// <summary>課コード</summary>
        /// <remarks>仕入データより</remarks>
        private Int32 _minSectionCode;

        /// <summary>支払日付</summary>
        /// <remarks>仕入日をセット</remarks>
        private DateTime _paymentDate;

        /// <summary>計上日付</summary>
        /// <remarks>仕入計上日付をセット</remarks>
        private DateTime _addUpADate;

        /// <summary>支払金種コード</summary>
        /// <remarks>UI側で設定</remarks>
        private Int32 _paymentMoneyKindCode;

        /// <summary>支払金種名称</summary>
        /// <remarks>UI側で設定</remarks>
        private string _paymentMoneyKindName = "";

        /// <summary>支払金種区分</summary>
        /// <remarks>UI側で設定</remarks>
        private Int32 _paymentMoneyKindDiv;

        /// <summary>支払計</summary>
        /// <remarks>仕入金額合計をセット</remarks>
        private Int64 _paymentTotal;

        /// <summary>支払金額</summary>
        /// <remarks>仕入金額合計をセット</remarks>
        private Int64 _payment;

        /// <summary>手数料支払額</summary>
        /// <remarks>未設定</remarks>
        private Int64 _feePayment;

        /// <summary>値引支払額</summary>
        /// <remarks>未設定</remarks>
        private Int64 _discountPayment;

        /// <summary>自動支払区分</summary>
        /// <remarks>仕入データより</remarks>
        private Int32 _autoPayment;

        /// <summary>手形振出日</summary>
        /// <remarks>未設定</remarks>
        private DateTime _draftDrawingDate;

        /// <summary>手形種類</summary>
        /// <remarks>未設定</remarks>
        private Int32 _draftKind;

        /// <summary>手形種類名称</summary>
        /// <remarks>未設定</remarks>
        private string _draftKindName = "";

        /// <summary>手形区分</summary>
        /// <remarks>未設定</remarks>
        private Int32 _draftDivide;

        /// <summary>手形区分名称</summary>
        /// <remarks>未設定</remarks>
        private string _draftDivideName = "";

        /// <summary>手形番号</summary>
        /// <remarks>未設定</remarks>
        private string _draftNo = "";

        /// <summary>赤黒支払連結番号</summary>
        /// <remarks>未設定</remarks>
        private Int32 _debitNoteLinkPayNo;

        /// <summary>支払担当者コード</summary>
        /// <remarks>仕入担当者コードをセット</remarks>
        private string _paymentAgentCode = "";

        /// <summary>支払担当者名称</summary>
        /// <remarks>仕入担当者名称をセット</remarks>
        private string _paymentAgentName = "";

        /// <summary>支払入力者コード</summary>
        /// <remarks>仕入入力者コードをセット</remarks>
        private string _paymentInputAgentCd = "";

        /// <summary>支払入力者名称</summary>
        /// <remarks>仕入入力者名称をセット</remarks>
        private string _paymentInputAgentNm = "";

        /// <summary>伝票摘要</summary>
        /// <remarks>仕入伝票番号をセット</remarks>
        private string _outline = "";

        /// <summary>銀行コード</summary>
        /// <remarks>未設定</remarks>
        private Int32 _bankCode;

        /// <summary>銀行名称</summary>
        /// <remarks>未設定</remarks>
        private string _bankName = "";


        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>リモート側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>リモート側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>仕入データより</value>
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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>リモート側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>リモート側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>リモート側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>リモート側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>リモート側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>仕入データより</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  PaymentSlipNo
        /// <summary>支払伝票番号プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentSlipNo
        {
            get { return _paymentSlipNo; }
            set { _paymentSlipNo = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>仕入形式プロパティ</summary>
        /// <value>仕入データより</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// <value>仕入データより</value>
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

        /// public propaty name  :  PayeeCode
        /// <summary>支払先コードプロパティ</summary>
        /// <value>仕入データより</value>
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

        /// public propaty name  :  PayeeName
        /// <summary>支払先名称プロパティ</summary>
        /// <value>UI側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeName
        {
            get { return _payeeName; }
            set { _payeeName = value; }
        }

        /// public propaty name  :  PayeeName2
        /// <summary>支払先名称2プロパティ</summary>
        /// <value>UI側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeName2
        {
            get { return _payeeName2; }
            set { _payeeName2 = value; }
        }

        /// public propaty name  :  PayeeSnm
        /// <summary>支払先略称プロパティ</summary>
        /// <value>仕入データより</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>仕入データより</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierNm1
        /// <summary>仕入先名1プロパティ</summary>
        /// <value>仕入データより</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }

        /// public propaty name  :  SupplierNm2
        /// <summary>仕入先名2プロパティ</summary>
        /// <value>仕入データより</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm2
        {
            get { return _supplierNm2; }
            set { _supplierNm2 = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// <value>仕入データより</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  PaymentInpSectionCd
        /// <summary>支払入力拠点コードプロパティ</summary>
        /// <value>仕入拠点コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払入力拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentInpSectionCd
        {
            get { return _paymentInpSectionCd; }
            set { _paymentInpSectionCd = value; }
        }

        /// public propaty name  :  AddUpSecCode
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>仕入計上拠点コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  UpdateSecCd
        /// <summary>更新拠点コードプロパティ</summary>
        /// <value>拠点コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateSecCd
        {
            get { return _updateSecCd; }
            set { _updateSecCd = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>部門コードプロパティ</summary>
        /// <value>仕入データより</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }

        /// public propaty name  :  MinSectionCode
        /// <summary>課コードプロパティ</summary>
        /// <value>仕入データより</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MinSectionCode
        {
            get { return _minSectionCode; }
            set { _minSectionCode = value; }
        }

        /// public propaty name  :  PaymentDate
        /// <summary>支払日付プロパティ</summary>
        /// <value>仕入日をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PaymentDate
        {
            get { return _paymentDate; }
            set { _paymentDate = value; }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>計上日付プロパティ</summary>
        /// <value>仕入計上日付をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpADate
        {
            get { return _addUpADate; }
            set { _addUpADate = value; }
        }

        /// public propaty name  :  PaymentMoneyKindCode
        /// <summary>支払金種コードプロパティ</summary>
        /// <value>UI側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentMoneyKindCode
        {
            get { return _paymentMoneyKindCode; }
            set { _paymentMoneyKindCode = value; }
        }

        /// public propaty name  :  PaymentMoneyKindName
        /// <summary>支払金種名称プロパティ</summary>
        /// <value>UI側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentMoneyKindName
        {
            get { return _paymentMoneyKindName; }
            set { _paymentMoneyKindName = value; }
        }

        /// public propaty name  :  PaymentMoneyKindDiv
        /// <summary>支払金種区分プロパティ</summary>
        /// <value>UI側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金種区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentMoneyKindDiv
        {
            get { return _paymentMoneyKindDiv; }
            set { _paymentMoneyKindDiv = value; }
        }

        /// public propaty name  :  PaymentTotal
        /// <summary>支払計プロパティ</summary>
        /// <value>仕入金額合計をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PaymentTotal
        {
            get { return _paymentTotal; }
            set { _paymentTotal = value; }
        }

        /// public propaty name  :  Payment
        /// <summary>支払金額プロパティ</summary>
        /// <value>仕入金額合計をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Payment
        {
            get { return _payment; }
            set { _payment = value; }
        }

        /// public propaty name  :  FeePayment
        /// <summary>手数料支払額プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手数料支払額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 FeePayment
        {
            get { return _feePayment; }
            set { _feePayment = value; }
        }

        /// public propaty name  :  DiscountPayment
        /// <summary>値引支払額プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引支払額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DiscountPayment
        {
            get { return _discountPayment; }
            set { _discountPayment = value; }
        }

        /// public propaty name  :  AutoPayment
        /// <summary>自動支払区分プロパティ</summary>
        /// <value>仕入データより</value>
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

        /// public propaty name  :  DraftDrawingDate
        /// <summary>手形振出日プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DraftDrawingDate
        {
            get { return _draftDrawingDate; }
            set { _draftDrawingDate = value; }
        }

        /// public propaty name  :  DraftKind
        /// <summary>手形種類プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形種類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DraftKind
        {
            get { return _draftKind; }
            set { _draftKind = value; }
        }

        /// public propaty name  :  DraftKindName
        /// <summary>手形種類名称プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形種類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DraftKindName
        {
            get { return _draftKindName; }
            set { _draftKindName = value; }
        }

        /// public propaty name  :  DraftDivide
        /// <summary>手形区分プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DraftDivide
        {
            get { return _draftDivide; }
            set { _draftDivide = value; }
        }

        /// public propaty name  :  DraftDivideName
        /// <summary>手形区分名称プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DraftDivideName
        {
            get { return _draftDivideName; }
            set { _draftDivideName = value; }
        }

        /// public propaty name  :  DraftNo
        /// <summary>手形番号プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DraftNo
        {
            get { return _draftNo; }
            set { _draftNo = value; }
        }

        /// public propaty name  :  DebitNoteLinkPayNo
        /// <summary>赤黒支払連結番号プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤黒支払連結番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteLinkPayNo
        {
            get { return _debitNoteLinkPayNo; }
            set { _debitNoteLinkPayNo = value; }
        }

        /// public propaty name  :  PaymentAgentCode
        /// <summary>支払担当者コードプロパティ</summary>
        /// <value>仕入担当者コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentAgentCode
        {
            get { return _paymentAgentCode; }
            set { _paymentAgentCode = value; }
        }

        /// public propaty name  :  PaymentAgentName
        /// <summary>支払担当者名称プロパティ</summary>
        /// <value>仕入担当者名称をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentAgentName
        {
            get { return _paymentAgentName; }
            set { _paymentAgentName = value; }
        }

        /// public propaty name  :  PaymentInputAgentCd
        /// <summary>支払入力者コードプロパティ</summary>
        /// <value>仕入入力者コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentInputAgentCd
        {
            get { return _paymentInputAgentCd; }
            set { _paymentInputAgentCd = value; }
        }

        /// public propaty name  :  PaymentInputAgentNm
        /// <summary>支払入力者名称プロパティ</summary>
        /// <value>仕入入力者名称をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払入力者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentInputAgentNm
        {
            get { return _paymentInputAgentNm; }
            set { _paymentInputAgentNm = value; }
        }

        /// public propaty name  :  Outline
        /// <summary>伝票摘要プロパティ</summary>
        /// <value>仕入伝票番号をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票摘要プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Outline
        {
            get { return _outline; }
            set { _outline = value; }
        }

        /// public propaty name  :  BankCode
        /// <summary>銀行コードプロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BankCode
        {
            get { return _bankCode; }
            set { _bankCode = value; }
        }

        /// public propaty name  :  BankName
        /// <summary>銀行名称プロパティ</summary>
        /// <value>未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }


        /// <summary>
        /// 仕入支払データワーク(IOWriteMASIRPayment)ワークコンストラクタ
        /// </summary>
        /// <returns>IOWriteMASIRPaymentWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRPaymentWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public IOWriteMASIRPaymentWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>IOWriteMASIRPaymentWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   IOWriteMASIRPaymentWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class IOWriteMASIRPaymentWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRPaymentWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  IOWriteMASIRPaymentWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is IOWriteMASIRPaymentWork || graph is ArrayList || graph is IOWriteMASIRPaymentWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(IOWriteMASIRPaymentWork).FullName));

            if (graph != null && graph is IOWriteMASIRPaymentWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.IOWriteMASIRPaymentWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is IOWriteMASIRPaymentWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((IOWriteMASIRPaymentWork[])graph).Length;
            }
            else if (graph is IOWriteMASIRPaymentWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //赤伝区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //支払伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentSlipNo
            //仕入形式
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //支払先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //支払先名称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName
            //支払先名称2
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName2
            //支払先略称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先名1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //仕入先名2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //支払入力拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInpSectionCd
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //更新拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdateSecCd
            //部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //課コード
            serInfo.MemberInfo.Add(typeof(Int32)); //MinSectionCode
            //支払日付
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentDate
            //計上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //支払金種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentMoneyKindCode
            //支払金種名称
            serInfo.MemberInfo.Add(typeof(string)); //PaymentMoneyKindName
            //支払金種区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentMoneyKindDiv
            //支払計
            serInfo.MemberInfo.Add(typeof(Int64)); //PaymentTotal
            //支払金額
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment
            //手数料支払額
            serInfo.MemberInfo.Add(typeof(Int64)); //FeePayment
            //値引支払額
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountPayment
            //自動支払区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoPayment
            //手形振出日
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftDrawingDate
            //手形種類
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftKind
            //手形種類名称
            serInfo.MemberInfo.Add(typeof(string)); //DraftKindName
            //手形区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftDivide
            //手形区分名称
            serInfo.MemberInfo.Add(typeof(string)); //DraftDivideName
            //手形番号
            serInfo.MemberInfo.Add(typeof(string)); //DraftNo
            //赤黒支払連結番号
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteLinkPayNo
            //支払担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //PaymentAgentCode
            //支払担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //PaymentAgentName
            //支払入力者コード
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInputAgentCd
            //支払入力者名称
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInputAgentNm
            //伝票摘要
            serInfo.MemberInfo.Add(typeof(string)); //Outline
            //銀行コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BankCode
            //銀行名称
            serInfo.MemberInfo.Add(typeof(string)); //BankName


            serInfo.Serialize(writer, serInfo);
            if (graph is IOWriteMASIRPaymentWork)
            {
                IOWriteMASIRPaymentWork temp = (IOWriteMASIRPaymentWork)graph;

                SetIOWriteMASIRPaymentWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is IOWriteMASIRPaymentWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((IOWriteMASIRPaymentWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (IOWriteMASIRPaymentWork temp in lst)
                {
                    SetIOWriteMASIRPaymentWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// IOWriteMASIRPaymentWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 49;

        /// <summary>
        ///  IOWriteMASIRPaymentWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRPaymentWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetIOWriteMASIRPaymentWork(System.IO.BinaryWriter writer, IOWriteMASIRPaymentWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //赤伝区分
            writer.Write(temp.DebitNoteDiv);
            //支払伝票番号
            writer.Write(temp.PaymentSlipNo);
            //仕入形式
            writer.Write(temp.SupplierFormal);
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //支払先コード
            writer.Write(temp.PayeeCode);
            //支払先名称
            writer.Write(temp.PayeeName);
            //支払先名称2
            writer.Write(temp.PayeeName2);
            //支払先略称
            writer.Write(temp.PayeeSnm);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先名1
            writer.Write(temp.SupplierNm1);
            //仕入先名2
            writer.Write(temp.SupplierNm2);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //支払入力拠点コード
            writer.Write(temp.PaymentInpSectionCd);
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //更新拠点コード
            writer.Write(temp.UpdateSecCd);
            //部門コード
            writer.Write(temp.SubSectionCode);
            //課コード
            writer.Write(temp.MinSectionCode);
            //支払日付
            writer.Write((Int64)temp.PaymentDate.Ticks);
            //計上日付
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //支払金種コード
            writer.Write(temp.PaymentMoneyKindCode);
            //支払金種名称
            writer.Write(temp.PaymentMoneyKindName);
            //支払金種区分
            writer.Write(temp.PaymentMoneyKindDiv);
            //支払計
            writer.Write(temp.PaymentTotal);
            //支払金額
            writer.Write(temp.Payment);
            //手数料支払額
            writer.Write(temp.FeePayment);
            //値引支払額
            writer.Write(temp.DiscountPayment);
            //自動支払区分
            writer.Write(temp.AutoPayment);
            //手形振出日
            writer.Write((Int64)temp.DraftDrawingDate.Ticks);
            //手形種類
            writer.Write(temp.DraftKind);
            //手形種類名称
            writer.Write(temp.DraftKindName);
            //手形区分
            writer.Write(temp.DraftDivide);
            //手形区分名称
            writer.Write(temp.DraftDivideName);
            //手形番号
            writer.Write(temp.DraftNo);
            //赤黒支払連結番号
            writer.Write(temp.DebitNoteLinkPayNo);
            //支払担当者コード
            writer.Write(temp.PaymentAgentCode);
            //支払担当者名称
            writer.Write(temp.PaymentAgentName);
            //支払入力者コード
            writer.Write(temp.PaymentInputAgentCd);
            //支払入力者名称
            writer.Write(temp.PaymentInputAgentNm);
            //伝票摘要
            writer.Write(temp.Outline);
            //銀行コード
            writer.Write(temp.BankCode);
            //銀行名称
            writer.Write(temp.BankName);

        }

        /// <summary>
        ///  IOWriteMASIRPaymentWorkインスタンス取得
        /// </summary>
        /// <returns>IOWriteMASIRPaymentWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRPaymentWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private IOWriteMASIRPaymentWork GetIOWriteMASIRPaymentWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            IOWriteMASIRPaymentWork temp = new IOWriteMASIRPaymentWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //赤伝区分
            temp.DebitNoteDiv = reader.ReadInt32();
            //支払伝票番号
            temp.PaymentSlipNo = reader.ReadInt32();
            //仕入形式
            temp.SupplierFormal = reader.ReadInt32();
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //支払先コード
            temp.PayeeCode = reader.ReadInt32();
            //支払先名称
            temp.PayeeName = reader.ReadString();
            //支払先名称2
            temp.PayeeName2 = reader.ReadString();
            //支払先略称
            temp.PayeeSnm = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先名1
            temp.SupplierNm1 = reader.ReadString();
            //仕入先名2
            temp.SupplierNm2 = reader.ReadString();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //支払入力拠点コード
            temp.PaymentInpSectionCd = reader.ReadString();
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //更新拠点コード
            temp.UpdateSecCd = reader.ReadString();
            //部門コード
            temp.SubSectionCode = reader.ReadInt32();
            //課コード
            temp.MinSectionCode = reader.ReadInt32();
            //支払日付
            temp.PaymentDate = new DateTime(reader.ReadInt64());
            //計上日付
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //支払金種コード
            temp.PaymentMoneyKindCode = reader.ReadInt32();
            //支払金種名称
            temp.PaymentMoneyKindName = reader.ReadString();
            //支払金種区分
            temp.PaymentMoneyKindDiv = reader.ReadInt32();
            //支払計
            temp.PaymentTotal = reader.ReadInt64();
            //支払金額
            temp.Payment = reader.ReadInt64();
            //手数料支払額
            temp.FeePayment = reader.ReadInt64();
            //値引支払額
            temp.DiscountPayment = reader.ReadInt64();
            //自動支払区分
            temp.AutoPayment = reader.ReadInt32();
            //手形振出日
            temp.DraftDrawingDate = new DateTime(reader.ReadInt64());
            //手形種類
            temp.DraftKind = reader.ReadInt32();
            //手形種類名称
            temp.DraftKindName = reader.ReadString();
            //手形区分
            temp.DraftDivide = reader.ReadInt32();
            //手形区分名称
            temp.DraftDivideName = reader.ReadString();
            //手形番号
            temp.DraftNo = reader.ReadString();
            //赤黒支払連結番号
            temp.DebitNoteLinkPayNo = reader.ReadInt32();
            //支払担当者コード
            temp.PaymentAgentCode = reader.ReadString();
            //支払担当者名称
            temp.PaymentAgentName = reader.ReadString();
            //支払入力者コード
            temp.PaymentInputAgentCd = reader.ReadString();
            //支払入力者名称
            temp.PaymentInputAgentNm = reader.ReadString();
            //伝票摘要
            temp.Outline = reader.ReadString();
            //銀行コード
            temp.BankCode = reader.ReadInt32();
            //銀行名称
            temp.BankName = reader.ReadString();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>IOWriteMASIRPaymentWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRPaymentWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                IOWriteMASIRPaymentWork temp = GetIOWriteMASIRPaymentWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (IOWriteMASIRPaymentWork[])lst.ToArray(typeof(IOWriteMASIRPaymentWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
