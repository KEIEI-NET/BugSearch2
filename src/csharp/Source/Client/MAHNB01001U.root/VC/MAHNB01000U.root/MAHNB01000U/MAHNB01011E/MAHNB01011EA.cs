using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesSlip
    /// <summary>
    ///                      売上データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/02/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/9  杉村</br>
    /// <br>                 :   ○スペルミス修正</br>
    /// <br>                 :   売上値引非課税対象額合計</br>
    /// <br>                 :   売上正価金額</br>
    /// <br>                 :   売上金額消費税額（外税）</br>
    /// <br>Update Note      :   2008/9/25  對馬</br>
    /// <br>                 :   ○売上データレイアウトに対し、以下の項目追加</br>
    /// <br>                 :   入力モード、売上伝票区分(画面表示用)</br>
    /// <br>                 :   受注ステータス、得意先掛率グループコード</br>
    /// <br>                 :   請求先名称　請求先名称２</br>
    /// <br>                 :   与信管理区分、締日、次回勘定開始日</br>
    /// <br>                 :   粗利計算用売上金額</br>
    /// <br>                 :   拠点名称、部門名称、車両管理区分</br>
    /// <br>                 :   部品検索モード、車両検索モード</br>
    /// <br>                 :   売価率(検索見積用)、見積データ作成区分(検索見積用)</br>
    /// <br>                 :   得意先注番表示区分、得意先優先倉庫コード、取引中止日</br>
    /// <br>Update Note  : 2009/09/08 張凱</br>
    /// <br>               PM.NS-2-A・車輌管理</br>
    /// <br>               車輌管理機能の追加</br>
    /// <br>Update Note : 2009/12/17 對馬 大輔 保守依頼③対応</br>
    /// <br>             MANTIS[14756] 既存修正時、伝票タイプの明細数に従い明細数を制限する</br>
    /// <br>Update Note :  2009/12/23 張凱</br>
    /// <br>               PM.NS-5-A・PM.NS保守依頼④</br>
    /// <br>               PM.NS保守依頼④を追加</br>
    /// <br>Update Note :  2010/01/27 張凱</br>
    /// <br>               PM.NS保守依頼４次改良対応を追加</br>
    /// <br>               在庫情報更新falgを追加</br>
    /// <br>Update Note :  2010/02/26 對馬 大輔 </br>
    /// <br>               SCM対応</br>
    /// <br>Update Note :  2010/04/08 對馬 大輔 </br>
    /// <br>               SCM対応</br>
    /// <br>Update Note :  2011/07/18 朱宝軍 </br>
    /// <br>               回答区分の追加</br>
    /// <br>Update Note :  2011/12/15 tianjw</br>
    /// <br>               Redmine#27390 拠点管理/売上日のチェック</br>
    /// <br>Update Note :  2013/01/18 田建委</br>
    /// <br>管理番号    :  10806793-00 2013/03/13配信分</br>
    /// <br>            :  Redmine#33797 自動入金備考区分の追加</br>
    /// </remarks>
    public class SalesSlip
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

        /// <summary>赤黒連結売上伝票番号</summary>
        /// <remarks>赤黒の相手方売上伝票番号</remarks>
        private string _debitNLnkSalesSlNum = "";

        /// <summary>売上伝票区分</summary>
        /// <remarks>0:売上,1:返品</remarks>
        private Int32 _salesSlipCd;

        /// <summary>売上商品区分</summary>
        /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動)</remarks>
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
        /// <remarks>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        // ----- ADD 2011/12/15 ------------------->>>>>
        /// <summary>前回売上日付</summary>
        /// <remarks>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</remarks>
        private DateTime _preSalesDate;
        // ----- ADD 2011/12/15 -------------------<<<<<

        /// <summary>計上日付</summary>
        /// <remarks>請求日　(YYYYMMDD)</remarks>
        private DateTime _addUpADate;

        /// <summary>来勘区分</summary>
        /// <remarks>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</remarks>
        private Int32 _delayPaymentDiv;

        /// <summary>見積書番号</summary>
        private string _estimateFormNo = "";

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

        /// <summary>売上値引消費税額（内税）</summary>
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

        //----- ADD 2013/01/18 田建委 Redmine#33797 ----->>>>>
        /// <summary>自動入金備考区分</summary>
        /// <remarks>0:売上伝票番号 1:売上伝票備考 2:無し</remarks>
        private Int32 _autoDepositNoteDiv;
        //----- ADD 2013/01/18 田建委 Redmine#33797 -----<<<<<

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
        /// <remarks>得意先注文番号（仮伝番号）</remarks>
        private string _partySaleSlipNum = "";

        // --- ADD 2009/09/08 ---------->>>>>
        /// <summary>車輌備考</summary>
        private string _carSlipNote = "";

        /// <summary>走行距離</summary>
        private string _mileage = "";

        // --- ADD 2009/09/08 ----------<<<<<

        /// <summary>伝票備考</summary>
        private string _slipNote = "";

        /// <summary>伝票備考２</summary>
        private string _slipNote2 = "";

        /// <summary>伝票備考３</summary>
        private string _slipNote3 = "";

        // --- ADD 2009/12/23 ---------->>>>>

        /// <summary>伝票備考コード</summary>
        private Int32 _slipNoteCode;

        /// <summary>伝票備考２コード</summary>
        private Int32 _slipNote2Code;

        /// <summary>伝票備考３コード</summary>
        private Int32 _slipNote3Code;

        // --- ADD 2009/12/23 ----------<<<<<

        /// <summary>返品理由コード</summary>
        private Int32 _retGoodsReasonDiv;

        /// <summary>返品理由</summary>
        private string _retGoodsReason = "";

        /// <summary>レジ処理日</summary>
        /// <remarks>YYYYMMDD　（サーバー未接続時、売上伝票発行するための情報）</remarks>
        private DateTime _regiProcDate;

        /// <summary>レジ番号</summary>
        /// <remarks>　　　　　（サーバー未接続時、売上伝票発行するための情報）</remarks>
        private Int32 _cashRegisterNo;

        /// <summary>POSレシート番号</summary>
        /// <remarks>　　　　　（サーバー未接続時、売上伝票発行するための情報）</remarks>
        private Int32 _posReceiptNo;

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

        /// <summary>発注番号</summary>
        /// <remarks>売上形式＝"受注"の時にセット</remarks>
        private string _orderNumber = "";

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

        /// <summary>消込フラグ</summary>
        /// <remarks>0:残あり 9:残無し　（受注、出荷にて使用）</remarks>
        private Int32 _reconcileFlag;

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
        /// <remarks>通常　　0:西暦　1:和暦</remarks>
        private Int32 _eraNameDispCd1;

        /// <summary>見積消費税区分</summary>
        /// <remarks>0:非表示 1:外税（明細）2:総額表示 3:外税（伝票）</remarks>
        private Int32 _estimaTaxDivCd;

        /// <summary>見積書印刷区分</summary>
        private Int32 _estimateFormPrtCd;

        /// <summary>見積件名</summary>
        private string _estimateSubject = "";

        /// <summary>脚注１</summary>
        private string _footnotes1 = "";

        /// <summary>脚注２</summary>
        private string _footnotes2 = "";

        /// <summary>見積タイトル１</summary>
        private string _estimateTitle1 = "";

        /// <summary>見積タイトル２</summary>
        private string _estimateTitle2 = "";

        /// <summary>見積タイトル３</summary>
        private string _estimateTitle3 = "";

        /// <summary>見積タイトル４</summary>
        private string _estimateTitle4 = "";

        /// <summary>見積タイトル５</summary>
        private string _estimateTitle5 = "";

        /// <summary>見積備考１</summary>
        private string _estimateNote1 = "";

        /// <summary>見積備考２</summary>
        private string _estimateNote2 = "";

        /// <summary>見積備考３</summary>
        private string _estimateNote3 = "";

        /// <summary>見積備考４</summary>
        private string _estimateNote4 = "";

        /// <summary>見積備考５</summary>
        private string _estimateNote5 = "";

        /// <summary>見積有効期限</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _estimateValidityDate;

        /// <summary>品番印字区分</summary>
        /// <remarks>0:しない,1:する</remarks>
        private Int32 _partsNoPrtCd;

        /// <summary>オプション印字区分</summary>
        /// <remarks>0:しない,1:する</remarks>
        private Int32 _optionPringDivCd;

        /// <summary>掛率使用区分</summary>
        /// <remarks>0:売価＝定価 1:掛率指定,2:掛率設定</remarks>
        private Int32 _rateUseCode;

        /// <summary>入力モード</summary>
        /// <remarks>0:通常入力モード 1:返品入力モード 2:赤伝入力モード</remarks>
        private Int32 _inputMode;

        /// <summary>売上伝票区分(画面表示用)</summary>
        /// <remarks>10:掛売上 20:掛返品 30:現金売上 40:現金返品</remarks>
        private Int32 _salesSlipDisplay;

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _acptAnOdrStatusDisplay;

        /// <summary>得意先掛率グループコード</summary>
        private Int32 _custRateGrpCode;

        /// <summary>請求先名称</summary>
        /// <remarks>請求得意先名称</remarks>
        private string _claimName = "";

        /// <summary>請求先名称２</summary>
        /// <remarks>請求得意先名称２</remarks>
        private string _claimName2 = "";

        /// <summary>与信管理区分</summary>
        private Int32 _creditMngCode;

        /// <summary>締日</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>次回勘定開始日</summary>
        /// <remarks>01～31まで（省略可能）</remarks>
        private Int32 _nTimeCalcStDate;

        /// <summary>粗利計算用売上金額</summary>
        private Int64 _totalMoneyForGrossProfit;

        /// <summary>拠点名称</summary>
        private string _sectionName = "";

        /// <summary>部門名称</summary>
        private string _subSectionName = "";

        /// <summary>車輌管理区分</summary>
        /// <remarks>0:しない、1:登録(確認)、2:登録(自動) 3:登録無</remarks>
        private Int32 _carMngDivCd;

        /// <summary>部品検索モード</summary>
        /// <remarks>0:品番検索、1:BLコード検索</remarks>
        private Int32 _searchMode;

        /// <summary>車両検索モード</summary>
        /// <remarks>0:型式検索、1:モデルプレート検索</remarks>
        private Int32 _searchCarMode;

        /// <summary>売価率</summary>
        /// <remarks>※検索見積用</remarks>
        private Double _salesRate;

        /// <summary>見積データ作成区分</summary>
        /// <remarks>※検索見積用</remarks>
        private Int32 _estimateDtCreateDiv;

        /// <summary>得意先注番表示区分</summary>
        /// <remarks>0:しない　1:する（得意先マスタ 0:全体設定参照 1:しない　2:する）</remarks>
        private Int32 _custOrderNoDispDiv;

        /// <summary>得意先優先倉庫コード</summary>
        private string _custWarehouseCd = "";

        /// <summary>取引中止日</summary>
        private DateTime _transStopDate;

        //>>>2010/02/26
        /// <summary>オンライン種別区分</summary>
        /// <remarks>0:なし 10:SCM、20:TSP.NS、30:TSP.NSインライン、40:TSPメール</remarks>
        private Int32 _onlineKindDiv;

        /// <summary>問合せ元企業コード</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>問合せ元拠点コード</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>回答区分</summary>
        /// <remarks>0:通常 1:全回答</remarks>
        private Int32 _answerDiv;

        /// <summary>問合せ番号</summary>
        private Int64 _inquiryNumber;
        //<<<2010/02/26
        //>>>2010/04/08
        /// <summary>問合せ・発注種別</summary>
        private Int32 _inqOrdDivCd;
        //<<<2010/04/08

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>実績計上拠点名称</summary>
        private string _resultsAddUpSecNm = "";

        // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>明細行数</summary>
        private Int32 _detailRowCountForReadSlip;
        // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // ---------------------- ADD START 2011/07/18 朱宝軍 ----------------->>>>>
        /// <summary>自動回答区分(SCM)</summary>
        /// <remarks>0:通常(PCC連携なし)、1:手動回答、2:自動回答</remarks>
        private Int32 _autoAnswerDivSCM;

        /// public propaty name  :  AutoAnswerDivSCM
        /// <summary>自動回答区分(SCM)プロパティ</summary>
        /// <value>1:通常(PCC連携なし)、2:手動回答、3:自動回答</value>
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
        // ---------------------- ADD END   2011.02.09 朱宝軍 -----------------<<<<<
        // --- ADD 2010/01/27 -------------->>>>>
        /// <summary>在庫情報更新判断</summary>
        private bool _stockUpdateFlag　= false;
        // --- ADD 2010/01/27 --------------<<<<<

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

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>更新日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>更新日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>更新日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>更新日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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
        /// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動)</value>
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

        /// public propaty name  :  SearchSlipDateJpFormal
        /// <summary>伝票検索日付 和暦プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
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
        /// <value>YYYYMMDD　（更新年月日）</value>
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
        /// <value>YYYYMMDD　（更新年月日）</value>
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
        /// <value>YYYYMMDD　（更新年月日）</value>
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

        // ----- ADD 2011/12/15 ------------------->>>>>
        /// public propaty name  :  PreSalesDate
        /// <summary>前回売上日付プロパティ</summary>
        /// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PreSalesDate
        {
            get { return _preSalesDate; }
            set { _preSalesDate = value; }
        }
        // ----- ADD 2011/12/15 -------------------<<<<<

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

        /// public propaty name  :  EstimateFormNo
        /// <summary>見積書番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateFormNo
        {
            get { return _estimateFormNo; }
            set { _estimateFormNo = value; }
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
        /// <summary>売上値引消費税額（内税）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上値引消費税額（内税）プロパティ</br>
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

        //----- ADD 2013/01/18 田建委 Redmine#33797 ----->>>>>
        /// public propaty name  :  AutoDepositNoteDiv
        /// <summary>自動入金備考区分プロパティ</summary>
        /// <value>0:売上伝票番号 1:売上伝票備考 2:無し</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動入金備考区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoDepositNoteDiv
        {
            get { return _autoDepositNoteDiv; }
            set { _autoDepositNoteDiv = value; }
        }
        //----- ADD 2013/01/18 田建委 Redmine#33797 -----<<<<<

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

        // --- ADD 2009/09/08 ---------->>>>>

        /// public propaty name  :  CarSlipNote
        /// <summary>車輌備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarSlipNote
        {
            get { return _carSlipNote; }
            set { _carSlipNote = value; }
        }

        /// public propaty name  :  Mileage
        /// <summary>走行距離プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   走行距離プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Mileage
        {
            get { return _mileage; }
            set { _mileage = value; }
        }

        // --- ADD 2009/09/08 ----------<<<<<

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

        // --- ADD 2009/12/23 ---------->>>>>
        /// public propaty name  :  SlipNoteCode
        /// <summary>伝票備考コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipNoteCode
        {
            get { return _slipNoteCode; }
            set { _slipNoteCode = value; }
        }

        /// public propaty name  :  SlipNote2Code
        /// <summary>伝票備考２コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考２コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipNote2Code
        {
            get { return _slipNote2Code; }
            set { _slipNote2Code = value; }
        }

        /// public propaty name  :  SlipNote3Code
        /// <summary>伝票備考３コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考３コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipNote3Code
        {
            get { return _slipNote3Code; }
            set { _slipNote3Code = value; }
        }
        // --- ADD 2009/12/23 ----------<<<<<

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

        /// public propaty name  :  RegiProcDate
        /// <summary>レジ処理日プロパティ</summary>
        /// <value>YYYYMMDD　（サーバー未接続時、売上伝票発行するための情報）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   レジ処理日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime RegiProcDate
        {
            get { return _regiProcDate; }
            set { _regiProcDate = value; }
        }

        /// public propaty name  :  RegiProcDateJpFormal
        /// <summary>レジ処理日 和暦プロパティ</summary>
        /// <value>YYYYMMDD　（サーバー未接続時、売上伝票発行するための情報）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   レジ処理日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RegiProcDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _regiProcDate); }
            set { }
        }

        /// public propaty name  :  RegiProcDateJpInFormal
        /// <summary>レジ処理日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD　（サーバー未接続時、売上伝票発行するための情報）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   レジ処理日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RegiProcDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _regiProcDate); }
            set { }
        }

        /// public propaty name  :  RegiProcDateAdFormal
        /// <summary>レジ処理日 西暦プロパティ</summary>
        /// <value>YYYYMMDD　（サーバー未接続時、売上伝票発行するための情報）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   レジ処理日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RegiProcDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _regiProcDate); }
            set { }
        }

        /// public propaty name  :  RegiProcDateAdInFormal
        /// <summary>レジ処理日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD　（サーバー未接続時、売上伝票発行するための情報）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   レジ処理日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RegiProcDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _regiProcDate); }
            set { }
        }

        /// public propaty name  :  CashRegisterNo
        /// <summary>レジ番号プロパティ</summary>
        /// <value>　　　　　（サーバー未接続時、売上伝票発行するための情報）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   レジ番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// public propaty name  :  PosReceiptNo
        /// <summary>POSレシート番号プロパティ</summary>
        /// <value>　　　　　（サーバー未接続時、売上伝票発行するための情報）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   POSレシート番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PosReceiptNo
        {
            get { return _posReceiptNo; }
            set { _posReceiptNo = value; }
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

        /// public propaty name  :  EdiSendDateJpFormal
        /// <summary>ＥＤＩ送信日 和暦プロパティ</summary>
        /// <value>YYYYMMDD （ErectricDataInterface）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ送信日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdiSendDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _ediSendDate); }
            set { }
        }

        /// public propaty name  :  EdiSendDateJpInFormal
        /// <summary>ＥＤＩ送信日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD （ErectricDataInterface）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ送信日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdiSendDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _ediSendDate); }
            set { }
        }

        /// public propaty name  :  EdiSendDateAdFormal
        /// <summary>ＥＤＩ送信日 西暦プロパティ</summary>
        /// <value>YYYYMMDD （ErectricDataInterface）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ送信日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdiSendDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _ediSendDate); }
            set { }
        }

        /// public propaty name  :  EdiSendDateAdInFormal
        /// <summary>ＥＤＩ送信日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD （ErectricDataInterface）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ送信日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdiSendDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _ediSendDate); }
            set { }
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

        /// public propaty name  :  EdiTakeInDateJpFormal
        /// <summary>ＥＤＩ取込日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ取込日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdiTakeInDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _ediTakeInDate); }
            set { }
        }

        /// public propaty name  :  EdiTakeInDateJpInFormal
        /// <summary>ＥＤＩ取込日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ取込日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdiTakeInDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _ediTakeInDate); }
            set { }
        }

        /// public propaty name  :  EdiTakeInDateAdFormal
        /// <summary>ＥＤＩ取込日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ取込日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdiTakeInDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _ediTakeInDate); }
            set { }
        }

        /// public propaty name  :  EdiTakeInDateAdInFormal
        /// <summary>ＥＤＩ取込日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ取込日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdiTakeInDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _ediTakeInDate); }
            set { }
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

        /// public propaty name  :  SalesSlipPrintDateJpFormal
        /// <summary>売上伝票発行日 和暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipPrintDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _salesSlipPrintDate); }
            set { }
        }

        /// public propaty name  :  SalesSlipPrintDateJpInFormal
        /// <summary>売上伝票発行日 和暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipPrintDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _salesSlipPrintDate); }
            set { }
        }

        /// public propaty name  :  SalesSlipPrintDateAdFormal
        /// <summary>売上伝票発行日 西暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipPrintDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _salesSlipPrintDate); }
            set { }
        }

        /// public propaty name  :  SalesSlipPrintDateAdInFormal
        /// <summary>売上伝票発行日 西暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipPrintDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _salesSlipPrintDate); }
            set { }
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

        /// public propaty name  :  OrderNumber
        /// <summary>発注番号プロパティ</summary>
        /// <value>売上形式＝"受注"の時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; }
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

        /// public propaty name  :  ReconcileFlag
        /// <summary>消込フラグプロパティ</summary>
        /// <value>0:残あり 9:残無し　（受注、出荷にて使用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消込フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReconcileFlag
        {
            get { return _reconcileFlag; }
            set { _reconcileFlag = value; }
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

        /// public propaty name  :  EstimaTaxDivCd
        /// <summary>見積消費税区分プロパティ</summary>
        /// <value>0:非表示 1:外税（明細）2:総額表示 3:外税（伝票）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積消費税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstimaTaxDivCd
        {
            get { return _estimaTaxDivCd; }
            set { _estimaTaxDivCd = value; }
        }

        /// public propaty name  :  EstimateFormPrtCd
        /// <summary>見積書印刷区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書印刷区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstimateFormPrtCd
        {
            get { return _estimateFormPrtCd; }
            set { _estimateFormPrtCd = value; }
        }

        /// public propaty name  :  EstimateSubject
        /// <summary>見積件名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積件名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateSubject
        {
            get { return _estimateSubject; }
            set { _estimateSubject = value; }
        }

        /// public propaty name  :  Footnotes1
        /// <summary>脚注１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   脚注１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Footnotes1
        {
            get { return _footnotes1; }
            set { _footnotes1 = value; }
        }

        /// public propaty name  :  Footnotes2
        /// <summary>脚注２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   脚注２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Footnotes2
        {
            get { return _footnotes2; }
            set { _footnotes2 = value; }
        }

        /// public propaty name  :  EstimateTitle1
        /// <summary>見積タイトル１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積タイトル１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateTitle1
        {
            get { return _estimateTitle1; }
            set { _estimateTitle1 = value; }
        }

        /// public propaty name  :  EstimateTitle2
        /// <summary>見積タイトル２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積タイトル２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateTitle2
        {
            get { return _estimateTitle2; }
            set { _estimateTitle2 = value; }
        }

        /// public propaty name  :  EstimateTitle3
        /// <summary>見積タイトル３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積タイトル３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateTitle3
        {
            get { return _estimateTitle3; }
            set { _estimateTitle3 = value; }
        }

        /// public propaty name  :  EstimateTitle4
        /// <summary>見積タイトル４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積タイトル４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateTitle4
        {
            get { return _estimateTitle4; }
            set { _estimateTitle4 = value; }
        }

        /// public propaty name  :  EstimateTitle5
        /// <summary>見積タイトル５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積タイトル５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateTitle5
        {
            get { return _estimateTitle5; }
            set { _estimateTitle5 = value; }
        }

        /// public propaty name  :  EstimateNote1
        /// <summary>見積備考１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateNote1
        {
            get { return _estimateNote1; }
            set { _estimateNote1 = value; }
        }

        /// public propaty name  :  EstimateNote2
        /// <summary>見積備考２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateNote2
        {
            get { return _estimateNote2; }
            set { _estimateNote2 = value; }
        }

        /// public propaty name  :  EstimateNote3
        /// <summary>見積備考３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積備考３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateNote3
        {
            get { return _estimateNote3; }
            set { _estimateNote3 = value; }
        }

        /// public propaty name  :  EstimateNote4
        /// <summary>見積備考４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積備考４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateNote4
        {
            get { return _estimateNote4; }
            set { _estimateNote4 = value; }
        }

        /// public propaty name  :  EstimateNote5
        /// <summary>見積備考５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積備考５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateNote5
        {
            get { return _estimateNote5; }
            set { _estimateNote5 = value; }
        }

        /// public propaty name  :  EstimateValidityDate
        /// <summary>見積有効期限プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積有効期限プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime EstimateValidityDate
        {
            get { return _estimateValidityDate; }
            set { _estimateValidityDate = value; }
        }

        /// public propaty name  :  EstimateValidityDateJpFormal
        /// <summary>見積有効期限 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積有効期限 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateValidityDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _estimateValidityDate); }
            set { }
        }

        /// public propaty name  :  EstimateValidityDateJpInFormal
        /// <summary>見積有効期限 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積有効期限 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateValidityDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _estimateValidityDate); }
            set { }
        }

        /// public propaty name  :  EstimateValidityDateAdFormal
        /// <summary>見積有効期限 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積有効期限 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateValidityDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _estimateValidityDate); }
            set { }
        }

        /// public propaty name  :  EstimateValidityDateAdInFormal
        /// <summary>見積有効期限 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積有効期限 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateValidityDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _estimateValidityDate); }
            set { }
        }

        /// public propaty name  :  PartsNoPrtCd
        /// <summary>品番印字区分プロパティ</summary>
        /// <value>0:しない,1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsNoPrtCd
        {
            get { return _partsNoPrtCd; }
            set { _partsNoPrtCd = value; }
        }

        /// public propaty name  :  OptionPringDivCd
        /// <summary>オプション印字区分プロパティ</summary>
        /// <value>0:しない,1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オプション印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OptionPringDivCd
        {
            get { return _optionPringDivCd; }
            set { _optionPringDivCd = value; }
        }

        /// public propaty name  :  RateUseCode
        /// <summary>掛率使用区分プロパティ</summary>
        /// <value>0:売価＝定価 1:掛率指定,2:掛率設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率使用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateUseCode
        {
            get { return _rateUseCode; }
            set { _rateUseCode = value; }
        }

        /// public propaty name  :  InputMode
        /// <summary>入力モードプロパティ</summary>
        /// <value>0:通常入力モード 1:返品入力モード 2:赤伝入力モード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力モードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InputMode
        {
            get { return _inputMode; }
            set { _inputMode = value; }
        }

        /// public propaty name  :  SalesSlipDisplay
        /// <summary>売上伝票区分(画面表示用)プロパティ</summary>
        /// <value>10:掛売上 20:掛返品 30:現金売上 40:現金返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分(画面表示用)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipDisplay
        {
            get { return _salesSlipDisplay; }
            set { _salesSlipDisplay = value; }
        }

        /// public propaty name  :  AcptAnOdrStatusDisplay
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatusDisplay
        {
            get { return _acptAnOdrStatusDisplay; }
            set { _acptAnOdrStatusDisplay = value; }
        }

        /// public propaty name  :  CustRateGrpCode
        /// <summary>得意先掛率グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
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
        /// <summary>請求先名称２プロパティ</summary>
        /// <value>請求得意先名称２</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimName2
        {
            get { return _claimName2; }
            set { _claimName2 = value; }
        }

        /// public propaty name  :  CreditMngCode
        /// <summary>与信管理区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   与信管理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CreditMngCode
        {
            get { return _creditMngCode; }
            set { _creditMngCode = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>締日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  NTimeCalcStDate
        /// <summary>次回勘定開始日プロパティ</summary>
        /// <value>01～31まで（省略可能）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   次回勘定開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NTimeCalcStDate
        {
            get { return _nTimeCalcStDate; }
            set { _nTimeCalcStDate = value; }
        }

        /// public propaty name  :  TotalMoneyForGrossProfit
        /// <summary>粗利計算用売上金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利計算用売上金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalMoneyForGrossProfit
        {
            get { return _totalMoneyForGrossProfit; }
            set { _totalMoneyForGrossProfit = value; }
        }

        /// public propaty name  :  SectionName
        /// <summary>拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
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

        /// public propaty name  :  CarMngDivCd
        /// <summary>車輌管理区分プロパティ</summary>
        /// <value>0:しない、1:登録(確認)、2:登録(自動) 3:登録無</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌管理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarMngDivCd
        {
            get { return _carMngDivCd; }
            set { _carMngDivCd = value; }
        }

        /// public propaty name  :  SearchMode
        /// <summary>部品検索モードプロパティ</summary>
        /// <value>0:品番検索、1:BLコード検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品検索モードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchMode
        {
            get { return _searchMode; }
            set { _searchMode = value; }
        }

        /// public propaty name  :  SearchCarMode
        /// <summary>車両検索モードプロパティ</summary>
        /// <value>0:型式検索、1:モデルプレート検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両検索モードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchCarMode
        {
            get { return _searchCarMode; }
            set { _searchCarMode = value; }
        }

        /// public propaty name  :  SalesRate
        /// <summary>売価率プロパティ</summary>
        /// <value>※検索見積用</value>
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

        /// public propaty name  :  EstimateDtCreateDiv
        /// <summary>見積データ作成区分プロパティ</summary>
        /// <value>※検索見積用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積データ作成区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstimateDtCreateDiv
        {
            get { return _estimateDtCreateDiv; }
            set { _estimateDtCreateDiv = value; }
        }

        /// public propaty name  :  CustOrderNoDispDiv
        /// <summary>得意先注番表示区分プロパティ</summary>
        /// <value>0:しない　1:する（得意先マスタ 0:全体設定参照 1:しない　2:する）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先注番表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustOrderNoDispDiv
        {
            get { return _custOrderNoDispDiv; }
            set { _custOrderNoDispDiv = value; }
        }

        /// public propaty name  :  CustWarehouseCd
        /// <summary>得意先優先倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先優先倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustWarehouseCd
        {
            get { return _custWarehouseCd; }
            set { _custWarehouseCd = value; }
        }

        /// public propaty name  :  TransStopDate
        /// <summary>取引中止日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引中止日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime TransStopDate
        {
            get { return _transStopDate; }
            set { _transStopDate = value; }
        }

        /// public propaty name  :  TransStopDateJpFormal
        /// <summary>取引中止日 和暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引中止日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TransStopDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _transStopDate); }
            set { }
        }

        /// public propaty name  :  TransStopDateJpInFormal
        /// <summary>取引中止日 和暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引中止日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TransStopDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _transStopDate); }
            set { }
        }

        /// public propaty name  :  TransStopDateAdFormal
        /// <summary>取引中止日 西暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引中止日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TransStopDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _transStopDate); }
            set { }
        }

        /// public propaty name  :  TransStopDateAdInFormal
        /// <summary>取引中止日 西暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引中止日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TransStopDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _transStopDate); }
            set { }
        }

        //>>>2010/02/26
        /// public propaty name  :  OnlineKindDiv
        /// <summary>オンライン種別区分プロパティ</summary>
        /// <value>0:なし 10:SCM、20:TSP.NS、30:TSP.NSインライン、40:TSPメール</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オンライン種別区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OnlineKindDiv
        {
            get { return _onlineKindDiv; }
            set { _onlineKindDiv = value; }
        }

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>問合せ元企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>問合せ元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  AnswerDiv
        /// <summary>回答区分プロパティ</summary>
        /// <value>0:通常 1:全回答</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnswerDiv
        {
            get { return _answerDiv; }
            set { _answerDiv = value; }
        }

        /// public propaty name  :  InquiryNumber
        /// <summary>問合せ番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }
        //<<<2010/02/26

        //>>>2010/04/08
        /// public propaty name  :  InquiryNumber
        /// <summary>問合せ・発注種別プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ・発注種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InqOrdDivCd
        {
            get { return _inqOrdDivCd; }
            set { _inqOrdDivCd = value; }
        }
        //<<<2010/04/08

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

        /// public propaty name  :  UpdEmployeeName
        /// <summary>更新従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
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

        // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  DetailRowCountForReadSlip
        /// <summary>明細行数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細行数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DetailRowCountForReadSlip
        {
            get { return _detailRowCountForReadSlip; }
            set { _detailRowCountForReadSlip = value; }
        }
        // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // --- ADD 2010/01/27 -------------->>>>>
        /// public propaty name  :  StockUpdateFlag
        /// <summary>在庫情報更新判断プロパティ(false: 更新 true:更新しない)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫情報更新判断プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool StockUpdateFlag
        {
            get { return _stockUpdateFlag; }
            set { _stockUpdateFlag = value; }
        }
        // --- ADD 2010/01/27 --------------<<<<<

        /// <summary>
        /// 売上データコンストラクタ
        /// </summary>
        /// <returns>SalesSlipクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesSlip()
        {
        }

        /// <summary>
        /// 売上データコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="acptAnOdrStatus">受注ステータス(10:見積,20:受注,30:売上,40:出荷)</param>
        /// <param name="salesSlipNum">売上伝票番号(見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="subSectionCode">部門コード</param>
        /// <param name="debitNoteDiv">赤伝区分(0:黒伝,1:赤伝,2:元黒)</param>
        /// <param name="debitNLnkSalesSlNum">赤黒連結売上伝票番号(赤黒の相手方売上伝票番号)</param>
        /// <param name="salesSlipCd">売上伝票区分(0:売上,1:返品)</param>
        /// <param name="salesGoodsCd">売上商品区分(0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動))</param>
        /// <param name="accRecDivCd">売掛区分(0:売掛なし,1:売掛)</param>
        /// <param name="salesInpSecCd">売上入力拠点コード(文字型 売上を入力した拠点コード)</param>
        /// <param name="demandAddUpSecCd">請求計上拠点コード(文字型)</param>
        /// <param name="resultsAddUpSecCd">実績計上拠点コード(実績計上を行う企業内の拠点コード)</param>
        /// <param name="updateSecCd">更新拠点コード(文字型 データの登録更新拠点)</param>
        /// <param name="salesSlipUpdateCd">売上伝票更新区分(0:未更新,1:更新あり)</param>
        /// <param name="searchSlipDate">伝票検索日付(YYYYMMDD　（更新年月日）)</param>
        /// <param name="shipmentDay">出荷日付(YYYYMMDD)</param>
        /// <param name="salesDate">売上日付(見積日、受注日、売上日を兼ねる。(YYYYMMDD))</param>
        /// <param name="preSalesDate">前回売上日付(見積日、受注日、売上日を兼ねる。(YYYYMMDD))</param> // ADD 2011/12/15
        /// <param name="addUpADate">計上日付(請求日　(YYYYMMDD))</param>
        /// <param name="delayPaymentDiv">来勘区分(0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後)</param>
        /// <param name="estimateFormNo">見積書番号</param>
        /// <param name="estimateDivide">見積区分(1:通常見積　2:単価見積　3:検索見積)</param>
        /// <param name="inputAgenCd">入力担当者コード(ログイン担当者（ＵＳＢ）)</param>
        /// <param name="inputAgenNm">入力担当者名称</param>
        /// <param name="salesInputCode">売上入力者コード(入力担当者（発行者）)</param>
        /// <param name="salesInputName">売上入力者名称</param>
        /// <param name="frontEmployeeCd">受付従業員コード(受付担当者（受注者）)</param>
        /// <param name="frontEmployeeNm">受付従業員名称</param>
        /// <param name="salesEmployeeCd">販売従業員コード(計上担当者（担当者）)</param>
        /// <param name="salesEmployeeNm">販売従業員名称</param>
        /// <param name="totalAmountDispWayCd">総額表示方法区分(0:総額表示しない（税抜き）,1:総額表示する（税込み）)</param>
        /// <param name="ttlAmntDispRateApy">総額表示掛率適用区分(0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率)</param>
        /// <param name="salesTotalTaxInc">売上伝票合計（税込み）(売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額)</param>
        /// <param name="salesTotalTaxExc">売上伝票合計（税抜き）(売上正価金額＋売上値引金額計（税抜き）)</param>
        /// <param name="salesPrtTotalTaxInc">売上部品合計（税込み）(売上部品小計（税込み）＋部品値引対象額合計（税込み）)</param>
        /// <param name="salesPrtTotalTaxExc">売上部品合計（税抜き）(売上部品小計（税抜き）＋部品値引対象額合計（税抜き）)</param>
        /// <param name="salesWorkTotalTaxInc">売上作業合計（税込み）(売上作業小計（税込み）＋作業値引対象額合計（税込み）)</param>
        /// <param name="salesWorkTotalTaxExc">売上作業合計（税抜き）(売上作業小計（税抜き）＋作業値引対象額合計（税抜き）)</param>
        /// <param name="salesSubtotalTaxInc">売上小計（税込み）(値引後の明細金額の合計（非課税含まず）)</param>
        /// <param name="salesSubtotalTaxExc">売上小計（税抜き）(値引後の明細金額の合計（非課税含まず）)</param>
        /// <param name="salesPrtSubttlInc">売上部品小計（税込み）(部品明細金額の税込合計)</param>
        /// <param name="salesPrtSubttlExc">売上部品小計（税抜き）(部品明細金額の税抜合計)</param>
        /// <param name="salesWorkSubttlInc">売上作業小計（税込み）(作業明細金額の税込合計)</param>
        /// <param name="salesWorkSubttlExc">売上作業小計（税抜き）(作業明細金額の税抜合計)</param>
        /// <param name="salesNetPrice">売上正価金額(値引前の税抜売上金額（外税分、内税分、非課税分の合計）)</param>
        /// <param name="salesSubtotalTax">売上小計（税）(外税対象金額の集計（税抜、値引含まず）)</param>
        /// <param name="itdedSalesOutTax">売上外税対象額(内税対象金額の集計（税抜、値引含まず） )</param>
        /// <param name="itdedSalesInTax">売上内税対象額(非課税対象金額の集計（値引含まず）)</param>
        /// <param name="salSubttlSubToTaxFre">売上小計非課税対象額(売上金額消費税額（外税）+売上金額消費税額（内税）値引き含まず)</param>
        /// <param name="salesOutTax">売上金額消費税額（外税）(値引前の外税商品の消費税)</param>
        /// <param name="salAmntConsTaxInclu">売上金額消費税額（内税）(値引前の内税商品の消費税)</param>
        /// <param name="salesDisTtlTaxExc">売上値引金額計（税抜き）</param>
        /// <param name="itdedSalesDisOutTax">売上値引外税対象額合計(外税商品値引の外税対象額（税抜）)</param>
        /// <param name="itdedSalesDisInTax">売上値引内税対象額合計(内税商品値引の内税対象額（税抜）)</param>
        /// <param name="itdedPartsDisOutTax">部品値引対象額合計（税抜き）(部品値引額（税抜き）)</param>
        /// <param name="itdedPartsDisInTax">部品値引対象額合計（税込み）(部品値引額（税込み）)</param>
        /// <param name="itdedWorkDisOutTax">作業値引対象額合計（税抜き）(作業値引額（税抜き）)</param>
        /// <param name="itdedWorkDisInTax">作業値引対象額合計（税込み）(作業値引額（税込み）)</param>
        /// <param name="itdedSalesDisTaxFre">売上値引非課税対象額合計(非課税商品値引の非課税対象額)</param>
        /// <param name="salesDisOutTax">売上値引消費税額（外税）(外税商品値引の消費税額)</param>
        /// <param name="salesDisTtlTaxInclu">売上値引消費税額（内税）</param>
        /// <param name="partsDiscountRate">部品値引率(小計に対しての部品値引率)</param>
        /// <param name="ravorDiscountRate">工賃値引率(小計に対しての工賃値引率)</param>
        /// <param name="totalCost">原価金額計</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式(0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税)</param>
        /// <param name="consTaxRate">消費税税率(変更2007/8/22(型,桁) 塩原)</param>
        /// <param name="fractionProcCd">端数処理区分(1:切捨て,2:四捨五入,3:切上げ　（消費税）)</param>
        /// <param name="accRecConsTax">売掛消費税</param>
        /// <param name="autoDepositCd">自動入金区分(0:通常入金,1:自動入金)</param>
        /// <param name="autoDepositNoteDiv">自動入金備考区分(0:売上伝票番号 1:売上伝票備考 2:無し)</param>  // ADD 2013/01/18 田建委 Redmine#33797
        /// <param name="autoDepositSlipNo">自動入金伝票番号(自動入金時の入金伝票番号)</param>
        /// <param name="depositAllowanceTtl">入金引当合計額(預り金引当合計額を含む)</param>
        /// <param name="depositAlwcBlnce">入金引当残高</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="claimSnm">請求先略称</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerName">得意先名称</param>
        /// <param name="customerName2">得意先名称2</param>
        /// <param name="customerSnm">得意先略称</param>
        /// <param name="honorificTitle">敬称</param>
        /// <param name="outputNameCode">諸口コード(0:正式得意先,1:諸口得意先)</param>
        /// <param name="outputName">諸口名称</param>
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
        /// <param name="carSlipNote">車輌備考</param>
        /// <param name="mileage">走行距離</param>
        /// <param name="slipNote">伝票備考</param>
        /// <param name="slipNote2">伝票備考２</param>
        /// <param name="slipNote3">伝票備考３</param>
        /// <param name="slipNoteCode">伝票備考コード</param>
        /// <param name="slipNote2Code">伝票備考２コード</param>
        /// <param name="slipNote3Code">伝票備考３コード</param>
        /// <param name="retGoodsReasonDiv">返品理由コード</param>
        /// <param name="retGoodsReason">返品理由</param>
        /// <param name="regiProcDate">レジ処理日(YYYYMMDD　（サーバー未接続時、売上伝票発行するための情報）)</param>
        /// <param name="cashRegisterNo">レジ番号(　　　　　（サーバー未接続時、売上伝票発行するための情報）)</param>
        /// <param name="posReceiptNo">POSレシート番号(　　　　　（サーバー未接続時、売上伝票発行するための情報）)</param>
        /// <param name="detailRowCount">明細行数(伝票内の明細の行数（諸費用明細は除く）)</param>
        /// <param name="ediSendDate">ＥＤＩ送信日(YYYYMMDD （ErectricDataInterface）)</param>
        /// <param name="ediTakeInDate">ＥＤＩ取込日(YYYYMMDD)</param>
        /// <param name="uoeRemark1">ＵＯＥリマーク１(UserOrderEntory)</param>
        /// <param name="uoeRemark2">ＵＯＥリマーク２</param>
        /// <param name="slipPrintDivCd">伝票発行区分(0:しない 1:する)</param>
        /// <param name="slipPrintFinishCd">伝票発行済区分(0:未発行 1:発行済)</param>
        /// <param name="salesSlipPrintDate">売上伝票発行日</param>
        /// <param name="businessTypeCode">業種コード</param>
        /// <param name="businessTypeName">業種名称</param>
        /// <param name="orderNumber">発注番号(売上形式＝"受注"の時にセット)</param>
        /// <param name="deliveredGoodsDiv">納品区分(例) 1:配達,2:店頭渡し,3:直送,…)</param>
        /// <param name="deliveredGoodsDivNm">納品区分名称</param>
        /// <param name="salesAreaCode">販売エリアコード(地区コード)</param>
        /// <param name="salesAreaName">販売エリア名称</param>
        /// <param name="reconcileFlag">消込フラグ(0:残あり 9:残無し　（受注、出荷にて使用）)</param>
        /// <param name="slipPrtSetPaperId">伝票印刷設定用帳票ID(売上形式とセットで伝票タイプ管理マスタを参照)</param>
        /// <param name="completeCd">一式伝票区分(0:通常伝票,1:一式伝票)</param>
        /// <param name="salesPriceFracProcCd">売上金額端数処理区分(1:切捨て,2:四捨五入,3:切上げ　（売上明細データの金額用）)</param>
        /// <param name="stockGoodsTtlTaxExc">在庫商品合計金額（税抜）(在庫取寄区分が０の明細金額の集計)</param>
        /// <param name="pureGoodsTtlTaxExc">純正商品合計金額（税抜）(商品属性が０の明細金額の集計)</param>
        /// <param name="listPricePrintDiv">定価印刷区分</param>
        /// <param name="eraNameDispCd1">元号表示区分１(通常　　0:西暦　1:和暦)</param>
        /// <param name="estimaTaxDivCd">見積消費税区分(0:非表示 1:外税（明細）2:総額表示 3:外税（伝票）)</param>
        /// <param name="estimateFormPrtCd">見積書印刷区分</param>
        /// <param name="estimateSubject">見積件名</param>
        /// <param name="footnotes1">脚注１</param>
        /// <param name="footnotes2">脚注２</param>
        /// <param name="estimateTitle1">見積タイトル１</param>
        /// <param name="estimateTitle2">見積タイトル２</param>
        /// <param name="estimateTitle3">見積タイトル３</param>
        /// <param name="estimateTitle4">見積タイトル４</param>
        /// <param name="estimateTitle5">見積タイトル５</param>
        /// <param name="estimateNote1">見積備考１</param>
        /// <param name="estimateNote2">見積備考２</param>
        /// <param name="estimateNote3">見積備考３</param>
        /// <param name="estimateNote4">見積備考４</param>
        /// <param name="estimateNote5">見積備考５</param>
        /// <param name="estimateValidityDate">見積有効期限(YYYYMMDD)</param>
        /// <param name="partsNoPrtCd">品番印字区分(0:しない,1:する)</param>
        /// <param name="optionPringDivCd">オプション印字区分(0:しない,1:する)</param>
        /// <param name="rateUseCode">掛率使用区分(0:売価＝定価 1:掛率指定,2:掛率設定)</param>
        /// <param name="inputMode">入力モード(0:通常入力モード 1:返品入力モード 2:赤伝入力モード)</param>
        /// <param name="salesSlipDisplay">売上伝票区分(画面表示用)(10:掛売上 20:掛返品 30:現金売上 40:現金返品)</param>
        /// <param name="acptAnOdrStatusDisplay">受注ステータス(10:見積,20:受注,30:売上,40:出荷)</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <param name="claimName">請求先名称(請求得意先名称)</param>
        /// <param name="claimName2">請求先名称２(請求得意先名称２)</param>
        /// <param name="creditMngCode">与信管理区分</param>
        /// <param name="totalDay">締日(DD)</param>
        /// <param name="nTimeCalcStDate">次回勘定開始日(01～31まで（省略可能）)</param>
        /// <param name="totalMoneyForGrossProfit">粗利計算用売上金額</param>
        /// <param name="sectionName">拠点名称</param>
        /// <param name="subSectionName">部門名称</param>
        /// <param name="carMngDivCd">車輌管理区分(0:しない、1:登録(確認)、2:登録(自動) 3:登録無)</param>
        /// <param name="searchMode">部品検索モード(0:品番検索、1:BLコード検索)</param>
        /// <param name="searchCarMode">車両検索モード(0:型式検索、1:モデルプレート検索)</param>
        /// <param name="salesRate">売価率(※検索見積用)</param>
        /// <param name="estimateDtCreateDiv">見積データ作成区分(※検索見積用)</param>
        /// <param name="custOrderNoDispDiv">得意先注番表示区分(0:しない　1:する（得意先マスタ 0:全体設定参照 1:しない　2:する）)</param>
        /// <param name="custWarehouseCd">得意先優先倉庫コード</param>
        /// <param name="transStopDate">取引中止日</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="resultsAddUpSecNm">実績計上拠点名称</param>
        /// <param name="resultsAddUpSecNm">明細行数</param> // ADD 2009/12/17
        /// <param name="stockUpdateFlag">在庫情報更新判断</param> // ADD 2010/01/27
        /// <returns>SalesSlipクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //>>>2010/04/08
        ////>>>2010/02/26
        ////// 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //////public SalesSlip(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, Int32 salesSlipUpdateCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 delayPaymentDiv, string estimateFormNo, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesPrtTotalTaxInc, Int64 salesPrtTotalTaxExc, Int64 salesWorkTotalTaxInc, Int64 salesWorkTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesPrtSubttlInc, Int64 salesPrtSubttlExc, Int64 salesWorkSubttlInc, Int64 salesWorkSubttlExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedPartsDisOutTax, Int64 itdedPartsDisInTax, Int64 itdedWorkDisOutTax, Int64 itdedWorkDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Double partsDiscountRate, Double ravorDiscountRate, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, Int32 outputNameCode, string outputName, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string carSlipNote, string mileage, string slipNote, string slipNote2, string slipNote3, Int32 retGoodsReasonDiv, string retGoodsReason, DateTime regiProcDate, Int32 cashRegisterNo, Int32 posReceiptNo, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, string orderNumber, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, Int32 reconcileFlag, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 estimaTaxDivCd, Int32 estimateFormPrtCd, string estimateSubject, string footnotes1, string footnotes2, string estimateTitle1, string estimateTitle2, string estimateTitle3, string estimateTitle4, string estimateTitle5, string estimateNote1, string estimateNote2, string estimateNote3, string estimateNote4, string estimateNote5, DateTime estimateValidityDate, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 rateUseCode, Int32 inputMode, Int32 salesSlipDisplay, Int32 acptAnOdrStatusDisplay, Int32 custRateGrpCode, string claimName, string claimName2, Int32 creditMngCode, Int32 totalDay, Int32 nTimeCalcStDate, Int64 totalMoneyForGrossProfit, string sectionName, string subSectionName, Int32 carMngDivCd, Int32 searchMode, Int32 searchCarMode, Double salesRate, Int32 estimateDtCreateDiv, Int32 custOrderNoDispDiv, string custWarehouseCd, DateTime transStopDate, string enterpriseName, string updEmployeeName, string resultsAddUpSecNm)
        ////public SalesSlip(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, Int32 salesSlipUpdateCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 delayPaymentDiv, string estimateFormNo, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesPrtTotalTaxInc, Int64 salesPrtTotalTaxExc, Int64 salesWorkTotalTaxInc, Int64 salesWorkTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesPrtSubttlInc, Int64 salesPrtSubttlExc, Int64 salesWorkSubttlInc, Int64 salesWorkSubttlExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedPartsDisOutTax, Int64 itdedPartsDisInTax, Int64 itdedWorkDisOutTax, Int64 itdedWorkDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Double partsDiscountRate, Double ravorDiscountRate, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, Int32 outputNameCode, string outputName, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string carSlipNote, string mileage, string slipNote, string slipNote2, string slipNote3, Int32 slipNoteCode, Int32 slipNote2Code, Int32 slipNote3Code, Int32 retGoodsReasonDiv, string retGoodsReason, DateTime regiProcDate, Int32 cashRegisterNo, Int32 posReceiptNo, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, string orderNumber, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, Int32 reconcileFlag, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 estimaTaxDivCd, Int32 estimateFormPrtCd, string estimateSubject, string footnotes1, string footnotes2, string estimateTitle1, string estimateTitle2, string estimateTitle3, string estimateTitle4, string estimateTitle5, string estimateNote1, string estimateNote2, string estimateNote3, string estimateNote4, string estimateNote5, DateTime estimateValidityDate, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 rateUseCode, Int32 inputMode, Int32 salesSlipDisplay, Int32 acptAnOdrStatusDisplay, Int32 custRateGrpCode, string claimName, string claimName2, Int32 creditMngCode, Int32 totalDay, Int32 nTimeCalcStDate, Int64 totalMoneyForGrossProfit, string sectionName, string subSectionName, Int32 carMngDivCd, Int32 searchMode, Int32 searchCarMode, Double salesRate, Int32 estimateDtCreateDiv, Int32 custOrderNoDispDiv, string custWarehouseCd, DateTime transStopDate, string enterpriseName, string updEmployeeName, string resultsAddUpSecNm, Int32 detailRowCountForReadSlip)
        ////// 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //public SalesSlip(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, Int32 salesSlipUpdateCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 delayPaymentDiv, string estimateFormNo, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesPrtTotalTaxInc, Int64 salesPrtTotalTaxExc, Int64 salesWorkTotalTaxInc, Int64 salesWorkTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesPrtSubttlInc, Int64 salesPrtSubttlExc, Int64 salesWorkSubttlInc, Int64 salesWorkSubttlExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedPartsDisOutTax, Int64 itdedPartsDisInTax, Int64 itdedWorkDisOutTax, Int64 itdedWorkDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Double partsDiscountRate, Double ravorDiscountRate, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, Int32 outputNameCode, string outputName, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string carSlipNote, string mileage, string slipNote, string slipNote2, string slipNote3, Int32 slipNoteCode, Int32 slipNote2Code, Int32 slipNote3Code, Int32 retGoodsReasonDiv, string retGoodsReason, DateTime regiProcDate, Int32 cashRegisterNo, Int32 posReceiptNo, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, string orderNumber, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, Int32 reconcileFlag, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 estimaTaxDivCd, Int32 estimateFormPrtCd, string estimateSubject, string footnotes1, string footnotes2, string estimateTitle1, string estimateTitle2, string estimateTitle3, string estimateTitle4, string estimateTitle5, string estimateNote1, string estimateNote2, string estimateNote3, string estimateNote4, string estimateNote5, DateTime estimateValidityDate, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 rateUseCode, Int32 inputMode, Int32 salesSlipDisplay, Int32 acptAnOdrStatusDisplay, Int32 custRateGrpCode, string claimName, string claimName2, Int32 creditMngCode, Int32 totalDay, Int32 nTimeCalcStDate, Int64 totalMoneyForGrossProfit, string sectionName, string subSectionName, Int32 carMngDivCd, Int32 searchMode, Int32 searchCarMode, Double salesRate, Int32 estimateDtCreateDiv, Int32 custOrderNoDispDiv, string custWarehouseCd, DateTime transStopDate, Int32 onlineKindDiv, string inqOriginalEpCd, string inqOriginalSecCd, Int32 answerDiv, Int64 inquiryNumber, string enterpriseName, string updEmployeeName, string resultsAddUpSecNm, Int32 detailRowCountForReadSlip)
        ////<<<2010/02/26
        // --- ADD 2010/01/27 -------------->>>>>
        //public SalesSlip(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, Int32 salesSlipUpdateCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 delayPaymentDiv, string estimateFormNo, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesPrtTotalTaxInc, Int64 salesPrtTotalTaxExc, Int64 salesWorkTotalTaxInc, Int64 salesWorkTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesPrtSubttlInc, Int64 salesPrtSubttlExc, Int64 salesWorkSubttlInc, Int64 salesWorkSubttlExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedPartsDisOutTax, Int64 itdedPartsDisInTax, Int64 itdedWorkDisOutTax, Int64 itdedWorkDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Double partsDiscountRate, Double ravorDiscountRate, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, Int32 outputNameCode, string outputName, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string carSlipNote, string mileage, string slipNote, string slipNote2, string slipNote3, Int32 slipNoteCode, Int32 slipNote2Code, Int32 slipNote3Code, Int32 retGoodsReasonDiv, string retGoodsReason, DateTime regiProcDate, Int32 cashRegisterNo, Int32 posReceiptNo, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, string orderNumber, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, Int32 reconcileFlag, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 estimaTaxDivCd, Int32 estimateFormPrtCd, string estimateSubject, string footnotes1, string footnotes2, string estimateTitle1, string estimateTitle2, string estimateTitle3, string estimateTitle4, string estimateTitle5, string estimateNote1, string estimateNote2, string estimateNote3, string estimateNote4, string estimateNote5, DateTime estimateValidityDate, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 rateUseCode, Int32 inputMode, Int32 salesSlipDisplay, Int32 acptAnOdrStatusDisplay, Int32 custRateGrpCode, string claimName, string claimName2, Int32 creditMngCode, Int32 totalDay, Int32 nTimeCalcStDate, Int64 totalMoneyForGrossProfit, string sectionName, string subSectionName, Int32 carMngDivCd, Int32 searchMode, Int32 searchCarMode, Double salesRate, Int32 estimateDtCreateDiv, Int32 custOrderNoDispDiv, string custWarehouseCd, DateTime transStopDate, Int32 onlineKindDiv, string inqOriginalEpCd, string inqOriginalSecCd, Int32 answerDiv, Int64 inquiryNumber, Int32 inqOrdDivCd, string enterpriseName, string updEmployeeName, string resultsAddUpSecNm, Int32 detailRowCountForReadSlip)
        //public SalesSlip(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, Int32 salesSlipUpdateCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 delayPaymentDiv, string estimateFormNo, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesPrtTotalTaxInc, Int64 salesPrtTotalTaxExc, Int64 salesWorkTotalTaxInc, Int64 salesWorkTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesPrtSubttlInc, Int64 salesPrtSubttlExc, Int64 salesWorkSubttlInc, Int64 salesWorkSubttlExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedPartsDisOutTax, Int64 itdedPartsDisInTax, Int64 itdedWorkDisOutTax, Int64 itdedWorkDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Double partsDiscountRate, Double ravorDiscountRate, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, Int32 outputNameCode, string outputName, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string carSlipNote, string mileage, string slipNote, string slipNote2, string slipNote3, Int32 slipNoteCode, Int32 slipNote2Code, Int32 slipNote3Code, Int32 retGoodsReasonDiv, string retGoodsReason, DateTime regiProcDate, Int32 cashRegisterNo, Int32 posReceiptNo, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, string orderNumber, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, Int32 reconcileFlag, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 estimaTaxDivCd, Int32 estimateFormPrtCd, string estimateSubject, string footnotes1, string footnotes2, string estimateTitle1, string estimateTitle2, string estimateTitle3, string estimateTitle4, string estimateTitle5, string estimateNote1, string estimateNote2, string estimateNote3, string estimateNote4, string estimateNote5, DateTime estimateValidityDate, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 rateUseCode, Int32 inputMode, Int32 salesSlipDisplay, Int32 acptAnOdrStatusDisplay, Int32 custRateGrpCode, string claimName, string claimName2, Int32 creditMngCode, Int32 totalDay, Int32 nTimeCalcStDate, Int64 totalMoneyForGrossProfit, string sectionName, string subSectionName, Int32 carMngDivCd, Int32 searchMode, Int32 searchCarMode, Double salesRate, Int32 estimateDtCreateDiv, Int32 custOrderNoDispDiv, string custWarehouseCd, DateTime transStopDate, Int32 onlineKindDiv, string inqOriginalEpCd, string inqOriginalSecCd, Int32 answerDiv, Int64 inquiryNumber, Int32 inqOrdDivCd, string enterpriseName, string updEmployeeName, string resultsAddUpSecNm, Int32 detailRowCountForReadSlip, bool stockUpdateFlag)// del 2011/07/18 朱宝軍
        // --- ADD 2010/01/27 --------------<<<<<
        //<<<2010/04/08
        //public SalesSlip(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, Int32 salesSlipUpdateCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 delayPaymentDiv, string estimateFormNo, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesPrtTotalTaxInc, Int64 salesPrtTotalTaxExc, Int64 salesWorkTotalTaxInc, Int64 salesWorkTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesPrtSubttlInc, Int64 salesPrtSubttlExc, Int64 salesWorkSubttlInc, Int64 salesWorkSubttlExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedPartsDisOutTax, Int64 itdedPartsDisInTax, Int64 itdedWorkDisOutTax, Int64 itdedWorkDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Double partsDiscountRate, Double ravorDiscountRate, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, Int32 outputNameCode, string outputName, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string carSlipNote, string mileage, string slipNote, string slipNote2, string slipNote3, Int32 slipNoteCode, Int32 slipNote2Code, Int32 slipNote3Code, Int32 retGoodsReasonDiv, string retGoodsReason, DateTime regiProcDate, Int32 cashRegisterNo, Int32 posReceiptNo, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, string orderNumber, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, Int32 reconcileFlag, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 estimaTaxDivCd, Int32 estimateFormPrtCd, string estimateSubject, string footnotes1, string footnotes2, string estimateTitle1, string estimateTitle2, string estimateTitle3, string estimateTitle4, string estimateTitle5, string estimateNote1, string estimateNote2, string estimateNote3, string estimateNote4, string estimateNote5, DateTime estimateValidityDate, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 rateUseCode, Int32 inputMode, Int32 salesSlipDisplay, Int32 acptAnOdrStatusDisplay, Int32 custRateGrpCode, string claimName, string claimName2, Int32 creditMngCode, Int32 totalDay, Int32 nTimeCalcStDate, Int64 totalMoneyForGrossProfit, string sectionName, string subSectionName, Int32 carMngDivCd, Int32 searchMode, Int32 searchCarMode, Double salesRate, Int32 estimateDtCreateDiv, Int32 custOrderNoDispDiv, string custWarehouseCd, DateTime transStopDate, Int32 onlineKindDiv, string inqOriginalEpCd, string inqOriginalSecCd, Int32 answerDiv, Int64 inquiryNumber, Int32 inqOrdDivCd, string enterpriseName, string updEmployeeName, string resultsAddUpSecNm, Int32 detailRowCountForReadSlip, bool stockUpdateFlag, int autoAnswerDivSCM)// add 2011/07/18 朱宝軍 // DEL 2011/12/15
        //public SalesSlip(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, Int32 salesSlipUpdateCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime preSalesDate, DateTime addUpADate, Int32 delayPaymentDiv, string estimateFormNo, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesPrtTotalTaxInc, Int64 salesPrtTotalTaxExc, Int64 salesWorkTotalTaxInc, Int64 salesWorkTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesPrtSubttlInc, Int64 salesPrtSubttlExc, Int64 salesWorkSubttlInc, Int64 salesWorkSubttlExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedPartsDisOutTax, Int64 itdedPartsDisInTax, Int64 itdedWorkDisOutTax, Int64 itdedWorkDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Double partsDiscountRate, Double ravorDiscountRate, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, Int32 outputNameCode, string outputName, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string carSlipNote, string mileage, string slipNote, string slipNote2, string slipNote3, Int32 slipNoteCode, Int32 slipNote2Code, Int32 slipNote3Code, Int32 retGoodsReasonDiv, string retGoodsReason, DateTime regiProcDate, Int32 cashRegisterNo, Int32 posReceiptNo, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, string orderNumber, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, Int32 reconcileFlag, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 estimaTaxDivCd, Int32 estimateFormPrtCd, string estimateSubject, string footnotes1, string footnotes2, string estimateTitle1, string estimateTitle2, string estimateTitle3, string estimateTitle4, string estimateTitle5, string estimateNote1, string estimateNote2, string estimateNote3, string estimateNote4, string estimateNote5, DateTime estimateValidityDate, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 rateUseCode, Int32 inputMode, Int32 salesSlipDisplay, Int32 acptAnOdrStatusDisplay, Int32 custRateGrpCode, string claimName, string claimName2, Int32 creditMngCode, Int32 totalDay, Int32 nTimeCalcStDate, Int64 totalMoneyForGrossProfit, string sectionName, string subSectionName, Int32 carMngDivCd, Int32 searchMode, Int32 searchCarMode, Double salesRate, Int32 estimateDtCreateDiv, Int32 custOrderNoDispDiv, string custWarehouseCd, DateTime transStopDate, Int32 onlineKindDiv, string inqOriginalEpCd, string inqOriginalSecCd, Int32 answerDiv, Int64 inquiryNumber, Int32 inqOrdDivCd, string enterpriseName, string updEmployeeName, string resultsAddUpSecNm, Int32 detailRowCountForReadSlip, bool stockUpdateFlag, int autoAnswerDivSCM)// add 2011/07/18 朱宝軍 // ADD 2011/12/15 // DEL 2013/01/18 田建委 Redmine#33797
        //----- ADD 2013/01/18 田建委 Redmine#33797 ---------->>>>>
        public SalesSlip(
            DateTime createDateTime,
            DateTime updateDateTime,
            string enterpriseCode,
            Guid fileHeaderGuid,
            string updEmployeeCode,
            string updAssemblyId1,
            string updAssemblyId2,
            Int32 logicalDeleteCode,
            Int32 acptAnOdrStatus,
            string salesSlipNum,
            string sectionCode,
            Int32 subSectionCode,
            Int32 debitNoteDiv,
            string debitNLnkSalesSlNum,
            Int32 salesSlipCd,
            Int32 salesGoodsCd,
            Int32 accRecDivCd,
            string salesInpSecCd,
            string demandAddUpSecCd,
            string resultsAddUpSecCd,
            string updateSecCd,
            Int32 salesSlipUpdateCd,
            DateTime searchSlipDate,
            DateTime shipmentDay,
            DateTime salesDate,
            DateTime preSalesDate,
            DateTime addUpADate,
            Int32 delayPaymentDiv,
            string estimateFormNo,
            Int32 estimateDivide,
            string inputAgenCd,
            string inputAgenNm,
            string salesInputCode,
            string salesInputName,
            string frontEmployeeCd,
            string frontEmployeeNm,
            string salesEmployeeCd,
            string salesEmployeeNm,
            Int32 totalAmountDispWayCd,
            Int32 ttlAmntDispRateApy,
            Int64 salesTotalTaxInc,
            Int64 salesTotalTaxExc,
            Int64 salesPrtTotalTaxInc,
            Int64 salesPrtTotalTaxExc,
            Int64 salesWorkTotalTaxInc,
            Int64 salesWorkTotalTaxExc,
            Int64 salesSubtotalTaxInc,
            Int64 salesSubtotalTaxExc,
            Int64 salesPrtSubttlInc,
            Int64 salesPrtSubttlExc,
            Int64 salesWorkSubttlInc,
            Int64 salesWorkSubttlExc,
            Int64 salesNetPrice,
            Int64 salesSubtotalTax,
            Int64 itdedSalesOutTax,
            Int64 itdedSalesInTax,
            Int64 salSubttlSubToTaxFre,
            Int64 salesOutTax,
            Int64 salAmntConsTaxInclu,
            Int64 salesDisTtlTaxExc,
            Int64 itdedSalesDisOutTax,
            Int64 itdedSalesDisInTax,
            Int64 itdedPartsDisOutTax,
            Int64 itdedPartsDisInTax,
            Int64 itdedWorkDisOutTax,
            Int64 itdedWorkDisInTax,
            Int64 itdedSalesDisTaxFre,
            Int64 salesDisOutTax,
            Int64 salesDisTtlTaxInclu,
            Double partsDiscountRate,
            Double ravorDiscountRate,
            Int64 totalCost,
            Int32 consTaxLayMethod,
            Double consTaxRate,
            Int32 fractionProcCd,
            Int64 accRecConsTax,
            Int32 autoDepositCd,
            Int32 autoDepositNoteDiv, // 自動入金備考区分(0:売上伝票番号 1:売上伝票備考 2:無し)
            Int32 autoDepositSlipNo,
            Int64 depositAllowanceTtl,
            Int64 depositAlwcBlnce,
            Int32 claimCode,
            string claimSnm,
            Int32 customerCode,
            string customerName,
            string customerName2,
            string customerSnm,
            string honorificTitle,
            Int32 outputNameCode,
            string outputName,
            Int32 custSlipNo,
            Int32 slipAddressDiv,
            Int32 addresseeCode,
            string addresseeName,
            string addresseeName2,
            string addresseePostNo,
            string addresseeAddr1,
            string addresseeAddr3,
            string addresseeAddr4,
            string addresseeTelNo,
            string addresseeFaxNo,
            string partySaleSlipNum,
            string carSlipNote,
            string mileage,
            string slipNote,
            string slipNote2,
            string slipNote3,
            Int32 slipNoteCode,
            Int32 slipNote2Code,
            Int32 slipNote3Code,
            Int32 retGoodsReasonDiv,
            string retGoodsReason,
            DateTime regiProcDate,
            Int32 cashRegisterNo,
            Int32 posReceiptNo,
            Int32 detailRowCount,
            DateTime ediSendDate,
            DateTime ediTakeInDate,
            string uoeRemark1,
            string uoeRemark2,
            Int32 slipPrintDivCd,
            Int32 slipPrintFinishCd,
            DateTime salesSlipPrintDate,
            Int32 businessTypeCode,
            string businessTypeName,
            string orderNumber,
            Int32 deliveredGoodsDiv,
            string deliveredGoodsDivNm,
            Int32 salesAreaCode,
            string salesAreaName,
            Int32 reconcileFlag,
            string slipPrtSetPaperId,
            Int32 completeCd,
            Int32 salesPriceFracProcCd,
            Int64 stockGoodsTtlTaxExc,
            Int64 pureGoodsTtlTaxExc,
            Int32 listPricePrintDiv,
            Int32 eraNameDispCd1,
            Int32 estimaTaxDivCd,
            Int32 estimateFormPrtCd,
            string estimateSubject,
            string footnotes1,
            string footnotes2,
            string estimateTitle1,
            string estimateTitle2,
            string estimateTitle3,
            string estimateTitle4,
            string estimateTitle5,
            string estimateNote1,
            string estimateNote2,
            string estimateNote3,
            string estimateNote4,
            string estimateNote5,
            DateTime estimateValidityDate,
            Int32 partsNoPrtCd,
            Int32 optionPringDivCd,
            Int32 rateUseCode,
            Int32 inputMode,
            Int32 salesSlipDisplay,
            Int32 acptAnOdrStatusDisplay,
            Int32 custRateGrpCode,
            string claimName,
            string claimName2,
            Int32 creditMngCode,
            Int32 totalDay,
            Int32 nTimeCalcStDate,
            Int64 totalMoneyForGrossProfit,
            string sectionName,
            string subSectionName,
            Int32 carMngDivCd,
            Int32 searchMode,
            Int32 searchCarMode,
            Double salesRate,
            Int32 estimateDtCreateDiv,
            Int32 custOrderNoDispDiv,
            string custWarehouseCd,
            DateTime transStopDate,
            Int32 onlineKindDiv,
            string inqOriginalEpCd,
            string inqOriginalSecCd,
            Int32 answerDiv,
            Int64 inquiryNumber,
            Int32 inqOrdDivCd,
            string enterpriseName,
            string updEmployeeName,
            string resultsAddUpSecNm,
            Int32 detailRowCountForReadSlip,
            bool stockUpdateFlag,
            int autoAnswerDivSCM)
        //----- ADD 2013/01/18 田建委 Redmine#33797 ----------<<<<<
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._salesSlipNum = salesSlipNum;
            this._sectionCode = sectionCode;
            this._subSectionCode = subSectionCode;
            this._debitNoteDiv = debitNoteDiv;
            this._debitNLnkSalesSlNum = debitNLnkSalesSlNum;
            this._salesSlipCd = salesSlipCd;
            this._salesGoodsCd = salesGoodsCd;
            this._accRecDivCd = accRecDivCd;
            this._salesInpSecCd = salesInpSecCd;
            this._demandAddUpSecCd = demandAddUpSecCd;
            this._resultsAddUpSecCd = resultsAddUpSecCd;
            this._updateSecCd = updateSecCd;
            this._salesSlipUpdateCd = salesSlipUpdateCd;
            this.SearchSlipDate = searchSlipDate;
            this.ShipmentDay = shipmentDay;
            this.SalesDate = salesDate;
            this.PreSalesDate = preSalesDate; // ADD 2011/12/15
            this.AddUpADate = addUpADate;
            this._delayPaymentDiv = delayPaymentDiv;
            this._estimateFormNo = estimateFormNo;
            this._estimateDivide = estimateDivide;
            this._inputAgenCd = inputAgenCd;
            this._inputAgenNm = inputAgenNm;
            this._salesInputCode = salesInputCode;
            this._salesInputName = salesInputName;
            this._frontEmployeeCd = frontEmployeeCd;
            this._frontEmployeeNm = frontEmployeeNm;
            this._salesEmployeeCd = salesEmployeeCd;
            this._salesEmployeeNm = salesEmployeeNm;
            this._totalAmountDispWayCd = totalAmountDispWayCd;
            this._ttlAmntDispRateApy = ttlAmntDispRateApy;
            this._salesTotalTaxInc = salesTotalTaxInc;
            this._salesTotalTaxExc = salesTotalTaxExc;
            this._salesPrtTotalTaxInc = salesPrtTotalTaxInc;
            this._salesPrtTotalTaxExc = salesPrtTotalTaxExc;
            this._salesWorkTotalTaxInc = salesWorkTotalTaxInc;
            this._salesWorkTotalTaxExc = salesWorkTotalTaxExc;
            this._salesSubtotalTaxInc = salesSubtotalTaxInc;
            this._salesSubtotalTaxExc = salesSubtotalTaxExc;
            this._salesPrtSubttlInc = salesPrtSubttlInc;
            this._salesPrtSubttlExc = salesPrtSubttlExc;
            this._salesWorkSubttlInc = salesWorkSubttlInc;
            this._salesWorkSubttlExc = salesWorkSubttlExc;
            this._salesNetPrice = salesNetPrice;
            this._salesSubtotalTax = salesSubtotalTax;
            this._itdedSalesOutTax = itdedSalesOutTax;
            this._itdedSalesInTax = itdedSalesInTax;
            this._salSubttlSubToTaxFre = salSubttlSubToTaxFre;
            this._salesOutTax = salesOutTax;
            this._salAmntConsTaxInclu = salAmntConsTaxInclu;
            this._salesDisTtlTaxExc = salesDisTtlTaxExc;
            this._itdedSalesDisOutTax = itdedSalesDisOutTax;
            this._itdedSalesDisInTax = itdedSalesDisInTax;
            this._itdedPartsDisOutTax = itdedPartsDisOutTax;
            this._itdedPartsDisInTax = itdedPartsDisInTax;
            this._itdedWorkDisOutTax = itdedWorkDisOutTax;
            this._itdedWorkDisInTax = itdedWorkDisInTax;
            this._itdedSalesDisTaxFre = itdedSalesDisTaxFre;
            this._salesDisOutTax = salesDisOutTax;
            this._salesDisTtlTaxInclu = salesDisTtlTaxInclu;
            this._partsDiscountRate = partsDiscountRate;
            this._ravorDiscountRate = ravorDiscountRate;
            this._totalCost = totalCost;
            this._consTaxLayMethod = consTaxLayMethod;
            this._consTaxRate = consTaxRate;
            this._fractionProcCd = fractionProcCd;
            this._accRecConsTax = accRecConsTax;
            this._autoDepositCd = autoDepositCd;
            this._autoDepositNoteDiv = autoDepositNoteDiv; // 自動入金備考区分(0:売上伝票番号 1:売上伝票備考 2:無し) // ADD 2013/01/18 田建委 Redmine#33797
            this._autoDepositSlipNo = autoDepositSlipNo;
            this._depositAllowanceTtl = depositAllowanceTtl;
            this._depositAlwcBlnce = depositAlwcBlnce;
            this._claimCode = claimCode;
            this._claimSnm = claimSnm;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._customerName2 = customerName2;
            this._customerSnm = customerSnm;
            this._honorificTitle = honorificTitle;
            this._outputNameCode = outputNameCode;
            this._outputName = outputName;
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
            // --- ADD 2009/09/08 ---------->>>>>
            this._carSlipNote = carSlipNote;
            this._mileage = mileage;
            // --- ADD 2009/09/08 ----------<<<<<
            this._slipNote = slipNote;
            this._slipNote2 = slipNote2;
            this._slipNote3 = slipNote3;
            // --- ADD 2009/12/23 ---------->>>>>
            this._slipNoteCode = slipNoteCode;
            this._slipNote2Code = slipNote2Code;
            this._slipNote3Code = slipNote3Code;
            // --- ADD 2009/12/23 ----------<<<<<
            this._retGoodsReasonDiv = retGoodsReasonDiv;
            this._retGoodsReason = retGoodsReason;
            this.RegiProcDate = regiProcDate;
            this._cashRegisterNo = cashRegisterNo;
            this._posReceiptNo = posReceiptNo;
            this._detailRowCount = detailRowCount;
            this.EdiSendDate = ediSendDate;
            this.EdiTakeInDate = ediTakeInDate;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this._slipPrintDivCd = slipPrintDivCd;
            this._slipPrintFinishCd = slipPrintFinishCd;
            this.SalesSlipPrintDate = salesSlipPrintDate;
            this._businessTypeCode = businessTypeCode;
            this._businessTypeName = businessTypeName;
            this._orderNumber = orderNumber;
            this._deliveredGoodsDiv = deliveredGoodsDiv;
            this._deliveredGoodsDivNm = deliveredGoodsDivNm;
            this._salesAreaCode = salesAreaCode;
            this._salesAreaName = salesAreaName;
            this._reconcileFlag = reconcileFlag;
            this._slipPrtSetPaperId = slipPrtSetPaperId;
            this._completeCd = completeCd;
            this._salesPriceFracProcCd = salesPriceFracProcCd;
            this._stockGoodsTtlTaxExc = stockGoodsTtlTaxExc;
            this._pureGoodsTtlTaxExc = pureGoodsTtlTaxExc;
            this._listPricePrintDiv = listPricePrintDiv;
            this._eraNameDispCd1 = eraNameDispCd1;
            this._estimaTaxDivCd = estimaTaxDivCd;
            this._estimateFormPrtCd = estimateFormPrtCd;
            this._estimateSubject = estimateSubject;
            this._footnotes1 = footnotes1;
            this._footnotes2 = footnotes2;
            this._estimateTitle1 = estimateTitle1;
            this._estimateTitle2 = estimateTitle2;
            this._estimateTitle3 = estimateTitle3;
            this._estimateTitle4 = estimateTitle4;
            this._estimateTitle5 = estimateTitle5;
            this._estimateNote1 = estimateNote1;
            this._estimateNote2 = estimateNote2;
            this._estimateNote3 = estimateNote3;
            this._estimateNote4 = estimateNote4;
            this._estimateNote5 = estimateNote5;
            this.EstimateValidityDate = estimateValidityDate;
            this._partsNoPrtCd = partsNoPrtCd;
            this._optionPringDivCd = optionPringDivCd;
            this._rateUseCode = rateUseCode;
            this._inputMode = inputMode;
            this._salesSlipDisplay = salesSlipDisplay;
            this._acptAnOdrStatusDisplay = acptAnOdrStatusDisplay;
            this._custRateGrpCode = custRateGrpCode;
            this._claimName = claimName;
            this._claimName2 = claimName2;
            this._creditMngCode = creditMngCode;
            this._totalDay = totalDay;
            this._nTimeCalcStDate = nTimeCalcStDate;
            this._totalMoneyForGrossProfit = totalMoneyForGrossProfit;
            this._sectionName = sectionName;
            this._subSectionName = subSectionName;
            this._carMngDivCd = carMngDivCd;
            this._searchMode = searchMode;
            this._searchCarMode = searchCarMode;
            this._salesRate = salesRate;
            this._estimateDtCreateDiv = estimateDtCreateDiv;
            this._custOrderNoDispDiv = custOrderNoDispDiv;
            this._custWarehouseCd = custWarehouseCd;
            this.TransStopDate = transStopDate;
            //>>>2010/02/26
            this._onlineKindDiv = onlineKindDiv;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._answerDiv = answerDiv;
            this._inquiryNumber = inquiryNumber;
            //<<<2010/02/26
            //>>>2010/04/08
            this._inqOrdDivCd = inqOrdDivCd;
            //<<<2010/04/08
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._resultsAddUpSecNm = resultsAddUpSecNm;
            this._detailRowCountForReadSlip = detailRowCountForReadSlip; // ADD 2009/12/17
            this._stockUpdateFlag = stockUpdateFlag; // ADD 2010/01/27
            this._autoAnswerDivSCM = autoAnswerDivSCM; // add 2011/07/18 朱宝軍
        }

        /// <summary>
        /// 売上データ複製処理
        /// </summary>
        /// <returns>SalesSlipクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSalesSlipクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesSlip Clone()
        {
            //>>>2010/04/08
            ////>>>2010/02/26
            //////return new SalesSlip(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._salesSlipUpdateCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._addUpADate, this._delayPaymentDiv, this._estimateFormNo, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesPrtTotalTaxInc, this._salesPrtTotalTaxExc, this._salesWorkTotalTaxInc, this._salesWorkTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesPrtSubttlInc, this._salesPrtSubttlExc, this._salesWorkSubttlInc, this._salesWorkSubttlExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedPartsDisOutTax, this._itdedPartsDisInTax, this._itdedWorkDisOutTax, this._itdedWorkDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._partsDiscountRate, this._ravorDiscountRate, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputNameCode, this._outputName, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._carSlipNote, this._mileage, this._slipNote, this._slipNote2, this._slipNote3, this._retGoodsReasonDiv, this._retGoodsReason, this._regiProcDate, this._cashRegisterNo, this._posReceiptNo, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._orderNumber, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._reconcileFlag, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._estimaTaxDivCd, this._estimateFormPrtCd, this._estimateSubject, this._footnotes1, this._footnotes2, this._estimateTitle1, this._estimateTitle2, this._estimateTitle3, this._estimateTitle4, this._estimateTitle5, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimateNote4, this._estimateNote5, this._estimateValidityDate, this._partsNoPrtCd, this._optionPringDivCd, this._rateUseCode, this._inputMode, this._salesSlipDisplay, this._acptAnOdrStatusDisplay, this._custRateGrpCode, this._claimName, this._claimName2, this._creditMngCode, this._totalDay, this._nTimeCalcStDate, this._totalMoneyForGrossProfit, this._sectionName, this._subSectionName, this._carMngDivCd, this._searchMode, this._searchCarMode, this._salesRate, this._estimateDtCreateDiv, this._custOrderNoDispDiv, this._custWarehouseCd, this._transStopDate, this._enterpriseName, this._updEmployeeName, this._resultsAddUpSecNm); // DEL 2009/12/17
            ////return new SalesSlip(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._salesSlipUpdateCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._addUpADate, this._delayPaymentDiv, this._estimateFormNo, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesPrtTotalTaxInc, this._salesPrtTotalTaxExc, this._salesWorkTotalTaxInc, this._salesWorkTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesPrtSubttlInc, this._salesPrtSubttlExc, this._salesWorkSubttlInc, this._salesWorkSubttlExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedPartsDisOutTax, this._itdedPartsDisInTax, this._itdedWorkDisOutTax, this._itdedWorkDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._partsDiscountRate, this._ravorDiscountRate, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputNameCode, this._outputName, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._carSlipNote, this._mileage, this._slipNote, this._slipNote2, this._slipNote3, this._slipNoteCode, this._slipNote2Code, this._slipNote3Code, this._retGoodsReasonDiv, this._retGoodsReason, this._regiProcDate, this._cashRegisterNo, this._posReceiptNo, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._orderNumber, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._reconcileFlag, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._estimaTaxDivCd, this._estimateFormPrtCd, this._estimateSubject, this._footnotes1, this._footnotes2, this._estimateTitle1, this._estimateTitle2, this._estimateTitle3, this._estimateTitle4, this._estimateTitle5, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimateNote4, this._estimateNote5, this._estimateValidityDate, this._partsNoPrtCd, this._optionPringDivCd, this._rateUseCode, this._inputMode, this._salesSlipDisplay, this._acptAnOdrStatusDisplay, this._custRateGrpCode, this._claimName, this._claimName2, this._creditMngCode, this._totalDay, this._nTimeCalcStDate, this._totalMoneyForGrossProfit, this._sectionName, this._subSectionName, this._carMngDivCd, this._searchMode, this._searchCarMode, this._salesRate, this._estimateDtCreateDiv, this._custOrderNoDispDiv, this._custWarehouseCd, this._transStopDate, this._enterpriseName, this._updEmployeeName, this._resultsAddUpSecNm, this._detailRowCountForReadSlip); // ADD 2009/12/17
            //return new SalesSlip(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._salesSlipUpdateCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._addUpADate, this._delayPaymentDiv, this._estimateFormNo, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesPrtTotalTaxInc, this._salesPrtTotalTaxExc, this._salesWorkTotalTaxInc, this._salesWorkTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesPrtSubttlInc, this._salesPrtSubttlExc, this._salesWorkSubttlInc, this._salesWorkSubttlExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedPartsDisOutTax, this._itdedPartsDisInTax, this._itdedWorkDisOutTax, this._itdedWorkDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._partsDiscountRate, this._ravorDiscountRate, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputNameCode, this._outputName, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._carSlipNote, this._mileage, this._slipNote, this._slipNote2, this._slipNote3, this._slipNoteCode, this._slipNote2Code, this._slipNote3Code, this._retGoodsReasonDiv, this._retGoodsReason, this._regiProcDate, this._cashRegisterNo, this._posReceiptNo, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._orderNumber, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._reconcileFlag, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._estimaTaxDivCd, this._estimateFormPrtCd, this._estimateSubject, this._footnotes1, this._footnotes2, this._estimateTitle1, this._estimateTitle2, this._estimateTitle3, this._estimateTitle4, this._estimateTitle5, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimateNote4, this._estimateNote5, this._estimateValidityDate, this._partsNoPrtCd, this._optionPringDivCd, this._rateUseCode, this._inputMode, this._salesSlipDisplay, this._acptAnOdrStatusDisplay, this._custRateGrpCode, this._claimName, this._claimName2, this._creditMngCode, this._totalDay, this._nTimeCalcStDate, this._totalMoneyForGrossProfit, this._sectionName, this._subSectionName, this._carMngDivCd, this._searchMode, this._searchCarMode, this._salesRate, this._estimateDtCreateDiv, this._custOrderNoDispDiv, this._custWarehouseCd, this._transStopDate, this._onlineKindDiv, this._inqOriginalEpCd, this._inqOriginalSecCd, this._answerDiv, this._inquiryNumber, this._enterpriseName, this._updEmployeeName, this._resultsAddUpSecNm, this._detailRowCountForReadSlip); // ADD 2009/12/17
            ////<<<2010/02/26
            // --- UPD 2010/01/27 -------------->>>>>
            //return new SalesSlip(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._salesSlipUpdateCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._addUpADate, this._delayPaymentDiv, this._estimateFormNo, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesPrtTotalTaxInc, this._salesPrtTotalTaxExc, this._salesWorkTotalTaxInc, this._salesWorkTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesPrtSubttlInc, this._salesPrtSubttlExc, this._salesWorkSubttlInc, this._salesWorkSubttlExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedPartsDisOutTax, this._itdedPartsDisInTax, this._itdedWorkDisOutTax, this._itdedWorkDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._partsDiscountRate, this._ravorDiscountRate, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputNameCode, this._outputName, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._carSlipNote, this._mileage, this._slipNote, this._slipNote2, this._slipNote3, this._slipNoteCode, this._slipNote2Code, this._slipNote3Code, this._retGoodsReasonDiv, this._retGoodsReason, this._regiProcDate, this._cashRegisterNo, this._posReceiptNo, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._orderNumber, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._reconcileFlag, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._estimaTaxDivCd, this._estimateFormPrtCd, this._estimateSubject, this._footnotes1, this._footnotes2, this._estimateTitle1, this._estimateTitle2, this._estimateTitle3, this._estimateTitle4, this._estimateTitle5, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimateNote4, this._estimateNote5, this._estimateValidityDate, this._partsNoPrtCd, this._optionPringDivCd, this._rateUseCode, this._inputMode, this._salesSlipDisplay, this._acptAnOdrStatusDisplay, this._custRateGrpCode, this._claimName, this._claimName2, this._creditMngCode, this._totalDay, this._nTimeCalcStDate, this._totalMoneyForGrossProfit, this._sectionName, this._subSectionName, this._carMngDivCd, this._searchMode, this._searchCarMode, this._salesRate, this._estimateDtCreateDiv, this._custOrderNoDispDiv, this._custWarehouseCd, this._transStopDate, this._onlineKindDiv, this._inqOriginalEpCd, this._inqOriginalSecCd, this._answerDiv, this._inquiryNumber, this._inqOrdDivCd, this._enterpriseName, this._updEmployeeName, this._resultsAddUpSecNm, this._detailRowCountForReadSlip);
            //return new SalesSlip(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._salesSlipUpdateCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._addUpADate, this._delayPaymentDiv, this._estimateFormNo, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesPrtTotalTaxInc, this._salesPrtTotalTaxExc, this._salesWorkTotalTaxInc, this._salesWorkTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesPrtSubttlInc, this._salesPrtSubttlExc, this._salesWorkSubttlInc, this._salesWorkSubttlExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedPartsDisOutTax, this._itdedPartsDisInTax, this._itdedWorkDisOutTax, this._itdedWorkDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._partsDiscountRate, this._ravorDiscountRate, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputNameCode, this._outputName, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._carSlipNote, this._mileage, this._slipNote, this._slipNote2, this._slipNote3, this._slipNoteCode, this._slipNote2Code, this._slipNote3Code, this._retGoodsReasonDiv, this._retGoodsReason, this._regiProcDate, this._cashRegisterNo, this._posReceiptNo, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._orderNumber, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._reconcileFlag, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._estimaTaxDivCd, this._estimateFormPrtCd, this._estimateSubject, this._footnotes1, this._footnotes2, this._estimateTitle1, this._estimateTitle2, this._estimateTitle3, this._estimateTitle4, this._estimateTitle5, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimateNote4, this._estimateNote5, this._estimateValidityDate, this._partsNoPrtCd, this._optionPringDivCd, this._rateUseCode, this._inputMode, this._salesSlipDisplay, this._acptAnOdrStatusDisplay, this._custRateGrpCode, this._claimName, this._claimName2, this._creditMngCode, this._totalDay, this._nTimeCalcStDate, this._totalMoneyForGrossProfit, this._sectionName, this._subSectionName, this._carMngDivCd, this._searchMode, this._searchCarMode, this._salesRate, this._estimateDtCreateDiv, this._custOrderNoDispDiv, this._custWarehouseCd, this._transStopDate, this._onlineKindDiv, this._inqOriginalEpCd, this._inqOriginalSecCd, this._answerDiv, this._inquiryNumber, this._inqOrdDivCd, this._enterpriseName, this._updEmployeeName, this._resultsAddUpSecNm, this._detailRowCountForReadSlip, this._stockUpdateFlag);// del 2011/07/18 朱宝軍
            // --- UPD 2010/01/27 --------------<<<<<
            //<<<2010/04/08
            //return new SalesSlip(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._salesSlipUpdateCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._addUpADate, this._delayPaymentDiv, this._estimateFormNo, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesPrtTotalTaxInc, this._salesPrtTotalTaxExc, this._salesWorkTotalTaxInc, this._salesWorkTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesPrtSubttlInc, this._salesPrtSubttlExc, this._salesWorkSubttlInc, this._salesWorkSubttlExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedPartsDisOutTax, this._itdedPartsDisInTax, this._itdedWorkDisOutTax, this._itdedWorkDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._partsDiscountRate, this._ravorDiscountRate, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputNameCode, this._outputName, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._carSlipNote, this._mileage, this._slipNote, this._slipNote2, this._slipNote3, this._slipNoteCode, this._slipNote2Code, this._slipNote3Code, this._retGoodsReasonDiv, this._retGoodsReason, this._regiProcDate, this._cashRegisterNo, this._posReceiptNo, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._orderNumber, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._reconcileFlag, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._estimaTaxDivCd, this._estimateFormPrtCd, this._estimateSubject, this._footnotes1, this._footnotes2, this._estimateTitle1, this._estimateTitle2, this._estimateTitle3, this._estimateTitle4, this._estimateTitle5, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimateNote4, this._estimateNote5, this._estimateValidityDate, this._partsNoPrtCd, this._optionPringDivCd, this._rateUseCode, this._inputMode, this._salesSlipDisplay, this._acptAnOdrStatusDisplay, this._custRateGrpCode, this._claimName, this._claimName2, this._creditMngCode, this._totalDay, this._nTimeCalcStDate, this._totalMoneyForGrossProfit, this._sectionName, this._subSectionName, this._carMngDivCd, this._searchMode, this._searchCarMode, this._salesRate, this._estimateDtCreateDiv, this._custOrderNoDispDiv, this._custWarehouseCd, this._transStopDate, this._onlineKindDiv, this._inqOriginalEpCd, this._inqOriginalSecCd, this._answerDiv, this._inquiryNumber, this._inqOrdDivCd, this._enterpriseName, this._updEmployeeName, this._resultsAddUpSecNm, this._detailRowCountForReadSlip, this._stockUpdateFlag, this._autoAnswerDivSCM);// add 2011/07/18 朱宝軍 // DEL 2011/12/15
            //return new SalesSlip(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._salesSlipUpdateCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._preSalesDate, this._addUpADate, this._delayPaymentDiv, this._estimateFormNo, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesPrtTotalTaxInc, this._salesPrtTotalTaxExc, this._salesWorkTotalTaxInc, this._salesWorkTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesPrtSubttlInc, this._salesPrtSubttlExc, this._salesWorkSubttlInc, this._salesWorkSubttlExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedPartsDisOutTax, this._itdedPartsDisInTax, this._itdedWorkDisOutTax, this._itdedWorkDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._partsDiscountRate, this._ravorDiscountRate, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputNameCode, this._outputName, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._carSlipNote, this._mileage, this._slipNote, this._slipNote2, this._slipNote3, this._slipNoteCode, this._slipNote2Code, this._slipNote3Code, this._retGoodsReasonDiv, this._retGoodsReason, this._regiProcDate, this._cashRegisterNo, this._posReceiptNo, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._orderNumber, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._reconcileFlag, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._estimaTaxDivCd, this._estimateFormPrtCd, this._estimateSubject, this._footnotes1, this._footnotes2, this._estimateTitle1, this._estimateTitle2, this._estimateTitle3, this._estimateTitle4, this._estimateTitle5, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimateNote4, this._estimateNote5, this._estimateValidityDate, this._partsNoPrtCd, this._optionPringDivCd, this._rateUseCode, this._inputMode, this._salesSlipDisplay, this._acptAnOdrStatusDisplay, this._custRateGrpCode, this._claimName, this._claimName2, this._creditMngCode, this._totalDay, this._nTimeCalcStDate, this._totalMoneyForGrossProfit, this._sectionName, this._subSectionName, this._carMngDivCd, this._searchMode, this._searchCarMode, this._salesRate, this._estimateDtCreateDiv, this._custOrderNoDispDiv, this._custWarehouseCd, this._transStopDate, this._onlineKindDiv, this._inqOriginalEpCd, this._inqOriginalSecCd, this._answerDiv, this._inquiryNumber, this._inqOrdDivCd, this._enterpriseName, this._updEmployeeName, this._resultsAddUpSecNm, this._detailRowCountForReadSlip, this._stockUpdateFlag, this._autoAnswerDivSCM);// ADD 2011/12/15 // DEL 2013/01/18 田建委 Redmine#33797
            //----- ADD 2013/01/18 田建委 Redmine#33797 ---------->>>>>
            return new SalesSlip(
                this._createDateTime,
                this._updateDateTime,
                this._enterpriseCode,
                this._fileHeaderGuid,
                this._updEmployeeCode,
                this._updAssemblyId1,
                this._updAssemblyId2,
                this._logicalDeleteCode,
                this._acptAnOdrStatus,
                this._salesSlipNum,
                this._sectionCode,
                this._subSectionCode,
                this._debitNoteDiv,
                this._debitNLnkSalesSlNum,
                this._salesSlipCd,
                this._salesGoodsCd,
                this._accRecDivCd,
                this._salesInpSecCd,
                this._demandAddUpSecCd,
                this._resultsAddUpSecCd,
                this._updateSecCd,
                this._salesSlipUpdateCd,
                this._searchSlipDate,
                this._shipmentDay,
                this._salesDate,
                this._preSalesDate,
                this._addUpADate,
                this._delayPaymentDiv,
                this._estimateFormNo,
                this._estimateDivide,
                this._inputAgenCd,
                this._inputAgenNm,
                this._salesInputCode,
                this._salesInputName,
                this._frontEmployeeCd,
                this._frontEmployeeNm,
                this._salesEmployeeCd,
                this._salesEmployeeNm,
                this._totalAmountDispWayCd,
                this._ttlAmntDispRateApy,
                this._salesTotalTaxInc,
                this._salesTotalTaxExc,
                this._salesPrtTotalTaxInc,
                this._salesPrtTotalTaxExc,
                this._salesWorkTotalTaxInc,
                this._salesWorkTotalTaxExc,
                this._salesSubtotalTaxInc,
                this._salesSubtotalTaxExc,
                this._salesPrtSubttlInc,
                this._salesPrtSubttlExc,
                this._salesWorkSubttlInc,
                this._salesWorkSubttlExc,
                this._salesNetPrice,
                this._salesSubtotalTax,
                this._itdedSalesOutTax,
                this._itdedSalesInTax,
                this._salSubttlSubToTaxFre,
                this._salesOutTax,
                this._salAmntConsTaxInclu,
                this._salesDisTtlTaxExc,
                this._itdedSalesDisOutTax,
                this._itdedSalesDisInTax,
                this._itdedPartsDisOutTax,
                this._itdedPartsDisInTax,
                this._itdedWorkDisOutTax,
                this._itdedWorkDisInTax,
                this._itdedSalesDisTaxFre,
                this._salesDisOutTax,
                this._salesDisTtlTaxInclu,
                this._partsDiscountRate,
                this._ravorDiscountRate,
                this._totalCost,
                this._consTaxLayMethod,
                this._consTaxRate,
                this._fractionProcCd,
                this._accRecConsTax,
                this._autoDepositCd,
                this._autoDepositNoteDiv, // 自動入金備考区分(0:売上伝票番号 1:売上伝票備考 2:無し)
                this._autoDepositSlipNo,
                this._depositAllowanceTtl,
                this._depositAlwcBlnce,
                this._claimCode,
                this._claimSnm,
                this._customerCode,
                this._customerName,
                this._customerName2,
                this._customerSnm,
                this._honorificTitle,
                this._outputNameCode,
                this._outputName,
                this._custSlipNo,
                this._slipAddressDiv,
                this._addresseeCode,
                this._addresseeName,
                this._addresseeName2,
                this._addresseePostNo,
                this._addresseeAddr1,
                this._addresseeAddr3,
                this._addresseeAddr4,
                this._addresseeTelNo,
                this._addresseeFaxNo,
                this._partySaleSlipNum,
                this._carSlipNote,
                this._mileage,
                this._slipNote,
                this._slipNote2,
                this._slipNote3,
                this._slipNoteCode,
                this._slipNote2Code,
                this._slipNote3Code,
                this._retGoodsReasonDiv,
                this._retGoodsReason,
                this._regiProcDate,
                this._cashRegisterNo,
                this._posReceiptNo,
                this._detailRowCount,
                this._ediSendDate,
                this._ediTakeInDate,
                this._uoeRemark1,
                this._uoeRemark2,
                this._slipPrintDivCd,
                this._slipPrintFinishCd,
                this._salesSlipPrintDate,
                this._businessTypeCode,
                this._businessTypeName,
                this._orderNumber,
                this._deliveredGoodsDiv,
                this._deliveredGoodsDivNm,
                this._salesAreaCode,
                this._salesAreaName,
                this._reconcileFlag,
                this._slipPrtSetPaperId,
                this._completeCd,
                this._salesPriceFracProcCd,
                this._stockGoodsTtlTaxExc,
                this._pureGoodsTtlTaxExc,
                this._listPricePrintDiv,
                this._eraNameDispCd1,
                this._estimaTaxDivCd,
                this._estimateFormPrtCd,
                this._estimateSubject,
                this._footnotes1,
                this._footnotes2,
                this._estimateTitle1,
                this._estimateTitle2,
                this._estimateTitle3,
                this._estimateTitle4,
                this._estimateTitle5,
                this._estimateNote1,
                this._estimateNote2,
                this._estimateNote3,
                this._estimateNote4,
                this._estimateNote5,
                this._estimateValidityDate,
                this._partsNoPrtCd,
                this._optionPringDivCd,
                this._rateUseCode,
                this._inputMode,
                this._salesSlipDisplay,
                this._acptAnOdrStatusDisplay,
                this._custRateGrpCode,
                this._claimName,
                this._claimName2,
                this._creditMngCode,
                this._totalDay,
                this._nTimeCalcStDate,
                this._totalMoneyForGrossProfit,
                this._sectionName,
                this._subSectionName,
                this._carMngDivCd,
                this._searchMode,
                this._searchCarMode,
                this._salesRate,
                this._estimateDtCreateDiv,
                this._custOrderNoDispDiv,
                this._custWarehouseCd,
                this._transStopDate,
                this._onlineKindDiv,
                this._inqOriginalEpCd.Trim(),//@@@@20230303
                this._inqOriginalSecCd,
                this._answerDiv,
                this._inquiryNumber,
                this._inqOrdDivCd,
                this._enterpriseName,
                this._updEmployeeName,
                this._resultsAddUpSecNm,
                this._detailRowCountForReadSlip,
                this._stockUpdateFlag,
                this._autoAnswerDivSCM);
            //----- ADD 2013/01/18 田建委 Redmine#33797 ----------<<<<<
        }

        /// <summary>
        /// 売上データ比較処理
        /// </summary>
        /// <param name="target">比較対象のSalesSlipクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SalesSlip target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.SalesSlipNum == target.SalesSlipNum)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SubSectionCode == target.SubSectionCode)
                 && (this.DebitNoteDiv == target.DebitNoteDiv)
                 && (this.DebitNLnkSalesSlNum == target.DebitNLnkSalesSlNum)
                 && (this.SalesSlipCd == target.SalesSlipCd)
                 && (this.SalesGoodsCd == target.SalesGoodsCd)
                 && (this.AccRecDivCd == target.AccRecDivCd)
                 && (this.SalesInpSecCd == target.SalesInpSecCd)
                 && (this.DemandAddUpSecCd == target.DemandAddUpSecCd)
                 && (this.ResultsAddUpSecCd == target.ResultsAddUpSecCd)
                 && (this.UpdateSecCd == target.UpdateSecCd)
                 && (this.SalesSlipUpdateCd == target.SalesSlipUpdateCd)
                 && (this.SearchSlipDate == target.SearchSlipDate)
                 && (this.ShipmentDay == target.ShipmentDay)
                 && (this.SalesDate == target.SalesDate)
                 && (this.PreSalesDate == target.PreSalesDate) // ADD 2011/12/15
                 && (this.AddUpADate == target.AddUpADate)
                 && (this.DelayPaymentDiv == target.DelayPaymentDiv)
                 && (this.EstimateFormNo == target.EstimateFormNo)
                 && (this.EstimateDivide == target.EstimateDivide)
                 && (this.InputAgenCd == target.InputAgenCd)
                 && (this.InputAgenNm == target.InputAgenNm)
                 && (this.SalesInputCode == target.SalesInputCode)
                 && (this.SalesInputName == target.SalesInputName)
                 && (this.FrontEmployeeCd == target.FrontEmployeeCd)
                 && (this.FrontEmployeeNm == target.FrontEmployeeNm)
                 && (this.SalesEmployeeCd == target.SalesEmployeeCd)
                 && (this.SalesEmployeeNm == target.SalesEmployeeNm)
                 && (this.TotalAmountDispWayCd == target.TotalAmountDispWayCd)
                 && (this.TtlAmntDispRateApy == target.TtlAmntDispRateApy)
                 && (this.SalesTotalTaxInc == target.SalesTotalTaxInc)
                 && (this.SalesTotalTaxExc == target.SalesTotalTaxExc)
                 && (this.SalesPrtTotalTaxInc == target.SalesPrtTotalTaxInc)
                 && (this.SalesPrtTotalTaxExc == target.SalesPrtTotalTaxExc)
                 && (this.SalesWorkTotalTaxInc == target.SalesWorkTotalTaxInc)
                 && (this.SalesWorkTotalTaxExc == target.SalesWorkTotalTaxExc)
                 && (this.SalesSubtotalTaxInc == target.SalesSubtotalTaxInc)
                 && (this.SalesSubtotalTaxExc == target.SalesSubtotalTaxExc)
                 && (this.SalesPrtSubttlInc == target.SalesPrtSubttlInc)
                 && (this.SalesPrtSubttlExc == target.SalesPrtSubttlExc)
                 && (this.SalesWorkSubttlInc == target.SalesWorkSubttlInc)
                 && (this.SalesWorkSubttlExc == target.SalesWorkSubttlExc)
                 && (this.SalesNetPrice == target.SalesNetPrice)
                 && (this.SalesSubtotalTax == target.SalesSubtotalTax)
                 && (this.ItdedSalesOutTax == target.ItdedSalesOutTax)
                 && (this.ItdedSalesInTax == target.ItdedSalesInTax)
                 && (this.SalSubttlSubToTaxFre == target.SalSubttlSubToTaxFre)
                 && (this.SalesOutTax == target.SalesOutTax)
                 && (this.SalAmntConsTaxInclu == target.SalAmntConsTaxInclu)
                 && (this.SalesDisTtlTaxExc == target.SalesDisTtlTaxExc)
                 && (this.ItdedSalesDisOutTax == target.ItdedSalesDisOutTax)
                 && (this.ItdedSalesDisInTax == target.ItdedSalesDisInTax)
                 && (this.ItdedPartsDisOutTax == target.ItdedPartsDisOutTax)
                 && (this.ItdedPartsDisInTax == target.ItdedPartsDisInTax)
                 && (this.ItdedWorkDisOutTax == target.ItdedWorkDisOutTax)
                 && (this.ItdedWorkDisInTax == target.ItdedWorkDisInTax)
                 && (this.ItdedSalesDisTaxFre == target.ItdedSalesDisTaxFre)
                 && (this.SalesDisOutTax == target.SalesDisOutTax)
                 && (this.SalesDisTtlTaxInclu == target.SalesDisTtlTaxInclu)
                 && (this.PartsDiscountRate == target.PartsDiscountRate)
                 && (this.RavorDiscountRate == target.RavorDiscountRate)
                 && (this.TotalCost == target.TotalCost)
                 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
                 && (this.ConsTaxRate == target.ConsTaxRate)
                 && (this.FractionProcCd == target.FractionProcCd)
                 && (this.AccRecConsTax == target.AccRecConsTax)
                 && (this.AutoDepositCd == target.AutoDepositCd)
                 && (this.AutoDepositNoteDiv == target.AutoDepositNoteDiv) // ADD 2013/01/18 田建委 Redmine#33797
                 && (this.AutoDepositSlipNo == target.AutoDepositSlipNo)
                 && (this.DepositAllowanceTtl == target.DepositAllowanceTtl)
                 && (this.DepositAlwcBlnce == target.DepositAlwcBlnce)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.ClaimSnm == target.ClaimSnm)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerName == target.CustomerName)
                 && (this.CustomerName2 == target.CustomerName2)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.HonorificTitle == target.HonorificTitle)
                 && (this.OutputNameCode == target.OutputNameCode)
                 && (this.OutputName == target.OutputName)
                 && (this.CustSlipNo == target.CustSlipNo)
                 && (this.SlipAddressDiv == target.SlipAddressDiv)
                 && (this.AddresseeCode == target.AddresseeCode)
                 && (this.AddresseeName == target.AddresseeName)
                 && (this.AddresseeName2 == target.AddresseeName2)
                 && (this.AddresseePostNo == target.AddresseePostNo)
                 && (this.AddresseeAddr1 == target.AddresseeAddr1)
                 && (this.AddresseeAddr3 == target.AddresseeAddr3)
                 && (this.AddresseeAddr4 == target.AddresseeAddr4)
                 && (this.AddresseeTelNo == target.AddresseeTelNo)
                 && (this.AddresseeFaxNo == target.AddresseeFaxNo)
                 && (this.PartySaleSlipNum == target.PartySaleSlipNum)
                 && (this.CarSlipNote == target.CarSlipNote)   // ADD 2009/09/08
                 && (this.Mileage == target.Mileage)   // ADD 2009/09/08
                 && (this.SlipNote == target.SlipNote)
                 && (this.SlipNote2 == target.SlipNote2)
                 && (this.SlipNote3 == target.SlipNote3)
                 // --- ADD 2009/12/23 ---------->>>>>
                 && (this.SlipNoteCode == target.SlipNoteCode)
                 && (this.SlipNote2Code == target.SlipNote2Code)
                 && (this.SlipNote3Code == target.SlipNote3Code)
                 // --- ADD 2009/12/23 ----------<<<<<
                 && (this.RetGoodsReasonDiv == target.RetGoodsReasonDiv)
                 && (this.RetGoodsReason == target.RetGoodsReason)
                 && (this.RegiProcDate == target.RegiProcDate)
                 && (this.CashRegisterNo == target.CashRegisterNo)
                 && (this.PosReceiptNo == target.PosReceiptNo)
                 && (this.DetailRowCount == target.DetailRowCount)
                 && (this.EdiSendDate == target.EdiSendDate)
                 && (this.EdiTakeInDate == target.EdiTakeInDate)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.SlipPrintDivCd == target.SlipPrintDivCd)
                 && (this.SlipPrintFinishCd == target.SlipPrintFinishCd)
                 && (this.SalesSlipPrintDate == target.SalesSlipPrintDate)
                 && (this.BusinessTypeCode == target.BusinessTypeCode)
                 && (this.BusinessTypeName == target.BusinessTypeName)
                 && (this.OrderNumber == target.OrderNumber)
                 && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
                 && (this.DeliveredGoodsDivNm == target.DeliveredGoodsDivNm)
                 && (this.SalesAreaCode == target.SalesAreaCode)
                 && (this.SalesAreaName == target.SalesAreaName)
                 && (this.ReconcileFlag == target.ReconcileFlag)
                 && (this.SlipPrtSetPaperId == target.SlipPrtSetPaperId)
                 && (this.CompleteCd == target.CompleteCd)
                 && (this.SalesPriceFracProcCd == target.SalesPriceFracProcCd)
                 && (this.StockGoodsTtlTaxExc == target.StockGoodsTtlTaxExc)
                 && (this.PureGoodsTtlTaxExc == target.PureGoodsTtlTaxExc)
                 && (this.ListPricePrintDiv == target.ListPricePrintDiv)
                 && (this.EraNameDispCd1 == target.EraNameDispCd1)
                 && (this.EstimaTaxDivCd == target.EstimaTaxDivCd)
                 && (this.EstimateFormPrtCd == target.EstimateFormPrtCd)
                 && (this.EstimateSubject == target.EstimateSubject)
                 && (this.Footnotes1 == target.Footnotes1)
                 && (this.Footnotes2 == target.Footnotes2)
                 && (this.EstimateTitle1 == target.EstimateTitle1)
                 && (this.EstimateTitle2 == target.EstimateTitle2)
                 && (this.EstimateTitle3 == target.EstimateTitle3)
                 && (this.EstimateTitle4 == target.EstimateTitle4)
                 && (this.EstimateTitle5 == target.EstimateTitle5)
                 && (this.EstimateNote1 == target.EstimateNote1)
                 && (this.EstimateNote2 == target.EstimateNote2)
                 && (this.EstimateNote3 == target.EstimateNote3)
                 && (this.EstimateNote4 == target.EstimateNote4)
                 && (this.EstimateNote5 == target.EstimateNote5)
                 && (this.EstimateValidityDate == target.EstimateValidityDate)
                 && (this.PartsNoPrtCd == target.PartsNoPrtCd)
                 && (this.OptionPringDivCd == target.OptionPringDivCd)
                 && (this.RateUseCode == target.RateUseCode)
                 && (this.InputMode == target.InputMode)
                 && (this.SalesSlipDisplay == target.SalesSlipDisplay)
                 && (this.AcptAnOdrStatusDisplay == target.AcptAnOdrStatusDisplay)
                 && (this.CustRateGrpCode == target.CustRateGrpCode)
                 && (this.ClaimName == target.ClaimName)
                 && (this.ClaimName2 == target.ClaimName2)
                 && (this.CreditMngCode == target.CreditMngCode)
                 && (this.TotalDay == target.TotalDay)
                 && (this.NTimeCalcStDate == target.NTimeCalcStDate)
                 && (this.TotalMoneyForGrossProfit == target.TotalMoneyForGrossProfit)
                 && (this.SectionName == target.SectionName)
                 && (this.SubSectionName == target.SubSectionName)
                 && (this.CarMngDivCd == target.CarMngDivCd)
                 && (this.SearchMode == target.SearchMode)
                 && (this.SearchCarMode == target.SearchCarMode)
                 && (this.SalesRate == target.SalesRate)
                 && (this.EstimateDtCreateDiv == target.EstimateDtCreateDiv)
                 && (this.CustOrderNoDispDiv == target.CustOrderNoDispDiv)
                 && (this.CustWarehouseCd == target.CustWarehouseCd)
                 && (this.TransStopDate == target.TransStopDate)
                //>>>2010/02/26
                 && (this.OnlineKindDiv == target.OnlineKindDiv)
                 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim())//@@@@20230303
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.AnswerDiv == target.AnswerDiv)
                 && (this.InquiryNumber == target.InquiryNumber)
                //<<<2010/02/26
                //>>>2010/04/08
                 && (this.InqOrdDivCd == target.InqOrdDivCd)
                //<<<2010/04/08
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.DetailRowCountForReadSlip == target.DetailRowCountForReadSlip) // ADD 2009/12/17
                 && (this.StockUpdateFlag == target.StockUpdateFlag) // ADD 2010/01/27
                 && (this.AutoAnswerDivSCM == target.AutoAnswerDivSCM) // add 2011/07/18 朱宝軍
                 && (this.ResultsAddUpSecNm == target.ResultsAddUpSecNm));
        }

        /// <summary>
        /// 売上データ比較処理
        /// </summary>
        /// <param name="salesSlip1">
        ///                    比較するSalesSlipクラスのインスタンス
        /// </param>
        /// <param name="salesSlip2">比較するSalesSlipクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SalesSlip salesSlip1, SalesSlip salesSlip2)
        {
            return ((salesSlip1.CreateDateTime == salesSlip2.CreateDateTime)
                 && (salesSlip1.UpdateDateTime == salesSlip2.UpdateDateTime)
                 && (salesSlip1.EnterpriseCode == salesSlip2.EnterpriseCode)
                 && (salesSlip1.FileHeaderGuid == salesSlip2.FileHeaderGuid)
                 && (salesSlip1.UpdEmployeeCode == salesSlip2.UpdEmployeeCode)
                 && (salesSlip1.UpdAssemblyId1 == salesSlip2.UpdAssemblyId1)
                 && (salesSlip1.UpdAssemblyId2 == salesSlip2.UpdAssemblyId2)
                 && (salesSlip1.LogicalDeleteCode == salesSlip2.LogicalDeleteCode)
                 && (salesSlip1.AcptAnOdrStatus == salesSlip2.AcptAnOdrStatus)
                 && (salesSlip1.SalesSlipNum == salesSlip2.SalesSlipNum)
                 && (salesSlip1.SectionCode == salesSlip2.SectionCode)
                 && (salesSlip1.SubSectionCode == salesSlip2.SubSectionCode)
                 && (salesSlip1.DebitNoteDiv == salesSlip2.DebitNoteDiv)
                 && (salesSlip1.DebitNLnkSalesSlNum == salesSlip2.DebitNLnkSalesSlNum)
                 && (salesSlip1.SalesSlipCd == salesSlip2.SalesSlipCd)
                 && (salesSlip1.SalesGoodsCd == salesSlip2.SalesGoodsCd)
                 && (salesSlip1.AccRecDivCd == salesSlip2.AccRecDivCd)
                 && (salesSlip1.SalesInpSecCd == salesSlip2.SalesInpSecCd)
                 && (salesSlip1.DemandAddUpSecCd == salesSlip2.DemandAddUpSecCd)
                 && (salesSlip1.ResultsAddUpSecCd == salesSlip2.ResultsAddUpSecCd)
                 && (salesSlip1.UpdateSecCd == salesSlip2.UpdateSecCd)
                 && (salesSlip1.SalesSlipUpdateCd == salesSlip2.SalesSlipUpdateCd)
                 && (salesSlip1.SearchSlipDate == salesSlip2.SearchSlipDate)
                 && (salesSlip1.ShipmentDay == salesSlip2.ShipmentDay)
                 && (salesSlip1.SalesDate == salesSlip2.SalesDate)
                 && (salesSlip1.PreSalesDate == salesSlip2.PreSalesDate) // ADD 2011/12/15
                 && (salesSlip1.AddUpADate == salesSlip2.AddUpADate)
                 && (salesSlip1.DelayPaymentDiv == salesSlip2.DelayPaymentDiv)
                 && (salesSlip1.EstimateFormNo == salesSlip2.EstimateFormNo)
                 && (salesSlip1.EstimateDivide == salesSlip2.EstimateDivide)
                 && (salesSlip1.InputAgenCd == salesSlip2.InputAgenCd)
                 && (salesSlip1.InputAgenNm == salesSlip2.InputAgenNm)
                 && (salesSlip1.SalesInputCode == salesSlip2.SalesInputCode)
                 && (salesSlip1.SalesInputName == salesSlip2.SalesInputName)
                 && (salesSlip1.FrontEmployeeCd == salesSlip2.FrontEmployeeCd)
                 && (salesSlip1.FrontEmployeeNm == salesSlip2.FrontEmployeeNm)
                 && (salesSlip1.SalesEmployeeCd == salesSlip2.SalesEmployeeCd)
                 && (salesSlip1.SalesEmployeeNm == salesSlip2.SalesEmployeeNm)
                 && (salesSlip1.TotalAmountDispWayCd == salesSlip2.TotalAmountDispWayCd)
                 && (salesSlip1.TtlAmntDispRateApy == salesSlip2.TtlAmntDispRateApy)
                 && (salesSlip1.SalesTotalTaxInc == salesSlip2.SalesTotalTaxInc)
                 && (salesSlip1.SalesTotalTaxExc == salesSlip2.SalesTotalTaxExc)
                 && (salesSlip1.SalesPrtTotalTaxInc == salesSlip2.SalesPrtTotalTaxInc)
                 && (salesSlip1.SalesPrtTotalTaxExc == salesSlip2.SalesPrtTotalTaxExc)
                 && (salesSlip1.SalesWorkTotalTaxInc == salesSlip2.SalesWorkTotalTaxInc)
                 && (salesSlip1.SalesWorkTotalTaxExc == salesSlip2.SalesWorkTotalTaxExc)
                 && (salesSlip1.SalesSubtotalTaxInc == salesSlip2.SalesSubtotalTaxInc)
                 && (salesSlip1.SalesSubtotalTaxExc == salesSlip2.SalesSubtotalTaxExc)
                 && (salesSlip1.SalesPrtSubttlInc == salesSlip2.SalesPrtSubttlInc)
                 && (salesSlip1.SalesPrtSubttlExc == salesSlip2.SalesPrtSubttlExc)
                 && (salesSlip1.SalesWorkSubttlInc == salesSlip2.SalesWorkSubttlInc)
                 && (salesSlip1.SalesWorkSubttlExc == salesSlip2.SalesWorkSubttlExc)
                 && (salesSlip1.SalesNetPrice == salesSlip2.SalesNetPrice)
                 && (salesSlip1.SalesSubtotalTax == salesSlip2.SalesSubtotalTax)
                 && (salesSlip1.ItdedSalesOutTax == salesSlip2.ItdedSalesOutTax)
                 && (salesSlip1.ItdedSalesInTax == salesSlip2.ItdedSalesInTax)
                 && (salesSlip1.SalSubttlSubToTaxFre == salesSlip2.SalSubttlSubToTaxFre)
                 && (salesSlip1.SalesOutTax == salesSlip2.SalesOutTax)
                 && (salesSlip1.SalAmntConsTaxInclu == salesSlip2.SalAmntConsTaxInclu)
                 && (salesSlip1.SalesDisTtlTaxExc == salesSlip2.SalesDisTtlTaxExc)
                 && (salesSlip1.ItdedSalesDisOutTax == salesSlip2.ItdedSalesDisOutTax)
                 && (salesSlip1.ItdedSalesDisInTax == salesSlip2.ItdedSalesDisInTax)
                 && (salesSlip1.ItdedPartsDisOutTax == salesSlip2.ItdedPartsDisOutTax)
                 && (salesSlip1.ItdedPartsDisInTax == salesSlip2.ItdedPartsDisInTax)
                 && (salesSlip1.ItdedWorkDisOutTax == salesSlip2.ItdedWorkDisOutTax)
                 && (salesSlip1.ItdedWorkDisInTax == salesSlip2.ItdedWorkDisInTax)
                 && (salesSlip1.ItdedSalesDisTaxFre == salesSlip2.ItdedSalesDisTaxFre)
                 && (salesSlip1.SalesDisOutTax == salesSlip2.SalesDisOutTax)
                 && (salesSlip1.SalesDisTtlTaxInclu == salesSlip2.SalesDisTtlTaxInclu)
                 && (salesSlip1.PartsDiscountRate == salesSlip2.PartsDiscountRate)
                 && (salesSlip1.RavorDiscountRate == salesSlip2.RavorDiscountRate)
                 && (salesSlip1.TotalCost == salesSlip2.TotalCost)
                 && (salesSlip1.ConsTaxLayMethod == salesSlip2.ConsTaxLayMethod)
                 && (salesSlip1.ConsTaxRate == salesSlip2.ConsTaxRate)
                 && (salesSlip1.FractionProcCd == salesSlip2.FractionProcCd)
                 && (salesSlip1.AccRecConsTax == salesSlip2.AccRecConsTax)
                 && (salesSlip1.AutoDepositCd == salesSlip2.AutoDepositCd)
                 && (salesSlip1.AutoDepositNoteDiv == salesSlip2.AutoDepositNoteDiv) // ADD 2013/01/18 田建委 Redmine#33797
                 && (salesSlip1.AutoDepositSlipNo == salesSlip2.AutoDepositSlipNo)
                 && (salesSlip1.DepositAllowanceTtl == salesSlip2.DepositAllowanceTtl)
                 && (salesSlip1.DepositAlwcBlnce == salesSlip2.DepositAlwcBlnce)
                 && (salesSlip1.ClaimCode == salesSlip2.ClaimCode)
                 && (salesSlip1.ClaimSnm == salesSlip2.ClaimSnm)
                 && (salesSlip1.CustomerCode == salesSlip2.CustomerCode)
                 && (salesSlip1.CustomerName == salesSlip2.CustomerName)
                 && (salesSlip1.CustomerName2 == salesSlip2.CustomerName2)
                 && (salesSlip1.CustomerSnm == salesSlip2.CustomerSnm)
                 && (salesSlip1.HonorificTitle == salesSlip2.HonorificTitle)
                 && (salesSlip1.OutputNameCode == salesSlip2.OutputNameCode)
                 && (salesSlip1.OutputName == salesSlip2.OutputName)
                 && (salesSlip1.CustSlipNo == salesSlip2.CustSlipNo)
                 && (salesSlip1.SlipAddressDiv == salesSlip2.SlipAddressDiv)
                 && (salesSlip1.AddresseeCode == salesSlip2.AddresseeCode)
                 && (salesSlip1.AddresseeName == salesSlip2.AddresseeName)
                 && (salesSlip1.AddresseeName2 == salesSlip2.AddresseeName2)
                 && (salesSlip1.AddresseePostNo == salesSlip2.AddresseePostNo)
                 && (salesSlip1.AddresseeAddr1 == salesSlip2.AddresseeAddr1)
                 && (salesSlip1.AddresseeAddr3 == salesSlip2.AddresseeAddr3)
                 && (salesSlip1.AddresseeAddr4 == salesSlip2.AddresseeAddr4)
                 && (salesSlip1.AddresseeTelNo == salesSlip2.AddresseeTelNo)
                 && (salesSlip1.AddresseeFaxNo == salesSlip2.AddresseeFaxNo)
                 && (salesSlip1.PartySaleSlipNum == salesSlip2.PartySaleSlipNum)
                 && (salesSlip1.CarSlipNote == salesSlip2.CarSlipNote)   // ADD 2009/09/08
                 && (salesSlip1.Mileage == salesSlip2.Mileage)   // ADD 2009/09/08
                 && (salesSlip1.SlipNote == salesSlip2.SlipNote)
                 && (salesSlip1.SlipNote2 == salesSlip2.SlipNote2)
                 && (salesSlip1.SlipNote3 == salesSlip2.SlipNote3)
                 // --- ADD 2009/12/23 ---------->>>>>
                 && (salesSlip1.SlipNoteCode == salesSlip2.SlipNoteCode)
                 && (salesSlip1.SlipNote2Code == salesSlip2.SlipNote2Code)
                 && (salesSlip1.SlipNote3Code == salesSlip2.SlipNote3Code)
                 // --- ADD 2009/12/23 ----------<<<<<
                 && (salesSlip1.RetGoodsReasonDiv == salesSlip2.RetGoodsReasonDiv)
                 && (salesSlip1.RetGoodsReason == salesSlip2.RetGoodsReason)
                 && (salesSlip1.RegiProcDate == salesSlip2.RegiProcDate)
                 && (salesSlip1.CashRegisterNo == salesSlip2.CashRegisterNo)
                 && (salesSlip1.PosReceiptNo == salesSlip2.PosReceiptNo)
                 && (salesSlip1.DetailRowCount == salesSlip2.DetailRowCount)
                 && (salesSlip1.EdiSendDate == salesSlip2.EdiSendDate)
                 && (salesSlip1.EdiTakeInDate == salesSlip2.EdiTakeInDate)
                 && (salesSlip1.UoeRemark1 == salesSlip2.UoeRemark1)
                 && (salesSlip1.UoeRemark2 == salesSlip2.UoeRemark2)
                 && (salesSlip1.SlipPrintDivCd == salesSlip2.SlipPrintDivCd)
                 && (salesSlip1.SlipPrintFinishCd == salesSlip2.SlipPrintFinishCd)
                 && (salesSlip1.SalesSlipPrintDate == salesSlip2.SalesSlipPrintDate)
                 && (salesSlip1.BusinessTypeCode == salesSlip2.BusinessTypeCode)
                 && (salesSlip1.BusinessTypeName == salesSlip2.BusinessTypeName)
                 && (salesSlip1.OrderNumber == salesSlip2.OrderNumber)
                 && (salesSlip1.DeliveredGoodsDiv == salesSlip2.DeliveredGoodsDiv)
                 && (salesSlip1.DeliveredGoodsDivNm == salesSlip2.DeliveredGoodsDivNm)
                 && (salesSlip1.SalesAreaCode == salesSlip2.SalesAreaCode)
                 && (salesSlip1.SalesAreaName == salesSlip2.SalesAreaName)
                 && (salesSlip1.ReconcileFlag == salesSlip2.ReconcileFlag)
                 && (salesSlip1.SlipPrtSetPaperId == salesSlip2.SlipPrtSetPaperId)
                 && (salesSlip1.CompleteCd == salesSlip2.CompleteCd)
                 && (salesSlip1.SalesPriceFracProcCd == salesSlip2.SalesPriceFracProcCd)
                 && (salesSlip1.StockGoodsTtlTaxExc == salesSlip2.StockGoodsTtlTaxExc)
                 && (salesSlip1.PureGoodsTtlTaxExc == salesSlip2.PureGoodsTtlTaxExc)
                 && (salesSlip1.ListPricePrintDiv == salesSlip2.ListPricePrintDiv)
                 && (salesSlip1.EraNameDispCd1 == salesSlip2.EraNameDispCd1)
                 && (salesSlip1.EstimaTaxDivCd == salesSlip2.EstimaTaxDivCd)
                 && (salesSlip1.EstimateFormPrtCd == salesSlip2.EstimateFormPrtCd)
                 && (salesSlip1.EstimateSubject == salesSlip2.EstimateSubject)
                 && (salesSlip1.Footnotes1 == salesSlip2.Footnotes1)
                 && (salesSlip1.Footnotes2 == salesSlip2.Footnotes2)
                 && (salesSlip1.EstimateTitle1 == salesSlip2.EstimateTitle1)
                 && (salesSlip1.EstimateTitle2 == salesSlip2.EstimateTitle2)
                 && (salesSlip1.EstimateTitle3 == salesSlip2.EstimateTitle3)
                 && (salesSlip1.EstimateTitle4 == salesSlip2.EstimateTitle4)
                 && (salesSlip1.EstimateTitle5 == salesSlip2.EstimateTitle5)
                 && (salesSlip1.EstimateNote1 == salesSlip2.EstimateNote1)
                 && (salesSlip1.EstimateNote2 == salesSlip2.EstimateNote2)
                 && (salesSlip1.EstimateNote3 == salesSlip2.EstimateNote3)
                 && (salesSlip1.EstimateNote4 == salesSlip2.EstimateNote4)
                 && (salesSlip1.EstimateNote5 == salesSlip2.EstimateNote5)
                 && (salesSlip1.EstimateValidityDate == salesSlip2.EstimateValidityDate)
                 && (salesSlip1.PartsNoPrtCd == salesSlip2.PartsNoPrtCd)
                 && (salesSlip1.OptionPringDivCd == salesSlip2.OptionPringDivCd)
                 && (salesSlip1.RateUseCode == salesSlip2.RateUseCode)
                 && (salesSlip1.InputMode == salesSlip2.InputMode)
                 && (salesSlip1.SalesSlipDisplay == salesSlip2.SalesSlipDisplay)
                 && (salesSlip1.AcptAnOdrStatusDisplay == salesSlip2.AcptAnOdrStatusDisplay)
                 && (salesSlip1.CustRateGrpCode == salesSlip2.CustRateGrpCode)
                 && (salesSlip1.ClaimName == salesSlip2.ClaimName)
                 && (salesSlip1.ClaimName2 == salesSlip2.ClaimName2)
                 && (salesSlip1.CreditMngCode == salesSlip2.CreditMngCode)
                 && (salesSlip1.TotalDay == salesSlip2.TotalDay)
                 && (salesSlip1.NTimeCalcStDate == salesSlip2.NTimeCalcStDate)
                 && (salesSlip1.TotalMoneyForGrossProfit == salesSlip2.TotalMoneyForGrossProfit)
                 && (salesSlip1.SectionName == salesSlip2.SectionName)
                 && (salesSlip1.SubSectionName == salesSlip2.SubSectionName)
                 && (salesSlip1.CarMngDivCd == salesSlip2.CarMngDivCd)
                 && (salesSlip1.SearchMode == salesSlip2.SearchMode)
                 && (salesSlip1.SearchCarMode == salesSlip2.SearchCarMode)
                 && (salesSlip1.SalesRate == salesSlip2.SalesRate)
                 && (salesSlip1.EstimateDtCreateDiv == salesSlip2.EstimateDtCreateDiv)
                 && (salesSlip1.CustOrderNoDispDiv == salesSlip2.CustOrderNoDispDiv)
                 && (salesSlip1.CustWarehouseCd == salesSlip2.CustWarehouseCd)
                 && (salesSlip1.TransStopDate == salesSlip2.TransStopDate)
                //>>>2010/02/26
                 && (salesSlip1.OnlineKindDiv == salesSlip2.OnlineKindDiv)
                 && (salesSlip1.InqOriginalEpCd.Trim() == salesSlip2.InqOriginalEpCd.Trim())//@@@@20230303
                 && (salesSlip1.InqOriginalSecCd == salesSlip2.InqOriginalSecCd)
                 && (salesSlip1.AnswerDiv == salesSlip2.AnswerDiv)
                 && (salesSlip1.InquiryNumber == salesSlip2.InquiryNumber)
                //<<<2010/02/26
                //>>>2010/04/08
                 && (salesSlip1.InqOrdDivCd == salesSlip2.InqOrdDivCd)
                //<<<2010/04/08
                 && (salesSlip1.EnterpriseName == salesSlip2.EnterpriseName)
                 && (salesSlip1.UpdEmployeeName == salesSlip2.UpdEmployeeName)
                 && (salesSlip1.DetailRowCountForReadSlip == salesSlip2.DetailRowCountForReadSlip) // ADD 2009/12/17
                 && (salesSlip1.StockUpdateFlag == salesSlip2.StockUpdateFlag) // ADD 2010/01/27
                 && (salesSlip1.AutoAnswerDivSCM == salesSlip2.AutoAnswerDivSCM) // add 2011/07/18 朱宝軍
                 && (salesSlip1.ResultsAddUpSecNm == salesSlip2.ResultsAddUpSecNm));
        }
        /// <summary>
        /// 売上データ比較処理
        /// </summary>
        /// <param name="target">比較対象のSalesSlipクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SalesSlip target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
            if (this.DebitNoteDiv != target.DebitNoteDiv) resList.Add("DebitNoteDiv");
            if (this.DebitNLnkSalesSlNum != target.DebitNLnkSalesSlNum) resList.Add("DebitNLnkSalesSlNum");
            if (this.SalesSlipCd != target.SalesSlipCd) resList.Add("SalesSlipCd");
            if (this.SalesGoodsCd != target.SalesGoodsCd) resList.Add("SalesGoodsCd");
            if (this.AccRecDivCd != target.AccRecDivCd) resList.Add("AccRecDivCd");
            if (this.SalesInpSecCd != target.SalesInpSecCd) resList.Add("SalesInpSecCd");
            if (this.DemandAddUpSecCd != target.DemandAddUpSecCd) resList.Add("DemandAddUpSecCd");
            if (this.ResultsAddUpSecCd != target.ResultsAddUpSecCd) resList.Add("ResultsAddUpSecCd");
            if (this.UpdateSecCd != target.UpdateSecCd) resList.Add("UpdateSecCd");
            if (this.SalesSlipUpdateCd != target.SalesSlipUpdateCd) resList.Add("SalesSlipUpdateCd");
            if (this.SearchSlipDate != target.SearchSlipDate) resList.Add("SearchSlipDate");
            if (this.ShipmentDay != target.ShipmentDay) resList.Add("ShipmentDay");
            if (this.SalesDate != target.SalesDate) resList.Add("SalesDate");
            if (this.PreSalesDate != target.PreSalesDate) resList.Add("PreSalesDate"); // ADD 2011/12/15
            if (this.AddUpADate != target.AddUpADate) resList.Add("AddUpADate");
            if (this.DelayPaymentDiv != target.DelayPaymentDiv) resList.Add("DelayPaymentDiv");
            if (this.EstimateFormNo != target.EstimateFormNo) resList.Add("EstimateFormNo");
            if (this.EstimateDivide != target.EstimateDivide) resList.Add("EstimateDivide");
            if (this.InputAgenCd != target.InputAgenCd) resList.Add("InputAgenCd");
            if (this.InputAgenNm != target.InputAgenNm) resList.Add("InputAgenNm");
            if (this.SalesInputCode != target.SalesInputCode) resList.Add("SalesInputCode");
            if (this.SalesInputName != target.SalesInputName) resList.Add("SalesInputName");
            if (this.FrontEmployeeCd != target.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (this.FrontEmployeeNm != target.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
            if (this.SalesEmployeeCd != target.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (this.SalesEmployeeNm != target.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (this.TtlAmntDispRateApy != target.TtlAmntDispRateApy) resList.Add("TtlAmntDispRateApy");
            if (this.SalesTotalTaxInc != target.SalesTotalTaxInc) resList.Add("SalesTotalTaxInc");
            if (this.SalesTotalTaxExc != target.SalesTotalTaxExc) resList.Add("SalesTotalTaxExc");
            if (this.SalesPrtTotalTaxInc != target.SalesPrtTotalTaxInc) resList.Add("SalesPrtTotalTaxInc");
            if (this.SalesPrtTotalTaxExc != target.SalesPrtTotalTaxExc) resList.Add("SalesPrtTotalTaxExc");
            if (this.SalesWorkTotalTaxInc != target.SalesWorkTotalTaxInc) resList.Add("SalesWorkTotalTaxInc");
            if (this.SalesWorkTotalTaxExc != target.SalesWorkTotalTaxExc) resList.Add("SalesWorkTotalTaxExc");
            if (this.SalesSubtotalTaxInc != target.SalesSubtotalTaxInc) resList.Add("SalesSubtotalTaxInc");
            if (this.SalesSubtotalTaxExc != target.SalesSubtotalTaxExc) resList.Add("SalesSubtotalTaxExc");
            if (this.SalesPrtSubttlInc != target.SalesPrtSubttlInc) resList.Add("SalesPrtSubttlInc");
            if (this.SalesPrtSubttlExc != target.SalesPrtSubttlExc) resList.Add("SalesPrtSubttlExc");
            if (this.SalesWorkSubttlInc != target.SalesWorkSubttlInc) resList.Add("SalesWorkSubttlInc");
            if (this.SalesWorkSubttlExc != target.SalesWorkSubttlExc) resList.Add("SalesWorkSubttlExc");
            if (this.SalesNetPrice != target.SalesNetPrice) resList.Add("SalesNetPrice");
            if (this.SalesSubtotalTax != target.SalesSubtotalTax) resList.Add("SalesSubtotalTax");
            if (this.ItdedSalesOutTax != target.ItdedSalesOutTax) resList.Add("ItdedSalesOutTax");
            if (this.ItdedSalesInTax != target.ItdedSalesInTax) resList.Add("ItdedSalesInTax");
            if (this.SalSubttlSubToTaxFre != target.SalSubttlSubToTaxFre) resList.Add("SalSubttlSubToTaxFre");
            if (this.SalesOutTax != target.SalesOutTax) resList.Add("SalesOutTax");
            if (this.SalAmntConsTaxInclu != target.SalAmntConsTaxInclu) resList.Add("SalAmntConsTaxInclu");
            if (this.SalesDisTtlTaxExc != target.SalesDisTtlTaxExc) resList.Add("SalesDisTtlTaxExc");
            if (this.ItdedSalesDisOutTax != target.ItdedSalesDisOutTax) resList.Add("ItdedSalesDisOutTax");
            if (this.ItdedSalesDisInTax != target.ItdedSalesDisInTax) resList.Add("ItdedSalesDisInTax");
            if (this.ItdedPartsDisOutTax != target.ItdedPartsDisOutTax) resList.Add("ItdedPartsDisOutTax");
            if (this.ItdedPartsDisInTax != target.ItdedPartsDisInTax) resList.Add("ItdedPartsDisInTax");
            if (this.ItdedWorkDisOutTax != target.ItdedWorkDisOutTax) resList.Add("ItdedWorkDisOutTax");
            if (this.ItdedWorkDisInTax != target.ItdedWorkDisInTax) resList.Add("ItdedWorkDisInTax");
            if (this.ItdedSalesDisTaxFre != target.ItdedSalesDisTaxFre) resList.Add("ItdedSalesDisTaxFre");
            if (this.SalesDisOutTax != target.SalesDisOutTax) resList.Add("SalesDisOutTax");
            if (this.SalesDisTtlTaxInclu != target.SalesDisTtlTaxInclu) resList.Add("SalesDisTtlTaxInclu");
            if (this.PartsDiscountRate != target.PartsDiscountRate) resList.Add("PartsDiscountRate");
            if (this.RavorDiscountRate != target.RavorDiscountRate) resList.Add("RavorDiscountRate");
            if (this.TotalCost != target.TotalCost) resList.Add("TotalCost");
            if (this.ConsTaxLayMethod != target.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (this.ConsTaxRate != target.ConsTaxRate) resList.Add("ConsTaxRate");
            if (this.FractionProcCd != target.FractionProcCd) resList.Add("FractionProcCd");
            if (this.AccRecConsTax != target.AccRecConsTax) resList.Add("AccRecConsTax");
            if (this.AutoDepositCd != target.AutoDepositCd) resList.Add("AutoDepositCd");
            if (this.AutoDepositNoteDiv != target.AutoDepositNoteDiv) resList.Add("AutoDepositNoteDiv"); // ADD 2013/01/18 田建委 Redmine#33797
            if (this.AutoDepositSlipNo != target.AutoDepositSlipNo) resList.Add("AutoDepositSlipNo");
            if (this.DepositAllowanceTtl != target.DepositAllowanceTtl) resList.Add("DepositAllowanceTtl");
            if (this.DepositAlwcBlnce != target.DepositAlwcBlnce) resList.Add("DepositAlwcBlnce");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.ClaimSnm != target.ClaimSnm) resList.Add("ClaimSnm");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.HonorificTitle != target.HonorificTitle) resList.Add("HonorificTitle");
            if (this.OutputNameCode != target.OutputNameCode) resList.Add("OutputNameCode");
            if (this.OutputName != target.OutputName) resList.Add("OutputName");
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
            if (this.CarSlipNote != target.CarSlipNote) resList.Add("CarSlipNote");   // ADD 2009/09/08
            if (this.Mileage != target.Mileage) resList.Add("Mileage");   // ADD 2009/09/08
            if (this.SlipNote != target.SlipNote) resList.Add("SlipNote");
            if (this.SlipNote2 != target.SlipNote2) resList.Add("SlipNote2");
            if (this.SlipNote3 != target.SlipNote3) resList.Add("SlipNote3");
            // --- ADD 2009/12/23 ---------->>>>>
            if (this.SlipNoteCode != target.SlipNoteCode) resList.Add("SlipNoteCode");
            if (this.SlipNote2Code != target.SlipNote2Code) resList.Add("SlipNote2Code");
            if (this.SlipNote3Code != target.SlipNote3Code) resList.Add("SlipNote3Code");
            // --- ADD 2009/12/23 ----------<<<<<
            if (this.RetGoodsReasonDiv != target.RetGoodsReasonDiv) resList.Add("RetGoodsReasonDiv");
            if (this.RetGoodsReason != target.RetGoodsReason) resList.Add("RetGoodsReason");
            if (this.RegiProcDate != target.RegiProcDate) resList.Add("RegiProcDate");
            if (this.CashRegisterNo != target.CashRegisterNo) resList.Add("CashRegisterNo");
            if (this.PosReceiptNo != target.PosReceiptNo) resList.Add("PosReceiptNo");
            if (this.DetailRowCount != target.DetailRowCount) resList.Add("DetailRowCount");
            if (this.EdiSendDate != target.EdiSendDate) resList.Add("EdiSendDate");
            if (this.EdiTakeInDate != target.EdiTakeInDate) resList.Add("EdiTakeInDate");
            if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
            if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
            if (this.SlipPrintDivCd != target.SlipPrintDivCd) resList.Add("SlipPrintDivCd");
            if (this.SlipPrintFinishCd != target.SlipPrintFinishCd) resList.Add("SlipPrintFinishCd");
            if (this.SalesSlipPrintDate != target.SalesSlipPrintDate) resList.Add("SalesSlipPrintDate");
            if (this.BusinessTypeCode != target.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (this.BusinessTypeName != target.BusinessTypeName) resList.Add("BusinessTypeName");
            if (this.OrderNumber != target.OrderNumber) resList.Add("OrderNumber");
            if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (this.DeliveredGoodsDivNm != target.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (this.SalesAreaCode != target.SalesAreaCode) resList.Add("SalesAreaCode");
            if (this.SalesAreaName != target.SalesAreaName) resList.Add("SalesAreaName");
            if (this.ReconcileFlag != target.ReconcileFlag) resList.Add("ReconcileFlag");
            if (this.SlipPrtSetPaperId != target.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
            if (this.CompleteCd != target.CompleteCd) resList.Add("CompleteCd");
            if (this.SalesPriceFracProcCd != target.SalesPriceFracProcCd) resList.Add("SalesPriceFracProcCd");
            if (this.StockGoodsTtlTaxExc != target.StockGoodsTtlTaxExc) resList.Add("StockGoodsTtlTaxExc");
            if (this.PureGoodsTtlTaxExc != target.PureGoodsTtlTaxExc) resList.Add("PureGoodsTtlTaxExc");
            if (this.ListPricePrintDiv != target.ListPricePrintDiv) resList.Add("ListPricePrintDiv");
            if (this.EraNameDispCd1 != target.EraNameDispCd1) resList.Add("EraNameDispCd1");
            if (this.EstimaTaxDivCd != target.EstimaTaxDivCd) resList.Add("EstimaTaxDivCd");
            if (this.EstimateFormPrtCd != target.EstimateFormPrtCd) resList.Add("EstimateFormPrtCd");
            if (this.EstimateSubject != target.EstimateSubject) resList.Add("EstimateSubject");
            if (this.Footnotes1 != target.Footnotes1) resList.Add("Footnotes1");
            if (this.Footnotes2 != target.Footnotes2) resList.Add("Footnotes2");
            if (this.EstimateTitle1 != target.EstimateTitle1) resList.Add("EstimateTitle1");
            if (this.EstimateTitle2 != target.EstimateTitle2) resList.Add("EstimateTitle2");
            if (this.EstimateTitle3 != target.EstimateTitle3) resList.Add("EstimateTitle3");
            if (this.EstimateTitle4 != target.EstimateTitle4) resList.Add("EstimateTitle4");
            if (this.EstimateTitle5 != target.EstimateTitle5) resList.Add("EstimateTitle5");
            if (this.EstimateNote1 != target.EstimateNote1) resList.Add("EstimateNote1");
            if (this.EstimateNote2 != target.EstimateNote2) resList.Add("EstimateNote2");
            if (this.EstimateNote3 != target.EstimateNote3) resList.Add("EstimateNote3");
            if (this.EstimateNote4 != target.EstimateNote4) resList.Add("EstimateNote4");
            if (this.EstimateNote5 != target.EstimateNote5) resList.Add("EstimateNote5");
            if (this.EstimateValidityDate != target.EstimateValidityDate) resList.Add("EstimateValidityDate");
            if (this.PartsNoPrtCd != target.PartsNoPrtCd) resList.Add("PartsNoPrtCd");
            if (this.OptionPringDivCd != target.OptionPringDivCd) resList.Add("OptionPringDivCd");
            if (this.RateUseCode != target.RateUseCode) resList.Add("RateUseCode");
            if (this.InputMode != target.InputMode) resList.Add("InputMode");
            if (this.SalesSlipDisplay != target.SalesSlipDisplay) resList.Add("SalesSlipDisplay");
            if (this.AcptAnOdrStatusDisplay != target.AcptAnOdrStatusDisplay) resList.Add("AcptAnOdrStatusDisplay");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.ClaimName != target.ClaimName) resList.Add("ClaimName");
            if (this.ClaimName2 != target.ClaimName2) resList.Add("ClaimName2");
            if (this.CreditMngCode != target.CreditMngCode) resList.Add("CreditMngCode");
            if (this.TotalDay != target.TotalDay) resList.Add("TotalDay");
            if (this.NTimeCalcStDate != target.NTimeCalcStDate) resList.Add("NTimeCalcStDate");
            if (this.TotalMoneyForGrossProfit != target.TotalMoneyForGrossProfit) resList.Add("TotalMoneyForGrossProfit");
            if (this.SectionName != target.SectionName) resList.Add("SectionName");
            if (this.SubSectionName != target.SubSectionName) resList.Add("SubSectionName");
            if (this.CarMngDivCd != target.CarMngDivCd) resList.Add("CarMngDivCd");
            if (this.SearchMode != target.SearchMode) resList.Add("SearchMode");
            if (this.SearchCarMode != target.SearchCarMode) resList.Add("SearchCarMode");
            if (this.SalesRate != target.SalesRate) resList.Add("SalesRate");
            if (this.EstimateDtCreateDiv != target.EstimateDtCreateDiv) resList.Add("EstimateDtCreateDiv");
            if (this.CustOrderNoDispDiv != target.CustOrderNoDispDiv) resList.Add("CustOrderNoDispDiv");
            if (this.CustWarehouseCd != target.CustWarehouseCd) resList.Add("CustWarehouseCd");
            if (this.TransStopDate != target.TransStopDate) resList.Add("TransStopDate");
            //>>>2010/02/26
            if (this.OnlineKindDiv != target.OnlineKindDiv) resList.Add("OnlineKindDiv");
            if (this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.AnswerDiv != target.AnswerDiv) resList.Add("AnswerDiv");
            if (this.InquiryNumber != target.InquiryNumber) resList.Add("InquiryNumber");
            //<<<2010/02/26
            //>>>2010/04/08
            if (this.InqOrdDivCd != target.InqOrdDivCd) resList.Add("InqOrdDivCd");
            //<<<2010/04/08
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.ResultsAddUpSecNm != target.ResultsAddUpSecNm) resList.Add("ResultsAddUpSecNm");
            if (this.DetailRowCountForReadSlip != target.DetailRowCountForReadSlip) resList.Add("DetailRowCountForReadSlip"); // ADD 2009/12/17
            if (this.StockUpdateFlag != target.StockUpdateFlag) resList.Add("StockUpdateFlag"); // ADD 2010/01/27
            if (this.AutoAnswerDivSCM != target.AutoAnswerDivSCM) resList.Add("AutoAnswerDivSCM"); // add 2011/07/18 朱宝軍
            return resList;
        }

        /// <summary>
        /// 売上データ比較処理
        /// </summary>
        /// <param name="salesSlip1">比較するSalesSlipクラスのインスタンス</param>
        /// <param name="salesSlip2">比較するSalesSlipクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SalesSlip salesSlip1, SalesSlip salesSlip2)
        {
            ArrayList resList = new ArrayList();
            if (salesSlip1.CreateDateTime != salesSlip2.CreateDateTime) resList.Add("CreateDateTime");
            if (salesSlip1.UpdateDateTime != salesSlip2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (salesSlip1.EnterpriseCode != salesSlip2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (salesSlip1.FileHeaderGuid != salesSlip2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (salesSlip1.UpdEmployeeCode != salesSlip2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (salesSlip1.UpdAssemblyId1 != salesSlip2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (salesSlip1.UpdAssemblyId2 != salesSlip2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (salesSlip1.LogicalDeleteCode != salesSlip2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (salesSlip1.AcptAnOdrStatus != salesSlip2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (salesSlip1.SalesSlipNum != salesSlip2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (salesSlip1.SectionCode != salesSlip2.SectionCode) resList.Add("SectionCode");
            if (salesSlip1.SubSectionCode != salesSlip2.SubSectionCode) resList.Add("SubSectionCode");
            if (salesSlip1.DebitNoteDiv != salesSlip2.DebitNoteDiv) resList.Add("DebitNoteDiv");
            if (salesSlip1.DebitNLnkSalesSlNum != salesSlip2.DebitNLnkSalesSlNum) resList.Add("DebitNLnkSalesSlNum");
            if (salesSlip1.SalesSlipCd != salesSlip2.SalesSlipCd) resList.Add("SalesSlipCd");
            if (salesSlip1.SalesGoodsCd != salesSlip2.SalesGoodsCd) resList.Add("SalesGoodsCd");
            if (salesSlip1.AccRecDivCd != salesSlip2.AccRecDivCd) resList.Add("AccRecDivCd");
            if (salesSlip1.SalesInpSecCd != salesSlip2.SalesInpSecCd) resList.Add("SalesInpSecCd");
            if (salesSlip1.DemandAddUpSecCd != salesSlip2.DemandAddUpSecCd) resList.Add("DemandAddUpSecCd");
            if (salesSlip1.ResultsAddUpSecCd != salesSlip2.ResultsAddUpSecCd) resList.Add("ResultsAddUpSecCd");
            if (salesSlip1.UpdateSecCd != salesSlip2.UpdateSecCd) resList.Add("UpdateSecCd");
            if (salesSlip1.SalesSlipUpdateCd != salesSlip2.SalesSlipUpdateCd) resList.Add("SalesSlipUpdateCd");
            if (salesSlip1.SearchSlipDate != salesSlip2.SearchSlipDate) resList.Add("SearchSlipDate");
            if (salesSlip1.ShipmentDay != salesSlip2.ShipmentDay) resList.Add("ShipmentDay");
            if (salesSlip1.SalesDate != salesSlip2.SalesDate) resList.Add("SalesDate");
            if (salesSlip1.PreSalesDate != salesSlip2.PreSalesDate) resList.Add("PreSalesDate"); // ADD 2011/12/15
            if (salesSlip1.AddUpADate != salesSlip2.AddUpADate) resList.Add("AddUpADate");
            if (salesSlip1.DelayPaymentDiv != salesSlip2.DelayPaymentDiv) resList.Add("DelayPaymentDiv");
            if (salesSlip1.EstimateFormNo != salesSlip2.EstimateFormNo) resList.Add("EstimateFormNo");
            if (salesSlip1.EstimateDivide != salesSlip2.EstimateDivide) resList.Add("EstimateDivide");
            if (salesSlip1.InputAgenCd != salesSlip2.InputAgenCd) resList.Add("InputAgenCd");
            if (salesSlip1.InputAgenNm != salesSlip2.InputAgenNm) resList.Add("InputAgenNm");
            if (salesSlip1.SalesInputCode != salesSlip2.SalesInputCode) resList.Add("SalesInputCode");
            if (salesSlip1.SalesInputName != salesSlip2.SalesInputName) resList.Add("SalesInputName");
            if (salesSlip1.FrontEmployeeCd != salesSlip2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (salesSlip1.FrontEmployeeNm != salesSlip2.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
            if (salesSlip1.SalesEmployeeCd != salesSlip2.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (salesSlip1.SalesEmployeeNm != salesSlip2.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (salesSlip1.TotalAmountDispWayCd != salesSlip2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (salesSlip1.TtlAmntDispRateApy != salesSlip2.TtlAmntDispRateApy) resList.Add("TtlAmntDispRateApy");
            if (salesSlip1.SalesTotalTaxInc != salesSlip2.SalesTotalTaxInc) resList.Add("SalesTotalTaxInc");
            if (salesSlip1.SalesTotalTaxExc != salesSlip2.SalesTotalTaxExc) resList.Add("SalesTotalTaxExc");
            if (salesSlip1.SalesPrtTotalTaxInc != salesSlip2.SalesPrtTotalTaxInc) resList.Add("SalesPrtTotalTaxInc");
            if (salesSlip1.SalesPrtTotalTaxExc != salesSlip2.SalesPrtTotalTaxExc) resList.Add("SalesPrtTotalTaxExc");
            if (salesSlip1.SalesWorkTotalTaxInc != salesSlip2.SalesWorkTotalTaxInc) resList.Add("SalesWorkTotalTaxInc");
            if (salesSlip1.SalesWorkTotalTaxExc != salesSlip2.SalesWorkTotalTaxExc) resList.Add("SalesWorkTotalTaxExc");
            if (salesSlip1.SalesSubtotalTaxInc != salesSlip2.SalesSubtotalTaxInc) resList.Add("SalesSubtotalTaxInc");
            if (salesSlip1.SalesSubtotalTaxExc != salesSlip2.SalesSubtotalTaxExc) resList.Add("SalesSubtotalTaxExc");
            if (salesSlip1.SalesPrtSubttlInc != salesSlip2.SalesPrtSubttlInc) resList.Add("SalesPrtSubttlInc");
            if (salesSlip1.SalesPrtSubttlExc != salesSlip2.SalesPrtSubttlExc) resList.Add("SalesPrtSubttlExc");
            if (salesSlip1.SalesWorkSubttlInc != salesSlip2.SalesWorkSubttlInc) resList.Add("SalesWorkSubttlInc");
            if (salesSlip1.SalesWorkSubttlExc != salesSlip2.SalesWorkSubttlExc) resList.Add("SalesWorkSubttlExc");
            if (salesSlip1.SalesNetPrice != salesSlip2.SalesNetPrice) resList.Add("SalesNetPrice");
            if (salesSlip1.SalesSubtotalTax != salesSlip2.SalesSubtotalTax) resList.Add("SalesSubtotalTax");
            if (salesSlip1.ItdedSalesOutTax != salesSlip2.ItdedSalesOutTax) resList.Add("ItdedSalesOutTax");
            if (salesSlip1.ItdedSalesInTax != salesSlip2.ItdedSalesInTax) resList.Add("ItdedSalesInTax");
            if (salesSlip1.SalSubttlSubToTaxFre != salesSlip2.SalSubttlSubToTaxFre) resList.Add("SalSubttlSubToTaxFre");
            if (salesSlip1.SalesOutTax != salesSlip2.SalesOutTax) resList.Add("SalesOutTax");
            if (salesSlip1.SalAmntConsTaxInclu != salesSlip2.SalAmntConsTaxInclu) resList.Add("SalAmntConsTaxInclu");
            if (salesSlip1.SalesDisTtlTaxExc != salesSlip2.SalesDisTtlTaxExc) resList.Add("SalesDisTtlTaxExc");
            if (salesSlip1.ItdedSalesDisOutTax != salesSlip2.ItdedSalesDisOutTax) resList.Add("ItdedSalesDisOutTax");
            if (salesSlip1.ItdedSalesDisInTax != salesSlip2.ItdedSalesDisInTax) resList.Add("ItdedSalesDisInTax");
            if (salesSlip1.ItdedPartsDisOutTax != salesSlip2.ItdedPartsDisOutTax) resList.Add("ItdedPartsDisOutTax");
            if (salesSlip1.ItdedPartsDisInTax != salesSlip2.ItdedPartsDisInTax) resList.Add("ItdedPartsDisInTax");
            if (salesSlip1.ItdedWorkDisOutTax != salesSlip2.ItdedWorkDisOutTax) resList.Add("ItdedWorkDisOutTax");
            if (salesSlip1.ItdedWorkDisInTax != salesSlip2.ItdedWorkDisInTax) resList.Add("ItdedWorkDisInTax");
            if (salesSlip1.ItdedSalesDisTaxFre != salesSlip2.ItdedSalesDisTaxFre) resList.Add("ItdedSalesDisTaxFre");
            if (salesSlip1.SalesDisOutTax != salesSlip2.SalesDisOutTax) resList.Add("SalesDisOutTax");
            if (salesSlip1.SalesDisTtlTaxInclu != salesSlip2.SalesDisTtlTaxInclu) resList.Add("SalesDisTtlTaxInclu");
            if (salesSlip1.PartsDiscountRate != salesSlip2.PartsDiscountRate) resList.Add("PartsDiscountRate");
            if (salesSlip1.RavorDiscountRate != salesSlip2.RavorDiscountRate) resList.Add("RavorDiscountRate");
            if (salesSlip1.TotalCost != salesSlip2.TotalCost) resList.Add("TotalCost");
            if (salesSlip1.ConsTaxLayMethod != salesSlip2.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (salesSlip1.ConsTaxRate != salesSlip2.ConsTaxRate) resList.Add("ConsTaxRate");
            if (salesSlip1.FractionProcCd != salesSlip2.FractionProcCd) resList.Add("FractionProcCd");
            if (salesSlip1.AccRecConsTax != salesSlip2.AccRecConsTax) resList.Add("AccRecConsTax");
            if (salesSlip1.AutoDepositCd != salesSlip2.AutoDepositCd) resList.Add("AutoDepositCd");
            if (salesSlip1.AutoDepositNoteDiv != salesSlip2.AutoDepositNoteDiv) resList.Add("AutoDepositNoteDiv"); // ADD 2013/01/18 田建委 Redmine#33797
            if (salesSlip1.AutoDepositSlipNo != salesSlip2.AutoDepositSlipNo) resList.Add("AutoDepositSlipNo");
            if (salesSlip1.DepositAllowanceTtl != salesSlip2.DepositAllowanceTtl) resList.Add("DepositAllowanceTtl");
            if (salesSlip1.DepositAlwcBlnce != salesSlip2.DepositAlwcBlnce) resList.Add("DepositAlwcBlnce");
            if (salesSlip1.ClaimCode != salesSlip2.ClaimCode) resList.Add("ClaimCode");
            if (salesSlip1.ClaimSnm != salesSlip2.ClaimSnm) resList.Add("ClaimSnm");
            if (salesSlip1.CustomerCode != salesSlip2.CustomerCode) resList.Add("CustomerCode");
            if (salesSlip1.CustomerName != salesSlip2.CustomerName) resList.Add("CustomerName");
            if (salesSlip1.CustomerName2 != salesSlip2.CustomerName2) resList.Add("CustomerName2");
            if (salesSlip1.CustomerSnm != salesSlip2.CustomerSnm) resList.Add("CustomerSnm");
            if (salesSlip1.HonorificTitle != salesSlip2.HonorificTitle) resList.Add("HonorificTitle");
            if (salesSlip1.OutputNameCode != salesSlip2.OutputNameCode) resList.Add("OutputNameCode");
            if (salesSlip1.OutputName != salesSlip2.OutputName) resList.Add("OutputName");
            if (salesSlip1.CustSlipNo != salesSlip2.CustSlipNo) resList.Add("CustSlipNo");
            if (salesSlip1.SlipAddressDiv != salesSlip2.SlipAddressDiv) resList.Add("SlipAddressDiv");
            if (salesSlip1.AddresseeCode != salesSlip2.AddresseeCode) resList.Add("AddresseeCode");
            if (salesSlip1.AddresseeName != salesSlip2.AddresseeName) resList.Add("AddresseeName");
            if (salesSlip1.AddresseeName2 != salesSlip2.AddresseeName2) resList.Add("AddresseeName2");
            if (salesSlip1.AddresseePostNo != salesSlip2.AddresseePostNo) resList.Add("AddresseePostNo");
            if (salesSlip1.AddresseeAddr1 != salesSlip2.AddresseeAddr1) resList.Add("AddresseeAddr1");
            if (salesSlip1.AddresseeAddr3 != salesSlip2.AddresseeAddr3) resList.Add("AddresseeAddr3");
            if (salesSlip1.AddresseeAddr4 != salesSlip2.AddresseeAddr4) resList.Add("AddresseeAddr4");
            if (salesSlip1.AddresseeTelNo != salesSlip2.AddresseeTelNo) resList.Add("AddresseeTelNo");
            if (salesSlip1.AddresseeFaxNo != salesSlip2.AddresseeFaxNo) resList.Add("AddresseeFaxNo");
            if (salesSlip1.PartySaleSlipNum != salesSlip2.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (salesSlip1.CarSlipNote != salesSlip2.CarSlipNote) resList.Add("CarSlipNote");   // ADD 2009/09/08
            if (salesSlip1.Mileage != salesSlip2.Mileage) resList.Add("Mileage");   // ADD 2009/09/08
            if (salesSlip1.SlipNote != salesSlip2.SlipNote) resList.Add("SlipNote");
            if (salesSlip1.SlipNote2 != salesSlip2.SlipNote2) resList.Add("SlipNote2");
            if (salesSlip1.SlipNote3 != salesSlip2.SlipNote3) resList.Add("SlipNote3");
            // --- ADD 2009/12/23 ---------->>>>>
            if (salesSlip1.SlipNoteCode != salesSlip2.SlipNoteCode) resList.Add("SlipNoteCode");
            if (salesSlip1.SlipNote2Code != salesSlip2.SlipNote2Code) resList.Add("SlipNote2Code");
            if (salesSlip1.SlipNote3Code != salesSlip2.SlipNote3Code) resList.Add("SlipNote3Code");
            // --- ADD 2009/12/23 ----------<<<<<
            if (salesSlip1.RetGoodsReasonDiv != salesSlip2.RetGoodsReasonDiv) resList.Add("RetGoodsReasonDiv");
            if (salesSlip1.RetGoodsReason != salesSlip2.RetGoodsReason) resList.Add("RetGoodsReason");
            if (salesSlip1.RegiProcDate != salesSlip2.RegiProcDate) resList.Add("RegiProcDate");
            if (salesSlip1.CashRegisterNo != salesSlip2.CashRegisterNo) resList.Add("CashRegisterNo");
            if (salesSlip1.PosReceiptNo != salesSlip2.PosReceiptNo) resList.Add("PosReceiptNo");
            if (salesSlip1.DetailRowCount != salesSlip2.DetailRowCount) resList.Add("DetailRowCount");
            if (salesSlip1.EdiSendDate != salesSlip2.EdiSendDate) resList.Add("EdiSendDate");
            if (salesSlip1.EdiTakeInDate != salesSlip2.EdiTakeInDate) resList.Add("EdiTakeInDate");
            if (salesSlip1.UoeRemark1 != salesSlip2.UoeRemark1) resList.Add("UoeRemark1");
            if (salesSlip1.UoeRemark2 != salesSlip2.UoeRemark2) resList.Add("UoeRemark2");
            if (salesSlip1.SlipPrintDivCd != salesSlip2.SlipPrintDivCd) resList.Add("SlipPrintDivCd");
            if (salesSlip1.SlipPrintFinishCd != salesSlip2.SlipPrintFinishCd) resList.Add("SlipPrintFinishCd");
            if (salesSlip1.SalesSlipPrintDate != salesSlip2.SalesSlipPrintDate) resList.Add("SalesSlipPrintDate");
            if (salesSlip1.BusinessTypeCode != salesSlip2.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (salesSlip1.BusinessTypeName != salesSlip2.BusinessTypeName) resList.Add("BusinessTypeName");
            if (salesSlip1.OrderNumber != salesSlip2.OrderNumber) resList.Add("OrderNumber");
            if (salesSlip1.DeliveredGoodsDiv != salesSlip2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (salesSlip1.DeliveredGoodsDivNm != salesSlip2.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (salesSlip1.SalesAreaCode != salesSlip2.SalesAreaCode) resList.Add("SalesAreaCode");
            if (salesSlip1.SalesAreaName != salesSlip2.SalesAreaName) resList.Add("SalesAreaName");
            if (salesSlip1.ReconcileFlag != salesSlip2.ReconcileFlag) resList.Add("ReconcileFlag");
            if (salesSlip1.SlipPrtSetPaperId != salesSlip2.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
            if (salesSlip1.CompleteCd != salesSlip2.CompleteCd) resList.Add("CompleteCd");
            if (salesSlip1.SalesPriceFracProcCd != salesSlip2.SalesPriceFracProcCd) resList.Add("SalesPriceFracProcCd");
            if (salesSlip1.StockGoodsTtlTaxExc != salesSlip2.StockGoodsTtlTaxExc) resList.Add("StockGoodsTtlTaxExc");
            if (salesSlip1.PureGoodsTtlTaxExc != salesSlip2.PureGoodsTtlTaxExc) resList.Add("PureGoodsTtlTaxExc");
            if (salesSlip1.ListPricePrintDiv != salesSlip2.ListPricePrintDiv) resList.Add("ListPricePrintDiv");
            if (salesSlip1.EraNameDispCd1 != salesSlip2.EraNameDispCd1) resList.Add("EraNameDispCd1");
            if (salesSlip1.EstimaTaxDivCd != salesSlip2.EstimaTaxDivCd) resList.Add("EstimaTaxDivCd");
            if (salesSlip1.EstimateFormPrtCd != salesSlip2.EstimateFormPrtCd) resList.Add("EstimateFormPrtCd");
            if (salesSlip1.EstimateSubject != salesSlip2.EstimateSubject) resList.Add("EstimateSubject");
            if (salesSlip1.Footnotes1 != salesSlip2.Footnotes1) resList.Add("Footnotes1");
            if (salesSlip1.Footnotes2 != salesSlip2.Footnotes2) resList.Add("Footnotes2");
            if (salesSlip1.EstimateTitle1 != salesSlip2.EstimateTitle1) resList.Add("EstimateTitle1");
            if (salesSlip1.EstimateTitle2 != salesSlip2.EstimateTitle2) resList.Add("EstimateTitle2");
            if (salesSlip1.EstimateTitle3 != salesSlip2.EstimateTitle3) resList.Add("EstimateTitle3");
            if (salesSlip1.EstimateTitle4 != salesSlip2.EstimateTitle4) resList.Add("EstimateTitle4");
            if (salesSlip1.EstimateTitle5 != salesSlip2.EstimateTitle5) resList.Add("EstimateTitle5");
            if (salesSlip1.EstimateNote1 != salesSlip2.EstimateNote1) resList.Add("EstimateNote1");
            if (salesSlip1.EstimateNote2 != salesSlip2.EstimateNote2) resList.Add("EstimateNote2");
            if (salesSlip1.EstimateNote3 != salesSlip2.EstimateNote3) resList.Add("EstimateNote3");
            if (salesSlip1.EstimateNote4 != salesSlip2.EstimateNote4) resList.Add("EstimateNote4");
            if (salesSlip1.EstimateNote5 != salesSlip2.EstimateNote5) resList.Add("EstimateNote5");
            if (salesSlip1.EstimateValidityDate != salesSlip2.EstimateValidityDate) resList.Add("EstimateValidityDate");
            if (salesSlip1.PartsNoPrtCd != salesSlip2.PartsNoPrtCd) resList.Add("PartsNoPrtCd");
            if (salesSlip1.OptionPringDivCd != salesSlip2.OptionPringDivCd) resList.Add("OptionPringDivCd");
            if (salesSlip1.RateUseCode != salesSlip2.RateUseCode) resList.Add("RateUseCode");
            if (salesSlip1.InputMode != salesSlip2.InputMode) resList.Add("InputMode");
            if (salesSlip1.SalesSlipDisplay != salesSlip2.SalesSlipDisplay) resList.Add("SalesSlipDisplay");
            if (salesSlip1.AcptAnOdrStatusDisplay != salesSlip2.AcptAnOdrStatusDisplay) resList.Add("AcptAnOdrStatusDisplay");
            if (salesSlip1.CustRateGrpCode != salesSlip2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (salesSlip1.ClaimName != salesSlip2.ClaimName) resList.Add("ClaimName");
            if (salesSlip1.ClaimName2 != salesSlip2.ClaimName2) resList.Add("ClaimName2");
            if (salesSlip1.CreditMngCode != salesSlip2.CreditMngCode) resList.Add("CreditMngCode");
            if (salesSlip1.TotalDay != salesSlip2.TotalDay) resList.Add("TotalDay");
            if (salesSlip1.NTimeCalcStDate != salesSlip2.NTimeCalcStDate) resList.Add("NTimeCalcStDate");
            if (salesSlip1.TotalMoneyForGrossProfit != salesSlip2.TotalMoneyForGrossProfit) resList.Add("TotalMoneyForGrossProfit");
            if (salesSlip1.SectionName != salesSlip2.SectionName) resList.Add("SectionName");
            if (salesSlip1.SubSectionName != salesSlip2.SubSectionName) resList.Add("SubSectionName");
            if (salesSlip1.CarMngDivCd != salesSlip2.CarMngDivCd) resList.Add("CarMngDivCd");
            if (salesSlip1.SearchMode != salesSlip2.SearchMode) resList.Add("SearchMode");
            if (salesSlip1.SearchCarMode != salesSlip2.SearchCarMode) resList.Add("SearchCarMode");
            if (salesSlip1.SalesRate != salesSlip2.SalesRate) resList.Add("SalesRate");
            if (salesSlip1.EstimateDtCreateDiv != salesSlip2.EstimateDtCreateDiv) resList.Add("EstimateDtCreateDiv");
            if (salesSlip1.CustOrderNoDispDiv != salesSlip2.CustOrderNoDispDiv) resList.Add("CustOrderNoDispDiv");
            if (salesSlip1.CustWarehouseCd != salesSlip2.CustWarehouseCd) resList.Add("CustWarehouseCd");
            if (salesSlip1.TransStopDate != salesSlip2.TransStopDate) resList.Add("TransStopDate");
            //<<<2010/02/26
            if (salesSlip1.OnlineKindDiv != salesSlip2.OnlineKindDiv) resList.Add("OnlineKindDiv");
            if (salesSlip1.InqOriginalEpCd.Trim() != salesSlip2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (salesSlip1.InqOriginalSecCd != salesSlip2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (salesSlip1.AnswerDiv != salesSlip2.AnswerDiv) resList.Add("AnswerDiv");
            if (salesSlip1.InquiryNumber != salesSlip2.InquiryNumber) resList.Add("InquiryNumber");
            //<<<2010/02/26
            //>>>2010/04/08
            if (salesSlip1.InqOrdDivCd != salesSlip2.InqOrdDivCd) resList.Add("InqOrdDivCd");
            //<<<2010/04/08
            if (salesSlip1.EnterpriseName != salesSlip2.EnterpriseName) resList.Add("EnterpriseName");
            if (salesSlip1.UpdEmployeeName != salesSlip2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (salesSlip1.ResultsAddUpSecNm != salesSlip2.ResultsAddUpSecNm) resList.Add("ResultsAddUpSecNm");
            if (salesSlip1.DetailRowCountForReadSlip != salesSlip2.DetailRowCountForReadSlip) resList.Add("DetailRowCountForReadSlip"); // ADD 2009/12/17
            if (salesSlip1.StockUpdateFlag != salesSlip2.StockUpdateFlag) resList.Add("StockUpdateFlag"); // ADD 2010/01/27
            if (salesSlip1.AutoAnswerDivSCM != salesSlip2.AutoAnswerDivSCM) resList.Add("AutoAnswerDivSCM"); // add 2011/07/18 朱宝軍
            return resList;
        }
    }
}
