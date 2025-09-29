using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   AcptAnOdrRemainRefData
    /// <summary>
    ///                      受注残照会抽出結果クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   受注残照会抽出結果クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class AcptAnOdrRemainRefData
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>受注ステータス</summary>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上伝票番号</summary>
        /// <remarks>伝票№</remarks>
        private string _salesSlipNum = "";

        /// <summary>受注番号</summary>
        private Int32 _acceptAnOrderNo;

        /// <summary>共通通番</summary>
        private Int64 _commonSeqNo;

        /// <summary>売上明細通番</summary>
        private Int64 _salesSlipDtlNum;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        /// <remarks>得意先名</remarks>
        private string _customerSnm = "";

        /// <summary>販売従業員コード</summary>
        private string _salesEmployeeCd = "";

        /// <summary>販売従業員名称</summary>
        /// <remarks>担当者名</remarks>
        private string _salesEmployeeNm = "";

        /// <summary>納品先名称</summary>
        /// <remarks>納入先</remarks>
        private string _addresseeName = "";

        /// <summary>納品先名称2</summary>
        /// <remarks>納入先２</remarks>
        private string _addresseeName2 = "";

        /// <summary>受付従業員コード</summary>
        private string _frontEmployeeCd = "";

        /// <summary>受付従業員名称</summary>
        /// <remarks>受注者名</remarks>
        private string _frontEmployeeNm = "";

        /// <summary>売上日付</summary>
        /// <remarks>受注日</remarks>
        private DateTime _salesDate;

        /// <summary>商品番号</summary>
        /// <remarks>商品コード</remarks>
        private string _goodsNo = "";

        /// <summary>商品番号曖昧検索条件</summary>
        private Int32 _goodsNoSrchTyp;

        /// <summary>商品名称</summary>
        /// <remarks>商品名</remarks>
        private string _goodsName = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        /// <remarks>メーカー名</remarks>
        private string _makerName = "";

        /// <summary>受注数量</summary>
        /// <remarks>受注数</remarks>
        private Double _acceptAnOrderCnt;

        /// <summary>受注残数</summary>
        /// <remarks>受注残数</remarks>
        private Double _acptAnOdrRemainCnt;

        /// <summary>売上単価（税抜，浮動）</summary>
        /// <remarks>受注単価</remarks>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>相手先伝票番号（明細）</summary>
        /// <remarks>得意先注番</remarks>
        private string _partySlipNumDtl = "";

        /// <summary>基準単価（売上単価）</summary>
        /// <remarks>基準単価</remarks>
        private Double _stdUnPrcSalUnPrc;

        /// <summary>原価単価</summary>
        /// <remarks>原価単価</remarks>
        private Double _salesUnitCost;

        /// <summary>明細備考</summary>
        /// <remarks>明細備考</remarks>
        private string _dtlNote = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        /// <remarks>仕入先名</remarks>
        private string _supplierSnm = "";

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名</summary>
        private string _warehouseName = "";

        /// <summary>伝票メモ１</summary>
        /// <remarks>メモ</remarks>
        private string _slipMemo1 = "";

        /// <summary>伝票メモ２</summary>
        /// <remarks>メモ</remarks>
        private string _slipMemo2 = "";

        /// <summary>伝票メモ３</summary>
        /// <remarks>メモ</remarks>
        private string _slipMemo3 = "";

        /// <summary>社内メモ１</summary>
        /// <remarks>メモ</remarks>
        private string _insideMemo1 = "";

        /// <summary>社内メモ２</summary>
        /// <remarks>メモ</remarks>
        private string _insideMemo2 = "";

        /// <summary>社内メモ３</summary>
        /// <remarks>メモ</remarks>
        private string _insideMemo3 = "";

        /// <summary>売上伝票区分（明細）</summary>
        /// <remarks>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</remarks>
        private Int32 _salesSlipCdDtl;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>定価（税抜，浮動）</summary>
        private Double _listPriceTaxExcFl;

        /// <summary>出荷数</summary>
        /// <remarks>売上数</remarks>
        private Double _shipmentCnt;

        /// <summary>車輌管理コード</summary>
        private string _carMngCode = "";

        /// <summary>型式指定番号</summary>
        private Int32 _modelDesignationNo;

        /// <summary>類別番号</summary>
        private Int32 _categoryNo;

        /// <summary>車種全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _modelFullName = "";

        /// <summary>型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _fullModel = "";

        /// <summary>伝票検索日付</summary>
        /// <remarks>入力日</remarks>
        private DateTime _searchSlipDate;

        /// <summary>計上日付</summary>
        /// <remarks>請求日　(YYYYMMDD)</remarks>
        private DateTime _addUpADate;

        /// <summary>請求先コード</summary>
        private Int32 _claimCode;

        /// <summary>請求先略称</summary>
        private string _claimSnm = "";

        /// <summary>実績計上拠点コード</summary>
        /// <remarks>文字型</remarks>
        private string _resultsAddUpSecCd = "";

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";

        /// <summary>売上金額消費税額</summary>
        private Double _salesPriceConsTax;

        /// <summary>出荷日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _shipmentDay;

        /// <summary>売上入力者コード</summary>
        private string _salesInputCode = "";

        /// <summary>売上入力者名称</summary>
        private string _salesInputName = "";

        /// <summary>消費税転嫁方式</summary>
        private Int32 _consTaxLayMethod;

        /// <summary>総額表示方法区分</summary>
        private Int32 _totalAmountDispWayCd;

        /// <summary>課税区分</summary>
        private Int32 _taxationDivCd;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>BL商品コード名称</summary>
        private string _bLGoodsName = "";

        /// <summary>実績計上拠点名称</summary>
        private string _resultsAddUpSecNm = "";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA ADD START
        /// <summary>標示用行No</summary>
        private Int32 _rowNoView;

        /// <summary>行選択フラグ</summary>
        private bool _selectRowFlag = false;

        /// <summary>メモ存在</summary>
        private string _memoExistsMark = "";

        /// <summary>メモ存在フラグ</summary>
        private bool _memoExistsFlag = false;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA ADD END

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

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
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
        /// <value>伝票№</value>
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

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>受注番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// public propaty name  :  CommonSeqNo
        /// <summary>共通通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   共通通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CommonSeqNo
        {
            get { return _commonSeqNo; }
            set { _commonSeqNo = value; }
        }

        /// public propaty name  :  SalesSlipDtlNum
        /// <summary>売上明細通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上明細通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesSlipDtlNum
        {
            get { return _salesSlipDtlNum; }
            set { _salesSlipDtlNum = value; }
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

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// <value>得意先名</value>
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

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>販売従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>販売従業員名称プロパティ</summary>
        /// <value>担当者名</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }

        /// public propaty name  :  AddresseeName
        /// <summary>納品先名称プロパティ</summary>
        /// <value>納入先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeName
        {
            get { return _addresseeName; }
            set { _addresseeName = value; }
        }

        /// public propaty name  :  AddresseeName2
        /// <summary>納品先名称2プロパティ</summary>
        /// <value>納入先２</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeName2
        {
            get { return _addresseeName2; }
            set { _addresseeName2 = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>受付従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>受付従業員名称プロパティ</summary>
        /// <value>受注者名</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>売上日付プロパティ</summary>
        /// <value>受注日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  SalesDateJpFormal
        /// <summary>売上日付 和暦プロパティ</summary>
        /// <value>受注日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateJpInFormal
        /// <summary>売上日付 和暦(略)プロパティ</summary>
        /// <value>受注日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateAdFormal
        /// <summary>売上日付 西暦プロパティ</summary>
        /// <value>受注日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateAdInFormal
        /// <summary>売上日付 西暦(略)プロパティ</summary>
        /// <value>受注日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// <value>商品コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsNoSrchTyp
        /// <summary>商品番号曖昧検索条件プロパティ</summary>
        /// <value>商品曖昧検索条件</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号曖昧検索条件プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNoSrchTyp
        {
            get { return _goodsNoSrchTyp; }
            set { _goodsNoSrchTyp = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// <value>商品名</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
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

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// <value>メーカー名</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  AcceptAnOrderCnt
        /// <summary>受注数量プロパティ</summary>
        /// <value>受注数</value>
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

        /// public propaty name  :  AcptAnOdrRemainCnt
        /// <summary>受注残数プロパティ</summary>
        /// <value>受注残数</value>
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

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>売上単価（税抜，浮動）プロパティ</summary>
        /// <value>受注単価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
        }

        /// public propaty name  :  PartySlipNumDtl
        /// <summary>相手先伝票番号（明細）プロパティ</summary>
        /// <value>得意先注番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号（明細）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySlipNumDtl
        {
            get { return _partySlipNumDtl; }
            set { _partySlipNumDtl = value; }
        }

        /// public propaty name  :  StdUnPrcSalUnPrc
        /// <summary>基準単価（売上単価）プロパティ</summary>
        /// <value>基準単価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   基準単価（売上単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StdUnPrcSalUnPrc
        {
            get { return _stdUnPrcSalUnPrc; }
            set { _stdUnPrcSalUnPrc = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>原価単価プロパティ</summary>
        /// <value>原価単価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  DtlNote
        /// <summary>明細備考プロパティ</summary>
        /// <value>明細備考</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DtlNote
        {
            get { return _dtlNote; }
            set { _dtlNote = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
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

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// <value>仕入先名</value>
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

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  SlipMemo1
        /// <summary>伝票メモ１プロパティ</summary>
        /// <value>メモ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipMemo1
        {
            get { return _slipMemo1; }
            set { _slipMemo1 = value; }
        }

        /// public propaty name  :  SlipMemo2
        /// <summary>伝票メモ２プロパティ</summary>
        /// <value>メモ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipMemo2
        {
            get { return _slipMemo2; }
            set { _slipMemo2 = value; }
        }

        /// public propaty name  :  SlipMemo3
        /// <summary>伝票メモ３プロパティ</summary>
        /// <value>メモ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipMemo3
        {
            get { return _slipMemo3; }
            set { _slipMemo3 = value; }
        }

        /// public propaty name  :  InsideMemo1
        /// <summary>社内メモ１プロパティ</summary>
        /// <value>メモ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InsideMemo1
        {
            get { return _insideMemo1; }
            set { _insideMemo1 = value; }
        }

        /// public propaty name  :  InsideMemo2
        /// <summary>社内メモ２プロパティ</summary>
        /// <value>メモ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InsideMemo2
        {
            get { return _insideMemo2; }
            set { _insideMemo2 = value; }
        }

        /// public propaty name  :  InsideMemo3
        /// <summary>社内メモ３プロパティ</summary>
        /// <value>メモ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InsideMemo3
        {
            get { return _insideMemo3; }
            set { _insideMemo3 = value; }
        }

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>売上伝票区分（明細）プロパティ</summary>
        /// <value>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分（明細）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>定価（税抜，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>出荷数プロパティ</summary>
        /// <value>売上数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  CarMngCode
        /// <summary>車輌管理コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }

        /// public propaty name  :  ModelDesignationNo
        /// <summary>型式指定番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式指定番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }

        /// public propaty name  :  CategoryNo
        /// <summary>類別番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   類別番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        /// public propaty name  :  ModelFullName
        /// <summary>車種全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>型式（フル型）プロパティ</summary>
        /// <value>フル型式(44桁用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（フル型）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  SearchSlipDate
        /// <summary>伝票検索日付プロパティ</summary>
        /// <value>入力日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SearchSlipDate
        {
            get { return _searchSlipDate; }
            set { _searchSlipDate = value; }
        }

        /// public propaty name  :  SearchSlipDateJpFormal
        /// <summary>伝票検索日付 和暦プロパティ</summary>
        /// <value>入力日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchSlipDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _searchSlipDate); }
            set { }
        }

        /// public propaty name  :  SearchSlipDateJpInFormal
        /// <summary>伝票検索日付 和暦(略)プロパティ</summary>
        /// <value>入力日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchSlipDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _searchSlipDate); }
            set { }
        }

        /// public propaty name  :  SearchSlipDateAdFormal
        /// <summary>伝票検索日付 西暦プロパティ</summary>
        /// <value>入力日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchSlipDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _searchSlipDate); }
            set { }
        }

        /// public propaty name  :  SearchSlipDateAdInFormal
        /// <summary>伝票検索日付 西暦(略)プロパティ</summary>
        /// <value>入力日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchSlipDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _searchSlipDate); }
            set { }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>計上日付プロパティ</summary>
        /// <value>請求日　(YYYYMMDD)</value>
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

        /// public propaty name  :  AddUpADateJpFormal
        /// <summary>計上日付 和暦プロパティ</summary>
        /// <value>請求日　(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpADateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _addUpADate); }
            set { }
        }

        /// public propaty name  :  AddUpADateJpInFormal
        /// <summary>計上日付 和暦(略)プロパティ</summary>
        /// <value>請求日　(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpADateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpADate); }
            set { }
        }

        /// public propaty name  :  AddUpADateAdFormal
        /// <summary>計上日付 西暦プロパティ</summary>
        /// <value>請求日　(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpADateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpADate); }
            set { }
        }

        /// public propaty name  :  AddUpADateAdInFormal
        /// <summary>計上日付 西暦(略)プロパティ</summary>
        /// <value>請求日　(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpADateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _addUpADate); }
            set { }
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

        /// public propaty name  :  ResultsAddUpSecCd
        /// <summary>実績計上拠点コードプロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ResultsAddUpSecCd
        {
            get { return _resultsAddUpSecCd; }
            set { _resultsAddUpSecCd = value; }
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

        /// public propaty name  :  SalesPriceConsTax
        /// <summary>売上金額消費税額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額消費税額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesPriceConsTax
        {
            get { return _salesPriceConsTax; }
            set { _salesPriceConsTax = value; }
        }

        /// public propaty name  :  ShipmentDay
        /// <summary>出荷日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ShipmentDay
        {
            get { return _shipmentDay; }
            set { _shipmentDay = value; }
        }

        /// public propaty name  :  ShipmentDayJpFormal
        /// <summary>出荷日付 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipmentDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _shipmentDay); }
            set { }
        }

        /// public propaty name  :  ShipmentDayJpInFormal
        /// <summary>出荷日付 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipmentDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _shipmentDay); }
            set { }
        }

        /// public propaty name  :  ShipmentDayAdFormal
        /// <summary>出荷日付 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipmentDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _shipmentDay); }
            set { }
        }

        /// public propaty name  :  ShipmentDayAdInFormal
        /// <summary>出荷日付 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipmentDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _shipmentDay); }
            set { }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>売上入力者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  SalesInputName
        /// <summary>売上入力者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputName
        {
            get { return _salesInputName; }
            set { _salesInputName = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>消費税転嫁方式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税転嫁方式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>総額表示方法区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示方法区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>課税区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
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

        /// public propaty name  :  BLGoodsName
        /// <summary>BL商品コード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }

        /// public propaty name  :  ResultsAddUpSecNm
        /// <summary>実績計上拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績計上拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ResultsAddUpSecNm
        {
            get { return _resultsAddUpSecNm; }
            set { _resultsAddUpSecNm = value; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA ADD START

        /// public propaty name  :  RowNoView
        /// <summary>標示用行Noプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標示用行Noプロパティ</br>
        /// </remarks>
        public Int32 RowNoView
        {
            get { return _rowNoView; }
            set { _rowNoView = value; }
        }

        /// public propaty name  :  SelectRowFlag
        /// <summary>行選択フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   行選択フラグプロパティ</br>
        /// </remarks>
        public bool SelectRowFlag
        {
            get { return _selectRowFlag; }
            set { _selectRowFlag = value; }
        }

        /// public propaty name  :  MemoExistsMark
        /// <summary>メモ存在プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メモ存在プロパティ</br>
        /// </remarks>
        public string MemoExistsMark
        {
            get { return _memoExistsMark; }
            set { _memoExistsMark = value; }
        }

        /// public propaty name  :  MemoExistsFlag
        /// <summary>メモ存在フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メモ存在フラグプロパティ</br>
        /// </remarks>
        public bool MemoExistsFlag
        {
            get { return _memoExistsFlag; }
            set { _memoExistsFlag = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA ADD END

        /// <summary>
        /// 受注残照会抽出結果クラスコンストラクタ
        /// </summary>
        /// <returns>AcptAnOdrRemainRefDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcptAnOdrRemainRefDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AcptAnOdrRemainRefData()
        {
        }

        /// <summary>
        /// 受注残照会抽出結果クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号(伝票№)</param>
        /// <param name="acceptAnOrderNo">受注番号</param>
        /// <param name="commonSeqNo">共通通番</param>
        /// <param name="salesSlipDtlNum">売上明細通番</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerSnm">得意先略称(得意先名)</param>
        /// <param name="salesEmployeeCd">販売従業員コード</param>
        /// <param name="salesEmployeeNm">販売従業員名称(担当者名)</param>
        /// <param name="addresseeName">納品先名称(納入先)</param>
        /// <param name="addresseeName2">納品先名称2(納入先２)</param>
        /// <param name="frontEmployeeCd">受付従業員コード</param>
        /// <param name="frontEmployeeNm">受付従業員名称(受注者名)</param>
        /// <param name="salesDate">売上日付(受注日)</param>
        /// <param name="goodsNo">商品番号(商品コード)</param>
        /// <param name="goodsName">商品名称(商品名)</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="makerName">メーカー名称(メーカー名)</param>
        /// <param name="acceptAnOrderCnt">受注数量(受注数)</param>
        /// <param name="acptAnOdrRemainCnt">受注残数(受注残数)</param>
        /// <param name="salesUnPrcTaxExcFl">売上単価（税抜，浮動）(受注単価)</param>
        /// <param name="partySlipNumDtl">相手先伝票番号（明細）(得意先注番)</param>
        /// <param name="stdUnPrcSalUnPrc">基準単価（売上単価）(基準単価)</param>
        /// <param name="salesUnitCost">原価単価(原価単価)</param>
        /// <param name="dtlNote">明細備考(明細備考)</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="supplierSnm">仕入先略称(仕入先名)</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="warehouseName">倉庫名</param>
        /// <param name="slipMemo1">伝票メモ１(メモ)</param>
        /// <param name="slipMemo2">伝票メモ２(メモ)</param>
        /// <param name="slipMemo3">伝票メモ３(メモ)</param>
        /// <param name="insideMemo1">社内メモ１(メモ)</param>
        /// <param name="insideMemo2">社内メモ２(メモ)</param>
        /// <param name="insideMemo3">社内メモ３(メモ)</param>
        /// <param name="salesSlipCdDtl">売上伝票区分（明細）(0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業)</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="listPriceTaxExcFl">定価（税抜，浮動）</param>
        /// <param name="shipmentCnt">出荷数(売上数)</param>
        /// <param name="carMngCode">車輌管理コード</param>
        /// <param name="modelDesignationNo">型式指定番号</param>
        /// <param name="categoryNo">類別番号</param>
        /// <param name="modelFullName">車種全角名称(正式名称（カナ漢字混在で全角管理）)</param>
        /// <param name="fullModel">型式（フル型）(フル型式(44桁用))</param>
        /// <param name="searchSlipDate">伝票検索日付(入力日)</param>
        /// <param name="addUpADate">計上日付(請求日　(YYYYMMDD))</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="claimSnm">請求先略称</param>
        /// <param name="resultsAddUpSecCd">実績計上拠点コード(文字型)</param>
        /// <param name="sectionGuideNm">拠点ガイド名称</param>
        /// <param name="salesPriceConsTax">売上金額消費税額</param>
        /// <param name="shipmentDay">出荷日付(YYYYMMDD)</param>
        /// <param name="salesInputCode">売上入力者コード</param>
        /// <param name="salesInputName">売上入力者名称</param>
        /// <param name="goodsNoSrchTyp"></param>
        /// <param name="consTaxLayMethod">消費税転嫁方式</param>
        /// <param name="totalAmountDispWayCd">総額表示方法区分</param>
        /// <param name="taxationDivCd">課税区分</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        /// <param name="resultsAddUpSecNm">実績計上拠点名称</param>
        /// <param name="rowNoView">標示用行No</param>
        /// <param name="selectRowFlag">行選択フラグ</param>
        /// <param name="memoExistsMark">メモ存在</param>
        /// <param name="memoExistsFlag">メモ存在フラグ</param>
        /// <returns>AcptAnOdrRemainRefDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcptAnOdrRemainRefDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AcptAnOdrRemainRefData(string enterpriseCode, Int32 acptAnOdrStatus, string salesSlipNum, Int32 acceptAnOrderNo, Int64 commonSeqNo, Int64 salesSlipDtlNum, Int32 customerCode, string customerSnm, string salesEmployeeCd, string salesEmployeeNm, string addresseeName, string addresseeName2, string frontEmployeeCd, string frontEmployeeNm, DateTime salesDate, string goodsNo, Int32 goodsNoSrchTyp, string goodsName, Int32 goodsMakerCd, string makerName, Double acceptAnOrderCnt, Double acptAnOdrRemainCnt, Double salesUnPrcTaxExcFl, string partySlipNumDtl, Double stdUnPrcSalUnPrc, Double salesUnitCost, string dtlNote, Int32 supplierCd, string supplierSnm, string warehouseCode, string warehouseName, string slipMemo1, string slipMemo2, string slipMemo3, string insideMemo1, string insideMemo2, string insideMemo3, Int32 salesSlipCdDtl, Int32 bLGoodsCode, Double listPriceTaxExcFl, Double shipmentCnt, string carMngCode, Int32 modelDesignationNo, Int32 categoryNo, string modelFullName, string fullModel, DateTime searchSlipDate, DateTime addUpADate, Int32 claimCode, string claimSnm, string resultsAddUpSecCd, string sectionGuideNm, Double salesPriceConsTax, DateTime shipmentDay, string salesInputCode, string salesInputName, Int32 consTaxLayMethod, Int32 totalAmountDispWayCd, Int32 taxationDivCd, string enterpriseName, string bLGoodsName, string resultsAddUpSecNm, Int32 rowNoView, bool selectRowFlag, string memoExistsMark, bool memoExistsFlag)
        {
            this._enterpriseCode = enterpriseCode;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._salesSlipNum = salesSlipNum;
            this._acceptAnOrderNo = acceptAnOrderNo;
            this._commonSeqNo = commonSeqNo;
            this._salesSlipDtlNum = salesSlipDtlNum;
            this._customerCode = customerCode;
            this._customerSnm = customerSnm;
            this._salesEmployeeCd = salesEmployeeCd;
            this._salesEmployeeNm = salesEmployeeNm;
            this._addresseeName = addresseeName;
            this._addresseeName2 = addresseeName2;
            this._frontEmployeeCd = frontEmployeeCd;
            this._frontEmployeeNm = frontEmployeeNm;
            this.SalesDate = salesDate;
            this._goodsNo = goodsNo;
            this._goodsNoSrchTyp = goodsNoSrchTyp;
            this._goodsName = goodsName;
            this._goodsMakerCd = goodsMakerCd;
            this._makerName = makerName;
            this._acceptAnOrderCnt = acceptAnOrderCnt;
            this._acptAnOdrRemainCnt = acptAnOdrRemainCnt;
            this._salesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
            this._partySlipNumDtl = partySlipNumDtl;
            this._stdUnPrcSalUnPrc = stdUnPrcSalUnPrc;
            this._salesUnitCost = salesUnitCost;
            this._dtlNote = dtlNote;
            this._supplierCd = supplierCd;
            this._supplierSnm = supplierSnm;
            this._warehouseCode = warehouseCode;
            this._warehouseName = warehouseName;
            this._slipMemo1 = slipMemo1;
            this._slipMemo2 = slipMemo2;
            this._slipMemo3 = slipMemo3;
            this._insideMemo1 = insideMemo1;
            this._insideMemo2 = insideMemo2;
            this._insideMemo3 = insideMemo3;
            this._salesSlipCdDtl = salesSlipCdDtl;
            this._bLGoodsCode = bLGoodsCode;
            this._listPriceTaxExcFl = listPriceTaxExcFl;
            this._shipmentCnt = shipmentCnt;
            this._carMngCode = carMngCode;
            this._modelDesignationNo = modelDesignationNo;
            this._categoryNo = categoryNo;
            this._modelFullName = modelFullName;
            this._fullModel = fullModel;
            this.SearchSlipDate = searchSlipDate;
            this.AddUpADate = addUpADate;
            this._claimCode = claimCode;
            this._claimSnm = claimSnm;
            this._resultsAddUpSecCd = resultsAddUpSecCd;
            this._sectionGuideNm = sectionGuideNm;
            this._salesPriceConsTax = salesPriceConsTax;
            this.ShipmentDay = shipmentDay;
            this._salesInputCode = salesInputCode;
            this._salesInputName = salesInputName;
            this._consTaxLayMethod = consTaxLayMethod;
            this._totalAmountDispWayCd = totalAmountDispWayCd;
            this._taxationDivCd = taxationDivCd;
            this._enterpriseName = enterpriseName;
            this._bLGoodsName = bLGoodsName;
            this._resultsAddUpSecNm = resultsAddUpSecNm;
            this._rowNoView = rowNoView;
            this._selectRowFlag = selectRowFlag;
            this._memoExistsMark = memoExistsMark;
            this._memoExistsFlag = memoExistsFlag;
        }

        /// <summary>
        /// 受注残照会抽出結果クラス複製処理
        /// </summary>
        /// <returns>AcptAnOdrRemainRefDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいAcptAnOdrRemainRefDataクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AcptAnOdrRemainRefData Clone()
        {
            return new AcptAnOdrRemainRefData(this._enterpriseCode, this._acptAnOdrStatus, this._salesSlipNum, this._acceptAnOrderNo, this._commonSeqNo, this._salesSlipDtlNum, this._customerCode, this._customerSnm, this._salesEmployeeCd, this._salesEmployeeNm, this._addresseeName, this._addresseeName2, this._frontEmployeeCd, this._frontEmployeeNm, this._salesDate, this._goodsNo, this._goodsNoSrchTyp, this._goodsName, this._goodsMakerCd, this._makerName, this._acceptAnOrderCnt, this._acptAnOdrRemainCnt, this._salesUnPrcTaxExcFl, this._partySlipNumDtl, this._stdUnPrcSalUnPrc, this._salesUnitCost, this._dtlNote, this._supplierCd, this._supplierSnm, this._warehouseCode, this._warehouseName, this._slipMemo1, this._slipMemo2, this._slipMemo3, this._insideMemo1, this._insideMemo2, this._insideMemo3, this._salesSlipCdDtl, this._bLGoodsCode, this._listPriceTaxExcFl, this._shipmentCnt, this._carMngCode, this._modelDesignationNo, this._categoryNo, this._modelFullName, this._fullModel, this._searchSlipDate, this._addUpADate, this._claimCode, this._claimSnm, this._resultsAddUpSecCd, this._sectionGuideNm, this._salesPriceConsTax, this._shipmentDay, this._salesInputCode, this._salesInputName, this._consTaxLayMethod, this.TotalAmountDispWayCd, this.TaxationDivCd, this._enterpriseName, this._bLGoodsName, this._resultsAddUpSecNm, this._rowNoView, this._selectRowFlag, this._memoExistsMark, this._memoExistsFlag);
        }

        /// <summary>
        /// 受注残照会抽出結果クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のAcptAnOdrRemainRefDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcptAnOdrRemainRefDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(AcptAnOdrRemainRefData target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.SalesSlipNum == target.SalesSlipNum)
                 && (this.AcceptAnOrderNo == target.AcceptAnOrderNo)
                 && (this.CommonSeqNo == target.CommonSeqNo)
                 && (this.SalesSlipDtlNum == target.SalesSlipDtlNum)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.SalesEmployeeCd == target.SalesEmployeeCd)
                 && (this.SalesEmployeeNm == target.SalesEmployeeNm)
                 && (this.AddresseeName == target.AddresseeName)
                 && (this.AddresseeName2 == target.AddresseeName2)
                 && (this.FrontEmployeeCd == target.FrontEmployeeCd)
                 && (this.FrontEmployeeNm == target.FrontEmployeeNm)
                 && (this.SalesDate == target.SalesDate)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsNoSrchTyp == target.GoodsNoSrchTyp)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.MakerName == target.MakerName)
                 && (this.AcceptAnOrderCnt == target.AcceptAnOrderCnt)
                 && (this.AcptAnOdrRemainCnt == target.AcptAnOdrRemainCnt)
                 && (this.SalesUnPrcTaxExcFl == target.SalesUnPrcTaxExcFl)
                 && (this.PartySlipNumDtl == target.PartySlipNumDtl)
                 && (this.StdUnPrcSalUnPrc == target.StdUnPrcSalUnPrc)
                 && (this.SalesUnitCost == target.SalesUnitCost)
                 && (this.DtlNote == target.DtlNote)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierSnm == target.SupplierSnm)
                 && (this.WarehouseCode == target.WarehouseCode)
                 && (this.WarehouseName == target.WarehouseName)
                 && (this.SlipMemo1 == target.SlipMemo1)
                 && (this.SlipMemo2 == target.SlipMemo2)
                 && (this.SlipMemo3 == target.SlipMemo3)
                 && (this.InsideMemo1 == target.InsideMemo1)
                 && (this.InsideMemo2 == target.InsideMemo2)
                 && (this.InsideMemo3 == target.InsideMemo3)
                 && (this.SalesSlipCdDtl == target.SalesSlipCdDtl)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.ListPriceTaxExcFl == target.ListPriceTaxExcFl)
                 && (this.ShipmentCnt == target.ShipmentCnt)
                 && (this.CarMngCode == target.CarMngCode)
                 && (this.ModelDesignationNo == target.ModelDesignationNo)
                 && (this.CategoryNo == target.CategoryNo)
                 && (this.ModelFullName == target.ModelFullName)
                 && (this.FullModel == target.FullModel)
                 && (this.SearchSlipDate == target.SearchSlipDate)
                 && (this.AddUpADate == target.AddUpADate)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.ClaimSnm == target.ClaimSnm)
                 && (this.ResultsAddUpSecCd == target.ResultsAddUpSecCd)
                 && (this.SectionGuideNm == target.SectionGuideNm)
                 && (this.SalesPriceConsTax == target.SalesPriceConsTax)
                 && (this.ShipmentDay == target.ShipmentDay)
                 && (this.SalesInputCode == target.SalesInputCode)
                 && (this.SalesInputName == target.SalesInputName)
                 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
                 && (this.TotalAmountDispWayCd == target.TotalAmountDispWayCd)
                 && (this.TaxationDivCd == target.TaxationDivCd)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.ResultsAddUpSecNm == target.ResultsAddUpSecNm)

                 && (this.RowNoView == target.RowNoView)
                 && (this.SelectRowFlag == target.SelectRowFlag)
                 && (this.MemoExistsMark == target.MemoExistsMark)
                 && (this.MemoExistsFlag == target.MemoExistsFlag)
                 );
        }

        /// <summary>
        /// 受注残照会抽出結果クラス比較処理
        /// </summary>
        /// <param name="acptAnOdrRemainRefData1">
        ///                    比較するAcptAnOdrRemainRefDataクラスのインスタンス
        /// </param>
        /// <param name="acptAnOdrRemainRefData2">比較するAcptAnOdrRemainRefDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcptAnOdrRemainRefDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(AcptAnOdrRemainRefData acptAnOdrRemainRefData1, AcptAnOdrRemainRefData acptAnOdrRemainRefData2)
        {
            return ((acptAnOdrRemainRefData1.EnterpriseCode == acptAnOdrRemainRefData2.EnterpriseCode)
                 && (acptAnOdrRemainRefData1.AcptAnOdrStatus == acptAnOdrRemainRefData2.AcptAnOdrStatus)
                 && (acptAnOdrRemainRefData1.SalesSlipNum == acptAnOdrRemainRefData2.SalesSlipNum)
                 && (acptAnOdrRemainRefData1.AcceptAnOrderNo == acptAnOdrRemainRefData2.AcceptAnOrderNo)
                 && (acptAnOdrRemainRefData1.CommonSeqNo == acptAnOdrRemainRefData2.CommonSeqNo)
                 && (acptAnOdrRemainRefData1.SalesSlipDtlNum == acptAnOdrRemainRefData2.SalesSlipDtlNum)
                 && (acptAnOdrRemainRefData1.CustomerCode == acptAnOdrRemainRefData2.CustomerCode)
                 && (acptAnOdrRemainRefData1.CustomerSnm == acptAnOdrRemainRefData2.CustomerSnm)
                 && (acptAnOdrRemainRefData1.SalesEmployeeCd == acptAnOdrRemainRefData2.SalesEmployeeCd)
                 && (acptAnOdrRemainRefData1.SalesEmployeeNm == acptAnOdrRemainRefData2.SalesEmployeeNm)
                 && (acptAnOdrRemainRefData1.AddresseeName == acptAnOdrRemainRefData2.AddresseeName)
                 && (acptAnOdrRemainRefData1.AddresseeName2 == acptAnOdrRemainRefData2.AddresseeName2)
                 && (acptAnOdrRemainRefData1.FrontEmployeeCd == acptAnOdrRemainRefData2.FrontEmployeeCd)
                 && (acptAnOdrRemainRefData1.FrontEmployeeNm == acptAnOdrRemainRefData2.FrontEmployeeNm)
                 && (acptAnOdrRemainRefData1.SalesDate == acptAnOdrRemainRefData2.SalesDate)
                 && (acptAnOdrRemainRefData1.GoodsNo == acptAnOdrRemainRefData2.GoodsNo)
                 && (acptAnOdrRemainRefData1.GoodsNoSrchTyp == acptAnOdrRemainRefData2.GoodsNoSrchTyp)
                 && (acptAnOdrRemainRefData1.GoodsName == acptAnOdrRemainRefData2.GoodsName)
                 && (acptAnOdrRemainRefData1.GoodsMakerCd == acptAnOdrRemainRefData2.GoodsMakerCd)
                 && (acptAnOdrRemainRefData1.MakerName == acptAnOdrRemainRefData2.MakerName)
                 && (acptAnOdrRemainRefData1.AcceptAnOrderCnt == acptAnOdrRemainRefData2.AcceptAnOrderCnt)
                 && (acptAnOdrRemainRefData1.AcptAnOdrRemainCnt == acptAnOdrRemainRefData2.AcptAnOdrRemainCnt)
                 && (acptAnOdrRemainRefData1.SalesUnPrcTaxExcFl == acptAnOdrRemainRefData2.SalesUnPrcTaxExcFl)
                 && (acptAnOdrRemainRefData1.PartySlipNumDtl == acptAnOdrRemainRefData2.PartySlipNumDtl)
                 && (acptAnOdrRemainRefData1.StdUnPrcSalUnPrc == acptAnOdrRemainRefData2.StdUnPrcSalUnPrc)
                 && (acptAnOdrRemainRefData1.SalesUnitCost == acptAnOdrRemainRefData2.SalesUnitCost)
                 && (acptAnOdrRemainRefData1.DtlNote == acptAnOdrRemainRefData2.DtlNote)
                 && (acptAnOdrRemainRefData1.SupplierCd == acptAnOdrRemainRefData2.SupplierCd)
                 && (acptAnOdrRemainRefData1.SupplierSnm == acptAnOdrRemainRefData2.SupplierSnm)
                 && (acptAnOdrRemainRefData1.WarehouseCode == acptAnOdrRemainRefData2.WarehouseCode)
                 && (acptAnOdrRemainRefData1.WarehouseName == acptAnOdrRemainRefData2.WarehouseName)
                 && (acptAnOdrRemainRefData1.SlipMemo1 == acptAnOdrRemainRefData2.SlipMemo1)
                 && (acptAnOdrRemainRefData1.SlipMemo2 == acptAnOdrRemainRefData2.SlipMemo2)
                 && (acptAnOdrRemainRefData1.SlipMemo3 == acptAnOdrRemainRefData2.SlipMemo3)
                 && (acptAnOdrRemainRefData1.InsideMemo1 == acptAnOdrRemainRefData2.InsideMemo1)
                 && (acptAnOdrRemainRefData1.InsideMemo2 == acptAnOdrRemainRefData2.InsideMemo2)
                 && (acptAnOdrRemainRefData1.InsideMemo3 == acptAnOdrRemainRefData2.InsideMemo3)
                 && (acptAnOdrRemainRefData1.SalesSlipCdDtl == acptAnOdrRemainRefData2.SalesSlipCdDtl)
                 && (acptAnOdrRemainRefData1.BLGoodsCode == acptAnOdrRemainRefData2.BLGoodsCode)
                 && (acptAnOdrRemainRefData1.ListPriceTaxExcFl == acptAnOdrRemainRefData2.ListPriceTaxExcFl)
                 && (acptAnOdrRemainRefData1.ShipmentCnt == acptAnOdrRemainRefData2.ShipmentCnt)
                 && (acptAnOdrRemainRefData1.CarMngCode == acptAnOdrRemainRefData2.CarMngCode)
                 && (acptAnOdrRemainRefData1.ModelDesignationNo == acptAnOdrRemainRefData2.ModelDesignationNo)
                 && (acptAnOdrRemainRefData1.CategoryNo == acptAnOdrRemainRefData2.CategoryNo)
                 && (acptAnOdrRemainRefData1.ModelFullName == acptAnOdrRemainRefData2.ModelFullName)
                 && (acptAnOdrRemainRefData1.FullModel == acptAnOdrRemainRefData2.FullModel)
                 && (acptAnOdrRemainRefData1.SearchSlipDate == acptAnOdrRemainRefData2.SearchSlipDate)
                 && (acptAnOdrRemainRefData1.AddUpADate == acptAnOdrRemainRefData2.AddUpADate)
                 && (acptAnOdrRemainRefData1.ClaimCode == acptAnOdrRemainRefData2.ClaimCode)
                 && (acptAnOdrRemainRefData1.ClaimSnm == acptAnOdrRemainRefData2.ClaimSnm)
                 && (acptAnOdrRemainRefData1.ResultsAddUpSecCd == acptAnOdrRemainRefData2.ResultsAddUpSecCd)
                 && (acptAnOdrRemainRefData1.SectionGuideNm == acptAnOdrRemainRefData2.SectionGuideNm)
                 && (acptAnOdrRemainRefData1.SalesPriceConsTax == acptAnOdrRemainRefData2.SalesPriceConsTax)
                 && (acptAnOdrRemainRefData1.ShipmentDay == acptAnOdrRemainRefData2.ShipmentDay)
                 && (acptAnOdrRemainRefData1.SalesInputCode == acptAnOdrRemainRefData2.SalesInputCode)
                 && (acptAnOdrRemainRefData1.SalesInputName == acptAnOdrRemainRefData2.SalesInputName)
                 && (acptAnOdrRemainRefData1.ConsTaxLayMethod == acptAnOdrRemainRefData2.ConsTaxLayMethod)
                 && (acptAnOdrRemainRefData1.TotalAmountDispWayCd == acptAnOdrRemainRefData2.TotalAmountDispWayCd)
                 && (acptAnOdrRemainRefData1.TaxationDivCd == acptAnOdrRemainRefData2.TaxationDivCd)
                 && (acptAnOdrRemainRefData1.EnterpriseName == acptAnOdrRemainRefData2.EnterpriseName)
                 && (acptAnOdrRemainRefData1.BLGoodsName == acptAnOdrRemainRefData2.BLGoodsName)
                 && (acptAnOdrRemainRefData1.ResultsAddUpSecNm == acptAnOdrRemainRefData2.ResultsAddUpSecNm)
                 && (acptAnOdrRemainRefData1.RowNoView == acptAnOdrRemainRefData2.RowNoView)
                 && (acptAnOdrRemainRefData1.SelectRowFlag == acptAnOdrRemainRefData2.SelectRowFlag)
                 && (acptAnOdrRemainRefData1.MemoExistsMark == acptAnOdrRemainRefData2.MemoExistsMark)
                 && (acptAnOdrRemainRefData1.MemoExistsFlag == acptAnOdrRemainRefData2.MemoExistsFlag)
                 );
        }
        /// <summary>
        /// 受注残照会抽出結果クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のAcptAnOdrRemainRefDataクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcptAnOdrRemainRefDataクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(AcptAnOdrRemainRefData target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.AcceptAnOrderNo != target.AcceptAnOrderNo) resList.Add("AcceptAnOrderNo");
            if (this.CommonSeqNo != target.CommonSeqNo) resList.Add("CommonSeqNo");
            if (this.SalesSlipDtlNum != target.SalesSlipDtlNum) resList.Add("SalesSlipDtlNum");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.SalesEmployeeCd != target.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (this.SalesEmployeeNm != target.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (this.AddresseeName != target.AddresseeName) resList.Add("AddresseeName");
            if (this.AddresseeName2 != target.AddresseeName2) resList.Add("AddresseeName2");
            if (this.FrontEmployeeCd != target.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (this.FrontEmployeeNm != target.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
            if (this.SalesDate != target.SalesDate) resList.Add("SalesDate");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsNoSrchTyp != target.GoodsNoSrchTyp) resList.Add("GoodsNoSrchTyp");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.AcceptAnOrderCnt != target.AcceptAnOrderCnt) resList.Add("AcceptAnOrderCnt");
            if (this.AcptAnOdrRemainCnt != target.AcptAnOdrRemainCnt) resList.Add("AcptAnOdrRemainCnt");
            if (this.SalesUnPrcTaxExcFl != target.SalesUnPrcTaxExcFl) resList.Add("SalesUnPrcTaxExcFl");
            if (this.PartySlipNumDtl != target.PartySlipNumDtl) resList.Add("PartySlipNumDtl");
            if (this.StdUnPrcSalUnPrc != target.StdUnPrcSalUnPrc) resList.Add("StdUnPrcSalUnPrc");
            if (this.SalesUnitCost != target.SalesUnitCost) resList.Add("SalesUnitCost");
            if (this.DtlNote != target.DtlNote) resList.Add("DtlNote");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            if (this.WarehouseName != target.WarehouseName) resList.Add("WarehouseName");
            if (this.SlipMemo1 != target.SlipMemo1) resList.Add("SlipMemo1");
            if (this.SlipMemo2 != target.SlipMemo2) resList.Add("SlipMemo2");
            if (this.SlipMemo3 != target.SlipMemo3) resList.Add("SlipMemo3");
            if (this.InsideMemo1 != target.InsideMemo1) resList.Add("InsideMemo1");
            if (this.InsideMemo2 != target.InsideMemo2) resList.Add("InsideMemo2");
            if (this.InsideMemo3 != target.InsideMemo3) resList.Add("InsideMemo3");
            if (this.SalesSlipCdDtl != target.SalesSlipCdDtl) resList.Add("SalesSlipCdDtl");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.ListPriceTaxExcFl != target.ListPriceTaxExcFl) resList.Add("ListPriceTaxExcFl");
            if (this.ShipmentCnt != target.ShipmentCnt) resList.Add("ShipmentCnt");
            if (this.CarMngCode != target.CarMngCode) resList.Add("CarMngCode");
            if (this.ModelDesignationNo != target.ModelDesignationNo) resList.Add("ModelDesignationNo");
            if (this.CategoryNo != target.CategoryNo) resList.Add("CategoryNo");
            if (this.ModelFullName != target.ModelFullName) resList.Add("ModelFullName");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.SearchSlipDate != target.SearchSlipDate) resList.Add("SearchSlipDate");
            if (this.AddUpADate != target.AddUpADate) resList.Add("AddUpADate");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.ClaimSnm != target.ClaimSnm) resList.Add("ClaimSnm");
            if (this.ResultsAddUpSecCd != target.ResultsAddUpSecCd) resList.Add("ResultsAddUpSecCd");
            if (this.SectionGuideNm != target.SectionGuideNm) resList.Add("SectionGuideNm");
            if (this.SalesPriceConsTax != target.SalesPriceConsTax) resList.Add("SalesPriceConsTax");
            if (this.ShipmentDay != target.ShipmentDay) resList.Add("ShipmentDay");
            if (this.SalesInputCode != target.SalesInputCode) resList.Add("SalesInputCode");
            if (this.SalesInputName != target.SalesInputName) resList.Add("SalesInputName");
            if (this.ConsTaxLayMethod != target.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (this.TaxationDivCd != target.TaxationDivCd) resList.Add("TaxationDivCd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            if (this.ResultsAddUpSecNm != target.ResultsAddUpSecNm) resList.Add("ResultsAddUpSecNm");
            if (this.RowNoView != target.RowNoView) resList.Add("RowNoView");
            if (this.SelectRowFlag != target.SelectRowFlag) resList.Add("SelectRowFlag");
            if (this.MemoExistsMark != target.MemoExistsMark) resList.Add("MemoExistsMark");
            if (this.MemoExistsFlag != target.MemoExistsFlag) resList.Add("MemoExistsFlag");

            return resList;
        }

        /// <summary>
        /// 受注残照会抽出結果クラス比較処理
        /// </summary>
        /// <param name="acptAnOdrRemainRefData1">比較するAcptAnOdrRemainRefDataクラスのインスタンス</param>
        /// <param name="acptAnOdrRemainRefData2">比較するAcptAnOdrRemainRefDataクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcptAnOdrRemainRefDataクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(AcptAnOdrRemainRefData acptAnOdrRemainRefData1, AcptAnOdrRemainRefData acptAnOdrRemainRefData2)
        {
            ArrayList resList = new ArrayList();
            if (acptAnOdrRemainRefData1.EnterpriseCode != acptAnOdrRemainRefData2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (acptAnOdrRemainRefData1.AcptAnOdrStatus != acptAnOdrRemainRefData2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (acptAnOdrRemainRefData1.SalesSlipNum != acptAnOdrRemainRefData2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (acptAnOdrRemainRefData1.AcceptAnOrderNo != acptAnOdrRemainRefData2.AcceptAnOrderNo) resList.Add("AcceptAnOrderNo");
            if (acptAnOdrRemainRefData1.CommonSeqNo != acptAnOdrRemainRefData2.CommonSeqNo) resList.Add("CommonSeqNo");
            if (acptAnOdrRemainRefData1.SalesSlipDtlNum != acptAnOdrRemainRefData2.SalesSlipDtlNum) resList.Add("SalesSlipDtlNum");
            if (acptAnOdrRemainRefData1.CustomerCode != acptAnOdrRemainRefData2.CustomerCode) resList.Add("CustomerCode");
            if (acptAnOdrRemainRefData1.CustomerSnm != acptAnOdrRemainRefData2.CustomerSnm) resList.Add("CustomerSnm");
            if (acptAnOdrRemainRefData1.SalesEmployeeCd != acptAnOdrRemainRefData2.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (acptAnOdrRemainRefData1.SalesEmployeeNm != acptAnOdrRemainRefData2.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (acptAnOdrRemainRefData1.AddresseeName != acptAnOdrRemainRefData2.AddresseeName) resList.Add("AddresseeName");
            if (acptAnOdrRemainRefData1.AddresseeName2 != acptAnOdrRemainRefData2.AddresseeName2) resList.Add("AddresseeName2");
            if (acptAnOdrRemainRefData1.FrontEmployeeCd != acptAnOdrRemainRefData2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (acptAnOdrRemainRefData1.FrontEmployeeNm != acptAnOdrRemainRefData2.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
            if (acptAnOdrRemainRefData1.SalesDate != acptAnOdrRemainRefData2.SalesDate) resList.Add("SalesDate");
            if (acptAnOdrRemainRefData1.GoodsNo != acptAnOdrRemainRefData2.GoodsNo) resList.Add("GoodsNo");
            if (acptAnOdrRemainRefData1.GoodsNoSrchTyp != acptAnOdrRemainRefData2.GoodsNoSrchTyp) resList.Add("GoodsNoSrchTyp");
            if (acptAnOdrRemainRefData1.GoodsName != acptAnOdrRemainRefData2.GoodsName) resList.Add("GoodsName");
            if (acptAnOdrRemainRefData1.GoodsMakerCd != acptAnOdrRemainRefData2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (acptAnOdrRemainRefData1.MakerName != acptAnOdrRemainRefData2.MakerName) resList.Add("MakerName");
            if (acptAnOdrRemainRefData1.AcceptAnOrderCnt != acptAnOdrRemainRefData2.AcceptAnOrderCnt) resList.Add("AcceptAnOrderCnt");
            if (acptAnOdrRemainRefData1.AcptAnOdrRemainCnt != acptAnOdrRemainRefData2.AcptAnOdrRemainCnt) resList.Add("AcptAnOdrRemainCnt");
            if (acptAnOdrRemainRefData1.SalesUnPrcTaxExcFl != acptAnOdrRemainRefData2.SalesUnPrcTaxExcFl) resList.Add("SalesUnPrcTaxExcFl");
            if (acptAnOdrRemainRefData1.PartySlipNumDtl != acptAnOdrRemainRefData2.PartySlipNumDtl) resList.Add("PartySlipNumDtl");
            if (acptAnOdrRemainRefData1.StdUnPrcSalUnPrc != acptAnOdrRemainRefData2.StdUnPrcSalUnPrc) resList.Add("StdUnPrcSalUnPrc");
            if (acptAnOdrRemainRefData1.SalesUnitCost != acptAnOdrRemainRefData2.SalesUnitCost) resList.Add("SalesUnitCost");
            if (acptAnOdrRemainRefData1.DtlNote != acptAnOdrRemainRefData2.DtlNote) resList.Add("DtlNote");
            if (acptAnOdrRemainRefData1.SupplierCd != acptAnOdrRemainRefData2.SupplierCd) resList.Add("SupplierCd");
            if (acptAnOdrRemainRefData1.SupplierSnm != acptAnOdrRemainRefData2.SupplierSnm) resList.Add("SupplierSnm");
            if (acptAnOdrRemainRefData1.WarehouseCode != acptAnOdrRemainRefData2.WarehouseCode) resList.Add("WarehouseCode");
            if (acptAnOdrRemainRefData1.WarehouseName != acptAnOdrRemainRefData2.WarehouseName) resList.Add("WarehouseName");
            if (acptAnOdrRemainRefData1.SlipMemo1 != acptAnOdrRemainRefData2.SlipMemo1) resList.Add("SlipMemo1");
            if (acptAnOdrRemainRefData1.SlipMemo2 != acptAnOdrRemainRefData2.SlipMemo2) resList.Add("SlipMemo2");
            if (acptAnOdrRemainRefData1.SlipMemo3 != acptAnOdrRemainRefData2.SlipMemo3) resList.Add("SlipMemo3");
            if (acptAnOdrRemainRefData1.InsideMemo1 != acptAnOdrRemainRefData2.InsideMemo1) resList.Add("InsideMemo1");
            if (acptAnOdrRemainRefData1.InsideMemo2 != acptAnOdrRemainRefData2.InsideMemo2) resList.Add("InsideMemo2");
            if (acptAnOdrRemainRefData1.InsideMemo3 != acptAnOdrRemainRefData2.InsideMemo3) resList.Add("InsideMemo3");
            if (acptAnOdrRemainRefData1.SalesSlipCdDtl != acptAnOdrRemainRefData2.SalesSlipCdDtl) resList.Add("SalesSlipCdDtl");
            if (acptAnOdrRemainRefData1.BLGoodsCode != acptAnOdrRemainRefData2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (acptAnOdrRemainRefData1.ListPriceTaxExcFl != acptAnOdrRemainRefData2.ListPriceTaxExcFl) resList.Add("ListPriceTaxExcFl");
            if (acptAnOdrRemainRefData1.ShipmentCnt != acptAnOdrRemainRefData2.ShipmentCnt) resList.Add("ShipmentCnt");
            if (acptAnOdrRemainRefData1.CarMngCode != acptAnOdrRemainRefData2.CarMngCode) resList.Add("CarMngCode");
            if (acptAnOdrRemainRefData1.ModelDesignationNo != acptAnOdrRemainRefData2.ModelDesignationNo) resList.Add("ModelDesignationNo");
            if (acptAnOdrRemainRefData1.CategoryNo != acptAnOdrRemainRefData2.CategoryNo) resList.Add("CategoryNo");
            if (acptAnOdrRemainRefData1.ModelFullName != acptAnOdrRemainRefData2.ModelFullName) resList.Add("ModelFullName");
            if (acptAnOdrRemainRefData1.FullModel != acptAnOdrRemainRefData2.FullModel) resList.Add("FullModel");
            if (acptAnOdrRemainRefData1.SearchSlipDate != acptAnOdrRemainRefData2.SearchSlipDate) resList.Add("SearchSlipDate");
            if (acptAnOdrRemainRefData1.AddUpADate != acptAnOdrRemainRefData2.AddUpADate) resList.Add("AddUpADate");
            if (acptAnOdrRemainRefData1.ClaimCode != acptAnOdrRemainRefData2.ClaimCode) resList.Add("ClaimCode");
            if (acptAnOdrRemainRefData1.ClaimSnm != acptAnOdrRemainRefData2.ClaimSnm) resList.Add("ClaimSnm");
            if (acptAnOdrRemainRefData1.ResultsAddUpSecCd != acptAnOdrRemainRefData2.ResultsAddUpSecCd) resList.Add("ResultsAddUpSecCd");
            if (acptAnOdrRemainRefData1.SectionGuideNm != acptAnOdrRemainRefData2.SectionGuideNm) resList.Add("SectionGuideNm");
            if (acptAnOdrRemainRefData1.SalesPriceConsTax != acptAnOdrRemainRefData2.SalesPriceConsTax) resList.Add("SalesPriceConsTax");
            if (acptAnOdrRemainRefData1.ShipmentDay != acptAnOdrRemainRefData2.ShipmentDay) resList.Add("ShipmentDay");
            if (acptAnOdrRemainRefData1.SalesInputCode != acptAnOdrRemainRefData2.SalesInputCode) resList.Add("SalesInputCode");
            if (acptAnOdrRemainRefData1.SalesInputName != acptAnOdrRemainRefData2.SalesInputName) resList.Add("SalesInputName");
            if (acptAnOdrRemainRefData1.ConsTaxLayMethod != acptAnOdrRemainRefData2.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (acptAnOdrRemainRefData1.TotalAmountDispWayCd != acptAnOdrRemainRefData2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (acptAnOdrRemainRefData1.TaxationDivCd != acptAnOdrRemainRefData2.TaxationDivCd) resList.Add("TaxationDivCd");
            if (acptAnOdrRemainRefData1.EnterpriseName != acptAnOdrRemainRefData2.EnterpriseName) resList.Add("EnterpriseName");
            if (acptAnOdrRemainRefData1.BLGoodsName != acptAnOdrRemainRefData2.BLGoodsName) resList.Add("BLGoodsName");
            if (acptAnOdrRemainRefData1.ResultsAddUpSecNm != acptAnOdrRemainRefData2.ResultsAddUpSecNm) resList.Add("ResultsAddUpSecNm");
            if (acptAnOdrRemainRefData1.RowNoView != acptAnOdrRemainRefData2.RowNoView) resList.Add("RowNoView");
            if (acptAnOdrRemainRefData1.SelectRowFlag != acptAnOdrRemainRefData2.SelectRowFlag) resList.Add("SelectRowFlag");
            if (acptAnOdrRemainRefData1.MemoExistsMark != acptAnOdrRemainRefData2.MemoExistsMark) resList.Add("MemoExistsMark");
            if (acptAnOdrRemainRefData1.MemoExistsFlag != acptAnOdrRemainRefData2.MemoExistsFlag) resList.Add("MemoExistsFlag");
            return resList;
        }
    }
}
