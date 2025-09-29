using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesConfWork
    /// <summary>
    ///                      売上確認表抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上確認表抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/31  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note      :   2010/06/29 30517 夏野 駿希</br>
    /// <br>                     Mantis.15691　車種名の印字を車種全角名称から車種半角名称へ変更する。</br>
    /// <br></br>
    /// <br>Update Note      :   2010/07/14 30531 大矢 睦美</br>
    /// <br>                 :   Mantis【15806】  品名に品名カナをセットするように修正</br>
    /// <br>Update Note      :   2011/07/18 施健</br>
    /// <br>                 :   「SCM回答マーク印字区分」、「通常発行マーク」、「SCM手動回答マーク」、「SCM自動回答マーク」、「自動回答区分(SCM)」を追加する</br>
    /// <br>Update Note      :   2011/11/29 陳建明</br>
    /// <br>                 :   障害報告 #8076売上確認表/訂正伝票と削除伝票の区別についての対応</br>
    /// <br>Update Note      :   2020/02/27 3H 尹安</br>
    /// <br>管理番号         :   11570208-00 </br>
    /// <br>                 :   軽減税率対応</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesConfWork
    {
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>部門名称</summary>
        private string _subSectionName = "";

        /// <summary>売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼る</remarks>
        private string _salesSlipNum = "";

        /// <summary>請求先コード</summary>
        private Int32 _claimCode;

        /// <summary>請求先略称</summary>
        private string _claimSnm = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>出荷日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _shipmentDay;

        /// <summary>売上日付</summary>
        /// <remarks>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        /// <summary>計上日付</summary>
        /// <remarks>請求日　(YYYYMMDD)</remarks>
        private DateTime _addUpADate;

        /// <summary>売上伝票区分</summary>
        /// <remarks>0:売上,1:返品</remarks>
        private Int32 _salesSlipCd;

        /// <summary>売掛区分</summary>
        /// <remarks>0:売掛なし,1:売掛</remarks>
        private Int32 _accRecDivCd;

        /// <summary>売上入力者コード</summary>
        /// <remarks>入力担当者（発行者）</remarks>
        private string _salesInputCode = "";

        /// <summary>売上入力者名称</summary>
        private string _salesInputName = "";

        /// <summary>受付従業員コード</summary>
        /// <remarks>受付担当者（受注者）</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>受付従業員名称</summary>
        private string _frontEmployeeNm = "";

        /// <summary>販売従業員コード</summary>
        /// <remarks>計上担当者（担当者）</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>販売従業員名称</summary>
        private string _salesEmployeeNm = "";

        /// <summary>相手先伝票番号</summary>
        /// <remarks>得意先注文番号（仮伝番号）</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>売上伝票合計（税込み）</summary>
        /// <remarks>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</remarks>
        private Int64 _salesTotalTaxInc;

        /// <summary>売上伝票合計（税抜き）</summary>
        /// <remarks>売上正価金額＋売上値引金額計（税抜き）</remarks>
        private Int64 _salesTotalTaxExc;

        /// <summary>原価金額計</summary>
        private Int64 _totalCost;

        /// <summary>返品理由コード</summary>
        private Int32 _retGoodsReasonDiv;

        /// <summary>返品理由</summary>
        private string _retGoodsReason = "";

        /// <summary>得意先伝票番号</summary>
        private Int32 _custSlipNo;

        /// <summary>伝票備考</summary>
        private string _slipNote = "";

        /// <summary>伝票備考２</summary>
        private string _slipNote2 = "";

        /// <summary>伝票備考３</summary>
        private string _slipNote3 = "";

        /// <summary>業種コード</summary>
        private Int32 _businessTypeCode;

        /// <summary>業種名称</summary>
        private string _businessTypeName = "";

        /// <summary>販売エリアコード</summary>
        /// <remarks>地区コード</remarks>
        private Int32 _salesAreaCode;

        /// <summary>販売エリア名称</summary>
        private string _salesAreaName = "";

        /// <summary>ＵＯＥリマーク１</summary>
        /// <remarks>UserOrderEntory</remarks>
        private string _uoeRemark1 = "";

        /// <summary>ＵＯＥリマーク２</summary>
        private string _uoeRemark2 = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";

        /// <summary>売上在庫取寄せ区分</summary>
        /// <remarks>0:取寄せ，1:在庫</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>定価（税込，浮動）</summary>
        /// <remarks>税抜き</remarks>
        private Double _listPriceTaxIncFl;

        /// <summary>定価（税抜，浮動）</summary>
        /// <remarks>税込み</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>売価率</summary>
        private Double _salesRate;

        /// <summary>出荷数</summary>
        private Double _shipmentCnt;

        /// <summary>原価単価</summary>
        private Double _salesUnitCost;

        /// <summary>売上単価（税込，浮動）</summary>
        private Double _salesUnPrcTaxIncFl;

        /// <summary>売上単価（税抜，浮動）</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>原価</summary>
        private Int64 _cost;

        /// <summary>売上金額（税込み）</summary>
        private Int64 _salesMoneyTaxInc;

        /// <summary>売上金額（税抜き）</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>仕入伝票番号</summary>
        /// <remarks>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる。（未発注はゼロ）</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>販売区分コード</summary>
        private Int32 _salesCode;

        /// <summary>販売区分名称</summary>
        private string _salesCdNm = "";

        /// <summary>車種全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _modelFullName = "";

        /// <summary>型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _fullModel = "";

        /// <summary>型式指定番号</summary>
        private Int32 _modelDesignationNo;

        /// <summary>類別番号</summary>
        private Int32 _categoryNo;

        /// <summary>車輌管理コード</summary>
        /// <remarks>※PM7での車両管理番号</remarks>
        private string _carMngCode = "";

        /// <summary>初年度</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _firstEntryDate;

        /// <summary>取引区分名[伝票]</summary>
        private string _transactionName = "";

        /// <summary>粗利率[伝票]</summary>
        private Double _grossMarginRate;

        /// <summary>粗利チェックマーク[伝票]</summary>
        private string _grossMarginMarkSlip = "";

        /// <summary>粗利率[明細]</summary>
        private Double _grossMarginRateDtl;

        /// <summary>粗利チェックマーク[明細]</summary>
        private string _grossMarginMarkDtl = "";

        /// <summary>売上伝票区分（明細）</summary>
        /// <remarks>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</remarks>
        private Int32 _salesSlipCdDtl;

        /// <summary>売上値引金額計（税抜き）</summary>
        private Int64 _salesDisTtlTaxExc;

        /// <summary>売上行番号</summary>
        private Int32 _salesRowNo;

        /// <summary>伝票検索日付</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _searchSlipDate;

        /// <summary>消費税転嫁方式[伝票]</summary>
        /// <remarks>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>総額表示方法区分[伝票]</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>課税区分[明細]</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _taxationDivCd;

        /// <summary>売上金額消費税額（内税）[伝票]</summary>
        /// <remarks>値引前の内税商品の消費税</remarks>
        private Int64 _salAmntConsTaxInclu;

        /// <summary>売上値引消費税額（内税）[伝票]</summary>
        private Int64 _salesDisTtlTaxInclu;

        /// <summary>売上値引消費税額（外税）[伝票]</summary>
        /// <remarks>外税商品値引の消費税額</remarks>
        private Int64 _salesDisOutTax;

        /// <summary>原価金額(値引)</summary>
        private Int64 _disCost;

        /// <summary>相手先伝票番号</summary>
        /// <remarks>仕入先伝票番号に使用する</remarks>
        private string _partySaleSlipNumStock = "";

        // 2010/06/29 Add >>>
        /// <summary>車種半角名称</summary>
        private string _modelHalfName = "";
        // 2010/06/29 Add <<<
        // --- ADD  大矢睦美  2010/07/14 ---------->>>>>
        /// <summary>商品名称カナ</summary>
        private string _goodsNameKana = "";
        // --- ADD  大矢睦美  2010/07/14 ----------<<<<<

        // --- ADD  施健  2011/07/18 ---------->>>>>
        /// <summary>SCM回答マーク印字区分</summary>
        /// <remarks>0:しない,1:する</remarks>
        private Int32 _sCMAnsMarkPrtDiv;

        /// <summary>通常発行マーク</summary>
        private string _normalPrtMark = "";

        /// <summary>SCM手動回答マーク</summary>
        private string _sCMManualAnsMark = "";

        /// <summary>SCM自動回答マーク</summary>
        private string _sCMAutoAnsMark = "";

        /// <summary>自動回答区分(SCM)</summary>
        /// <remarks>0:通常(PCC連携なし)、1:手動回答、2:自動回答</remarks>
        private Int32 _autoAnswerDivSCM;
        // --- ADD  施健  2011/07/18 ----------<<<<<

        // --- ADD  陳建明  2010/11/29--------->>>>>>
        /// <summary>削除区分</summary>
        /// <remarks>0:未削除、1:削除</remarks>
        private Int32 _logicalDeleteCode;

        // ----- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
        /// <summary>売上金額非課税</summary>
        private Int64 _salesMoneyTaxFreeCdrf;

        /// <summary>売上明細課税存在フラグ</summary>
        private bool _taxRateExistFlag;

        /// <summary>売上明細非課税存在フラグ</summary>
        private bool _taxFreeExistFlag;
        // ----- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<

        
        // --- ADD  陳建明  2010/11/29---------<<<<<<
        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
        /// <summary>消費税税率</summary>
        private Double _consTaxRate;

        /// public propaty name  :  SectionCode
        /// <summary>消費税税率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税税率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ConsTaxRate
        {
            get { return _consTaxRate; }
            set { _consTaxRate = value; }
        }
        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
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

        /// public propaty name  :  SubSectionName
        /// <summary>部門名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SubSectionName
        {
            get { return _subSectionName; }
            set { _subSectionName = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼る</value>
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

        /// public propaty name  :  SalesDate
        /// <summary>売上日付プロパティ</summary>
        /// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
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

        /// public propaty name  :  SalesSlipCd
        /// <summary>売上伝票区分プロパティ</summary>
        /// <value>0:売上,1:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>売掛区分プロパティ</summary>
        /// <value>0:売掛なし,1:売掛</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売掛区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>売上入力者コードプロパティ</summary>
        /// <value>入力担当者（発行者）</value>
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

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>受付従業員コードプロパティ</summary>
        /// <value>受付担当者（受注者）</value>
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

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>販売従業員コードプロパティ</summary>
        /// <value>計上担当者（担当者）</value>
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

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>相手先伝票番号プロパティ</summary>
        /// <value>得意先注文番号（仮伝番号）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  SalesTotalTaxInc
        /// <summary>売上伝票合計（税込み）プロパティ</summary>
        /// <value>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票合計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTotalTaxInc
        {
            get { return _salesTotalTaxInc; }
            set { _salesTotalTaxInc = value; }
        }

        /// public propaty name  :  SalesTotalTaxExc
        /// <summary>売上伝票合計（税抜き）プロパティ</summary>
        /// <value>売上正価金額＋売上値引金額計（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票合計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTotalTaxExc
        {
            get { return _salesTotalTaxExc; }
            set { _salesTotalTaxExc = value; }
        }

        /// public propaty name  :  TotalCost
        /// <summary>原価金額計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価金額計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        /// public propaty name  :  RetGoodsReasonDiv
        /// <summary>返品理由コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品理由コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RetGoodsReasonDiv
        {
            get { return _retGoodsReasonDiv; }
            set { _retGoodsReasonDiv = value; }
        }

        /// public propaty name  :  RetGoodsReason
        /// <summary>返品理由プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品理由プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RetGoodsReason
        {
            get { return _retGoodsReason; }
            set { _retGoodsReason = value; }
        }

        /// public propaty name  :  CustSlipNo
        /// <summary>得意先伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustSlipNo
        {
            get { return _custSlipNo; }
            set { _custSlipNo = value; }
        }

        /// public propaty name  :  SlipNote
        /// <summary>伝票備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
        }

        /// public propaty name  :  SlipNote2
        /// <summary>伝票備考２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote2
        {
            get { return _slipNote2; }
            set { _slipNote2 = value; }
        }

        /// public propaty name  :  SlipNote3
        /// <summary>伝票備考３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote3
        {
            get { return _slipNote3; }
            set { _slipNote3 = value; }
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

        /// public propaty name  :  SalesAreaCode
        /// <summary>販売エリアコードプロパティ</summary>
        /// <value>地区コード</value>
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

        /// public propaty name  :  UoeRemark1
        /// <summary>ＵＯＥリマーク１プロパティ</summary>
        /// <value>UserOrderEntory</value>
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

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
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

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
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

        /// public propaty name  :  ListPriceTaxIncFl
        /// <summary>定価（税込，浮動）プロパティ</summary>
        /// <value>税抜き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceTaxIncFl
        {
            get { return _listPriceTaxIncFl; }
            set { _listPriceTaxIncFl = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>定価（税抜，浮動）プロパティ</summary>
        /// <value>税込み</value>
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

        /// public propaty name  :  SalesRate
        /// <summary>売価率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesRate
        {
            get { return _salesRate; }
            set { _salesRate = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>出荷数プロパティ</summary>
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

        /// public propaty name  :  SalesUnitCost
        /// <summary>原価単価プロパティ</summary>
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

        /// public propaty name  :  SalesUnPrcTaxIncFl
        /// <summary>売上単価（税込，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnPrcTaxIncFl
        {
            get { return _salesUnPrcTaxIncFl; }
            set { _salesUnPrcTaxIncFl = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>売上単価（税抜，浮動）プロパティ</summary>
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

        /// public propaty name  :  Cost
        /// <summary>原価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        /// public propaty name  :  SalesMoneyTaxInc
        /// <summary>売上金額（税込み）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxInc
        {
            get { return _salesMoneyTaxInc; }
            set { _salesMoneyTaxInc = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>売上金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
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

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// <value>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる。（未発注はゼロ）</value>
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
        /// <summary>倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>倉庫棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>販売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        /// public propaty name  :  SalesCdNm
        /// <summary>販売区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesCdNm
        {
            get { return _salesCdNm; }
            set { _salesCdNm = value; }
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

        /// public propaty name  :  CarMngCode
        /// <summary>車輌管理コードプロパティ</summary>
        /// <value>※PM7での車両管理番号</value>
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

        /// public propaty name  :  FirstEntryDate
        /// <summary>初年度プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime FirstEntryDate
        {
            get { return _firstEntryDate; }
            set { _firstEntryDate = value; }
        }

        /// public propaty name  :  TransactionName
        /// <summary>取引区分名[伝票]プロパティ</summary>
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

        /// public propaty name  :  GrossMarginRate
        /// <summary>粗利率[伝票]プロパティ</summary>
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

        /// public propaty name  :  GrossMarginRateDtl
        /// <summary>粗利率[明細]プロパティ</summary>
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

        /// public propaty name  :  SalesDisTtlTaxExc
        /// <summary>売上値引金額計（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上値引金額計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesDisTtlTaxExc
        {
            get { return _salesDisTtlTaxExc; }
            set { _salesDisTtlTaxExc = value; }
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

        /// public propaty name  :  SearchSlipDate
        /// <summary>伝票検索日付プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
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
        /// <summary>売上金額消費税額（内税）[伝票]プロパティ</summary>
        /// <value>値引前の内税商品の消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額消費税額（内税）[伝票]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalAmntConsTaxInclu
        {
            get { return _salAmntConsTaxInclu; }
            set { _salAmntConsTaxInclu = value; }
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

        /// public propaty name  :  PartySaleSlipNumStock
        /// <summary>相手先伝票番号プロパティ</summary>
        /// <value>仕入先伝票番号に使用する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNumStock
        {
            get { return _partySaleSlipNumStock; }
            set { _partySaleSlipNumStock = value; }
        }

        // 2010/06/29 Add >>>
        /// public propaty name  :  ModelHalfName
        /// <summary>車種半角名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種半角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelHalfName
        {
            get { return _modelHalfName; }
            set { _modelHalfName = value; }
        }
        // 2010/06/29 Add <<<

        // --- ADD  大矢睦美  2010/07/14 ---------->>>>>
        /// public propaty name  :  GoodsNameKana
        /// <summary>商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }
        // --- ADD  大矢睦美  2010/07/14 ----------<<<<<

        // --- ADD  施健  2011/07/18 ---------->>>>>
        /// public propaty name  :  SCMAnsMarkPrtDiv
        /// <summary>SCM回答マーク印字区分プロパティ</summary>
        /// <value>0:しない,1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM回答マーク印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SCMAnsMarkPrtDiv
        {
            get { return _sCMAnsMarkPrtDiv; }
            set { _sCMAnsMarkPrtDiv = value; }
        }

        /// public propaty name  :  NormalPrtMark
        /// <summary>通常発行マークプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   通常発行マークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NormalPrtMark
        {
            get { return _normalPrtMark; }
            set { _normalPrtMark = value; }
        }

        /// public propaty name  :  SCMManualAnsMark
        /// <summary>SCM手動回答マークプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM手動回答マークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SCMManualAnsMark
        {
            get { return _sCMManualAnsMark; }
            set { _sCMManualAnsMark = value; }
        }

        /// public propaty name  :  SCMAutoAnsMark
        /// <summary>SCM自動回答マークプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM自動回答マークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SCMAutoAnsMark
        {
            get { return _sCMAutoAnsMark; }
            set { _sCMAutoAnsMark = value; }
        }

        /// public propaty name  :  AutoAnswerDivSCM
        /// <summary>自動回答区分(SCM)プロパティ</summary>
        /// <value>0:通常(PCC連携なし)、1:手動回答、2:自動回答</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動回答区分(SCM)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoAnswerDivSCM
        {
            get { return _autoAnswerDivSCM; }
            set { _autoAnswerDivSCM = value; }
        }
        // --- ADD  施健  2011/07/18 ----------<<<<<

        // --- ADD  陳建明  2010/11/29--------->>>>>>
        /// public propaty name  :  LogicalDeleteCode
        /// <summary>削除区分</summary>
        /// <value>0:未削除、1:削除</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }
        // --- ADD  陳建明  2010/11/29---------<<<<<<<

        // ----- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
        /// public propaty name  :  SalesMoneyTaxFreeCdrf
        /// <summary>売上金額非課税</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額非課税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxFreeCdrf
        {
            get { return _salesMoneyTaxFreeCdrf; }
            set { _salesMoneyTaxFreeCdrf = value; }
        }

        /// public propaty name  :  TaxRateExistFlag
        /// <summary>売上明細課税存在フラグ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  売上明細課税存在フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool TaxRateExistFlag
        {
            get { return _taxRateExistFlag; }
            set { _taxRateExistFlag = value; }
        }

        /// public propaty name  :  TaxFreeExistFlag
        /// <summary>売上明細非課税存在フラグ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  売上明細非課税存在フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool TaxFreeExistFlag
        {
            get { return _taxFreeExistFlag; }
            set { _taxFreeExistFlag = value; }
        }
        // ----- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<

        /// <summary>
        /// 売上確認表抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>SalesConfWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesConfWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesConfWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SalesConfWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalesConfWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SalesConfWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesConfWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesConfWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesConfWork || graph is ArrayList || graph is SalesConfWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SalesConfWork).FullName));

            if (graph != null && graph is SalesConfWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesConfWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesConfWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesConfWork[])graph).Length;
            }
            else if (graph is SalesConfWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //部門名称
            serInfo.MemberInfo.Add(typeof(string)); //SubSectionName
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //請求先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //請求先略称
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //出荷日付
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentDay
            //売上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //計上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //売上伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCd
            //売掛区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AccRecDivCd
            //売上入力者コード
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputCode
            //売上入力者名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputName
            //受付従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeCd
            //受付従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeNm
            //販売従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeCd
            //販売従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeNm
            //相手先伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //売上伝票合計（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxInc
            //売上伝票合計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxExc
            //原価金額計
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalCost
            //返品理由コード
            serInfo.MemberInfo.Add(typeof(Int32)); //RetGoodsReasonDiv
            //返品理由
            serInfo.MemberInfo.Add(typeof(string)); //RetGoodsReason
            //得意先伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CustSlipNo
            //伝票備考
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote
            //伝票備考２
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote2
            //伝票備考３
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote3
            //業種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessTypeCode
            //業種名称
            serInfo.MemberInfo.Add(typeof(string)); //BusinessTypeName
            //販売エリアコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //販売エリア名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //ＵＯＥリマーク１
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //ＵＯＥリマーク２
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //売上在庫取寄せ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDivCd
            //定価（税込，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxIncFl
            //定価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //売価率
            serInfo.MemberInfo.Add(typeof(Double)); //SalesRate
            //出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //原価単価
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //売上単価（税込，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxIncFl
            //売上単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //原価
            serInfo.MemberInfo.Add(typeof(Int64)); //Cost
            //売上金額（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxInc
            //売上金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //販売区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCode
            //販売区分名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesCdNm
            //車種全角名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelFullName
            //型式（フル型）
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //型式指定番号
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
            //類別番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
            //車輌管理コード
            serInfo.MemberInfo.Add(typeof(string)); //CarMngCode
            //初年度
            serInfo.MemberInfo.Add(typeof(Int32)); //FirstEntryDate
            //取引区分名[伝票]
            serInfo.MemberInfo.Add(typeof(string)); //TransactionName
            //粗利率[伝票]
            serInfo.MemberInfo.Add(typeof(Double)); //GrossMarginRate
            //粗利チェックマーク[伝票]
            serInfo.MemberInfo.Add(typeof(string)); //GrossMarginMarkSlip
            //粗利率[明細]
            serInfo.MemberInfo.Add(typeof(Double)); //GrossMarginRateDtl
            //粗利チェックマーク[明細]
            serInfo.MemberInfo.Add(typeof(string)); //GrossMarginMarkDtl
            //売上伝票区分（明細）
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCdDtl
            //売上値引金額計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesDisTtlTaxExc
            //売上行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //伝票検索日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchSlipDate
            //消費税転嫁方式[伝票]
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //総額表示方法区分[伝票]
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalAmountDispWayCd
            //課税区分[明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //売上金額消費税額（内税）[伝票]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalAmntConsTaxInclu
            //売上値引消費税額（内税）[伝票]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesDisTtlTaxInclu
            //売上値引消費税額（外税）[伝票]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesDisOutTax
            //原価金額(値引)
            serInfo.MemberInfo.Add(typeof(Int64)); //DisCost
            //相手先伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNumStock
            //車種半角名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelHalfName
            // --- ADD  大矢睦美  2010/07/14 ---------->>>>>
            //商品名称カナ
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            // --- ADD  大矢睦美  2010/07/14 ----------<<<<<
            // --- ADD  施健  2011/07/18 ---------->>>>>
            //SCM回答マーク印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SCMAnsMarkPrtDiv
            //通常発行マーク
            serInfo.MemberInfo.Add(typeof(string)); //NormalPrtMark
            //SCM手動回答マーク
            serInfo.MemberInfo.Add(typeof(string)); //SCMManualAnsMark
            //SCM自動回答マーク
            serInfo.MemberInfo.Add(typeof(string)); //SCMAutoAnsMark
            //自動回答区分(SCM)
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoAnswerDivSCM
            // --- ADD  施健  2011/07/18 ----------<<<<<
            // --- ADD  陳建明  2010/11/29--------->>>>>>
            //削除区分マーク
            serInfo.MemberInfo.Add(typeof(Int32));
            // --- ADD  陳建明  2010/11/29---------<<<<<<
            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            // 消費税税率
            serInfo.MemberInfo.Add(typeof(Double));
            // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            serInfo.Serialize(writer, serInfo);
            if (graph is SalesConfWork)
            {
                SalesConfWork temp = (SalesConfWork)graph;

                SetSalesConfWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesConfWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesConfWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesConfWork temp in lst)
                {
                    SetSalesConfWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesConfWorkメンバ数(publicプロパティ数)
        /// </summary>
        // --- UPD  施健  2011/07/18 ---------->>>>>
        // --- UPD  大矢睦美  2010/07/14 ---------->>>>>
        // 2010/06/29 >>>
        //private const int currentMemberCount = 82;
        //private const int currentMemberCount = 83;
        //private const int currentMemberCount = 84;
        //private const int currentMemberCount = 89;// --- DEL  陳建明  2010/11/29
        //private const int currentMemberCount = 90;// --- ADD  陳建明  2010/11/29  // --- DEL 3H 尹安 2020/02/27
        private const int currentMemberCount = 91;  // --- ADD 3H 尹安 2020/02/27
        // 2010/06/29 <<<
        // --- UPD  大矢睦美  2010/07/14 ----------<<<<<
        // --- UPD  施健  2011/07/18 ----------<<<<<
        /// <summary>
        ///  SalesConfWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesConfWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSalesConfWork(System.IO.BinaryWriter writer, SalesConfWork temp)
        {
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //部門コード
            writer.Write(temp.SubSectionCode);
            //部門名称
            writer.Write(temp.SubSectionName);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //請求先コード
            writer.Write(temp.ClaimCode);
            //請求先略称
            writer.Write(temp.ClaimSnm);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //出荷日付
            writer.Write((Int64)temp.ShipmentDay.Ticks);
            //売上日付
            writer.Write((Int64)temp.SalesDate.Ticks);
            //計上日付
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //売上伝票区分
            writer.Write(temp.SalesSlipCd);
            //売掛区分
            writer.Write(temp.AccRecDivCd);
            //売上入力者コード
            writer.Write(temp.SalesInputCode);
            //売上入力者名称
            writer.Write(temp.SalesInputName);
            //受付従業員コード
            writer.Write(temp.FrontEmployeeCd);
            //受付従業員名称
            writer.Write(temp.FrontEmployeeNm);
            //販売従業員コード
            writer.Write(temp.SalesEmployeeCd);
            //販売従業員名称
            writer.Write(temp.SalesEmployeeNm);
            //相手先伝票番号
            writer.Write(temp.PartySaleSlipNum);
            //売上伝票合計（税込み）
            writer.Write(temp.SalesTotalTaxInc);
            //売上伝票合計（税抜き）
            writer.Write(temp.SalesTotalTaxExc);
            //原価金額計
            writer.Write(temp.TotalCost);
            //返品理由コード
            writer.Write(temp.RetGoodsReasonDiv);
            //返品理由
            writer.Write(temp.RetGoodsReason);
            //得意先伝票番号
            writer.Write(temp.CustSlipNo);
            //伝票備考
            writer.Write(temp.SlipNote);
            //伝票備考２
            writer.Write(temp.SlipNote2);
            //伝票備考３
            writer.Write(temp.SlipNote3);
            //業種コード
            writer.Write(temp.BusinessTypeCode);
            //業種名称
            writer.Write(temp.BusinessTypeName);
            //販売エリアコード
            writer.Write(temp.SalesAreaCode);
            //販売エリア名称
            writer.Write(temp.SalesAreaName);
            //ＵＯＥリマーク１
            writer.Write(temp.UoeRemark1);
            //ＵＯＥリマーク２
            writer.Write(temp.UoeRemark2);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード名称（全角）
            writer.Write(temp.BLGoodsFullName);
            //売上在庫取寄せ区分
            writer.Write(temp.SalesOrderDivCd);
            //定価（税込，浮動）
            writer.Write(temp.ListPriceTaxIncFl);
            //定価（税抜，浮動）
            writer.Write(temp.ListPriceTaxExcFl);
            //売価率
            writer.Write(temp.SalesRate);
            //出荷数
            writer.Write(temp.ShipmentCnt);
            //原価単価
            writer.Write(temp.SalesUnitCost);
            //売上単価（税込，浮動）
            writer.Write(temp.SalesUnPrcTaxIncFl);
            //売上単価（税抜，浮動）
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //原価
            writer.Write(temp.Cost);
            //売上金額（税込み）
            writer.Write(temp.SalesMoneyTaxInc);
            //売上金額（税抜き）
            writer.Write(temp.SalesMoneyTaxExc);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //販売区分コード
            writer.Write(temp.SalesCode);
            //販売区分名称
            writer.Write(temp.SalesCdNm);
            //車種全角名称
            writer.Write(temp.ModelFullName);
            //型式（フル型）
            writer.Write(temp.FullModel);
            //型式指定番号
            writer.Write(temp.ModelDesignationNo);
            //類別番号
            writer.Write(temp.CategoryNo);
            //車輌管理コード
            writer.Write(temp.CarMngCode);
            //初年度
            writer.Write((Int64)temp.FirstEntryDate.Ticks);
            //取引区分名[伝票]
            writer.Write(temp.TransactionName);
            //粗利率[伝票]
            writer.Write(temp.GrossMarginRate);
            //粗利チェックマーク[伝票]
            writer.Write(temp.GrossMarginMarkSlip);
            //粗利率[明細]
            writer.Write(temp.GrossMarginRateDtl);
            //粗利チェックマーク[明細]
            writer.Write(temp.GrossMarginMarkDtl);
            //売上伝票区分（明細）
            writer.Write(temp.SalesSlipCdDtl);
            //売上値引金額計（税抜き）
            writer.Write(temp.SalesDisTtlTaxExc);
            //売上行番号
            writer.Write(temp.SalesRowNo);
            //伝票検索日付
            writer.Write((Int64)temp.SearchSlipDate.Ticks);
            //消費税転嫁方式[伝票]
            writer.Write(temp.ConsTaxLayMethod);
            //総額表示方法区分[伝票]
            writer.Write(temp.TotalAmountDispWayCd);
            //課税区分[明細]
            writer.Write(temp.TaxationDivCd);
            //売上金額消費税額（内税）[伝票]
            writer.Write(temp.SalAmntConsTaxInclu);
            //売上値引消費税額（内税）[伝票]
            writer.Write(temp.SalesDisTtlTaxInclu);
            //売上値引消費税額（外税）[伝票]
            writer.Write(temp.SalesDisOutTax);
            //原価金額(値引)
            writer.Write(temp.DisCost);
            //相手先伝票番号
            writer.Write(temp.PartySaleSlipNumStock);
            //車種半角名称
            writer.Write(temp.ModelHalfName);
            // --- ADD  大矢睦美  2010/07/14 ---------->>>>>
            //商品名称カナ
            writer.Write(temp.GoodsNameKana);
            // --- ADD  大矢睦美  2010/07/14 ----------<<<<<
            // --- ADD  施健  2011/07/18 ---------->>>>>
            //SCM回答マーク印字区分
            writer.Write(temp.SCMAnsMarkPrtDiv);
            //通常発行マーク
            writer.Write(temp.NormalPrtMark);
            //SCM手動回答マーク
            writer.Write(temp.SCMManualAnsMark);
            //SCM自動回答マーク
            writer.Write(temp.SCMAutoAnsMark);
            //自動回答区分(SCM)
            writer.Write(temp.AutoAnswerDivSCM);
            // --- ADD  施健  2011/07/18 ----------<<<<<
            // --- ADD  陳建明  2010/11/29--------->>>>>>
            //削除区分マーク
            writer.Write(temp.LogicalDeleteCode);
            // --- ADD  陳建明  2010/11/29---------<<<<<<
            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            // 消費税税率
            writer.Write(temp.ConsTaxRate);
            // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）--------->>>>>>
            // 売上金額非課税
            writer.Write(temp.SalesMoneyTaxFreeCdrf);
            // 売上明細課税存在フラグ
            writer.Write(temp.TaxRateExistFlag);
            // 売上明細非課税存在フラグ
            writer.Write(temp.TaxFreeExistFlag);
            // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）---------<<<<<<
        }

        /// <summary>
        ///  SalesConfWorkインスタンス取得
        /// </summary>
        /// <returns>SalesConfWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesConfWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SalesConfWork GetSalesConfWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SalesConfWork temp = new SalesConfWork();

            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //部門コード
            temp.SubSectionCode = reader.ReadInt32();
            //部門名称
            temp.SubSectionName = reader.ReadString();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //請求先コード
            temp.ClaimCode = reader.ReadInt32();
            //請求先略称
            temp.ClaimSnm = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //出荷日付
            temp.ShipmentDay = new DateTime(reader.ReadInt64());
            //売上日付
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //計上日付
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //売上伝票区分
            temp.SalesSlipCd = reader.ReadInt32();
            //売掛区分
            temp.AccRecDivCd = reader.ReadInt32();
            //売上入力者コード
            temp.SalesInputCode = reader.ReadString();
            //売上入力者名称
            temp.SalesInputName = reader.ReadString();
            //受付従業員コード
            temp.FrontEmployeeCd = reader.ReadString();
            //受付従業員名称
            temp.FrontEmployeeNm = reader.ReadString();
            //販売従業員コード
            temp.SalesEmployeeCd = reader.ReadString();
            //販売従業員名称
            temp.SalesEmployeeNm = reader.ReadString();
            //相手先伝票番号
            temp.PartySaleSlipNum = reader.ReadString();
            //売上伝票合計（税込み）
            temp.SalesTotalTaxInc = reader.ReadInt64();
            //売上伝票合計（税抜き）
            temp.SalesTotalTaxExc = reader.ReadInt64();
            //原価金額計
            temp.TotalCost = reader.ReadInt64();
            //返品理由コード
            temp.RetGoodsReasonDiv = reader.ReadInt32();
            //返品理由
            temp.RetGoodsReason = reader.ReadString();
            //得意先伝票番号
            temp.CustSlipNo = reader.ReadInt32();
            //伝票備考
            temp.SlipNote = reader.ReadString();
            //伝票備考２
            temp.SlipNote2 = reader.ReadString();
            //伝票備考３
            temp.SlipNote3 = reader.ReadString();
            //業種コード
            temp.BusinessTypeCode = reader.ReadInt32();
            //業種名称
            temp.BusinessTypeName = reader.ReadString();
            //販売エリアコード
            temp.SalesAreaCode = reader.ReadInt32();
            //販売エリア名称
            temp.SalesAreaName = reader.ReadString();
            //ＵＯＥリマーク１
            temp.UoeRemark1 = reader.ReadString();
            //ＵＯＥリマーク２
            temp.UoeRemark2 = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（全角）
            temp.BLGoodsFullName = reader.ReadString();
            //売上在庫取寄せ区分
            temp.SalesOrderDivCd = reader.ReadInt32();
            //定価（税込，浮動）
            temp.ListPriceTaxIncFl = reader.ReadDouble();
            //定価（税抜，浮動）
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //売価率
            temp.SalesRate = reader.ReadDouble();
            //出荷数
            temp.ShipmentCnt = reader.ReadDouble();
            //原価単価
            temp.SalesUnitCost = reader.ReadDouble();
            //売上単価（税込，浮動）
            temp.SalesUnPrcTaxIncFl = reader.ReadDouble();
            //売上単価（税抜，浮動）
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //原価
            temp.Cost = reader.ReadInt64();
            //売上金額（税込み）
            temp.SalesMoneyTaxInc = reader.ReadInt64();
            //売上金額（税抜き）
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //販売区分コード
            temp.SalesCode = reader.ReadInt32();
            //販売区分名称
            temp.SalesCdNm = reader.ReadString();
            //車種全角名称
            temp.ModelFullName = reader.ReadString();
            //型式（フル型）
            temp.FullModel = reader.ReadString();
            //型式指定番号
            temp.ModelDesignationNo = reader.ReadInt32();
            //類別番号
            temp.CategoryNo = reader.ReadInt32();
            //車輌管理コード
            temp.CarMngCode = reader.ReadString();
            //初年度
            temp.FirstEntryDate = new DateTime(reader.ReadInt64());
            //取引区分名[伝票]
            temp.TransactionName = reader.ReadString();
            //粗利率[伝票]
            temp.GrossMarginRate = reader.ReadDouble();
            //粗利チェックマーク[伝票]
            temp.GrossMarginMarkSlip = reader.ReadString();
            //粗利率[明細]
            temp.GrossMarginRateDtl = reader.ReadDouble();
            //粗利チェックマーク[明細]
            temp.GrossMarginMarkDtl = reader.ReadString();
            //売上伝票区分（明細）
            temp.SalesSlipCdDtl = reader.ReadInt32();
            //売上値引金額計（税抜き）
            temp.SalesDisTtlTaxExc = reader.ReadInt64();
            //売上行番号
            temp.SalesRowNo = reader.ReadInt32();
            //伝票検索日付
            temp.SearchSlipDate = new DateTime(reader.ReadInt64());
            //消費税転嫁方式[伝票]
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //総額表示方法区分[伝票]
            temp.TotalAmountDispWayCd = reader.ReadInt32();
            //課税区分[明細]
            temp.TaxationDivCd = reader.ReadInt32();
            //売上金額消費税額（内税）[伝票]
            temp.SalAmntConsTaxInclu = reader.ReadInt64();
            //売上値引消費税額（内税）[伝票]
            temp.SalesDisTtlTaxInclu = reader.ReadInt64();
            //売上値引消費税額（外税）[伝票]
            temp.SalesDisOutTax = reader.ReadInt64();
            //原価金額(値引)
            temp.DisCost = reader.ReadInt64();
            //相手先伝票番号
            temp.PartySaleSlipNumStock = reader.ReadString();
            //車種半角名称
            temp.ModelHalfName = reader.ReadString();
            // --- ADD  大矢睦美  2010/07/14 ---------->>>>>
            //商品名称カナ
            temp.GoodsNameKana = reader.ReadString();
            // --- ADD  大矢睦美  2010/07/14 ----------<<<<<
            // --- ADD  施健  2011/07/18 ---------->>>>>
            //SCM回答マーク印字区分
            temp.SCMAnsMarkPrtDiv = reader.ReadInt32();
            //通常発行マーク
            temp.NormalPrtMark = reader.ReadString();
            //SCM手動回答マーク
            temp.SCMManualAnsMark = reader.ReadString();
            //SCM自動回答マーク
            temp.SCMAutoAnsMark = reader.ReadString();
            //自動回答区分(SCM)
            temp.AutoAnswerDivSCM = reader.ReadInt32();
            // --- ADD  施健  2011/07/18 ----------<<<<<
            // --- ADD  陳建明  2010/11/29--------->>>>>>
            //削除区分マーク
            temp.LogicalDeleteCode = reader.ReadInt32();
            // --- ADD  陳建明  2010/11/29---------<<<<<<
            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            // 消費税税率
            temp.ConsTaxRate = reader.ReadDouble();
            // --- ADD END 3H 尹安 2020/02/27 -----<<<<<

            // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）--------->>>>>>
            temp.SalesMoneyTaxFreeCdrf = reader.ReadInt64();
            temp.TaxRateExistFlag = reader.ReadBoolean();
            temp.TaxFreeExistFlag = reader.ReadBoolean();
            // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）---------<<<<<
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
        /// <returns>SalesConfWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesConfWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesConfWork temp = GetSalesConfWork(reader, serInfo);
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
                    retValue = (SalesConfWork[])lst.ToArray(typeof(SalesConfWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
