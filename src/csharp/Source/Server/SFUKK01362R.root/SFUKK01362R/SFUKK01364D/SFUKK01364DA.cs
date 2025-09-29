using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    # region --- DEL 2008/06/26 M.Kubota ---
#if false
    /// public class name:   CreateDepsitMainWork
	/// <summary>
	///                      入金更新データパラメータ(受注指定型)クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   入金更新データパラメータ(受注指定型)クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/1/23</br>
	/// <br>Genarated Date   :   2007/05/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2007/5/14  木村 武正</br>
    /// <br>                 :   サービス伝票区分を追加</br>
    /// <br>Update Note      :   2007/10/11  山田 明友</br>
    /// <br>                 :   サービス伝票区分・受注番号を削除</br>
    /// <br>                 :   追加パラメータ多数</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class CreateDepsitMainWork
	{
		/// <summary>伝票管理番号</summary>
		private string _slipMngNo = "";

		/// <summary>受注ステータス</summary>
		/// <remarks>10:見積,11:見積キャンセル,20:受注,21:受注キャンセル,30:売上</remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>入金金種コード</summary>
		private Int32 _depositKindCode;

		/// <summary>入金金種名称</summary>
		private string _depositKindName = "";

		/// <summary>入金金種区分</summary>
		private Int32 _depositKindDivCd;

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>得意先名称</summary>
		private string _customerName = "";

		/// <summary>得意先名称2</summary>
		private string _customerName2 = "";

		/// <summary>自動入金区分</summary>
		/// <remarks>0:通常入金,1:自動入金</remarks>
		private Int32 _autoDepositCd;

		/// <summary>預り金区分</summary>
		/// <remarks>0:通常入金,1:預り金入金</remarks>
		private Int32 _depositCd;

		/// <summary>伝票摘要</summary>
		/// <remarks>車販の場合、摘要+注文書№+管理番号を格納</remarks>
		private string _outline = "";

		/// <summary>入金入力拠点コード</summary>
		/// <remarks>入金入力した拠点コード</remarks>
		private string _inputDepositSecCd = "";

		/// <summary>入金日付</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _depositDate;

		/// <summary>計上拠点コード</summary>
		/// <remarks>集計の対象となっている拠点コード</remarks>
		private string _addUpSecCode = "";

		/// <summary>計上日付</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _addUpADate;

		/// <summary>更新拠点コード</summary>
		/// <remarks>文字型 データの登録更新拠点</remarks>
		private string _updateSecCd = "";

		/// <summary>入金担当者コード</summary>
		private string _depositAgentCode = "";

		/// <summary>入金担当者名称</summary>
		private string _depositAgentNm = "";

		/// <summary>入金計</summary>
		private Int64 _depositTotal;

		/// <summary>入金金額</summary>
		/// <remarks>値引・手数料を除いた額</remarks>
		private Int64 _deposit;

		/// <summary>手数料入金額</summary>
		private Int64 _feeDeposit;

		/// <summary>値引入金額</summary>
		private Int64 _discountDeposit;

		/// <summary>リベート入金額</summary>
		private Int64 _rebateDeposit;

		/// <summary>クレジット／ローン区分</summary>
		/// <remarks>1:クレジット,2:ローン</remarks>
		private Int32 _creditOrLoanCd;

		/// <summary>クレジット会社コード</summary>
		private string _creditCompanyCode = "";

		/// <summary>手形振出日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _draftDrawingDate;

		/// <summary>手形支払期日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _draftPayTimeLimit;

		/// <summary>売上伝票番号</summary>
		/// <remarks>預り金、自動入金時の売上伝票</remarks>
		private string _salesSlipNum = "";

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>課コード</summary>
        private Int32 _minSectionCode;

        /// <summary>手形種類</summary>
        private Int32 _draftKind;

        /// <summary>手形種類名称</summary>
        /// <remarks>約束、為替、小切手</remarks>
        private string _draftKindName = "";

        /// <summary>手形区分</summary>
        private Int32 _draftDivide;

        /// <summary>手形区分名称</summary>
        /// <remarks>自振、廻し</remarks>
        private string _draftDivideName = "";

        /// <summary>手形番号</summary>
        private string _draftNo = "";

        /// <summary>入金入力者コード</summary>
        private string _depositInputAgentCd = "";

        /// <summary>入金入力者名称</summary>
        private string _depositInputAgentNm = "";

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>請求先コード</summary>
        /// <remarks>請求先得意先</remarks>
        private Int32 _claimCode;

        /// <summary>請求先名称</summary>
        /// <remarks>請求得意先名称</remarks>
        private string _claimName = "";

        /// <summary>請求先名称2</summary>
        /// <remarks>請求得意先名称２</remarks>
        private string _claimName2 = "";

        /// <summary>請求先略称</summary>
        private string _claimSnm = "";

        /// <summary>銀行コード</summary>
        /// <remarks>郵便局：9900</remarks>
        private Int32 _bankCode;

        /// <summary>銀行名称</summary>
        private string _bankName = "";

        /// <summary>ＥＤＩ送信日</summary>
        private DateTime _ediSendDate;

        /// <summary>ＥＤＩ取込日</summary>
        private DateTime _ediTakeInDate;


		/// public propaty name  :  SlipMngNo
		/// <summary>伝票管理番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票管理番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipMngNo
		{
			get{return _slipMngNo;}
			set{_slipMngNo = value;}
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>受注ステータスプロパティ</summary>
		/// <value>10:見積,11:見積キャンセル,20:受注,21:受注キャンセル,30:売上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注ステータスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  DepositKindCode
		/// <summary>入金金種コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金金種コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DepositKindCode
		{
			get{return _depositKindCode;}
			set{_depositKindCode = value;}
		}

		/// public propaty name  :  DepositKindName
		/// <summary>入金金種名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金金種名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DepositKindName
		{
			get{return _depositKindName;}
			set{_depositKindName = value;}
		}

		/// public propaty name  :  DepositKindDivCd
		/// <summary>入金金種区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金金種区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DepositKindDivCd
		{
			get{return _depositKindDivCd;}
			set{_depositKindDivCd = value;}
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
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  CustomerName
		/// <summary>得意先名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerName
		{
			get{return _customerName;}
			set{_customerName = value;}
		}

		/// public propaty name  :  CustomerName2
		/// <summary>得意先名称2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先名称2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerName2
		{
			get{return _customerName2;}
			set{_customerName2 = value;}
		}

		/// public propaty name  :  AutoDepositCd
		/// <summary>自動入金区分プロパティ</summary>
		/// <value>0:通常入金,1:自動入金</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自動入金区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AutoDepositCd
		{
			get{return _autoDepositCd;}
			set{_autoDepositCd = value;}
		}

		/// public propaty name  :  DepositCd
		/// <summary>預り金区分プロパティ</summary>
		/// <value>0:通常入金,1:預り金入金</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   預り金区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DepositCd
		{
			get{return _depositCd;}
			set{_depositCd = value;}
		}

		/// public propaty name  :  Outline
		/// <summary>伝票摘要プロパティ</summary>
		/// <value>車販の場合、摘要+注文書№+管理番号を格納</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票摘要プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Outline
		{
			get{return _outline;}
			set{_outline = value;}
		}

		/// public propaty name  :  InputDepositSecCd
		/// <summary>入金入力拠点コードプロパティ</summary>
		/// <value>入金入力した拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金入力拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InputDepositSecCd
		{
			get{return _inputDepositSecCd;}
			set{_inputDepositSecCd = value;}
		}

		/// public propaty name  :  DepositDate
		/// <summary>入金日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime DepositDate
		{
			get{return _depositDate;}
			set{_depositDate = value;}
		}

		/// public propaty name  :  AddUpSecCode
		/// <summary>計上拠点コードプロパティ</summary>
		/// <value>集計の対象となっている拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpSecCode
		{
			get{return _addUpSecCode;}
			set{_addUpSecCode = value;}
		}

		/// public propaty name  :  AddUpADate
		/// <summary>計上日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpADate
		{
			get{return _addUpADate;}
			set{_addUpADate = value;}
		}

		/// public propaty name  :  UpdateSecCd
		/// <summary>更新拠点コードプロパティ</summary>
		/// <value>文字型 データの登録更新拠点</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateSecCd
		{
			get{return _updateSecCd;}
			set{_updateSecCd = value;}
		}

		/// public propaty name  :  DepositAgentCode
		/// <summary>入金担当者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金担当者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DepositAgentCode
		{
			get{return _depositAgentCode;}
			set{_depositAgentCode = value;}
		}

		/// public propaty name  :  DepositAgentNm
		/// <summary>入金担当者名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金担当者名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DepositAgentNm
		{
			get{return _depositAgentNm;}
			set{_depositAgentNm = value;}
		}

		/// public propaty name  :  DepositTotal
		/// <summary>入金計プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 DepositTotal
		{
			get{return _depositTotal;}
			set{_depositTotal = value;}
		}

		/// public propaty name  :  Deposit
		/// <summary>入金金額プロパティ</summary>
		/// <value>値引・手数料を除いた額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 Deposit
		{
			get{return _deposit;}
			set{_deposit = value;}
		}

		/// public propaty name  :  FeeDeposit
		/// <summary>手数料入金額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   手数料入金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 FeeDeposit
		{
			get{return _feeDeposit;}
			set{_feeDeposit = value;}
		}

		/// public propaty name  :  DiscountDeposit
		/// <summary>値引入金額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   値引入金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 DiscountDeposit
		{
			get{return _discountDeposit;}
			set{_discountDeposit = value;}
		}

		/// public propaty name  :  RebateDeposit
		/// <summary>リベート入金額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   リベート入金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 RebateDeposit
		{
			get{return _rebateDeposit;}
			set{_rebateDeposit = value;}
		}

		/// public propaty name  :  CreditOrLoanCd
		/// <summary>クレジット／ローン区分プロパティ</summary>
		/// <value>1:クレジット,2:ローン</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   クレジット／ローン区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CreditOrLoanCd
		{
			get{return _creditOrLoanCd;}
			set{_creditOrLoanCd = value;}
		}

		/// public propaty name  :  CreditCompanyCode
		/// <summary>クレジット会社コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   クレジット会社コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreditCompanyCode
		{
			get{return _creditCompanyCode;}
			set{_creditCompanyCode = value;}
		}

		/// public propaty name  :  DraftDrawingDate
		/// <summary>手形振出日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   手形振出日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime DraftDrawingDate
		{
			get{return _draftDrawingDate;}
			set{_draftDrawingDate = value;}
		}

		/// public propaty name  :  DraftPayTimeLimit
		/// <summary>手形支払期日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   手形支払期日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime DraftPayTimeLimit
		{
			get{return _draftPayTimeLimit;}
			set{_draftPayTimeLimit = value;}
		}

		/// public propaty name  :  SalesSlipNum
		/// <summary>売上伝票番号プロパティ</summary>
		/// <value>預り金、自動入金時の売上伝票</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesSlipNum
		{
			get{return _salesSlipNum;}
			set{_salesSlipNum = value;}
		}

        /// public propaty name  :  SubSectionCode
        /// <summary>部門コードプロパティ</summary>
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

        /// public propaty name  :  DraftKind
        /// <summary>手形種類プロパティ</summary>
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
        /// <value>約束、為替、小切手</value>
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
        /// <value>自振、廻し</value>
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

        /// public propaty name  :  DepositInputAgentCd
        /// <summary>入金入力者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositInputAgentCd
        {
            get { return _depositInputAgentCd; }
            set { _depositInputAgentCd = value; }
        }

        /// public propaty name  :  DepositInputAgentNm
        /// <summary>入金入力者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金入力者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositInputAgentNm
        {
            get { return _depositInputAgentNm; }
            set { _depositInputAgentNm = value; }
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

        /// public propaty name  :  ClaimCode
        /// <summary>請求先コードプロパティ</summary>
        /// <value>請求先得意先</value>
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

        /// public propaty name  :  ClaimName
        /// <summary>請求先名称プロパティ</summary>
        /// <value>請求得意先名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimName
        {
            get { return _claimName; }
            set { _claimName = value; }
        }

        /// public propaty name  :  ClaimName2
        /// <summary>請求先名称2プロパティ</summary>
        /// <value>請求得意先名称２</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimName2
        {
            get { return _claimName2; }
            set { _claimName2 = value; }
        }

        /// public propaty name  :  ClaimSnm
        /// <summary>請求先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimSnm
        {
            get { return _claimSnm; }
            set { _claimSnm = value; }
        }

        /// public propaty name  :  BankCode
        /// <summary>銀行コードプロパティ</summary>
        /// <value>郵便局：9900</value>
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
		/// 入金更新データパラメータ(受注指定型)クラスワークコンストラクタ
		/// </summary>
		/// <returns>CreateDepsitMainWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CreateDepsitMainWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CreateDepsitMainWork()
		{
		}

	}
# endif        
    # endregion

    /// public class name:   CreateDepsitMainWork
    /// <summary>
    ///                      入金更新データ(売上指定型)ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   入金更新データ(売上指定型)ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/07/02</br>
    /// <br>Genarated Date   :   2008/08/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/08/05  久保田</br>
    /// <br>                 :   "預り金区分"を削除</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CreateDepsitMainWork
    {
        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上伝票番号</summary>
        private string _salesSlipNum = "";

        /// <summary>入金入力拠点コード</summary>
        /// <remarks>入金入力した拠点コード</remarks>
        private string _inputDepositSecCd = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>更新拠点コード</summary>
        /// <remarks>文字型 データの登録更新拠点</remarks>
        private string _updateSecCd = "";

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>入力日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inputDay;

        /// <summary>入金日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _depositDate;

        /// <summary>計上日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpADate;

        /// <summary>入金計</summary>
        /// <remarks>入金金額＋手数料支払額＋値引支払額</remarks>
        private Int64 _depositTotal;

        /// <summary>入金金額</summary>
        /// <remarks>値引・手数料を除いた額</remarks>
        private Int64 _deposit;

        /// <summary>手数料入金額</summary>
        private Int64 _feeDeposit;

        /// <summary>値引入金額</summary>
        private Int64 _discountDeposit;

        /// <summary>自動入金区分</summary>
        /// <remarks>0:通常入金,1:自動入金</remarks>
        private Int32 _autoDepositCd;

        /// <summary>手形振出日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _draftDrawingDate;

        /// <summary>手形種類</summary>
        private Int32 _draftKind;

        /// <summary>手形種類名称</summary>
        /// <remarks>約束、為替、小切手</remarks>
        private string _draftKindName = "";

        /// <summary>手形区分</summary>
        private Int32 _draftDivide;

        /// <summary>手形区分名称</summary>
        /// <remarks>自振、廻し</remarks>
        private string _draftDivideName = "";

        /// <summary>手形番号</summary>
        private string _draftNo = "";

        /// <summary>入金担当者コード</summary>
        private string _depositAgentCode = "";

        /// <summary>入金担当者名称</summary>
        private string _depositAgentNm = "";

        /// <summary>入金入力者コード</summary>
        private string _depositInputAgentCd = "";

        /// <summary>入金入力者名称</summary>
        private string _depositInputAgentNm = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先名称</summary>
        private string _customerName = "";

        /// <summary>得意先名称2</summary>
        private string _customerName2 = "";

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>請求先コード</summary>
        /// <remarks>請求先得意先</remarks>
        private Int32 _claimCode;

        /// <summary>請求先名称</summary>
        /// <remarks>請求得意先名称</remarks>
        private string _claimName = "";

        /// <summary>請求先名称2</summary>
        /// <remarks>請求得意先名称２</remarks>
        private string _claimName2 = "";

        /// <summary>請求先略称</summary>
        private string _claimSnm = "";

        /// <summary>伝票摘要</summary>
        /// <remarks>車販の場合、摘要+注文書№+管理番号を格納</remarks>
        private string _outline = "";

        /// <summary>銀行コード</summary>
        /// <remarks>郵便局：9900</remarks>
        private Int32 _bankCode;

        /// <summary>銀行名称</summary>
        private string _bankName = "";

        /// <summary>入金行番号</summary>
        /// <remarks>※入金設定金種コードの設定番号をセット</remarks>
        private Int32 _depositRowNo;

        /// <summary>金種コード</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode;

        /// <summary>金種名称</summary>
        private string _moneyKindName = "";

        /// <summary>金種区分</summary>
        private Int32 _moneyKindDiv;

        /// <summary>有効期限</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm;


        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  InputDepositSecCd
        /// <summary>入金入力拠点コードプロパティ</summary>
        /// <value>入金入力した拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金入力拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputDepositSecCd
        {
            get { return _inputDepositSecCd; }
            set { _inputDepositSecCd = value; }
        }

        /// public propaty name  :  AddUpSecCode
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>集計の対象となっている拠点コード</value>
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
        /// <value>文字型 データの登録更新拠点</value>
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

        /// public propaty name  :  InputDay
        /// <summary>入力日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  DepositDate
        /// <summary>入金日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DepositDate
        {
            get { return _depositDate; }
            set { _depositDate = value; }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>計上日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
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

        /// public propaty name  :  DepositTotal
        /// <summary>入金計プロパティ</summary>
        /// <value>入金金額＋手数料支払額＋値引支払額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DepositTotal
        {
            get { return _depositTotal; }
            set { _depositTotal = value; }
        }

        /// public propaty name  :  Deposit
        /// <summary>入金金額プロパティ</summary>
        /// <value>値引・手数料を除いた額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Deposit
        {
            get { return _deposit; }
            set { _deposit = value; }
        }

        /// public propaty name  :  FeeDeposit
        /// <summary>手数料入金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手数料入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 FeeDeposit
        {
            get { return _feeDeposit; }
            set { _feeDeposit = value; }
        }

        /// public propaty name  :  DiscountDeposit
        /// <summary>値引入金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DiscountDeposit
        {
            get { return _discountDeposit; }
            set { _discountDeposit = value; }
        }

        /// public propaty name  :  AutoDepositCd
        /// <summary>自動入金区分プロパティ</summary>
        /// <value>0:通常入金,1:自動入金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動入金区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoDepositCd
        {
            get { return _autoDepositCd; }
            set { _autoDepositCd = value; }
        }

        /// public propaty name  :  DraftDrawingDate
        /// <summary>手形振出日プロパティ</summary>
        /// <value>YYYYMMDD</value>
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
        /// <value>約束、為替、小切手</value>
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
        /// <value>自振、廻し</value>
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

        /// public propaty name  :  DepositAgentCode
        /// <summary>入金担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositAgentCode
        {
            get { return _depositAgentCode; }
            set { _depositAgentCode = value; }
        }

        /// public propaty name  :  DepositAgentNm
        /// <summary>入金担当者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositAgentNm
        {
            get { return _depositAgentNm; }
            set { _depositAgentNm = value; }
        }

        /// public propaty name  :  DepositInputAgentCd
        /// <summary>入金入力者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositInputAgentCd
        {
            get { return _depositInputAgentCd; }
            set { _depositInputAgentCd = value; }
        }

        /// public propaty name  :  DepositInputAgentNm
        /// <summary>入金入力者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金入力者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositInputAgentNm
        {
            get { return _depositInputAgentNm; }
            set { _depositInputAgentNm = value; }
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

        /// public propaty name  :  CustomerName
        /// <summary>得意先名称プロパティ</summary>
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

        /// public propaty name  :  ClaimCode
        /// <summary>請求先コードプロパティ</summary>
        /// <value>請求先得意先</value>
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

        /// public propaty name  :  ClaimName
        /// <summary>請求先名称プロパティ</summary>
        /// <value>請求得意先名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimName
        {
            get { return _claimName; }
            set { _claimName = value; }
        }

        /// public propaty name  :  ClaimName2
        /// <summary>請求先名称2プロパティ</summary>
        /// <value>請求得意先名称２</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimName2
        {
            get { return _claimName2; }
            set { _claimName2 = value; }
        }

        /// public propaty name  :  ClaimSnm
        /// <summary>請求先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimSnm
        {
            get { return _claimSnm; }
            set { _claimSnm = value; }
        }

        /// public propaty name  :  Outline
        /// <summary>伝票摘要プロパティ</summary>
        /// <value>車販の場合、摘要+注文書№+管理番号を格納</value>
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
        /// <value>郵便局：9900</value>
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

        /// public propaty name  :  DepositRowNo
        /// <summary>入金行番号プロパティ</summary>
        /// <value>※入金設定金種コードの設定番号をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositRowNo
        {
            get { return _depositRowNo; }
            set { _depositRowNo = value; }
        }

        /// public propaty name  :  MoneyKindCode
        /// <summary>金種コードプロパティ</summary>
        /// <value>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindCode
        {
            get { return _moneyKindCode; }
            set { _moneyKindCode = value; }
        }

        /// public propaty name  :  MoneyKindName
        /// <summary>金種名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MoneyKindName
        {
            get { return _moneyKindName; }
            set { _moneyKindName = value; }
        }

        /// public propaty name  :  MoneyKindDiv
        /// <summary>金種区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindDiv
        {
            get { return _moneyKindDiv; }
            set { _moneyKindDiv = value; }
        }

        /// public propaty name  :  ValidityTerm
        /// <summary>有効期限プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ValidityTerm
        {
            get { return _validityTerm; }
            set { _validityTerm = value; }
        }


        /// <summary>
        /// 入金更新データ(売上指定型)ワークコンストラクタ
        /// </summary>
        /// <returns>CreateDepsitMainWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CreateDepsitMainWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CreateDepsitMainWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CreateDepsitMainWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CreateDepsitMainWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CreateDepsitMainWork_SerializationSurrogate_For_V51010 : ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CreateDepsitMainWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CreateDepsitMainWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CreateDepsitMainWork || graph is ArrayList || graph is CreateDepsitMainWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CreateDepsitMainWork).FullName));

            if (graph != null && graph is CreateDepsitMainWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CreateDepsitMainWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CreateDepsitMainWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CreateDepsitMainWork[])graph).Length;
            }
            else if (graph is CreateDepsitMainWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //入金入力拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InputDepositSecCd
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //更新拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdateSecCd
            //部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //入力日付
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //入金日付
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositDate
            //計上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //入金計
            serInfo.MemberInfo.Add(typeof(Int64)); //DepositTotal
            //入金金額
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit
            //手数料入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //FeeDeposit
            //値引入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountDeposit
            //自動入金区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoDepositCd
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
            //入金担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //DepositAgentCode
            //入金担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //DepositAgentNm
            //入金入力者コード
            serInfo.MemberInfo.Add(typeof(string)); //DepositInputAgentCd
            //入金入力者名称
            serInfo.MemberInfo.Add(typeof(string)); //DepositInputAgentNm
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //得意先名称2
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //請求先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //請求先名称
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName
            //請求先名称2
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName2
            //請求先略称
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //伝票摘要
            serInfo.MemberInfo.Add(typeof(string)); //Outline
            //銀行コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BankCode
            //銀行名称
            serInfo.MemberInfo.Add(typeof(string)); //BankName
            //入金行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo
            //金種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode
            //金種名称
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName
            //金種区分
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv
            //有効期限
            serInfo.MemberInfo.Add(typeof(Int32)); //ValidityTerm


            serInfo.Serialize(writer, serInfo);
            if (graph is CreateDepsitMainWork)
            {
                CreateDepsitMainWork temp = (CreateDepsitMainWork)graph;

                SetCreateDepsitMainWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CreateDepsitMainWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CreateDepsitMainWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CreateDepsitMainWork temp in lst)
                {
                    SetCreateDepsitMainWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CreateDepsitMainWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 40;

        /// <summary>
        ///  CreateDepsitMainWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CreateDepsitMainWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCreateDepsitMainWork(System.IO.BinaryWriter writer, CreateDepsitMainWork temp)
        {
            //受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //入金入力拠点コード
            writer.Write(temp.InputDepositSecCd);
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //更新拠点コード
            writer.Write(temp.UpdateSecCd);
            //部門コード
            writer.Write(temp.SubSectionCode);
            //入力日付
            writer.Write((Int64)temp.InputDay.Ticks);
            //入金日付
            writer.Write((Int64)temp.DepositDate.Ticks);
            //計上日付
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //入金計
            writer.Write(temp.DepositTotal);
            //入金金額
            writer.Write(temp.Deposit);
            //手数料入金額
            writer.Write(temp.FeeDeposit);
            //値引入金額
            writer.Write(temp.DiscountDeposit);
            //自動入金区分
            writer.Write(temp.AutoDepositCd);
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
            //入金担当者コード
            writer.Write(temp.DepositAgentCode);
            //入金担当者名称
            writer.Write(temp.DepositAgentNm);
            //入金入力者コード
            writer.Write(temp.DepositInputAgentCd);
            //入金入力者名称
            writer.Write(temp.DepositInputAgentNm);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先名称
            writer.Write(temp.CustomerName);
            //得意先名称2
            writer.Write(temp.CustomerName2);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //請求先コード
            writer.Write(temp.ClaimCode);
            //請求先名称
            writer.Write(temp.ClaimName);
            //請求先名称2
            writer.Write(temp.ClaimName2);
            //請求先略称
            writer.Write(temp.ClaimSnm);
            //伝票摘要
            writer.Write(temp.Outline);
            //銀行コード
            writer.Write(temp.BankCode);
            //銀行名称
            writer.Write(temp.BankName);
            //入金行番号
            writer.Write(temp.DepositRowNo);
            //金種コード
            writer.Write(temp.MoneyKindCode);
            //金種名称
            writer.Write(temp.MoneyKindName);
            //金種区分
            writer.Write(temp.MoneyKindDiv);
            //有効期限
            writer.Write((Int64)temp.ValidityTerm.Ticks);

        }

        /// <summary>
        ///  CreateDepsitMainWorkインスタンス取得
        /// </summary>
        /// <returns>CreateDepsitMainWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CreateDepsitMainWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CreateDepsitMainWork GetCreateDepsitMainWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CreateDepsitMainWork temp = new CreateDepsitMainWork();

            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //入金入力拠点コード
            temp.InputDepositSecCd = reader.ReadString();
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //更新拠点コード
            temp.UpdateSecCd = reader.ReadString();
            //部門コード
            temp.SubSectionCode = reader.ReadInt32();
            //入力日付
            temp.InputDay = new DateTime(reader.ReadInt64());
            //入金日付
            temp.DepositDate = new DateTime(reader.ReadInt64());
            //計上日付
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //入金計
            temp.DepositTotal = reader.ReadInt64();
            //入金金額
            temp.Deposit = reader.ReadInt64();
            //手数料入金額
            temp.FeeDeposit = reader.ReadInt64();
            //値引入金額
            temp.DiscountDeposit = reader.ReadInt64();
            //自動入金区分
            temp.AutoDepositCd = reader.ReadInt32();
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
            //入金担当者コード
            temp.DepositAgentCode = reader.ReadString();
            //入金担当者名称
            temp.DepositAgentNm = reader.ReadString();
            //入金入力者コード
            temp.DepositInputAgentCd = reader.ReadString();
            //入金入力者名称
            temp.DepositInputAgentNm = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先名称
            temp.CustomerName = reader.ReadString();
            //得意先名称2
            temp.CustomerName2 = reader.ReadString();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //請求先コード
            temp.ClaimCode = reader.ReadInt32();
            //請求先名称
            temp.ClaimName = reader.ReadString();
            //請求先名称2
            temp.ClaimName2 = reader.ReadString();
            //請求先略称
            temp.ClaimSnm = reader.ReadString();
            //伝票摘要
            temp.Outline = reader.ReadString();
            //銀行コード
            temp.BankCode = reader.ReadInt32();
            //銀行名称
            temp.BankName = reader.ReadString();
            //入金行番号
            temp.DepositRowNo = reader.ReadInt32();
            //金種コード
            temp.MoneyKindCode = reader.ReadInt32();
            //金種名称
            temp.MoneyKindName = reader.ReadString();
            //金種区分
            temp.MoneyKindDiv = reader.ReadInt32();
            //有効期限
            temp.ValidityTerm = new DateTime(reader.ReadInt64());


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
        /// <returns>CreateDepsitMainWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CreateDepsitMainWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CreateDepsitMainWork temp = GetCreateDepsitMainWork(reader, serInfo);
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
                    retValue = (CreateDepsitMainWork[])lst.ToArray(typeof(CreateDepsitMainWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
