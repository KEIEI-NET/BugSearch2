//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesHistoryWork
    /// <summary>
    ///                      売上履歴データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上履歴データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2009/04/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/9  杉村</br>
    /// <br>                 :   ○スペルミス修正</br>
    /// <br>                 :   売上値引非課税対象額合計</br>
    /// <br>                 :   売上正価金額</br>
    /// <br>                 :   売上金額消費税額（外税）</br>
    /// <br>Update Note      :   2008/7/29  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   得意先伝票番号</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class DCSalesHistoryWork : IFileHeader
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>受注ステータス</summary>
        /// <remarks>30:売上</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上伝票番号</summary>
        private string _salesSlipNum = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>赤黒連結売上伝票番号</summary>
        /// <remarks>赤黒の相手方売上伝票番号</remarks>
        private string _debitNLnkSalesSlNum = "";

        /// <summary>売上伝票区分</summary>
        /// <remarks>0:売上,1:返品</remarks>
        private Int32 _salesSlipCd;

        /// <summary>売上商品区分</summary>
        /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整</remarks>
        private Int32 _salesGoodsCd;

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

        /// <summary>売上伝票更新区分</summary>
        /// <remarks>0:未更新,1:更新あり</remarks>
        private Int32 _salesSlipUpdateCd;

        /// <summary>伝票検索日付</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _searchSlipDate;

        /// <summary>出荷日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _shipmentDay;

        /// <summary>売上日付</summary>
        /// <remarks>(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        /// <summary>計上日付</summary>
        /// <remarks>請求日　(YYYYMMDD)</remarks>
        private DateTime _addUpADate;

        /// <summary>来勘区分</summary>
        /// <remarks>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</remarks>
        private Int32 _delayPaymentDiv;

        /// <summary>入力担当者コード</summary>
        /// <remarks>ログイン担当者（ＵＳＢ）</remarks>
        private string _inputAgenCd = "";

        /// <summary>入力担当者名称</summary>
        private string _inputAgenNm = "";

        /// <summary>売上入力者コード</summary>
        /// <remarks>入力担当者</remarks>
        private string _salesInputCode = "";

        /// <summary>売上入力者名称</summary>
        private string _salesInputName = "";

        /// <summary>受付従業員コード</summary>
        /// <remarks>受付担当者</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>受付従業員名称</summary>
        private string _frontEmployeeNm = "";

        /// <summary>販売従業員コード</summary>
        /// <remarks>計上担当者</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>販売従業員名称</summary>
        private string _salesEmployeeNm = "";

        /// <summary>総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>総額表示掛率適用区分</summary>
        /// <remarks>0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率</remarks>
        private Int32 _ttlAmntDispRateApy;

        /// <summary>売上伝票合計（税込み）</summary>
        /// <remarks>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</remarks>
        private Int64 _salesTotalTaxInc;

        /// <summary>売上伝票合計（税抜き）</summary>
        /// <remarks>売上正価金額＋売上値引金額計（税抜き）</remarks>
        private Int64 _salesTotalTaxExc;

        /// <summary>売上部品合計（税込み）</summary>
        /// <remarks>売上部品小計（税込み）＋部品値引対象額合計（税込み）</remarks>
        private Int64 _salesPrtTotalTaxInc;

        /// <summary>売上部品合計（税抜き）</summary>
        /// <remarks>売上部品小計（税抜き）＋部品値引対象額合計（税抜き）</remarks>
        private Int64 _salesPrtTotalTaxExc;

        /// <summary>売上作業合計（税込み）</summary>
        /// <remarks>売上作業小計（税込み）＋作業値引対象額合計（税込み）</remarks>
        private Int64 _salesWorkTotalTaxInc;

        /// <summary>売上作業合計（税抜き）</summary>
        /// <remarks>売上作業小計（税抜き）＋作業値引対象額合計（税抜き）</remarks>
        private Int64 _salesWorkTotalTaxExc;

        /// <summary>売上小計（税込み）</summary>
        /// <remarks>値引後の明細金額の合計（非課税含まず）</remarks>
        private Int64 _salesSubtotalTaxInc;

        /// <summary>売上小計（税抜き）</summary>
        /// <remarks>値引後の明細金額の合計（非課税含まず）</remarks>
        private Int64 _salesSubtotalTaxExc;

        /// <summary>売上部品小計（税込み）</summary>
        /// <remarks>部品明細金額の税込合計</remarks>
        private Int64 _salesPrtSubttlInc;

        /// <summary>売上部品小計（税抜き）</summary>
        /// <remarks>部品明細金額の税抜合計</remarks>
        private Int64 _salesPrtSubttlExc;

        /// <summary>売上作業小計（税込み）</summary>
        /// <remarks>作業明細金額の税込合計</remarks>
        private Int64 _salesWorkSubttlInc;

        /// <summary>売上作業小計（税抜き）</summary>
        /// <remarks>作業明細金額の税抜合計</remarks>
        private Int64 _salesWorkSubttlExc;

        /// <summary>売上正価金額</summary>
        /// <remarks>値引前の税抜売上金額（外税分、内税分、非課税分の合計）</remarks>
        private Int64 _salesNetPrice;

        /// <summary>売上小計（税）</summary>
        /// <remarks>外税対象金額の集計（税抜、値引含まず）</remarks>
        private Int64 _salesSubtotalTax;

        /// <summary>売上外税対象額</summary>
        /// <remarks>内税対象金額の集計（税抜、値引含まず） </remarks>
        private Int64 _itdedSalesOutTax;

        /// <summary>売上内税対象額</summary>
        /// <remarks>非課税対象金額の集計（値引含まず）</remarks>
        private Int64 _itdedSalesInTax;

        /// <summary>売上小計非課税対象額</summary>
        /// <remarks>売上金額消費税額（外税）+売上金額消費税額（内税）値引き含まず</remarks>
        private Int64 _salSubttlSubToTaxFre;

        /// <summary>売上金額消費税額（外税）</summary>
        /// <remarks>値引前の外税商品の消費税</remarks>
        private Int64 _salesOutTax;

        /// <summary>売上金額消費税額（内税）</summary>
        /// <remarks>値引前の内税商品の消費税</remarks>
        private Int64 _salAmntConsTaxInclu;

        /// <summary>売上値引金額計（税抜き）</summary>
        private Int64 _salesDisTtlTaxExc;

        /// <summary>売上値引外税対象額合計</summary>
        /// <remarks>外税商品値引の外税対象額（税抜）</remarks>
        private Int64 _itdedSalesDisOutTax;

        /// <summary>売上値引内税対象額合計</summary>
        /// <remarks>内税商品値引の内税対象額（税抜）</remarks>
        private Int64 _itdedSalesDisInTax;

        /// <summary>部品値引対象額合計（税抜き）</summary>
        /// <remarks>部品値引額（税抜き）</remarks>
        private Int64 _itdedPartsDisOutTax;

        /// <summary>部品値引対象額合計（税込み）</summary>
        /// <remarks>部品値引額（税込み）</remarks>
        private Int64 _itdedPartsDisInTax;

        /// <summary>作業値引対象額合計（税抜き）</summary>
        /// <remarks>作業値引額（税抜き）</remarks>
        private Int64 _itdedWorkDisOutTax;

        /// <summary>作業値引対象額合計（税込み）</summary>
        /// <remarks>作業値引額（税込み）</remarks>
        private Int64 _itdedWorkDisInTax;

        /// <summary>売上値引非課税対象額合計</summary>
        /// <remarks>非課税商品値引の非課税対象額</remarks>
        private Int64 _itdedSalesDisTaxFre;

        /// <summary>売上値引消費税額（外税）</summary>
        /// <remarks>外税商品値引の消費税額</remarks>
        private Int64 _salesDisOutTax;

        /// <summary>仕入値引消費税額（内税）</summary>
        private Int64 _salesDisTtlTaxInclu;

        /// <summary>部品値引率</summary>
        /// <remarks>小計に対しての部品値引率</remarks>
        private Double _partsDiscountRate;

        /// <summary>工賃値引率</summary>
        /// <remarks>小計に対しての工賃値引率</remarks>
        private Double _ravorDiscountRate;

        /// <summary>原価金額計</summary>
        private Int64 _totalCost;

        /// <summary>消費税転嫁方式</summary>
        /// <remarks>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>消費税税率</summary>
        /// <remarks>変更2007/8/22(型,桁) 塩原</remarks>
        private Double _consTaxRate;

        /// <summary>端数処理区分</summary>
        /// <remarks>1:切捨て,2:四捨五入,3:切上げ　（消費税）</remarks>
        private Int32 _fractionProcCd;

        /// <summary>売掛消費税</summary>
        private Int64 _accRecConsTax;

        /// <summary>自動入金区分</summary>
        /// <remarks>0:通常入金,1:自動入金</remarks>
        private Int32 _autoDepositCd;

        /// <summary>自動入金伝票番号</summary>
        /// <remarks>自動入金時の入金伝票番号</remarks>
        private Int32 _autoDepositSlipNo;

        /// <summary>入金引当合計額</summary>
        /// <remarks>預り金引当合計額を含む</remarks>
        private Int64 _depositAllowanceTtl;

        /// <summary>入金引当残高</summary>
        private Int64 _depositAlwcBlnce;

        /// <summary>請求先コード</summary>
        private Int32 _claimCode;

        /// <summary>請求先略称</summary>
        private string _claimSnm = "";

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

        /// <summary>諸口コード</summary>
        /// <remarks>0:正式得意先,1:諸口得意先</remarks>
        private Int32 _outputNameCode;

        /// <summary>諸口名称</summary>
        private string _outputName = "";

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
        /// <remarks>得意先注文番号</remarks>
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

        /// <summary>明細行数</summary>
        /// <remarks>伝票内の明細の行数（諸費用明細は除く）</remarks>
        private Int32 _detailRowCount;

        /// <summary>ＥＤＩ送信日</summary>
        /// <remarks>YYYYMMDD （ErectricDataInterface）</remarks>
        private DateTime _ediSendDate;

        /// <summary>ＥＤＩ取込日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ediTakeInDate;

        /// <summary>ＵＯＥリマーク１</summary>
        /// <remarks>UserOrderEntory</remarks>
        private string _uoeRemark1 = "";

        /// <summary>ＵＯＥリマーク２</summary>
        private string _uoeRemark2 = "";

        /// <summary>伝票発行区分</summary>
        /// <remarks>0:しない 1:する</remarks>
        private Int32 _slipPrintDivCd;

        /// <summary>伝票発行済区分</summary>
        /// <remarks>0:未発行 1:発行済</remarks>
        private Int32 _slipPrintFinishCd;

        /// <summary>売上伝票発行日</summary>
        private DateTime _salesSlipPrintDate;

        /// <summary>業種コード</summary>
        private Int32 _businessTypeCode;

        /// <summary>業種名称</summary>
        private string _businessTypeName = "";

        /// <summary>納品区分</summary>
        /// <remarks>例) 1:配達,2:店頭渡し,3:直送,…</remarks>
        private Int32 _deliveredGoodsDiv;

        /// <summary>納品区分名称</summary>
        private string _deliveredGoodsDivNm = "";

        /// <summary>販売エリアコード</summary>
        /// <remarks>地区コード</remarks>
        private Int32 _salesAreaCode;

        /// <summary>販売エリア名称</summary>
        private string _salesAreaName = "";

        /// <summary>伝票印刷設定用帳票ID</summary>
        /// <remarks>売上形式とセットで伝票タイプ管理マスタを参照</remarks>
        private string _slipPrtSetPaperId = "";

        /// <summary>一式伝票区分</summary>
        /// <remarks>0:通常伝票,1:一式伝票</remarks>
        private Int32 _completeCd;

        /// <summary>売上金額端数処理区分</summary>
        /// <remarks>1:切捨て,2:四捨五入,3:切上げ　（売上明細データの金額用）</remarks>
        private Int32 _salesPriceFracProcCd;

        /// <summary>在庫商品合計金額（税抜）</summary>
        /// <remarks>在庫取寄区分が０の明細金額の集計</remarks>
        private Int64 _stockGoodsTtlTaxExc;

        /// <summary>純正商品合計金額（税抜）</summary>
        /// <remarks>商品属性が０の明細金額の集計</remarks>
        private Int64 _pureGoodsTtlTaxExc;

        /// <summary>定価印刷区分</summary>
        private Int32 _listPricePrintDiv;

        /// <summary>元号表示区分１</summary>
        /// <remarks>車輌　　0:西暦　1:和暦</remarks>
        private Int32 _eraNameDispCd1;


        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
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
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
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
        /// <value>共通ファイルヘッダ</value>
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
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
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
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
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
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
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

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>30:売上</value>
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

        /// public propaty name  :  DebitNLnkSalesSlNum
        /// <summary>赤黒連結売上伝票番号プロパティ</summary>
        /// <value>赤黒の相手方売上伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤黒連結売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DebitNLnkSalesSlNum
        {
            get { return _debitNLnkSalesSlNum; }
            set { _debitNLnkSalesSlNum = value; }
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

        /// public propaty name  :  SalesGoodsCd
        /// <summary>売上商品区分プロパティ</summary>
        /// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上商品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesGoodsCd
        {
            get { return _salesGoodsCd; }
            set { _salesGoodsCd = value; }
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

        /// public propaty name  :  SalesSlipUpdateCd
        /// <summary>売上伝票更新区分プロパティ</summary>
        /// <value>0:未更新,1:更新あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipUpdateCd
        {
            get { return _salesSlipUpdateCd; }
            set { _salesSlipUpdateCd = value; }
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
        /// <value>(YYYYMMDD)</value>
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

        /// public propaty name  :  DelayPaymentDiv
        /// <summary>来勘区分プロパティ</summary>
        /// <value>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   来勘区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DelayPaymentDiv
        {
            get { return _delayPaymentDiv; }
            set { _delayPaymentDiv = value; }
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
        /// <value>入力担当者</value>
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
        /// <value>受付担当者</value>
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
        /// <value>計上担当者</value>
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

        /// public propaty name  :  TtlAmntDispRateApy
        /// <summary>総額表示掛率適用区分プロパティ</summary>
        /// <value>0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示掛率適用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TtlAmntDispRateApy
        {
            get { return _ttlAmntDispRateApy; }
            set { _ttlAmntDispRateApy = value; }
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

        /// public propaty name  :  SalesPrtTotalTaxInc
        /// <summary>売上部品合計（税込み）プロパティ</summary>
        /// <value>売上部品小計（税込み）＋部品値引対象額合計（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上部品合計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesPrtTotalTaxInc
        {
            get { return _salesPrtTotalTaxInc; }
            set { _salesPrtTotalTaxInc = value; }
        }

        /// public propaty name  :  SalesPrtTotalTaxExc
        /// <summary>売上部品合計（税抜き）プロパティ</summary>
        /// <value>売上部品小計（税抜き）＋部品値引対象額合計（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上部品合計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesPrtTotalTaxExc
        {
            get { return _salesPrtTotalTaxExc; }
            set { _salesPrtTotalTaxExc = value; }
        }

        /// public propaty name  :  SalesWorkTotalTaxInc
        /// <summary>売上作業合計（税込み）プロパティ</summary>
        /// <value>売上作業小計（税込み）＋作業値引対象額合計（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上作業合計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesWorkTotalTaxInc
        {
            get { return _salesWorkTotalTaxInc; }
            set { _salesWorkTotalTaxInc = value; }
        }

        /// public propaty name  :  SalesWorkTotalTaxExc
        /// <summary>売上作業合計（税抜き）プロパティ</summary>
        /// <value>売上作業小計（税抜き）＋作業値引対象額合計（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上作業合計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesWorkTotalTaxExc
        {
            get { return _salesWorkTotalTaxExc; }
            set { _salesWorkTotalTaxExc = value; }
        }

        /// public propaty name  :  SalesSubtotalTaxInc
        /// <summary>売上小計（税込み）プロパティ</summary>
        /// <value>値引後の明細金額の合計（非課税含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上小計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesSubtotalTaxInc
        {
            get { return _salesSubtotalTaxInc; }
            set { _salesSubtotalTaxInc = value; }
        }

        /// public propaty name  :  SalesSubtotalTaxExc
        /// <summary>売上小計（税抜き）プロパティ</summary>
        /// <value>値引後の明細金額の合計（非課税含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上小計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesSubtotalTaxExc
        {
            get { return _salesSubtotalTaxExc; }
            set { _salesSubtotalTaxExc = value; }
        }

        /// public propaty name  :  SalesPrtSubttlInc
        /// <summary>売上部品小計（税込み）プロパティ</summary>
        /// <value>部品明細金額の税込合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上部品小計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesPrtSubttlInc
        {
            get { return _salesPrtSubttlInc; }
            set { _salesPrtSubttlInc = value; }
        }

        /// public propaty name  :  SalesPrtSubttlExc
        /// <summary>売上部品小計（税抜き）プロパティ</summary>
        /// <value>部品明細金額の税抜合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上部品小計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesPrtSubttlExc
        {
            get { return _salesPrtSubttlExc; }
            set { _salesPrtSubttlExc = value; }
        }

        /// public propaty name  :  SalesWorkSubttlInc
        /// <summary>売上作業小計（税込み）プロパティ</summary>
        /// <value>作業明細金額の税込合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上作業小計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesWorkSubttlInc
        {
            get { return _salesWorkSubttlInc; }
            set { _salesWorkSubttlInc = value; }
        }

        /// public propaty name  :  SalesWorkSubttlExc
        /// <summary>売上作業小計（税抜き）プロパティ</summary>
        /// <value>作業明細金額の税抜合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上作業小計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesWorkSubttlExc
        {
            get { return _salesWorkSubttlExc; }
            set { _salesWorkSubttlExc = value; }
        }

        /// public propaty name  :  SalesNetPrice
        /// <summary>売上正価金額プロパティ</summary>
        /// <value>値引前の税抜売上金額（外税分、内税分、非課税分の合計）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上正価金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesNetPrice
        {
            get { return _salesNetPrice; }
            set { _salesNetPrice = value; }
        }

        /// public propaty name  :  SalesSubtotalTax
        /// <summary>売上小計（税）プロパティ</summary>
        /// <value>外税対象金額の集計（税抜、値引含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上小計（税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesSubtotalTax
        {
            get { return _salesSubtotalTax; }
            set { _salesSubtotalTax = value; }
        }

        /// public propaty name  :  ItdedSalesOutTax
        /// <summary>売上外税対象額プロパティ</summary>
        /// <value>内税対象金額の集計（税抜、値引含まず） </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上外税対象額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedSalesOutTax
        {
            get { return _itdedSalesOutTax; }
            set { _itdedSalesOutTax = value; }
        }

        /// public propaty name  :  ItdedSalesInTax
        /// <summary>売上内税対象額プロパティ</summary>
        /// <value>非課税対象金額の集計（値引含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上内税対象額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedSalesInTax
        {
            get { return _itdedSalesInTax; }
            set { _itdedSalesInTax = value; }
        }

        /// public propaty name  :  SalSubttlSubToTaxFre
        /// <summary>売上小計非課税対象額プロパティ</summary>
        /// <value>売上金額消費税額（外税）+売上金額消費税額（内税）値引き含まず</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上小計非課税対象額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalSubttlSubToTaxFre
        {
            get { return _salSubttlSubToTaxFre; }
            set { _salSubttlSubToTaxFre = value; }
        }

        /// public propaty name  :  SalesOutTax
        /// <summary>売上金額消費税額（外税）プロパティ</summary>
        /// <value>値引前の外税商品の消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額消費税額（外税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesOutTax
        {
            get { return _salesOutTax; }
            set { _salesOutTax = value; }
        }

        /// public propaty name  :  SalAmntConsTaxInclu
        /// <summary>売上金額消費税額（内税）プロパティ</summary>
        /// <value>値引前の内税商品の消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額消費税額（内税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalAmntConsTaxInclu
        {
            get { return _salAmntConsTaxInclu; }
            set { _salAmntConsTaxInclu = value; }
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

        /// public propaty name  :  ItdedSalesDisOutTax
        /// <summary>売上値引外税対象額合計プロパティ</summary>
        /// <value>外税商品値引の外税対象額（税抜）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上値引外税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedSalesDisOutTax
        {
            get { return _itdedSalesDisOutTax; }
            set { _itdedSalesDisOutTax = value; }
        }

        /// public propaty name  :  ItdedSalesDisInTax
        /// <summary>売上値引内税対象額合計プロパティ</summary>
        /// <value>内税商品値引の内税対象額（税抜）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上値引内税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedSalesDisInTax
        {
            get { return _itdedSalesDisInTax; }
            set { _itdedSalesDisInTax = value; }
        }

        /// public propaty name  :  ItdedPartsDisOutTax
        /// <summary>部品値引対象額合計（税抜き）プロパティ</summary>
        /// <value>部品値引額（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品値引対象額合計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedPartsDisOutTax
        {
            get { return _itdedPartsDisOutTax; }
            set { _itdedPartsDisOutTax = value; }
        }

        /// public propaty name  :  ItdedPartsDisInTax
        /// <summary>部品値引対象額合計（税込み）プロパティ</summary>
        /// <value>部品値引額（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品値引対象額合計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedPartsDisInTax
        {
            get { return _itdedPartsDisInTax; }
            set { _itdedPartsDisInTax = value; }
        }

        /// public propaty name  :  ItdedWorkDisOutTax
        /// <summary>作業値引対象額合計（税抜き）プロパティ</summary>
        /// <value>作業値引額（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作業値引対象額合計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedWorkDisOutTax
        {
            get { return _itdedWorkDisOutTax; }
            set { _itdedWorkDisOutTax = value; }
        }

        /// public propaty name  :  ItdedWorkDisInTax
        /// <summary>作業値引対象額合計（税込み）プロパティ</summary>
        /// <value>作業値引額（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作業値引対象額合計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedWorkDisInTax
        {
            get { return _itdedWorkDisInTax; }
            set { _itdedWorkDisInTax = value; }
        }

        /// public propaty name  :  ItdedSalesDisTaxFre
        /// <summary>売上値引非課税対象額合計プロパティ</summary>
        /// <value>非課税商品値引の非課税対象額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上値引非課税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedSalesDisTaxFre
        {
            get { return _itdedSalesDisTaxFre; }
            set { _itdedSalesDisTaxFre = value; }
        }

        /// public propaty name  :  SalesDisOutTax
        /// <summary>売上値引消費税額（外税）プロパティ</summary>
        /// <value>外税商品値引の消費税額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上値引消費税額（外税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesDisOutTax
        {
            get { return _salesDisOutTax; }
            set { _salesDisOutTax = value; }
        }

        /// public propaty name  :  SalesDisTtlTaxInclu
        /// <summary>仕入値引消費税額（内税）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引消費税額（内税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesDisTtlTaxInclu
        {
            get { return _salesDisTtlTaxInclu; }
            set { _salesDisTtlTaxInclu = value; }
        }

        /// public propaty name  :  PartsDiscountRate
        /// <summary>部品値引率プロパティ</summary>
        /// <value>小計に対しての部品値引率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品値引率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PartsDiscountRate
        {
            get { return _partsDiscountRate; }
            set { _partsDiscountRate = value; }
        }

        /// public propaty name  :  RavorDiscountRate
        /// <summary>工賃値引率プロパティ</summary>
        /// <value>小計に対しての工賃値引率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   工賃値引率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double RavorDiscountRate
        {
            get { return _ravorDiscountRate; }
            set { _ravorDiscountRate = value; }
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

        /// public propaty name  :  ConsTaxRate
        /// <summary>消費税税率プロパティ</summary>
        /// <value>変更2007/8/22(型,桁) 塩原</value>
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

        /// public propaty name  :  FractionProcCd
        /// <summary>端数処理区分プロパティ</summary>
        /// <value>1:切捨て,2:四捨五入,3:切上げ　（消費税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FractionProcCd
        {
            get { return _fractionProcCd; }
            set { _fractionProcCd = value; }
        }

        /// public propaty name  :  AccRecConsTax
        /// <summary>売掛消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売掛消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AccRecConsTax
        {
            get { return _accRecConsTax; }
            set { _accRecConsTax = value; }
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

        /// public propaty name  :  AutoDepositSlipNo
        /// <summary>自動入金伝票番号プロパティ</summary>
        /// <value>自動入金時の入金伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動入金伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoDepositSlipNo
        {
            get { return _autoDepositSlipNo; }
            set { _autoDepositSlipNo = value; }
        }

        /// public propaty name  :  DepositAllowanceTtl
        /// <summary>入金引当合計額プロパティ</summary>
        /// <value>預り金引当合計額を含む</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金引当合計額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DepositAllowanceTtl
        {
            get { return _depositAllowanceTtl; }
            set { _depositAllowanceTtl = value; }
        }

        /// public propaty name  :  DepositAlwcBlnce
        /// <summary>入金引当残高プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金引当残高プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DepositAlwcBlnce
        {
            get { return _depositAlwcBlnce; }
            set { _depositAlwcBlnce = value; }
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

        /// public propaty name  :  OutputNameCode
        /// <summary>諸口コードプロパティ</summary>
        /// <value>0:正式得意先,1:諸口得意先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   諸口コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OutputNameCode
        {
            get { return _outputNameCode; }
            set { _outputNameCode = value; }
        }

        /// public propaty name  :  OutputName
        /// <summary>諸口名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   諸口名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OutputName
        {
            get { return _outputName; }
            set { _outputName = value; }
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
        /// <value>得意先注文番号</value>
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

        /// public propaty name  :  DetailRowCount
        /// <summary>明細行数プロパティ</summary>
        /// <value>伝票内の明細の行数（諸費用明細は除く）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細行数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DetailRowCount
        {
            get { return _detailRowCount; }
            set { _detailRowCount = value; }
        }

        /// public propaty name  :  EdiSendDate
        /// <summary>ＥＤＩ送信日プロパティ</summary>
        /// <value>YYYYMMDD （ErectricDataInterface）</value>
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
        /// <value>YYYYMMDD</value>
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

        /// public propaty name  :  SlipPrintDivCd
        /// <summary>伝票発行区分プロパティ</summary>
        /// <value>0:しない 1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票発行区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipPrintDivCd
        {
            get { return _slipPrintDivCd; }
            set { _slipPrintDivCd = value; }
        }

        /// public propaty name  :  SlipPrintFinishCd
        /// <summary>伝票発行済区分プロパティ</summary>
        /// <value>0:未発行 1:発行済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票発行済区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipPrintFinishCd
        {
            get { return _slipPrintFinishCd; }
            set { _slipPrintFinishCd = value; }
        }

        /// public propaty name  :  SalesSlipPrintDate
        /// <summary>売上伝票発行日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesSlipPrintDate
        {
            get { return _salesSlipPrintDate; }
            set { _salesSlipPrintDate = value; }
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

        /// public propaty name  :  DeliveredGoodsDivNm
        /// <summary>納品区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliveredGoodsDivNm
        {
            get { return _deliveredGoodsDivNm; }
            set { _deliveredGoodsDivNm = value; }
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

        /// public propaty name  :  SlipPrtSetPaperId
        /// <summary>伝票印刷設定用帳票IDプロパティ</summary>
        /// <value>売上形式とセットで伝票タイプ管理マスタを参照</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票印刷設定用帳票IDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipPrtSetPaperId
        {
            get { return _slipPrtSetPaperId; }
            set { _slipPrtSetPaperId = value; }
        }

        /// public propaty name  :  CompleteCd
        /// <summary>一式伝票区分プロパティ</summary>
        /// <value>0:通常伝票,1:一式伝票</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   一式伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CompleteCd
        {
            get { return _completeCd; }
            set { _completeCd = value; }
        }

        /// public propaty name  :  SalesPriceFracProcCd
        /// <summary>売上金額端数処理区分プロパティ</summary>
        /// <value>1:切捨て,2:四捨五入,3:切上げ　（売上明細データの金額用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額端数処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesPriceFracProcCd
        {
            get { return _salesPriceFracProcCd; }
            set { _salesPriceFracProcCd = value; }
        }

        /// public propaty name  :  StockGoodsTtlTaxExc
        /// <summary>在庫商品合計金額（税抜）プロパティ</summary>
        /// <value>在庫取寄区分が０の明細金額の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫商品合計金額（税抜）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockGoodsTtlTaxExc
        {
            get { return _stockGoodsTtlTaxExc; }
            set { _stockGoodsTtlTaxExc = value; }
        }

        /// public propaty name  :  PureGoodsTtlTaxExc
        /// <summary>純正商品合計金額（税抜）プロパティ</summary>
        /// <value>商品属性が０の明細金額の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正商品合計金額（税抜）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PureGoodsTtlTaxExc
        {
            get { return _pureGoodsTtlTaxExc; }
            set { _pureGoodsTtlTaxExc = value; }
        }

        /// public propaty name  :  ListPricePrintDiv
        /// <summary>定価印刷区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価印刷区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ListPricePrintDiv
        {
            get { return _listPricePrintDiv; }
            set { _listPricePrintDiv = value; }
        }

        /// public propaty name  :  EraNameDispCd1
        /// <summary>元号表示区分１プロパティ</summary>
        /// <value>車輌　　0:西暦　1:和暦</value>
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


        /// <summary>
        /// 売上履歴データワークコンストラクタ
        /// </summary>
        /// <returns>SalesHistoryWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistoryWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DCSalesHistoryWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SalesHistoryWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalesHistoryWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class DCSalesHistoryWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistoryWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesHistoryWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DCSalesHistoryWork || graph is ArrayList || graph is DCSalesHistoryWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(DCSalesHistoryWork).FullName));

            if (graph != null && graph is DCSalesHistoryWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.DCSalesHistoryWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DCSalesHistoryWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DCSalesHistoryWork[])graph).Length;
            }
            else if (graph is DCSalesHistoryWork)
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
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //赤伝区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //赤黒連結売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //DebitNLnkSalesSlNum
            //売上伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCd
            //売上商品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesGoodsCd
            //売掛区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AccRecDivCd
            //売上入力拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SalesInpSecCd
            //請求計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //DemandAddUpSecCd
            //実績計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ResultsAddUpSecCd
            //更新拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdateSecCd
            //売上伝票更新区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipUpdateCd
            //伝票検索日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchSlipDate
            //出荷日付
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentDay
            //売上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //計上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //来勘区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DelayPaymentDiv
            //入力担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //InputAgenCd
            //入力担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //InputAgenNm
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
            //総額表示方法区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalAmountDispWayCd
            //総額表示掛率適用区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TtlAmntDispRateApy
            //売上伝票合計（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxInc
            //売上伝票合計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxExc
            //売上部品合計（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesPrtTotalTaxInc
            //売上部品合計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesPrtTotalTaxExc
            //売上作業合計（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesWorkTotalTaxInc
            //売上作業合計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesWorkTotalTaxExc
            //売上小計（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSubtotalTaxInc
            //売上小計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSubtotalTaxExc
            //売上部品小計（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesPrtSubttlInc
            //売上部品小計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesPrtSubttlExc
            //売上作業小計（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesWorkSubttlInc
            //売上作業小計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesWorkSubttlExc
            //売上正価金額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesNetPrice
            //売上小計（税）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSubtotalTax
            //売上外税対象額
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesOutTax
            //売上内税対象額
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesInTax
            //売上小計非課税対象額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalSubttlSubToTaxFre
            //売上金額消費税額（外税）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesOutTax
            //売上金額消費税額（内税）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalAmntConsTaxInclu
            //売上値引金額計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesDisTtlTaxExc
            //売上値引外税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesDisOutTax
            //売上値引内税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesDisInTax
            //部品値引対象額合計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedPartsDisOutTax
            //部品値引対象額合計（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedPartsDisInTax
            //作業値引対象額合計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedWorkDisOutTax
            //作業値引対象額合計（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedWorkDisInTax
            //売上値引非課税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesDisTaxFre
            //売上値引消費税額（外税）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesDisOutTax
            //仕入値引消費税額（内税）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesDisTtlTaxInclu
            //部品値引率
            serInfo.MemberInfo.Add(typeof(Double)); //PartsDiscountRate
            //工賃値引率
            serInfo.MemberInfo.Add(typeof(Double)); //RavorDiscountRate
            //原価金額計
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalCost
            //消費税転嫁方式
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //消費税税率
            serInfo.MemberInfo.Add(typeof(Double)); //ConsTaxRate
            //端数処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //FractionProcCd
            //売掛消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //AccRecConsTax
            //自動入金区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoDepositCd
            //自動入金伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoDepositSlipNo
            //入金引当合計額
            serInfo.MemberInfo.Add(typeof(Int64)); //DepositAllowanceTtl
            //入金引当残高
            serInfo.MemberInfo.Add(typeof(Int64)); //DepositAlwcBlnce
            //請求先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //請求先略称
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //得意先名称2
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //敬称
            serInfo.MemberInfo.Add(typeof(string)); //HonorificTitle
            //諸口コード
            serInfo.MemberInfo.Add(typeof(Int32)); //OutputNameCode
            //諸口名称
            serInfo.MemberInfo.Add(typeof(string)); //OutputName
            //得意先伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CustSlipNo
            //伝票住所区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipAddressDiv
            //納品先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //AddresseeCode
            //納品先名称
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName
            //納品先名称2
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName2
            //納品先郵便番号
            serInfo.MemberInfo.Add(typeof(string)); //AddresseePostNo
            //納品先住所1(都道府県市区郡・町村・字)
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeAddr1
            //納品先住所3(番地)
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeAddr3
            //納品先住所4(アパート名称)
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeAddr4
            //納品先電話番号
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeTelNo
            //納品先FAX番号
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeFaxNo
            //相手先伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //伝票備考
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote
            //伝票備考２
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote2
            //伝票備考３
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote3
            //返品理由コード
            serInfo.MemberInfo.Add(typeof(Int32)); //RetGoodsReasonDiv
            //返品理由
            serInfo.MemberInfo.Add(typeof(string)); //RetGoodsReason
            //明細行数
            serInfo.MemberInfo.Add(typeof(Int32)); //DetailRowCount
            //ＥＤＩ送信日
            serInfo.MemberInfo.Add(typeof(Int32)); //EdiSendDate
            //ＥＤＩ取込日
            serInfo.MemberInfo.Add(typeof(Int32)); //EdiTakeInDate
            //ＵＯＥリマーク１
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //ＵＯＥリマーク２
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
            //伝票発行区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipPrintDivCd
            //伝票発行済区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipPrintFinishCd
            //売上伝票発行日
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipPrintDate
            //業種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessTypeCode
            //業種名称
            serInfo.MemberInfo.Add(typeof(string)); //BusinessTypeName
            //納品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliveredGoodsDiv
            //納品区分名称
            serInfo.MemberInfo.Add(typeof(string)); //DeliveredGoodsDivNm
            //販売エリアコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //販売エリア名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //伝票印刷設定用帳票ID
            serInfo.MemberInfo.Add(typeof(string)); //SlipPrtSetPaperId
            //一式伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CompleteCd
            //売上金額端数処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesPriceFracProcCd
            //在庫商品合計金額（税抜）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockGoodsTtlTaxExc
            //純正商品合計金額（税抜）
            serInfo.MemberInfo.Add(typeof(Int64)); //PureGoodsTtlTaxExc
            //定価印刷区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPricePrintDiv
            //元号表示区分１
            serInfo.MemberInfo.Add(typeof(Int32)); //EraNameDispCd1


            serInfo.Serialize(writer, serInfo);
            if (graph is DCSalesHistoryWork)
            {
                DCSalesHistoryWork temp = (DCSalesHistoryWork)graph;

                SetSalesHistoryWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DCSalesHistoryWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DCSalesHistoryWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DCSalesHistoryWork temp in lst)
                {
                    SetSalesHistoryWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesHistoryWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 124;

        /// <summary>
        ///  SalesHistoryWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistoryWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSalesHistoryWork(System.IO.BinaryWriter writer, DCSalesHistoryWork temp)
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
            //受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //拠点コード
            writer.Write(temp.SectionCode);
            //部門コード
            writer.Write(temp.SubSectionCode);
            //赤伝区分
            writer.Write(temp.DebitNoteDiv);
            //赤黒連結売上伝票番号
            writer.Write(temp.DebitNLnkSalesSlNum);
            //売上伝票区分
            writer.Write(temp.SalesSlipCd);
            //売上商品区分
            writer.Write(temp.SalesGoodsCd);
            //売掛区分
            writer.Write(temp.AccRecDivCd);
            //売上入力拠点コード
            writer.Write(temp.SalesInpSecCd);
            //請求計上拠点コード
            writer.Write(temp.DemandAddUpSecCd);
            //実績計上拠点コード
            writer.Write(temp.ResultsAddUpSecCd);
            //更新拠点コード
            writer.Write(temp.UpdateSecCd);
            //売上伝票更新区分
            writer.Write(temp.SalesSlipUpdateCd);
            //伝票検索日付
            writer.Write((Int64)temp.SearchSlipDate.Ticks);
            //出荷日付
            writer.Write((Int64)temp.ShipmentDay.Ticks);
            //売上日付
            writer.Write((Int64)temp.SalesDate.Ticks);
            //計上日付
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //来勘区分
            writer.Write(temp.DelayPaymentDiv);
            //入力担当者コード
            writer.Write(temp.InputAgenCd);
            //入力担当者名称
            writer.Write(temp.InputAgenNm);
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
            //総額表示方法区分
            writer.Write(temp.TotalAmountDispWayCd);
            //総額表示掛率適用区分
            writer.Write(temp.TtlAmntDispRateApy);
            //売上伝票合計（税込み）
            writer.Write(temp.SalesTotalTaxInc);
            //売上伝票合計（税抜き）
            writer.Write(temp.SalesTotalTaxExc);
            //売上部品合計（税込み）
            writer.Write(temp.SalesPrtTotalTaxInc);
            //売上部品合計（税抜き）
            writer.Write(temp.SalesPrtTotalTaxExc);
            //売上作業合計（税込み）
            writer.Write(temp.SalesWorkTotalTaxInc);
            //売上作業合計（税抜き）
            writer.Write(temp.SalesWorkTotalTaxExc);
            //売上小計（税込み）
            writer.Write(temp.SalesSubtotalTaxInc);
            //売上小計（税抜き）
            writer.Write(temp.SalesSubtotalTaxExc);
            //売上部品小計（税込み）
            writer.Write(temp.SalesPrtSubttlInc);
            //売上部品小計（税抜き）
            writer.Write(temp.SalesPrtSubttlExc);
            //売上作業小計（税込み）
            writer.Write(temp.SalesWorkSubttlInc);
            //売上作業小計（税抜き）
            writer.Write(temp.SalesWorkSubttlExc);
            //売上正価金額
            writer.Write(temp.SalesNetPrice);
            //売上小計（税）
            writer.Write(temp.SalesSubtotalTax);
            //売上外税対象額
            writer.Write(temp.ItdedSalesOutTax);
            //売上内税対象額
            writer.Write(temp.ItdedSalesInTax);
            //売上小計非課税対象額
            writer.Write(temp.SalSubttlSubToTaxFre);
            //売上金額消費税額（外税）
            writer.Write(temp.SalesOutTax);
            //売上金額消費税額（内税）
            writer.Write(temp.SalAmntConsTaxInclu);
            //売上値引金額計（税抜き）
            writer.Write(temp.SalesDisTtlTaxExc);
            //売上値引外税対象額合計
            writer.Write(temp.ItdedSalesDisOutTax);
            //売上値引内税対象額合計
            writer.Write(temp.ItdedSalesDisInTax);
            //部品値引対象額合計（税抜き）
            writer.Write(temp.ItdedPartsDisOutTax);
            //部品値引対象額合計（税込み）
            writer.Write(temp.ItdedPartsDisInTax);
            //作業値引対象額合計（税抜き）
            writer.Write(temp.ItdedWorkDisOutTax);
            //作業値引対象額合計（税込み）
            writer.Write(temp.ItdedWorkDisInTax);
            //売上値引非課税対象額合計
            writer.Write(temp.ItdedSalesDisTaxFre);
            //売上値引消費税額（外税）
            writer.Write(temp.SalesDisOutTax);
            //仕入値引消費税額（内税）
            writer.Write(temp.SalesDisTtlTaxInclu);
            //部品値引率
            writer.Write(temp.PartsDiscountRate);
            //工賃値引率
            writer.Write(temp.RavorDiscountRate);
            //原価金額計
            writer.Write(temp.TotalCost);
            //消費税転嫁方式
            writer.Write(temp.ConsTaxLayMethod);
            //消費税税率
            writer.Write(temp.ConsTaxRate);
            //端数処理区分
            writer.Write(temp.FractionProcCd);
            //売掛消費税
            writer.Write(temp.AccRecConsTax);
            //自動入金区分
            writer.Write(temp.AutoDepositCd);
            //自動入金伝票番号
            writer.Write(temp.AutoDepositSlipNo);
            //入金引当合計額
            writer.Write(temp.DepositAllowanceTtl);
            //入金引当残高
            writer.Write(temp.DepositAlwcBlnce);
            //請求先コード
            writer.Write(temp.ClaimCode);
            //請求先略称
            writer.Write(temp.ClaimSnm);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先名称
            writer.Write(temp.CustomerName);
            //得意先名称2
            writer.Write(temp.CustomerName2);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //敬称
            writer.Write(temp.HonorificTitle);
            //諸口コード
            writer.Write(temp.OutputNameCode);
            //諸口名称
            writer.Write(temp.OutputName);
            //得意先伝票番号
            writer.Write(temp.CustSlipNo);
            //伝票住所区分
            writer.Write(temp.SlipAddressDiv);
            //納品先コード
            writer.Write(temp.AddresseeCode);
            //納品先名称
            writer.Write(temp.AddresseeName);
            //納品先名称2
            writer.Write(temp.AddresseeName2);
            //納品先郵便番号
            writer.Write(temp.AddresseePostNo);
            //納品先住所1(都道府県市区郡・町村・字)
            writer.Write(temp.AddresseeAddr1);
            //納品先住所3(番地)
            writer.Write(temp.AddresseeAddr3);
            //納品先住所4(アパート名称)
            writer.Write(temp.AddresseeAddr4);
            //納品先電話番号
            writer.Write(temp.AddresseeTelNo);
            //納品先FAX番号
            writer.Write(temp.AddresseeFaxNo);
            //相手先伝票番号
            writer.Write(temp.PartySaleSlipNum);
            //伝票備考
            writer.Write(temp.SlipNote);
            //伝票備考２
            writer.Write(temp.SlipNote2);
            //伝票備考３
            writer.Write(temp.SlipNote3);
            //返品理由コード
            writer.Write(temp.RetGoodsReasonDiv);
            //返品理由
            writer.Write(temp.RetGoodsReason);
            //明細行数
            writer.Write(temp.DetailRowCount);
            //ＥＤＩ送信日
            writer.Write((Int64)temp.EdiSendDate.Ticks);
            //ＥＤＩ取込日
            writer.Write((Int64)temp.EdiTakeInDate.Ticks);
            //ＵＯＥリマーク１
            writer.Write(temp.UoeRemark1);
            //ＵＯＥリマーク２
            writer.Write(temp.UoeRemark2);
            //伝票発行区分
            writer.Write(temp.SlipPrintDivCd);
            //伝票発行済区分
            writer.Write(temp.SlipPrintFinishCd);
            //売上伝票発行日
            writer.Write((Int64)temp.SalesSlipPrintDate.Ticks);
            //業種コード
            writer.Write(temp.BusinessTypeCode);
            //業種名称
            writer.Write(temp.BusinessTypeName);
            //納品区分
            writer.Write(temp.DeliveredGoodsDiv);
            //納品区分名称
            writer.Write(temp.DeliveredGoodsDivNm);
            //販売エリアコード
            writer.Write(temp.SalesAreaCode);
            //販売エリア名称
            writer.Write(temp.SalesAreaName);
            //伝票印刷設定用帳票ID
            writer.Write(temp.SlipPrtSetPaperId);
            //一式伝票区分
            writer.Write(temp.CompleteCd);
            //売上金額端数処理区分
            writer.Write(temp.SalesPriceFracProcCd);
            //在庫商品合計金額（税抜）
            writer.Write(temp.StockGoodsTtlTaxExc);
            //純正商品合計金額（税抜）
            writer.Write(temp.PureGoodsTtlTaxExc);
            //定価印刷区分
            writer.Write(temp.ListPricePrintDiv);
            //元号表示区分１
            writer.Write(temp.EraNameDispCd1);

        }

        /// <summary>
        ///  SalesHistoryWorkインスタンス取得
        /// </summary>
        /// <returns>SalesHistoryWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistoryWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private DCSalesHistoryWork GetSalesHistoryWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            DCSalesHistoryWork temp = new DCSalesHistoryWork();

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
            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //部門コード
            temp.SubSectionCode = reader.ReadInt32();
            //赤伝区分
            temp.DebitNoteDiv = reader.ReadInt32();
            //赤黒連結売上伝票番号
            temp.DebitNLnkSalesSlNum = reader.ReadString();
            //売上伝票区分
            temp.SalesSlipCd = reader.ReadInt32();
            //売上商品区分
            temp.SalesGoodsCd = reader.ReadInt32();
            //売掛区分
            temp.AccRecDivCd = reader.ReadInt32();
            //売上入力拠点コード
            temp.SalesInpSecCd = reader.ReadString();
            //請求計上拠点コード
            temp.DemandAddUpSecCd = reader.ReadString();
            //実績計上拠点コード
            temp.ResultsAddUpSecCd = reader.ReadString();
            //更新拠点コード
            temp.UpdateSecCd = reader.ReadString();
            //売上伝票更新区分
            temp.SalesSlipUpdateCd = reader.ReadInt32();
            //伝票検索日付
            temp.SearchSlipDate = new DateTime(reader.ReadInt64());
            //出荷日付
            temp.ShipmentDay = new DateTime(reader.ReadInt64());
            //売上日付
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //計上日付
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //来勘区分
            temp.DelayPaymentDiv = reader.ReadInt32();
            //入力担当者コード
            temp.InputAgenCd = reader.ReadString();
            //入力担当者名称
            temp.InputAgenNm = reader.ReadString();
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
            //総額表示方法区分
            temp.TotalAmountDispWayCd = reader.ReadInt32();
            //総額表示掛率適用区分
            temp.TtlAmntDispRateApy = reader.ReadInt32();
            //売上伝票合計（税込み）
            temp.SalesTotalTaxInc = reader.ReadInt64();
            //売上伝票合計（税抜き）
            temp.SalesTotalTaxExc = reader.ReadInt64();
            //売上部品合計（税込み）
            temp.SalesPrtTotalTaxInc = reader.ReadInt64();
            //売上部品合計（税抜き）
            temp.SalesPrtTotalTaxExc = reader.ReadInt64();
            //売上作業合計（税込み）
            temp.SalesWorkTotalTaxInc = reader.ReadInt64();
            //売上作業合計（税抜き）
            temp.SalesWorkTotalTaxExc = reader.ReadInt64();
            //売上小計（税込み）
            temp.SalesSubtotalTaxInc = reader.ReadInt64();
            //売上小計（税抜き）
            temp.SalesSubtotalTaxExc = reader.ReadInt64();
            //売上部品小計（税込み）
            temp.SalesPrtSubttlInc = reader.ReadInt64();
            //売上部品小計（税抜き）
            temp.SalesPrtSubttlExc = reader.ReadInt64();
            //売上作業小計（税込み）
            temp.SalesWorkSubttlInc = reader.ReadInt64();
            //売上作業小計（税抜き）
            temp.SalesWorkSubttlExc = reader.ReadInt64();
            //売上正価金額
            temp.SalesNetPrice = reader.ReadInt64();
            //売上小計（税）
            temp.SalesSubtotalTax = reader.ReadInt64();
            //売上外税対象額
            temp.ItdedSalesOutTax = reader.ReadInt64();
            //売上内税対象額
            temp.ItdedSalesInTax = reader.ReadInt64();
            //売上小計非課税対象額
            temp.SalSubttlSubToTaxFre = reader.ReadInt64();
            //売上金額消費税額（外税）
            temp.SalesOutTax = reader.ReadInt64();
            //売上金額消費税額（内税）
            temp.SalAmntConsTaxInclu = reader.ReadInt64();
            //売上値引金額計（税抜き）
            temp.SalesDisTtlTaxExc = reader.ReadInt64();
            //売上値引外税対象額合計
            temp.ItdedSalesDisOutTax = reader.ReadInt64();
            //売上値引内税対象額合計
            temp.ItdedSalesDisInTax = reader.ReadInt64();
            //部品値引対象額合計（税抜き）
            temp.ItdedPartsDisOutTax = reader.ReadInt64();
            //部品値引対象額合計（税込み）
            temp.ItdedPartsDisInTax = reader.ReadInt64();
            //作業値引対象額合計（税抜き）
            temp.ItdedWorkDisOutTax = reader.ReadInt64();
            //作業値引対象額合計（税込み）
            temp.ItdedWorkDisInTax = reader.ReadInt64();
            //売上値引非課税対象額合計
            temp.ItdedSalesDisTaxFre = reader.ReadInt64();
            //売上値引消費税額（外税）
            temp.SalesDisOutTax = reader.ReadInt64();
            //仕入値引消費税額（内税）
            temp.SalesDisTtlTaxInclu = reader.ReadInt64();
            //部品値引率
            temp.PartsDiscountRate = reader.ReadDouble();
            //工賃値引率
            temp.RavorDiscountRate = reader.ReadDouble();
            //原価金額計
            temp.TotalCost = reader.ReadInt64();
            //消費税転嫁方式
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //消費税税率
            temp.ConsTaxRate = reader.ReadDouble();
            //端数処理区分
            temp.FractionProcCd = reader.ReadInt32();
            //売掛消費税
            temp.AccRecConsTax = reader.ReadInt64();
            //自動入金区分
            temp.AutoDepositCd = reader.ReadInt32();
            //自動入金伝票番号
            temp.AutoDepositSlipNo = reader.ReadInt32();
            //入金引当合計額
            temp.DepositAllowanceTtl = reader.ReadInt64();
            //入金引当残高
            temp.DepositAlwcBlnce = reader.ReadInt64();
            //請求先コード
            temp.ClaimCode = reader.ReadInt32();
            //請求先略称
            temp.ClaimSnm = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先名称
            temp.CustomerName = reader.ReadString();
            //得意先名称2
            temp.CustomerName2 = reader.ReadString();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //敬称
            temp.HonorificTitle = reader.ReadString();
            //諸口コード
            temp.OutputNameCode = reader.ReadInt32();
            //諸口名称
            temp.OutputName = reader.ReadString();
            //得意先伝票番号
            temp.CustSlipNo = reader.ReadInt32();
            //伝票住所区分
            temp.SlipAddressDiv = reader.ReadInt32();
            //納品先コード
            temp.AddresseeCode = reader.ReadInt32();
            //納品先名称
            temp.AddresseeName = reader.ReadString();
            //納品先名称2
            temp.AddresseeName2 = reader.ReadString();
            //納品先郵便番号
            temp.AddresseePostNo = reader.ReadString();
            //納品先住所1(都道府県市区郡・町村・字)
            temp.AddresseeAddr1 = reader.ReadString();
            //納品先住所3(番地)
            temp.AddresseeAddr3 = reader.ReadString();
            //納品先住所4(アパート名称)
            temp.AddresseeAddr4 = reader.ReadString();
            //納品先電話番号
            temp.AddresseeTelNo = reader.ReadString();
            //納品先FAX番号
            temp.AddresseeFaxNo = reader.ReadString();
            //相手先伝票番号
            temp.PartySaleSlipNum = reader.ReadString();
            //伝票備考
            temp.SlipNote = reader.ReadString();
            //伝票備考２
            temp.SlipNote2 = reader.ReadString();
            //伝票備考３
            temp.SlipNote3 = reader.ReadString();
            //返品理由コード
            temp.RetGoodsReasonDiv = reader.ReadInt32();
            //返品理由
            temp.RetGoodsReason = reader.ReadString();
            //明細行数
            temp.DetailRowCount = reader.ReadInt32();
            //ＥＤＩ送信日
            temp.EdiSendDate = new DateTime(reader.ReadInt64());
            //ＥＤＩ取込日
            temp.EdiTakeInDate = new DateTime(reader.ReadInt64());
            //ＵＯＥリマーク１
            temp.UoeRemark1 = reader.ReadString();
            //ＵＯＥリマーク２
            temp.UoeRemark2 = reader.ReadString();
            //伝票発行区分
            temp.SlipPrintDivCd = reader.ReadInt32();
            //伝票発行済区分
            temp.SlipPrintFinishCd = reader.ReadInt32();
            //売上伝票発行日
            temp.SalesSlipPrintDate = new DateTime(reader.ReadInt64());
            //業種コード
            temp.BusinessTypeCode = reader.ReadInt32();
            //業種名称
            temp.BusinessTypeName = reader.ReadString();
            //納品区分
            temp.DeliveredGoodsDiv = reader.ReadInt32();
            //納品区分名称
            temp.DeliveredGoodsDivNm = reader.ReadString();
            //販売エリアコード
            temp.SalesAreaCode = reader.ReadInt32();
            //販売エリア名称
            temp.SalesAreaName = reader.ReadString();
            //伝票印刷設定用帳票ID
            temp.SlipPrtSetPaperId = reader.ReadString();
            //一式伝票区分
            temp.CompleteCd = reader.ReadInt32();
            //売上金額端数処理区分
            temp.SalesPriceFracProcCd = reader.ReadInt32();
            //在庫商品合計金額（税抜）
            temp.StockGoodsTtlTaxExc = reader.ReadInt64();
            //純正商品合計金額（税抜）
            temp.PureGoodsTtlTaxExc = reader.ReadInt64();
            //定価印刷区分
            temp.ListPricePrintDiv = reader.ReadInt32();
            //元号表示区分１
            temp.EraNameDispCd1 = reader.ReadInt32();


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
        /// <returns>SalesHistoryWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistoryWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DCSalesHistoryWork temp = GetSalesHistoryWork(reader, serInfo);
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
                    retValue = (DCSalesHistoryWork[])lst.ToArray(typeof(DCSalesHistoryWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
