using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
    # region // DEL
    ///// public class name:   SalesSlipSearchResult
    ///// <summary>
    /////                      売上伝票検索抽出結果
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   売上伝票検索抽出結果ヘッダファイル</br>
    ///// <br>Programmer       :   自動生成</br>
    ///// <br>Date             :   </br>
    ///// <br>Genarated Date   :   2008/07/09  (CSharp File Generated Date)</br>
    ///// <br>Update Note      :   </br>
    ///// </remarks>
    //public class SalesSlipSearchResult
    //{
    //    /// <summary>企業コード</summary>
    //    /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
    //    private string _enterpriseCode = "";

    //    /// <summary>論理削除区分</summary>
    //    /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
    //    private Int32 _logicalDeleteCode;

    //    /// <summary>受注ステータス</summary>
    //    /// <remarks>10:見積,20:受注,30:売上,40:出荷,70:指示書,80:クレーム,99:一時保管  </remarks>
    //    private Int32 _acptAnOdrStatus;

    //    /// <summary>売上伝票番号</summary>
    //    /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
    //    private string _salesSlipNum = "";

    //    /// <summary>拠点コード</summary>
    //    private string _sectionCode = "";

    //    /// <summary>拠点ガイド名称</summary>
    //    private string _sectionGuideNm = "";

    //    /// <summary>部門コード</summary>
    //    private Int32 _subSectionCode;

    //    /// <summary>部門名称</summary>
    //    private string _subSectionName = "";

    //    /// <summary>赤伝区分</summary>
    //    /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
    //    private Int32 _debitNoteDiv;

    //    /// <summary>赤黒連結売上伝票番号</summary>
    //    /// <remarks>赤黒の相手方売上伝票番号</remarks>
    //    private string _debitNLnkSalesSlNum = "";

    //    /// <summary>売上伝票区分</summary>
    //    /// <remarks>0:売上,1:返品</remarks>
    //    private Int32 _salesSlipCd;

    //    /// <summary>売上商品区分</summary>
    //    /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動)</remarks>
    //    private Int32 _salesGoodsCd;

    //    /// <summary>売掛区分</summary>
    //    /// <remarks>0:売掛なし,1:売掛</remarks>
    //    private Int32 _accRecDivCd;

    //    /// <summary>売上入力拠点コード</summary>
    //    /// <remarks>文字型 売上を入力した拠点コード</remarks>
    //    private string _salesInpSecCd = "";

    //    /// <summary>請求計上拠点コード</summary>
    //    /// <remarks>文字型</remarks>
    //    private string _demandAddUpSecCd = "";

    //    /// <summary>実績計上拠点コード</summary>
    //    /// <remarks>実績計上を行う企業内の拠点コード</remarks>
    //    private string _resultsAddUpSecCd = "";

    //    /// <summary>更新拠点コード</summary>
    //    /// <remarks>文字型 データの登録更新拠点</remarks>
    //    private string _updateSecCd = "";

    //    /// <summary>伝票検索日付</summary>
    //    /// <remarks>YYYYMMDD　（更新年月日）</remarks>
    //    private DateTime _searchSlipDate;

    //    /// <summary>出荷日付</summary>
    //    /// <remarks>YYYYMMDD</remarks>
    //    private DateTime _shipmentDay;

    //    /// <summary>売上日付</summary>
    //    /// <remarks>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</remarks>
    //    private DateTime _salesDate;

    //    /// <summary>計上日付</summary>
    //    /// <remarks>請求日　(YYYYMMDD)</remarks>
    //    private DateTime _addUpADate;

    //    /// <summary>来勘区分</summary>
    //    /// <remarks>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</remarks>
    //    private Int32 _delayPaymentDiv;

    //    /// <summary>見積書番号</summary>
    //    private string _estimateFormNo = "";

    //    /// <summary>見積区分</summary>
    //    /// <remarks>1:通常見積　2:単価見積　3:検索見積</remarks>
    //    private Int32 _estimateDivide;

    //    /// <summary>入力担当者コード</summary>
    //    /// <remarks>ログイン担当者（ＵＳＢ）</remarks>
    //    private string _inputAgenCd = "";

    //    /// <summary>入力担当者名称</summary>
    //    private string _inputAgenNm = "";

    //    /// <summary>売上入力者コード</summary>
    //    /// <remarks>入力担当者（発行者）</remarks>
    //    private string _salesInputCode = "";

    //    /// <summary>売上入力者名称</summary>
    //    private string _salesInputName = "";

    //    /// <summary>受付従業員コード</summary>
    //    /// <remarks>受付担当者（受注者）</remarks>
    //    private string _frontEmployeeCd = "";

    //    /// <summary>受付従業員名称</summary>
    //    private string _frontEmployeeNm = "";

    //    /// <summary>販売従業員コード</summary>
    //    /// <remarks>計上担当者（担当者）</remarks>
    //    private string _salesEmployeeCd = "";

    //    /// <summary>販売従業員名称</summary>
    //    private string _salesEmployeeNm = "";

    //    /// <summary>総額表示方法区分</summary>
    //    /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
    //    private Int32 _totalAmountDispWayCd;

    //    /// <summary>総額表示掛率適用区分</summary>
    //    /// <remarks>0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率</remarks>
    //    private Int32 _ttlAmntDispRateApy;

    //    /// <summary>売上伝票合計（税込み）</summary>
    //    /// <remarks>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</remarks>
    //    private Int64 _salesTotalTaxInc;

    //    /// <summary>売上伝票合計（税抜き）</summary>
    //    /// <remarks>売上正価金額＋売上値引金額計（税抜き）</remarks>
    //    private Int64 _salesTotalTaxExc;

    //    /// <summary>売上部品合計（税込み）</summary>
    //    /// <remarks>売上部品小計（税込み）＋部品値引対象額合計（税込み）</remarks>
    //    private Int64 _salesPrtTotalTaxInc;

    //    /// <summary>売上部品合計（税抜き）</summary>
    //    /// <remarks>売上部品小計（税抜き）＋部品値引対象額合計（税抜き）</remarks>
    //    private Int64 _salesPrtTotalTaxExc;

    //    /// <summary>売上作業合計（税込み）</summary>
    //    /// <remarks>売上作業小計（税込み）＋作業値引対象額合計（税込み）</remarks>
    //    private Int64 _salesWorkTotalTaxInc;

    //    /// <summary>売上作業合計（税抜き）</summary>
    //    /// <remarks>売上作業小計（税抜き）＋作業値引対象額合計（税抜き）</remarks>
    //    private Int64 _salesWorkTotalTaxExc;

    //    /// <summary>売上小計（税込み）</summary>
    //    /// <remarks>値引後の明細金額の合計（非課税含まず）</remarks>
    //    private Int64 _salesSubtotalTaxInc;

    //    /// <summary>売上小計（税抜き）</summary>
    //    /// <remarks>値引後の明細金額の合計（非課税含まず）</remarks>
    //    private Int64 _salesSubtotalTaxExc;

    //    /// <summary>売上部品小計（税込み）</summary>
    //    /// <remarks>部品明細金額の税込合計</remarks>
    //    private Int64 _salesPrtSubttlInc;

    //    /// <summary>売上部品小計（税抜き）</summary>
    //    /// <remarks>部品明細金額の税抜合計</remarks>
    //    private Int64 _salesPrtSubttlExc;

    //    /// <summary>売上作業小計（税込み）</summary>
    //    /// <remarks>作業明細金額の税込合計</remarks>
    //    private Int64 _salesWorkSubttlInc;

    //    /// <summary>売上作業小計（税抜き）</summary>
    //    /// <remarks>作業明細金額の税抜合計</remarks>
    //    private Int64 _salesWorkSubttlExc;

    //    /// <summary>売上正価金額</summary>
    //    /// <remarks>値引前の税抜売上金額（外税分、内税分、非課税分の合計）</remarks>
    //    private Int64 _salesNetPrice;

    //    /// <summary>売上小計（税）</summary>
    //    /// <remarks>外税対象金額の集計（税抜、値引含まず）</remarks>
    //    private Int64 _salesSubtotalTax;

    //    /// <summary>売上外税対象額</summary>
    //    /// <remarks>内税対象金額の集計（税抜、値引含まず） </remarks>
    //    private Int64 _itdedSalesOutTax;

    //    /// <summary>売上内税対象額</summary>
    //    /// <remarks>非課税対象金額の集計（値引含まず）</remarks>
    //    private Int64 _itdedSalesInTax;

    //    /// <summary>売上小計非課税対象額</summary>
    //    /// <remarks>売上金額消費税額（外税）+売上金額消費税額（内税）値引き含まず</remarks>
    //    private Int64 _salSubttlSubToTaxFre;

    //    /// <summary>売上金額消費税額（外税）</summary>
    //    /// <remarks>値引前の外税商品の消費税</remarks>
    //    private Int64 _salesOutTax;

    //    /// <summary>売上金額消費税額（内税）</summary>
    //    /// <remarks>値引前の内税商品の消費税</remarks>
    //    private Int64 _salAmntConsTaxInclu;

    //    /// <summary>売上値引金額計（税抜き）</summary>
    //    private Int64 _salesDisTtlTaxExc;

    //    /// <summary>売上値引外税対象額合計</summary>
    //    /// <remarks>外税商品値引の外税対象額（税抜）</remarks>
    //    private Int64 _itdedSalesDisOutTax;

    //    /// <summary>売上値引内税対象額合計</summary>
    //    /// <remarks>内税商品値引の内税対象額（税抜）</remarks>
    //    private Int64 _itdedSalesDisInTax;

    //    /// <summary>部品値引対象額合計（税抜き）</summary>
    //    /// <remarks>部品値引額（税抜き）</remarks>
    //    private Int64 _itdedPartsDisOutTax;

    //    /// <summary>部品値引対象額合計（税込み）</summary>
    //    /// <remarks>部品値引額（税込み）</remarks>
    //    private Int64 _itdedPartsDisInTax;

    //    /// <summary>作業値引対象額合計（税抜き）</summary>
    //    /// <remarks>作業値引額（税抜き）</remarks>
    //    private Int64 _itdedWorkDisOutTax;

    //    /// <summary>作業値引対象額合計（税込み）</summary>
    //    /// <remarks>作業値引額（税込み）</remarks>
    //    private Int64 _itdedWorkDisInTax;

    //    /// <summary>売上値引非課税対象額合計</summary>
    //    /// <remarks>非課税商品値引の非課税対象額</remarks>
    //    private Int64 _itdedSalesDisTaxFre;

    //    /// <summary>売上値引消費税額（外税）</summary>
    //    /// <remarks>外税商品値引の消費税額</remarks>
    //    private Int64 _salesDisOutTax;

    //    /// <summary>売上値引消費税額（内税）</summary>
    //    private Int64 _salesDisTtlTaxInclu;

    //    /// <summary>部品値引率</summary>
    //    /// <remarks>小計に対しての部品値引率</remarks>
    //    private Double _partsDiscountRate;

    //    /// <summary>工賃値引率</summary>
    //    /// <remarks>小計に対しての工賃値引率</remarks>
    //    private Double _ravorDiscountRate;

    //    /// <summary>原価金額計</summary>
    //    private Int64 _totalCost;

    //    /// <summary>消費税転嫁方式</summary>
    //    /// <remarks>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</remarks>
    //    private Int32 _consTaxLayMethod;

    //    /// <summary>消費税税率</summary>
    //    /// <remarks>変更2007/8/22(型,桁) 塩原</remarks>
    //    private Double _consTaxRate;

    //    /// <summary>端数処理区分</summary>
    //    /// <remarks>1:切捨て,2:四捨五入,3:切上げ　（消費税）</remarks>
    //    private Int32 _fractionProcCd;

    //    /// <summary>売掛消費税</summary>
    //    private Int64 _accRecConsTax;

    //    /// <summary>自動入金区分</summary>
    //    /// <remarks>0:通常入金,1:自動入金</remarks>
    //    private Int32 _autoDepositCd;

    //    /// <summary>自動入金伝票番号</summary>
    //    /// <remarks>自動入金時の入金伝票番号</remarks>
    //    private Int32 _autoDepositSlipNo;

    //    /// <summary>入金引当合計額</summary>
    //    /// <remarks>預り金引当合計額を含む</remarks>
    //    private Int64 _depositAllowanceTtl;

    //    /// <summary>入金引当残高</summary>
    //    private Int64 _depositAlwcBlnce;

    //    /// <summary>請求先コード</summary>
    //    private Int32 _claimCode;

    //    /// <summary>請求先略称</summary>
    //    private string _claimSnm = "";

    //    /// <summary>得意先コード</summary>
    //    private Int32 _customerCode;

    //    /// <summary>得意先名称</summary>
    //    private string _customerName = "";

    //    /// <summary>得意先名称2</summary>
    //    private string _customerName2 = "";

    //    /// <summary>得意先略称</summary>
    //    private string _customerSnm = "";

    //    /// <summary>敬称</summary>
    //    private string _honorificTitle = "";

    //    /// <summary>諸口名称</summary>
    //    private string _outputName = "";

    //    /// <summary>得意先伝票番号</summary>
    //    private Int32 _custSlipNo;

    //    /// <summary>伝票住所区分</summary>
    //    /// <remarks>1:得意先,2:納入先</remarks>
    //    private Int32 _slipAddressDiv;

    //    /// <summary>納品先コード</summary>
    //    private Int32 _addresseeCode;

    //    /// <summary>納品先名称</summary>
    //    private string _addresseeName = "";

    //    /// <summary>納品先名称2</summary>
    //    /// <remarks>追加(登録漏れ) 塩原</remarks>
    //    private string _addresseeName2 = "";

    //    /// <summary>納品先郵便番号</summary>
    //    /// <remarks>伝票住所区分に従う内容</remarks>
    //    private string _addresseePostNo = "";

    //    /// <summary>納品先住所1(都道府県市区郡・町村・字)</summary>
    //    /// <remarks>伝票住所区分に従う内容</remarks>
    //    private string _addresseeAddr1 = "";

    //    /// <summary>納品先住所3(番地)</summary>
    //    /// <remarks>伝票住所区分に従う内容</remarks>
    //    private string _addresseeAddr3 = "";

    //    /// <summary>納品先住所4(アパート名称)</summary>
    //    /// <remarks>伝票住所区分に従う内容</remarks>
    //    private string _addresseeAddr4 = "";

    //    /// <summary>納品先電話番号</summary>
    //    /// <remarks>伝票住所区分に従う内容</remarks>
    //    private string _addresseeTelNo = "";

    //    /// <summary>納品先FAX番号</summary>
    //    /// <remarks>伝票住所区分に従う内容</remarks>
    //    private string _addresseeFaxNo = "";

    //    /// <summary>相手先伝票番号</summary>
    //    /// <remarks>得意先注文番号（仮伝番号）</remarks>
    //    private string _partySaleSlipNum = "";

    //    /// <summary>伝票備考</summary>
    //    private string _slipNote = "";

    //    /// <summary>伝票備考２</summary>
    //    private string _slipNote2 = "";

    //    /// <summary>伝票備考３</summary>
    //    private string _slipNote3 = "";

    //    /// <summary>返品理由コード</summary>
    //    private Int32 _retGoodsReasonDiv;

    //    /// <summary>返品理由</summary>
    //    private string _retGoodsReason = "";

    //    /// <summary>レジ処理日</summary>
    //    /// <remarks>YYYYMMDD　（サーバー未接続時、売上伝票発行するための情報）</remarks>
    //    private DateTime _regiProcDate;

    //    /// <summary>レジ番号</summary>
    //    /// <remarks>　　　　　（サーバー未接続時、売上伝票発行するための情報）</remarks>
    //    private Int32 _cashRegisterNo;

    //    /// <summary>POSレシート番号</summary>
    //    /// <remarks>　　　　　（サーバー未接続時、売上伝票発行するための情報）</remarks>
    //    private Int32 _posReceiptNo;

    //    /// <summary>明細行数</summary>
    //    /// <remarks>伝票内の明細の行数（諸費用明細は除く）</remarks>
    //    private Int32 _detailRowCount;

    //    /// <summary>ＥＤＩ送信日</summary>
    //    /// <remarks>YYYYMMDD （ErectricDataInterface）</remarks>
    //    private DateTime _ediSendDate;

    //    /// <summary>ＥＤＩ取込日</summary>
    //    /// <remarks>YYYYMMDD</remarks>
    //    private DateTime _ediTakeInDate;

    //    /// <summary>ＵＯＥリマーク１</summary>
    //    /// <remarks>UserOrderEntory</remarks>
    //    private string _uoeRemark1 = "";

    //    /// <summary>ＵＯＥリマーク２</summary>
    //    private string _uoeRemark2 = "";

    //    /// <summary>伝票発行区分</summary>
    //    /// <remarks>0:しない 1:する</remarks>
    //    private Int32 _slipPrintDivCd;

    //    /// <summary>伝票発行済区分</summary>
    //    /// <remarks>0:未発行 1:発行済</remarks>
    //    private Int32 _slipPrintFinishCd;

    //    /// <summary>売上伝票発行日</summary>
    //    private DateTime _salesSlipPrintDate;

    //    /// <summary>業種コード</summary>
    //    private Int32 _businessTypeCode;

    //    /// <summary>業種名称</summary>
    //    private string _businessTypeName = "";

    //    /// <summary>発注番号</summary>
    //    /// <remarks>売上形式＝"受注"の時にセット</remarks>
    //    private string _orderNumber = "";

    //    /// <summary>納品区分</summary>
    //    /// <remarks>例) 1:配達,2:店頭渡し,3:直送,…</remarks>
    //    private Int32 _deliveredGoodsDiv;

    //    /// <summary>納品区分名称</summary>
    //    private string _deliveredGoodsDivNm = "";

    //    /// <summary>販売エリアコード</summary>
    //    /// <remarks>地区コード</remarks>
    //    private Int32 _salesAreaCode;

    //    /// <summary>販売エリア名称</summary>
    //    private string _salesAreaName = "";

    //    /// <summary>消込フラグ</summary>
    //    /// <remarks>0:残あり 9:残無し　（受注、出荷にて使用）</remarks>
    //    private Int32 _reconcileFlag;

    //    /// <summary>伝票印刷設定用帳票ID</summary>
    //    /// <remarks>売上形式とセットで伝票タイプ管理マスタを参照</remarks>
    //    private string _slipPrtSetPaperId = "";

    //    /// <summary>一式伝票区分</summary>
    //    /// <remarks>0:通常伝票,1:一式伝票</remarks>
    //    private Int32 _completeCd;

    //    /// <summary>売上金額端数処理区分</summary>
    //    /// <remarks>1:切捨て,2:四捨五入,3:切上げ　（売上明細データの金額用）</remarks>
    //    private Int32 _salesPriceFracProcCd;

    //    /// <summary>在庫商品合計金額（税抜）</summary>
    //    /// <remarks>在庫取寄区分が０の明細金額の集計</remarks>
    //    private Int64 _stockGoodsTtlTaxExc;

    //    /// <summary>純正商品合計金額（税抜）</summary>
    //    /// <remarks>商品属性が０の明細金額の集計</remarks>
    //    private Int64 _pureGoodsTtlTaxExc;

    //    /// <summary>定価印刷区分</summary>
    //    private Int32 _listPricePrintDiv;

    //    /// <summary>元号表示区分１</summary>
    //    /// <remarks>通常　　0:西暦　1:和暦</remarks>
    //    private Int32 _eraNameDispCd1;

    //    /// <summary>見積消費税区分</summary>
    //    /// <remarks>0:非表示 1:外税（明細）2:総額表示 3:外税（伝票）</remarks>
    //    private Int32 _estimaTaxDivCd;

    //    /// <summary>見積書印刷区分</summary>
    //    private Int32 _estimateFormPrtCd;

    //    /// <summary>見積件名</summary>
    //    private string _estimateSubject = "";

    //    /// <summary>脚注１</summary>
    //    private string _footnotes1 = "";

    //    /// <summary>脚注２</summary>
    //    private string _footnotes2 = "";

    //    /// <summary>見積タイトル１</summary>
    //    private string _estimateTitle1 = "";

    //    /// <summary>見積タイトル２</summary>
    //    private string _estimateTitle2 = "";

    //    /// <summary>見積タイトル３</summary>
    //    private string _estimateTitle3 = "";

    //    /// <summary>見積タイトル４</summary>
    //    private string _estimateTitle4 = "";

    //    /// <summary>見積タイトル５</summary>
    //    private string _estimateTitle5 = "";

    //    /// <summary>見積備考１</summary>
    //    private string _estimateNote1 = "";

    //    /// <summary>見積備考２</summary>
    //    private string _estimateNote2 = "";

    //    /// <summary>見積備考３</summary>
    //    private string _estimateNote3 = "";

    //    /// <summary>見積備考４</summary>
    //    private string _estimateNote4 = "";

    //    /// <summary>見積備考５</summary>
    //    private string _estimateNote5 = "";

    //    /// <summary>見積有効期限</summary>
    //    /// <remarks>YYYYMMDD</remarks>
    //    private DateTime _estimateValidityDate;

    //    /// <summary>品番印字区分</summary>
    //    /// <remarks>0:しない,1:する</remarks>
    //    private Int32 _partsNoPrtCd;

    //    /// <summary>オプション印字区分</summary>
    //    /// <remarks>0:しない,1:する</remarks>
    //    private Int32 _optionPringDivCd;

    //    /// <summary>掛率使用区分</summary>
    //    /// <remarks>0:売価＝定価 1:掛率指定,2:掛率設定</remarks>
    //    private Int32 _rateUseCode;

    //    /// <summary>車両管理番号</summary>
    //    /// <remarks>自動採番（無重複のシーケンス）PM7での車両SEQ</remarks>
    //    private String _carMngCode;

    //    /// <summary>型式指定番号</summary>
    //    private Int32 _modelDesignationNo;

    //    /// <summary>類別番号</summary>
    //    private Int32 _categoryNo;

    //    /// <summary>メーカー全角名称</summary>
    //    /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
    //    private string _makerFullName = "";

    //    /// <summary>型式（フル型）</summary>
    //    /// <remarks>フル型式(44桁用)</remarks>
    //    private string _fullModel = "";

    //    /// <summary>企業名称</summary>
    //    private string _enterpriseName = "";

    //    /// <summary>実績計上拠点名称</summary>
    //    private string _resultsAddUpSecNm = "";


    //    /// public propaty name  :  EnterpriseCode
    //    /// <summary>企業コードプロパティ</summary>
    //    /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   企業コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EnterpriseCode
    //    {
    //        get { return _enterpriseCode; }
    //        set { _enterpriseCode = value; }
    //    }

    //    /// public propaty name  :  LogicalDeleteCode
    //    /// <summary>論理削除区分プロパティ</summary>
    //    /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   論理削除区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 LogicalDeleteCode
    //    {
    //        get { return _logicalDeleteCode; }
    //        set { _logicalDeleteCode = value; }
    //    }

    //    /// public propaty name  :  AcptAnOdrStatus
    //    /// <summary>受注ステータスプロパティ</summary>
    //    /// <value>10:見積,20:受注,30:売上,40:出荷,70:指示書,80:クレーム,99:一時保管  </value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   受注ステータスプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 AcptAnOdrStatus
    //    {
    //        get { return _acptAnOdrStatus; }
    //        set { _acptAnOdrStatus = value; }
    //    }

    //    /// public propaty name  :  SalesSlipNum
    //    /// <summary>売上伝票番号プロパティ</summary>
    //    /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上伝票番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesSlipNum
    //    {
    //        get { return _salesSlipNum; }
    //        set { _salesSlipNum = value; }
    //    }

    //    /// public propaty name  :  SectionCode
    //    /// <summary>拠点コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   拠点コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SectionCode
    //    {
    //        get { return _sectionCode; }
    //        set { _sectionCode = value; }
    //    }

    //    /// public propaty name  :  SectionGuideNm
    //    /// <summary>拠点ガイド名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   拠点ガイド名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SectionGuideNm
    //    {
    //        get { return _sectionGuideNm; }
    //        set { _sectionGuideNm = value; }
    //    }

    //    /// public propaty name  :  SubSectionCode
    //    /// <summary>部門コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   部門コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SubSectionCode
    //    {
    //        get { return _subSectionCode; }
    //        set { _subSectionCode = value; }
    //    }

    //    /// public propaty name  :  SubSectionName
    //    /// <summary>部門名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   部門名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SubSectionName
    //    {
    //        get { return _subSectionName; }
    //        set { _subSectionName = value; }
    //    }

    //    /// public propaty name  :  DebitNoteDiv
    //    /// <summary>赤伝区分プロパティ</summary>
    //    /// <value>0:黒伝,1:赤伝,2:元黒</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   赤伝区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 DebitNoteDiv
    //    {
    //        get { return _debitNoteDiv; }
    //        set { _debitNoteDiv = value; }
    //    }

    //    /// public propaty name  :  DebitNLnkSalesSlNum
    //    /// <summary>赤黒連結売上伝票番号プロパティ</summary>
    //    /// <value>赤黒の相手方売上伝票番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   赤黒連結売上伝票番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string DebitNLnkSalesSlNum
    //    {
    //        get { return _debitNLnkSalesSlNum; }
    //        set { _debitNLnkSalesSlNum = value; }
    //    }

    //    /// public propaty name  :  SalesSlipCd
    //    /// <summary>売上伝票区分プロパティ</summary>
    //    /// <value>0:売上,1:返品</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上伝票区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SalesSlipCd
    //    {
    //        get { return _salesSlipCd; }
    //        set { _salesSlipCd = value; }
    //    }

    //    /// public propaty name  :  SalesGoodsCd
    //    /// <summary>売上商品区分プロパティ</summary>
    //    /// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上商品区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SalesGoodsCd
    //    {
    //        get { return _salesGoodsCd; }
    //        set { _salesGoodsCd = value; }
    //    }

    //    /// public propaty name  :  AccRecDivCd
    //    /// <summary>売掛区分プロパティ</summary>
    //    /// <value>0:売掛なし,1:売掛</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売掛区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 AccRecDivCd
    //    {
    //        get { return _accRecDivCd; }
    //        set { _accRecDivCd = value; }
    //    }

    //    /// public propaty name  :  SalesInpSecCd
    //    /// <summary>売上入力拠点コードプロパティ</summary>
    //    /// <value>文字型 売上を入力した拠点コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上入力拠点コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesInpSecCd
    //    {
    //        get { return _salesInpSecCd; }
    //        set { _salesInpSecCd = value; }
    //    }

    //    /// public propaty name  :  DemandAddUpSecCd
    //    /// <summary>請求計上拠点コードプロパティ</summary>
    //    /// <value>文字型</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   請求計上拠点コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string DemandAddUpSecCd
    //    {
    //        get { return _demandAddUpSecCd; }
    //        set { _demandAddUpSecCd = value; }
    //    }

    //    /// public propaty name  :  ResultsAddUpSecCd
    //    /// <summary>実績計上拠点コードプロパティ</summary>
    //    /// <value>実績計上を行う企業内の拠点コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   実績計上拠点コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string ResultsAddUpSecCd
    //    {
    //        get { return _resultsAddUpSecCd; }
    //        set { _resultsAddUpSecCd = value; }
    //    }

    //    /// public propaty name  :  UpdateSecCd
    //    /// <summary>更新拠点コードプロパティ</summary>
    //    /// <value>文字型 データの登録更新拠点</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   更新拠点コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string UpdateSecCd
    //    {
    //        get { return _updateSecCd; }
    //        set { _updateSecCd = value; }
    //    }

    //    /// public propaty name  :  SearchSlipDate
    //    /// <summary>伝票検索日付プロパティ</summary>
    //    /// <value>YYYYMMDD　（更新年月日）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票検索日付プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime SearchSlipDate
    //    {
    //        get { return _searchSlipDate; }
    //        set { _searchSlipDate = value; }
    //    }

    //    /// public propaty name  :  SearchSlipDateJpFormal
    //    /// <summary>伝票検索日付 和暦プロパティ</summary>
    //    /// <value>YYYYMMDD　（更新年月日）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票検索日付 和暦プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SearchSlipDateJpFormal
    //    {
    //        get { return TDateTime.DateTimeToString("GGYYMMDD", _searchSlipDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  SearchSlipDateJpInFormal
    //    /// <summary>伝票検索日付 和暦(略)プロパティ</summary>
    //    /// <value>YYYYMMDD　（更新年月日）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票検索日付 和暦(略)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SearchSlipDateJpInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("ggYY/MM/DD", _searchSlipDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  SearchSlipDateAdFormal
    //    /// <summary>伝票検索日付 西暦プロパティ</summary>
    //    /// <value>YYYYMMDD　（更新年月日）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票検索日付 西暦プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SearchSlipDateAdFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YYYY/MM/DD", _searchSlipDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  SearchSlipDateAdInFormal
    //    /// <summary>伝票検索日付 西暦(略)プロパティ</summary>
    //    /// <value>YYYYMMDD　（更新年月日）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票検索日付 西暦(略)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SearchSlipDateAdInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YY/MM/DD", _searchSlipDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  ShipmentDay
    //    /// <summary>出荷日付プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   出荷日付プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime ShipmentDay
    //    {
    //        get { return _shipmentDay; }
    //        set { _shipmentDay = value; }
    //    }

    //    /// public propaty name  :  ShipmentDayJpFormal
    //    /// <summary>出荷日付 和暦プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   出荷日付 和暦プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string ShipmentDayJpFormal
    //    {
    //        get { return TDateTime.DateTimeToString("GGYYMMDD", _shipmentDay); }
    //        set { }
    //    }

    //    /// public propaty name  :  ShipmentDayJpInFormal
    //    /// <summary>出荷日付 和暦(略)プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   出荷日付 和暦(略)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string ShipmentDayJpInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("ggYY/MM/DD", _shipmentDay); }
    //        set { }
    //    }

    //    /// public propaty name  :  ShipmentDayAdFormal
    //    /// <summary>出荷日付 西暦プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   出荷日付 西暦プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string ShipmentDayAdFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YYYY/MM/DD", _shipmentDay); }
    //        set { }
    //    }

    //    /// public propaty name  :  ShipmentDayAdInFormal
    //    /// <summary>出荷日付 西暦(略)プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   出荷日付 西暦(略)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string ShipmentDayAdInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YY/MM/DD", _shipmentDay); }
    //        set { }
    //    }

    //    /// public propaty name  :  SalesDate
    //    /// <summary>売上日付プロパティ</summary>
    //    /// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上日付プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime SalesDate
    //    {
    //        get { return _salesDate; }
    //        set { _salesDate = value; }
    //    }

    //    /// public propaty name  :  SalesDateJpFormal
    //    /// <summary>売上日付 和暦プロパティ</summary>
    //    /// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上日付 和暦プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesDateJpFormal
    //    {
    //        get { return TDateTime.DateTimeToString("GGYYMMDD", _salesDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  SalesDateJpInFormal
    //    /// <summary>売上日付 和暦(略)プロパティ</summary>
    //    /// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上日付 和暦(略)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesDateJpInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("ggYY/MM/DD", _salesDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  SalesDateAdFormal
    //    /// <summary>売上日付 西暦プロパティ</summary>
    //    /// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上日付 西暦プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesDateAdFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YYYY/MM/DD", _salesDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  SalesDateAdInFormal
    //    /// <summary>売上日付 西暦(略)プロパティ</summary>
    //    /// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上日付 西暦(略)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesDateAdInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YY/MM/DD", _salesDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  AddUpADate
    //    /// <summary>計上日付プロパティ</summary>
    //    /// <value>請求日　(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   計上日付プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime AddUpADate
    //    {
    //        get { return _addUpADate; }
    //        set { _addUpADate = value; }
    //    }

    //    /// public propaty name  :  AddUpADateJpFormal
    //    /// <summary>計上日付 和暦プロパティ</summary>
    //    /// <value>請求日　(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   計上日付 和暦プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string AddUpADateJpFormal
    //    {
    //        get { return TDateTime.DateTimeToString("GGYYMMDD", _addUpADate); }
    //        set { }
    //    }

    //    /// public propaty name  :  AddUpADateJpInFormal
    //    /// <summary>計上日付 和暦(略)プロパティ</summary>
    //    /// <value>請求日　(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   計上日付 和暦(略)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string AddUpADateJpInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpADate); }
    //        set { }
    //    }

    //    /// public propaty name  :  AddUpADateAdFormal
    //    /// <summary>計上日付 西暦プロパティ</summary>
    //    /// <value>請求日　(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   計上日付 西暦プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string AddUpADateAdFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpADate); }
    //        set { }
    //    }

    //    /// public propaty name  :  AddUpADateAdInFormal
    //    /// <summary>計上日付 西暦(略)プロパティ</summary>
    //    /// <value>請求日　(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   計上日付 西暦(略)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string AddUpADateAdInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YY/MM/DD", _addUpADate); }
    //        set { }
    //    }

    //    /// public propaty name  :  DelayPaymentDiv
    //    /// <summary>来勘区分プロパティ</summary>
    //    /// <value>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   来勘区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 DelayPaymentDiv
    //    {
    //        get { return _delayPaymentDiv; }
    //        set { _delayPaymentDiv = value; }
    //    }

    //    /// public propaty name  :  EstimateFormNo
    //    /// <summary>見積書番号プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積書番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EstimateFormNo
    //    {
    //        get { return _estimateFormNo; }
    //        set { _estimateFormNo = value; }
    //    }

    //    /// public propaty name  :  EstimateDivide
    //    /// <summary>見積区分プロパティ</summary>
    //    /// <value>1:通常見積　2:単価見積　3:検索見積</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 EstimateDivide
    //    {
    //        get { return _estimateDivide; }
    //        set { _estimateDivide = value; }
    //    }

    //    /// public propaty name  :  InputAgenCd
    //    /// <summary>入力担当者コードプロパティ</summary>
    //    /// <value>ログイン担当者（ＵＳＢ）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   入力担当者コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string InputAgenCd
    //    {
    //        get { return _inputAgenCd; }
    //        set { _inputAgenCd = value; }
    //    }

    //    /// public propaty name  :  InputAgenNm
    //    /// <summary>入力担当者名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   入力担当者名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string InputAgenNm
    //    {
    //        get { return _inputAgenNm; }
    //        set { _inputAgenNm = value; }
    //    }

    //    /// public propaty name  :  SalesInputCode
    //    /// <summary>売上入力者コードプロパティ</summary>
    //    /// <value>入力担当者（発行者）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上入力者コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesInputCode
    //    {
    //        get { return _salesInputCode; }
    //        set { _salesInputCode = value; }
    //    }

    //    /// public propaty name  :  SalesInputName
    //    /// <summary>売上入力者名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上入力者名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesInputName
    //    {
    //        get { return _salesInputName; }
    //        set { _salesInputName = value; }
    //    }

    //    /// public propaty name  :  FrontEmployeeCd
    //    /// <summary>受付従業員コードプロパティ</summary>
    //    /// <value>受付担当者（受注者）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   受付従業員コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string FrontEmployeeCd
    //    {
    //        get { return _frontEmployeeCd; }
    //        set { _frontEmployeeCd = value; }
    //    }

    //    /// public propaty name  :  FrontEmployeeNm
    //    /// <summary>受付従業員名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   受付従業員名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string FrontEmployeeNm
    //    {
    //        get { return _frontEmployeeNm; }
    //        set { _frontEmployeeNm = value; }
    //    }

    //    /// public propaty name  :  SalesEmployeeCd
    //    /// <summary>販売従業員コードプロパティ</summary>
    //    /// <value>計上担当者（担当者）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   販売従業員コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesEmployeeCd
    //    {
    //        get { return _salesEmployeeCd; }
    //        set { _salesEmployeeCd = value; }
    //    }

    //    /// public propaty name  :  SalesEmployeeNm
    //    /// <summary>販売従業員名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   販売従業員名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesEmployeeNm
    //    {
    //        get { return _salesEmployeeNm; }
    //        set { _salesEmployeeNm = value; }
    //    }

    //    /// public propaty name  :  TotalAmountDispWayCd
    //    /// <summary>総額表示方法区分プロパティ</summary>
    //    /// <value>0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   総額表示方法区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 TotalAmountDispWayCd
    //    {
    //        get { return _totalAmountDispWayCd; }
    //        set { _totalAmountDispWayCd = value; }
    //    }

    //    /// public propaty name  :  TtlAmntDispRateApy
    //    /// <summary>総額表示掛率適用区分プロパティ</summary>
    //    /// <value>0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   総額表示掛率適用区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 TtlAmntDispRateApy
    //    {
    //        get { return _ttlAmntDispRateApy; }
    //        set { _ttlAmntDispRateApy = value; }
    //    }

    //    /// public propaty name  :  SalesTotalTaxInc
    //    /// <summary>売上伝票合計（税込み）プロパティ</summary>
    //    /// <value>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上伝票合計（税込み）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesTotalTaxInc
    //    {
    //        get { return _salesTotalTaxInc; }
    //        set { _salesTotalTaxInc = value; }
    //    }

    //    /// public propaty name  :  SalesTotalTaxExc
    //    /// <summary>売上伝票合計（税抜き）プロパティ</summary>
    //    /// <value>売上正価金額＋売上値引金額計（税抜き）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上伝票合計（税抜き）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesTotalTaxExc
    //    {
    //        get { return _salesTotalTaxExc; }
    //        set { _salesTotalTaxExc = value; }
    //    }

    //    /// public propaty name  :  SalesPrtTotalTaxInc
    //    /// <summary>売上部品合計（税込み）プロパティ</summary>
    //    /// <value>売上部品小計（税込み）＋部品値引対象額合計（税込み）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上部品合計（税込み）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesPrtTotalTaxInc
    //    {
    //        get { return _salesPrtTotalTaxInc; }
    //        set { _salesPrtTotalTaxInc = value; }
    //    }

    //    /// public propaty name  :  SalesPrtTotalTaxExc
    //    /// <summary>売上部品合計（税抜き）プロパティ</summary>
    //    /// <value>売上部品小計（税抜き）＋部品値引対象額合計（税抜き）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上部品合計（税抜き）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesPrtTotalTaxExc
    //    {
    //        get { return _salesPrtTotalTaxExc; }
    //        set { _salesPrtTotalTaxExc = value; }
    //    }

    //    /// public propaty name  :  SalesWorkTotalTaxInc
    //    /// <summary>売上作業合計（税込み）プロパティ</summary>
    //    /// <value>売上作業小計（税込み）＋作業値引対象額合計（税込み）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上作業合計（税込み）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesWorkTotalTaxInc
    //    {
    //        get { return _salesWorkTotalTaxInc; }
    //        set { _salesWorkTotalTaxInc = value; }
    //    }

    //    /// public propaty name  :  SalesWorkTotalTaxExc
    //    /// <summary>売上作業合計（税抜き）プロパティ</summary>
    //    /// <value>売上作業小計（税抜き）＋作業値引対象額合計（税抜き）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上作業合計（税抜き）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesWorkTotalTaxExc
    //    {
    //        get { return _salesWorkTotalTaxExc; }
    //        set { _salesWorkTotalTaxExc = value; }
    //    }

    //    /// public propaty name  :  SalesSubtotalTaxInc
    //    /// <summary>売上小計（税込み）プロパティ</summary>
    //    /// <value>値引後の明細金額の合計（非課税含まず）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上小計（税込み）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesSubtotalTaxInc
    //    {
    //        get { return _salesSubtotalTaxInc; }
    //        set { _salesSubtotalTaxInc = value; }
    //    }

    //    /// public propaty name  :  SalesSubtotalTaxExc
    //    /// <summary>売上小計（税抜き）プロパティ</summary>
    //    /// <value>値引後の明細金額の合計（非課税含まず）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上小計（税抜き）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesSubtotalTaxExc
    //    {
    //        get { return _salesSubtotalTaxExc; }
    //        set { _salesSubtotalTaxExc = value; }
    //    }

    //    /// public propaty name  :  SalesPrtSubttlInc
    //    /// <summary>売上部品小計（税込み）プロパティ</summary>
    //    /// <value>部品明細金額の税込合計</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上部品小計（税込み）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesPrtSubttlInc
    //    {
    //        get { return _salesPrtSubttlInc; }
    //        set { _salesPrtSubttlInc = value; }
    //    }

    //    /// public propaty name  :  SalesPrtSubttlExc
    //    /// <summary>売上部品小計（税抜き）プロパティ</summary>
    //    /// <value>部品明細金額の税抜合計</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上部品小計（税抜き）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesPrtSubttlExc
    //    {
    //        get { return _salesPrtSubttlExc; }
    //        set { _salesPrtSubttlExc = value; }
    //    }

    //    /// public propaty name  :  SalesWorkSubttlInc
    //    /// <summary>売上作業小計（税込み）プロパティ</summary>
    //    /// <value>作業明細金額の税込合計</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上作業小計（税込み）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesWorkSubttlInc
    //    {
    //        get { return _salesWorkSubttlInc; }
    //        set { _salesWorkSubttlInc = value; }
    //    }

    //    /// public propaty name  :  SalesWorkSubttlExc
    //    /// <summary>売上作業小計（税抜き）プロパティ</summary>
    //    /// <value>作業明細金額の税抜合計</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上作業小計（税抜き）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesWorkSubttlExc
    //    {
    //        get { return _salesWorkSubttlExc; }
    //        set { _salesWorkSubttlExc = value; }
    //    }

    //    /// public propaty name  :  SalesNetPrice
    //    /// <summary>売上正価金額プロパティ</summary>
    //    /// <value>値引前の税抜売上金額（外税分、内税分、非課税分の合計）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上正価金額プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesNetPrice
    //    {
    //        get { return _salesNetPrice; }
    //        set { _salesNetPrice = value; }
    //    }

    //    /// public propaty name  :  SalesSubtotalTax
    //    /// <summary>売上小計（税）プロパティ</summary>
    //    /// <value>外税対象金額の集計（税抜、値引含まず）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上小計（税）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesSubtotalTax
    //    {
    //        get { return _salesSubtotalTax; }
    //        set { _salesSubtotalTax = value; }
    //    }

    //    /// public propaty name  :  ItdedSalesOutTax
    //    /// <summary>売上外税対象額プロパティ</summary>
    //    /// <value>内税対象金額の集計（税抜、値引含まず） </value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上外税対象額プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ItdedSalesOutTax
    //    {
    //        get { return _itdedSalesOutTax; }
    //        set { _itdedSalesOutTax = value; }
    //    }

    //    /// public propaty name  :  ItdedSalesInTax
    //    /// <summary>売上内税対象額プロパティ</summary>
    //    /// <value>非課税対象金額の集計（値引含まず）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上内税対象額プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ItdedSalesInTax
    //    {
    //        get { return _itdedSalesInTax; }
    //        set { _itdedSalesInTax = value; }
    //    }

    //    /// public propaty name  :  SalSubttlSubToTaxFre
    //    /// <summary>売上小計非課税対象額プロパティ</summary>
    //    /// <value>売上金額消費税額（外税）+売上金額消費税額（内税）値引き含まず</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上小計非課税対象額プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalSubttlSubToTaxFre
    //    {
    //        get { return _salSubttlSubToTaxFre; }
    //        set { _salSubttlSubToTaxFre = value; }
    //    }

    //    /// public propaty name  :  SalesOutTax
    //    /// <summary>売上金額消費税額（外税）プロパティ</summary>
    //    /// <value>値引前の外税商品の消費税</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上金額消費税額（外税）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesOutTax
    //    {
    //        get { return _salesOutTax; }
    //        set { _salesOutTax = value; }
    //    }

    //    /// public propaty name  :  SalAmntConsTaxInclu
    //    /// <summary>売上金額消費税額（内税）プロパティ</summary>
    //    /// <value>値引前の内税商品の消費税</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上金額消費税額（内税）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalAmntConsTaxInclu
    //    {
    //        get { return _salAmntConsTaxInclu; }
    //        set { _salAmntConsTaxInclu = value; }
    //    }

    //    /// public propaty name  :  SalesDisTtlTaxExc
    //    /// <summary>売上値引金額計（税抜き）プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上値引金額計（税抜き）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesDisTtlTaxExc
    //    {
    //        get { return _salesDisTtlTaxExc; }
    //        set { _salesDisTtlTaxExc = value; }
    //    }

    //    /// public propaty name  :  ItdedSalesDisOutTax
    //    /// <summary>売上値引外税対象額合計プロパティ</summary>
    //    /// <value>外税商品値引の外税対象額（税抜）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上値引外税対象額合計プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ItdedSalesDisOutTax
    //    {
    //        get { return _itdedSalesDisOutTax; }
    //        set { _itdedSalesDisOutTax = value; }
    //    }

    //    /// public propaty name  :  ItdedSalesDisInTax
    //    /// <summary>売上値引内税対象額合計プロパティ</summary>
    //    /// <value>内税商品値引の内税対象額（税抜）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上値引内税対象額合計プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ItdedSalesDisInTax
    //    {
    //        get { return _itdedSalesDisInTax; }
    //        set { _itdedSalesDisInTax = value; }
    //    }

    //    /// public propaty name  :  ItdedPartsDisOutTax
    //    /// <summary>部品値引対象額合計（税抜き）プロパティ</summary>
    //    /// <value>部品値引額（税抜き）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   部品値引対象額合計（税抜き）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ItdedPartsDisOutTax
    //    {
    //        get { return _itdedPartsDisOutTax; }
    //        set { _itdedPartsDisOutTax = value; }
    //    }

    //    /// public propaty name  :  ItdedPartsDisInTax
    //    /// <summary>部品値引対象額合計（税込み）プロパティ</summary>
    //    /// <value>部品値引額（税込み）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   部品値引対象額合計（税込み）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ItdedPartsDisInTax
    //    {
    //        get { return _itdedPartsDisInTax; }
    //        set { _itdedPartsDisInTax = value; }
    //    }

    //    /// public propaty name  :  ItdedWorkDisOutTax
    //    /// <summary>作業値引対象額合計（税抜き）プロパティ</summary>
    //    /// <value>作業値引額（税抜き）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   作業値引対象額合計（税抜き）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ItdedWorkDisOutTax
    //    {
    //        get { return _itdedWorkDisOutTax; }
    //        set { _itdedWorkDisOutTax = value; }
    //    }

    //    /// public propaty name  :  ItdedWorkDisInTax
    //    /// <summary>作業値引対象額合計（税込み）プロパティ</summary>
    //    /// <value>作業値引額（税込み）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   作業値引対象額合計（税込み）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ItdedWorkDisInTax
    //    {
    //        get { return _itdedWorkDisInTax; }
    //        set { _itdedWorkDisInTax = value; }
    //    }

    //    /// public propaty name  :  ItdedSalesDisTaxFre
    //    /// <summary>売上値引非課税対象額合計プロパティ</summary>
    //    /// <value>非課税商品値引の非課税対象額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上値引非課税対象額合計プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ItdedSalesDisTaxFre
    //    {
    //        get { return _itdedSalesDisTaxFre; }
    //        set { _itdedSalesDisTaxFre = value; }
    //    }

    //    /// public propaty name  :  SalesDisOutTax
    //    /// <summary>売上値引消費税額（外税）プロパティ</summary>
    //    /// <value>外税商品値引の消費税額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上値引消費税額（外税）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesDisOutTax
    //    {
    //        get { return _salesDisOutTax; }
    //        set { _salesDisOutTax = value; }
    //    }

    //    /// public propaty name  :  SalesDisTtlTaxInclu
    //    /// <summary>売上値引消費税額（内税）プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上値引消費税額（内税）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesDisTtlTaxInclu
    //    {
    //        get { return _salesDisTtlTaxInclu; }
    //        set { _salesDisTtlTaxInclu = value; }
    //    }

    //    /// public propaty name  :  PartsDiscountRate
    //    /// <summary>部品値引率プロパティ</summary>
    //    /// <value>小計に対しての部品値引率</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   部品値引率プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Double PartsDiscountRate
    //    {
    //        get { return _partsDiscountRate; }
    //        set { _partsDiscountRate = value; }
    //    }

    //    /// public propaty name  :  RavorDiscountRate
    //    /// <summary>工賃値引率プロパティ</summary>
    //    /// <value>小計に対しての工賃値引率</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   工賃値引率プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Double RavorDiscountRate
    //    {
    //        get { return _ravorDiscountRate; }
    //        set { _ravorDiscountRate = value; }
    //    }

    //    /// public propaty name  :  TotalCost
    //    /// <summary>原価金額計プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   原価金額計プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 TotalCost
    //    {
    //        get { return _totalCost; }
    //        set { _totalCost = value; }
    //    }

    //    /// public propaty name  :  ConsTaxLayMethod
    //    /// <summary>消費税転嫁方式プロパティ</summary>
    //    /// <value>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   消費税転嫁方式プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 ConsTaxLayMethod
    //    {
    //        get { return _consTaxLayMethod; }
    //        set { _consTaxLayMethod = value; }
    //    }

    //    /// public propaty name  :  ConsTaxRate
    //    /// <summary>消費税税率プロパティ</summary>
    //    /// <value>変更2007/8/22(型,桁) 塩原</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   消費税税率プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Double ConsTaxRate
    //    {
    //        get { return _consTaxRate; }
    //        set { _consTaxRate = value; }
    //    }

    //    /// public propaty name  :  FractionProcCd
    //    /// <summary>端数処理区分プロパティ</summary>
    //    /// <value>1:切捨て,2:四捨五入,3:切上げ　（消費税）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   端数処理区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 FractionProcCd
    //    {
    //        get { return _fractionProcCd; }
    //        set { _fractionProcCd = value; }
    //    }

    //    /// public propaty name  :  AccRecConsTax
    //    /// <summary>売掛消費税プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売掛消費税プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 AccRecConsTax
    //    {
    //        get { return _accRecConsTax; }
    //        set { _accRecConsTax = value; }
    //    }

    //    /// public propaty name  :  AutoDepositCd
    //    /// <summary>自動入金区分プロパティ</summary>
    //    /// <value>0:通常入金,1:自動入金</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   自動入金区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 AutoDepositCd
    //    {
    //        get { return _autoDepositCd; }
    //        set { _autoDepositCd = value; }
    //    }

    //    /// public propaty name  :  AutoDepositSlipNo
    //    /// <summary>自動入金伝票番号プロパティ</summary>
    //    /// <value>自動入金時の入金伝票番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   自動入金伝票番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 AutoDepositSlipNo
    //    {
    //        get { return _autoDepositSlipNo; }
    //        set { _autoDepositSlipNo = value; }
    //    }

    //    /// public propaty name  :  DepositAllowanceTtl
    //    /// <summary>入金引当合計額プロパティ</summary>
    //    /// <value>預り金引当合計額を含む</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   入金引当合計額プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 DepositAllowanceTtl
    //    {
    //        get { return _depositAllowanceTtl; }
    //        set { _depositAllowanceTtl = value; }
    //    }

    //    /// public propaty name  :  DepositAlwcBlnce
    //    /// <summary>入金引当残高プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   入金引当残高プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 DepositAlwcBlnce
    //    {
    //        get { return _depositAlwcBlnce; }
    //        set { _depositAlwcBlnce = value; }
    //    }

    //    /// public propaty name  :  ClaimCode
    //    /// <summary>請求先コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   請求先コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 ClaimCode
    //    {
    //        get { return _claimCode; }
    //        set { _claimCode = value; }
    //    }

    //    /// public propaty name  :  ClaimSnm
    //    /// <summary>請求先略称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   請求先略称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string ClaimSnm
    //    {
    //        get { return _claimSnm; }
    //        set { _claimSnm = value; }
    //    }

    //    /// public propaty name  :  CustomerCode
    //    /// <summary>得意先コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   得意先コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 CustomerCode
    //    {
    //        get { return _customerCode; }
    //        set { _customerCode = value; }
    //    }

    //    /// public propaty name  :  CustomerName
    //    /// <summary>得意先名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   得意先名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string CustomerName
    //    {
    //        get { return _customerName; }
    //        set { _customerName = value; }
    //    }

    //    /// public propaty name  :  CustomerName2
    //    /// <summary>得意先名称2プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   得意先名称2プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string CustomerName2
    //    {
    //        get { return _customerName2; }
    //        set { _customerName2 = value; }
    //    }

    //    /// public propaty name  :  CustomerSnm
    //    /// <summary>得意先略称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   得意先略称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string CustomerSnm
    //    {
    //        get { return _customerSnm; }
    //        set { _customerSnm = value; }
    //    }

    //    /// public propaty name  :  HonorificTitle
    //    /// <summary>敬称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   敬称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string HonorificTitle
    //    {
    //        get { return _honorificTitle; }
    //        set { _honorificTitle = value; }
    //    }

    //    /// public propaty name  :  OutputName
    //    /// <summary>諸口名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   諸口名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string OutputName
    //    {
    //        get { return _outputName; }
    //        set { _outputName = value; }
    //    }

    //    /// public propaty name  :  CustSlipNo
    //    /// <summary>得意先伝票番号プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   得意先伝票番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 CustSlipNo
    //    {
    //        get { return _custSlipNo; }
    //        set { _custSlipNo = value; }
    //    }

    //    /// public propaty name  :  SlipAddressDiv
    //    /// <summary>伝票住所区分プロパティ</summary>
    //    /// <value>1:得意先,2:納入先</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票住所区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SlipAddressDiv
    //    {
    //        get { return _slipAddressDiv; }
    //        set { _slipAddressDiv = value; }
    //    }

    //    /// public propaty name  :  AddresseeCode
    //    /// <summary>納品先コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   納品先コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 AddresseeCode
    //    {
    //        get { return _addresseeCode; }
    //        set { _addresseeCode = value; }
    //    }

    //    /// public propaty name  :  AddresseeName
    //    /// <summary>納品先名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   納品先名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string AddresseeName
    //    {
    //        get { return _addresseeName; }
    //        set { _addresseeName = value; }
    //    }

    //    /// public propaty name  :  AddresseeName2
    //    /// <summary>納品先名称2プロパティ</summary>
    //    /// <value>追加(登録漏れ) 塩原</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   納品先名称2プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string AddresseeName2
    //    {
    //        get { return _addresseeName2; }
    //        set { _addresseeName2 = value; }
    //    }

    //    /// public propaty name  :  AddresseePostNo
    //    /// <summary>納品先郵便番号プロパティ</summary>
    //    /// <value>伝票住所区分に従う内容</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   納品先郵便番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string AddresseePostNo
    //    {
    //        get { return _addresseePostNo; }
    //        set { _addresseePostNo = value; }
    //    }

    //    /// public propaty name  :  AddresseeAddr1
    //    /// <summary>納品先住所1(都道府県市区郡・町村・字)プロパティ</summary>
    //    /// <value>伝票住所区分に従う内容</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   納品先住所1(都道府県市区郡・町村・字)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string AddresseeAddr1
    //    {
    //        get { return _addresseeAddr1; }
    //        set { _addresseeAddr1 = value; }
    //    }

    //    /// public propaty name  :  AddresseeAddr3
    //    /// <summary>納品先住所3(番地)プロパティ</summary>
    //    /// <value>伝票住所区分に従う内容</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   納品先住所3(番地)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string AddresseeAddr3
    //    {
    //        get { return _addresseeAddr3; }
    //        set { _addresseeAddr3 = value; }
    //    }

    //    /// public propaty name  :  AddresseeAddr4
    //    /// <summary>納品先住所4(アパート名称)プロパティ</summary>
    //    /// <value>伝票住所区分に従う内容</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   納品先住所4(アパート名称)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string AddresseeAddr4
    //    {
    //        get { return _addresseeAddr4; }
    //        set { _addresseeAddr4 = value; }
    //    }

    //    /// public propaty name  :  AddresseeTelNo
    //    /// <summary>納品先電話番号プロパティ</summary>
    //    /// <value>伝票住所区分に従う内容</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   納品先電話番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string AddresseeTelNo
    //    {
    //        get { return _addresseeTelNo; }
    //        set { _addresseeTelNo = value; }
    //    }

    //    /// public propaty name  :  AddresseeFaxNo
    //    /// <summary>納品先FAX番号プロパティ</summary>
    //    /// <value>伝票住所区分に従う内容</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   納品先FAX番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string AddresseeFaxNo
    //    {
    //        get { return _addresseeFaxNo; }
    //        set { _addresseeFaxNo = value; }
    //    }

    //    /// public propaty name  :  PartySaleSlipNum
    //    /// <summary>相手先伝票番号プロパティ</summary>
    //    /// <value>得意先注文番号（仮伝番号）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   相手先伝票番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string PartySaleSlipNum
    //    {
    //        get { return _partySaleSlipNum; }
    //        set { _partySaleSlipNum = value; }
    //    }

    //    /// public propaty name  :  SlipNote
    //    /// <summary>伝票備考プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票備考プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SlipNote
    //    {
    //        get { return _slipNote; }
    //        set { _slipNote = value; }
    //    }

    //    /// public propaty name  :  SlipNote2
    //    /// <summary>伝票備考２プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票備考２プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SlipNote2
    //    {
    //        get { return _slipNote2; }
    //        set { _slipNote2 = value; }
    //    }

    //    /// public propaty name  :  SlipNote3
    //    /// <summary>伝票備考３プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票備考３プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SlipNote3
    //    {
    //        get { return _slipNote3; }
    //        set { _slipNote3 = value; }
    //    }

    //    /// public propaty name  :  RetGoodsReasonDiv
    //    /// <summary>返品理由コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   返品理由コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 RetGoodsReasonDiv
    //    {
    //        get { return _retGoodsReasonDiv; }
    //        set { _retGoodsReasonDiv = value; }
    //    }

    //    /// public propaty name  :  RetGoodsReason
    //    /// <summary>返品理由プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   返品理由プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string RetGoodsReason
    //    {
    //        get { return _retGoodsReason; }
    //        set { _retGoodsReason = value; }
    //    }

    //    /// public propaty name  :  RegiProcDate
    //    /// <summary>レジ処理日プロパティ</summary>
    //    /// <value>YYYYMMDD　（サーバー未接続時、売上伝票発行するための情報）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   レジ処理日プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime RegiProcDate
    //    {
    //        get { return _regiProcDate; }
    //        set { _regiProcDate = value; }
    //    }

    //    /// public propaty name  :  RegiProcDateJpFormal
    //    /// <summary>レジ処理日 和暦プロパティ</summary>
    //    /// <value>YYYYMMDD　（サーバー未接続時、売上伝票発行するための情報）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   レジ処理日 和暦プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string RegiProcDateJpFormal
    //    {
    //        get { return TDateTime.DateTimeToString("GGYYMMDD", _regiProcDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  RegiProcDateJpInFormal
    //    /// <summary>レジ処理日 和暦(略)プロパティ</summary>
    //    /// <value>YYYYMMDD　（サーバー未接続時、売上伝票発行するための情報）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   レジ処理日 和暦(略)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string RegiProcDateJpInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("ggYY/MM/DD", _regiProcDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  RegiProcDateAdFormal
    //    /// <summary>レジ処理日 西暦プロパティ</summary>
    //    /// <value>YYYYMMDD　（サーバー未接続時、売上伝票発行するための情報）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   レジ処理日 西暦プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string RegiProcDateAdFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YYYY/MM/DD", _regiProcDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  RegiProcDateAdInFormal
    //    /// <summary>レジ処理日 西暦(略)プロパティ</summary>
    //    /// <value>YYYYMMDD　（サーバー未接続時、売上伝票発行するための情報）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   レジ処理日 西暦(略)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string RegiProcDateAdInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YY/MM/DD", _regiProcDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  CashRegisterNo
    //    /// <summary>レジ番号プロパティ</summary>
    //    /// <value>　　　　　（サーバー未接続時、売上伝票発行するための情報）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   レジ番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 CashRegisterNo
    //    {
    //        get { return _cashRegisterNo; }
    //        set { _cashRegisterNo = value; }
    //    }

    //    /// public propaty name  :  PosReceiptNo
    //    /// <summary>POSレシート番号プロパティ</summary>
    //    /// <value>　　　　　（サーバー未接続時、売上伝票発行するための情報）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   POSレシート番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 PosReceiptNo
    //    {
    //        get { return _posReceiptNo; }
    //        set { _posReceiptNo = value; }
    //    }

    //    /// public propaty name  :  DetailRowCount
    //    /// <summary>明細行数プロパティ</summary>
    //    /// <value>伝票内の明細の行数（諸費用明細は除く）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   明細行数プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 DetailRowCount
    //    {
    //        get { return _detailRowCount; }
    //        set { _detailRowCount = value; }
    //    }

    //    /// public propaty name  :  EdiSendDate
    //    /// <summary>ＥＤＩ送信日プロパティ</summary>
    //    /// <value>YYYYMMDD （ErectricDataInterface）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＥＤＩ送信日プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime EdiSendDate
    //    {
    //        get { return _ediSendDate; }
    //        set { _ediSendDate = value; }
    //    }

    //    /// public propaty name  :  EdiSendDateJpFormal
    //    /// <summary>ＥＤＩ送信日 和暦プロパティ</summary>
    //    /// <value>YYYYMMDD （ErectricDataInterface）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＥＤＩ送信日 和暦プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EdiSendDateJpFormal
    //    {
    //        get { return TDateTime.DateTimeToString("GGYYMMDD", _ediSendDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EdiSendDateJpInFormal
    //    /// <summary>ＥＤＩ送信日 和暦(略)プロパティ</summary>
    //    /// <value>YYYYMMDD （ErectricDataInterface）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＥＤＩ送信日 和暦(略)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EdiSendDateJpInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("ggYY/MM/DD", _ediSendDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EdiSendDateAdFormal
    //    /// <summary>ＥＤＩ送信日 西暦プロパティ</summary>
    //    /// <value>YYYYMMDD （ErectricDataInterface）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＥＤＩ送信日 西暦プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EdiSendDateAdFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YYYY/MM/DD", _ediSendDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EdiSendDateAdInFormal
    //    /// <summary>ＥＤＩ送信日 西暦(略)プロパティ</summary>
    //    /// <value>YYYYMMDD （ErectricDataInterface）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＥＤＩ送信日 西暦(略)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EdiSendDateAdInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YY/MM/DD", _ediSendDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EdiTakeInDate
    //    /// <summary>ＥＤＩ取込日プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＥＤＩ取込日プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime EdiTakeInDate
    //    {
    //        get { return _ediTakeInDate; }
    //        set { _ediTakeInDate = value; }
    //    }

    //    /// public propaty name  :  EdiTakeInDateJpFormal
    //    /// <summary>ＥＤＩ取込日 和暦プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＥＤＩ取込日 和暦プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EdiTakeInDateJpFormal
    //    {
    //        get { return TDateTime.DateTimeToString("GGYYMMDD", _ediTakeInDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EdiTakeInDateJpInFormal
    //    /// <summary>ＥＤＩ取込日 和暦(略)プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＥＤＩ取込日 和暦(略)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EdiTakeInDateJpInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("ggYY/MM/DD", _ediTakeInDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EdiTakeInDateAdFormal
    //    /// <summary>ＥＤＩ取込日 西暦プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＥＤＩ取込日 西暦プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EdiTakeInDateAdFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YYYY/MM/DD", _ediTakeInDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EdiTakeInDateAdInFormal
    //    /// <summary>ＥＤＩ取込日 西暦(略)プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＥＤＩ取込日 西暦(略)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EdiTakeInDateAdInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YY/MM/DD", _ediTakeInDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  UoeRemark1
    //    /// <summary>ＵＯＥリマーク１プロパティ</summary>
    //    /// <value>UserOrderEntory</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＵＯＥリマーク１プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string UoeRemark1
    //    {
    //        get { return _uoeRemark1; }
    //        set { _uoeRemark1 = value; }
    //    }

    //    /// public propaty name  :  UoeRemark2
    //    /// <summary>ＵＯＥリマーク２プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＵＯＥリマーク２プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string UoeRemark2
    //    {
    //        get { return _uoeRemark2; }
    //        set { _uoeRemark2 = value; }
    //    }

    //    /// public propaty name  :  SlipPrintDivCd
    //    /// <summary>伝票発行区分プロパティ</summary>
    //    /// <value>0:しない 1:する</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票発行区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SlipPrintDivCd
    //    {
    //        get { return _slipPrintDivCd; }
    //        set { _slipPrintDivCd = value; }
    //    }

    //    /// public propaty name  :  SlipPrintFinishCd
    //    /// <summary>伝票発行済区分プロパティ</summary>
    //    /// <value>0:未発行 1:発行済</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票発行済区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SlipPrintFinishCd
    //    {
    //        get { return _slipPrintFinishCd; }
    //        set { _slipPrintFinishCd = value; }
    //    }

    //    /// public propaty name  :  SalesSlipPrintDate
    //    /// <summary>売上伝票発行日プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上伝票発行日プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime SalesSlipPrintDate
    //    {
    //        get { return _salesSlipPrintDate; }
    //        set { _salesSlipPrintDate = value; }
    //    }

    //    /// public propaty name  :  SalesSlipPrintDateJpFormal
    //    /// <summary>売上伝票発行日 和暦プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上伝票発行日 和暦プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesSlipPrintDateJpFormal
    //    {
    //        get { return TDateTime.DateTimeToString("GGYYMMDD", _salesSlipPrintDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  SalesSlipPrintDateJpInFormal
    //    /// <summary>売上伝票発行日 和暦(略)プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上伝票発行日 和暦(略)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesSlipPrintDateJpInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("ggYY/MM/DD", _salesSlipPrintDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  SalesSlipPrintDateAdFormal
    //    /// <summary>売上伝票発行日 西暦プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上伝票発行日 西暦プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesSlipPrintDateAdFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YYYY/MM/DD", _salesSlipPrintDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  SalesSlipPrintDateAdInFormal
    //    /// <summary>売上伝票発行日 西暦(略)プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上伝票発行日 西暦(略)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesSlipPrintDateAdInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YY/MM/DD", _salesSlipPrintDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  BusinessTypeCode
    //    /// <summary>業種コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   業種コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 BusinessTypeCode
    //    {
    //        get { return _businessTypeCode; }
    //        set { _businessTypeCode = value; }
    //    }

    //    /// public propaty name  :  BusinessTypeName
    //    /// <summary>業種名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   業種名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string BusinessTypeName
    //    {
    //        get { return _businessTypeName; }
    //        set { _businessTypeName = value; }
    //    }

    //    /// public propaty name  :  OrderNumber
    //    /// <summary>発注番号プロパティ</summary>
    //    /// <value>売上形式＝"受注"の時にセット</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   発注番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string OrderNumber
    //    {
    //        get { return _orderNumber; }
    //        set { _orderNumber = value; }
    //    }

    //    /// public propaty name  :  DeliveredGoodsDiv
    //    /// <summary>納品区分プロパティ</summary>
    //    /// <value>例) 1:配達,2:店頭渡し,3:直送,…</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   納品区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 DeliveredGoodsDiv
    //    {
    //        get { return _deliveredGoodsDiv; }
    //        set { _deliveredGoodsDiv = value; }
    //    }

    //    /// public propaty name  :  DeliveredGoodsDivNm
    //    /// <summary>納品区分名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   納品区分名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string DeliveredGoodsDivNm
    //    {
    //        get { return _deliveredGoodsDivNm; }
    //        set { _deliveredGoodsDivNm = value; }
    //    }

    //    /// public propaty name  :  SalesAreaCode
    //    /// <summary>販売エリアコードプロパティ</summary>
    //    /// <value>地区コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   販売エリアコードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SalesAreaCode
    //    {
    //        get { return _salesAreaCode; }
    //        set { _salesAreaCode = value; }
    //    }

    //    /// public propaty name  :  SalesAreaName
    //    /// <summary>販売エリア名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   販売エリア名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesAreaName
    //    {
    //        get { return _salesAreaName; }
    //        set { _salesAreaName = value; }
    //    }

    //    /// public propaty name  :  ReconcileFlag
    //    /// <summary>消込フラグプロパティ</summary>
    //    /// <value>0:残あり 9:残無し　（受注、出荷にて使用）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   消込フラグプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 ReconcileFlag
    //    {
    //        get { return _reconcileFlag; }
    //        set { _reconcileFlag = value; }
    //    }

    //    /// public propaty name  :  SlipPrtSetPaperId
    //    /// <summary>伝票印刷設定用帳票IDプロパティ</summary>
    //    /// <value>売上形式とセットで伝票タイプ管理マスタを参照</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票印刷設定用帳票IDプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SlipPrtSetPaperId
    //    {
    //        get { return _slipPrtSetPaperId; }
    //        set { _slipPrtSetPaperId = value; }
    //    }

    //    /// public propaty name  :  CompleteCd
    //    /// <summary>一式伝票区分プロパティ</summary>
    //    /// <value>0:通常伝票,1:一式伝票</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   一式伝票区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 CompleteCd
    //    {
    //        get { return _completeCd; }
    //        set { _completeCd = value; }
    //    }

    //    /// public propaty name  :  SalesPriceFracProcCd
    //    /// <summary>売上金額端数処理区分プロパティ</summary>
    //    /// <value>1:切捨て,2:四捨五入,3:切上げ　（売上明細データの金額用）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上金額端数処理区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SalesPriceFracProcCd
    //    {
    //        get { return _salesPriceFracProcCd; }
    //        set { _salesPriceFracProcCd = value; }
    //    }

    //    /// public propaty name  :  StockGoodsTtlTaxExc
    //    /// <summary>在庫商品合計金額（税抜）プロパティ</summary>
    //    /// <value>在庫取寄区分が０の明細金額の集計</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   在庫商品合計金額（税抜）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 StockGoodsTtlTaxExc
    //    {
    //        get { return _stockGoodsTtlTaxExc; }
    //        set { _stockGoodsTtlTaxExc = value; }
    //    }

    //    /// public propaty name  :  PureGoodsTtlTaxExc
    //    /// <summary>純正商品合計金額（税抜）プロパティ</summary>
    //    /// <value>商品属性が０の明細金額の集計</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   純正商品合計金額（税抜）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 PureGoodsTtlTaxExc
    //    {
    //        get { return _pureGoodsTtlTaxExc; }
    //        set { _pureGoodsTtlTaxExc = value; }
    //    }

    //    /// public propaty name  :  ListPricePrintDiv
    //    /// <summary>定価印刷区分プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   定価印刷区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 ListPricePrintDiv
    //    {
    //        get { return _listPricePrintDiv; }
    //        set { _listPricePrintDiv = value; }
    //    }

    //    /// public propaty name  :  EraNameDispCd1
    //    /// <summary>元号表示区分１プロパティ</summary>
    //    /// <value>通常　　0:西暦　1:和暦</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   元号表示区分１プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 EraNameDispCd1
    //    {
    //        get { return _eraNameDispCd1; }
    //        set { _eraNameDispCd1 = value; }
    //    }

    //    /// public propaty name  :  EstimaTaxDivCd
    //    /// <summary>見積消費税区分プロパティ</summary>
    //    /// <value>0:非表示 1:外税（明細）2:総額表示 3:外税（伝票）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積消費税区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 EstimaTaxDivCd
    //    {
    //        get { return _estimaTaxDivCd; }
    //        set { _estimaTaxDivCd = value; }
    //    }

    //    /// public propaty name  :  EstimateFormPrtCd
    //    /// <summary>見積書印刷区分プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積書印刷区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 EstimateFormPrtCd
    //    {
    //        get { return _estimateFormPrtCd; }
    //        set { _estimateFormPrtCd = value; }
    //    }

    //    /// public propaty name  :  EstimateSubject
    //    /// <summary>見積件名プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積件名プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EstimateSubject
    //    {
    //        get { return _estimateSubject; }
    //        set { _estimateSubject = value; }
    //    }

    //    /// public propaty name  :  Footnotes1
    //    /// <summary>脚注１プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   脚注１プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string Footnotes1
    //    {
    //        get { return _footnotes1; }
    //        set { _footnotes1 = value; }
    //    }

    //    /// public propaty name  :  Footnotes2
    //    /// <summary>脚注２プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   脚注２プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string Footnotes2
    //    {
    //        get { return _footnotes2; }
    //        set { _footnotes2 = value; }
    //    }

    //    /// public propaty name  :  EstimateTitle1
    //    /// <summary>見積タイトル１プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積タイトル１プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EstimateTitle1
    //    {
    //        get { return _estimateTitle1; }
    //        set { _estimateTitle1 = value; }
    //    }

    //    /// public propaty name  :  EstimateTitle2
    //    /// <summary>見積タイトル２プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積タイトル２プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EstimateTitle2
    //    {
    //        get { return _estimateTitle2; }
    //        set { _estimateTitle2 = value; }
    //    }

    //    /// public propaty name  :  EstimateTitle3
    //    /// <summary>見積タイトル３プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積タイトル３プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EstimateTitle3
    //    {
    //        get { return _estimateTitle3; }
    //        set { _estimateTitle3 = value; }
    //    }

    //    /// public propaty name  :  EstimateTitle4
    //    /// <summary>見積タイトル４プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積タイトル４プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EstimateTitle4
    //    {
    //        get { return _estimateTitle4; }
    //        set { _estimateTitle4 = value; }
    //    }

    //    /// public propaty name  :  EstimateTitle5
    //    /// <summary>見積タイトル５プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積タイトル５プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EstimateTitle5
    //    {
    //        get { return _estimateTitle5; }
    //        set { _estimateTitle5 = value; }
    //    }

    //    /// public propaty name  :  EstimateNote1
    //    /// <summary>見積備考１プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積備考１プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EstimateNote1
    //    {
    //        get { return _estimateNote1; }
    //        set { _estimateNote1 = value; }
    //    }

    //    /// public propaty name  :  EstimateNote2
    //    /// <summary>見積備考２プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積備考２プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EstimateNote2
    //    {
    //        get { return _estimateNote2; }
    //        set { _estimateNote2 = value; }
    //    }

    //    /// public propaty name  :  EstimateNote3
    //    /// <summary>見積備考３プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積備考３プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EstimateNote3
    //    {
    //        get { return _estimateNote3; }
    //        set { _estimateNote3 = value; }
    //    }

    //    /// public propaty name  :  EstimateNote4
    //    /// <summary>見積備考４プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積備考４プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EstimateNote4
    //    {
    //        get { return _estimateNote4; }
    //        set { _estimateNote4 = value; }
    //    }

    //    /// public propaty name  :  EstimateNote5
    //    /// <summary>見積備考５プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積備考５プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EstimateNote5
    //    {
    //        get { return _estimateNote5; }
    //        set { _estimateNote5 = value; }
    //    }

    //    /// public propaty name  :  EstimateValidityDate
    //    /// <summary>見積有効期限プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積有効期限プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime EstimateValidityDate
    //    {
    //        get { return _estimateValidityDate; }
    //        set { _estimateValidityDate = value; }
    //    }

    //    /// public propaty name  :  EstimateValidityDateJpFormal
    //    /// <summary>見積有効期限 和暦プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積有効期限 和暦プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EstimateValidityDateJpFormal
    //    {
    //        get { return TDateTime.DateTimeToString("GGYYMMDD", _estimateValidityDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EstimateValidityDateJpInFormal
    //    /// <summary>見積有効期限 和暦(略)プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積有効期限 和暦(略)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EstimateValidityDateJpInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("ggYY/MM/DD", _estimateValidityDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EstimateValidityDateAdFormal
    //    /// <summary>見積有効期限 西暦プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積有効期限 西暦プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EstimateValidityDateAdFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YYYY/MM/DD", _estimateValidityDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  EstimateValidityDateAdInFormal
    //    /// <summary>見積有効期限 西暦(略)プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   見積有効期限 西暦(略)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EstimateValidityDateAdInFormal
    //    {
    //        get { return TDateTime.DateTimeToString("YY/MM/DD", _estimateValidityDate); }
    //        set { }
    //    }

    //    /// public propaty name  :  PartsNoPrtCd
    //    /// <summary>品番印字区分プロパティ</summary>
    //    /// <value>0:しない,1:する</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   品番印字区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 PartsNoPrtCd
    //    {
    //        get { return _partsNoPrtCd; }
    //        set { _partsNoPrtCd = value; }
    //    }

    //    /// public propaty name  :  OptionPringDivCd
    //    /// <summary>オプション印字区分プロパティ</summary>
    //    /// <value>0:しない,1:する</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   オプション印字区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 OptionPringDivCd
    //    {
    //        get { return _optionPringDivCd; }
    //        set { _optionPringDivCd = value; }
    //    }

    //    /// public propaty name  :  RateUseCode
    //    /// <summary>掛率使用区分プロパティ</summary>
    //    /// <value>0:売価＝定価 1:掛率指定,2:掛率設定</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   掛率使用区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 RateUseCode
    //    {
    //        get { return _rateUseCode; }
    //        set { _rateUseCode = value; }
    //    }

    //    /// public propaty name  :  CarMngCode
    //    /// <summary>車両管理番号プロパティ</summary>
    //    /// <value>自動採番（無重複のシーケンス）PM7での車両SEQ</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   車両管理番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string CarMngCode
    //    {
    //        get { return _carMngCode; }
    //        set { _carMngCode = value; }
    //    }

    //    /// public propaty name  :  ModelDesignationNo
    //    /// <summary>型式指定番号プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   型式指定番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 ModelDesignationNo
    //    {
    //        get { return _modelDesignationNo; }
    //        set { _modelDesignationNo = value; }
    //    }

    //    /// public propaty name  :  CategoryNo
    //    /// <summary>類別番号プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   類別番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 CategoryNo
    //    {
    //        get { return _categoryNo; }
    //        set { _categoryNo = value; }
    //    }

    //    /// public propaty name  :  MakerFullName
    //    /// <summary>メーカー全角名称プロパティ</summary>
    //    /// <value>正式名称（カナ漢字混在で全角管理）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   メーカー全角名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string MakerFullName
    //    {
    //        get { return _makerFullName; }
    //        set { _makerFullName = value; }
    //    }

    //    /// public propaty name  :  FullModel
    //    /// <summary>型式（フル型）プロパティ</summary>
    //    /// <value>フル型式(44桁用)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   型式（フル型）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string FullModel
    //    {
    //        get { return _fullModel; }
    //        set { _fullModel = value; }
    //    }

    //    /// public propaty name  :  EnterpriseName
    //    /// <summary>企業名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   企業名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EnterpriseName
    //    {
    //        get { return _enterpriseName; }
    //        set { _enterpriseName = value; }
    //    }

    //    /// public propaty name  :  ResultsAddUpSecNm
    //    /// <summary>実績計上拠点名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   実績計上拠点名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string ResultsAddUpSecNm
    //    {
    //        get { return _resultsAddUpSecNm; }
    //        set { _resultsAddUpSecNm = value; }
    //    }


    //    /// <summary>
    //    /// 売上伝票検索抽出結果コンストラクタ
    //    /// </summary>
    //    /// <returns>SalesSlipSearchResultクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SalesSlipSearchResultクラスの新しいインスタンスを生成します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public SalesSlipSearchResult()
    //    {
    //    }

    //    /// <summary>
    //    /// 売上伝票検索抽出結果コンストラクタ
    //    /// </summary>
    //    /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
    //    /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
    //    /// <param name="acptAnOdrStatus">受注ステータス(10:見積,20:受注,30:売上,40:出荷,70:指示書,80:クレーム,99:一時保管  )</param>
    //    /// <param name="salesSlipNum">売上伝票番号(見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。)</param>
    //    /// <param name="sectionCode">拠点コード</param>
    //    /// <param name="sectionGuideNm">拠点ガイド名称</param>
    //    /// <param name="subSectionCode">部門コード</param>
    //    /// <param name="subSectionName">部門名称</param>
    //    /// <param name="debitNoteDiv">赤伝区分(0:黒伝,1:赤伝,2:元黒)</param>
    //    /// <param name="debitNLnkSalesSlNum">赤黒連結売上伝票番号(赤黒の相手方売上伝票番号)</param>
    //    /// <param name="salesSlipCd">売上伝票区分(0:売上,1:返品)</param>
    //    /// <param name="salesGoodsCd">売上商品区分(0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動))</param>
    //    /// <param name="accRecDivCd">売掛区分(0:売掛なし,1:売掛)</param>
    //    /// <param name="salesInpSecCd">売上入力拠点コード(文字型 売上を入力した拠点コード)</param>
    //    /// <param name="demandAddUpSecCd">請求計上拠点コード(文字型)</param>
    //    /// <param name="resultsAddUpSecCd">実績計上拠点コード(実績計上を行う企業内の拠点コード)</param>
    //    /// <param name="updateSecCd">更新拠点コード(文字型 データの登録更新拠点)</param>
    //    /// <param name="searchSlipDate">伝票検索日付(YYYYMMDD　（更新年月日）)</param>
    //    /// <param name="shipmentDay">出荷日付(YYYYMMDD)</param>
    //    /// <param name="salesDate">売上日付(見積日、受注日、売上日を兼ねる。(YYYYMMDD))</param>
    //    /// <param name="addUpADate">計上日付(請求日　(YYYYMMDD))</param>
    //    /// <param name="delayPaymentDiv">来勘区分(0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後)</param>
    //    /// <param name="estimateFormNo">見積書番号</param>
    //    /// <param name="estimateDivide">見積区分(1:通常見積　2:単価見積　3:検索見積)</param>
    //    /// <param name="inputAgenCd">入力担当者コード(ログイン担当者（ＵＳＢ）)</param>
    //    /// <param name="inputAgenNm">入力担当者名称</param>
    //    /// <param name="salesInputCode">売上入力者コード(入力担当者（発行者）)</param>
    //    /// <param name="salesInputName">売上入力者名称</param>
    //    /// <param name="frontEmployeeCd">受付従業員コード(受付担当者（受注者）)</param>
    //    /// <param name="frontEmployeeNm">受付従業員名称</param>
    //    /// <param name="salesEmployeeCd">販売従業員コード(計上担当者（担当者）)</param>
    //    /// <param name="salesEmployeeNm">販売従業員名称</param>
    //    /// <param name="totalAmountDispWayCd">総額表示方法区分(0:総額表示しない（税抜き）,1:総額表示する（税込み）)</param>
    //    /// <param name="ttlAmntDispRateApy">総額表示掛率適用区分(0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率)</param>
    //    /// <param name="salesTotalTaxInc">売上伝票合計（税込み）(売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額)</param>
    //    /// <param name="salesTotalTaxExc">売上伝票合計（税抜き）(売上正価金額＋売上値引金額計（税抜き）)</param>
    //    /// <param name="salesPrtTotalTaxInc">売上部品合計（税込み）(売上部品小計（税込み）＋部品値引対象額合計（税込み）)</param>
    //    /// <param name="salesPrtTotalTaxExc">売上部品合計（税抜き）(売上部品小計（税抜き）＋部品値引対象額合計（税抜き）)</param>
    //    /// <param name="salesWorkTotalTaxInc">売上作業合計（税込み）(売上作業小計（税込み）＋作業値引対象額合計（税込み）)</param>
    //    /// <param name="salesWorkTotalTaxExc">売上作業合計（税抜き）(売上作業小計（税抜き）＋作業値引対象額合計（税抜き）)</param>
    //    /// <param name="salesSubtotalTaxInc">売上小計（税込み）(値引後の明細金額の合計（非課税含まず）)</param>
    //    /// <param name="salesSubtotalTaxExc">売上小計（税抜き）(値引後の明細金額の合計（非課税含まず）)</param>
    //    /// <param name="salesPrtSubttlInc">売上部品小計（税込み）(部品明細金額の税込合計)</param>
    //    /// <param name="salesPrtSubttlExc">売上部品小計（税抜き）(部品明細金額の税抜合計)</param>
    //    /// <param name="salesWorkSubttlInc">売上作業小計（税込み）(作業明細金額の税込合計)</param>
    //    /// <param name="salesWorkSubttlExc">売上作業小計（税抜き）(作業明細金額の税抜合計)</param>
    //    /// <param name="salesNetPrice">売上正価金額(値引前の税抜売上金額（外税分、内税分、非課税分の合計）)</param>
    //    /// <param name="salesSubtotalTax">売上小計（税）(外税対象金額の集計（税抜、値引含まず）)</param>
    //    /// <param name="itdedSalesOutTax">売上外税対象額(内税対象金額の集計（税抜、値引含まず） )</param>
    //    /// <param name="itdedSalesInTax">売上内税対象額(非課税対象金額の集計（値引含まず）)</param>
    //    /// <param name="salSubttlSubToTaxFre">売上小計非課税対象額(売上金額消費税額（外税）+売上金額消費税額（内税）値引き含まず)</param>
    //    /// <param name="salesOutTax">売上金額消費税額（外税）(値引前の外税商品の消費税)</param>
    //    /// <param name="salAmntConsTaxInclu">売上金額消費税額（内税）(値引前の内税商品の消費税)</param>
    //    /// <param name="salesDisTtlTaxExc">売上値引金額計（税抜き）</param>
    //    /// <param name="itdedSalesDisOutTax">売上値引外税対象額合計(外税商品値引の外税対象額（税抜）)</param>
    //    /// <param name="itdedSalesDisInTax">売上値引内税対象額合計(内税商品値引の内税対象額（税抜）)</param>
    //    /// <param name="itdedPartsDisOutTax">部品値引対象額合計（税抜き）(部品値引額（税抜き）)</param>
    //    /// <param name="itdedPartsDisInTax">部品値引対象額合計（税込み）(部品値引額（税込み）)</param>
    //    /// <param name="itdedWorkDisOutTax">作業値引対象額合計（税抜き）(作業値引額（税抜き）)</param>
    //    /// <param name="itdedWorkDisInTax">作業値引対象額合計（税込み）(作業値引額（税込み）)</param>
    //    /// <param name="itdedSalesDisTaxFre">売上値引非課税対象額合計(非課税商品値引の非課税対象額)</param>
    //    /// <param name="salesDisOutTax">売上値引消費税額（外税）(外税商品値引の消費税額)</param>
    //    /// <param name="salesDisTtlTaxInclu">売上値引消費税額（内税）</param>
    //    /// <param name="partsDiscountRate">部品値引率(小計に対しての部品値引率)</param>
    //    /// <param name="ravorDiscountRate">工賃値引率(小計に対しての工賃値引率)</param>
    //    /// <param name="totalCost">原価金額計</param>
    //    /// <param name="consTaxLayMethod">消費税転嫁方式(0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税)</param>
    //    /// <param name="consTaxRate">消費税税率(変更2007/8/22(型,桁) 塩原)</param>
    //    /// <param name="fractionProcCd">端数処理区分(1:切捨て,2:四捨五入,3:切上げ　（消費税）)</param>
    //    /// <param name="accRecConsTax">売掛消費税</param>
    //    /// <param name="autoDepositCd">自動入金区分(0:通常入金,1:自動入金)</param>
    //    /// <param name="autoDepositSlipNo">自動入金伝票番号(自動入金時の入金伝票番号)</param>
    //    /// <param name="depositAllowanceTtl">入金引当合計額(預り金引当合計額を含む)</param>
    //    /// <param name="depositAlwcBlnce">入金引当残高</param>
    //    /// <param name="claimCode">請求先コード</param>
    //    /// <param name="claimSnm">請求先略称</param>
    //    /// <param name="customerCode">得意先コード</param>
    //    /// <param name="customerName">得意先名称</param>
    //    /// <param name="customerName2">得意先名称2</param>
    //    /// <param name="customerSnm">得意先略称</param>
    //    /// <param name="honorificTitle">敬称</param>
    //    /// <param name="outputName">諸口名称</param>
    //    /// <param name="custSlipNo">得意先伝票番号</param>
    //    /// <param name="slipAddressDiv">伝票住所区分(1:得意先,2:納入先)</param>
    //    /// <param name="addresseeCode">納品先コード</param>
    //    /// <param name="addresseeName">納品先名称</param>
    //    /// <param name="addresseeName2">納品先名称2(追加(登録漏れ) 塩原)</param>
    //    /// <param name="addresseePostNo">納品先郵便番号(伝票住所区分に従う内容)</param>
    //    /// <param name="addresseeAddr1">納品先住所1(都道府県市区郡・町村・字)(伝票住所区分に従う内容)</param>
    //    /// <param name="addresseeAddr3">納品先住所3(番地)(伝票住所区分に従う内容)</param>
    //    /// <param name="addresseeAddr4">納品先住所4(アパート名称)(伝票住所区分に従う内容)</param>
    //    /// <param name="addresseeTelNo">納品先電話番号(伝票住所区分に従う内容)</param>
    //    /// <param name="addresseeFaxNo">納品先FAX番号(伝票住所区分に従う内容)</param>
    //    /// <param name="partySaleSlipNum">相手先伝票番号(得意先注文番号（仮伝番号）)</param>
    //    /// <param name="slipNote">伝票備考</param>
    //    /// <param name="slipNote2">伝票備考２</param>
    //    /// <param name="slipNote3">伝票備考３</param>
    //    /// <param name="retGoodsReasonDiv">返品理由コード</param>
    //    /// <param name="retGoodsReason">返品理由</param>
    //    /// <param name="regiProcDate">レジ処理日(YYYYMMDD　（サーバー未接続時、売上伝票発行するための情報）)</param>
    //    /// <param name="cashRegisterNo">レジ番号(　　　　　（サーバー未接続時、売上伝票発行するための情報）)</param>
    //    /// <param name="posReceiptNo">POSレシート番号(　　　　　（サーバー未接続時、売上伝票発行するための情報）)</param>
    //    /// <param name="detailRowCount">明細行数(伝票内の明細の行数（諸費用明細は除く）)</param>
    //    /// <param name="ediSendDate">ＥＤＩ送信日(YYYYMMDD （ErectricDataInterface）)</param>
    //    /// <param name="ediTakeInDate">ＥＤＩ取込日(YYYYMMDD)</param>
    //    /// <param name="uoeRemark1">ＵＯＥリマーク１(UserOrderEntory)</param>
    //    /// <param name="uoeRemark2">ＵＯＥリマーク２</param>
    //    /// <param name="slipPrintDivCd">伝票発行区分(0:しない 1:する)</param>
    //    /// <param name="slipPrintFinishCd">伝票発行済区分(0:未発行 1:発行済)</param>
    //    /// <param name="salesSlipPrintDate">売上伝票発行日</param>
    //    /// <param name="businessTypeCode">業種コード</param>
    //    /// <param name="businessTypeName">業種名称</param>
    //    /// <param name="orderNumber">発注番号(売上形式＝"受注"の時にセット)</param>
    //    /// <param name="deliveredGoodsDiv">納品区分(例) 1:配達,2:店頭渡し,3:直送,…)</param>
    //    /// <param name="deliveredGoodsDivNm">納品区分名称</param>
    //    /// <param name="salesAreaCode">販売エリアコード(地区コード)</param>
    //    /// <param name="salesAreaName">販売エリア名称</param>
    //    /// <param name="reconcileFlag">消込フラグ(0:残あり 9:残無し　（受注、出荷にて使用）)</param>
    //    /// <param name="slipPrtSetPaperId">伝票印刷設定用帳票ID(売上形式とセットで伝票タイプ管理マスタを参照)</param>
    //    /// <param name="completeCd">一式伝票区分(0:通常伝票,1:一式伝票)</param>
    //    /// <param name="salesPriceFracProcCd">売上金額端数処理区分(1:切捨て,2:四捨五入,3:切上げ　（売上明細データの金額用）)</param>
    //    /// <param name="stockGoodsTtlTaxExc">在庫商品合計金額（税抜）(在庫取寄区分が０の明細金額の集計)</param>
    //    /// <param name="pureGoodsTtlTaxExc">純正商品合計金額（税抜）(商品属性が０の明細金額の集計)</param>
    //    /// <param name="listPricePrintDiv">定価印刷区分</param>
    //    /// <param name="eraNameDispCd1">元号表示区分１(通常　　0:西暦　1:和暦)</param>
    //    /// <param name="estimaTaxDivCd">見積消費税区分(0:非表示 1:外税（明細）2:総額表示 3:外税（伝票）)</param>
    //    /// <param name="estimateFormPrtCd">見積書印刷区分</param>
    //    /// <param name="estimateSubject">見積件名</param>
    //    /// <param name="footnotes1">脚注１</param>
    //    /// <param name="footnotes2">脚注２</param>
    //    /// <param name="estimateTitle1">見積タイトル１</param>
    //    /// <param name="estimateTitle2">見積タイトル２</param>
    //    /// <param name="estimateTitle3">見積タイトル３</param>
    //    /// <param name="estimateTitle4">見積タイトル４</param>
    //    /// <param name="estimateTitle5">見積タイトル５</param>
    //    /// <param name="estimateNote1">見積備考１</param>
    //    /// <param name="estimateNote2">見積備考２</param>
    //    /// <param name="estimateNote3">見積備考３</param>
    //    /// <param name="estimateNote4">見積備考４</param>
    //    /// <param name="estimateNote5">見積備考５</param>
    //    /// <param name="estimateValidityDate">見積有効期限(YYYYMMDD)</param>
    //    /// <param name="partsNoPrtCd">品番印字区分(0:しない,1:する)</param>
    //    /// <param name="optionPringDivCd">オプション印字区分(0:しない,1:する)</param>
    //    /// <param name="rateUseCode">掛率使用区分(0:売価＝定価 1:掛率指定,2:掛率設定)</param>
    //    /// <param name="carMngCode">車両管理番号(自動採番（無重複のシーケンス）PM7での車両SEQ)</param>
    //    /// <param name="modelDesignationNo">型式指定番号</param>
    //    /// <param name="categoryNo">類別番号</param>
    //    /// <param name="makerFullName">メーカー全角名称(正式名称（カナ漢字混在で全角管理）)</param>
    //    /// <param name="fullModel">型式（フル型）(フル型式(44桁用))</param>
    //    /// <param name="enterpriseName">企業名称</param>
    //    /// <param name="resultsAddUpSecNm">実績計上拠点名称</param>
    //    /// <returns>SalesSlipSearchResultクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SalesSlipSearchResultクラスの新しいインスタンスを生成します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public SalesSlipSearchResult(string enterpriseCode, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, string sectionGuideNm, Int32 subSectionCode, string subSectionName, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 delayPaymentDiv, string estimateFormNo, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesPrtTotalTaxInc, Int64 salesPrtTotalTaxExc, Int64 salesWorkTotalTaxInc, Int64 salesWorkTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesPrtSubttlInc, Int64 salesPrtSubttlExc, Int64 salesWorkSubttlInc, Int64 salesWorkSubttlExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedPartsDisOutTax, Int64 itdedPartsDisInTax, Int64 itdedWorkDisOutTax, Int64 itdedWorkDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Double partsDiscountRate, Double ravorDiscountRate, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, string outputName, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string slipNote, string slipNote2, string slipNote3, Int32 retGoodsReasonDiv, string retGoodsReason, DateTime regiProcDate, Int32 cashRegisterNo, Int32 posReceiptNo, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, string orderNumber, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, Int32 reconcileFlag, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 estimaTaxDivCd, Int32 estimateFormPrtCd, string estimateSubject, string footnotes1, string footnotes2, string estimateTitle1, string estimateTitle2, string estimateTitle3, string estimateTitle4, string estimateTitle5, string estimateNote1, string estimateNote2, string estimateNote3, string estimateNote4, string estimateNote5, DateTime estimateValidityDate, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 rateUseCode, string carMngCode, Int32 modelDesignationNo, Int32 categoryNo, string makerFullName, string fullModel, string enterpriseName, string resultsAddUpSecNm)
    //    {
    //        this._enterpriseCode = enterpriseCode;
    //        this._logicalDeleteCode = logicalDeleteCode;
    //        this._acptAnOdrStatus = acptAnOdrStatus;
    //        this._salesSlipNum = salesSlipNum;
    //        this._sectionCode = sectionCode;
    //        this._sectionGuideNm = sectionGuideNm;
    //        this._subSectionCode = subSectionCode;
    //        this._subSectionName = subSectionName;
    //        this._debitNoteDiv = debitNoteDiv;
    //        this._debitNLnkSalesSlNum = debitNLnkSalesSlNum;
    //        this._salesSlipCd = salesSlipCd;
    //        this._salesGoodsCd = salesGoodsCd;
    //        this._accRecDivCd = accRecDivCd;
    //        this._salesInpSecCd = salesInpSecCd;
    //        this._demandAddUpSecCd = demandAddUpSecCd;
    //        this._resultsAddUpSecCd = resultsAddUpSecCd;
    //        this._updateSecCd = updateSecCd;
    //        this.SearchSlipDate = searchSlipDate;
    //        this.ShipmentDay = shipmentDay;
    //        this.SalesDate = salesDate;
    //        this.AddUpADate = addUpADate;
    //        this._delayPaymentDiv = delayPaymentDiv;
    //        this._estimateFormNo = estimateFormNo;
    //        this._estimateDivide = estimateDivide;
    //        this._inputAgenCd = inputAgenCd;
    //        this._inputAgenNm = inputAgenNm;
    //        this._salesInputCode = salesInputCode;
    //        this._salesInputName = salesInputName;
    //        this._frontEmployeeCd = frontEmployeeCd;
    //        this._frontEmployeeNm = frontEmployeeNm;
    //        this._salesEmployeeCd = salesEmployeeCd;
    //        this._salesEmployeeNm = salesEmployeeNm;
    //        this._totalAmountDispWayCd = totalAmountDispWayCd;
    //        this._ttlAmntDispRateApy = ttlAmntDispRateApy;
    //        this._salesTotalTaxInc = salesTotalTaxInc;
    //        this._salesTotalTaxExc = salesTotalTaxExc;
    //        this._salesPrtTotalTaxInc = salesPrtTotalTaxInc;
    //        this._salesPrtTotalTaxExc = salesPrtTotalTaxExc;
    //        this._salesWorkTotalTaxInc = salesWorkTotalTaxInc;
    //        this._salesWorkTotalTaxExc = salesWorkTotalTaxExc;
    //        this._salesSubtotalTaxInc = salesSubtotalTaxInc;
    //        this._salesSubtotalTaxExc = salesSubtotalTaxExc;
    //        this._salesPrtSubttlInc = salesPrtSubttlInc;
    //        this._salesPrtSubttlExc = salesPrtSubttlExc;
    //        this._salesWorkSubttlInc = salesWorkSubttlInc;
    //        this._salesWorkSubttlExc = salesWorkSubttlExc;
    //        this._salesNetPrice = salesNetPrice;
    //        this._salesSubtotalTax = salesSubtotalTax;
    //        this._itdedSalesOutTax = itdedSalesOutTax;
    //        this._itdedSalesInTax = itdedSalesInTax;
    //        this._salSubttlSubToTaxFre = salSubttlSubToTaxFre;
    //        this._salesOutTax = salesOutTax;
    //        this._salAmntConsTaxInclu = salAmntConsTaxInclu;
    //        this._salesDisTtlTaxExc = salesDisTtlTaxExc;
    //        this._itdedSalesDisOutTax = itdedSalesDisOutTax;
    //        this._itdedSalesDisInTax = itdedSalesDisInTax;
    //        this._itdedPartsDisOutTax = itdedPartsDisOutTax;
    //        this._itdedPartsDisInTax = itdedPartsDisInTax;
    //        this._itdedWorkDisOutTax = itdedWorkDisOutTax;
    //        this._itdedWorkDisInTax = itdedWorkDisInTax;
    //        this._itdedSalesDisTaxFre = itdedSalesDisTaxFre;
    //        this._salesDisOutTax = salesDisOutTax;
    //        this._salesDisTtlTaxInclu = salesDisTtlTaxInclu;
    //        this._partsDiscountRate = partsDiscountRate;
    //        this._ravorDiscountRate = ravorDiscountRate;
    //        this._totalCost = totalCost;
    //        this._consTaxLayMethod = consTaxLayMethod;
    //        this._consTaxRate = consTaxRate;
    //        this._fractionProcCd = fractionProcCd;
    //        this._accRecConsTax = accRecConsTax;
    //        this._autoDepositCd = autoDepositCd;
    //        this._autoDepositSlipNo = autoDepositSlipNo;
    //        this._depositAllowanceTtl = depositAllowanceTtl;
    //        this._depositAlwcBlnce = depositAlwcBlnce;
    //        this._claimCode = claimCode;
    //        this._claimSnm = claimSnm;
    //        this._customerCode = customerCode;
    //        this._customerName = customerName;
    //        this._customerName2 = customerName2;
    //        this._customerSnm = customerSnm;
    //        this._honorificTitle = honorificTitle;
    //        this._outputName = outputName;
    //        this._custSlipNo = custSlipNo;
    //        this._slipAddressDiv = slipAddressDiv;
    //        this._addresseeCode = addresseeCode;
    //        this._addresseeName = addresseeName;
    //        this._addresseeName2 = addresseeName2;
    //        this._addresseePostNo = addresseePostNo;
    //        this._addresseeAddr1 = addresseeAddr1;
    //        this._addresseeAddr3 = addresseeAddr3;
    //        this._addresseeAddr4 = addresseeAddr4;
    //        this._addresseeTelNo = addresseeTelNo;
    //        this._addresseeFaxNo = addresseeFaxNo;
    //        this._partySaleSlipNum = partySaleSlipNum;
    //        this._slipNote = slipNote;
    //        this._slipNote2 = slipNote2;
    //        this._slipNote3 = slipNote3;
    //        this._retGoodsReasonDiv = retGoodsReasonDiv;
    //        this._retGoodsReason = retGoodsReason;
    //        this.RegiProcDate = regiProcDate;
    //        this._cashRegisterNo = cashRegisterNo;
    //        this._posReceiptNo = posReceiptNo;
    //        this._detailRowCount = detailRowCount;
    //        this.EdiSendDate = ediSendDate;
    //        this.EdiTakeInDate = ediTakeInDate;
    //        this._uoeRemark1 = uoeRemark1;
    //        this._uoeRemark2 = uoeRemark2;
    //        this._slipPrintDivCd = slipPrintDivCd;
    //        this._slipPrintFinishCd = slipPrintFinishCd;
    //        this.SalesSlipPrintDate = salesSlipPrintDate;
    //        this._businessTypeCode = businessTypeCode;
    //        this._businessTypeName = businessTypeName;
    //        this._orderNumber = orderNumber;
    //        this._deliveredGoodsDiv = deliveredGoodsDiv;
    //        this._deliveredGoodsDivNm = deliveredGoodsDivNm;
    //        this._salesAreaCode = salesAreaCode;
    //        this._salesAreaName = salesAreaName;
    //        this._reconcileFlag = reconcileFlag;
    //        this._slipPrtSetPaperId = slipPrtSetPaperId;
    //        this._completeCd = completeCd;
    //        this._salesPriceFracProcCd = salesPriceFracProcCd;
    //        this._stockGoodsTtlTaxExc = stockGoodsTtlTaxExc;
    //        this._pureGoodsTtlTaxExc = pureGoodsTtlTaxExc;
    //        this._listPricePrintDiv = listPricePrintDiv;
    //        this._eraNameDispCd1 = eraNameDispCd1;
    //        this._estimaTaxDivCd = estimaTaxDivCd;
    //        this._estimateFormPrtCd = estimateFormPrtCd;
    //        this._estimateSubject = estimateSubject;
    //        this._footnotes1 = footnotes1;
    //        this._footnotes2 = footnotes2;
    //        this._estimateTitle1 = estimateTitle1;
    //        this._estimateTitle2 = estimateTitle2;
    //        this._estimateTitle3 = estimateTitle3;
    //        this._estimateTitle4 = estimateTitle4;
    //        this._estimateTitle5 = estimateTitle5;
    //        this._estimateNote1 = estimateNote1;
    //        this._estimateNote2 = estimateNote2;
    //        this._estimateNote3 = estimateNote3;
    //        this._estimateNote4 = estimateNote4;
    //        this._estimateNote5 = estimateNote5;
    //        this.EstimateValidityDate = estimateValidityDate;
    //        this._partsNoPrtCd = partsNoPrtCd;
    //        this._optionPringDivCd = optionPringDivCd;
    //        this._rateUseCode = rateUseCode;
    //        this._carMngCode = carMngCode;
    //        this._modelDesignationNo = modelDesignationNo;
    //        this._categoryNo = categoryNo;
    //        this._makerFullName = makerFullName;
    //        this._fullModel = fullModel;
    //        this._enterpriseName = enterpriseName;
    //        this._resultsAddUpSecNm = resultsAddUpSecNm;

    //    }

    //    /// <summary>
    //    /// 売上伝票検索抽出結果複製処理
    //    /// </summary>
    //    /// <returns>SalesSlipSearchResultクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   自身の内容と等しいSalesSlipSearchResultクラスのインスタンスを返します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public SalesSlipSearchResult Clone()
    //    {
    //        return new SalesSlipSearchResult(this._enterpriseCode, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._sectionGuideNm, this._subSectionCode, this._subSectionName, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._addUpADate, this._delayPaymentDiv, this._estimateFormNo, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesPrtTotalTaxInc, this._salesPrtTotalTaxExc, this._salesWorkTotalTaxInc, this._salesWorkTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesPrtSubttlInc, this._salesPrtSubttlExc, this._salesWorkSubttlInc, this._salesWorkSubttlExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedPartsDisOutTax, this._itdedPartsDisInTax, this._itdedWorkDisOutTax, this._itdedWorkDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._partsDiscountRate, this._ravorDiscountRate, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputName, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._slipNote, this._slipNote2, this._slipNote3, this._retGoodsReasonDiv, this._retGoodsReason, this._regiProcDate, this._cashRegisterNo, this._posReceiptNo, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._orderNumber, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._reconcileFlag, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._estimaTaxDivCd, this._estimateFormPrtCd, this._estimateSubject, this._footnotes1, this._footnotes2, this._estimateTitle1, this._estimateTitle2, this._estimateTitle3, this._estimateTitle4, this._estimateTitle5, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimateNote4, this._estimateNote5, this._estimateValidityDate, this._partsNoPrtCd, this._optionPringDivCd, this._rateUseCode, this._carMngCode, this._modelDesignationNo, this._categoryNo, this._makerFullName, this._fullModel, this._enterpriseName, this._resultsAddUpSecNm);
    //    }

    //    /// <summary>
    //    /// 売上伝票検索抽出結果比較処理
    //    /// </summary>
    //    /// <param name="target">比較対象のSalesSlipSearchResultクラスのインスタンス</param>
    //    /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SalesSlipSearchResultクラスの内容が一致するか比較します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public bool Equals(SalesSlipSearchResult target)
    //    {
    //        return ((this.EnterpriseCode == target.EnterpriseCode)
    //             && (this.LogicalDeleteCode == target.LogicalDeleteCode)
    //             && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
    //             && (this.SalesSlipNum == target.SalesSlipNum)
    //             && (this.SectionCode == target.SectionCode)
    //             && (this.SectionGuideNm == target.SectionGuideNm)
    //             && (this.SubSectionCode == target.SubSectionCode)
    //             && (this.SubSectionName == target.SubSectionName)
    //             && (this.DebitNoteDiv == target.DebitNoteDiv)
    //             && (this.DebitNLnkSalesSlNum == target.DebitNLnkSalesSlNum)
    //             && (this.SalesSlipCd == target.SalesSlipCd)
    //             && (this.SalesGoodsCd == target.SalesGoodsCd)
    //             && (this.AccRecDivCd == target.AccRecDivCd)
    //             && (this.SalesInpSecCd == target.SalesInpSecCd)
    //             && (this.DemandAddUpSecCd == target.DemandAddUpSecCd)
    //             && (this.ResultsAddUpSecCd == target.ResultsAddUpSecCd)
    //             && (this.UpdateSecCd == target.UpdateSecCd)
    //             && (this.SearchSlipDate == target.SearchSlipDate)
    //             && (this.ShipmentDay == target.ShipmentDay)
    //             && (this.SalesDate == target.SalesDate)
    //             && (this.AddUpADate == target.AddUpADate)
    //             && (this.DelayPaymentDiv == target.DelayPaymentDiv)
    //             && (this.EstimateFormNo == target.EstimateFormNo)
    //             && (this.EstimateDivide == target.EstimateDivide)
    //             && (this.InputAgenCd == target.InputAgenCd)
    //             && (this.InputAgenNm == target.InputAgenNm)
    //             && (this.SalesInputCode == target.SalesInputCode)
    //             && (this.SalesInputName == target.SalesInputName)
    //             && (this.FrontEmployeeCd == target.FrontEmployeeCd)
    //             && (this.FrontEmployeeNm == target.FrontEmployeeNm)
    //             && (this.SalesEmployeeCd == target.SalesEmployeeCd)
    //             && (this.SalesEmployeeNm == target.SalesEmployeeNm)
    //             && (this.TotalAmountDispWayCd == target.TotalAmountDispWayCd)
    //             && (this.TtlAmntDispRateApy == target.TtlAmntDispRateApy)
    //             && (this.SalesTotalTaxInc == target.SalesTotalTaxInc)
    //             && (this.SalesTotalTaxExc == target.SalesTotalTaxExc)
    //             && (this.SalesPrtTotalTaxInc == target.SalesPrtTotalTaxInc)
    //             && (this.SalesPrtTotalTaxExc == target.SalesPrtTotalTaxExc)
    //             && (this.SalesWorkTotalTaxInc == target.SalesWorkTotalTaxInc)
    //             && (this.SalesWorkTotalTaxExc == target.SalesWorkTotalTaxExc)
    //             && (this.SalesSubtotalTaxInc == target.SalesSubtotalTaxInc)
    //             && (this.SalesSubtotalTaxExc == target.SalesSubtotalTaxExc)
    //             && (this.SalesPrtSubttlInc == target.SalesPrtSubttlInc)
    //             && (this.SalesPrtSubttlExc == target.SalesPrtSubttlExc)
    //             && (this.SalesWorkSubttlInc == target.SalesWorkSubttlInc)
    //             && (this.SalesWorkSubttlExc == target.SalesWorkSubttlExc)
    //             && (this.SalesNetPrice == target.SalesNetPrice)
    //             && (this.SalesSubtotalTax == target.SalesSubtotalTax)
    //             && (this.ItdedSalesOutTax == target.ItdedSalesOutTax)
    //             && (this.ItdedSalesInTax == target.ItdedSalesInTax)
    //             && (this.SalSubttlSubToTaxFre == target.SalSubttlSubToTaxFre)
    //             && (this.SalesOutTax == target.SalesOutTax)
    //             && (this.SalAmntConsTaxInclu == target.SalAmntConsTaxInclu)
    //             && (this.SalesDisTtlTaxExc == target.SalesDisTtlTaxExc)
    //             && (this.ItdedSalesDisOutTax == target.ItdedSalesDisOutTax)
    //             && (this.ItdedSalesDisInTax == target.ItdedSalesDisInTax)
    //             && (this.ItdedPartsDisOutTax == target.ItdedPartsDisOutTax)
    //             && (this.ItdedPartsDisInTax == target.ItdedPartsDisInTax)
    //             && (this.ItdedWorkDisOutTax == target.ItdedWorkDisOutTax)
    //             && (this.ItdedWorkDisInTax == target.ItdedWorkDisInTax)
    //             && (this.ItdedSalesDisTaxFre == target.ItdedSalesDisTaxFre)
    //             && (this.SalesDisOutTax == target.SalesDisOutTax)
    //             && (this.SalesDisTtlTaxInclu == target.SalesDisTtlTaxInclu)
    //             && (this.PartsDiscountRate == target.PartsDiscountRate)
    //             && (this.RavorDiscountRate == target.RavorDiscountRate)
    //             && (this.TotalCost == target.TotalCost)
    //             && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
    //             && (this.ConsTaxRate == target.ConsTaxRate)
    //             && (this.FractionProcCd == target.FractionProcCd)
    //             && (this.AccRecConsTax == target.AccRecConsTax)
    //             && (this.AutoDepositCd == target.AutoDepositCd)
    //             && (this.AutoDepositSlipNo == target.AutoDepositSlipNo)
    //             && (this.DepositAllowanceTtl == target.DepositAllowanceTtl)
    //             && (this.DepositAlwcBlnce == target.DepositAlwcBlnce)
    //             && (this.ClaimCode == target.ClaimCode)
    //             && (this.ClaimSnm == target.ClaimSnm)
    //             && (this.CustomerCode == target.CustomerCode)
    //             && (this.CustomerName == target.CustomerName)
    //             && (this.CustomerName2 == target.CustomerName2)
    //             && (this.CustomerSnm == target.CustomerSnm)
    //             && (this.HonorificTitle == target.HonorificTitle)
    //             && (this.OutputName == target.OutputName)
    //             && (this.CustSlipNo == target.CustSlipNo)
    //             && (this.SlipAddressDiv == target.SlipAddressDiv)
    //             && (this.AddresseeCode == target.AddresseeCode)
    //             && (this.AddresseeName == target.AddresseeName)
    //             && (this.AddresseeName2 == target.AddresseeName2)
    //             && (this.AddresseePostNo == target.AddresseePostNo)
    //             && (this.AddresseeAddr1 == target.AddresseeAddr1)
    //             && (this.AddresseeAddr3 == target.AddresseeAddr3)
    //             && (this.AddresseeAddr4 == target.AddresseeAddr4)
    //             && (this.AddresseeTelNo == target.AddresseeTelNo)
    //             && (this.AddresseeFaxNo == target.AddresseeFaxNo)
    //             && (this.PartySaleSlipNum == target.PartySaleSlipNum)
    //             && (this.SlipNote == target.SlipNote)
    //             && (this.SlipNote2 == target.SlipNote2)
    //             && (this.SlipNote3 == target.SlipNote3)
    //             && (this.RetGoodsReasonDiv == target.RetGoodsReasonDiv)
    //             && (this.RetGoodsReason == target.RetGoodsReason)
    //             && (this.RegiProcDate == target.RegiProcDate)
    //             && (this.CashRegisterNo == target.CashRegisterNo)
    //             && (this.PosReceiptNo == target.PosReceiptNo)
    //             && (this.DetailRowCount == target.DetailRowCount)
    //             && (this.EdiSendDate == target.EdiSendDate)
    //             && (this.EdiTakeInDate == target.EdiTakeInDate)
    //             && (this.UoeRemark1 == target.UoeRemark1)
    //             && (this.UoeRemark2 == target.UoeRemark2)
    //             && (this.SlipPrintDivCd == target.SlipPrintDivCd)
    //             && (this.SlipPrintFinishCd == target.SlipPrintFinishCd)
    //             && (this.SalesSlipPrintDate == target.SalesSlipPrintDate)
    //             && (this.BusinessTypeCode == target.BusinessTypeCode)
    //             && (this.BusinessTypeName == target.BusinessTypeName)
    //             && (this.OrderNumber == target.OrderNumber)
    //             && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
    //             && (this.DeliveredGoodsDivNm == target.DeliveredGoodsDivNm)
    //             && (this.SalesAreaCode == target.SalesAreaCode)
    //             && (this.SalesAreaName == target.SalesAreaName)
    //             && (this.ReconcileFlag == target.ReconcileFlag)
    //             && (this.SlipPrtSetPaperId == target.SlipPrtSetPaperId)
    //             && (this.CompleteCd == target.CompleteCd)
    //             && (this.SalesPriceFracProcCd == target.SalesPriceFracProcCd)
    //             && (this.StockGoodsTtlTaxExc == target.StockGoodsTtlTaxExc)
    //             && (this.PureGoodsTtlTaxExc == target.PureGoodsTtlTaxExc)
    //             && (this.ListPricePrintDiv == target.ListPricePrintDiv)
    //             && (this.EraNameDispCd1 == target.EraNameDispCd1)
    //             && (this.EstimaTaxDivCd == target.EstimaTaxDivCd)
    //             && (this.EstimateFormPrtCd == target.EstimateFormPrtCd)
    //             && (this.EstimateSubject == target.EstimateSubject)
    //             && (this.Footnotes1 == target.Footnotes1)
    //             && (this.Footnotes2 == target.Footnotes2)
    //             && (this.EstimateTitle1 == target.EstimateTitle1)
    //             && (this.EstimateTitle2 == target.EstimateTitle2)
    //             && (this.EstimateTitle3 == target.EstimateTitle3)
    //             && (this.EstimateTitle4 == target.EstimateTitle4)
    //             && (this.EstimateTitle5 == target.EstimateTitle5)
    //             && (this.EstimateNote1 == target.EstimateNote1)
    //             && (this.EstimateNote2 == target.EstimateNote2)
    //             && (this.EstimateNote3 == target.EstimateNote3)
    //             && (this.EstimateNote4 == target.EstimateNote4)
    //             && (this.EstimateNote5 == target.EstimateNote5)
    //             && (this.EstimateValidityDate == target.EstimateValidityDate)
    //             && (this.PartsNoPrtCd == target.PartsNoPrtCd)
    //             && (this.OptionPringDivCd == target.OptionPringDivCd)
    //             && (this.RateUseCode == target.RateUseCode)
    //             && (this.CarMngCode == target.CarMngCode)
    //             && (this.ModelDesignationNo == target.ModelDesignationNo)
    //             && (this.CategoryNo == target.CategoryNo)
    //             && (this.MakerFullName == target.MakerFullName)
    //             && (this.FullModel == target.FullModel)
    //             && (this.EnterpriseName == target.EnterpriseName)
    //             && (this.ResultsAddUpSecNm == target.ResultsAddUpSecNm));
    //    }

    //    /// <summary>
    //    /// 売上伝票検索抽出結果比較処理
    //    /// </summary>
    //    /// <param name="salesSlipSearchResult1">
    //    ///                    比較するSalesSlipSearchResultクラスのインスタンス
    //    /// </param>
    //    /// <param name="salesSlipSearchResult2">比較するSalesSlipSearchResultクラスのインスタンス</param>
    //    /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SalesSlipSearchResultクラスの内容が一致するか比較します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public static bool Equals(SalesSlipSearchResult salesSlipSearchResult1, SalesSlipSearchResult salesSlipSearchResult2)
    //    {
    //        return ((salesSlipSearchResult1.EnterpriseCode == salesSlipSearchResult2.EnterpriseCode)
    //             && (salesSlipSearchResult1.LogicalDeleteCode == salesSlipSearchResult2.LogicalDeleteCode)
    //             && (salesSlipSearchResult1.AcptAnOdrStatus == salesSlipSearchResult2.AcptAnOdrStatus)
    //             && (salesSlipSearchResult1.SalesSlipNum == salesSlipSearchResult2.SalesSlipNum)
    //             && (salesSlipSearchResult1.SectionCode == salesSlipSearchResult2.SectionCode)
    //             && (salesSlipSearchResult1.SectionGuideNm == salesSlipSearchResult2.SectionGuideNm)
    //             && (salesSlipSearchResult1.SubSectionCode == salesSlipSearchResult2.SubSectionCode)
    //             && (salesSlipSearchResult1.SubSectionName == salesSlipSearchResult2.SubSectionName)
    //             && (salesSlipSearchResult1.DebitNoteDiv == salesSlipSearchResult2.DebitNoteDiv)
    //             && (salesSlipSearchResult1.DebitNLnkSalesSlNum == salesSlipSearchResult2.DebitNLnkSalesSlNum)
    //             && (salesSlipSearchResult1.SalesSlipCd == salesSlipSearchResult2.SalesSlipCd)
    //             && (salesSlipSearchResult1.SalesGoodsCd == salesSlipSearchResult2.SalesGoodsCd)
    //             && (salesSlipSearchResult1.AccRecDivCd == salesSlipSearchResult2.AccRecDivCd)
    //             && (salesSlipSearchResult1.SalesInpSecCd == salesSlipSearchResult2.SalesInpSecCd)
    //             && (salesSlipSearchResult1.DemandAddUpSecCd == salesSlipSearchResult2.DemandAddUpSecCd)
    //             && (salesSlipSearchResult1.ResultsAddUpSecCd == salesSlipSearchResult2.ResultsAddUpSecCd)
    //             && (salesSlipSearchResult1.UpdateSecCd == salesSlipSearchResult2.UpdateSecCd)
    //             && (salesSlipSearchResult1.SearchSlipDate == salesSlipSearchResult2.SearchSlipDate)
    //             && (salesSlipSearchResult1.ShipmentDay == salesSlipSearchResult2.ShipmentDay)
    //             && (salesSlipSearchResult1.SalesDate == salesSlipSearchResult2.SalesDate)
    //             && (salesSlipSearchResult1.AddUpADate == salesSlipSearchResult2.AddUpADate)
    //             && (salesSlipSearchResult1.DelayPaymentDiv == salesSlipSearchResult2.DelayPaymentDiv)
    //             && (salesSlipSearchResult1.EstimateFormNo == salesSlipSearchResult2.EstimateFormNo)
    //             && (salesSlipSearchResult1.EstimateDivide == salesSlipSearchResult2.EstimateDivide)
    //             && (salesSlipSearchResult1.InputAgenCd == salesSlipSearchResult2.InputAgenCd)
    //             && (salesSlipSearchResult1.InputAgenNm == salesSlipSearchResult2.InputAgenNm)
    //             && (salesSlipSearchResult1.SalesInputCode == salesSlipSearchResult2.SalesInputCode)
    //             && (salesSlipSearchResult1.SalesInputName == salesSlipSearchResult2.SalesInputName)
    //             && (salesSlipSearchResult1.FrontEmployeeCd == salesSlipSearchResult2.FrontEmployeeCd)
    //             && (salesSlipSearchResult1.FrontEmployeeNm == salesSlipSearchResult2.FrontEmployeeNm)
    //             && (salesSlipSearchResult1.SalesEmployeeCd == salesSlipSearchResult2.SalesEmployeeCd)
    //             && (salesSlipSearchResult1.SalesEmployeeNm == salesSlipSearchResult2.SalesEmployeeNm)
    //             && (salesSlipSearchResult1.TotalAmountDispWayCd == salesSlipSearchResult2.TotalAmountDispWayCd)
    //             && (salesSlipSearchResult1.TtlAmntDispRateApy == salesSlipSearchResult2.TtlAmntDispRateApy)
    //             && (salesSlipSearchResult1.SalesTotalTaxInc == salesSlipSearchResult2.SalesTotalTaxInc)
    //             && (salesSlipSearchResult1.SalesTotalTaxExc == salesSlipSearchResult2.SalesTotalTaxExc)
    //             && (salesSlipSearchResult1.SalesPrtTotalTaxInc == salesSlipSearchResult2.SalesPrtTotalTaxInc)
    //             && (salesSlipSearchResult1.SalesPrtTotalTaxExc == salesSlipSearchResult2.SalesPrtTotalTaxExc)
    //             && (salesSlipSearchResult1.SalesWorkTotalTaxInc == salesSlipSearchResult2.SalesWorkTotalTaxInc)
    //             && (salesSlipSearchResult1.SalesWorkTotalTaxExc == salesSlipSearchResult2.SalesWorkTotalTaxExc)
    //             && (salesSlipSearchResult1.SalesSubtotalTaxInc == salesSlipSearchResult2.SalesSubtotalTaxInc)
    //             && (salesSlipSearchResult1.SalesSubtotalTaxExc == salesSlipSearchResult2.SalesSubtotalTaxExc)
    //             && (salesSlipSearchResult1.SalesPrtSubttlInc == salesSlipSearchResult2.SalesPrtSubttlInc)
    //             && (salesSlipSearchResult1.SalesPrtSubttlExc == salesSlipSearchResult2.SalesPrtSubttlExc)
    //             && (salesSlipSearchResult1.SalesWorkSubttlInc == salesSlipSearchResult2.SalesWorkSubttlInc)
    //             && (salesSlipSearchResult1.SalesWorkSubttlExc == salesSlipSearchResult2.SalesWorkSubttlExc)
    //             && (salesSlipSearchResult1.SalesNetPrice == salesSlipSearchResult2.SalesNetPrice)
    //             && (salesSlipSearchResult1.SalesSubtotalTax == salesSlipSearchResult2.SalesSubtotalTax)
    //             && (salesSlipSearchResult1.ItdedSalesOutTax == salesSlipSearchResult2.ItdedSalesOutTax)
    //             && (salesSlipSearchResult1.ItdedSalesInTax == salesSlipSearchResult2.ItdedSalesInTax)
    //             && (salesSlipSearchResult1.SalSubttlSubToTaxFre == salesSlipSearchResult2.SalSubttlSubToTaxFre)
    //             && (salesSlipSearchResult1.SalesOutTax == salesSlipSearchResult2.SalesOutTax)
    //             && (salesSlipSearchResult1.SalAmntConsTaxInclu == salesSlipSearchResult2.SalAmntConsTaxInclu)
    //             && (salesSlipSearchResult1.SalesDisTtlTaxExc == salesSlipSearchResult2.SalesDisTtlTaxExc)
    //             && (salesSlipSearchResult1.ItdedSalesDisOutTax == salesSlipSearchResult2.ItdedSalesDisOutTax)
    //             && (salesSlipSearchResult1.ItdedSalesDisInTax == salesSlipSearchResult2.ItdedSalesDisInTax)
    //             && (salesSlipSearchResult1.ItdedPartsDisOutTax == salesSlipSearchResult2.ItdedPartsDisOutTax)
    //             && (salesSlipSearchResult1.ItdedPartsDisInTax == salesSlipSearchResult2.ItdedPartsDisInTax)
    //             && (salesSlipSearchResult1.ItdedWorkDisOutTax == salesSlipSearchResult2.ItdedWorkDisOutTax)
    //             && (salesSlipSearchResult1.ItdedWorkDisInTax == salesSlipSearchResult2.ItdedWorkDisInTax)
    //             && (salesSlipSearchResult1.ItdedSalesDisTaxFre == salesSlipSearchResult2.ItdedSalesDisTaxFre)
    //             && (salesSlipSearchResult1.SalesDisOutTax == salesSlipSearchResult2.SalesDisOutTax)
    //             && (salesSlipSearchResult1.SalesDisTtlTaxInclu == salesSlipSearchResult2.SalesDisTtlTaxInclu)
    //             && (salesSlipSearchResult1.PartsDiscountRate == salesSlipSearchResult2.PartsDiscountRate)
    //             && (salesSlipSearchResult1.RavorDiscountRate == salesSlipSearchResult2.RavorDiscountRate)
    //             && (salesSlipSearchResult1.TotalCost == salesSlipSearchResult2.TotalCost)
    //             && (salesSlipSearchResult1.ConsTaxLayMethod == salesSlipSearchResult2.ConsTaxLayMethod)
    //             && (salesSlipSearchResult1.ConsTaxRate == salesSlipSearchResult2.ConsTaxRate)
    //             && (salesSlipSearchResult1.FractionProcCd == salesSlipSearchResult2.FractionProcCd)
    //             && (salesSlipSearchResult1.AccRecConsTax == salesSlipSearchResult2.AccRecConsTax)
    //             && (salesSlipSearchResult1.AutoDepositCd == salesSlipSearchResult2.AutoDepositCd)
    //             && (salesSlipSearchResult1.AutoDepositSlipNo == salesSlipSearchResult2.AutoDepositSlipNo)
    //             && (salesSlipSearchResult1.DepositAllowanceTtl == salesSlipSearchResult2.DepositAllowanceTtl)
    //             && (salesSlipSearchResult1.DepositAlwcBlnce == salesSlipSearchResult2.DepositAlwcBlnce)
    //             && (salesSlipSearchResult1.ClaimCode == salesSlipSearchResult2.ClaimCode)
    //             && (salesSlipSearchResult1.ClaimSnm == salesSlipSearchResult2.ClaimSnm)
    //             && (salesSlipSearchResult1.CustomerCode == salesSlipSearchResult2.CustomerCode)
    //             && (salesSlipSearchResult1.CustomerName == salesSlipSearchResult2.CustomerName)
    //             && (salesSlipSearchResult1.CustomerName2 == salesSlipSearchResult2.CustomerName2)
    //             && (salesSlipSearchResult1.CustomerSnm == salesSlipSearchResult2.CustomerSnm)
    //             && (salesSlipSearchResult1.HonorificTitle == salesSlipSearchResult2.HonorificTitle)
    //             && (salesSlipSearchResult1.OutputName == salesSlipSearchResult2.OutputName)
    //             && (salesSlipSearchResult1.CustSlipNo == salesSlipSearchResult2.CustSlipNo)
    //             && (salesSlipSearchResult1.SlipAddressDiv == salesSlipSearchResult2.SlipAddressDiv)
    //             && (salesSlipSearchResult1.AddresseeCode == salesSlipSearchResult2.AddresseeCode)
    //             && (salesSlipSearchResult1.AddresseeName == salesSlipSearchResult2.AddresseeName)
    //             && (salesSlipSearchResult1.AddresseeName2 == salesSlipSearchResult2.AddresseeName2)
    //             && (salesSlipSearchResult1.AddresseePostNo == salesSlipSearchResult2.AddresseePostNo)
    //             && (salesSlipSearchResult1.AddresseeAddr1 == salesSlipSearchResult2.AddresseeAddr1)
    //             && (salesSlipSearchResult1.AddresseeAddr3 == salesSlipSearchResult2.AddresseeAddr3)
    //             && (salesSlipSearchResult1.AddresseeAddr4 == salesSlipSearchResult2.AddresseeAddr4)
    //             && (salesSlipSearchResult1.AddresseeTelNo == salesSlipSearchResult2.AddresseeTelNo)
    //             && (salesSlipSearchResult1.AddresseeFaxNo == salesSlipSearchResult2.AddresseeFaxNo)
    //             && (salesSlipSearchResult1.PartySaleSlipNum == salesSlipSearchResult2.PartySaleSlipNum)
    //             && (salesSlipSearchResult1.SlipNote == salesSlipSearchResult2.SlipNote)
    //             && (salesSlipSearchResult1.SlipNote2 == salesSlipSearchResult2.SlipNote2)
    //             && (salesSlipSearchResult1.SlipNote3 == salesSlipSearchResult2.SlipNote3)
    //             && (salesSlipSearchResult1.RetGoodsReasonDiv == salesSlipSearchResult2.RetGoodsReasonDiv)
    //             && (salesSlipSearchResult1.RetGoodsReason == salesSlipSearchResult2.RetGoodsReason)
    //             && (salesSlipSearchResult1.RegiProcDate == salesSlipSearchResult2.RegiProcDate)
    //             && (salesSlipSearchResult1.CashRegisterNo == salesSlipSearchResult2.CashRegisterNo)
    //             && (salesSlipSearchResult1.PosReceiptNo == salesSlipSearchResult2.PosReceiptNo)
    //             && (salesSlipSearchResult1.DetailRowCount == salesSlipSearchResult2.DetailRowCount)
    //             && (salesSlipSearchResult1.EdiSendDate == salesSlipSearchResult2.EdiSendDate)
    //             && (salesSlipSearchResult1.EdiTakeInDate == salesSlipSearchResult2.EdiTakeInDate)
    //             && (salesSlipSearchResult1.UoeRemark1 == salesSlipSearchResult2.UoeRemark1)
    //             && (salesSlipSearchResult1.UoeRemark2 == salesSlipSearchResult2.UoeRemark2)
    //             && (salesSlipSearchResult1.SlipPrintDivCd == salesSlipSearchResult2.SlipPrintDivCd)
    //             && (salesSlipSearchResult1.SlipPrintFinishCd == salesSlipSearchResult2.SlipPrintFinishCd)
    //             && (salesSlipSearchResult1.SalesSlipPrintDate == salesSlipSearchResult2.SalesSlipPrintDate)
    //             && (salesSlipSearchResult1.BusinessTypeCode == salesSlipSearchResult2.BusinessTypeCode)
    //             && (salesSlipSearchResult1.BusinessTypeName == salesSlipSearchResult2.BusinessTypeName)
    //             && (salesSlipSearchResult1.OrderNumber == salesSlipSearchResult2.OrderNumber)
    //             && (salesSlipSearchResult1.DeliveredGoodsDiv == salesSlipSearchResult2.DeliveredGoodsDiv)
    //             && (salesSlipSearchResult1.DeliveredGoodsDivNm == salesSlipSearchResult2.DeliveredGoodsDivNm)
    //             && (salesSlipSearchResult1.SalesAreaCode == salesSlipSearchResult2.SalesAreaCode)
    //             && (salesSlipSearchResult1.SalesAreaName == salesSlipSearchResult2.SalesAreaName)
    //             && (salesSlipSearchResult1.ReconcileFlag == salesSlipSearchResult2.ReconcileFlag)
    //             && (salesSlipSearchResult1.SlipPrtSetPaperId == salesSlipSearchResult2.SlipPrtSetPaperId)
    //             && (salesSlipSearchResult1.CompleteCd == salesSlipSearchResult2.CompleteCd)
    //             && (salesSlipSearchResult1.SalesPriceFracProcCd == salesSlipSearchResult2.SalesPriceFracProcCd)
    //             && (salesSlipSearchResult1.StockGoodsTtlTaxExc == salesSlipSearchResult2.StockGoodsTtlTaxExc)
    //             && (salesSlipSearchResult1.PureGoodsTtlTaxExc == salesSlipSearchResult2.PureGoodsTtlTaxExc)
    //             && (salesSlipSearchResult1.ListPricePrintDiv == salesSlipSearchResult2.ListPricePrintDiv)
    //             && (salesSlipSearchResult1.EraNameDispCd1 == salesSlipSearchResult2.EraNameDispCd1)
    //             && (salesSlipSearchResult1.EstimaTaxDivCd == salesSlipSearchResult2.EstimaTaxDivCd)
    //             && (salesSlipSearchResult1.EstimateFormPrtCd == salesSlipSearchResult2.EstimateFormPrtCd)
    //             && (salesSlipSearchResult1.EstimateSubject == salesSlipSearchResult2.EstimateSubject)
    //             && (salesSlipSearchResult1.Footnotes1 == salesSlipSearchResult2.Footnotes1)
    //             && (salesSlipSearchResult1.Footnotes2 == salesSlipSearchResult2.Footnotes2)
    //             && (salesSlipSearchResult1.EstimateTitle1 == salesSlipSearchResult2.EstimateTitle1)
    //             && (salesSlipSearchResult1.EstimateTitle2 == salesSlipSearchResult2.EstimateTitle2)
    //             && (salesSlipSearchResult1.EstimateTitle3 == salesSlipSearchResult2.EstimateTitle3)
    //             && (salesSlipSearchResult1.EstimateTitle4 == salesSlipSearchResult2.EstimateTitle4)
    //             && (salesSlipSearchResult1.EstimateTitle5 == salesSlipSearchResult2.EstimateTitle5)
    //             && (salesSlipSearchResult1.EstimateNote1 == salesSlipSearchResult2.EstimateNote1)
    //             && (salesSlipSearchResult1.EstimateNote2 == salesSlipSearchResult2.EstimateNote2)
    //             && (salesSlipSearchResult1.EstimateNote3 == salesSlipSearchResult2.EstimateNote3)
    //             && (salesSlipSearchResult1.EstimateNote4 == salesSlipSearchResult2.EstimateNote4)
    //             && (salesSlipSearchResult1.EstimateNote5 == salesSlipSearchResult2.EstimateNote5)
    //             && (salesSlipSearchResult1.EstimateValidityDate == salesSlipSearchResult2.EstimateValidityDate)
    //             && (salesSlipSearchResult1.PartsNoPrtCd == salesSlipSearchResult2.PartsNoPrtCd)
    //             && (salesSlipSearchResult1.OptionPringDivCd == salesSlipSearchResult2.OptionPringDivCd)
    //             && (salesSlipSearchResult1.RateUseCode == salesSlipSearchResult2.RateUseCode)
    //             && (salesSlipSearchResult1.CarMngCode == salesSlipSearchResult2.CarMngCode)
    //             && (salesSlipSearchResult1.ModelDesignationNo == salesSlipSearchResult2.ModelDesignationNo)
    //             && (salesSlipSearchResult1.CategoryNo == salesSlipSearchResult2.CategoryNo)
    //             && (salesSlipSearchResult1.MakerFullName == salesSlipSearchResult2.MakerFullName)
    //             && (salesSlipSearchResult1.FullModel == salesSlipSearchResult2.FullModel)
    //             && (salesSlipSearchResult1.EnterpriseName == salesSlipSearchResult2.EnterpriseName)
    //             && (salesSlipSearchResult1.ResultsAddUpSecNm == salesSlipSearchResult2.ResultsAddUpSecNm));
    //    }
    //    /// <summary>
    //    /// 売上伝票検索抽出結果比較処理
    //    /// </summary>
    //    /// <param name="target">比較対象のSalesSlipSearchResultクラスのインスタンス</param>
    //    /// <returns>一致しない項目のリスト</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SalesSlipSearchResultクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public ArrayList Compare(SalesSlipSearchResult target)
    //    {
    //        ArrayList resList = new ArrayList();
    //        if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
    //        if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
    //        if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
    //        if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
    //        if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
    //        if (this.SectionGuideNm != target.SectionGuideNm) resList.Add("SectionGuideNm");
    //        if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
    //        if (this.SubSectionName != target.SubSectionName) resList.Add("SubSectionName");
    //        if (this.DebitNoteDiv != target.DebitNoteDiv) resList.Add("DebitNoteDiv");
    //        if (this.DebitNLnkSalesSlNum != target.DebitNLnkSalesSlNum) resList.Add("DebitNLnkSalesSlNum");
    //        if (this.SalesSlipCd != target.SalesSlipCd) resList.Add("SalesSlipCd");
    //        if (this.SalesGoodsCd != target.SalesGoodsCd) resList.Add("SalesGoodsCd");
    //        if (this.AccRecDivCd != target.AccRecDivCd) resList.Add("AccRecDivCd");
    //        if (this.SalesInpSecCd != target.SalesInpSecCd) resList.Add("SalesInpSecCd");
    //        if (this.DemandAddUpSecCd != target.DemandAddUpSecCd) resList.Add("DemandAddUpSecCd");
    //        if (this.ResultsAddUpSecCd != target.ResultsAddUpSecCd) resList.Add("ResultsAddUpSecCd");
    //        if (this.UpdateSecCd != target.UpdateSecCd) resList.Add("UpdateSecCd");
    //        if (this.SearchSlipDate != target.SearchSlipDate) resList.Add("SearchSlipDate");
    //        if (this.ShipmentDay != target.ShipmentDay) resList.Add("ShipmentDay");
    //        if (this.SalesDate != target.SalesDate) resList.Add("SalesDate");
    //        if (this.AddUpADate != target.AddUpADate) resList.Add("AddUpADate");
    //        if (this.DelayPaymentDiv != target.DelayPaymentDiv) resList.Add("DelayPaymentDiv");
    //        if (this.EstimateFormNo != target.EstimateFormNo) resList.Add("EstimateFormNo");
    //        if (this.EstimateDivide != target.EstimateDivide) resList.Add("EstimateDivide");
    //        if (this.InputAgenCd != target.InputAgenCd) resList.Add("InputAgenCd");
    //        if (this.InputAgenNm != target.InputAgenNm) resList.Add("InputAgenNm");
    //        if (this.SalesInputCode != target.SalesInputCode) resList.Add("SalesInputCode");
    //        if (this.SalesInputName != target.SalesInputName) resList.Add("SalesInputName");
    //        if (this.FrontEmployeeCd != target.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
    //        if (this.FrontEmployeeNm != target.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
    //        if (this.SalesEmployeeCd != target.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
    //        if (this.SalesEmployeeNm != target.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
    //        if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
    //        if (this.TtlAmntDispRateApy != target.TtlAmntDispRateApy) resList.Add("TtlAmntDispRateApy");
    //        if (this.SalesTotalTaxInc != target.SalesTotalTaxInc) resList.Add("SalesTotalTaxInc");
    //        if (this.SalesTotalTaxExc != target.SalesTotalTaxExc) resList.Add("SalesTotalTaxExc");
    //        if (this.SalesPrtTotalTaxInc != target.SalesPrtTotalTaxInc) resList.Add("SalesPrtTotalTaxInc");
    //        if (this.SalesPrtTotalTaxExc != target.SalesPrtTotalTaxExc) resList.Add("SalesPrtTotalTaxExc");
    //        if (this.SalesWorkTotalTaxInc != target.SalesWorkTotalTaxInc) resList.Add("SalesWorkTotalTaxInc");
    //        if (this.SalesWorkTotalTaxExc != target.SalesWorkTotalTaxExc) resList.Add("SalesWorkTotalTaxExc");
    //        if (this.SalesSubtotalTaxInc != target.SalesSubtotalTaxInc) resList.Add("SalesSubtotalTaxInc");
    //        if (this.SalesSubtotalTaxExc != target.SalesSubtotalTaxExc) resList.Add("SalesSubtotalTaxExc");
    //        if (this.SalesPrtSubttlInc != target.SalesPrtSubttlInc) resList.Add("SalesPrtSubttlInc");
    //        if (this.SalesPrtSubttlExc != target.SalesPrtSubttlExc) resList.Add("SalesPrtSubttlExc");
    //        if (this.SalesWorkSubttlInc != target.SalesWorkSubttlInc) resList.Add("SalesWorkSubttlInc");
    //        if (this.SalesWorkSubttlExc != target.SalesWorkSubttlExc) resList.Add("SalesWorkSubttlExc");
    //        if (this.SalesNetPrice != target.SalesNetPrice) resList.Add("SalesNetPrice");
    //        if (this.SalesSubtotalTax != target.SalesSubtotalTax) resList.Add("SalesSubtotalTax");
    //        if (this.ItdedSalesOutTax != target.ItdedSalesOutTax) resList.Add("ItdedSalesOutTax");
    //        if (this.ItdedSalesInTax != target.ItdedSalesInTax) resList.Add("ItdedSalesInTax");
    //        if (this.SalSubttlSubToTaxFre != target.SalSubttlSubToTaxFre) resList.Add("SalSubttlSubToTaxFre");
    //        if (this.SalesOutTax != target.SalesOutTax) resList.Add("SalesOutTax");
    //        if (this.SalAmntConsTaxInclu != target.SalAmntConsTaxInclu) resList.Add("SalAmntConsTaxInclu");
    //        if (this.SalesDisTtlTaxExc != target.SalesDisTtlTaxExc) resList.Add("SalesDisTtlTaxExc");
    //        if (this.ItdedSalesDisOutTax != target.ItdedSalesDisOutTax) resList.Add("ItdedSalesDisOutTax");
    //        if (this.ItdedSalesDisInTax != target.ItdedSalesDisInTax) resList.Add("ItdedSalesDisInTax");
    //        if (this.ItdedPartsDisOutTax != target.ItdedPartsDisOutTax) resList.Add("ItdedPartsDisOutTax");
    //        if (this.ItdedPartsDisInTax != target.ItdedPartsDisInTax) resList.Add("ItdedPartsDisInTax");
    //        if (this.ItdedWorkDisOutTax != target.ItdedWorkDisOutTax) resList.Add("ItdedWorkDisOutTax");
    //        if (this.ItdedWorkDisInTax != target.ItdedWorkDisInTax) resList.Add("ItdedWorkDisInTax");
    //        if (this.ItdedSalesDisTaxFre != target.ItdedSalesDisTaxFre) resList.Add("ItdedSalesDisTaxFre");
    //        if (this.SalesDisOutTax != target.SalesDisOutTax) resList.Add("SalesDisOutTax");
    //        if (this.SalesDisTtlTaxInclu != target.SalesDisTtlTaxInclu) resList.Add("SalesDisTtlTaxInclu");
    //        if (this.PartsDiscountRate != target.PartsDiscountRate) resList.Add("PartsDiscountRate");
    //        if (this.RavorDiscountRate != target.RavorDiscountRate) resList.Add("RavorDiscountRate");
    //        if (this.TotalCost != target.TotalCost) resList.Add("TotalCost");
    //        if (this.ConsTaxLayMethod != target.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
    //        if (this.ConsTaxRate != target.ConsTaxRate) resList.Add("ConsTaxRate");
    //        if (this.FractionProcCd != target.FractionProcCd) resList.Add("FractionProcCd");
    //        if (this.AccRecConsTax != target.AccRecConsTax) resList.Add("AccRecConsTax");
    //        if (this.AutoDepositCd != target.AutoDepositCd) resList.Add("AutoDepositCd");
    //        if (this.AutoDepositSlipNo != target.AutoDepositSlipNo) resList.Add("AutoDepositSlipNo");
    //        if (this.DepositAllowanceTtl != target.DepositAllowanceTtl) resList.Add("DepositAllowanceTtl");
    //        if (this.DepositAlwcBlnce != target.DepositAlwcBlnce) resList.Add("DepositAlwcBlnce");
    //        if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
    //        if (this.ClaimSnm != target.ClaimSnm) resList.Add("ClaimSnm");
    //        if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
    //        if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
    //        if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
    //        if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
    //        if (this.HonorificTitle != target.HonorificTitle) resList.Add("HonorificTitle");
    //        if (this.OutputName != target.OutputName) resList.Add("OutputName");
    //        if (this.CustSlipNo != target.CustSlipNo) resList.Add("CustSlipNo");
    //        if (this.SlipAddressDiv != target.SlipAddressDiv) resList.Add("SlipAddressDiv");
    //        if (this.AddresseeCode != target.AddresseeCode) resList.Add("AddresseeCode");
    //        if (this.AddresseeName != target.AddresseeName) resList.Add("AddresseeName");
    //        if (this.AddresseeName2 != target.AddresseeName2) resList.Add("AddresseeName2");
    //        if (this.AddresseePostNo != target.AddresseePostNo) resList.Add("AddresseePostNo");
    //        if (this.AddresseeAddr1 != target.AddresseeAddr1) resList.Add("AddresseeAddr1");
    //        if (this.AddresseeAddr3 != target.AddresseeAddr3) resList.Add("AddresseeAddr3");
    //        if (this.AddresseeAddr4 != target.AddresseeAddr4) resList.Add("AddresseeAddr4");
    //        if (this.AddresseeTelNo != target.AddresseeTelNo) resList.Add("AddresseeTelNo");
    //        if (this.AddresseeFaxNo != target.AddresseeFaxNo) resList.Add("AddresseeFaxNo");
    //        if (this.PartySaleSlipNum != target.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
    //        if (this.SlipNote != target.SlipNote) resList.Add("SlipNote");
    //        if (this.SlipNote2 != target.SlipNote2) resList.Add("SlipNote2");
    //        if (this.SlipNote3 != target.SlipNote3) resList.Add("SlipNote3");
    //        if (this.RetGoodsReasonDiv != target.RetGoodsReasonDiv) resList.Add("RetGoodsReasonDiv");
    //        if (this.RetGoodsReason != target.RetGoodsReason) resList.Add("RetGoodsReason");
    //        if (this.RegiProcDate != target.RegiProcDate) resList.Add("RegiProcDate");
    //        if (this.CashRegisterNo != target.CashRegisterNo) resList.Add("CashRegisterNo");
    //        if (this.PosReceiptNo != target.PosReceiptNo) resList.Add("PosReceiptNo");
    //        if (this.DetailRowCount != target.DetailRowCount) resList.Add("DetailRowCount");
    //        if (this.EdiSendDate != target.EdiSendDate) resList.Add("EdiSendDate");
    //        if (this.EdiTakeInDate != target.EdiTakeInDate) resList.Add("EdiTakeInDate");
    //        if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
    //        if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
    //        if (this.SlipPrintDivCd != target.SlipPrintDivCd) resList.Add("SlipPrintDivCd");
    //        if (this.SlipPrintFinishCd != target.SlipPrintFinishCd) resList.Add("SlipPrintFinishCd");
    //        if (this.SalesSlipPrintDate != target.SalesSlipPrintDate) resList.Add("SalesSlipPrintDate");
    //        if (this.BusinessTypeCode != target.BusinessTypeCode) resList.Add("BusinessTypeCode");
    //        if (this.BusinessTypeName != target.BusinessTypeName) resList.Add("BusinessTypeName");
    //        if (this.OrderNumber != target.OrderNumber) resList.Add("OrderNumber");
    //        if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
    //        if (this.DeliveredGoodsDivNm != target.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
    //        if (this.SalesAreaCode != target.SalesAreaCode) resList.Add("SalesAreaCode");
    //        if (this.SalesAreaName != target.SalesAreaName) resList.Add("SalesAreaName");
    //        if (this.ReconcileFlag != target.ReconcileFlag) resList.Add("ReconcileFlag");
    //        if (this.SlipPrtSetPaperId != target.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
    //        if (this.CompleteCd != target.CompleteCd) resList.Add("CompleteCd");
    //        if (this.SalesPriceFracProcCd != target.SalesPriceFracProcCd) resList.Add("SalesPriceFracProcCd");
    //        if (this.StockGoodsTtlTaxExc != target.StockGoodsTtlTaxExc) resList.Add("StockGoodsTtlTaxExc");
    //        if (this.PureGoodsTtlTaxExc != target.PureGoodsTtlTaxExc) resList.Add("PureGoodsTtlTaxExc");
    //        if (this.ListPricePrintDiv != target.ListPricePrintDiv) resList.Add("ListPricePrintDiv");
    //        if (this.EraNameDispCd1 != target.EraNameDispCd1) resList.Add("EraNameDispCd1");
    //        if (this.EstimaTaxDivCd != target.EstimaTaxDivCd) resList.Add("EstimaTaxDivCd");
    //        if (this.EstimateFormPrtCd != target.EstimateFormPrtCd) resList.Add("EstimateFormPrtCd");
    //        if (this.EstimateSubject != target.EstimateSubject) resList.Add("EstimateSubject");
    //        if (this.Footnotes1 != target.Footnotes1) resList.Add("Footnotes1");
    //        if (this.Footnotes2 != target.Footnotes2) resList.Add("Footnotes2");
    //        if (this.EstimateTitle1 != target.EstimateTitle1) resList.Add("EstimateTitle1");
    //        if (this.EstimateTitle2 != target.EstimateTitle2) resList.Add("EstimateTitle2");
    //        if (this.EstimateTitle3 != target.EstimateTitle3) resList.Add("EstimateTitle3");
    //        if (this.EstimateTitle4 != target.EstimateTitle4) resList.Add("EstimateTitle4");
    //        if (this.EstimateTitle5 != target.EstimateTitle5) resList.Add("EstimateTitle5");
    //        if (this.EstimateNote1 != target.EstimateNote1) resList.Add("EstimateNote1");
    //        if (this.EstimateNote2 != target.EstimateNote2) resList.Add("EstimateNote2");
    //        if (this.EstimateNote3 != target.EstimateNote3) resList.Add("EstimateNote3");
    //        if (this.EstimateNote4 != target.EstimateNote4) resList.Add("EstimateNote4");
    //        if (this.EstimateNote5 != target.EstimateNote5) resList.Add("EstimateNote5");
    //        if (this.EstimateValidityDate != target.EstimateValidityDate) resList.Add("EstimateValidityDate");
    //        if (this.PartsNoPrtCd != target.PartsNoPrtCd) resList.Add("PartsNoPrtCd");
    //        if (this.OptionPringDivCd != target.OptionPringDivCd) resList.Add("OptionPringDivCd");
    //        if (this.RateUseCode != target.RateUseCode) resList.Add("RateUseCode");
    //        if (this.CarMngCode != target.CarMngCode) resList.Add("CarMngNo");
    //        if (this.ModelDesignationNo != target.ModelDesignationNo) resList.Add("ModelDesignationNo");
    //        if (this.CategoryNo != target.CategoryNo) resList.Add("CategoryNo");
    //        if (this.MakerFullName != target.MakerFullName) resList.Add("MakerFullName");
    //        if (this.FullModel != target.FullModel) resList.Add("FullModel");
    //        if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
    //        if (this.ResultsAddUpSecNm != target.ResultsAddUpSecNm) resList.Add("ResultsAddUpSecNm");

    //        return resList;
    //    }

    //    /// <summary>
    //    /// 売上伝票検索抽出結果比較処理
    //    /// </summary>
    //    /// <param name="salesSlipSearchResult1">比較するSalesSlipSearchResultクラスのインスタンス</param>
    //    /// <param name="salesSlipSearchResult2">比較するSalesSlipSearchResultクラスのインスタンス</param>
    //    /// <returns>一致しない項目のリスト</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SalesSlipSearchResultクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public static ArrayList Compare(SalesSlipSearchResult salesSlipSearchResult1, SalesSlipSearchResult salesSlipSearchResult2)
    //    {
    //        ArrayList resList = new ArrayList();
    //        if (salesSlipSearchResult1.EnterpriseCode != salesSlipSearchResult2.EnterpriseCode) resList.Add("EnterpriseCode");
    //        if (salesSlipSearchResult1.LogicalDeleteCode != salesSlipSearchResult2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
    //        if (salesSlipSearchResult1.AcptAnOdrStatus != salesSlipSearchResult2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
    //        if (salesSlipSearchResult1.SalesSlipNum != salesSlipSearchResult2.SalesSlipNum) resList.Add("SalesSlipNum");
    //        if (salesSlipSearchResult1.SectionCode != salesSlipSearchResult2.SectionCode) resList.Add("SectionCode");
    //        if (salesSlipSearchResult1.SectionGuideNm != salesSlipSearchResult2.SectionGuideNm) resList.Add("SectionGuideNm");
    //        if (salesSlipSearchResult1.SubSectionCode != salesSlipSearchResult2.SubSectionCode) resList.Add("SubSectionCode");
    //        if (salesSlipSearchResult1.SubSectionName != salesSlipSearchResult2.SubSectionName) resList.Add("SubSectionName");
    //        if (salesSlipSearchResult1.DebitNoteDiv != salesSlipSearchResult2.DebitNoteDiv) resList.Add("DebitNoteDiv");
    //        if (salesSlipSearchResult1.DebitNLnkSalesSlNum != salesSlipSearchResult2.DebitNLnkSalesSlNum) resList.Add("DebitNLnkSalesSlNum");
    //        if (salesSlipSearchResult1.SalesSlipCd != salesSlipSearchResult2.SalesSlipCd) resList.Add("SalesSlipCd");
    //        if (salesSlipSearchResult1.SalesGoodsCd != salesSlipSearchResult2.SalesGoodsCd) resList.Add("SalesGoodsCd");
    //        if (salesSlipSearchResult1.AccRecDivCd != salesSlipSearchResult2.AccRecDivCd) resList.Add("AccRecDivCd");
    //        if (salesSlipSearchResult1.SalesInpSecCd != salesSlipSearchResult2.SalesInpSecCd) resList.Add("SalesInpSecCd");
    //        if (salesSlipSearchResult1.DemandAddUpSecCd != salesSlipSearchResult2.DemandAddUpSecCd) resList.Add("DemandAddUpSecCd");
    //        if (salesSlipSearchResult1.ResultsAddUpSecCd != salesSlipSearchResult2.ResultsAddUpSecCd) resList.Add("ResultsAddUpSecCd");
    //        if (salesSlipSearchResult1.UpdateSecCd != salesSlipSearchResult2.UpdateSecCd) resList.Add("UpdateSecCd");
    //        if (salesSlipSearchResult1.SearchSlipDate != salesSlipSearchResult2.SearchSlipDate) resList.Add("SearchSlipDate");
    //        if (salesSlipSearchResult1.ShipmentDay != salesSlipSearchResult2.ShipmentDay) resList.Add("ShipmentDay");
    //        if (salesSlipSearchResult1.SalesDate != salesSlipSearchResult2.SalesDate) resList.Add("SalesDate");
    //        if (salesSlipSearchResult1.AddUpADate != salesSlipSearchResult2.AddUpADate) resList.Add("AddUpADate");
    //        if (salesSlipSearchResult1.DelayPaymentDiv != salesSlipSearchResult2.DelayPaymentDiv) resList.Add("DelayPaymentDiv");
    //        if (salesSlipSearchResult1.EstimateFormNo != salesSlipSearchResult2.EstimateFormNo) resList.Add("EstimateFormNo");
    //        if (salesSlipSearchResult1.EstimateDivide != salesSlipSearchResult2.EstimateDivide) resList.Add("EstimateDivide");
    //        if (salesSlipSearchResult1.InputAgenCd != salesSlipSearchResult2.InputAgenCd) resList.Add("InputAgenCd");
    //        if (salesSlipSearchResult1.InputAgenNm != salesSlipSearchResult2.InputAgenNm) resList.Add("InputAgenNm");
    //        if (salesSlipSearchResult1.SalesInputCode != salesSlipSearchResult2.SalesInputCode) resList.Add("SalesInputCode");
    //        if (salesSlipSearchResult1.SalesInputName != salesSlipSearchResult2.SalesInputName) resList.Add("SalesInputName");
    //        if (salesSlipSearchResult1.FrontEmployeeCd != salesSlipSearchResult2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
    //        if (salesSlipSearchResult1.FrontEmployeeNm != salesSlipSearchResult2.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
    //        if (salesSlipSearchResult1.SalesEmployeeCd != salesSlipSearchResult2.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
    //        if (salesSlipSearchResult1.SalesEmployeeNm != salesSlipSearchResult2.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
    //        if (salesSlipSearchResult1.TotalAmountDispWayCd != salesSlipSearchResult2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
    //        if (salesSlipSearchResult1.TtlAmntDispRateApy != salesSlipSearchResult2.TtlAmntDispRateApy) resList.Add("TtlAmntDispRateApy");
    //        if (salesSlipSearchResult1.SalesTotalTaxInc != salesSlipSearchResult2.SalesTotalTaxInc) resList.Add("SalesTotalTaxInc");
    //        if (salesSlipSearchResult1.SalesTotalTaxExc != salesSlipSearchResult2.SalesTotalTaxExc) resList.Add("SalesTotalTaxExc");
    //        if (salesSlipSearchResult1.SalesPrtTotalTaxInc != salesSlipSearchResult2.SalesPrtTotalTaxInc) resList.Add("SalesPrtTotalTaxInc");
    //        if (salesSlipSearchResult1.SalesPrtTotalTaxExc != salesSlipSearchResult2.SalesPrtTotalTaxExc) resList.Add("SalesPrtTotalTaxExc");
    //        if (salesSlipSearchResult1.SalesWorkTotalTaxInc != salesSlipSearchResult2.SalesWorkTotalTaxInc) resList.Add("SalesWorkTotalTaxInc");
    //        if (salesSlipSearchResult1.SalesWorkTotalTaxExc != salesSlipSearchResult2.SalesWorkTotalTaxExc) resList.Add("SalesWorkTotalTaxExc");
    //        if (salesSlipSearchResult1.SalesSubtotalTaxInc != salesSlipSearchResult2.SalesSubtotalTaxInc) resList.Add("SalesSubtotalTaxInc");
    //        if (salesSlipSearchResult1.SalesSubtotalTaxExc != salesSlipSearchResult2.SalesSubtotalTaxExc) resList.Add("SalesSubtotalTaxExc");
    //        if (salesSlipSearchResult1.SalesPrtSubttlInc != salesSlipSearchResult2.SalesPrtSubttlInc) resList.Add("SalesPrtSubttlInc");
    //        if (salesSlipSearchResult1.SalesPrtSubttlExc != salesSlipSearchResult2.SalesPrtSubttlExc) resList.Add("SalesPrtSubttlExc");
    //        if (salesSlipSearchResult1.SalesWorkSubttlInc != salesSlipSearchResult2.SalesWorkSubttlInc) resList.Add("SalesWorkSubttlInc");
    //        if (salesSlipSearchResult1.SalesWorkSubttlExc != salesSlipSearchResult2.SalesWorkSubttlExc) resList.Add("SalesWorkSubttlExc");
    //        if (salesSlipSearchResult1.SalesNetPrice != salesSlipSearchResult2.SalesNetPrice) resList.Add("SalesNetPrice");
    //        if (salesSlipSearchResult1.SalesSubtotalTax != salesSlipSearchResult2.SalesSubtotalTax) resList.Add("SalesSubtotalTax");
    //        if (salesSlipSearchResult1.ItdedSalesOutTax != salesSlipSearchResult2.ItdedSalesOutTax) resList.Add("ItdedSalesOutTax");
    //        if (salesSlipSearchResult1.ItdedSalesInTax != salesSlipSearchResult2.ItdedSalesInTax) resList.Add("ItdedSalesInTax");
    //        if (salesSlipSearchResult1.SalSubttlSubToTaxFre != salesSlipSearchResult2.SalSubttlSubToTaxFre) resList.Add("SalSubttlSubToTaxFre");
    //        if (salesSlipSearchResult1.SalesOutTax != salesSlipSearchResult2.SalesOutTax) resList.Add("SalesOutTax");
    //        if (salesSlipSearchResult1.SalAmntConsTaxInclu != salesSlipSearchResult2.SalAmntConsTaxInclu) resList.Add("SalAmntConsTaxInclu");
    //        if (salesSlipSearchResult1.SalesDisTtlTaxExc != salesSlipSearchResult2.SalesDisTtlTaxExc) resList.Add("SalesDisTtlTaxExc");
    //        if (salesSlipSearchResult1.ItdedSalesDisOutTax != salesSlipSearchResult2.ItdedSalesDisOutTax) resList.Add("ItdedSalesDisOutTax");
    //        if (salesSlipSearchResult1.ItdedSalesDisInTax != salesSlipSearchResult2.ItdedSalesDisInTax) resList.Add("ItdedSalesDisInTax");
    //        if (salesSlipSearchResult1.ItdedPartsDisOutTax != salesSlipSearchResult2.ItdedPartsDisOutTax) resList.Add("ItdedPartsDisOutTax");
    //        if (salesSlipSearchResult1.ItdedPartsDisInTax != salesSlipSearchResult2.ItdedPartsDisInTax) resList.Add("ItdedPartsDisInTax");
    //        if (salesSlipSearchResult1.ItdedWorkDisOutTax != salesSlipSearchResult2.ItdedWorkDisOutTax) resList.Add("ItdedWorkDisOutTax");
    //        if (salesSlipSearchResult1.ItdedWorkDisInTax != salesSlipSearchResult2.ItdedWorkDisInTax) resList.Add("ItdedWorkDisInTax");
    //        if (salesSlipSearchResult1.ItdedSalesDisTaxFre != salesSlipSearchResult2.ItdedSalesDisTaxFre) resList.Add("ItdedSalesDisTaxFre");
    //        if (salesSlipSearchResult1.SalesDisOutTax != salesSlipSearchResult2.SalesDisOutTax) resList.Add("SalesDisOutTax");
    //        if (salesSlipSearchResult1.SalesDisTtlTaxInclu != salesSlipSearchResult2.SalesDisTtlTaxInclu) resList.Add("SalesDisTtlTaxInclu");
    //        if (salesSlipSearchResult1.PartsDiscountRate != salesSlipSearchResult2.PartsDiscountRate) resList.Add("PartsDiscountRate");
    //        if (salesSlipSearchResult1.RavorDiscountRate != salesSlipSearchResult2.RavorDiscountRate) resList.Add("RavorDiscountRate");
    //        if (salesSlipSearchResult1.TotalCost != salesSlipSearchResult2.TotalCost) resList.Add("TotalCost");
    //        if (salesSlipSearchResult1.ConsTaxLayMethod != salesSlipSearchResult2.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
    //        if (salesSlipSearchResult1.ConsTaxRate != salesSlipSearchResult2.ConsTaxRate) resList.Add("ConsTaxRate");
    //        if (salesSlipSearchResult1.FractionProcCd != salesSlipSearchResult2.FractionProcCd) resList.Add("FractionProcCd");
    //        if (salesSlipSearchResult1.AccRecConsTax != salesSlipSearchResult2.AccRecConsTax) resList.Add("AccRecConsTax");
    //        if (salesSlipSearchResult1.AutoDepositCd != salesSlipSearchResult2.AutoDepositCd) resList.Add("AutoDepositCd");
    //        if (salesSlipSearchResult1.AutoDepositSlipNo != salesSlipSearchResult2.AutoDepositSlipNo) resList.Add("AutoDepositSlipNo");
    //        if (salesSlipSearchResult1.DepositAllowanceTtl != salesSlipSearchResult2.DepositAllowanceTtl) resList.Add("DepositAllowanceTtl");
    //        if (salesSlipSearchResult1.DepositAlwcBlnce != salesSlipSearchResult2.DepositAlwcBlnce) resList.Add("DepositAlwcBlnce");
    //        if (salesSlipSearchResult1.ClaimCode != salesSlipSearchResult2.ClaimCode) resList.Add("ClaimCode");
    //        if (salesSlipSearchResult1.ClaimSnm != salesSlipSearchResult2.ClaimSnm) resList.Add("ClaimSnm");
    //        if (salesSlipSearchResult1.CustomerCode != salesSlipSearchResult2.CustomerCode) resList.Add("CustomerCode");
    //        if (salesSlipSearchResult1.CustomerName != salesSlipSearchResult2.CustomerName) resList.Add("CustomerName");
    //        if (salesSlipSearchResult1.CustomerName2 != salesSlipSearchResult2.CustomerName2) resList.Add("CustomerName2");
    //        if (salesSlipSearchResult1.CustomerSnm != salesSlipSearchResult2.CustomerSnm) resList.Add("CustomerSnm");
    //        if (salesSlipSearchResult1.HonorificTitle != salesSlipSearchResult2.HonorificTitle) resList.Add("HonorificTitle");
    //        if (salesSlipSearchResult1.OutputName != salesSlipSearchResult2.OutputName) resList.Add("OutputName");
    //        if (salesSlipSearchResult1.CustSlipNo != salesSlipSearchResult2.CustSlipNo) resList.Add("CustSlipNo");
    //        if (salesSlipSearchResult1.SlipAddressDiv != salesSlipSearchResult2.SlipAddressDiv) resList.Add("SlipAddressDiv");
    //        if (salesSlipSearchResult1.AddresseeCode != salesSlipSearchResult2.AddresseeCode) resList.Add("AddresseeCode");
    //        if (salesSlipSearchResult1.AddresseeName != salesSlipSearchResult2.AddresseeName) resList.Add("AddresseeName");
    //        if (salesSlipSearchResult1.AddresseeName2 != salesSlipSearchResult2.AddresseeName2) resList.Add("AddresseeName2");
    //        if (salesSlipSearchResult1.AddresseePostNo != salesSlipSearchResult2.AddresseePostNo) resList.Add("AddresseePostNo");
    //        if (salesSlipSearchResult1.AddresseeAddr1 != salesSlipSearchResult2.AddresseeAddr1) resList.Add("AddresseeAddr1");
    //        if (salesSlipSearchResult1.AddresseeAddr3 != salesSlipSearchResult2.AddresseeAddr3) resList.Add("AddresseeAddr3");
    //        if (salesSlipSearchResult1.AddresseeAddr4 != salesSlipSearchResult2.AddresseeAddr4) resList.Add("AddresseeAddr4");
    //        if (salesSlipSearchResult1.AddresseeTelNo != salesSlipSearchResult2.AddresseeTelNo) resList.Add("AddresseeTelNo");
    //        if (salesSlipSearchResult1.AddresseeFaxNo != salesSlipSearchResult2.AddresseeFaxNo) resList.Add("AddresseeFaxNo");
    //        if (salesSlipSearchResult1.PartySaleSlipNum != salesSlipSearchResult2.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
    //        if (salesSlipSearchResult1.SlipNote != salesSlipSearchResult2.SlipNote) resList.Add("SlipNote");
    //        if (salesSlipSearchResult1.SlipNote2 != salesSlipSearchResult2.SlipNote2) resList.Add("SlipNote2");
    //        if (salesSlipSearchResult1.SlipNote3 != salesSlipSearchResult2.SlipNote3) resList.Add("SlipNote3");
    //        if (salesSlipSearchResult1.RetGoodsReasonDiv != salesSlipSearchResult2.RetGoodsReasonDiv) resList.Add("RetGoodsReasonDiv");
    //        if (salesSlipSearchResult1.RetGoodsReason != salesSlipSearchResult2.RetGoodsReason) resList.Add("RetGoodsReason");
    //        if (salesSlipSearchResult1.RegiProcDate != salesSlipSearchResult2.RegiProcDate) resList.Add("RegiProcDate");
    //        if (salesSlipSearchResult1.CashRegisterNo != salesSlipSearchResult2.CashRegisterNo) resList.Add("CashRegisterNo");
    //        if (salesSlipSearchResult1.PosReceiptNo != salesSlipSearchResult2.PosReceiptNo) resList.Add("PosReceiptNo");
    //        if (salesSlipSearchResult1.DetailRowCount != salesSlipSearchResult2.DetailRowCount) resList.Add("DetailRowCount");
    //        if (salesSlipSearchResult1.EdiSendDate != salesSlipSearchResult2.EdiSendDate) resList.Add("EdiSendDate");
    //        if (salesSlipSearchResult1.EdiTakeInDate != salesSlipSearchResult2.EdiTakeInDate) resList.Add("EdiTakeInDate");
    //        if (salesSlipSearchResult1.UoeRemark1 != salesSlipSearchResult2.UoeRemark1) resList.Add("UoeRemark1");
    //        if (salesSlipSearchResult1.UoeRemark2 != salesSlipSearchResult2.UoeRemark2) resList.Add("UoeRemark2");
    //        if (salesSlipSearchResult1.SlipPrintDivCd != salesSlipSearchResult2.SlipPrintDivCd) resList.Add("SlipPrintDivCd");
    //        if (salesSlipSearchResult1.SlipPrintFinishCd != salesSlipSearchResult2.SlipPrintFinishCd) resList.Add("SlipPrintFinishCd");
    //        if (salesSlipSearchResult1.SalesSlipPrintDate != salesSlipSearchResult2.SalesSlipPrintDate) resList.Add("SalesSlipPrintDate");
    //        if (salesSlipSearchResult1.BusinessTypeCode != salesSlipSearchResult2.BusinessTypeCode) resList.Add("BusinessTypeCode");
    //        if (salesSlipSearchResult1.BusinessTypeName != salesSlipSearchResult2.BusinessTypeName) resList.Add("BusinessTypeName");
    //        if (salesSlipSearchResult1.OrderNumber != salesSlipSearchResult2.OrderNumber) resList.Add("OrderNumber");
    //        if (salesSlipSearchResult1.DeliveredGoodsDiv != salesSlipSearchResult2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
    //        if (salesSlipSearchResult1.DeliveredGoodsDivNm != salesSlipSearchResult2.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
    //        if (salesSlipSearchResult1.SalesAreaCode != salesSlipSearchResult2.SalesAreaCode) resList.Add("SalesAreaCode");
    //        if (salesSlipSearchResult1.SalesAreaName != salesSlipSearchResult2.SalesAreaName) resList.Add("SalesAreaName");
    //        if (salesSlipSearchResult1.ReconcileFlag != salesSlipSearchResult2.ReconcileFlag) resList.Add("ReconcileFlag");
    //        if (salesSlipSearchResult1.SlipPrtSetPaperId != salesSlipSearchResult2.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
    //        if (salesSlipSearchResult1.CompleteCd != salesSlipSearchResult2.CompleteCd) resList.Add("CompleteCd");
    //        if (salesSlipSearchResult1.SalesPriceFracProcCd != salesSlipSearchResult2.SalesPriceFracProcCd) resList.Add("SalesPriceFracProcCd");
    //        if (salesSlipSearchResult1.StockGoodsTtlTaxExc != salesSlipSearchResult2.StockGoodsTtlTaxExc) resList.Add("StockGoodsTtlTaxExc");
    //        if (salesSlipSearchResult1.PureGoodsTtlTaxExc != salesSlipSearchResult2.PureGoodsTtlTaxExc) resList.Add("PureGoodsTtlTaxExc");
    //        if (salesSlipSearchResult1.ListPricePrintDiv != salesSlipSearchResult2.ListPricePrintDiv) resList.Add("ListPricePrintDiv");
    //        if (salesSlipSearchResult1.EraNameDispCd1 != salesSlipSearchResult2.EraNameDispCd1) resList.Add("EraNameDispCd1");
    //        if (salesSlipSearchResult1.EstimaTaxDivCd != salesSlipSearchResult2.EstimaTaxDivCd) resList.Add("EstimaTaxDivCd");
    //        if (salesSlipSearchResult1.EstimateFormPrtCd != salesSlipSearchResult2.EstimateFormPrtCd) resList.Add("EstimateFormPrtCd");
    //        if (salesSlipSearchResult1.EstimateSubject != salesSlipSearchResult2.EstimateSubject) resList.Add("EstimateSubject");
    //        if (salesSlipSearchResult1.Footnotes1 != salesSlipSearchResult2.Footnotes1) resList.Add("Footnotes1");
    //        if (salesSlipSearchResult1.Footnotes2 != salesSlipSearchResult2.Footnotes2) resList.Add("Footnotes2");
    //        if (salesSlipSearchResult1.EstimateTitle1 != salesSlipSearchResult2.EstimateTitle1) resList.Add("EstimateTitle1");
    //        if (salesSlipSearchResult1.EstimateTitle2 != salesSlipSearchResult2.EstimateTitle2) resList.Add("EstimateTitle2");
    //        if (salesSlipSearchResult1.EstimateTitle3 != salesSlipSearchResult2.EstimateTitle3) resList.Add("EstimateTitle3");
    //        if (salesSlipSearchResult1.EstimateTitle4 != salesSlipSearchResult2.EstimateTitle4) resList.Add("EstimateTitle4");
    //        if (salesSlipSearchResult1.EstimateTitle5 != salesSlipSearchResult2.EstimateTitle5) resList.Add("EstimateTitle5");
    //        if (salesSlipSearchResult1.EstimateNote1 != salesSlipSearchResult2.EstimateNote1) resList.Add("EstimateNote1");
    //        if (salesSlipSearchResult1.EstimateNote2 != salesSlipSearchResult2.EstimateNote2) resList.Add("EstimateNote2");
    //        if (salesSlipSearchResult1.EstimateNote3 != salesSlipSearchResult2.EstimateNote3) resList.Add("EstimateNote3");
    //        if (salesSlipSearchResult1.EstimateNote4 != salesSlipSearchResult2.EstimateNote4) resList.Add("EstimateNote4");
    //        if (salesSlipSearchResult1.EstimateNote5 != salesSlipSearchResult2.EstimateNote5) resList.Add("EstimateNote5");
    //        if (salesSlipSearchResult1.EstimateValidityDate != salesSlipSearchResult2.EstimateValidityDate) resList.Add("EstimateValidityDate");
    //        if (salesSlipSearchResult1.PartsNoPrtCd != salesSlipSearchResult2.PartsNoPrtCd) resList.Add("PartsNoPrtCd");
    //        if (salesSlipSearchResult1.OptionPringDivCd != salesSlipSearchResult2.OptionPringDivCd) resList.Add("OptionPringDivCd");
    //        if (salesSlipSearchResult1.RateUseCode != salesSlipSearchResult2.RateUseCode) resList.Add("RateUseCode");
    //        if (salesSlipSearchResult1.CarMngCode != salesSlipSearchResult2.CarMngCode) resList.Add("CarMngNo");
    //        if (salesSlipSearchResult1.ModelDesignationNo != salesSlipSearchResult2.ModelDesignationNo) resList.Add("ModelDesignationNo");
    //        if (salesSlipSearchResult1.CategoryNo != salesSlipSearchResult2.CategoryNo) resList.Add("CategoryNo");
    //        if (salesSlipSearchResult1.MakerFullName != salesSlipSearchResult2.MakerFullName) resList.Add("MakerFullName");
    //        if (salesSlipSearchResult1.FullModel != salesSlipSearchResult2.FullModel) resList.Add("FullModel");
    //        if (salesSlipSearchResult1.EnterpriseName != salesSlipSearchResult2.EnterpriseName) resList.Add("EnterpriseName");
    //        if (salesSlipSearchResult1.ResultsAddUpSecNm != salesSlipSearchResult2.ResultsAddUpSecNm) resList.Add("ResultsAddUpSecNm");

    //        return resList;
    //    }
    //}
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL

    /// public class name:   SalesSlipSearchResult
    /// <summary>
    ///                      売上伝票検索抽出結果
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上伝票検索抽出結果ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SalesSlipSearchResult
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷,70:指示書,80:クレーム,99:一時保管  </remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private string _salesSlipNum = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>部門名称</summary>
        private string _subSectionName = "";

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

        /// <summary>伝票検索日付</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _searchSlipDate;

        /// <summary>出荷日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _shipmentDay;

        /// <summary>売上日付</summary>
        /// <remarks>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</remarks>
        private DateTime _salesDate;

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

        /// <summary>車輌管理コード</summary>
        /// <remarks>※PM7での車両管理番号</remarks>
        private string _carMngCode = "";

        /// <summary>型式指定番号</summary>
        private Int32 _modelDesignationNo;

        /// <summary>類別番号</summary>
        private Int32 _categoryNo;

        /// <summary>メーカー全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _makerFullName = "";

        /// <summary>型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _fullModel = "";

        /// <summary>車種全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _modelFullName = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>実績計上拠点名称</summary>
        private string _resultsAddUpSecNm = "";


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
        /// <value>10:見積,20:受注,30:売上,40:出荷,70:指示書,80:クレーム,99:一時保管  </value>
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
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _searchSlipDate ); }
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
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _searchSlipDate ); }
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
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _searchSlipDate ); }
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
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _searchSlipDate ); }
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
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _shipmentDay ); }
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
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _shipmentDay ); }
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
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _shipmentDay ); }
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
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _shipmentDay ); }
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
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _salesDate ); }
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
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _salesDate ); }
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
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _salesDate ); }
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
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _salesDate ); }
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
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _addUpADate ); }
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
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _addUpADate ); }
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
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _addUpADate ); }
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
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _addUpADate ); }
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
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _regiProcDate ); }
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
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _regiProcDate ); }
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
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _regiProcDate ); }
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
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _regiProcDate ); }
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
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _estimateValidityDate ); }
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
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _estimateValidityDate ); }
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
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _estimateValidityDate ); }
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
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _estimateValidityDate ); }
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

        /// public propaty name  :  MakerFullName
        /// <summary>メーカー全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerFullName
        {
            get { return _makerFullName; }
            set { _makerFullName = value; }
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


        /// <summary>
        /// 売上伝票検索抽出結果コンストラクタ
        /// </summary>
        /// <returns>SalesSlipSearchResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipSearchResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesSlipSearchResult()
        {
        }

        /// <summary>
        /// 売上伝票検索抽出結果コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="acptAnOdrStatus">受注ステータス(10:見積,20:受注,30:売上,40:出荷,70:指示書,80:クレーム,99:一時保管  )</param>
        /// <param name="salesSlipNum">売上伝票番号(見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="sectionGuideNm">拠点ガイド名称</param>
        /// <param name="subSectionCode">部門コード</param>
        /// <param name="subSectionName">部門名称</param>
        /// <param name="debitNoteDiv">赤伝区分(0:黒伝,1:赤伝,2:元黒)</param>
        /// <param name="debitNLnkSalesSlNum">赤黒連結売上伝票番号(赤黒の相手方売上伝票番号)</param>
        /// <param name="salesSlipCd">売上伝票区分(0:売上,1:返品)</param>
        /// <param name="salesGoodsCd">売上商品区分(0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動))</param>
        /// <param name="accRecDivCd">売掛区分(0:売掛なし,1:売掛)</param>
        /// <param name="salesInpSecCd">売上入力拠点コード(文字型 売上を入力した拠点コード)</param>
        /// <param name="demandAddUpSecCd">請求計上拠点コード(文字型)</param>
        /// <param name="resultsAddUpSecCd">実績計上拠点コード(実績計上を行う企業内の拠点コード)</param>
        /// <param name="updateSecCd">更新拠点コード(文字型 データの登録更新拠点)</param>
        /// <param name="searchSlipDate">伝票検索日付(YYYYMMDD　（更新年月日）)</param>
        /// <param name="shipmentDay">出荷日付(YYYYMMDD)</param>
        /// <param name="salesDate">売上日付(見積日、受注日、売上日を兼ねる。(YYYYMMDD))</param>
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
        /// <param name="consTaxRate">消費税税率</param>
        /// <param name="fractionProcCd">端数処理区分(1:切捨て,2:四捨五入,3:切上げ　（消費税）)</param>
        /// <param name="accRecConsTax">売掛消費税</param>
        /// <param name="autoDepositCd">自動入金区分(0:通常入金,1:自動入金)</param>
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
        /// <param name="outputName">諸口名称</param>
        /// <param name="custSlipNo">得意先伝票番号</param>
        /// <param name="slipAddressDiv">伝票住所区分(1:得意先,2:納入先)</param>
        /// <param name="addresseeCode">納品先コード</param>
        /// <param name="addresseeName">納品先名称</param>
        /// <param name="addresseeName2">納品先名称2</param>
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
        /// <param name="carMngCode">車輌管理コード(※PM7での車両管理番号)</param>
        /// <param name="modelDesignationNo">型式指定番号</param>
        /// <param name="categoryNo">類別番号</param>
        /// <param name="makerFullName">メーカー全角名称(正式名称（カナ漢字混在で全角管理）)</param>
        /// <param name="fullModel">型式（フル型）(フル型式(44桁用))</param>
        /// <param name="modelFullName">車種全角名称(正式名称（カナ漢字混在で全角管理）)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="resultsAddUpSecNm">実績計上拠点名称</param>
        /// <returns>SalesSlipSearchResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipSearchResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesSlipSearchResult( string enterpriseCode, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, string sectionGuideNm, Int32 subSectionCode, string subSectionName, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 delayPaymentDiv, string estimateFormNo, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesPrtTotalTaxInc, Int64 salesPrtTotalTaxExc, Int64 salesWorkTotalTaxInc, Int64 salesWorkTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesPrtSubttlInc, Int64 salesPrtSubttlExc, Int64 salesWorkSubttlInc, Int64 salesWorkSubttlExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedPartsDisOutTax, Int64 itdedPartsDisInTax, Int64 itdedWorkDisOutTax, Int64 itdedWorkDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Double partsDiscountRate, Double ravorDiscountRate, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, string outputName, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string slipNote, string slipNote2, string slipNote3, Int32 retGoodsReasonDiv, string retGoodsReason, DateTime regiProcDate, Int32 cashRegisterNo, Int32 posReceiptNo, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, string orderNumber, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, Int32 reconcileFlag, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 estimaTaxDivCd, Int32 estimateFormPrtCd, string estimateSubject, string footnotes1, string footnotes2, string estimateTitle1, string estimateTitle2, string estimateTitle3, string estimateTitle4, string estimateTitle5, string estimateNote1, string estimateNote2, string estimateNote3, string estimateNote4, string estimateNote5, DateTime estimateValidityDate, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 rateUseCode, string carMngCode, Int32 modelDesignationNo, Int32 categoryNo, string makerFullName, string fullModel, string modelFullName, string enterpriseName, string resultsAddUpSecNm )
        {
            this._enterpriseCode = enterpriseCode;
            this._logicalDeleteCode = logicalDeleteCode;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._salesSlipNum = salesSlipNum;
            this._sectionCode = sectionCode;
            this._sectionGuideNm = sectionGuideNm;
            this._subSectionCode = subSectionCode;
            this._subSectionName = subSectionName;
            this._debitNoteDiv = debitNoteDiv;
            this._debitNLnkSalesSlNum = debitNLnkSalesSlNum;
            this._salesSlipCd = salesSlipCd;
            this._salesGoodsCd = salesGoodsCd;
            this._accRecDivCd = accRecDivCd;
            this._salesInpSecCd = salesInpSecCd;
            this._demandAddUpSecCd = demandAddUpSecCd;
            this._resultsAddUpSecCd = resultsAddUpSecCd;
            this._updateSecCd = updateSecCd;
            this.SearchSlipDate = searchSlipDate;
            this.ShipmentDay = shipmentDay;
            this.SalesDate = salesDate;
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
            this._slipNote = slipNote;
            this._slipNote2 = slipNote2;
            this._slipNote3 = slipNote3;
            this._retGoodsReasonDiv = retGoodsReasonDiv;
            this._retGoodsReason = retGoodsReason;
            this.RegiProcDate = regiProcDate;
            this._cashRegisterNo = cashRegisterNo;
            this._posReceiptNo = posReceiptNo;
            this._detailRowCount = detailRowCount;
            this._ediSendDate = ediSendDate;
            this._ediTakeInDate = ediTakeInDate;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this._slipPrintDivCd = slipPrintDivCd;
            this._slipPrintFinishCd = slipPrintFinishCd;
            this._salesSlipPrintDate = salesSlipPrintDate;
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
            this._carMngCode = carMngCode;
            this._modelDesignationNo = modelDesignationNo;
            this._categoryNo = categoryNo;
            this._makerFullName = makerFullName;
            this._fullModel = fullModel;
            this._modelFullName = modelFullName;
            this._enterpriseName = enterpriseName;
            this._resultsAddUpSecNm = resultsAddUpSecNm;

        }

        /// <summary>
        /// 売上伝票検索抽出結果複製処理
        /// </summary>
        /// <returns>SalesSlipSearchResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSalesSlipSearchResultクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesSlipSearchResult Clone()
        {
            return new SalesSlipSearchResult( this._enterpriseCode, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._sectionGuideNm, this._subSectionCode, this._subSectionName, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._addUpADate, this._delayPaymentDiv, this._estimateFormNo, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesPrtTotalTaxInc, this._salesPrtTotalTaxExc, this._salesWorkTotalTaxInc, this._salesWorkTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesPrtSubttlInc, this._salesPrtSubttlExc, this._salesWorkSubttlInc, this._salesWorkSubttlExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedPartsDisOutTax, this._itdedPartsDisInTax, this._itdedWorkDisOutTax, this._itdedWorkDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._partsDiscountRate, this._ravorDiscountRate, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputName, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._slipNote, this._slipNote2, this._slipNote3, this._retGoodsReasonDiv, this._retGoodsReason, this._regiProcDate, this._cashRegisterNo, this._posReceiptNo, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._orderNumber, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._reconcileFlag, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._estimaTaxDivCd, this._estimateFormPrtCd, this._estimateSubject, this._footnotes1, this._footnotes2, this._estimateTitle1, this._estimateTitle2, this._estimateTitle3, this._estimateTitle4, this._estimateTitle5, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimateNote4, this._estimateNote5, this._estimateValidityDate, this._partsNoPrtCd, this._optionPringDivCd, this._rateUseCode, this._carMngCode, this._modelDesignationNo, this._categoryNo, this._makerFullName, this._fullModel, this._modelFullName, this._enterpriseName, this._resultsAddUpSecNm );
        }

        /// <summary>
        /// 売上伝票検索抽出結果比較処理
        /// </summary>
        /// <param name="target">比較対象のSalesSlipSearchResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipSearchResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals( SalesSlipSearchResult target )
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.SalesSlipNum == target.SalesSlipNum)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SectionGuideNm == target.SectionGuideNm)
                 && (this.SubSectionCode == target.SubSectionCode)
                 && (this.SubSectionName == target.SubSectionName)
                 && (this.DebitNoteDiv == target.DebitNoteDiv)
                 && (this.DebitNLnkSalesSlNum == target.DebitNLnkSalesSlNum)
                 && (this.SalesSlipCd == target.SalesSlipCd)
                 && (this.SalesGoodsCd == target.SalesGoodsCd)
                 && (this.AccRecDivCd == target.AccRecDivCd)
                 && (this.SalesInpSecCd == target.SalesInpSecCd)
                 && (this.DemandAddUpSecCd == target.DemandAddUpSecCd)
                 && (this.ResultsAddUpSecCd == target.ResultsAddUpSecCd)
                 && (this.UpdateSecCd == target.UpdateSecCd)
                 && (this.SearchSlipDate == target.SearchSlipDate)
                 && (this.ShipmentDay == target.ShipmentDay)
                 && (this.SalesDate == target.SalesDate)
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
                 && (this.SlipNote == target.SlipNote)
                 && (this.SlipNote2 == target.SlipNote2)
                 && (this.SlipNote3 == target.SlipNote3)
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
                 && (this.CarMngCode == target.CarMngCode)
                 && (this.ModelDesignationNo == target.ModelDesignationNo)
                 && (this.CategoryNo == target.CategoryNo)
                 && (this.MakerFullName == target.MakerFullName)
                 && (this.FullModel == target.FullModel)
                 && (this.ModelFullName == target.ModelFullName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.ResultsAddUpSecNm == target.ResultsAddUpSecNm));
        }

        /// <summary>
        /// 売上伝票検索抽出結果比較処理
        /// </summary>
        /// <param name="salesSlipSearchResult1">
        ///                    比較するSalesSlipSearchResultクラスのインスタンス
        /// </param>
        /// <param name="salesSlipSearchResult2">比較するSalesSlipSearchResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipSearchResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals( SalesSlipSearchResult salesSlipSearchResult1, SalesSlipSearchResult salesSlipSearchResult2 )
        {
            return ((salesSlipSearchResult1.EnterpriseCode == salesSlipSearchResult2.EnterpriseCode)
                 && (salesSlipSearchResult1.LogicalDeleteCode == salesSlipSearchResult2.LogicalDeleteCode)
                 && (salesSlipSearchResult1.AcptAnOdrStatus == salesSlipSearchResult2.AcptAnOdrStatus)
                 && (salesSlipSearchResult1.SalesSlipNum == salesSlipSearchResult2.SalesSlipNum)
                 && (salesSlipSearchResult1.SectionCode == salesSlipSearchResult2.SectionCode)
                 && (salesSlipSearchResult1.SectionGuideNm == salesSlipSearchResult2.SectionGuideNm)
                 && (salesSlipSearchResult1.SubSectionCode == salesSlipSearchResult2.SubSectionCode)
                 && (salesSlipSearchResult1.SubSectionName == salesSlipSearchResult2.SubSectionName)
                 && (salesSlipSearchResult1.DebitNoteDiv == salesSlipSearchResult2.DebitNoteDiv)
                 && (salesSlipSearchResult1.DebitNLnkSalesSlNum == salesSlipSearchResult2.DebitNLnkSalesSlNum)
                 && (salesSlipSearchResult1.SalesSlipCd == salesSlipSearchResult2.SalesSlipCd)
                 && (salesSlipSearchResult1.SalesGoodsCd == salesSlipSearchResult2.SalesGoodsCd)
                 && (salesSlipSearchResult1.AccRecDivCd == salesSlipSearchResult2.AccRecDivCd)
                 && (salesSlipSearchResult1.SalesInpSecCd == salesSlipSearchResult2.SalesInpSecCd)
                 && (salesSlipSearchResult1.DemandAddUpSecCd == salesSlipSearchResult2.DemandAddUpSecCd)
                 && (salesSlipSearchResult1.ResultsAddUpSecCd == salesSlipSearchResult2.ResultsAddUpSecCd)
                 && (salesSlipSearchResult1.UpdateSecCd == salesSlipSearchResult2.UpdateSecCd)
                 && (salesSlipSearchResult1.SearchSlipDate == salesSlipSearchResult2.SearchSlipDate)
                 && (salesSlipSearchResult1.ShipmentDay == salesSlipSearchResult2.ShipmentDay)
                 && (salesSlipSearchResult1.SalesDate == salesSlipSearchResult2.SalesDate)
                 && (salesSlipSearchResult1.AddUpADate == salesSlipSearchResult2.AddUpADate)
                 && (salesSlipSearchResult1.DelayPaymentDiv == salesSlipSearchResult2.DelayPaymentDiv)
                 && (salesSlipSearchResult1.EstimateFormNo == salesSlipSearchResult2.EstimateFormNo)
                 && (salesSlipSearchResult1.EstimateDivide == salesSlipSearchResult2.EstimateDivide)
                 && (salesSlipSearchResult1.InputAgenCd == salesSlipSearchResult2.InputAgenCd)
                 && (salesSlipSearchResult1.InputAgenNm == salesSlipSearchResult2.InputAgenNm)
                 && (salesSlipSearchResult1.SalesInputCode == salesSlipSearchResult2.SalesInputCode)
                 && (salesSlipSearchResult1.SalesInputName == salesSlipSearchResult2.SalesInputName)
                 && (salesSlipSearchResult1.FrontEmployeeCd == salesSlipSearchResult2.FrontEmployeeCd)
                 && (salesSlipSearchResult1.FrontEmployeeNm == salesSlipSearchResult2.FrontEmployeeNm)
                 && (salesSlipSearchResult1.SalesEmployeeCd == salesSlipSearchResult2.SalesEmployeeCd)
                 && (salesSlipSearchResult1.SalesEmployeeNm == salesSlipSearchResult2.SalesEmployeeNm)
                 && (salesSlipSearchResult1.TotalAmountDispWayCd == salesSlipSearchResult2.TotalAmountDispWayCd)
                 && (salesSlipSearchResult1.TtlAmntDispRateApy == salesSlipSearchResult2.TtlAmntDispRateApy)
                 && (salesSlipSearchResult1.SalesTotalTaxInc == salesSlipSearchResult2.SalesTotalTaxInc)
                 && (salesSlipSearchResult1.SalesTotalTaxExc == salesSlipSearchResult2.SalesTotalTaxExc)
                 && (salesSlipSearchResult1.SalesPrtTotalTaxInc == salesSlipSearchResult2.SalesPrtTotalTaxInc)
                 && (salesSlipSearchResult1.SalesPrtTotalTaxExc == salesSlipSearchResult2.SalesPrtTotalTaxExc)
                 && (salesSlipSearchResult1.SalesWorkTotalTaxInc == salesSlipSearchResult2.SalesWorkTotalTaxInc)
                 && (salesSlipSearchResult1.SalesWorkTotalTaxExc == salesSlipSearchResult2.SalesWorkTotalTaxExc)
                 && (salesSlipSearchResult1.SalesSubtotalTaxInc == salesSlipSearchResult2.SalesSubtotalTaxInc)
                 && (salesSlipSearchResult1.SalesSubtotalTaxExc == salesSlipSearchResult2.SalesSubtotalTaxExc)
                 && (salesSlipSearchResult1.SalesPrtSubttlInc == salesSlipSearchResult2.SalesPrtSubttlInc)
                 && (salesSlipSearchResult1.SalesPrtSubttlExc == salesSlipSearchResult2.SalesPrtSubttlExc)
                 && (salesSlipSearchResult1.SalesWorkSubttlInc == salesSlipSearchResult2.SalesWorkSubttlInc)
                 && (salesSlipSearchResult1.SalesWorkSubttlExc == salesSlipSearchResult2.SalesWorkSubttlExc)
                 && (salesSlipSearchResult1.SalesNetPrice == salesSlipSearchResult2.SalesNetPrice)
                 && (salesSlipSearchResult1.SalesSubtotalTax == salesSlipSearchResult2.SalesSubtotalTax)
                 && (salesSlipSearchResult1.ItdedSalesOutTax == salesSlipSearchResult2.ItdedSalesOutTax)
                 && (salesSlipSearchResult1.ItdedSalesInTax == salesSlipSearchResult2.ItdedSalesInTax)
                 && (salesSlipSearchResult1.SalSubttlSubToTaxFre == salesSlipSearchResult2.SalSubttlSubToTaxFre)
                 && (salesSlipSearchResult1.SalesOutTax == salesSlipSearchResult2.SalesOutTax)
                 && (salesSlipSearchResult1.SalAmntConsTaxInclu == salesSlipSearchResult2.SalAmntConsTaxInclu)
                 && (salesSlipSearchResult1.SalesDisTtlTaxExc == salesSlipSearchResult2.SalesDisTtlTaxExc)
                 && (salesSlipSearchResult1.ItdedSalesDisOutTax == salesSlipSearchResult2.ItdedSalesDisOutTax)
                 && (salesSlipSearchResult1.ItdedSalesDisInTax == salesSlipSearchResult2.ItdedSalesDisInTax)
                 && (salesSlipSearchResult1.ItdedPartsDisOutTax == salesSlipSearchResult2.ItdedPartsDisOutTax)
                 && (salesSlipSearchResult1.ItdedPartsDisInTax == salesSlipSearchResult2.ItdedPartsDisInTax)
                 && (salesSlipSearchResult1.ItdedWorkDisOutTax == salesSlipSearchResult2.ItdedWorkDisOutTax)
                 && (salesSlipSearchResult1.ItdedWorkDisInTax == salesSlipSearchResult2.ItdedWorkDisInTax)
                 && (salesSlipSearchResult1.ItdedSalesDisTaxFre == salesSlipSearchResult2.ItdedSalesDisTaxFre)
                 && (salesSlipSearchResult1.SalesDisOutTax == salesSlipSearchResult2.SalesDisOutTax)
                 && (salesSlipSearchResult1.SalesDisTtlTaxInclu == salesSlipSearchResult2.SalesDisTtlTaxInclu)
                 && (salesSlipSearchResult1.PartsDiscountRate == salesSlipSearchResult2.PartsDiscountRate)
                 && (salesSlipSearchResult1.RavorDiscountRate == salesSlipSearchResult2.RavorDiscountRate)
                 && (salesSlipSearchResult1.TotalCost == salesSlipSearchResult2.TotalCost)
                 && (salesSlipSearchResult1.ConsTaxLayMethod == salesSlipSearchResult2.ConsTaxLayMethod)
                 && (salesSlipSearchResult1.ConsTaxRate == salesSlipSearchResult2.ConsTaxRate)
                 && (salesSlipSearchResult1.FractionProcCd == salesSlipSearchResult2.FractionProcCd)
                 && (salesSlipSearchResult1.AccRecConsTax == salesSlipSearchResult2.AccRecConsTax)
                 && (salesSlipSearchResult1.AutoDepositCd == salesSlipSearchResult2.AutoDepositCd)
                 && (salesSlipSearchResult1.AutoDepositSlipNo == salesSlipSearchResult2.AutoDepositSlipNo)
                 && (salesSlipSearchResult1.DepositAllowanceTtl == salesSlipSearchResult2.DepositAllowanceTtl)
                 && (salesSlipSearchResult1.DepositAlwcBlnce == salesSlipSearchResult2.DepositAlwcBlnce)
                 && (salesSlipSearchResult1.ClaimCode == salesSlipSearchResult2.ClaimCode)
                 && (salesSlipSearchResult1.ClaimSnm == salesSlipSearchResult2.ClaimSnm)
                 && (salesSlipSearchResult1.CustomerCode == salesSlipSearchResult2.CustomerCode)
                 && (salesSlipSearchResult1.CustomerName == salesSlipSearchResult2.CustomerName)
                 && (salesSlipSearchResult1.CustomerName2 == salesSlipSearchResult2.CustomerName2)
                 && (salesSlipSearchResult1.CustomerSnm == salesSlipSearchResult2.CustomerSnm)
                 && (salesSlipSearchResult1.HonorificTitle == salesSlipSearchResult2.HonorificTitle)
                 && (salesSlipSearchResult1.OutputName == salesSlipSearchResult2.OutputName)
                 && (salesSlipSearchResult1.CustSlipNo == salesSlipSearchResult2.CustSlipNo)
                 && (salesSlipSearchResult1.SlipAddressDiv == salesSlipSearchResult2.SlipAddressDiv)
                 && (salesSlipSearchResult1.AddresseeCode == salesSlipSearchResult2.AddresseeCode)
                 && (salesSlipSearchResult1.AddresseeName == salesSlipSearchResult2.AddresseeName)
                 && (salesSlipSearchResult1.AddresseeName2 == salesSlipSearchResult2.AddresseeName2)
                 && (salesSlipSearchResult1.AddresseePostNo == salesSlipSearchResult2.AddresseePostNo)
                 && (salesSlipSearchResult1.AddresseeAddr1 == salesSlipSearchResult2.AddresseeAddr1)
                 && (salesSlipSearchResult1.AddresseeAddr3 == salesSlipSearchResult2.AddresseeAddr3)
                 && (salesSlipSearchResult1.AddresseeAddr4 == salesSlipSearchResult2.AddresseeAddr4)
                 && (salesSlipSearchResult1.AddresseeTelNo == salesSlipSearchResult2.AddresseeTelNo)
                 && (salesSlipSearchResult1.AddresseeFaxNo == salesSlipSearchResult2.AddresseeFaxNo)
                 && (salesSlipSearchResult1.PartySaleSlipNum == salesSlipSearchResult2.PartySaleSlipNum)
                 && (salesSlipSearchResult1.SlipNote == salesSlipSearchResult2.SlipNote)
                 && (salesSlipSearchResult1.SlipNote2 == salesSlipSearchResult2.SlipNote2)
                 && (salesSlipSearchResult1.SlipNote3 == salesSlipSearchResult2.SlipNote3)
                 && (salesSlipSearchResult1.RetGoodsReasonDiv == salesSlipSearchResult2.RetGoodsReasonDiv)
                 && (salesSlipSearchResult1.RetGoodsReason == salesSlipSearchResult2.RetGoodsReason)
                 && (salesSlipSearchResult1.RegiProcDate == salesSlipSearchResult2.RegiProcDate)
                 && (salesSlipSearchResult1.CashRegisterNo == salesSlipSearchResult2.CashRegisterNo)
                 && (salesSlipSearchResult1.PosReceiptNo == salesSlipSearchResult2.PosReceiptNo)
                 && (salesSlipSearchResult1.DetailRowCount == salesSlipSearchResult2.DetailRowCount)
                 && (salesSlipSearchResult1.EdiSendDate == salesSlipSearchResult2.EdiSendDate)
                 && (salesSlipSearchResult1.EdiTakeInDate == salesSlipSearchResult2.EdiTakeInDate)
                 && (salesSlipSearchResult1.UoeRemark1 == salesSlipSearchResult2.UoeRemark1)
                 && (salesSlipSearchResult1.UoeRemark2 == salesSlipSearchResult2.UoeRemark2)
                 && (salesSlipSearchResult1.SlipPrintDivCd == salesSlipSearchResult2.SlipPrintDivCd)
                 && (salesSlipSearchResult1.SlipPrintFinishCd == salesSlipSearchResult2.SlipPrintFinishCd)
                 && (salesSlipSearchResult1.SalesSlipPrintDate == salesSlipSearchResult2.SalesSlipPrintDate)
                 && (salesSlipSearchResult1.BusinessTypeCode == salesSlipSearchResult2.BusinessTypeCode)
                 && (salesSlipSearchResult1.BusinessTypeName == salesSlipSearchResult2.BusinessTypeName)
                 && (salesSlipSearchResult1.OrderNumber == salesSlipSearchResult2.OrderNumber)
                 && (salesSlipSearchResult1.DeliveredGoodsDiv == salesSlipSearchResult2.DeliveredGoodsDiv)
                 && (salesSlipSearchResult1.DeliveredGoodsDivNm == salesSlipSearchResult2.DeliveredGoodsDivNm)
                 && (salesSlipSearchResult1.SalesAreaCode == salesSlipSearchResult2.SalesAreaCode)
                 && (salesSlipSearchResult1.SalesAreaName == salesSlipSearchResult2.SalesAreaName)
                 && (salesSlipSearchResult1.ReconcileFlag == salesSlipSearchResult2.ReconcileFlag)
                 && (salesSlipSearchResult1.SlipPrtSetPaperId == salesSlipSearchResult2.SlipPrtSetPaperId)
                 && (salesSlipSearchResult1.CompleteCd == salesSlipSearchResult2.CompleteCd)
                 && (salesSlipSearchResult1.SalesPriceFracProcCd == salesSlipSearchResult2.SalesPriceFracProcCd)
                 && (salesSlipSearchResult1.StockGoodsTtlTaxExc == salesSlipSearchResult2.StockGoodsTtlTaxExc)
                 && (salesSlipSearchResult1.PureGoodsTtlTaxExc == salesSlipSearchResult2.PureGoodsTtlTaxExc)
                 && (salesSlipSearchResult1.ListPricePrintDiv == salesSlipSearchResult2.ListPricePrintDiv)
                 && (salesSlipSearchResult1.EraNameDispCd1 == salesSlipSearchResult2.EraNameDispCd1)
                 && (salesSlipSearchResult1.EstimaTaxDivCd == salesSlipSearchResult2.EstimaTaxDivCd)
                 && (salesSlipSearchResult1.EstimateFormPrtCd == salesSlipSearchResult2.EstimateFormPrtCd)
                 && (salesSlipSearchResult1.EstimateSubject == salesSlipSearchResult2.EstimateSubject)
                 && (salesSlipSearchResult1.Footnotes1 == salesSlipSearchResult2.Footnotes1)
                 && (salesSlipSearchResult1.Footnotes2 == salesSlipSearchResult2.Footnotes2)
                 && (salesSlipSearchResult1.EstimateTitle1 == salesSlipSearchResult2.EstimateTitle1)
                 && (salesSlipSearchResult1.EstimateTitle2 == salesSlipSearchResult2.EstimateTitle2)
                 && (salesSlipSearchResult1.EstimateTitle3 == salesSlipSearchResult2.EstimateTitle3)
                 && (salesSlipSearchResult1.EstimateTitle4 == salesSlipSearchResult2.EstimateTitle4)
                 && (salesSlipSearchResult1.EstimateTitle5 == salesSlipSearchResult2.EstimateTitle5)
                 && (salesSlipSearchResult1.EstimateNote1 == salesSlipSearchResult2.EstimateNote1)
                 && (salesSlipSearchResult1.EstimateNote2 == salesSlipSearchResult2.EstimateNote2)
                 && (salesSlipSearchResult1.EstimateNote3 == salesSlipSearchResult2.EstimateNote3)
                 && (salesSlipSearchResult1.EstimateNote4 == salesSlipSearchResult2.EstimateNote4)
                 && (salesSlipSearchResult1.EstimateNote5 == salesSlipSearchResult2.EstimateNote5)
                 && (salesSlipSearchResult1.EstimateValidityDate == salesSlipSearchResult2.EstimateValidityDate)
                 && (salesSlipSearchResult1.PartsNoPrtCd == salesSlipSearchResult2.PartsNoPrtCd)
                 && (salesSlipSearchResult1.OptionPringDivCd == salesSlipSearchResult2.OptionPringDivCd)
                 && (salesSlipSearchResult1.RateUseCode == salesSlipSearchResult2.RateUseCode)
                 && (salesSlipSearchResult1.CarMngCode == salesSlipSearchResult2.CarMngCode)
                 && (salesSlipSearchResult1.ModelDesignationNo == salesSlipSearchResult2.ModelDesignationNo)
                 && (salesSlipSearchResult1.CategoryNo == salesSlipSearchResult2.CategoryNo)
                 && (salesSlipSearchResult1.MakerFullName == salesSlipSearchResult2.MakerFullName)
                 && (salesSlipSearchResult1.FullModel == salesSlipSearchResult2.FullModel)
                 && (salesSlipSearchResult1.ModelFullName == salesSlipSearchResult2.ModelFullName)
                 && (salesSlipSearchResult1.EnterpriseName == salesSlipSearchResult2.EnterpriseName)
                 && (salesSlipSearchResult1.ResultsAddUpSecNm == salesSlipSearchResult2.ResultsAddUpSecNm));
        }
        /// <summary>
        /// 売上伝票検索抽出結果比較処理
        /// </summary>
        /// <param name="target">比較対象のSalesSlipSearchResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipSearchResultクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare( SalesSlipSearchResult target )
        {
            ArrayList resList = new ArrayList();
            if ( this.EnterpriseCode != target.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( this.LogicalDeleteCode != target.LogicalDeleteCode ) resList.Add( "LogicalDeleteCode" );
            if ( this.AcptAnOdrStatus != target.AcptAnOdrStatus ) resList.Add( "AcptAnOdrStatus" );
            if ( this.SalesSlipNum != target.SalesSlipNum ) resList.Add( "SalesSlipNum" );
            if ( this.SectionCode != target.SectionCode ) resList.Add( "SectionCode" );
            if ( this.SectionGuideNm != target.SectionGuideNm ) resList.Add( "SectionGuideNm" );
            if ( this.SubSectionCode != target.SubSectionCode ) resList.Add( "SubSectionCode" );
            if ( this.SubSectionName != target.SubSectionName ) resList.Add( "SubSectionName" );
            if ( this.DebitNoteDiv != target.DebitNoteDiv ) resList.Add( "DebitNoteDiv" );
            if ( this.DebitNLnkSalesSlNum != target.DebitNLnkSalesSlNum ) resList.Add( "DebitNLnkSalesSlNum" );
            if ( this.SalesSlipCd != target.SalesSlipCd ) resList.Add( "SalesSlipCd" );
            if ( this.SalesGoodsCd != target.SalesGoodsCd ) resList.Add( "SalesGoodsCd" );
            if ( this.AccRecDivCd != target.AccRecDivCd ) resList.Add( "AccRecDivCd" );
            if ( this.SalesInpSecCd != target.SalesInpSecCd ) resList.Add( "SalesInpSecCd" );
            if ( this.DemandAddUpSecCd != target.DemandAddUpSecCd ) resList.Add( "DemandAddUpSecCd" );
            if ( this.ResultsAddUpSecCd != target.ResultsAddUpSecCd ) resList.Add( "ResultsAddUpSecCd" );
            if ( this.UpdateSecCd != target.UpdateSecCd ) resList.Add( "UpdateSecCd" );
            if ( this.SearchSlipDate != target.SearchSlipDate ) resList.Add( "SearchSlipDate" );
            if ( this.ShipmentDay != target.ShipmentDay ) resList.Add( "ShipmentDay" );
            if ( this.SalesDate != target.SalesDate ) resList.Add( "SalesDate" );
            if ( this.AddUpADate != target.AddUpADate ) resList.Add( "AddUpADate" );
            if ( this.DelayPaymentDiv != target.DelayPaymentDiv ) resList.Add( "DelayPaymentDiv" );
            if ( this.EstimateFormNo != target.EstimateFormNo ) resList.Add( "EstimateFormNo" );
            if ( this.EstimateDivide != target.EstimateDivide ) resList.Add( "EstimateDivide" );
            if ( this.InputAgenCd != target.InputAgenCd ) resList.Add( "InputAgenCd" );
            if ( this.InputAgenNm != target.InputAgenNm ) resList.Add( "InputAgenNm" );
            if ( this.SalesInputCode != target.SalesInputCode ) resList.Add( "SalesInputCode" );
            if ( this.SalesInputName != target.SalesInputName ) resList.Add( "SalesInputName" );
            if ( this.FrontEmployeeCd != target.FrontEmployeeCd ) resList.Add( "FrontEmployeeCd" );
            if ( this.FrontEmployeeNm != target.FrontEmployeeNm ) resList.Add( "FrontEmployeeNm" );
            if ( this.SalesEmployeeCd != target.SalesEmployeeCd ) resList.Add( "SalesEmployeeCd" );
            if ( this.SalesEmployeeNm != target.SalesEmployeeNm ) resList.Add( "SalesEmployeeNm" );
            if ( this.TotalAmountDispWayCd != target.TotalAmountDispWayCd ) resList.Add( "TotalAmountDispWayCd" );
            if ( this.TtlAmntDispRateApy != target.TtlAmntDispRateApy ) resList.Add( "TtlAmntDispRateApy" );
            if ( this.SalesTotalTaxInc != target.SalesTotalTaxInc ) resList.Add( "SalesTotalTaxInc" );
            if ( this.SalesTotalTaxExc != target.SalesTotalTaxExc ) resList.Add( "SalesTotalTaxExc" );
            if ( this.SalesPrtTotalTaxInc != target.SalesPrtTotalTaxInc ) resList.Add( "SalesPrtTotalTaxInc" );
            if ( this.SalesPrtTotalTaxExc != target.SalesPrtTotalTaxExc ) resList.Add( "SalesPrtTotalTaxExc" );
            if ( this.SalesWorkTotalTaxInc != target.SalesWorkTotalTaxInc ) resList.Add( "SalesWorkTotalTaxInc" );
            if ( this.SalesWorkTotalTaxExc != target.SalesWorkTotalTaxExc ) resList.Add( "SalesWorkTotalTaxExc" );
            if ( this.SalesSubtotalTaxInc != target.SalesSubtotalTaxInc ) resList.Add( "SalesSubtotalTaxInc" );
            if ( this.SalesSubtotalTaxExc != target.SalesSubtotalTaxExc ) resList.Add( "SalesSubtotalTaxExc" );
            if ( this.SalesPrtSubttlInc != target.SalesPrtSubttlInc ) resList.Add( "SalesPrtSubttlInc" );
            if ( this.SalesPrtSubttlExc != target.SalesPrtSubttlExc ) resList.Add( "SalesPrtSubttlExc" );
            if ( this.SalesWorkSubttlInc != target.SalesWorkSubttlInc ) resList.Add( "SalesWorkSubttlInc" );
            if ( this.SalesWorkSubttlExc != target.SalesWorkSubttlExc ) resList.Add( "SalesWorkSubttlExc" );
            if ( this.SalesNetPrice != target.SalesNetPrice ) resList.Add( "SalesNetPrice" );
            if ( this.SalesSubtotalTax != target.SalesSubtotalTax ) resList.Add( "SalesSubtotalTax" );
            if ( this.ItdedSalesOutTax != target.ItdedSalesOutTax ) resList.Add( "ItdedSalesOutTax" );
            if ( this.ItdedSalesInTax != target.ItdedSalesInTax ) resList.Add( "ItdedSalesInTax" );
            if ( this.SalSubttlSubToTaxFre != target.SalSubttlSubToTaxFre ) resList.Add( "SalSubttlSubToTaxFre" );
            if ( this.SalesOutTax != target.SalesOutTax ) resList.Add( "SalesOutTax" );
            if ( this.SalAmntConsTaxInclu != target.SalAmntConsTaxInclu ) resList.Add( "SalAmntConsTaxInclu" );
            if ( this.SalesDisTtlTaxExc != target.SalesDisTtlTaxExc ) resList.Add( "SalesDisTtlTaxExc" );
            if ( this.ItdedSalesDisOutTax != target.ItdedSalesDisOutTax ) resList.Add( "ItdedSalesDisOutTax" );
            if ( this.ItdedSalesDisInTax != target.ItdedSalesDisInTax ) resList.Add( "ItdedSalesDisInTax" );
            if ( this.ItdedPartsDisOutTax != target.ItdedPartsDisOutTax ) resList.Add( "ItdedPartsDisOutTax" );
            if ( this.ItdedPartsDisInTax != target.ItdedPartsDisInTax ) resList.Add( "ItdedPartsDisInTax" );
            if ( this.ItdedWorkDisOutTax != target.ItdedWorkDisOutTax ) resList.Add( "ItdedWorkDisOutTax" );
            if ( this.ItdedWorkDisInTax != target.ItdedWorkDisInTax ) resList.Add( "ItdedWorkDisInTax" );
            if ( this.ItdedSalesDisTaxFre != target.ItdedSalesDisTaxFre ) resList.Add( "ItdedSalesDisTaxFre" );
            if ( this.SalesDisOutTax != target.SalesDisOutTax ) resList.Add( "SalesDisOutTax" );
            if ( this.SalesDisTtlTaxInclu != target.SalesDisTtlTaxInclu ) resList.Add( "SalesDisTtlTaxInclu" );
            if ( this.PartsDiscountRate != target.PartsDiscountRate ) resList.Add( "PartsDiscountRate" );
            if ( this.RavorDiscountRate != target.RavorDiscountRate ) resList.Add( "RavorDiscountRate" );
            if ( this.TotalCost != target.TotalCost ) resList.Add( "TotalCost" );
            if ( this.ConsTaxLayMethod != target.ConsTaxLayMethod ) resList.Add( "ConsTaxLayMethod" );
            if ( this.ConsTaxRate != target.ConsTaxRate ) resList.Add( "ConsTaxRate" );
            if ( this.FractionProcCd != target.FractionProcCd ) resList.Add( "FractionProcCd" );
            if ( this.AccRecConsTax != target.AccRecConsTax ) resList.Add( "AccRecConsTax" );
            if ( this.AutoDepositCd != target.AutoDepositCd ) resList.Add( "AutoDepositCd" );
            if ( this.AutoDepositSlipNo != target.AutoDepositSlipNo ) resList.Add( "AutoDepositSlipNo" );
            if ( this.DepositAllowanceTtl != target.DepositAllowanceTtl ) resList.Add( "DepositAllowanceTtl" );
            if ( this.DepositAlwcBlnce != target.DepositAlwcBlnce ) resList.Add( "DepositAlwcBlnce" );
            if ( this.ClaimCode != target.ClaimCode ) resList.Add( "ClaimCode" );
            if ( this.ClaimSnm != target.ClaimSnm ) resList.Add( "ClaimSnm" );
            if ( this.CustomerCode != target.CustomerCode ) resList.Add( "CustomerCode" );
            if ( this.CustomerName != target.CustomerName ) resList.Add( "CustomerName" );
            if ( this.CustomerName2 != target.CustomerName2 ) resList.Add( "CustomerName2" );
            if ( this.CustomerSnm != target.CustomerSnm ) resList.Add( "CustomerSnm" );
            if ( this.HonorificTitle != target.HonorificTitle ) resList.Add( "HonorificTitle" );
            if ( this.OutputName != target.OutputName ) resList.Add( "OutputName" );
            if ( this.CustSlipNo != target.CustSlipNo ) resList.Add( "CustSlipNo" );
            if ( this.SlipAddressDiv != target.SlipAddressDiv ) resList.Add( "SlipAddressDiv" );
            if ( this.AddresseeCode != target.AddresseeCode ) resList.Add( "AddresseeCode" );
            if ( this.AddresseeName != target.AddresseeName ) resList.Add( "AddresseeName" );
            if ( this.AddresseeName2 != target.AddresseeName2 ) resList.Add( "AddresseeName2" );
            if ( this.AddresseePostNo != target.AddresseePostNo ) resList.Add( "AddresseePostNo" );
            if ( this.AddresseeAddr1 != target.AddresseeAddr1 ) resList.Add( "AddresseeAddr1" );
            if ( this.AddresseeAddr3 != target.AddresseeAddr3 ) resList.Add( "AddresseeAddr3" );
            if ( this.AddresseeAddr4 != target.AddresseeAddr4 ) resList.Add( "AddresseeAddr4" );
            if ( this.AddresseeTelNo != target.AddresseeTelNo ) resList.Add( "AddresseeTelNo" );
            if ( this.AddresseeFaxNo != target.AddresseeFaxNo ) resList.Add( "AddresseeFaxNo" );
            if ( this.PartySaleSlipNum != target.PartySaleSlipNum ) resList.Add( "PartySaleSlipNum" );
            if ( this.SlipNote != target.SlipNote ) resList.Add( "SlipNote" );
            if ( this.SlipNote2 != target.SlipNote2 ) resList.Add( "SlipNote2" );
            if ( this.SlipNote3 != target.SlipNote3 ) resList.Add( "SlipNote3" );
            if ( this.RetGoodsReasonDiv != target.RetGoodsReasonDiv ) resList.Add( "RetGoodsReasonDiv" );
            if ( this.RetGoodsReason != target.RetGoodsReason ) resList.Add( "RetGoodsReason" );
            if ( this.RegiProcDate != target.RegiProcDate ) resList.Add( "RegiProcDate" );
            if ( this.CashRegisterNo != target.CashRegisterNo ) resList.Add( "CashRegisterNo" );
            if ( this.PosReceiptNo != target.PosReceiptNo ) resList.Add( "PosReceiptNo" );
            if ( this.DetailRowCount != target.DetailRowCount ) resList.Add( "DetailRowCount" );
            if ( this.EdiSendDate != target.EdiSendDate ) resList.Add( "EdiSendDate" );
            if ( this.EdiTakeInDate != target.EdiTakeInDate ) resList.Add( "EdiTakeInDate" );
            if ( this.UoeRemark1 != target.UoeRemark1 ) resList.Add( "UoeRemark1" );
            if ( this.UoeRemark2 != target.UoeRemark2 ) resList.Add( "UoeRemark2" );
            if ( this.SlipPrintDivCd != target.SlipPrintDivCd ) resList.Add( "SlipPrintDivCd" );
            if ( this.SlipPrintFinishCd != target.SlipPrintFinishCd ) resList.Add( "SlipPrintFinishCd" );
            if ( this.SalesSlipPrintDate != target.SalesSlipPrintDate ) resList.Add( "SalesSlipPrintDate" );
            if ( this.BusinessTypeCode != target.BusinessTypeCode ) resList.Add( "BusinessTypeCode" );
            if ( this.BusinessTypeName != target.BusinessTypeName ) resList.Add( "BusinessTypeName" );
            if ( this.OrderNumber != target.OrderNumber ) resList.Add( "OrderNumber" );
            if ( this.DeliveredGoodsDiv != target.DeliveredGoodsDiv ) resList.Add( "DeliveredGoodsDiv" );
            if ( this.DeliveredGoodsDivNm != target.DeliveredGoodsDivNm ) resList.Add( "DeliveredGoodsDivNm" );
            if ( this.SalesAreaCode != target.SalesAreaCode ) resList.Add( "SalesAreaCode" );
            if ( this.SalesAreaName != target.SalesAreaName ) resList.Add( "SalesAreaName" );
            if ( this.ReconcileFlag != target.ReconcileFlag ) resList.Add( "ReconcileFlag" );
            if ( this.SlipPrtSetPaperId != target.SlipPrtSetPaperId ) resList.Add( "SlipPrtSetPaperId" );
            if ( this.CompleteCd != target.CompleteCd ) resList.Add( "CompleteCd" );
            if ( this.SalesPriceFracProcCd != target.SalesPriceFracProcCd ) resList.Add( "SalesPriceFracProcCd" );
            if ( this.StockGoodsTtlTaxExc != target.StockGoodsTtlTaxExc ) resList.Add( "StockGoodsTtlTaxExc" );
            if ( this.PureGoodsTtlTaxExc != target.PureGoodsTtlTaxExc ) resList.Add( "PureGoodsTtlTaxExc" );
            if ( this.ListPricePrintDiv != target.ListPricePrintDiv ) resList.Add( "ListPricePrintDiv" );
            if ( this.EraNameDispCd1 != target.EraNameDispCd1 ) resList.Add( "EraNameDispCd1" );
            if ( this.EstimaTaxDivCd != target.EstimaTaxDivCd ) resList.Add( "EstimaTaxDivCd" );
            if ( this.EstimateFormPrtCd != target.EstimateFormPrtCd ) resList.Add( "EstimateFormPrtCd" );
            if ( this.EstimateSubject != target.EstimateSubject ) resList.Add( "EstimateSubject" );
            if ( this.Footnotes1 != target.Footnotes1 ) resList.Add( "Footnotes1" );
            if ( this.Footnotes2 != target.Footnotes2 ) resList.Add( "Footnotes2" );
            if ( this.EstimateTitle1 != target.EstimateTitle1 ) resList.Add( "EstimateTitle1" );
            if ( this.EstimateTitle2 != target.EstimateTitle2 ) resList.Add( "EstimateTitle2" );
            if ( this.EstimateTitle3 != target.EstimateTitle3 ) resList.Add( "EstimateTitle3" );
            if ( this.EstimateTitle4 != target.EstimateTitle4 ) resList.Add( "EstimateTitle4" );
            if ( this.EstimateTitle5 != target.EstimateTitle5 ) resList.Add( "EstimateTitle5" );
            if ( this.EstimateNote1 != target.EstimateNote1 ) resList.Add( "EstimateNote1" );
            if ( this.EstimateNote2 != target.EstimateNote2 ) resList.Add( "EstimateNote2" );
            if ( this.EstimateNote3 != target.EstimateNote3 ) resList.Add( "EstimateNote3" );
            if ( this.EstimateNote4 != target.EstimateNote4 ) resList.Add( "EstimateNote4" );
            if ( this.EstimateNote5 != target.EstimateNote5 ) resList.Add( "EstimateNote5" );
            if ( this.EstimateValidityDate != target.EstimateValidityDate ) resList.Add( "EstimateValidityDate" );
            if ( this.PartsNoPrtCd != target.PartsNoPrtCd ) resList.Add( "PartsNoPrtCd" );
            if ( this.OptionPringDivCd != target.OptionPringDivCd ) resList.Add( "OptionPringDivCd" );
            if ( this.RateUseCode != target.RateUseCode ) resList.Add( "RateUseCode" );
            if ( this.CarMngCode != target.CarMngCode ) resList.Add( "CarMngCode" );
            if ( this.ModelDesignationNo != target.ModelDesignationNo ) resList.Add( "ModelDesignationNo" );
            if ( this.CategoryNo != target.CategoryNo ) resList.Add( "CategoryNo" );
            if ( this.MakerFullName != target.MakerFullName ) resList.Add( "MakerFullName" );
            if ( this.FullModel != target.FullModel ) resList.Add( "FullModel" );
            if ( this.ModelFullName != target.ModelFullName ) resList.Add( "ModelFullName" );
            if ( this.EnterpriseName != target.EnterpriseName ) resList.Add( "EnterpriseName" );
            if ( this.ResultsAddUpSecNm != target.ResultsAddUpSecNm ) resList.Add( "ResultsAddUpSecNm" );

            return resList;
        }

        /// <summary>
        /// 売上伝票検索抽出結果比較処理
        /// </summary>
        /// <param name="salesSlipSearchResult1">比較するSalesSlipSearchResultクラスのインスタンス</param>
        /// <param name="salesSlipSearchResult2">比較するSalesSlipSearchResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipSearchResultクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare( SalesSlipSearchResult salesSlipSearchResult1, SalesSlipSearchResult salesSlipSearchResult2 )
        {
            ArrayList resList = new ArrayList();
            if ( salesSlipSearchResult1.EnterpriseCode != salesSlipSearchResult2.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( salesSlipSearchResult1.LogicalDeleteCode != salesSlipSearchResult2.LogicalDeleteCode ) resList.Add( "LogicalDeleteCode" );
            if ( salesSlipSearchResult1.AcptAnOdrStatus != salesSlipSearchResult2.AcptAnOdrStatus ) resList.Add( "AcptAnOdrStatus" );
            if ( salesSlipSearchResult1.SalesSlipNum != salesSlipSearchResult2.SalesSlipNum ) resList.Add( "SalesSlipNum" );
            if ( salesSlipSearchResult1.SectionCode != salesSlipSearchResult2.SectionCode ) resList.Add( "SectionCode" );
            if ( salesSlipSearchResult1.SectionGuideNm != salesSlipSearchResult2.SectionGuideNm ) resList.Add( "SectionGuideNm" );
            if ( salesSlipSearchResult1.SubSectionCode != salesSlipSearchResult2.SubSectionCode ) resList.Add( "SubSectionCode" );
            if ( salesSlipSearchResult1.SubSectionName != salesSlipSearchResult2.SubSectionName ) resList.Add( "SubSectionName" );
            if ( salesSlipSearchResult1.DebitNoteDiv != salesSlipSearchResult2.DebitNoteDiv ) resList.Add( "DebitNoteDiv" );
            if ( salesSlipSearchResult1.DebitNLnkSalesSlNum != salesSlipSearchResult2.DebitNLnkSalesSlNum ) resList.Add( "DebitNLnkSalesSlNum" );
            if ( salesSlipSearchResult1.SalesSlipCd != salesSlipSearchResult2.SalesSlipCd ) resList.Add( "SalesSlipCd" );
            if ( salesSlipSearchResult1.SalesGoodsCd != salesSlipSearchResult2.SalesGoodsCd ) resList.Add( "SalesGoodsCd" );
            if ( salesSlipSearchResult1.AccRecDivCd != salesSlipSearchResult2.AccRecDivCd ) resList.Add( "AccRecDivCd" );
            if ( salesSlipSearchResult1.SalesInpSecCd != salesSlipSearchResult2.SalesInpSecCd ) resList.Add( "SalesInpSecCd" );
            if ( salesSlipSearchResult1.DemandAddUpSecCd != salesSlipSearchResult2.DemandAddUpSecCd ) resList.Add( "DemandAddUpSecCd" );
            if ( salesSlipSearchResult1.ResultsAddUpSecCd != salesSlipSearchResult2.ResultsAddUpSecCd ) resList.Add( "ResultsAddUpSecCd" );
            if ( salesSlipSearchResult1.UpdateSecCd != salesSlipSearchResult2.UpdateSecCd ) resList.Add( "UpdateSecCd" );
            if ( salesSlipSearchResult1.SearchSlipDate != salesSlipSearchResult2.SearchSlipDate ) resList.Add( "SearchSlipDate" );
            if ( salesSlipSearchResult1.ShipmentDay != salesSlipSearchResult2.ShipmentDay ) resList.Add( "ShipmentDay" );
            if ( salesSlipSearchResult1.SalesDate != salesSlipSearchResult2.SalesDate ) resList.Add( "SalesDate" );
            if ( salesSlipSearchResult1.AddUpADate != salesSlipSearchResult2.AddUpADate ) resList.Add( "AddUpADate" );
            if ( salesSlipSearchResult1.DelayPaymentDiv != salesSlipSearchResult2.DelayPaymentDiv ) resList.Add( "DelayPaymentDiv" );
            if ( salesSlipSearchResult1.EstimateFormNo != salesSlipSearchResult2.EstimateFormNo ) resList.Add( "EstimateFormNo" );
            if ( salesSlipSearchResult1.EstimateDivide != salesSlipSearchResult2.EstimateDivide ) resList.Add( "EstimateDivide" );
            if ( salesSlipSearchResult1.InputAgenCd != salesSlipSearchResult2.InputAgenCd ) resList.Add( "InputAgenCd" );
            if ( salesSlipSearchResult1.InputAgenNm != salesSlipSearchResult2.InputAgenNm ) resList.Add( "InputAgenNm" );
            if ( salesSlipSearchResult1.SalesInputCode != salesSlipSearchResult2.SalesInputCode ) resList.Add( "SalesInputCode" );
            if ( salesSlipSearchResult1.SalesInputName != salesSlipSearchResult2.SalesInputName ) resList.Add( "SalesInputName" );
            if ( salesSlipSearchResult1.FrontEmployeeCd != salesSlipSearchResult2.FrontEmployeeCd ) resList.Add( "FrontEmployeeCd" );
            if ( salesSlipSearchResult1.FrontEmployeeNm != salesSlipSearchResult2.FrontEmployeeNm ) resList.Add( "FrontEmployeeNm" );
            if ( salesSlipSearchResult1.SalesEmployeeCd != salesSlipSearchResult2.SalesEmployeeCd ) resList.Add( "SalesEmployeeCd" );
            if ( salesSlipSearchResult1.SalesEmployeeNm != salesSlipSearchResult2.SalesEmployeeNm ) resList.Add( "SalesEmployeeNm" );
            if ( salesSlipSearchResult1.TotalAmountDispWayCd != salesSlipSearchResult2.TotalAmountDispWayCd ) resList.Add( "TotalAmountDispWayCd" );
            if ( salesSlipSearchResult1.TtlAmntDispRateApy != salesSlipSearchResult2.TtlAmntDispRateApy ) resList.Add( "TtlAmntDispRateApy" );
            if ( salesSlipSearchResult1.SalesTotalTaxInc != salesSlipSearchResult2.SalesTotalTaxInc ) resList.Add( "SalesTotalTaxInc" );
            if ( salesSlipSearchResult1.SalesTotalTaxExc != salesSlipSearchResult2.SalesTotalTaxExc ) resList.Add( "SalesTotalTaxExc" );
            if ( salesSlipSearchResult1.SalesPrtTotalTaxInc != salesSlipSearchResult2.SalesPrtTotalTaxInc ) resList.Add( "SalesPrtTotalTaxInc" );
            if ( salesSlipSearchResult1.SalesPrtTotalTaxExc != salesSlipSearchResult2.SalesPrtTotalTaxExc ) resList.Add( "SalesPrtTotalTaxExc" );
            if ( salesSlipSearchResult1.SalesWorkTotalTaxInc != salesSlipSearchResult2.SalesWorkTotalTaxInc ) resList.Add( "SalesWorkTotalTaxInc" );
            if ( salesSlipSearchResult1.SalesWorkTotalTaxExc != salesSlipSearchResult2.SalesWorkTotalTaxExc ) resList.Add( "SalesWorkTotalTaxExc" );
            if ( salesSlipSearchResult1.SalesSubtotalTaxInc != salesSlipSearchResult2.SalesSubtotalTaxInc ) resList.Add( "SalesSubtotalTaxInc" );
            if ( salesSlipSearchResult1.SalesSubtotalTaxExc != salesSlipSearchResult2.SalesSubtotalTaxExc ) resList.Add( "SalesSubtotalTaxExc" );
            if ( salesSlipSearchResult1.SalesPrtSubttlInc != salesSlipSearchResult2.SalesPrtSubttlInc ) resList.Add( "SalesPrtSubttlInc" );
            if ( salesSlipSearchResult1.SalesPrtSubttlExc != salesSlipSearchResult2.SalesPrtSubttlExc ) resList.Add( "SalesPrtSubttlExc" );
            if ( salesSlipSearchResult1.SalesWorkSubttlInc != salesSlipSearchResult2.SalesWorkSubttlInc ) resList.Add( "SalesWorkSubttlInc" );
            if ( salesSlipSearchResult1.SalesWorkSubttlExc != salesSlipSearchResult2.SalesWorkSubttlExc ) resList.Add( "SalesWorkSubttlExc" );
            if ( salesSlipSearchResult1.SalesNetPrice != salesSlipSearchResult2.SalesNetPrice ) resList.Add( "SalesNetPrice" );
            if ( salesSlipSearchResult1.SalesSubtotalTax != salesSlipSearchResult2.SalesSubtotalTax ) resList.Add( "SalesSubtotalTax" );
            if ( salesSlipSearchResult1.ItdedSalesOutTax != salesSlipSearchResult2.ItdedSalesOutTax ) resList.Add( "ItdedSalesOutTax" );
            if ( salesSlipSearchResult1.ItdedSalesInTax != salesSlipSearchResult2.ItdedSalesInTax ) resList.Add( "ItdedSalesInTax" );
            if ( salesSlipSearchResult1.SalSubttlSubToTaxFre != salesSlipSearchResult2.SalSubttlSubToTaxFre ) resList.Add( "SalSubttlSubToTaxFre" );
            if ( salesSlipSearchResult1.SalesOutTax != salesSlipSearchResult2.SalesOutTax ) resList.Add( "SalesOutTax" );
            if ( salesSlipSearchResult1.SalAmntConsTaxInclu != salesSlipSearchResult2.SalAmntConsTaxInclu ) resList.Add( "SalAmntConsTaxInclu" );
            if ( salesSlipSearchResult1.SalesDisTtlTaxExc != salesSlipSearchResult2.SalesDisTtlTaxExc ) resList.Add( "SalesDisTtlTaxExc" );
            if ( salesSlipSearchResult1.ItdedSalesDisOutTax != salesSlipSearchResult2.ItdedSalesDisOutTax ) resList.Add( "ItdedSalesDisOutTax" );
            if ( salesSlipSearchResult1.ItdedSalesDisInTax != salesSlipSearchResult2.ItdedSalesDisInTax ) resList.Add( "ItdedSalesDisInTax" );
            if ( salesSlipSearchResult1.ItdedPartsDisOutTax != salesSlipSearchResult2.ItdedPartsDisOutTax ) resList.Add( "ItdedPartsDisOutTax" );
            if ( salesSlipSearchResult1.ItdedPartsDisInTax != salesSlipSearchResult2.ItdedPartsDisInTax ) resList.Add( "ItdedPartsDisInTax" );
            if ( salesSlipSearchResult1.ItdedWorkDisOutTax != salesSlipSearchResult2.ItdedWorkDisOutTax ) resList.Add( "ItdedWorkDisOutTax" );
            if ( salesSlipSearchResult1.ItdedWorkDisInTax != salesSlipSearchResult2.ItdedWorkDisInTax ) resList.Add( "ItdedWorkDisInTax" );
            if ( salesSlipSearchResult1.ItdedSalesDisTaxFre != salesSlipSearchResult2.ItdedSalesDisTaxFre ) resList.Add( "ItdedSalesDisTaxFre" );
            if ( salesSlipSearchResult1.SalesDisOutTax != salesSlipSearchResult2.SalesDisOutTax ) resList.Add( "SalesDisOutTax" );
            if ( salesSlipSearchResult1.SalesDisTtlTaxInclu != salesSlipSearchResult2.SalesDisTtlTaxInclu ) resList.Add( "SalesDisTtlTaxInclu" );
            if ( salesSlipSearchResult1.PartsDiscountRate != salesSlipSearchResult2.PartsDiscountRate ) resList.Add( "PartsDiscountRate" );
            if ( salesSlipSearchResult1.RavorDiscountRate != salesSlipSearchResult2.RavorDiscountRate ) resList.Add( "RavorDiscountRate" );
            if ( salesSlipSearchResult1.TotalCost != salesSlipSearchResult2.TotalCost ) resList.Add( "TotalCost" );
            if ( salesSlipSearchResult1.ConsTaxLayMethod != salesSlipSearchResult2.ConsTaxLayMethod ) resList.Add( "ConsTaxLayMethod" );
            if ( salesSlipSearchResult1.ConsTaxRate != salesSlipSearchResult2.ConsTaxRate ) resList.Add( "ConsTaxRate" );
            if ( salesSlipSearchResult1.FractionProcCd != salesSlipSearchResult2.FractionProcCd ) resList.Add( "FractionProcCd" );
            if ( salesSlipSearchResult1.AccRecConsTax != salesSlipSearchResult2.AccRecConsTax ) resList.Add( "AccRecConsTax" );
            if ( salesSlipSearchResult1.AutoDepositCd != salesSlipSearchResult2.AutoDepositCd ) resList.Add( "AutoDepositCd" );
            if ( salesSlipSearchResult1.AutoDepositSlipNo != salesSlipSearchResult2.AutoDepositSlipNo ) resList.Add( "AutoDepositSlipNo" );
            if ( salesSlipSearchResult1.DepositAllowanceTtl != salesSlipSearchResult2.DepositAllowanceTtl ) resList.Add( "DepositAllowanceTtl" );
            if ( salesSlipSearchResult1.DepositAlwcBlnce != salesSlipSearchResult2.DepositAlwcBlnce ) resList.Add( "DepositAlwcBlnce" );
            if ( salesSlipSearchResult1.ClaimCode != salesSlipSearchResult2.ClaimCode ) resList.Add( "ClaimCode" );
            if ( salesSlipSearchResult1.ClaimSnm != salesSlipSearchResult2.ClaimSnm ) resList.Add( "ClaimSnm" );
            if ( salesSlipSearchResult1.CustomerCode != salesSlipSearchResult2.CustomerCode ) resList.Add( "CustomerCode" );
            if ( salesSlipSearchResult1.CustomerName != salesSlipSearchResult2.CustomerName ) resList.Add( "CustomerName" );
            if ( salesSlipSearchResult1.CustomerName2 != salesSlipSearchResult2.CustomerName2 ) resList.Add( "CustomerName2" );
            if ( salesSlipSearchResult1.CustomerSnm != salesSlipSearchResult2.CustomerSnm ) resList.Add( "CustomerSnm" );
            if ( salesSlipSearchResult1.HonorificTitle != salesSlipSearchResult2.HonorificTitle ) resList.Add( "HonorificTitle" );
            if ( salesSlipSearchResult1.OutputName != salesSlipSearchResult2.OutputName ) resList.Add( "OutputName" );
            if ( salesSlipSearchResult1.CustSlipNo != salesSlipSearchResult2.CustSlipNo ) resList.Add( "CustSlipNo" );
            if ( salesSlipSearchResult1.SlipAddressDiv != salesSlipSearchResult2.SlipAddressDiv ) resList.Add( "SlipAddressDiv" );
            if ( salesSlipSearchResult1.AddresseeCode != salesSlipSearchResult2.AddresseeCode ) resList.Add( "AddresseeCode" );
            if ( salesSlipSearchResult1.AddresseeName != salesSlipSearchResult2.AddresseeName ) resList.Add( "AddresseeName" );
            if ( salesSlipSearchResult1.AddresseeName2 != salesSlipSearchResult2.AddresseeName2 ) resList.Add( "AddresseeName2" );
            if ( salesSlipSearchResult1.AddresseePostNo != salesSlipSearchResult2.AddresseePostNo ) resList.Add( "AddresseePostNo" );
            if ( salesSlipSearchResult1.AddresseeAddr1 != salesSlipSearchResult2.AddresseeAddr1 ) resList.Add( "AddresseeAddr1" );
            if ( salesSlipSearchResult1.AddresseeAddr3 != salesSlipSearchResult2.AddresseeAddr3 ) resList.Add( "AddresseeAddr3" );
            if ( salesSlipSearchResult1.AddresseeAddr4 != salesSlipSearchResult2.AddresseeAddr4 ) resList.Add( "AddresseeAddr4" );
            if ( salesSlipSearchResult1.AddresseeTelNo != salesSlipSearchResult2.AddresseeTelNo ) resList.Add( "AddresseeTelNo" );
            if ( salesSlipSearchResult1.AddresseeFaxNo != salesSlipSearchResult2.AddresseeFaxNo ) resList.Add( "AddresseeFaxNo" );
            if ( salesSlipSearchResult1.PartySaleSlipNum != salesSlipSearchResult2.PartySaleSlipNum ) resList.Add( "PartySaleSlipNum" );
            if ( salesSlipSearchResult1.SlipNote != salesSlipSearchResult2.SlipNote ) resList.Add( "SlipNote" );
            if ( salesSlipSearchResult1.SlipNote2 != salesSlipSearchResult2.SlipNote2 ) resList.Add( "SlipNote2" );
            if ( salesSlipSearchResult1.SlipNote3 != salesSlipSearchResult2.SlipNote3 ) resList.Add( "SlipNote3" );
            if ( salesSlipSearchResult1.RetGoodsReasonDiv != salesSlipSearchResult2.RetGoodsReasonDiv ) resList.Add( "RetGoodsReasonDiv" );
            if ( salesSlipSearchResult1.RetGoodsReason != salesSlipSearchResult2.RetGoodsReason ) resList.Add( "RetGoodsReason" );
            if ( salesSlipSearchResult1.RegiProcDate != salesSlipSearchResult2.RegiProcDate ) resList.Add( "RegiProcDate" );
            if ( salesSlipSearchResult1.CashRegisterNo != salesSlipSearchResult2.CashRegisterNo ) resList.Add( "CashRegisterNo" );
            if ( salesSlipSearchResult1.PosReceiptNo != salesSlipSearchResult2.PosReceiptNo ) resList.Add( "PosReceiptNo" );
            if ( salesSlipSearchResult1.DetailRowCount != salesSlipSearchResult2.DetailRowCount ) resList.Add( "DetailRowCount" );
            if ( salesSlipSearchResult1.EdiSendDate != salesSlipSearchResult2.EdiSendDate ) resList.Add( "EdiSendDate" );
            if ( salesSlipSearchResult1.EdiTakeInDate != salesSlipSearchResult2.EdiTakeInDate ) resList.Add( "EdiTakeInDate" );
            if ( salesSlipSearchResult1.UoeRemark1 != salesSlipSearchResult2.UoeRemark1 ) resList.Add( "UoeRemark1" );
            if ( salesSlipSearchResult1.UoeRemark2 != salesSlipSearchResult2.UoeRemark2 ) resList.Add( "UoeRemark2" );
            if ( salesSlipSearchResult1.SlipPrintDivCd != salesSlipSearchResult2.SlipPrintDivCd ) resList.Add( "SlipPrintDivCd" );
            if ( salesSlipSearchResult1.SlipPrintFinishCd != salesSlipSearchResult2.SlipPrintFinishCd ) resList.Add( "SlipPrintFinishCd" );
            if ( salesSlipSearchResult1.SalesSlipPrintDate != salesSlipSearchResult2.SalesSlipPrintDate ) resList.Add( "SalesSlipPrintDate" );
            if ( salesSlipSearchResult1.BusinessTypeCode != salesSlipSearchResult2.BusinessTypeCode ) resList.Add( "BusinessTypeCode" );
            if ( salesSlipSearchResult1.BusinessTypeName != salesSlipSearchResult2.BusinessTypeName ) resList.Add( "BusinessTypeName" );
            if ( salesSlipSearchResult1.OrderNumber != salesSlipSearchResult2.OrderNumber ) resList.Add( "OrderNumber" );
            if ( salesSlipSearchResult1.DeliveredGoodsDiv != salesSlipSearchResult2.DeliveredGoodsDiv ) resList.Add( "DeliveredGoodsDiv" );
            if ( salesSlipSearchResult1.DeliveredGoodsDivNm != salesSlipSearchResult2.DeliveredGoodsDivNm ) resList.Add( "DeliveredGoodsDivNm" );
            if ( salesSlipSearchResult1.SalesAreaCode != salesSlipSearchResult2.SalesAreaCode ) resList.Add( "SalesAreaCode" );
            if ( salesSlipSearchResult1.SalesAreaName != salesSlipSearchResult2.SalesAreaName ) resList.Add( "SalesAreaName" );
            if ( salesSlipSearchResult1.ReconcileFlag != salesSlipSearchResult2.ReconcileFlag ) resList.Add( "ReconcileFlag" );
            if ( salesSlipSearchResult1.SlipPrtSetPaperId != salesSlipSearchResult2.SlipPrtSetPaperId ) resList.Add( "SlipPrtSetPaperId" );
            if ( salesSlipSearchResult1.CompleteCd != salesSlipSearchResult2.CompleteCd ) resList.Add( "CompleteCd" );
            if ( salesSlipSearchResult1.SalesPriceFracProcCd != salesSlipSearchResult2.SalesPriceFracProcCd ) resList.Add( "SalesPriceFracProcCd" );
            if ( salesSlipSearchResult1.StockGoodsTtlTaxExc != salesSlipSearchResult2.StockGoodsTtlTaxExc ) resList.Add( "StockGoodsTtlTaxExc" );
            if ( salesSlipSearchResult1.PureGoodsTtlTaxExc != salesSlipSearchResult2.PureGoodsTtlTaxExc ) resList.Add( "PureGoodsTtlTaxExc" );
            if ( salesSlipSearchResult1.ListPricePrintDiv != salesSlipSearchResult2.ListPricePrintDiv ) resList.Add( "ListPricePrintDiv" );
            if ( salesSlipSearchResult1.EraNameDispCd1 != salesSlipSearchResult2.EraNameDispCd1 ) resList.Add( "EraNameDispCd1" );
            if ( salesSlipSearchResult1.EstimaTaxDivCd != salesSlipSearchResult2.EstimaTaxDivCd ) resList.Add( "EstimaTaxDivCd" );
            if ( salesSlipSearchResult1.EstimateFormPrtCd != salesSlipSearchResult2.EstimateFormPrtCd ) resList.Add( "EstimateFormPrtCd" );
            if ( salesSlipSearchResult1.EstimateSubject != salesSlipSearchResult2.EstimateSubject ) resList.Add( "EstimateSubject" );
            if ( salesSlipSearchResult1.Footnotes1 != salesSlipSearchResult2.Footnotes1 ) resList.Add( "Footnotes1" );
            if ( salesSlipSearchResult1.Footnotes2 != salesSlipSearchResult2.Footnotes2 ) resList.Add( "Footnotes2" );
            if ( salesSlipSearchResult1.EstimateTitle1 != salesSlipSearchResult2.EstimateTitle1 ) resList.Add( "EstimateTitle1" );
            if ( salesSlipSearchResult1.EstimateTitle2 != salesSlipSearchResult2.EstimateTitle2 ) resList.Add( "EstimateTitle2" );
            if ( salesSlipSearchResult1.EstimateTitle3 != salesSlipSearchResult2.EstimateTitle3 ) resList.Add( "EstimateTitle3" );
            if ( salesSlipSearchResult1.EstimateTitle4 != salesSlipSearchResult2.EstimateTitle4 ) resList.Add( "EstimateTitle4" );
            if ( salesSlipSearchResult1.EstimateTitle5 != salesSlipSearchResult2.EstimateTitle5 ) resList.Add( "EstimateTitle5" );
            if ( salesSlipSearchResult1.EstimateNote1 != salesSlipSearchResult2.EstimateNote1 ) resList.Add( "EstimateNote1" );
            if ( salesSlipSearchResult1.EstimateNote2 != salesSlipSearchResult2.EstimateNote2 ) resList.Add( "EstimateNote2" );
            if ( salesSlipSearchResult1.EstimateNote3 != salesSlipSearchResult2.EstimateNote3 ) resList.Add( "EstimateNote3" );
            if ( salesSlipSearchResult1.EstimateNote4 != salesSlipSearchResult2.EstimateNote4 ) resList.Add( "EstimateNote4" );
            if ( salesSlipSearchResult1.EstimateNote5 != salesSlipSearchResult2.EstimateNote5 ) resList.Add( "EstimateNote5" );
            if ( salesSlipSearchResult1.EstimateValidityDate != salesSlipSearchResult2.EstimateValidityDate ) resList.Add( "EstimateValidityDate" );
            if ( salesSlipSearchResult1.PartsNoPrtCd != salesSlipSearchResult2.PartsNoPrtCd ) resList.Add( "PartsNoPrtCd" );
            if ( salesSlipSearchResult1.OptionPringDivCd != salesSlipSearchResult2.OptionPringDivCd ) resList.Add( "OptionPringDivCd" );
            if ( salesSlipSearchResult1.RateUseCode != salesSlipSearchResult2.RateUseCode ) resList.Add( "RateUseCode" );
            if ( salesSlipSearchResult1.CarMngCode != salesSlipSearchResult2.CarMngCode ) resList.Add( "CarMngCode" );
            if ( salesSlipSearchResult1.ModelDesignationNo != salesSlipSearchResult2.ModelDesignationNo ) resList.Add( "ModelDesignationNo" );
            if ( salesSlipSearchResult1.CategoryNo != salesSlipSearchResult2.CategoryNo ) resList.Add( "CategoryNo" );
            if ( salesSlipSearchResult1.MakerFullName != salesSlipSearchResult2.MakerFullName ) resList.Add( "MakerFullName" );
            if ( salesSlipSearchResult1.FullModel != salesSlipSearchResult2.FullModel ) resList.Add( "FullModel" );
            if ( salesSlipSearchResult1.ModelFullName != salesSlipSearchResult2.ModelFullName ) resList.Add( "ModelFullName" );
            if ( salesSlipSearchResult1.EnterpriseName != salesSlipSearchResult2.EnterpriseName ) resList.Add( "EnterpriseName" );
            if ( salesSlipSearchResult1.ResultsAddUpSecNm != salesSlipSearchResult2.ResultsAddUpSecNm ) resList.Add( "ResultsAddUpSecNm" );

            return resList;
        }
    }

}
