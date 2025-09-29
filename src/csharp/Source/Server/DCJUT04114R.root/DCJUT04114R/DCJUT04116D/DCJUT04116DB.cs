using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   AcptAnOdrRemainRefDataWork
    /// <summary>
    ///                      受注残照会抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   受注残照会抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class AcptAnOdrRemainRefDataWork
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
        private Int64 _salesPriceConsTax;

        /// <summary>出荷日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _shipmentDay;

        /// <summary>売上入力者コード</summary>
        private string _salesInputCode = "";

        /// <summary>売上入力者名称</summary>
        private string _salesInputName = "";

        /// <summary>消費税転嫁方式</summary>
        /// <remarks>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _taxationDivCd;

        /// <summary>売上行番号</summary>
        private Int32 _salesRowNo;


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
        public Int64 SalesPriceConsTax
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
        /// <value>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</value>
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
        /// <value>0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
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
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
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

        /// public propaty name  :  SalesRowNo
        /// <summary>売上行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesRowNo
        {
            get { return _salesRowNo; }
            set { _salesRowNo = value; }
        }


        /// <summary>
        /// 受注残照会抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>AcptAnOdrRemainRefDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcptAnOdrRemainRefDataWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AcptAnOdrRemainRefDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>AcptAnOdrRemainRefDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   AcptAnOdrRemainRefDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class AcptAnOdrRemainRefDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcptAnOdrRemainRefDataWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  AcptAnOdrRemainRefDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is AcptAnOdrRemainRefDataWork || graph is ArrayList || graph is AcptAnOdrRemainRefDataWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(AcptAnOdrRemainRefDataWork).FullName));

            if (graph != null && graph is AcptAnOdrRemainRefDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AcptAnOdrRemainRefDataWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is AcptAnOdrRemainRefDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((AcptAnOdrRemainRefDataWork[])graph).Length;
            }
            else if (graph is AcptAnOdrRemainRefDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //受注番号
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptAnOrderNo
            //共通通番
            serInfo.MemberInfo.Add(typeof(Int64)); //CommonSeqNo
            //売上明細通番
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNum
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //販売従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeCd
            //販売従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeNm
            //納品先名称
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName
            //納品先名称2
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName2
            //受付従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeCd
            //受付従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeNm
            //売上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //受注数量
            serInfo.MemberInfo.Add(typeof(Double)); //AcceptAnOrderCnt
            //受注残数
            serInfo.MemberInfo.Add(typeof(Double)); //AcptAnOdrRemainCnt
            //売上単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //相手先伝票番号（明細）
            serInfo.MemberInfo.Add(typeof(string)); //PartySlipNumDtl
            //基準単価（売上単価）
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcSalUnPrc
            //原価単価
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //明細備考
            serInfo.MemberInfo.Add(typeof(string)); //DtlNote
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //伝票メモ１
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo1
            //伝票メモ２
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo2
            //伝票メモ３
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo3
            //社内メモ１
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo1
            //社内メモ２
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo2
            //社内メモ３
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo3
            //売上伝票区分（明細）
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCdDtl
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //定価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //車輌管理コード
            serInfo.MemberInfo.Add(typeof(string)); //CarMngCode
            //型式指定番号
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
            //類別番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
            //車種全角名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelFullName
            //型式（フル型）
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //伝票検索日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchSlipDate
            //計上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //請求先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //請求先略称
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //実績計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ResultsAddUpSecCd
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //売上金額消費税額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesPriceConsTax
            //出荷日付
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentDay
            //売上入力者コード
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputCode
            //売上入力者名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputName
            //消費税転嫁方式
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //総額表示方法区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalAmountDispWayCd
            //課税区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //売上行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo


            serInfo.Serialize(writer, serInfo);
            if (graph is AcptAnOdrRemainRefDataWork)
            {
                AcptAnOdrRemainRefDataWork temp = (AcptAnOdrRemainRefDataWork)graph;

                SetAcptAnOdrRemainRefDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is AcptAnOdrRemainRefDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((AcptAnOdrRemainRefDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (AcptAnOdrRemainRefDataWork temp in lst)
                {
                    SetAcptAnOdrRemainRefDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// AcptAnOdrRemainRefDataWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 59;

        /// <summary>
        ///  AcptAnOdrRemainRefDataWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcptAnOdrRemainRefDataWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetAcptAnOdrRemainRefDataWork(System.IO.BinaryWriter writer, AcptAnOdrRemainRefDataWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //受注番号
            writer.Write(temp.AcceptAnOrderNo);
            //共通通番
            writer.Write(temp.CommonSeqNo);
            //売上明細通番
            writer.Write(temp.SalesSlipDtlNum);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //販売従業員コード
            writer.Write(temp.SalesEmployeeCd);
            //販売従業員名称
            writer.Write(temp.SalesEmployeeNm);
            //納品先名称
            writer.Write(temp.AddresseeName);
            //納品先名称2
            writer.Write(temp.AddresseeName2);
            //受付従業員コード
            writer.Write(temp.FrontEmployeeCd);
            //受付従業員名称
            writer.Write(temp.FrontEmployeeNm);
            //売上日付
            writer.Write((Int64)temp.SalesDate.Ticks);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //受注数量
            writer.Write(temp.AcceptAnOrderCnt);
            //受注残数
            writer.Write(temp.AcptAnOdrRemainCnt);
            //売上単価（税抜，浮動）
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //相手先伝票番号（明細）
            writer.Write(temp.PartySlipNumDtl);
            //基準単価（売上単価）
            writer.Write(temp.StdUnPrcSalUnPrc);
            //原価単価
            writer.Write(temp.SalesUnitCost);
            //明細備考
            writer.Write(temp.DtlNote);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名
            writer.Write(temp.WarehouseName);
            //伝票メモ１
            writer.Write(temp.SlipMemo1);
            //伝票メモ２
            writer.Write(temp.SlipMemo2);
            //伝票メモ３
            writer.Write(temp.SlipMemo3);
            //社内メモ１
            writer.Write(temp.InsideMemo1);
            //社内メモ２
            writer.Write(temp.InsideMemo2);
            //社内メモ３
            writer.Write(temp.InsideMemo3);
            //売上伝票区分（明細）
            writer.Write(temp.SalesSlipCdDtl);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //定価（税抜，浮動）
            writer.Write(temp.ListPriceTaxExcFl);
            //出荷数
            writer.Write(temp.ShipmentCnt);
            //車輌管理コード
            writer.Write(temp.CarMngCode);
            //型式指定番号
            writer.Write(temp.ModelDesignationNo);
            //類別番号
            writer.Write(temp.CategoryNo);
            //車種全角名称
            writer.Write(temp.ModelFullName);
            //型式（フル型）
            writer.Write(temp.FullModel);
            //伝票検索日付
            writer.Write((Int64)temp.SearchSlipDate.Ticks);
            //計上日付
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //請求先コード
            writer.Write(temp.ClaimCode);
            //請求先略称
            writer.Write(temp.ClaimSnm);
            //実績計上拠点コード
            writer.Write(temp.ResultsAddUpSecCd);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //売上金額消費税額
            writer.Write(temp.SalesPriceConsTax);
            //出荷日付
            writer.Write((Int64)temp.ShipmentDay.Ticks);
            //売上入力者コード
            writer.Write(temp.SalesInputCode);
            //売上入力者名称
            writer.Write(temp.SalesInputName);
            //消費税転嫁方式
            writer.Write(temp.ConsTaxLayMethod);
            //総額表示方法区分
            writer.Write(temp.TotalAmountDispWayCd);
            //課税区分
            writer.Write(temp.TaxationDivCd);
            //売上行番号
            writer.Write(temp.SalesRowNo);

        }

        /// <summary>
        ///  AcptAnOdrRemainRefDataWorkインスタンス取得
        /// </summary>
        /// <returns>AcptAnOdrRemainRefDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcptAnOdrRemainRefDataWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private AcptAnOdrRemainRefDataWork GetAcptAnOdrRemainRefDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            AcptAnOdrRemainRefDataWork temp = new AcptAnOdrRemainRefDataWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //受注番号
            temp.AcceptAnOrderNo = reader.ReadInt32();
            //共通通番
            temp.CommonSeqNo = reader.ReadInt64();
            //売上明細通番
            temp.SalesSlipDtlNum = reader.ReadInt64();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //販売従業員コード
            temp.SalesEmployeeCd = reader.ReadString();
            //販売従業員名称
            temp.SalesEmployeeNm = reader.ReadString();
            //納品先名称
            temp.AddresseeName = reader.ReadString();
            //納品先名称2
            temp.AddresseeName2 = reader.ReadString();
            //受付従業員コード
            temp.FrontEmployeeCd = reader.ReadString();
            //受付従業員名称
            temp.FrontEmployeeNm = reader.ReadString();
            //売上日付
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //受注数量
            temp.AcceptAnOrderCnt = reader.ReadDouble();
            //受注残数
            temp.AcptAnOdrRemainCnt = reader.ReadDouble();
            //売上単価（税抜，浮動）
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //相手先伝票番号（明細）
            temp.PartySlipNumDtl = reader.ReadString();
            //基準単価（売上単価）
            temp.StdUnPrcSalUnPrc = reader.ReadDouble();
            //原価単価
            temp.SalesUnitCost = reader.ReadDouble();
            //明細備考
            temp.DtlNote = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名
            temp.WarehouseName = reader.ReadString();
            //伝票メモ１
            temp.SlipMemo1 = reader.ReadString();
            //伝票メモ２
            temp.SlipMemo2 = reader.ReadString();
            //伝票メモ３
            temp.SlipMemo3 = reader.ReadString();
            //社内メモ１
            temp.InsideMemo1 = reader.ReadString();
            //社内メモ２
            temp.InsideMemo2 = reader.ReadString();
            //社内メモ３
            temp.InsideMemo3 = reader.ReadString();
            //売上伝票区分（明細）
            temp.SalesSlipCdDtl = reader.ReadInt32();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //定価（税抜，浮動）
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //出荷数
            temp.ShipmentCnt = reader.ReadDouble();
            //車輌管理コード
            temp.CarMngCode = reader.ReadString();
            //型式指定番号
            temp.ModelDesignationNo = reader.ReadInt32();
            //類別番号
            temp.CategoryNo = reader.ReadInt32();
            //車種全角名称
            temp.ModelFullName = reader.ReadString();
            //型式（フル型）
            temp.FullModel = reader.ReadString();
            //伝票検索日付
            temp.SearchSlipDate = new DateTime(reader.ReadInt64());
            //計上日付
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //請求先コード
            temp.ClaimCode = reader.ReadInt32();
            //請求先略称
            temp.ClaimSnm = reader.ReadString();
            //実績計上拠点コード
            temp.ResultsAddUpSecCd = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //売上金額消費税額
            temp.SalesPriceConsTax = reader.ReadInt64();
            //出荷日付
            temp.ShipmentDay = new DateTime(reader.ReadInt64());
            //売上入力者コード
            temp.SalesInputCode = reader.ReadString();
            //売上入力者名称
            temp.SalesInputName = reader.ReadString();
            //消費税転嫁方式
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //総額表示方法区分
            temp.TotalAmountDispWayCd = reader.ReadInt32();
            //課税区分
            temp.TaxationDivCd = reader.ReadInt32();
            //売上行番号
            temp.SalesRowNo = reader.ReadInt32();


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
        /// <returns>AcptAnOdrRemainRefDataWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcptAnOdrRemainRefDataWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                AcptAnOdrRemainRefDataWork temp = GetAcptAnOdrRemainRefDataWork(reader, serInfo);
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
                    retValue = (AcptAnOdrRemainRefDataWork[])lst.ToArray(typeof(AcptAnOdrRemainRefDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}