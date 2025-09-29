using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OrderConfWork
    /// <summary>
    ///                      受注貸出確認表抽出結果クラスワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   受注貸出確認表抽出結果クラスワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/31  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OrderConfWork
    {
        /// <summary>拠点コード[共通]</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド名称[共通]</summary>
        /// <remarks>拠点情報設定マスタより取得</remarks>
        private string _sectionGuideNm = "";

        /// <summary>部門コード[共通]</summary>
        private Int32 _subSectionCode;

        /// <summary>部門名称[共通]</summary>
        private string _subSectionName = "";

        /// <summary>得意先コード[共通]</summary>
        private Int32 _customerCode;

        /// <summary>得意先略称[共通]</summary>
        private string _customerSnm = "";

        /// <summary>販売エリアコード(地区)[共通]</summary>
        private Int32 _salesAreaCode;

        /// <summary>販売エリア名称(地区)[共通]</summary>
        private string _salesAreaName = "";

        /// <summary>請求先コード[共通]</summary>
        private Int32 _claimCode;

        /// <summary>請求先略称[共通]</summary>
        private string _claimSnm = "";

        /// <summary>納品先コード(納入先)[共通]</summary>
        private Int32 _addresseeCode;

        /// <summary>納品先名称(納入先)[共通]</summary>
        private string _addresseeName = "";

        /// <summary>納品先名称2(納入場所)[共通]</summary>
        /// <remarks>追加(登録漏れ) 塩原</remarks>
        private string _addresseeName2 = "";

        /// <summary>売上入力者コード[共通]</summary>
        private string _salesInputCode = "";

        /// <summary>売上入力者名称[共通]</summary>
        private string _salesInputName = "";

        /// <summary>受付従業員コード[共通]</summary>
        private string _frontEmployeeCd = "";

        /// <summary>受付従業員名称[共通]</summary>
        private string _frontEmployeeNm = "";

        /// <summary>販売従業員コード[共通]</summary>
        private string _salesEmployeeCd = "";

        /// <summary>販売従業員名称[共通]</summary>
        private string _salesEmployeeNm = "";

        /// <summary>受注ステータス[共通]</summary>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上伝票番号[伝票]</summary>
        private string _salesSlipNum = "";

        /// <summary>赤伝区分[共通]</summary>
        private Int32 _debitNoteDiv;

        /// <summary>売上伝票区分[伝票]</summary>
        /// <remarks>0:売上,1:返品</remarks>
        private Int32 _salesSlipCd;

        /// <summary>売上商品区分[共通]</summary>
        /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整</remarks>
        private Int32 _salesGoodsCd;

        /// <summary>売掛区分[共通]</summary>
        /// <remarks>0:売掛なし,1:売掛</remarks>
        private Int32 _accRecDivCd;

        /// <summary>取引区分名[伝票]</summary>
        /// <remarks>リモート部で算出(売上伝票区分・売掛区分を使用)</remarks>
        private string _transactionName = "";

        /// <summary>伝票検索日付(入力日付)[共通]</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _searchSlipDate;

        /// <summary>出荷日付[共通]</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _shipmentDay;

        /// <summary>売上日付[共通]</summary>
        private DateTime _salesDate;

        /// <summary>計上日付(請求日)[共通]</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpADate;

        /// <summary>来勘区分[共通]</summary>
        private Int32 _delayPaymentDiv;

        /// <summary>相手先伝票番号[共通]</summary>
        /// <remarks>得意先注文番号（仮伝番号）</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>売上伝票合計(税抜)[伝票]</summary>
        /// <remarks>(値引も含む)</remarks>
        private Int64 _salesTotalTaxExc;

        /// <summary>売上伝票合計(税込)[伝票]</summary>
        /// <remarks>(値引も含む)</remarks>
        private Int64 _salesTotalTaxInc;

        /// <summary>売上値引金額計(税抜)[伝票]</summary>
        private Int64 _salesDisTtlTaxExc;

        /// <summary>売上値引消費税額（内税）[伝票]</summary>
        private Int64 _salesDisTtlTaxInclu;

        /// <summary>原価金額計[伝票]</summary>
        private Int64 _totalCost;

        /// <summary>粗利率[伝票]</summary>
        /// <remarks>リモート部で算出</remarks>
        private Double _grossMarginRate;

        /// <summary>粗利チェックマーク[伝票]</summary>
        /// <remarks>リモート部で算出</remarks>
        private string _grossMarginMarkSlip = "";

        /// <summary>伝票備考[伝票]</summary>
        private string _slipNote = "";

        /// <summary>売上行番号[明細]</summary>
        private Int32 _salesRowNo;

        /// <summary>売上伝票区分[明細]</summary>
        /// <remarks>0:売上,1:返品,2:値引,9:一式</remarks>
        private Int32 _salesSlipCdDtl;

        /// <summary>商品メーカーコード[明細]</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称[明細]</summary>
        private string _makerName = "";

        /// <summary>商品番号[明細]</summary>
        private string _goodsNo = "";

        /// <summary>商品名称[明細]</summary>
        private string _goodsName = "";

        /// <summary>出荷数[明細]</summary>
        private Double _shipmentCnt;

        /// <summary>基準単価(売上単価)[明細]</summary>
        private Double _stdUnPrcSalUnPrc;

        /// <summary>売上単価(税込)[明細]</summary>
        private Double _salesUnPrcTaxIncFl;

        /// <summary>売上単価(税抜)[明細]</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>売上金額(税込)[明細]</summary>
        private Int64 _salesMoneyTaxInc;

        /// <summary>売上金額(税抜)[明細]</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>原価単価[明細]</summary>
        private Double _salesUnitCost;

        /// <summary>原価金額[明細]</summary>
        private Int64 _cost;

        /// <summary>粗利率[明細]</summary>
        /// <remarks>リモート部で算出</remarks>
        private Double _grossMarginRateDtl;

        /// <summary>粗利チェックマーク[明細]</summary>
        /// <remarks>リモート部で算出</remarks>
        private string _grossMarginMarkDtl = "";

        /// <summary>仕入先コード[明細]</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称[明細]</summary>
        private string _supplierSnm = "";

        /// <summary>相手先伝票番号[明細]</summary>
        /// <remarks>得意先注文番号（仮伝No）</remarks>
        private string _partySlipNumDtl = "";

        /// <summary>明細備考[明細]</summary>
        private string _dtlNote = "";

        /// <summary>倉庫コード[明細]</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称[明細]</summary>
        private string _warehouseName = "";

        /// <summary>業種コード[明細]</summary>
        private Int32 _businessTypeCode;

        /// <summary>業種名称[明細]</summary>
        private string _businessTypeName = "";

        /// <summary>販売区分コード[明細]</summary>
        private Int32 _salesCode;

        /// <summary>販売区分名称[明細]</summary>
        private string _salesCdNm = "";

        /// <summary>車種全角名称[明細]</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _modelFullName = "";

        /// <summary>型式（フル型）[明細]</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _fullModel = "";

        /// <summary>型式指定番号[明細]</summary>
        private Int32 _modelDesignationNo;

        /// <summary>類別番号[明細]</summary>
        private Int32 _categoryNo;

        /// <summary>車輌管理コード[明細]</summary>
        /// <remarks>※PM7での車両管理番号</remarks>
        private string _carMngCode = "";

        /// <summary>初年度[明細]</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _firstEntryDate;

        /// <summary>伝票備考２[明細]</summary>
        private string _slipNote2 = "";

        /// <summary>伝票備考３[明細]</summary>
        private string _slipNote3 = "";

        /// <summary>BL商品コード[明細]</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（全角）[明細]</summary>
        private string _bLGoodsFullName = "";

        /// <summary>売上在庫取寄せ区分</summary>
        /// <remarks>0:取寄せ，1:在庫</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>ＵＯＥリマーク１[明細]</summary>
        private string _uoeRemark1 = "";

        /// <summary>ＵＯＥリマーク２[明細]</summary>
        private string _uoeRemark2 = "";

        /// <summary>仕入明細通番（同時）</summary>
        /// <remarks>同時計上時の仕入明細通番をセット</remarks>
        private Int64 _stockSlipDtlNumSync;

        /// <summary>仕入伝票番号(明細)</summary>
        /// <remarks>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる。（未発注はゼロ）</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>消費税転嫁方式[伝票]</summary>
        /// <remarks>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>総額表示方法区分[伝票]</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>課税区分[明細]</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _taxationDivCd;

        /// <summary>売上金額消費税額（内税）[伝票] </summary>
        /// <remarks>値引前の内税商品の消費税</remarks>
        private Int64 _salAmntConsTaxInclu;

        /// <summary>定価（税抜，浮動）[明細]</summary>
        private Double _listPriceTaxExcFl;

        /// <summary>売上値引消費税額（外税）[伝票]</summary>
        /// <remarks>外税商品値引の消費税額</remarks>
        private Int64 _salesDisOutTax;

        /// <summary>原価金額(値引)</summary>
        private Int64 _disCost;

        /// <summary>受注残数</summary>
        /// <remarks>受注数量＋受注調整数－出荷数</remarks>
        private Double _acptAnOdrRemainCnt;

        /// <summary>受注数量</summary>
        /// <remarks>受注,出荷で使用</remarks>
        private Double _acceptAnOrderCnt;

        /// <summary>受注調整数</summary>
        /// <remarks>現在の受注数は「受注数量＋受注調整数」で算出</remarks>
        private Double _acptAnOdrAdjustCnt;


        /// public propaty name  :  SectionCode
        /// <summary>拠点コード[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称[共通]プロパティ</summary>
        /// <value>拠点情報設定マスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>部門コード[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門コード[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }

        /// public propaty name  :  SubSectionName
        /// <summary>部門名称[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門名称[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SubSectionName
        {
            get { return _subSectionName; }
            set { _subSectionName = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コード[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>販売エリアコード(地区)[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコード(地区)[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>販売エリア名称(地区)[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリア名称(地区)[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>請求先コード[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先コード[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  ClaimSnm
        /// <summary>請求先略称[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先略称[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimSnm
        {
            get { return _claimSnm; }
            set { _claimSnm = value; }
        }

        /// public propaty name  :  AddresseeCode
        /// <summary>納品先コード(納入先)[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先コード(納入先)[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddresseeCode
        {
            get { return _addresseeCode; }
            set { _addresseeCode = value; }
        }

        /// public propaty name  :  AddresseeName
        /// <summary>納品先名称(納入先)[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先名称(納入先)[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeName
        {
            get { return _addresseeName; }
            set { _addresseeName = value; }
        }

        /// public propaty name  :  AddresseeName2
        /// <summary>納品先名称2(納入場所)[共通]プロパティ</summary>
        /// <value>追加(登録漏れ) 塩原</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先名称2(納入場所)[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeName2
        {
            get { return _addresseeName2; }
            set { _addresseeName2 = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>売上入力者コード[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者コード[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  SalesInputName
        /// <summary>売上入力者名称[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者名称[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputName
        {
            get { return _salesInputName; }
            set { _salesInputName = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>受付従業員コード[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員コード[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>受付従業員名称[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員名称[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>販売従業員コード[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員コード[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>販売従業員名称[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員名称[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータス[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータス[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号[伝票]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号[伝票]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  SalesSlipCd
        /// <summary>売上伝票区分[伝票]プロパティ</summary>
        /// <value>0:売上,1:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分[伝票]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

        /// public propaty name  :  SalesGoodsCd
        /// <summary>売上商品区分[共通]プロパティ</summary>
        /// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上商品区分[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesGoodsCd
        {
            get { return _salesGoodsCd; }
            set { _salesGoodsCd = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>売掛区分[共通]プロパティ</summary>
        /// <value>0:売掛なし,1:売掛</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売掛区分[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
        }

        /// public propaty name  :  TransactionName
        /// <summary>取引区分名[伝票]プロパティ</summary>
        /// <value>リモート部で算出(売上伝票区分・売掛区分を使用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引区分名[伝票]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TransactionName
        {
            get { return _transactionName; }
            set { _transactionName = value; }
        }

        /// public propaty name  :  SearchSlipDate
        /// <summary>伝票検索日付(入力日付)[共通]プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付(入力日付)[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SearchSlipDate
        {
            get { return _searchSlipDate; }
            set { _searchSlipDate = value; }
        }

        /// public propaty name  :  ShipmentDay
        /// <summary>出荷日付[共通]プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ShipmentDay
        {
            get { return _shipmentDay; }
            set { _shipmentDay = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>売上日付[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>計上日付(請求日)[共通]プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付(請求日)[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpADate
        {
            get { return _addUpADate; }
            set { _addUpADate = value; }
        }

        /// public propaty name  :  DelayPaymentDiv
        /// <summary>来勘区分[共通]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   来勘区分[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DelayPaymentDiv
        {
            get { return _delayPaymentDiv; }
            set { _delayPaymentDiv = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>相手先伝票番号[共通]プロパティ</summary>
        /// <value>得意先注文番号（仮伝番号）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号[共通]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  SalesTotalTaxExc
        /// <summary>売上伝票合計(税抜)[伝票]プロパティ</summary>
        /// <value>(値引も含む)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票合計(税抜)[伝票]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTotalTaxExc
        {
            get { return _salesTotalTaxExc; }
            set { _salesTotalTaxExc = value; }
        }

        /// public propaty name  :  SalesTotalTaxInc
        /// <summary>売上伝票合計(税込)[伝票]プロパティ</summary>
        /// <value>(値引も含む)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票合計(税込)[伝票]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTotalTaxInc
        {
            get { return _salesTotalTaxInc; }
            set { _salesTotalTaxInc = value; }
        }

        /// public propaty name  :  SalesDisTtlTaxExc
        /// <summary>売上値引金額計(税抜)[伝票]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上値引金額計(税抜)[伝票]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesDisTtlTaxExc
        {
            get { return _salesDisTtlTaxExc; }
            set { _salesDisTtlTaxExc = value; }
        }

        /// public propaty name  :  SalesDisTtlTaxInclu
        /// <summary>売上値引消費税額（内税）[伝票]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上値引消費税額（内税）[伝票]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesDisTtlTaxInclu
        {
            get { return _salesDisTtlTaxInclu; }
            set { _salesDisTtlTaxInclu = value; }
        }

        /// public propaty name  :  TotalCost
        /// <summary>原価金額計[伝票]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価金額計[伝票]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        /// public propaty name  :  GrossMarginRate
        /// <summary>粗利率[伝票]プロパティ</summary>
        /// <value>リモート部で算出</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利率[伝票]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GrossMarginRate
        {
            get { return _grossMarginRate; }
            set { _grossMarginRate = value; }
        }

        /// public propaty name  :  GrossMarginMarkSlip
        /// <summary>粗利チェックマーク[伝票]プロパティ</summary>
        /// <value>リモート部で算出</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利チェックマーク[伝票]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GrossMarginMarkSlip
        {
            get { return _grossMarginMarkSlip; }
            set { _grossMarginMarkSlip = value; }
        }

        /// public propaty name  :  SlipNote
        /// <summary>伝票備考[伝票]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考[伝票]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
        }

        /// public propaty name  :  SalesRowNo
        /// <summary>売上行番号[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上行番号[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesRowNo
        {
            get { return _salesRowNo; }
            set { _salesRowNo = value; }
        }

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>売上伝票区分[明細]プロパティ</summary>
        /// <value>0:売上,1:返品,2:値引,9:一式</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコード[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名称[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>出荷数[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  StdUnPrcSalUnPrc
        /// <summary>基準単価(売上単価)[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   基準単価(売上単価)[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StdUnPrcSalUnPrc
        {
            get { return _stdUnPrcSalUnPrc; }
            set { _stdUnPrcSalUnPrc = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxIncFl
        /// <summary>売上単価(税込)[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価(税込)[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnPrcTaxIncFl
        {
            get { return _salesUnPrcTaxIncFl; }
            set { _salesUnPrcTaxIncFl = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>売上単価(税抜)[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価(税抜)[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
        }

        /// public propaty name  :  SalesMoneyTaxInc
        /// <summary>売上金額(税込)[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(税込)[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxInc
        {
            get { return _salesMoneyTaxInc; }
            set { _salesMoneyTaxInc = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>売上金額(税抜)[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(税抜)[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>原価単価[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  Cost
        /// <summary>原価金額[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価金額[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        /// public propaty name  :  GrossMarginRateDtl
        /// <summary>粗利率[明細]プロパティ</summary>
        /// <value>リモート部で算出</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利率[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GrossMarginRateDtl
        {
            get { return _grossMarginRateDtl; }
            set { _grossMarginRateDtl = value; }
        }

        /// public propaty name  :  GrossMarginMarkDtl
        /// <summary>粗利チェックマーク[明細]プロパティ</summary>
        /// <value>リモート部で算出</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利チェックマーク[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GrossMarginMarkDtl
        {
            get { return _grossMarginMarkDtl; }
            set { _grossMarginMarkDtl = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コード[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  PartySlipNumDtl
        /// <summary>相手先伝票番号[明細]プロパティ</summary>
        /// <value>得意先注文番号（仮伝No）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySlipNumDtl
        {
            get { return _partySlipNumDtl; }
            set { _partySlipNumDtl = value; }
        }

        /// public propaty name  :  DtlNote
        /// <summary>明細備考[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細備考[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DtlNote
        {
            get { return _dtlNote; }
            set { _dtlNote = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コード[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫名称[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>業種コード[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種コード[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>業種名称[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種名称[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>販売区分コード[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分コード[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        /// public propaty name  :  SalesCdNm
        /// <summary>販売区分名称[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分名称[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesCdNm
        {
            get { return _salesCdNm; }
            set { _salesCdNm = value; }
        }

        /// public propaty name  :  ModelFullName
        /// <summary>車種全角名称[明細]プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種全角名称[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>型式（フル型）[明細]プロパティ</summary>
        /// <value>フル型式(44桁用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（フル型）[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  ModelDesignationNo
        /// <summary>型式指定番号[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式指定番号[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }

        /// public propaty name  :  CategoryNo
        /// <summary>類別番号[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   類別番号[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        /// public propaty name  :  CarMngCode
        /// <summary>車輌管理コード[明細]プロパティ</summary>
        /// <value>※PM7での車両管理番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌管理コード[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }

        /// public propaty name  :  FirstEntryDate
        /// <summary>初年度[明細]プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime FirstEntryDate
        {
            get { return _firstEntryDate; }
            set { _firstEntryDate = value; }
        }

        /// public propaty name  :  SlipNote2
        /// <summary>伝票備考２[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考２[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote2
        {
            get { return _slipNote2; }
            set { _slipNote2 = value; }
        }

        /// public propaty name  :  SlipNote3
        /// <summary>伝票備考３[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考３[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote3
        {
            get { return _slipNote3; }
            set { _slipNote3 = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コード[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL商品コード名称（全角）[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>売上在庫取寄せ区分プロパティ</summary>
        /// <value>0:取寄せ，1:在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上在庫取寄せ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesOrderDivCd
        {
            get { return _salesOrderDivCd; }
            set { _salesOrderDivCd = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>ＵＯＥリマーク１[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク１[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>ＵＯＥリマーク２[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク２[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  StockSlipDtlNumSync
        /// <summary>仕入明細通番（同時）プロパティ</summary>
        /// <value>同時計上時の仕入明細通番をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入明細通番（同時）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockSlipDtlNumSync
        {
            get { return _stockSlipDtlNumSync; }
            set { _stockSlipDtlNumSync = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号(明細)プロパティ</summary>
        /// <value>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる。（未発注はゼロ）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号(明細)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>消費税転嫁方式[伝票]プロパティ</summary>
        /// <value>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税転嫁方式[伝票]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>総額表示方法区分[伝票]プロパティ</summary>
        /// <value>0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示方法区分[伝票]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>課税区分[明細]プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  SalAmntConsTaxInclu
        /// <summary>売上金額消費税額（内税）[伝票] プロパティ</summary>
        /// <value>値引前の内税商品の消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額消費税額（内税）[伝票] プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalAmntConsTaxInclu
        {
            get { return _salAmntConsTaxInclu; }
            set { _salAmntConsTaxInclu = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>定価（税抜，浮動）[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税抜，浮動）[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        /// public propaty name  :  SalesDisOutTax
        /// <summary>売上値引消費税額（外税）[伝票]プロパティ</summary>
        /// <value>外税商品値引の消費税額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上値引消費税額（外税）[伝票]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesDisOutTax
        {
            get { return _salesDisOutTax; }
            set { _salesDisOutTax = value; }
        }

        /// public propaty name  :  DisCost
        /// <summary>原価金額(値引)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価金額(値引)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DisCost
        {
            get { return _disCost; }
            set { _disCost = value; }
        }

        /// public propaty name  :  AcptAnOdrRemainCnt
        /// <summary>受注残数プロパティ</summary>
        /// <value>受注数量＋受注調整数－出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注残数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AcptAnOdrRemainCnt
        {
            get { return _acptAnOdrRemainCnt; }
            set { _acptAnOdrRemainCnt = value; }
        }

        /// public propaty name  :  AcceptAnOrderCnt
        /// <summary>受注数量プロパティ</summary>
        /// <value>受注,出荷で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AcceptAnOrderCnt
        {
            get { return _acceptAnOrderCnt; }
            set { _acceptAnOrderCnt = value; }
        }

        /// public propaty name  :  AcptAnOdrAdjustCnt
        /// <summary>受注調整数プロパティ</summary>
        /// <value>現在の受注数は「受注数量＋受注調整数」で算出</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注調整数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AcptAnOdrAdjustCnt
        {
            get { return _acptAnOdrAdjustCnt; }
            set { _acptAnOdrAdjustCnt = value; }
        }


        /// <summary>
        /// 受注貸出確認表抽出結果クラスワークワークコンストラクタ
        /// </summary>
        /// <returns>OrderConfWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderConfWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OrderConfWork()
        {
        }
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>OrderConfWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   OrderConfWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class OrderConfWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderConfWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OrderConfWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OrderConfWork || graph is ArrayList || graph is OrderConfWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(OrderConfWork).FullName));

            if (graph != null && graph is OrderConfWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OrderConfWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OrderConfWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OrderConfWork[])graph).Length;
            }
            else if (graph is OrderConfWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点コード[共通]
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド名称[共通]
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //部門コード[共通]
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //部門名称[共通]
            serInfo.MemberInfo.Add(typeof(string)); //SubSectionName
            //得意先コード[共通]
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先略称[共通]
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //販売エリアコード(地区)[共通]
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //販売エリア名称(地区)[共通]
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //請求先コード[共通]
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //請求先略称[共通]
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //納品先コード(納入先)[共通]
            serInfo.MemberInfo.Add(typeof(Int32)); //AddresseeCode
            //納品先名称(納入先)[共通]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName
            //納品先名称2(納入場所)[共通]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName2
            //売上入力者コード[共通]
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputCode
            //売上入力者名称[共通]
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputName
            //受付従業員コード[共通]
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeCd
            //受付従業員名称[共通]
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeNm
            //販売従業員コード[共通]
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeCd
            //販売従業員名称[共通]
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeNm
            //受注ステータス[共通]
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //売上伝票番号[伝票]
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //赤伝区分[共通]
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //売上伝票区分[伝票]
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCd
            //売上商品区分[共通]
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesGoodsCd
            //売掛区分[共通]
            serInfo.MemberInfo.Add(typeof(Int32)); //AccRecDivCd
            //取引区分名[伝票]
            serInfo.MemberInfo.Add(typeof(string)); //TransactionName
            //伝票検索日付(入力日付)[共通]
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchSlipDate
            //出荷日付[共通]
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentDay
            //売上日付[共通]
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //計上日付(請求日)[共通]
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //来勘区分[共通]
            serInfo.MemberInfo.Add(typeof(Int32)); //DelayPaymentDiv
            //相手先伝票番号[共通]
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //売上伝票合計(税抜)[伝票]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxExc
            //売上伝票合計(税込)[伝票]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxInc
            //売上値引金額計(税抜)[伝票]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesDisTtlTaxExc
            //売上値引消費税額（内税）[伝票]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesDisTtlTaxInclu
            //原価金額計[伝票]
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalCost
            //粗利率[伝票]
            serInfo.MemberInfo.Add(typeof(Double)); //GrossMarginRate
            //粗利チェックマーク[伝票]
            serInfo.MemberInfo.Add(typeof(string)); //GrossMarginMarkSlip
            //伝票備考[伝票]
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote
            //売上行番号[明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //売上伝票区分[明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCdDtl
            //商品メーカーコード[明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称[明細]
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //商品番号[明細]
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称[明細]
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //出荷数[明細]
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //基準単価(売上単価)[明細]
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcSalUnPrc
            //売上単価(税込)[明細]
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxIncFl
            //売上単価(税抜)[明細]
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //売上金額(税込)[明細]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxInc
            //売上金額(税抜)[明細]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //原価単価[明細]
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //原価金額[明細]
            serInfo.MemberInfo.Add(typeof(Int64)); //Cost
            //粗利率[明細]
            serInfo.MemberInfo.Add(typeof(Double)); //GrossMarginRateDtl
            //粗利チェックマーク[明細]
            serInfo.MemberInfo.Add(typeof(string)); //GrossMarginMarkDtl
            //仕入先コード[明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称[明細]
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //相手先伝票番号[明細]
            serInfo.MemberInfo.Add(typeof(string)); //PartySlipNumDtl
            //明細備考[明細]
            serInfo.MemberInfo.Add(typeof(string)); //DtlNote
            //倉庫コード[明細]
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称[明細]
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //業種コード[明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessTypeCode
            //業種名称[明細]
            serInfo.MemberInfo.Add(typeof(string)); //BusinessTypeName
            //販売区分コード[明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCode
            //販売区分名称[明細]
            serInfo.MemberInfo.Add(typeof(string)); //SalesCdNm
            //車種全角名称[明細]
            serInfo.MemberInfo.Add(typeof(string)); //ModelFullName
            //型式（フル型）[明細]
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //型式指定番号[明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
            //類別番号[明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
            //車輌管理コード[明細]
            serInfo.MemberInfo.Add(typeof(string)); //CarMngCode
            //初年度[明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //FirstEntryDate
            //伝票備考２[明細]
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote2
            //伝票備考３[明細]
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote3
            //BL商品コード[明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード名称（全角）[明細]
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //売上在庫取寄せ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDivCd
            //ＵＯＥリマーク１[明細]
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //ＵＯＥリマーク２[明細]
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
            //仕入明細通番（同時）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNumSync
            //仕入伝票番号(明細)
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //消費税転嫁方式[伝票]
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //総額表示方法区分[伝票]
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalAmountDispWayCd
            //課税区分[明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //売上金額消費税額（内税）[伝票] 
            serInfo.MemberInfo.Add(typeof(Int64)); //SalAmntConsTaxInclu
            //定価（税抜，浮動）[明細]
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //売上値引消費税額（外税）[伝票]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesDisOutTax
            //原価金額(値引)
            serInfo.MemberInfo.Add(typeof(Int64)); //DisCost
            //受注残数
            serInfo.MemberInfo.Add(typeof(Double)); //AcptAnOdrRemainCnt
            //受注数量
            serInfo.MemberInfo.Add(typeof(Double)); //AcceptAnOrderCnt
            //受注調整数
            serInfo.MemberInfo.Add(typeof(Double)); //AcptAnOdrAdjustCnt


            serInfo.Serialize(writer, serInfo);
            if (graph is OrderConfWork)
            {
                OrderConfWork temp = (OrderConfWork)graph;

                SetOrderConfWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OrderConfWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OrderConfWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OrderConfWork temp in lst)
                {
                    SetOrderConfWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OrderConfWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 91;

        /// <summary>
        ///  OrderConfWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderConfWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetOrderConfWork(System.IO.BinaryWriter writer, OrderConfWork temp)
        {
            //拠点コード[共通]
            writer.Write(temp.SectionCode);
            //拠点ガイド名称[共通]
            writer.Write(temp.SectionGuideNm);
            //部門コード[共通]
            writer.Write(temp.SubSectionCode);
            //部門名称[共通]
            writer.Write(temp.SubSectionName);
            //得意先コード[共通]
            writer.Write(temp.CustomerCode);
            //得意先略称[共通]
            writer.Write(temp.CustomerSnm);
            //販売エリアコード(地区)[共通]
            writer.Write(temp.SalesAreaCode);
            //販売エリア名称(地区)[共通]
            writer.Write(temp.SalesAreaName);
            //請求先コード[共通]
            writer.Write(temp.ClaimCode);
            //請求先略称[共通]
            writer.Write(temp.ClaimSnm);
            //納品先コード(納入先)[共通]
            writer.Write(temp.AddresseeCode);
            //納品先名称(納入先)[共通]
            writer.Write(temp.AddresseeName);
            //納品先名称2(納入場所)[共通]
            writer.Write(temp.AddresseeName2);
            //売上入力者コード[共通]
            writer.Write(temp.SalesInputCode);
            //売上入力者名称[共通]
            writer.Write(temp.SalesInputName);
            //受付従業員コード[共通]
            writer.Write(temp.FrontEmployeeCd);
            //受付従業員名称[共通]
            writer.Write(temp.FrontEmployeeNm);
            //販売従業員コード[共通]
            writer.Write(temp.SalesEmployeeCd);
            //販売従業員名称[共通]
            writer.Write(temp.SalesEmployeeNm);
            //受注ステータス[共通]
            writer.Write(temp.AcptAnOdrStatus);
            //売上伝票番号[伝票]
            writer.Write(temp.SalesSlipNum);
            //赤伝区分[共通]
            writer.Write(temp.DebitNoteDiv);
            //売上伝票区分[伝票]
            writer.Write(temp.SalesSlipCd);
            //売上商品区分[共通]
            writer.Write(temp.SalesGoodsCd);
            //売掛区分[共通]
            writer.Write(temp.AccRecDivCd);
            //取引区分名[伝票]
            writer.Write(temp.TransactionName);
            //伝票検索日付(入力日付)[共通]
            writer.Write((Int64)temp.SearchSlipDate.Ticks);
            //出荷日付[共通]
            writer.Write((Int64)temp.ShipmentDay.Ticks);
            //売上日付[共通]
            writer.Write((Int64)temp.SalesDate.Ticks);
            //計上日付(請求日)[共通]
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //来勘区分[共通]
            writer.Write(temp.DelayPaymentDiv);
            //相手先伝票番号[共通]
            writer.Write(temp.PartySaleSlipNum);
            //売上伝票合計(税抜)[伝票]
            writer.Write(temp.SalesTotalTaxExc);
            //売上伝票合計(税込)[伝票]
            writer.Write(temp.SalesTotalTaxInc);
            //売上値引金額計(税抜)[伝票]
            writer.Write(temp.SalesDisTtlTaxExc);
            //売上値引消費税額（内税）[伝票]
            writer.Write(temp.SalesDisTtlTaxInclu);
            //原価金額計[伝票]
            writer.Write(temp.TotalCost);
            //粗利率[伝票]
            writer.Write(temp.GrossMarginRate);
            //粗利チェックマーク[伝票]
            writer.Write(temp.GrossMarginMarkSlip);
            //伝票備考[伝票]
            writer.Write(temp.SlipNote);
            //売上行番号[明細]
            writer.Write(temp.SalesRowNo);
            //売上伝票区分[明細]
            writer.Write(temp.SalesSlipCdDtl);
            //商品メーカーコード[明細]
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称[明細]
            writer.Write(temp.MakerName);
            //商品番号[明細]
            writer.Write(temp.GoodsNo);
            //商品名称[明細]
            writer.Write(temp.GoodsName);
            //出荷数[明細]
            writer.Write(temp.ShipmentCnt);
            //基準単価(売上単価)[明細]
            writer.Write(temp.StdUnPrcSalUnPrc);
            //売上単価(税込)[明細]
            writer.Write(temp.SalesUnPrcTaxIncFl);
            //売上単価(税抜)[明細]
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //売上金額(税込)[明細]
            writer.Write(temp.SalesMoneyTaxInc);
            //売上金額(税抜)[明細]
            writer.Write(temp.SalesMoneyTaxExc);
            //原価単価[明細]
            writer.Write(temp.SalesUnitCost);
            //原価金額[明細]
            writer.Write(temp.Cost);
            //粗利率[明細]
            writer.Write(temp.GrossMarginRateDtl);
            //粗利チェックマーク[明細]
            writer.Write(temp.GrossMarginMarkDtl);
            //仕入先コード[明細]
            writer.Write(temp.SupplierCd);
            //仕入先略称[明細]
            writer.Write(temp.SupplierSnm);
            //相手先伝票番号[明細]
            writer.Write(temp.PartySlipNumDtl);
            //明細備考[明細]
            writer.Write(temp.DtlNote);
            //倉庫コード[明細]
            writer.Write(temp.WarehouseCode);
            //倉庫名称[明細]
            writer.Write(temp.WarehouseName);
            //業種コード[明細]
            writer.Write(temp.BusinessTypeCode);
            //業種名称[明細]
            writer.Write(temp.BusinessTypeName);
            //販売区分コード[明細]
            writer.Write(temp.SalesCode);
            //販売区分名称[明細]
            writer.Write(temp.SalesCdNm);
            //車種全角名称[明細]
            writer.Write(temp.ModelFullName);
            //型式（フル型）[明細]
            writer.Write(temp.FullModel);
            //型式指定番号[明細]
            writer.Write(temp.ModelDesignationNo);
            //類別番号[明細]
            writer.Write(temp.CategoryNo);
            //車輌管理コード[明細]
            writer.Write(temp.CarMngCode);
            //初年度[明細]
            writer.Write((Int64)temp.FirstEntryDate.Ticks);
            //伝票備考２[明細]
            writer.Write(temp.SlipNote2);
            //伝票備考３[明細]
            writer.Write(temp.SlipNote3);
            //BL商品コード[明細]
            writer.Write(temp.BLGoodsCode);
            //BL商品コード名称（全角）[明細]
            writer.Write(temp.BLGoodsFullName);
            //売上在庫取寄せ区分
            writer.Write(temp.SalesOrderDivCd);
            //ＵＯＥリマーク１[明細]
            writer.Write(temp.UoeRemark1);
            //ＵＯＥリマーク２[明細]
            writer.Write(temp.UoeRemark2);
            //仕入明細通番（同時）
            writer.Write(temp.StockSlipDtlNumSync);
            //仕入伝票番号(明細)
            writer.Write(temp.SupplierSlipNo);
            //消費税転嫁方式[伝票]
            writer.Write(temp.ConsTaxLayMethod);
            //総額表示方法区分[伝票]
            writer.Write(temp.TotalAmountDispWayCd);
            //課税区分[明細]
            writer.Write(temp.TaxationDivCd);
            //売上金額消費税額（内税）[伝票] 
            writer.Write(temp.SalAmntConsTaxInclu);
            //定価（税抜，浮動）[明細]
            writer.Write(temp.ListPriceTaxExcFl);
            //売上値引消費税額（外税）[伝票]
            writer.Write(temp.SalesDisOutTax);
            //原価金額(値引)
            writer.Write(temp.DisCost);
            //受注残数
            writer.Write(temp.AcptAnOdrRemainCnt);
            //受注数量
            writer.Write(temp.AcceptAnOrderCnt);
            //受注調整数
            writer.Write(temp.AcptAnOdrAdjustCnt);

        }

        /// <summary>
        ///  OrderConfWorkインスタンス取得
        /// </summary>
        /// <returns>OrderConfWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderConfWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private OrderConfWork GetOrderConfWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            OrderConfWork temp = new OrderConfWork();

            //拠点コード[共通]
            temp.SectionCode = reader.ReadString();
            //拠点ガイド名称[共通]
            temp.SectionGuideNm = reader.ReadString();
            //部門コード[共通]
            temp.SubSectionCode = reader.ReadInt32();
            //部門名称[共通]
            temp.SubSectionName = reader.ReadString();
            //得意先コード[共通]
            temp.CustomerCode = reader.ReadInt32();
            //得意先略称[共通]
            temp.CustomerSnm = reader.ReadString();
            //販売エリアコード(地区)[共通]
            temp.SalesAreaCode = reader.ReadInt32();
            //販売エリア名称(地区)[共通]
            temp.SalesAreaName = reader.ReadString();
            //請求先コード[共通]
            temp.ClaimCode = reader.ReadInt32();
            //請求先略称[共通]
            temp.ClaimSnm = reader.ReadString();
            //納品先コード(納入先)[共通]
            temp.AddresseeCode = reader.ReadInt32();
            //納品先名称(納入先)[共通]
            temp.AddresseeName = reader.ReadString();
            //納品先名称2(納入場所)[共通]
            temp.AddresseeName2 = reader.ReadString();
            //売上入力者コード[共通]
            temp.SalesInputCode = reader.ReadString();
            //売上入力者名称[共通]
            temp.SalesInputName = reader.ReadString();
            //受付従業員コード[共通]
            temp.FrontEmployeeCd = reader.ReadString();
            //受付従業員名称[共通]
            temp.FrontEmployeeNm = reader.ReadString();
            //販売従業員コード[共通]
            temp.SalesEmployeeCd = reader.ReadString();
            //販売従業員名称[共通]
            temp.SalesEmployeeNm = reader.ReadString();
            //受注ステータス[共通]
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //売上伝票番号[伝票]
            temp.SalesSlipNum = reader.ReadString();
            //赤伝区分[共通]
            temp.DebitNoteDiv = reader.ReadInt32();
            //売上伝票区分[伝票]
            temp.SalesSlipCd = reader.ReadInt32();
            //売上商品区分[共通]
            temp.SalesGoodsCd = reader.ReadInt32();
            //売掛区分[共通]
            temp.AccRecDivCd = reader.ReadInt32();
            //取引区分名[伝票]
            temp.TransactionName = reader.ReadString();
            //伝票検索日付(入力日付)[共通]
            temp.SearchSlipDate = new DateTime(reader.ReadInt64());
            //出荷日付[共通]
            temp.ShipmentDay = new DateTime(reader.ReadInt64());
            //売上日付[共通]
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //計上日付(請求日)[共通]
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //来勘区分[共通]
            temp.DelayPaymentDiv = reader.ReadInt32();
            //相手先伝票番号[共通]
            temp.PartySaleSlipNum = reader.ReadString();
            //売上伝票合計(税抜)[伝票]
            temp.SalesTotalTaxExc = reader.ReadInt64();
            //売上伝票合計(税込)[伝票]
            temp.SalesTotalTaxInc = reader.ReadInt64();
            //売上値引金額計(税抜)[伝票]
            temp.SalesDisTtlTaxExc = reader.ReadInt64();
            //売上値引消費税額（内税）[伝票]
            temp.SalesDisTtlTaxInclu = reader.ReadInt64();
            //原価金額計[伝票]
            temp.TotalCost = reader.ReadInt64();
            //粗利率[伝票]
            temp.GrossMarginRate = reader.ReadDouble();
            //粗利チェックマーク[伝票]
            temp.GrossMarginMarkSlip = reader.ReadString();
            //伝票備考[伝票]
            temp.SlipNote = reader.ReadString();
            //売上行番号[明細]
            temp.SalesRowNo = reader.ReadInt32();
            //売上伝票区分[明細]
            temp.SalesSlipCdDtl = reader.ReadInt32();
            //商品メーカーコード[明細]
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称[明細]
            temp.MakerName = reader.ReadString();
            //商品番号[明細]
            temp.GoodsNo = reader.ReadString();
            //商品名称[明細]
            temp.GoodsName = reader.ReadString();
            //出荷数[明細]
            temp.ShipmentCnt = reader.ReadDouble();
            //基準単価(売上単価)[明細]
            temp.StdUnPrcSalUnPrc = reader.ReadDouble();
            //売上単価(税込)[明細]
            temp.SalesUnPrcTaxIncFl = reader.ReadDouble();
            //売上単価(税抜)[明細]
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //売上金額(税込)[明細]
            temp.SalesMoneyTaxInc = reader.ReadInt64();
            //売上金額(税抜)[明細]
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //原価単価[明細]
            temp.SalesUnitCost = reader.ReadDouble();
            //原価金額[明細]
            temp.Cost = reader.ReadInt64();
            //粗利率[明細]
            temp.GrossMarginRateDtl = reader.ReadDouble();
            //粗利チェックマーク[明細]
            temp.GrossMarginMarkDtl = reader.ReadString();
            //仕入先コード[明細]
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称[明細]
            temp.SupplierSnm = reader.ReadString();
            //相手先伝票番号[明細]
            temp.PartySlipNumDtl = reader.ReadString();
            //明細備考[明細]
            temp.DtlNote = reader.ReadString();
            //倉庫コード[明細]
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称[明細]
            temp.WarehouseName = reader.ReadString();
            //業種コード[明細]
            temp.BusinessTypeCode = reader.ReadInt32();
            //業種名称[明細]
            temp.BusinessTypeName = reader.ReadString();
            //販売区分コード[明細]
            temp.SalesCode = reader.ReadInt32();
            //販売区分名称[明細]
            temp.SalesCdNm = reader.ReadString();
            //車種全角名称[明細]
            temp.ModelFullName = reader.ReadString();
            //型式（フル型）[明細]
            temp.FullModel = reader.ReadString();
            //型式指定番号[明細]
            temp.ModelDesignationNo = reader.ReadInt32();
            //類別番号[明細]
            temp.CategoryNo = reader.ReadInt32();
            //車輌管理コード[明細]
            temp.CarMngCode = reader.ReadString();
            //初年度[明細]
            temp.FirstEntryDate = new DateTime(reader.ReadInt64());
            //伝票備考２[明細]
            temp.SlipNote2 = reader.ReadString();
            //伝票備考３[明細]
            temp.SlipNote3 = reader.ReadString();
            //BL商品コード[明細]
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（全角）[明細]
            temp.BLGoodsFullName = reader.ReadString();
            //売上在庫取寄せ区分
            temp.SalesOrderDivCd = reader.ReadInt32();
            //ＵＯＥリマーク１[明細]
            temp.UoeRemark1 = reader.ReadString();
            //ＵＯＥリマーク２[明細]
            temp.UoeRemark2 = reader.ReadString();
            //仕入明細通番（同時）
            temp.StockSlipDtlNumSync = reader.ReadInt64();
            //仕入伝票番号(明細)
            temp.SupplierSlipNo = reader.ReadInt32();
            //消費税転嫁方式[伝票]
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //総額表示方法区分[伝票]
            temp.TotalAmountDispWayCd = reader.ReadInt32();
            //課税区分[明細]
            temp.TaxationDivCd = reader.ReadInt32();
            //売上金額消費税額（内税）[伝票] 
            temp.SalAmntConsTaxInclu = reader.ReadInt64();
            //定価（税抜，浮動）[明細]
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //売上値引消費税額（外税）[伝票]
            temp.SalesDisOutTax = reader.ReadInt64();
            //原価金額(値引)
            temp.DisCost = reader.ReadInt64();
            //受注残数
            temp.AcptAnOdrRemainCnt = reader.ReadDouble();
            //受注数量
            temp.AcceptAnOrderCnt = reader.ReadDouble();
            //受注調整数
            temp.AcptAnOdrAdjustCnt = reader.ReadDouble();


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
        /// <returns>OrderConfWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderConfWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OrderConfWork temp = GetOrderConfWork(reader, serInfo);
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
                    retValue = (OrderConfWork[])lst.ToArray(typeof(OrderConfWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
