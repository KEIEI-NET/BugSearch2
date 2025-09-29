using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MailDefaultHeader
    /// <summary>
    ///                      メール初期値ヘッダデータ
    /// </summary>
    /// <remarks>
    /// <br>note             :   メール初期値ヘッダデータヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2010/5/18</br>
    /// <br>Genarated Date   :   2010/05/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class MailDefaultHeader
    {
        /// <summary>起動モード</summary>
        /// <remarks>0:通常起動、1:QR付き起動</remarks>
        private Int32 _mode;

        /// <summary>添付ファイルパス</summary>
        /// <remarks>添付ファイルパス（ＱＲコードのファイルパス）</remarks>
        private string _attachedFilePath = "";

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private string _salesSlipNum = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>売上伝票区分</summary>
        /// <remarks>0:売上,1:返品</remarks>
        private Int32 _salesSlipCd;

        /// <summary>売掛区分</summary>
        /// <remarks>0:売掛なし,1:売掛</remarks>
        private Int32 _accRecDivCd;

        /// <summary>売上入力拠点コード</summary>
        /// <remarks>文字型 売上を入力した拠点コード</remarks>
        private string _salesInpSecCd = "";

        /// <summary>請求計上拠点コード</summary>
        /// <remarks>文字型</remarks>
        private string _demandAddUpSecCd = "";

        /// <summary>実績計上拠点コード</summary>
        /// <remarks>実績計上を行う企業内の拠点コード</remarks>
        private string _resultsAddUpSecCd = "";

        /// <summary>更新拠点コード</summary>
        /// <remarks>文字型 データの登録更新拠点</remarks>
        private string _updateSecCd = "";

        /// <summary>出荷日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _shipmentDay;

        /// <summary>売上日付</summary>
        /// <remarks>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        /// <summary>計上日付</summary>
        /// <remarks>請求日　(YYYYMMDD)</remarks>
        private DateTime _addUpADate;

        /// <summary>見積区分</summary>
        /// <remarks>1:通常見積　2:単価見積　3:検索見積</remarks>
        private Int32 _estimateDivide;

        /// <summary>入力担当者コード</summary>
        /// <remarks>ログイン担当者（ＵＳＢ）</remarks>
        private string _inputAgenCd = "";

        /// <summary>入力担当者名称</summary>
        private string _inputAgenNm = "";

        /// <summary>売上入力者コード</summary>
        /// <remarks>入力担当者（発行者）</remarks>
        private string _salesInputCode = "";

        /// <summary>受付従業員コード</summary>
        /// <remarks>受付担当者（受注者）</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>販売従業員コード</summary>
        /// <remarks>計上担当者（担当者）</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>売上合計金額(税抜き)</summary>
        /// <remarks>画面上の売上合計に相当</remarks>
        private Int64 _salesTotalPriceTaxExc;

        /// <summary>売上消費税（合計）</summary>
        /// <remarks>画面上の消費税</remarks>
        private Int64 _salesPriceConsTaxTotal;

        /// <summary>売上合計金額（税込み）</summary>
        /// <remarks>画面上の合計金額</remarks>
        private Int64 _salesTotalPrice;

        /// <summary>原価金額計</summary>
        private Int64 _totalCost;

        /// <summary>消費税転嫁方式</summary>
        /// <remarks>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>請求先コード</summary>
        private Int32 _claimCode;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先名称</summary>
        private string _customerName = "";

        /// <summary>得意先名称2</summary>
        private string _customerName2 = "";

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>敬称</summary>
        private string _honorificTitle = "";

        /// <summary>得意先伝票番号</summary>
        private Int32 _custSlipNo;

        /// <summary>伝票住所区分</summary>
        /// <remarks>1:得意先,2:納入先</remarks>
        private Int32 _slipAddressDiv;

        /// <summary>納品先コード</summary>
        private Int32 _addresseeCode;

        /// <summary>納品先名称</summary>
        private string _addresseeName = "";

        /// <summary>納品先名称2</summary>
        /// <remarks>追加(登録漏れ) 塩原</remarks>
        private string _addresseeName2 = "";

        /// <summary>納品先郵便番号</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private string _addresseePostNo = "";

        /// <summary>納品先住所1(都道府県市区郡・町村・字)</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private string _addresseeAddr1 = "";

        /// <summary>納品先住所3(番地)</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private string _addresseeAddr3 = "";

        /// <summary>納品先住所4(アパート名称)</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private string _addresseeAddr4 = "";

        /// <summary>納品先電話番号</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private string _addresseeTelNo = "";

        /// <summary>納品先FAX番号</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private string _addresseeFaxNo = "";

        /// <summary>相手先伝票番号</summary>
        /// <remarks>得意先注文番号（仮伝番号）</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>伝票備考</summary>
        private string _slipNote = "";

        /// <summary>伝票備考２</summary>
        private string _slipNote2 = "";

        /// <summary>伝票備考３</summary>
        private string _slipNote3 = "";

        /// <summary>返品理由コード</summary>
        private Int32 _retGoodsReasonDiv;

        /// <summary>返品理由</summary>
        private string _retGoodsReason = "";

        /// <summary>業種コード</summary>
        private Int32 _businessTypeCode;

        /// <summary>納品区分</summary>
        /// <remarks>例) 1:配達,2:店頭渡し,3:直送,…</remarks>
        private Int32 _deliveredGoodsDiv;

        /// <summary>販売エリアコード</summary>
        /// <remarks>地区コード</remarks>
        private Int32 _salesAreaCode;

        /// <summary>元号表示区分１</summary>
        /// <remarks>通常　　0:西暦　1:和暦</remarks>
        private Int32 _eraNameDispCd1;

        /// <summary>実績計上拠点名称</summary>
        private string _resultsAddUpSecNm = "";

        /// <summary>販売従業員名称</summary>
        private string _salesEmployeeNm = "";

        /// <summary>業種名称</summary>
        private string _businessTypeName = "";


        /// public propaty name  :  Mode
        /// <summary>起動モードプロパティ</summary>
        /// <value>0:通常起動、1:QR付き起動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   起動モードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        /// public propaty name  :  AttachedFilePath
        /// <summary>添付ファイルパスプロパティ</summary>
        /// <value>添付ファイルパス（ＱＲコードのファイルパス）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   添付ファイルパスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AttachedFilePath
        {
            get { return _attachedFilePath; }
            set { _attachedFilePath = value; }
        }

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
        /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
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

        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>0:黒伝,1:赤伝,2:元黒</value>
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

        /// public propaty name  :  SalesInpSecCd
        /// <summary>売上入力拠点コードプロパティ</summary>
        /// <value>文字型 売上を入力した拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInpSecCd
        {
            get { return _salesInpSecCd; }
            set { _salesInpSecCd = value; }
        }

        /// public propaty name  :  DemandAddUpSecCd
        /// <summary>請求計上拠点コードプロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DemandAddUpSecCd
        {
            get { return _demandAddUpSecCd; }
            set { _demandAddUpSecCd = value; }
        }

        /// public propaty name  :  ResultsAddUpSecCd
        /// <summary>実績計上拠点コードプロパティ</summary>
        /// <value>実績計上を行う企業内の拠点コード</value>
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

        /// public propaty name  :  SalesDateJpFormal
        /// <summary>売上日付 和暦プロパティ</summary>
        /// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
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
        /// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
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
        /// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
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
        /// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
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

        /// public propaty name  :  EstimateDivide
        /// <summary>見積区分プロパティ</summary>
        /// <value>1:通常見積　2:単価見積　3:検索見積</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstimateDivide
        {
            get { return _estimateDivide; }
            set { _estimateDivide = value; }
        }

        /// public propaty name  :  InputAgenCd
        /// <summary>入力担当者コードプロパティ</summary>
        /// <value>ログイン担当者（ＵＳＢ）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputAgenCd
        {
            get { return _inputAgenCd; }
            set { _inputAgenCd = value; }
        }

        /// public propaty name  :  InputAgenNm
        /// <summary>入力担当者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputAgenNm
        {
            get { return _inputAgenNm; }
            set { _inputAgenNm = value; }
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

        /// public propaty name  :  SalesTotalPriceTaxExc
        /// <summary>売上合計金額(税抜き)プロパティ</summary>
        /// <value>画面上の売上合計に相当</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上合計金額(税抜き)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTotalPriceTaxExc
        {
            get { return _salesTotalPriceTaxExc; }
            set { _salesTotalPriceTaxExc = value; }
        }

        /// public propaty name  :  SalesPriceConsTaxTotal
        /// <summary>売上消費税（合計）プロパティ</summary>
        /// <value>画面上の消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上消費税（合計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesPriceConsTaxTotal
        {
            get { return _salesPriceConsTaxTotal; }
            set { _salesPriceConsTaxTotal = value; }
        }

        /// public propaty name  :  SalesTotalPrice
        /// <summary>売上合計金額（税込み）プロパティ</summary>
        /// <value>画面上の合計金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上合計金額（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTotalPrice
        {
            get { return _salesTotalPrice; }
            set { _salesTotalPrice = value; }
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

        /// public propaty name  :  HonorificTitle
        /// <summary>敬称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HonorificTitle
        {
            get { return _honorificTitle; }
            set { _honorificTitle = value; }
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

        /// public propaty name  :  SlipAddressDiv
        /// <summary>伝票住所区分プロパティ</summary>
        /// <value>1:得意先,2:納入先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票住所区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipAddressDiv
        {
            get { return _slipAddressDiv; }
            set { _slipAddressDiv = value; }
        }

        /// public propaty name  :  AddresseeCode
        /// <summary>納品先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddresseeCode
        {
            get { return _addresseeCode; }
            set { _addresseeCode = value; }
        }

        /// public propaty name  :  AddresseeName
        /// <summary>納品先名称プロパティ</summary>
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
        /// <value>追加(登録漏れ) 塩原</value>
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

        /// public propaty name  :  AddresseePostNo
        /// <summary>納品先郵便番号プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseePostNo
        {
            get { return _addresseePostNo; }
            set { _addresseePostNo = value; }
        }

        /// public propaty name  :  AddresseeAddr1
        /// <summary>納品先住所1(都道府県市区郡・町村・字)プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先住所1(都道府県市区郡・町村・字)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeAddr1
        {
            get { return _addresseeAddr1; }
            set { _addresseeAddr1 = value; }
        }

        /// public propaty name  :  AddresseeAddr3
        /// <summary>納品先住所3(番地)プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先住所3(番地)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeAddr3
        {
            get { return _addresseeAddr3; }
            set { _addresseeAddr3 = value; }
        }

        /// public propaty name  :  AddresseeAddr4
        /// <summary>納品先住所4(アパート名称)プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先住所4(アパート名称)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeAddr4
        {
            get { return _addresseeAddr4; }
            set { _addresseeAddr4 = value; }
        }

        /// public propaty name  :  AddresseeTelNo
        /// <summary>納品先電話番号プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先電話番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeTelNo
        {
            get { return _addresseeTelNo; }
            set { _addresseeTelNo = value; }
        }

        /// public propaty name  :  AddresseeFaxNo
        /// <summary>納品先FAX番号プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先FAX番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeFaxNo
        {
            get { return _addresseeFaxNo; }
            set { _addresseeFaxNo = value; }
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

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>納品区分プロパティ</summary>
        /// <value>例) 1:配達,2:店頭渡し,3:直送,…</value>
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

        /// public propaty name  :  EraNameDispCd1
        /// <summary>元号表示区分１プロパティ</summary>
        /// <value>通常　　0:西暦　1:和暦</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   元号表示区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EraNameDispCd1
        {
            get { return _eraNameDispCd1; }
            set { _eraNameDispCd1 = value; }
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


        /// <summary>
        /// メール初期値ヘッダデータコンストラクタ
        /// </summary>
        /// <returns>MailDefaultHeaderクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailDefaultHeaderクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MailDefaultHeader()
        {
        }

        /// <summary>
        /// メール初期値ヘッダデータコンストラクタ
        /// </summary>
        /// <param name="mode">起動モード(0:通常起動、1:QR付き起動)</param>
        /// <param name="attachedFilePath">添付ファイルパス(添付ファイルパス（ＱＲコードのファイルパス）)</param>
        /// <param name="acptAnOdrStatus">受注ステータス(10:見積,20:受注,30:売上,40:出荷)</param>
        /// <param name="salesSlipNum">売上伝票番号(見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="subSectionCode">部門コード</param>
        /// <param name="debitNoteDiv">赤伝区分(0:黒伝,1:赤伝,2:元黒)</param>
        /// <param name="salesSlipCd">売上伝票区分(0:売上,1:返品)</param>
        /// <param name="accRecDivCd">売掛区分(0:売掛なし,1:売掛)</param>
        /// <param name="salesInpSecCd">売上入力拠点コード(文字型 売上を入力した拠点コード)</param>
        /// <param name="demandAddUpSecCd">請求計上拠点コード(文字型)</param>
        /// <param name="resultsAddUpSecCd">実績計上拠点コード(実績計上を行う企業内の拠点コード)</param>
        /// <param name="updateSecCd">更新拠点コード(文字型 データの登録更新拠点)</param>
        /// <param name="shipmentDay">出荷日付(YYYYMMDD)</param>
        /// <param name="salesDate">売上日付(見積日、受注日、売上日を兼ねる。(YYYYMMDD))</param>
        /// <param name="addUpADate">計上日付(請求日　(YYYYMMDD))</param>
        /// <param name="estimateDivide">見積区分(1:通常見積　2:単価見積　3:検索見積)</param>
        /// <param name="inputAgenCd">入力担当者コード(ログイン担当者（ＵＳＢ）)</param>
        /// <param name="inputAgenNm">入力担当者名称</param>
        /// <param name="salesInputCode">売上入力者コード(入力担当者（発行者）)</param>
        /// <param name="frontEmployeeCd">受付従業員コード(受付担当者（受注者）)</param>
        /// <param name="salesEmployeeCd">販売従業員コード(計上担当者（担当者）)</param>
        /// <param name="totalAmountDispWayCd">総額表示方法区分(0:総額表示しない（税抜き）,1:総額表示する（税込み）)</param>
        /// <param name="salesTotalPriceTaxExc">売上合計金額(税抜き)(画面上の売上合計に相当)</param>
        /// <param name="salesPriceConsTaxTotal">売上消費税（合計）(画面上の消費税)</param>
        /// <param name="salesTotalPrice">売上合計金額（税込み）(画面上の合計金額)</param>
        /// <param name="totalCost">原価金額計</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式(0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税)</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerName">得意先名称</param>
        /// <param name="customerName2">得意先名称2</param>
        /// <param name="customerSnm">得意先略称</param>
        /// <param name="honorificTitle">敬称</param>
        /// <param name="custSlipNo">得意先伝票番号</param>
        /// <param name="slipAddressDiv">伝票住所区分(1:得意先,2:納入先)</param>
        /// <param name="addresseeCode">納品先コード</param>
        /// <param name="addresseeName">納品先名称</param>
        /// <param name="addresseeName2">納品先名称2(追加(登録漏れ) 塩原)</param>
        /// <param name="addresseePostNo">納品先郵便番号(伝票住所区分に従う内容)</param>
        /// <param name="addresseeAddr1">納品先住所1(都道府県市区郡・町村・字)(伝票住所区分に従う内容)</param>
        /// <param name="addresseeAddr3">納品先住所3(番地)(伝票住所区分に従う内容)</param>
        /// <param name="addresseeAddr4">納品先住所4(アパート名称)(伝票住所区分に従う内容)</param>
        /// <param name="addresseeTelNo">納品先電話番号(伝票住所区分に従う内容)</param>
        /// <param name="addresseeFaxNo">納品先FAX番号(伝票住所区分に従う内容)</param>
        /// <param name="partySaleSlipNum">相手先伝票番号(得意先注文番号（仮伝番号）)</param>
        /// <param name="slipNote">伝票備考</param>
        /// <param name="slipNote2">伝票備考２</param>
        /// <param name="slipNote3">伝票備考３</param>
        /// <param name="retGoodsReasonDiv">返品理由コード</param>
        /// <param name="retGoodsReason">返品理由</param>
        /// <param name="businessTypeCode">業種コード</param>
        /// <param name="deliveredGoodsDiv">納品区分(例) 1:配達,2:店頭渡し,3:直送,…)</param>
        /// <param name="salesAreaCode">販売エリアコード(地区コード)</param>
        /// <param name="eraNameDispCd1">元号表示区分１(通常　　0:西暦　1:和暦)</param>
        /// <param name="resultsAddUpSecNm">実績計上拠点名称</param>
        /// <param name="salesEmployeeNm">販売従業員名称</param>
        /// <param name="businessTypeName">業種名称</param>
        /// <returns>MailDefaultHeaderクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailDefaultHeaderクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MailDefaultHeader(Int32 mode, string attachedFilePath, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, Int32 salesSlipCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string frontEmployeeCd, string salesEmployeeCd, Int32 totalAmountDispWayCd, Int64 salesTotalPriceTaxExc, Int64 salesPriceConsTaxTotal, Int64 salesTotalPrice, Int64 totalCost, Int32 consTaxLayMethod, Int32 claimCode, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string slipNote, string slipNote2, string slipNote3, Int32 retGoodsReasonDiv, string retGoodsReason, Int32 businessTypeCode, Int32 deliveredGoodsDiv, Int32 salesAreaCode, Int32 eraNameDispCd1, string resultsAddUpSecNm, string salesEmployeeNm, string businessTypeName)
        {
            this._mode = mode;
            this._attachedFilePath = attachedFilePath;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._salesSlipNum = salesSlipNum;
            this._sectionCode = sectionCode;
            this._subSectionCode = subSectionCode;
            this._debitNoteDiv = debitNoteDiv;
            this._salesSlipCd = salesSlipCd;
            this._accRecDivCd = accRecDivCd;
            this._salesInpSecCd = salesInpSecCd;
            this._demandAddUpSecCd = demandAddUpSecCd;
            this._resultsAddUpSecCd = resultsAddUpSecCd;
            this._updateSecCd = updateSecCd;
            this.ShipmentDay = shipmentDay;
            this.SalesDate = salesDate;
            this.AddUpADate = addUpADate;
            this._estimateDivide = estimateDivide;
            this._inputAgenCd = inputAgenCd;
            this._inputAgenNm = inputAgenNm;
            this._salesInputCode = salesInputCode;
            this._frontEmployeeCd = frontEmployeeCd;
            this._salesEmployeeCd = salesEmployeeCd;
            this._totalAmountDispWayCd = totalAmountDispWayCd;
            this._salesTotalPriceTaxExc = salesTotalPriceTaxExc;
            this._salesPriceConsTaxTotal = salesPriceConsTaxTotal;
            this._salesTotalPrice = salesTotalPrice;
            this._totalCost = totalCost;
            this._consTaxLayMethod = consTaxLayMethod;
            this._claimCode = claimCode;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._customerName2 = customerName2;
            this._customerSnm = customerSnm;
            this._honorificTitle = honorificTitle;
            this._custSlipNo = custSlipNo;
            this._slipAddressDiv = slipAddressDiv;
            this._addresseeCode = addresseeCode;
            this._addresseeName = addresseeName;
            this._addresseeName2 = addresseeName2;
            this._addresseePostNo = addresseePostNo;
            this._addresseeAddr1 = addresseeAddr1;
            this._addresseeAddr3 = addresseeAddr3;
            this._addresseeAddr4 = addresseeAddr4;
            this._addresseeTelNo = addresseeTelNo;
            this._addresseeFaxNo = addresseeFaxNo;
            this._partySaleSlipNum = partySaleSlipNum;
            this._slipNote = slipNote;
            this._slipNote2 = slipNote2;
            this._slipNote3 = slipNote3;
            this._retGoodsReasonDiv = retGoodsReasonDiv;
            this._retGoodsReason = retGoodsReason;
            this._businessTypeCode = businessTypeCode;
            this._deliveredGoodsDiv = deliveredGoodsDiv;
            this._salesAreaCode = salesAreaCode;
            this._eraNameDispCd1 = eraNameDispCd1;
            this._resultsAddUpSecNm = resultsAddUpSecNm;
            this._salesEmployeeNm = salesEmployeeNm;
            this._businessTypeName = businessTypeName;

        }

        /// <summary>
        /// メール初期値ヘッダデータ複製処理
        /// </summary>
        /// <returns>MailDefaultHeaderクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいMailDefaultHeaderクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MailDefaultHeader Clone()
        {
            return new MailDefaultHeader(this._mode, this._attachedFilePath, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._salesSlipCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._shipmentDay, this._salesDate, this._addUpADate, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._frontEmployeeCd, this._salesEmployeeCd, this._totalAmountDispWayCd, this._salesTotalPriceTaxExc, this._salesPriceConsTaxTotal, this._salesTotalPrice, this._totalCost, this._consTaxLayMethod, this._claimCode, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._slipNote, this._slipNote2, this._slipNote3, this._retGoodsReasonDiv, this._retGoodsReason, this._businessTypeCode, this._deliveredGoodsDiv, this._salesAreaCode, this._eraNameDispCd1, this._resultsAddUpSecNm, this._salesEmployeeNm, this._businessTypeName);
        }

        /// <summary>
        /// メール初期値ヘッダデータ比較処理
        /// </summary>
        /// <param name="target">比較対象のMailDefaultHeaderクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailDefaultHeaderクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(MailDefaultHeader target)
        {
            return ( ( this.Mode == target.Mode )
                 && ( this.AttachedFilePath == target.AttachedFilePath )
                 && ( this.AcptAnOdrStatus == target.AcptAnOdrStatus )
                 && ( this.SalesSlipNum == target.SalesSlipNum )
                 && ( this.SectionCode == target.SectionCode )
                 && ( this.SubSectionCode == target.SubSectionCode )
                 && ( this.DebitNoteDiv == target.DebitNoteDiv )
                 && ( this.SalesSlipCd == target.SalesSlipCd )
                 && ( this.AccRecDivCd == target.AccRecDivCd )
                 && ( this.SalesInpSecCd == target.SalesInpSecCd )
                 && ( this.DemandAddUpSecCd == target.DemandAddUpSecCd )
                 && ( this.ResultsAddUpSecCd == target.ResultsAddUpSecCd )
                 && ( this.UpdateSecCd == target.UpdateSecCd )
                 && ( this.ShipmentDay == target.ShipmentDay )
                 && ( this.SalesDate == target.SalesDate )
                 && ( this.AddUpADate == target.AddUpADate )
                 && ( this.EstimateDivide == target.EstimateDivide )
                 && ( this.InputAgenCd == target.InputAgenCd )
                 && ( this.InputAgenNm == target.InputAgenNm )
                 && ( this.SalesInputCode == target.SalesInputCode )
                 && ( this.FrontEmployeeCd == target.FrontEmployeeCd )
                 && ( this.SalesEmployeeCd == target.SalesEmployeeCd )
                 && ( this.TotalAmountDispWayCd == target.TotalAmountDispWayCd )
                 && ( this.SalesTotalPriceTaxExc == target.SalesTotalPriceTaxExc )
                 && ( this.SalesPriceConsTaxTotal == target.SalesPriceConsTaxTotal )
                 && ( this.SalesTotalPrice == target.SalesTotalPrice )
                 && ( this.TotalCost == target.TotalCost )
                 && ( this.ConsTaxLayMethod == target.ConsTaxLayMethod )
                 && ( this.ClaimCode == target.ClaimCode )
                 && ( this.CustomerCode == target.CustomerCode )
                 && ( this.CustomerName == target.CustomerName )
                 && ( this.CustomerName2 == target.CustomerName2 )
                 && ( this.CustomerSnm == target.CustomerSnm )
                 && ( this.HonorificTitle == target.HonorificTitle )
                 && ( this.CustSlipNo == target.CustSlipNo )
                 && ( this.SlipAddressDiv == target.SlipAddressDiv )
                 && ( this.AddresseeCode == target.AddresseeCode )
                 && ( this.AddresseeName == target.AddresseeName )
                 && ( this.AddresseeName2 == target.AddresseeName2 )
                 && ( this.AddresseePostNo == target.AddresseePostNo )
                 && ( this.AddresseeAddr1 == target.AddresseeAddr1 )
                 && ( this.AddresseeAddr3 == target.AddresseeAddr3 )
                 && ( this.AddresseeAddr4 == target.AddresseeAddr4 )
                 && ( this.AddresseeTelNo == target.AddresseeTelNo )
                 && ( this.AddresseeFaxNo == target.AddresseeFaxNo )
                 && ( this.PartySaleSlipNum == target.PartySaleSlipNum )
                 && ( this.SlipNote == target.SlipNote )
                 && ( this.SlipNote2 == target.SlipNote2 )
                 && ( this.SlipNote3 == target.SlipNote3 )
                 && ( this.RetGoodsReasonDiv == target.RetGoodsReasonDiv )
                 && ( this.RetGoodsReason == target.RetGoodsReason )
                 && ( this.BusinessTypeCode == target.BusinessTypeCode )
                 && ( this.DeliveredGoodsDiv == target.DeliveredGoodsDiv )
                 && ( this.SalesAreaCode == target.SalesAreaCode )
                 && ( this.EraNameDispCd1 == target.EraNameDispCd1 )
                 && ( this.ResultsAddUpSecNm == target.ResultsAddUpSecNm )
                 && ( this.SalesEmployeeNm == target.SalesEmployeeNm )
                 && ( this.BusinessTypeName == target.BusinessTypeName ) );
        }

        /// <summary>
        /// メール初期値ヘッダデータ比較処理
        /// </summary>
        /// <param name="mailDefaultHeader1">
        ///                    比較するMailDefaultHeaderクラスのインスタンス
        /// </param>
        /// <param name="mailDefaultHeader2">比較するMailDefaultHeaderクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailDefaultHeaderクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(MailDefaultHeader mailDefaultHeader1, MailDefaultHeader mailDefaultHeader2)
        {
            return ( ( mailDefaultHeader1.Mode == mailDefaultHeader2.Mode )
                 && ( mailDefaultHeader1.AttachedFilePath == mailDefaultHeader2.AttachedFilePath )
                 && ( mailDefaultHeader1.AcptAnOdrStatus == mailDefaultHeader2.AcptAnOdrStatus )
                 && ( mailDefaultHeader1.SalesSlipNum == mailDefaultHeader2.SalesSlipNum )
                 && ( mailDefaultHeader1.SectionCode == mailDefaultHeader2.SectionCode )
                 && ( mailDefaultHeader1.SubSectionCode == mailDefaultHeader2.SubSectionCode )
                 && ( mailDefaultHeader1.DebitNoteDiv == mailDefaultHeader2.DebitNoteDiv )
                 && ( mailDefaultHeader1.SalesSlipCd == mailDefaultHeader2.SalesSlipCd )
                 && ( mailDefaultHeader1.AccRecDivCd == mailDefaultHeader2.AccRecDivCd )
                 && ( mailDefaultHeader1.SalesInpSecCd == mailDefaultHeader2.SalesInpSecCd )
                 && ( mailDefaultHeader1.DemandAddUpSecCd == mailDefaultHeader2.DemandAddUpSecCd )
                 && ( mailDefaultHeader1.ResultsAddUpSecCd == mailDefaultHeader2.ResultsAddUpSecCd )
                 && ( mailDefaultHeader1.UpdateSecCd == mailDefaultHeader2.UpdateSecCd )
                 && ( mailDefaultHeader1.ShipmentDay == mailDefaultHeader2.ShipmentDay )
                 && ( mailDefaultHeader1.SalesDate == mailDefaultHeader2.SalesDate )
                 && ( mailDefaultHeader1.AddUpADate == mailDefaultHeader2.AddUpADate )
                 && ( mailDefaultHeader1.EstimateDivide == mailDefaultHeader2.EstimateDivide )
                 && ( mailDefaultHeader1.InputAgenCd == mailDefaultHeader2.InputAgenCd )
                 && ( mailDefaultHeader1.InputAgenNm == mailDefaultHeader2.InputAgenNm )
                 && ( mailDefaultHeader1.SalesInputCode == mailDefaultHeader2.SalesInputCode )
                 && ( mailDefaultHeader1.FrontEmployeeCd == mailDefaultHeader2.FrontEmployeeCd )
                 && ( mailDefaultHeader1.SalesEmployeeCd == mailDefaultHeader2.SalesEmployeeCd )
                 && ( mailDefaultHeader1.TotalAmountDispWayCd == mailDefaultHeader2.TotalAmountDispWayCd )
                 && ( mailDefaultHeader1.SalesTotalPriceTaxExc == mailDefaultHeader2.SalesTotalPriceTaxExc )
                 && ( mailDefaultHeader1.SalesPriceConsTaxTotal == mailDefaultHeader2.SalesPriceConsTaxTotal )
                 && ( mailDefaultHeader1.SalesTotalPrice == mailDefaultHeader2.SalesTotalPrice )
                 && ( mailDefaultHeader1.TotalCost == mailDefaultHeader2.TotalCost )
                 && ( mailDefaultHeader1.ConsTaxLayMethod == mailDefaultHeader2.ConsTaxLayMethod )
                 && ( mailDefaultHeader1.ClaimCode == mailDefaultHeader2.ClaimCode )
                 && ( mailDefaultHeader1.CustomerCode == mailDefaultHeader2.CustomerCode )
                 && ( mailDefaultHeader1.CustomerName == mailDefaultHeader2.CustomerName )
                 && ( mailDefaultHeader1.CustomerName2 == mailDefaultHeader2.CustomerName2 )
                 && ( mailDefaultHeader1.CustomerSnm == mailDefaultHeader2.CustomerSnm )
                 && ( mailDefaultHeader1.HonorificTitle == mailDefaultHeader2.HonorificTitle )
                 && ( mailDefaultHeader1.CustSlipNo == mailDefaultHeader2.CustSlipNo )
                 && ( mailDefaultHeader1.SlipAddressDiv == mailDefaultHeader2.SlipAddressDiv )
                 && ( mailDefaultHeader1.AddresseeCode == mailDefaultHeader2.AddresseeCode )
                 && ( mailDefaultHeader1.AddresseeName == mailDefaultHeader2.AddresseeName )
                 && ( mailDefaultHeader1.AddresseeName2 == mailDefaultHeader2.AddresseeName2 )
                 && ( mailDefaultHeader1.AddresseePostNo == mailDefaultHeader2.AddresseePostNo )
                 && ( mailDefaultHeader1.AddresseeAddr1 == mailDefaultHeader2.AddresseeAddr1 )
                 && ( mailDefaultHeader1.AddresseeAddr3 == mailDefaultHeader2.AddresseeAddr3 )
                 && ( mailDefaultHeader1.AddresseeAddr4 == mailDefaultHeader2.AddresseeAddr4 )
                 && ( mailDefaultHeader1.AddresseeTelNo == mailDefaultHeader2.AddresseeTelNo )
                 && ( mailDefaultHeader1.AddresseeFaxNo == mailDefaultHeader2.AddresseeFaxNo )
                 && ( mailDefaultHeader1.PartySaleSlipNum == mailDefaultHeader2.PartySaleSlipNum )
                 && ( mailDefaultHeader1.SlipNote == mailDefaultHeader2.SlipNote )
                 && ( mailDefaultHeader1.SlipNote2 == mailDefaultHeader2.SlipNote2 )
                 && ( mailDefaultHeader1.SlipNote3 == mailDefaultHeader2.SlipNote3 )
                 && ( mailDefaultHeader1.RetGoodsReasonDiv == mailDefaultHeader2.RetGoodsReasonDiv )
                 && ( mailDefaultHeader1.RetGoodsReason == mailDefaultHeader2.RetGoodsReason )
                 && ( mailDefaultHeader1.BusinessTypeCode == mailDefaultHeader2.BusinessTypeCode )
                 && ( mailDefaultHeader1.DeliveredGoodsDiv == mailDefaultHeader2.DeliveredGoodsDiv )
                 && ( mailDefaultHeader1.SalesAreaCode == mailDefaultHeader2.SalesAreaCode )
                 && ( mailDefaultHeader1.EraNameDispCd1 == mailDefaultHeader2.EraNameDispCd1 )
                 && ( mailDefaultHeader1.ResultsAddUpSecNm == mailDefaultHeader2.ResultsAddUpSecNm )
                 && ( mailDefaultHeader1.SalesEmployeeNm == mailDefaultHeader2.SalesEmployeeNm )
                 && ( mailDefaultHeader1.BusinessTypeName == mailDefaultHeader2.BusinessTypeName ) );
        }
        /// <summary>
        /// メール初期値ヘッダデータ比較処理
        /// </summary>
        /// <param name="target">比較対象のMailDefaultHeaderクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailDefaultHeaderクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(MailDefaultHeader target)
        {
            ArrayList resList = new ArrayList();
            if (this.Mode != target.Mode) resList.Add("Mode");
            if (this.AttachedFilePath != target.AttachedFilePath) resList.Add("AttachedFilePath");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
            if (this.DebitNoteDiv != target.DebitNoteDiv) resList.Add("DebitNoteDiv");
            if (this.SalesSlipCd != target.SalesSlipCd) resList.Add("SalesSlipCd");
            if (this.AccRecDivCd != target.AccRecDivCd) resList.Add("AccRecDivCd");
            if (this.SalesInpSecCd != target.SalesInpSecCd) resList.Add("SalesInpSecCd");
            if (this.DemandAddUpSecCd != target.DemandAddUpSecCd) resList.Add("DemandAddUpSecCd");
            if (this.ResultsAddUpSecCd != target.ResultsAddUpSecCd) resList.Add("ResultsAddUpSecCd");
            if (this.UpdateSecCd != target.UpdateSecCd) resList.Add("UpdateSecCd");
            if (this.ShipmentDay != target.ShipmentDay) resList.Add("ShipmentDay");
            if (this.SalesDate != target.SalesDate) resList.Add("SalesDate");
            if (this.AddUpADate != target.AddUpADate) resList.Add("AddUpADate");
            if (this.EstimateDivide != target.EstimateDivide) resList.Add("EstimateDivide");
            if (this.InputAgenCd != target.InputAgenCd) resList.Add("InputAgenCd");
            if (this.InputAgenNm != target.InputAgenNm) resList.Add("InputAgenNm");
            if (this.SalesInputCode != target.SalesInputCode) resList.Add("SalesInputCode");
            if (this.FrontEmployeeCd != target.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (this.SalesEmployeeCd != target.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (this.SalesTotalPriceTaxExc != target.SalesTotalPriceTaxExc) resList.Add("SalesTotalPriceTaxExc");
            if (this.SalesPriceConsTaxTotal != target.SalesPriceConsTaxTotal) resList.Add("SalesPriceConsTaxTotal");
            if (this.SalesTotalPrice != target.SalesTotalPrice) resList.Add("SalesTotalPrice");
            if (this.TotalCost != target.TotalCost) resList.Add("TotalCost");
            if (this.ConsTaxLayMethod != target.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.HonorificTitle != target.HonorificTitle) resList.Add("HonorificTitle");
            if (this.CustSlipNo != target.CustSlipNo) resList.Add("CustSlipNo");
            if (this.SlipAddressDiv != target.SlipAddressDiv) resList.Add("SlipAddressDiv");
            if (this.AddresseeCode != target.AddresseeCode) resList.Add("AddresseeCode");
            if (this.AddresseeName != target.AddresseeName) resList.Add("AddresseeName");
            if (this.AddresseeName2 != target.AddresseeName2) resList.Add("AddresseeName2");
            if (this.AddresseePostNo != target.AddresseePostNo) resList.Add("AddresseePostNo");
            if (this.AddresseeAddr1 != target.AddresseeAddr1) resList.Add("AddresseeAddr1");
            if (this.AddresseeAddr3 != target.AddresseeAddr3) resList.Add("AddresseeAddr3");
            if (this.AddresseeAddr4 != target.AddresseeAddr4) resList.Add("AddresseeAddr4");
            if (this.AddresseeTelNo != target.AddresseeTelNo) resList.Add("AddresseeTelNo");
            if (this.AddresseeFaxNo != target.AddresseeFaxNo) resList.Add("AddresseeFaxNo");
            if (this.PartySaleSlipNum != target.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (this.SlipNote != target.SlipNote) resList.Add("SlipNote");
            if (this.SlipNote2 != target.SlipNote2) resList.Add("SlipNote2");
            if (this.SlipNote3 != target.SlipNote3) resList.Add("SlipNote3");
            if (this.RetGoodsReasonDiv != target.RetGoodsReasonDiv) resList.Add("RetGoodsReasonDiv");
            if (this.RetGoodsReason != target.RetGoodsReason) resList.Add("RetGoodsReason");
            if (this.BusinessTypeCode != target.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (this.SalesAreaCode != target.SalesAreaCode) resList.Add("SalesAreaCode");
            if (this.EraNameDispCd1 != target.EraNameDispCd1) resList.Add("EraNameDispCd1");
            if (this.ResultsAddUpSecNm != target.ResultsAddUpSecNm) resList.Add("ResultsAddUpSecNm");
            if (this.SalesEmployeeNm != target.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (this.BusinessTypeName != target.BusinessTypeName) resList.Add("BusinessTypeName");

            return resList;
        }

        /// <summary>
        /// メール初期値ヘッダデータ比較処理
        /// </summary>
        /// <param name="mailDefaultHeader1">比較するMailDefaultHeaderクラスのインスタンス</param>
        /// <param name="mailDefaultHeader2">比較するMailDefaultHeaderクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailDefaultHeaderクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(MailDefaultHeader mailDefaultHeader1, MailDefaultHeader mailDefaultHeader2)
        {
            ArrayList resList = new ArrayList();
            if (mailDefaultHeader1.Mode != mailDefaultHeader2.Mode) resList.Add("Mode");
            if (mailDefaultHeader1.AttachedFilePath != mailDefaultHeader2.AttachedFilePath) resList.Add("AttachedFilePath");
            if (mailDefaultHeader1.AcptAnOdrStatus != mailDefaultHeader2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (mailDefaultHeader1.SalesSlipNum != mailDefaultHeader2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (mailDefaultHeader1.SectionCode != mailDefaultHeader2.SectionCode) resList.Add("SectionCode");
            if (mailDefaultHeader1.SubSectionCode != mailDefaultHeader2.SubSectionCode) resList.Add("SubSectionCode");
            if (mailDefaultHeader1.DebitNoteDiv != mailDefaultHeader2.DebitNoteDiv) resList.Add("DebitNoteDiv");
            if (mailDefaultHeader1.SalesSlipCd != mailDefaultHeader2.SalesSlipCd) resList.Add("SalesSlipCd");
            if (mailDefaultHeader1.AccRecDivCd != mailDefaultHeader2.AccRecDivCd) resList.Add("AccRecDivCd");
            if (mailDefaultHeader1.SalesInpSecCd != mailDefaultHeader2.SalesInpSecCd) resList.Add("SalesInpSecCd");
            if (mailDefaultHeader1.DemandAddUpSecCd != mailDefaultHeader2.DemandAddUpSecCd) resList.Add("DemandAddUpSecCd");
            if (mailDefaultHeader1.ResultsAddUpSecCd != mailDefaultHeader2.ResultsAddUpSecCd) resList.Add("ResultsAddUpSecCd");
            if (mailDefaultHeader1.UpdateSecCd != mailDefaultHeader2.UpdateSecCd) resList.Add("UpdateSecCd");
            if (mailDefaultHeader1.ShipmentDay != mailDefaultHeader2.ShipmentDay) resList.Add("ShipmentDay");
            if (mailDefaultHeader1.SalesDate != mailDefaultHeader2.SalesDate) resList.Add("SalesDate");
            if (mailDefaultHeader1.AddUpADate != mailDefaultHeader2.AddUpADate) resList.Add("AddUpADate");
            if (mailDefaultHeader1.EstimateDivide != mailDefaultHeader2.EstimateDivide) resList.Add("EstimateDivide");
            if (mailDefaultHeader1.InputAgenCd != mailDefaultHeader2.InputAgenCd) resList.Add("InputAgenCd");
            if (mailDefaultHeader1.InputAgenNm != mailDefaultHeader2.InputAgenNm) resList.Add("InputAgenNm");
            if (mailDefaultHeader1.SalesInputCode != mailDefaultHeader2.SalesInputCode) resList.Add("SalesInputCode");
            if (mailDefaultHeader1.FrontEmployeeCd != mailDefaultHeader2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (mailDefaultHeader1.SalesEmployeeCd != mailDefaultHeader2.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (mailDefaultHeader1.TotalAmountDispWayCd != mailDefaultHeader2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (mailDefaultHeader1.SalesTotalPriceTaxExc != mailDefaultHeader2.SalesTotalPriceTaxExc) resList.Add("SalesTotalPriceTaxExc");
            if (mailDefaultHeader1.SalesPriceConsTaxTotal != mailDefaultHeader2.SalesPriceConsTaxTotal) resList.Add("SalesPriceConsTaxTotal");
            if (mailDefaultHeader1.SalesTotalPrice != mailDefaultHeader2.SalesTotalPrice) resList.Add("SalesTotalPrice");
            if (mailDefaultHeader1.TotalCost != mailDefaultHeader2.TotalCost) resList.Add("TotalCost");
            if (mailDefaultHeader1.ConsTaxLayMethod != mailDefaultHeader2.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (mailDefaultHeader1.ClaimCode != mailDefaultHeader2.ClaimCode) resList.Add("ClaimCode");
            if (mailDefaultHeader1.CustomerCode != mailDefaultHeader2.CustomerCode) resList.Add("CustomerCode");
            if (mailDefaultHeader1.CustomerName != mailDefaultHeader2.CustomerName) resList.Add("CustomerName");
            if (mailDefaultHeader1.CustomerName2 != mailDefaultHeader2.CustomerName2) resList.Add("CustomerName2");
            if (mailDefaultHeader1.CustomerSnm != mailDefaultHeader2.CustomerSnm) resList.Add("CustomerSnm");
            if (mailDefaultHeader1.HonorificTitle != mailDefaultHeader2.HonorificTitle) resList.Add("HonorificTitle");
            if (mailDefaultHeader1.CustSlipNo != mailDefaultHeader2.CustSlipNo) resList.Add("CustSlipNo");
            if (mailDefaultHeader1.SlipAddressDiv != mailDefaultHeader2.SlipAddressDiv) resList.Add("SlipAddressDiv");
            if (mailDefaultHeader1.AddresseeCode != mailDefaultHeader2.AddresseeCode) resList.Add("AddresseeCode");
            if (mailDefaultHeader1.AddresseeName != mailDefaultHeader2.AddresseeName) resList.Add("AddresseeName");
            if (mailDefaultHeader1.AddresseeName2 != mailDefaultHeader2.AddresseeName2) resList.Add("AddresseeName2");
            if (mailDefaultHeader1.AddresseePostNo != mailDefaultHeader2.AddresseePostNo) resList.Add("AddresseePostNo");
            if (mailDefaultHeader1.AddresseeAddr1 != mailDefaultHeader2.AddresseeAddr1) resList.Add("AddresseeAddr1");
            if (mailDefaultHeader1.AddresseeAddr3 != mailDefaultHeader2.AddresseeAddr3) resList.Add("AddresseeAddr3");
            if (mailDefaultHeader1.AddresseeAddr4 != mailDefaultHeader2.AddresseeAddr4) resList.Add("AddresseeAddr4");
            if (mailDefaultHeader1.AddresseeTelNo != mailDefaultHeader2.AddresseeTelNo) resList.Add("AddresseeTelNo");
            if (mailDefaultHeader1.AddresseeFaxNo != mailDefaultHeader2.AddresseeFaxNo) resList.Add("AddresseeFaxNo");
            if (mailDefaultHeader1.PartySaleSlipNum != mailDefaultHeader2.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (mailDefaultHeader1.SlipNote != mailDefaultHeader2.SlipNote) resList.Add("SlipNote");
            if (mailDefaultHeader1.SlipNote2 != mailDefaultHeader2.SlipNote2) resList.Add("SlipNote2");
            if (mailDefaultHeader1.SlipNote3 != mailDefaultHeader2.SlipNote3) resList.Add("SlipNote3");
            if (mailDefaultHeader1.RetGoodsReasonDiv != mailDefaultHeader2.RetGoodsReasonDiv) resList.Add("RetGoodsReasonDiv");
            if (mailDefaultHeader1.RetGoodsReason != mailDefaultHeader2.RetGoodsReason) resList.Add("RetGoodsReason");
            if (mailDefaultHeader1.BusinessTypeCode != mailDefaultHeader2.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (mailDefaultHeader1.DeliveredGoodsDiv != mailDefaultHeader2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (mailDefaultHeader1.SalesAreaCode != mailDefaultHeader2.SalesAreaCode) resList.Add("SalesAreaCode");
            if (mailDefaultHeader1.EraNameDispCd1 != mailDefaultHeader2.EraNameDispCd1) resList.Add("EraNameDispCd1");
            if (mailDefaultHeader1.ResultsAddUpSecNm != mailDefaultHeader2.ResultsAddUpSecNm) resList.Add("ResultsAddUpSecNm");
            if (mailDefaultHeader1.SalesEmployeeNm != mailDefaultHeader2.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (mailDefaultHeader1.BusinessTypeName != mailDefaultHeader2.BusinessTypeName) resList.Add("BusinessTypeName");

            return resList;
        }
    }
}
