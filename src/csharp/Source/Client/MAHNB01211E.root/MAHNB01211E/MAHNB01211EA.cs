using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SearchClaimSales
    /// <summary>
    ///                      請求売上検索データクラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   請求売上検索データクラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/01/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/06/26 30414 忍 幸史 Partsman用に変更</br>
    /// </remarks>
    public class SearchClaimSales
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

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>課コード</summary>
        private Int32 _minSectionCode;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// <summary>赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _debitNoteDiv;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>赤黒連結受注番号</summary>
        /// <remarks>赤黒の相手方受注番号</remarks>
        private Int32 _debitNLnkAcptAnOdr;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

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

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>サービス伝票区分</summary>
        /// <remarks>0:OFF,1:ON</remarks>
        private Int32 _serviceSlipCd;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

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
        /// <remarks>(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        /// <summary>計上日付</summary>
        /// <remarks>請求日　(YYYYMMDD)</remarks>
        private DateTime _addUpADate;

        /// <summary>来勘区分</summary>
        /// <remarks>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</remarks>
        private Int32 _delayPaymentDiv;

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

        /// <summary>売上小計（税込み）</summary>
        /// <remarks>値引後の明細金額の合計（非課税含まず）</remarks>
        private Int64 _salesSubtotalTaxInc;

        /// <summary>売上小計（税抜き）</summary>
        /// <remarks>値引後の明細金額の合計（非課税含まず）</remarks>
        private Int64 _salesSubtotalTaxExc;

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

        /// <summary>売上値引非課税対象額合計</summary>
        /// <remarks>非課税商品値引の非課税対象額</remarks>
        private Int64 _itdedSalesDisTaxFre;

        /// <summary>売上値引消費税額（外税）</summary>
        /// <remarks>外税商品値引の消費税額</remarks>
        private Int64 _salesDisOutTax;

        /// <summary>仕入値引消費税額（内税）</summary>
        private Int64 _salesDisTtlTaxInclu;

        /// <summary>原価金額計</summary>
        private Int64 _totalCost;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>サービス預り金</summary>
        /// <remarks>料金収納など、サービス預り金の金額</remarks>
        private Int64 _serviceDeposits;

        /// <summary>消費税調整額</summary>
        private Int64 _taxAdjust;

        /// <summary>残高調整額</summary>
        private Int64 _balanceAdjust;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

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

        /// <summary>請求先名称</summary>
        /// <remarks>得意先マスタから取得</remarks>
        private string _claimName = "";

        /// <summary>請求先名称2</summary>
        /// <remarks>得意先マスタから取得</remarks>
        private string _claimName2 = "";

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

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>納品先住所2(丁目)</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private Int32 _addresseeAddr2;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

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

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>請求先区分</summary>
        /// <remarks>官庁請求区分（0:一般　1:官庁標準　2:官庁伝票）</remarks>
        private Int32 _claimType;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

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

        /// <summary>締日</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>最終締次更新年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _lastTotalAddUpDt;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>実績計上拠点名称</summary>
        private string _resultsAddUpSecNm = "";

        /// <summary>諸口名称</summary>
        private string _outputName = "";

        //-----ADD 2010/12/20----->>>>>
        /// <summary>売上伝票番号</summary>
        private string _depSalesSlipNum = "";
        //-----ADD 2010/12/20-----<<<<<

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

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
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
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

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

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  DebitNLnkAcptAnOdr
        /// <summary>赤黒連結受注番号プロパティ</summary>
        /// <value>赤黒の相手方受注番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤黒連結受注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNLnkAcptAnOdr
        {
            get { return _debitNLnkAcptAnOdr; }
            set { _debitNLnkAcptAnOdr = value; }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

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

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  ServiceSlipCd
        /// <summary>サービス伝票区分プロパティ</summary>
        /// <value>0:OFF,1:ON</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   サービス伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ServiceSlipCd
        {
            get { return _serviceSlipCd; }
            set { _serviceSlipCd = value; }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

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

        /// public propaty name  :  SalesDateJpFormal
        /// <summary>売上日付 和暦プロパティ</summary>
        /// <value>(YYYYMMDD)</value>
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
        /// <value>(YYYYMMDD)</value>
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
        /// <value>(YYYYMMDD)</value>
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
        /// <value>(YYYYMMDD)</value>
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

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  ServiceDeposits
        /// <summary>サービス預り金プロパティ</summary>
        /// <value>料金収納など、サービス預り金の金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   サービス預り金プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ServiceDeposits
        {
            get { return _serviceDeposits; }
            set { _serviceDeposits = value; }
        }

        /// public propaty name  :  TaxAdjust
        /// <summary>消費税調整額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税調整額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TaxAdjust
        {
            get { return _taxAdjust; }
            set { _taxAdjust = value; }
        }

        /// public propaty name  :  BalanceAdjust
        /// <summary>残高調整額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残高調整額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 BalanceAdjust
        {
            get { return _balanceAdjust; }
            set { _balanceAdjust = value; }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

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

        /// public propaty name  :  ClaimName
        /// <summary>請求先名称プロパティ</summary>
        /// <value>得意先マスタから取得</value>
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
        /// <value>得意先マスタから取得</value>
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

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  AddresseeAddr2
        /// <summary>納品先住所2(丁目)プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先住所2(丁目)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddresseeAddr2
        {
            get { return _addresseeAddr2; }
            set { _addresseeAddr2 = value; }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

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

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  ClaimType
        /// <summary>請求先区分プロパティ</summary>
        /// <value>官庁請求区分（0:一般　1:官庁標準　2:官庁伝票）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ClaimType
        {
            get { return _claimType; }
            set { _claimType = value; }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

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

        /// public propaty name  :  LastTotalAddUpDt
        /// <summary>最終締次更新年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終締次更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LastTotalAddUpDt
        {
            get { return _lastTotalAddUpDt; }
            set { _lastTotalAddUpDt = value; }
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

        // --- ADD 2010/12/20 ---------->>>>>
        /// public propaty name  :  DepSalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// <value>売上伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepSalesSlipNum
        {
            get { return _depSalesSlipNum; }
            set { _depSalesSlipNum = value; }
        }
        // --- ADD 2010/12/20 ----------<<<<<

        /// <summary>
        /// 請求売上検索データクラスコンストラクタ
        /// </summary>
        /// <returns>SearchClaimSalesクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchClaimSalesクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchClaimSales()
        {
        }

        /// <summary>
        /// 請求売上検索データクラスコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="acptAnOdrStatus">受注ステータス(30:売上)</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="subSectionCode">部門コード</param>
        /// <param name="debitNoteDiv">赤伝区分(0:黒伝,1:赤伝,2:元黒)</param>
        /// <param name="debitNLnkSalesSlNum">赤黒連結売上伝票番号(赤黒の相手方売上伝票番号)</param>
        /// <param name="salesSlipCd">売上伝票区分(0:売上,1:返品)</param>
        /// <param name="salesGoodsCd">売上商品区分(0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整)</param>
        /// <param name="accRecDivCd">売掛区分(0:売掛なし,1:売掛)</param>
        /// <param name="salesInpSecCd">売上入力拠点コード(文字型 売上を入力した拠点コード)</param>
        /// <param name="demandAddUpSecCd">請求計上拠点コード(文字型)</param>
        /// <param name="resultsAddUpSecCd">実績計上拠点コード(実績計上を行う企業内の拠点コード)</param>
        /// <param name="updateSecCd">更新拠点コード(文字型 データの登録更新拠点)</param>
        /// <param name="searchSlipDate">伝票検索日付(YYYYMMDD　（更新年月日）)</param>
        /// <param name="shipmentDay">出荷日付(YYYYMMDD)</param>
        /// <param name="salesDate">売上日付((YYYYMMDD))</param>
        /// <param name="addUpADate">計上日付(請求日　(YYYYMMDD))</param>
        /// <param name="delayPaymentDiv">来勘区分(0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後)</param>
        /// <param name="salesInputCode">売上入力者コード(入力担当者)</param>
        /// <param name="salesInputName">売上入力者名称</param>
        /// <param name="frontEmployeeCd">受付従業員コード(受付担当者)</param>
        /// <param name="frontEmployeeNm">受付従業員名称</param>
        /// <param name="salesEmployeeCd">販売従業員コード(計上担当者)</param>
        /// <param name="salesEmployeeNm">販売従業員名称</param>
        /// <param name="totalAmountDispWayCd">総額表示方法区分(0:総額表示しない（税抜き）,1:総額表示する（税込み）)</param>
        /// <param name="ttlAmntDispRateApy">総額表示掛率適用区分(0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率)</param>
        /// <param name="salesTotalTaxInc">売上伝票合計（税込み）(売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額)</param>
        /// <param name="salesTotalTaxExc">売上伝票合計（税抜き）(売上正価金額＋売上値引金額計（税抜き）)</param>
        /// <param name="salesSubtotalTaxInc">売上小計（税込み）(値引後の明細金額の合計（非課税含まず）)</param>
        /// <param name="salesSubtotalTaxExc">売上小計（税抜き）(値引後の明細金額の合計（非課税含まず）)</param>
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
        /// <param name="itdedSalesDisTaxFre">売上値引非課税対象額合計(非課税商品値引の非課税対象額)</param>
        /// <param name="salesDisOutTax">売上値引消費税額（外税）(外税商品値引の消費税額)</param>
        /// <param name="salesDisTtlTaxInclu">仕入値引消費税額（内税）</param>
        /// <param name="totalCost">原価金額計</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式(0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税)</param>
        /// <param name="consTaxRate">消費税税率(変更2007/8/22(型,桁) 塩原)</param>
        /// <param name="fractionProcCd">端数処理区分(1:切捨て,2:四捨五入,3:切上げ　（消費税）)</param>
        /// <param name="accRecConsTax">売掛消費税</param>
        /// <param name="autoDepositCd">自動入金区分(0:通常入金,1:自動入金)</param>
        /// <param name="autoDepositSlipNo">自動入金伝票番号(自動入金時の入金伝票番号)</param>
        /// <param name="depositAllowanceTtl">入金引当合計額(預り金引当合計額を含む)</param>
        /// <param name="depositAlwcBlnce">入金引当残高</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="claimName">請求先名称(得意先マスタから取得)</param>
        /// <param name="claimName2">請求先名称2(得意先マスタから取得)</param>
        /// <param name="claimSnm">請求先略称</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerName">得意先名称</param>
        /// <param name="customerName2">得意先名称2</param>
        /// <param name="customerSnm">得意先略称</param>
        /// <param name="honorificTitle">敬称</param>
        /// <param name="outputNameCode">諸口コード(0:正式得意先,1:諸口得意先)</param>
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
        /// <param name="partySaleSlipNum">相手先伝票番号(得意先注文番号)</param>
        /// <param name="slipNote">伝票備考</param>
        /// <param name="slipNote2">伝票備考２</param>
        /// <param name="retGoodsReasonDiv">返品理由コード</param>
        /// <param name="retGoodsReason">返品理由</param>
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
        /// <param name="deliveredGoodsDiv">納品区分(例) 1:配達,2:店頭渡し,3:直送,…)</param>
        /// <param name="deliveredGoodsDivNm">納品区分名称</param>
        /// <param name="salesAreaCode">販売エリアコード(地区コード)</param>
        /// <param name="salesAreaName">販売エリア名称</param>
        /// <param name="slipPrtSetPaperId">伝票印刷設定用帳票ID(売上形式とセットで伝票タイプ管理マスタを参照)</param>
        /// <param name="completeCd">一式伝票区分(0:通常伝票,1:一式伝票)</param>
        /// <param name="salesPriceFracProcCd">売上金額端数処理区分(1:切捨て,2:四捨五入,3:切上げ　（売上明細データの金額用）)</param>
        /// <param name="stockGoodsTtlTaxExc">在庫商品合計金額（税抜）(在庫取寄区分が０の明細金額の集計)</param>
        /// <param name="pureGoodsTtlTaxExc">純正商品合計金額（税抜）(商品属性が０の明細金額の集計)</param>
        /// <param name="listPricePrintDiv">定価印刷区分</param>
        /// <param name="eraNameDispCd1">元号表示区分１(通常　　0:西暦　1:和暦)</param>
        /// <param name="totalDay">締日(DD)</param>
        /// <param name="lastTotalAddUpDt">最終締次更新年月日(YYYYMMDD)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="resultsAddUpSecNm">実績計上拠点名称</param>
        /// <param name="outputName">諸口名称</param>
        /// <returns>SearchClaimSalesクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchClaimSalesクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchClaimSales(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 delayPaymentDiv, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimName, string claimName2, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, Int32 outputNameCode, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string slipNote, string slipNote2, string slipNote3, Int32 retGoodsReasonDiv, string retGoodsReason, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 totalDay, Int32 lastTotalAddUpDt, string enterpriseName, string updEmployeeName, string resultsAddUpSecNm, string outputName, string depSalesSlipNum)
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

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this._minSectionCode = minSectionCode;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            this._debitNoteDiv = debitNoteDiv;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this._debitNLnkAcptAnOdr = debitNLnkAcptAnOdr;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            this._debitNLnkSalesSlNum = debitNLnkSalesSlNum;
            this._salesSlipCd = salesSlipCd;
            this._salesGoodsCd = salesGoodsCd;
            this._accRecDivCd = accRecDivCd;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this._serviceSlipCd = serviceSlipCd;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            this._salesInpSecCd = salesInpSecCd;
            this._demandAddUpSecCd = demandAddUpSecCd;
            this._resultsAddUpSecCd = resultsAddUpSecCd;
            this._updateSecCd = updateSecCd;
            this.SearchSlipDate = searchSlipDate;
            this.ShipmentDay = shipmentDay;
            this.SalesDate = salesDate;
            this.AddUpADate = addUpADate;
            this._delayPaymentDiv = delayPaymentDiv;
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
            this._salesSubtotalTaxInc = salesSubtotalTaxInc;
            this._salesSubtotalTaxExc = salesSubtotalTaxExc;
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
            this._itdedSalesDisTaxFre = itdedSalesDisTaxFre;
            this._salesDisOutTax = salesDisOutTax;
            this._salesDisTtlTaxInclu = salesDisTtlTaxInclu;
            this._totalCost = totalCost;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this._serviceDeposits = serviceDeposits;
            this._taxAdjust = taxAdjust;
            this._balanceAdjust = balanceAdjust;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            this._consTaxLayMethod = consTaxLayMethod;
            this._consTaxRate = consTaxRate;
            this._fractionProcCd = fractionProcCd;
            this._accRecConsTax = accRecConsTax;
            this._autoDepositCd = autoDepositCd;
            this._autoDepositSlipNo = autoDepositSlipNo;
            this._depositAllowanceTtl = depositAllowanceTtl;
            this._depositAlwcBlnce = depositAlwcBlnce;
            this._claimCode = claimCode;
            this._claimName = claimName;
            this._claimName2 = claimName2;
            this._claimSnm = claimSnm;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._customerName2 = customerName2;
            this._customerSnm = customerSnm;
            this._honorificTitle = honorificTitle;
            this._outputNameCode = outputNameCode;
            this._slipAddressDiv = slipAddressDiv;
            this._addresseeCode = addresseeCode;
            this._addresseeName = addresseeName;
            this._addresseeName2 = addresseeName2;
            this._addresseePostNo = addresseePostNo;
            this._addresseeAddr1 = addresseeAddr1;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this._addresseeAddr2 = addresseeAddr2;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

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
            this._deliveredGoodsDiv = deliveredGoodsDiv;
            this._deliveredGoodsDivNm = deliveredGoodsDivNm;
            this._salesAreaCode = salesAreaCode;
            this._salesAreaName = salesAreaName;
            this._slipPrtSetPaperId = slipPrtSetPaperId;
            this._completeCd = completeCd;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this._claimType = claimType;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            this._salesPriceFracProcCd = salesPriceFracProcCd;
            this._stockGoodsTtlTaxExc = stockGoodsTtlTaxExc;
            this._pureGoodsTtlTaxExc = pureGoodsTtlTaxExc;
            this._listPricePrintDiv = listPricePrintDiv;
            this._eraNameDispCd1 = eraNameDispCd1;
            this._totalDay = totalDay;
            this._lastTotalAddUpDt = lastTotalAddUpDt;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._resultsAddUpSecNm = resultsAddUpSecNm;
            this._outputName = outputName;
            // --- ADD 2010/12/20 ---------->>>>>
            this._depSalesSlipNum = depSalesSlipNum;
            // --- ADD 2010/12/20 ----------<<<<<
        }

        /// <summary>
        /// 請求売上検索データクラス複製処理
        /// </summary>
        /// <returns>SearchClaimSalesクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSearchClaimSalesクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchClaimSales Clone()
        {
            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            //return new SearchClaimSales(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._subSectionCode, this._minSectionCode, this._debitNoteDiv, this._debitNLnkAcptAnOdr, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._serviceSlipCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._addUpADate, this._delayPaymentDiv, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._totalCost, this._serviceDeposits, this._taxAdjust, this._balanceAdjust, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimName, this._claimName2, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputNameCode, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr2, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._slipNote, this._slipNote2, this._retGoodsReasonDiv, this._retGoodsReason, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._slipPrtSetPaperId, this._completeCd, this._claimType, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._totalDay, this._lastTotalAddUpDt, this._enterpriseName, this._updEmployeeName, this._resultsAddUpSecNm, this._outputName);
            return new SearchClaimSales(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._addUpADate, this._delayPaymentDiv, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimName, this._claimName2, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputNameCode, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._slipNote, this._slipNote2, this._slipNote3, this._retGoodsReasonDiv, this._retGoodsReason, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._totalDay, this._lastTotalAddUpDt, this._enterpriseName, this._updEmployeeName, this._resultsAddUpSecNm, this._outputName, this._depSalesSlipNum);
            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// 請求売上検索データクラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSearchClaimSalesクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchClaimSalesクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SearchClaimSales target)
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
                /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
                && (this.MinSectionCode == target.MinSectionCode)
                   --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                 && (this.DebitNoteDiv == target.DebitNoteDiv)
                /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
                && (this.DebitNLnkAcptAnOdr == target.DebitNLnkAcptAnOdr)
                   --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                 && (this.DebitNLnkSalesSlNum == target.DebitNLnkSalesSlNum)
                 && (this.SalesSlipCd == target.SalesSlipCd)
                 && (this.SalesGoodsCd == target.SalesGoodsCd)
                 && (this.AccRecDivCd == target.AccRecDivCd)
                /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
                && (this.ServiceSlipCd == target.ServiceSlipCd)
                   --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                 && (this.SalesInpSecCd == target.SalesInpSecCd)
                 && (this.DemandAddUpSecCd == target.DemandAddUpSecCd)
                 && (this.ResultsAddUpSecCd == target.ResultsAddUpSecCd)
                 && (this.UpdateSecCd == target.UpdateSecCd)
                 && (this.SearchSlipDate == target.SearchSlipDate)
                 && (this.ShipmentDay == target.ShipmentDay)
                 && (this.SalesDate == target.SalesDate)
                 && (this.AddUpADate == target.AddUpADate)
                 && (this.DelayPaymentDiv == target.DelayPaymentDiv)
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
                 && (this.SalesSubtotalTaxInc == target.SalesSubtotalTaxInc)
                 && (this.SalesSubtotalTaxExc == target.SalesSubtotalTaxExc)
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
                 && (this.ItdedSalesDisTaxFre == target.ItdedSalesDisTaxFre)
                 && (this.SalesDisOutTax == target.SalesDisOutTax)
                 && (this.SalesDisTtlTaxInclu == target.SalesDisTtlTaxInclu)
                 && (this.TotalCost == target.TotalCost)
                /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
                && (this.ServiceDeposits == target.ServiceDeposits)
                && (this.TaxAdjust == target.TaxAdjust)
                && (this.BalanceAdjust == target.BalanceAdjust)
                  --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
                 && (this.ConsTaxRate == target.ConsTaxRate)
                 && (this.FractionProcCd == target.FractionProcCd)
                 && (this.AccRecConsTax == target.AccRecConsTax)
                 && (this.AutoDepositCd == target.AutoDepositCd)
                 && (this.AutoDepositSlipNo == target.AutoDepositSlipNo)
                 && (this.DepositAllowanceTtl == target.DepositAllowanceTtl)
                 && (this.DepositAlwcBlnce == target.DepositAlwcBlnce)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.ClaimName == target.ClaimName)
                 && (this.ClaimName2 == target.ClaimName2)
                 && (this.ClaimSnm == target.ClaimSnm)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerName == target.CustomerName)
                 && (this.CustomerName2 == target.CustomerName2)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.HonorificTitle == target.HonorificTitle)
                 && (this.OutputNameCode == target.OutputNameCode)
                 && (this.SlipAddressDiv == target.SlipAddressDiv)
                 && (this.AddresseeCode == target.AddresseeCode)
                 && (this.AddresseeName == target.AddresseeName)
                 && (this.AddresseeName2 == target.AddresseeName2)
                 && (this.AddresseePostNo == target.AddresseePostNo)
                 && (this.AddresseeAddr1 == target.AddresseeAddr1)
                /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
                && (this.AddresseeAddr2 == target.AddresseeAddr2)
                  --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
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
                && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
                && (this.DeliveredGoodsDivNm == target.DeliveredGoodsDivNm)
                && (this.SalesAreaCode == target.SalesAreaCode)
                && (this.SalesAreaName == target.SalesAreaName)
                && (this.SlipPrtSetPaperId == target.SlipPrtSetPaperId)
                && (this.CompleteCd == target.CompleteCd)
                /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
                && (this.ClaimType == target.ClaimType)
                  --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                && (this.SalesPriceFracProcCd == target.SalesPriceFracProcCd)
                && (this.StockGoodsTtlTaxExc == target.StockGoodsTtlTaxExc)
                && (this.PureGoodsTtlTaxExc == target.PureGoodsTtlTaxExc)
                && (this.ListPricePrintDiv == target.ListPricePrintDiv)
                && (this.EraNameDispCd1 == target.EraNameDispCd1)
                && (this.TotalDay == target.TotalDay)
                && (this.LastTotalAddUpDt == target.LastTotalAddUpDt)
                && (this.EnterpriseName == target.EnterpriseName)
                && (this.UpdEmployeeName == target.UpdEmployeeName)
                && (this.ResultsAddUpSecNm == target.ResultsAddUpSecNm)
                && (this.OutputName == target.OutputName)
                //-----ADD 2010/12/20----->>>>>
                && (this.DepSalesSlipNum == target.DepSalesSlipNum));
                //-----ADD 2010/12/20----->>>>>
       }

       /// <summary>
       /// 請求売上検索データクラス比較処理
       /// </summary>
       /// <param name="searchClaimSales1">
       ///                    比較するSearchClaimSalesクラスのインスタンス
       /// </param>
       /// <param name="searchClaimSales2">比較するSearchClaimSalesクラスのインスタンス</param>
       /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
       /// <remarks>
       /// <br>Note　　　　　　 :   SearchClaimSalesクラスの内容が一致するか比較します</br>
       /// <br>Programer        :   自動生成</br>
       /// </remarks>
       public static bool Equals(SearchClaimSales searchClaimSales1, SearchClaimSales searchClaimSales2)
       {
           return ((searchClaimSales1.CreateDateTime == searchClaimSales2.CreateDateTime)
                && (searchClaimSales1.UpdateDateTime == searchClaimSales2.UpdateDateTime)
                && (searchClaimSales1.EnterpriseCode == searchClaimSales2.EnterpriseCode)
                && (searchClaimSales1.FileHeaderGuid == searchClaimSales2.FileHeaderGuid)
                && (searchClaimSales1.UpdEmployeeCode == searchClaimSales2.UpdEmployeeCode)
                && (searchClaimSales1.UpdAssemblyId1 == searchClaimSales2.UpdAssemblyId1)
                && (searchClaimSales1.UpdAssemblyId2 == searchClaimSales2.UpdAssemblyId2)
                && (searchClaimSales1.LogicalDeleteCode == searchClaimSales2.LogicalDeleteCode)
                && (searchClaimSales1.AcptAnOdrStatus == searchClaimSales2.AcptAnOdrStatus)
                && (searchClaimSales1.SalesSlipNum == searchClaimSales2.SalesSlipNum)
                && (searchClaimSales1.SectionCode == searchClaimSales2.SectionCode)
                && (searchClaimSales1.SubSectionCode == searchClaimSales2.SubSectionCode)
               /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
               && (searchClaimSales1.MinSectionCode == searchClaimSales2.MinSectionCode)
                  --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                 && (searchClaimSales1.DebitNoteDiv == searchClaimSales2.DebitNoteDiv)
                /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
                && (searchClaimSales1.DebitNLnkAcptAnOdr == searchClaimSales2.DebitNLnkAcptAnOdr)
                   --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                 && (searchClaimSales1.DebitNLnkSalesSlNum == searchClaimSales2.DebitNLnkSalesSlNum)
                 && (searchClaimSales1.SalesSlipCd == searchClaimSales2.SalesSlipCd)
                 && (searchClaimSales1.SalesGoodsCd == searchClaimSales2.SalesGoodsCd)
                 && (searchClaimSales1.AccRecDivCd == searchClaimSales2.AccRecDivCd)
                /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
                && (searchClaimSales1.ServiceSlipCd == searchClaimSales2.ServiceSlipCd)
                   --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                 && (searchClaimSales1.SalesInpSecCd == searchClaimSales2.SalesInpSecCd)
                 && (searchClaimSales1.DemandAddUpSecCd == searchClaimSales2.DemandAddUpSecCd)
                 && (searchClaimSales1.ResultsAddUpSecCd == searchClaimSales2.ResultsAddUpSecCd)
                 && (searchClaimSales1.UpdateSecCd == searchClaimSales2.UpdateSecCd)
                 && (searchClaimSales1.SearchSlipDate == searchClaimSales2.SearchSlipDate)
                 && (searchClaimSales1.ShipmentDay == searchClaimSales2.ShipmentDay)
                 && (searchClaimSales1.SalesDate == searchClaimSales2.SalesDate)
                 && (searchClaimSales1.AddUpADate == searchClaimSales2.AddUpADate)
                 && (searchClaimSales1.DelayPaymentDiv == searchClaimSales2.DelayPaymentDiv)
                 && (searchClaimSales1.SalesInputCode == searchClaimSales2.SalesInputCode)
                 && (searchClaimSales1.SalesInputName == searchClaimSales2.SalesInputName)
                 && (searchClaimSales1.FrontEmployeeCd == searchClaimSales2.FrontEmployeeCd)
                 && (searchClaimSales1.FrontEmployeeNm == searchClaimSales2.FrontEmployeeNm)
                 && (searchClaimSales1.SalesEmployeeCd == searchClaimSales2.SalesEmployeeCd)
                 && (searchClaimSales1.SalesEmployeeNm == searchClaimSales2.SalesEmployeeNm)
                 && (searchClaimSales1.TotalAmountDispWayCd == searchClaimSales2.TotalAmountDispWayCd)
                 && (searchClaimSales1.TtlAmntDispRateApy == searchClaimSales2.TtlAmntDispRateApy)
                 && (searchClaimSales1.SalesTotalTaxInc == searchClaimSales2.SalesTotalTaxInc)
                 && (searchClaimSales1.SalesTotalTaxExc == searchClaimSales2.SalesTotalTaxExc)
                 && (searchClaimSales1.SalesSubtotalTaxInc == searchClaimSales2.SalesSubtotalTaxInc)
                 && (searchClaimSales1.SalesSubtotalTaxExc == searchClaimSales2.SalesSubtotalTaxExc)
                 && (searchClaimSales1.SalesNetPrice == searchClaimSales2.SalesNetPrice)
                 && (searchClaimSales1.SalesSubtotalTax == searchClaimSales2.SalesSubtotalTax)
                 && (searchClaimSales1.ItdedSalesOutTax == searchClaimSales2.ItdedSalesOutTax)
                 && (searchClaimSales1.ItdedSalesInTax == searchClaimSales2.ItdedSalesInTax)
                 && (searchClaimSales1.SalSubttlSubToTaxFre == searchClaimSales2.SalSubttlSubToTaxFre)
                 && (searchClaimSales1.SalesOutTax == searchClaimSales2.SalesOutTax)
                 && (searchClaimSales1.SalAmntConsTaxInclu == searchClaimSales2.SalAmntConsTaxInclu)
                 && (searchClaimSales1.SalesDisTtlTaxExc == searchClaimSales2.SalesDisTtlTaxExc)
                 && (searchClaimSales1.ItdedSalesDisOutTax == searchClaimSales2.ItdedSalesDisOutTax)
                 && (searchClaimSales1.ItdedSalesDisInTax == searchClaimSales2.ItdedSalesDisInTax)
                 && (searchClaimSales1.ItdedSalesDisTaxFre == searchClaimSales2.ItdedSalesDisTaxFre)
                 && (searchClaimSales1.SalesDisOutTax == searchClaimSales2.SalesDisOutTax)
                 && (searchClaimSales1.SalesDisTtlTaxInclu == searchClaimSales2.SalesDisTtlTaxInclu)
                 && (searchClaimSales1.TotalCost == searchClaimSales2.TotalCost)
                /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
                && (searchClaimSales1.ServiceDeposits == searchClaimSales2.ServiceDeposits)
                && (searchClaimSales1.TaxAdjust == searchClaimSales2.TaxAdjust)
                && (searchClaimSales1.BalanceAdjust == searchClaimSales2.BalanceAdjust)
                   --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

                 && (searchClaimSales1.ConsTaxLayMethod == searchClaimSales2.ConsTaxLayMethod)
                 && (searchClaimSales1.ConsTaxRate == searchClaimSales2.ConsTaxRate)
                 && (searchClaimSales1.FractionProcCd == searchClaimSales2.FractionProcCd)
                 && (searchClaimSales1.AccRecConsTax == searchClaimSales2.AccRecConsTax)
                 && (searchClaimSales1.AutoDepositCd == searchClaimSales2.AutoDepositCd)
                 && (searchClaimSales1.AutoDepositSlipNo == searchClaimSales2.AutoDepositSlipNo)
                 && (searchClaimSales1.DepositAllowanceTtl == searchClaimSales2.DepositAllowanceTtl)
                 && (searchClaimSales1.DepositAlwcBlnce == searchClaimSales2.DepositAlwcBlnce)
                 && (searchClaimSales1.ClaimCode == searchClaimSales2.ClaimCode)
                 && (searchClaimSales1.ClaimName == searchClaimSales2.ClaimName)
                 && (searchClaimSales1.ClaimName2 == searchClaimSales2.ClaimName2)
                 && (searchClaimSales1.ClaimSnm == searchClaimSales2.ClaimSnm)
                 && (searchClaimSales1.CustomerCode == searchClaimSales2.CustomerCode)
                 && (searchClaimSales1.CustomerName == searchClaimSales2.CustomerName)
                 && (searchClaimSales1.CustomerName2 == searchClaimSales2.CustomerName2)
                 && (searchClaimSales1.CustomerSnm == searchClaimSales2.CustomerSnm)
                 && (searchClaimSales1.HonorificTitle == searchClaimSales2.HonorificTitle)
                 && (searchClaimSales1.OutputNameCode == searchClaimSales2.OutputNameCode)
                 && (searchClaimSales1.SlipAddressDiv == searchClaimSales2.SlipAddressDiv)
                 && (searchClaimSales1.AddresseeCode == searchClaimSales2.AddresseeCode)
                 && (searchClaimSales1.AddresseeName == searchClaimSales2.AddresseeName)
                 && (searchClaimSales1.AddresseeName2 == searchClaimSales2.AddresseeName2)
                 && (searchClaimSales1.AddresseePostNo == searchClaimSales2.AddresseePostNo)
                 && (searchClaimSales1.AddresseeAddr1 == searchClaimSales2.AddresseeAddr1)
                /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
                && (searchClaimSales1.AddresseeAddr2 == searchClaimSales2.AddresseeAddr2)
                   --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                 && (searchClaimSales1.AddresseeAddr3 == searchClaimSales2.AddresseeAddr3)
                 && (searchClaimSales1.AddresseeAddr4 == searchClaimSales2.AddresseeAddr4)
                 && (searchClaimSales1.AddresseeTelNo == searchClaimSales2.AddresseeTelNo)
                 && (searchClaimSales1.AddresseeFaxNo == searchClaimSales2.AddresseeFaxNo)
                 && (searchClaimSales1.PartySaleSlipNum == searchClaimSales2.PartySaleSlipNum)
                 && (searchClaimSales1.SlipNote == searchClaimSales2.SlipNote)
                 && (searchClaimSales1.SlipNote2 == searchClaimSales2.SlipNote2)
                 && (searchClaimSales1.SlipNote3 == searchClaimSales2.SlipNote3)
                 && (searchClaimSales1.RetGoodsReasonDiv == searchClaimSales2.RetGoodsReasonDiv)
                 && (searchClaimSales1.RetGoodsReason == searchClaimSales2.RetGoodsReason)
                 && (searchClaimSales1.DetailRowCount == searchClaimSales2.DetailRowCount)
                 && (searchClaimSales1.EdiSendDate == searchClaimSales2.EdiSendDate)
                 && (searchClaimSales1.EdiTakeInDate == searchClaimSales2.EdiTakeInDate)
                 && (searchClaimSales1.UoeRemark1 == searchClaimSales2.UoeRemark1)
                 && (searchClaimSales1.UoeRemark2 == searchClaimSales2.UoeRemark2)
                 && (searchClaimSales1.SlipPrintDivCd == searchClaimSales2.SlipPrintDivCd)
                 && (searchClaimSales1.SlipPrintFinishCd == searchClaimSales2.SlipPrintFinishCd)
                 && (searchClaimSales1.SalesSlipPrintDate == searchClaimSales2.SalesSlipPrintDate)
                 && (searchClaimSales1.BusinessTypeCode == searchClaimSales2.BusinessTypeCode)
                 && (searchClaimSales1.BusinessTypeName == searchClaimSales2.BusinessTypeName)
                 && (searchClaimSales1.DeliveredGoodsDiv == searchClaimSales2.DeliveredGoodsDiv)
                 && (searchClaimSales1.DeliveredGoodsDivNm == searchClaimSales2.DeliveredGoodsDivNm)
                 && (searchClaimSales1.SalesAreaCode == searchClaimSales2.SalesAreaCode)
                 && (searchClaimSales1.SalesAreaName == searchClaimSales2.SalesAreaName)
                 && (searchClaimSales1.SlipPrtSetPaperId == searchClaimSales2.SlipPrtSetPaperId)
                 && (searchClaimSales1.CompleteCd == searchClaimSales2.CompleteCd)
                /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
                && (searchClaimSales1.ClaimType == searchClaimSales2.ClaimType)
                   --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                 && (searchClaimSales1.SalesPriceFracProcCd == searchClaimSales2.SalesPriceFracProcCd)
                 && (searchClaimSales1.StockGoodsTtlTaxExc == searchClaimSales2.StockGoodsTtlTaxExc)
                 && (searchClaimSales1.PureGoodsTtlTaxExc == searchClaimSales2.PureGoodsTtlTaxExc)
                 && (searchClaimSales1.ListPricePrintDiv == searchClaimSales2.ListPricePrintDiv)
                 && (searchClaimSales1.EraNameDispCd1 == searchClaimSales2.EraNameDispCd1)
                 && (searchClaimSales1.TotalDay == searchClaimSales2.TotalDay)
                 && (searchClaimSales1.LastTotalAddUpDt == searchClaimSales2.LastTotalAddUpDt)
                 && (searchClaimSales1.EnterpriseName == searchClaimSales2.EnterpriseName)
                 && (searchClaimSales1.UpdEmployeeName == searchClaimSales2.UpdEmployeeName)
                 && (searchClaimSales1.ResultsAddUpSecNm == searchClaimSales2.ResultsAddUpSecNm)
                 && (searchClaimSales1.OutputName == searchClaimSales2.OutputName)
                 //-----ADD 2010/12/20----->>>>>
                 && (searchClaimSales1.DepSalesSlipNum == searchClaimSales2.DepSalesSlipNum));
                 //-----ADD 2010/12/20-----<<<<<
        }
        /// <summary>
        /// 請求売上検索データクラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSearchClaimSalesクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchClaimSalesクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SearchClaimSales target)
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
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.MinSectionCode != target.MinSectionCode) resList.Add("MinSectionCode");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.DebitNoteDiv != target.DebitNoteDiv) resList.Add("DebitNoteDiv");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.DebitNLnkAcptAnOdr != target.DebitNLnkAcptAnOdr) resList.Add("DebitNLnkAcptAnOdr");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.DebitNLnkSalesSlNum != target.DebitNLnkSalesSlNum) resList.Add("DebitNLnkSalesSlNum");
            if (this.SalesSlipCd != target.SalesSlipCd) resList.Add("SalesSlipCd");
            if (this.SalesGoodsCd != target.SalesGoodsCd) resList.Add("SalesGoodsCd");
            if (this.AccRecDivCd != target.AccRecDivCd) resList.Add("AccRecDivCd");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.ServiceSlipCd != target.ServiceSlipCd) resList.Add("ServiceSlipCd");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.SalesInpSecCd != target.SalesInpSecCd) resList.Add("SalesInpSecCd");
            if (this.DemandAddUpSecCd != target.DemandAddUpSecCd) resList.Add("DemandAddUpSecCd");
            if (this.ResultsAddUpSecCd != target.ResultsAddUpSecCd) resList.Add("ResultsAddUpSecCd");
            if (this.UpdateSecCd != target.UpdateSecCd) resList.Add("UpdateSecCd");
            if (this.SearchSlipDate != target.SearchSlipDate) resList.Add("SearchSlipDate");
            if (this.ShipmentDay != target.ShipmentDay) resList.Add("ShipmentDay");
            if (this.SalesDate != target.SalesDate) resList.Add("SalesDate");
            if (this.AddUpADate != target.AddUpADate) resList.Add("AddUpADate");
            if (this.DelayPaymentDiv != target.DelayPaymentDiv) resList.Add("DelayPaymentDiv");
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
            if (this.SalesSubtotalTaxInc != target.SalesSubtotalTaxInc) resList.Add("SalesSubtotalTaxInc");
            if (this.SalesSubtotalTaxExc != target.SalesSubtotalTaxExc) resList.Add("SalesSubtotalTaxExc");
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
            if (this.ItdedSalesDisTaxFre != target.ItdedSalesDisTaxFre) resList.Add("ItdedSalesDisTaxFre");
            if (this.SalesDisOutTax != target.SalesDisOutTax) resList.Add("SalesDisOutTax");
            if (this.SalesDisTtlTaxInclu != target.SalesDisTtlTaxInclu) resList.Add("SalesDisTtlTaxInclu");
            if (this.TotalCost != target.TotalCost) resList.Add("TotalCost");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.ServiceDeposits != target.ServiceDeposits) resList.Add("ServiceDeposits");
            if (this.TaxAdjust != target.TaxAdjust) resList.Add("TaxAdjust");
            if (this.BalanceAdjust != target.BalanceAdjust) resList.Add("BalanceAdjust");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.ConsTaxLayMethod != target.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (this.ConsTaxRate != target.ConsTaxRate) resList.Add("ConsTaxRate");
            if (this.FractionProcCd != target.FractionProcCd) resList.Add("FractionProcCd");
            if (this.AccRecConsTax != target.AccRecConsTax) resList.Add("AccRecConsTax");
            if (this.AutoDepositCd != target.AutoDepositCd) resList.Add("AutoDepositCd");
            if (this.AutoDepositSlipNo != target.AutoDepositSlipNo) resList.Add("AutoDepositSlipNo");
            if (this.DepositAllowanceTtl != target.DepositAllowanceTtl) resList.Add("DepositAllowanceTtl");
            if (this.DepositAlwcBlnce != target.DepositAlwcBlnce) resList.Add("DepositAlwcBlnce");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.ClaimName != target.ClaimName) resList.Add("ClaimName");
            if (this.ClaimName2 != target.ClaimName2) resList.Add("ClaimName2");
            if (this.ClaimSnm != target.ClaimSnm) resList.Add("ClaimSnm");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.HonorificTitle != target.HonorificTitle) resList.Add("HonorificTitle");
            if (this.OutputNameCode != target.OutputNameCode) resList.Add("OutputNameCode");
            if (this.SlipAddressDiv != target.SlipAddressDiv) resList.Add("SlipAddressDiv");
            if (this.AddresseeCode != target.AddresseeCode) resList.Add("AddresseeCode");
            if (this.AddresseeName != target.AddresseeName) resList.Add("AddresseeName");
            if (this.AddresseeName2 != target.AddresseeName2) resList.Add("AddresseeName2");
            if (this.AddresseePostNo != target.AddresseePostNo) resList.Add("AddresseePostNo");
            if (this.AddresseeAddr1 != target.AddresseeAddr1) resList.Add("AddresseeAddr1");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.AddresseeAddr2 != target.AddresseeAddr2) resList.Add("AddresseeAddr2");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
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
            if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (this.DeliveredGoodsDivNm != target.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (this.SalesAreaCode != target.SalesAreaCode) resList.Add("SalesAreaCode");
            if (this.SalesAreaName != target.SalesAreaName) resList.Add("SalesAreaName");
            if (this.SlipPrtSetPaperId != target.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
            if (this.CompleteCd != target.CompleteCd) resList.Add("CompleteCd");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.ClaimType != target.ClaimType) resList.Add("ClaimType");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.SalesPriceFracProcCd != target.SalesPriceFracProcCd) resList.Add("SalesPriceFracProcCd");
            if (this.StockGoodsTtlTaxExc != target.StockGoodsTtlTaxExc) resList.Add("StockGoodsTtlTaxExc");
            if (this.PureGoodsTtlTaxExc != target.PureGoodsTtlTaxExc) resList.Add("PureGoodsTtlTaxExc");
            if (this.ListPricePrintDiv != target.ListPricePrintDiv) resList.Add("ListPricePrintDiv");
            if (this.EraNameDispCd1 != target.EraNameDispCd1) resList.Add("EraNameDispCd1");
            if (this.TotalDay != target.TotalDay) resList.Add("TotalDay");
            if (this.LastTotalAddUpDt != target.LastTotalAddUpDt) resList.Add("LastTotalAddUpDt");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.ResultsAddUpSecNm != target.ResultsAddUpSecNm) resList.Add("ResultsAddUpSecNm");
            if (this.OutputName != target.OutputName) resList.Add("OutputName");
            //-----ADD 2010/12/20----->>>>>
            if (this.DepSalesSlipNum != target.DepSalesSlipNum) resList.Add("DepSalesSlipNum");
            //-----ADD 2010/12/20-----<<<<<
            return resList;
        }

        /// <summary>
        /// 請求売上検索データクラス比較処理
        /// </summary>
        /// <param name="searchClaimSales1">比較するSearchClaimSalesクラスのインスタンス</param>
        /// <param name="searchClaimSales2">比較するSearchClaimSalesクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchClaimSalesクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SearchClaimSales searchClaimSales1, SearchClaimSales searchClaimSales2)
        {
            ArrayList resList = new ArrayList();
            if (searchClaimSales1.CreateDateTime != searchClaimSales2.CreateDateTime) resList.Add("CreateDateTime");
            if (searchClaimSales1.UpdateDateTime != searchClaimSales2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (searchClaimSales1.EnterpriseCode != searchClaimSales2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (searchClaimSales1.FileHeaderGuid != searchClaimSales2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (searchClaimSales1.UpdEmployeeCode != searchClaimSales2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (searchClaimSales1.UpdAssemblyId1 != searchClaimSales2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (searchClaimSales1.UpdAssemblyId2 != searchClaimSales2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (searchClaimSales1.LogicalDeleteCode != searchClaimSales2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (searchClaimSales1.AcptAnOdrStatus != searchClaimSales2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (searchClaimSales1.SalesSlipNum != searchClaimSales2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (searchClaimSales1.SectionCode != searchClaimSales2.SectionCode) resList.Add("SectionCode");
            if (searchClaimSales1.SubSectionCode != searchClaimSales2.SubSectionCode) resList.Add("SubSectionCode");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchClaimSales1.MinSectionCode != searchClaimSales2.MinSectionCode) resList.Add("MinSectionCode");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchClaimSales1.DebitNoteDiv != searchClaimSales2.DebitNoteDiv) resList.Add("DebitNoteDiv");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchClaimSales1.DebitNLnkAcptAnOdr != searchClaimSales2.DebitNLnkAcptAnOdr) resList.Add("DebitNLnkAcptAnOdr");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchClaimSales1.DebitNLnkSalesSlNum != searchClaimSales2.DebitNLnkSalesSlNum) resList.Add("DebitNLnkSalesSlNum");
            if (searchClaimSales1.SalesSlipCd != searchClaimSales2.SalesSlipCd) resList.Add("SalesSlipCd");
            if (searchClaimSales1.SalesGoodsCd != searchClaimSales2.SalesGoodsCd) resList.Add("SalesGoodsCd");
            if (searchClaimSales1.AccRecDivCd != searchClaimSales2.AccRecDivCd) resList.Add("AccRecDivCd");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchClaimSales1.ServiceSlipCd != searchClaimSales2.ServiceSlipCd) resList.Add("ServiceSlipCd");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchClaimSales1.SalesInpSecCd != searchClaimSales2.SalesInpSecCd) resList.Add("SalesInpSecCd");
            if (searchClaimSales1.DemandAddUpSecCd != searchClaimSales2.DemandAddUpSecCd) resList.Add("DemandAddUpSecCd");
            if (searchClaimSales1.ResultsAddUpSecCd != searchClaimSales2.ResultsAddUpSecCd) resList.Add("ResultsAddUpSecCd");
            if (searchClaimSales1.UpdateSecCd != searchClaimSales2.UpdateSecCd) resList.Add("UpdateSecCd");
            if (searchClaimSales1.SearchSlipDate != searchClaimSales2.SearchSlipDate) resList.Add("SearchSlipDate");
            if (searchClaimSales1.ShipmentDay != searchClaimSales2.ShipmentDay) resList.Add("ShipmentDay");
            if (searchClaimSales1.SalesDate != searchClaimSales2.SalesDate) resList.Add("SalesDate");
            if (searchClaimSales1.AddUpADate != searchClaimSales2.AddUpADate) resList.Add("AddUpADate");
            if (searchClaimSales1.DelayPaymentDiv != searchClaimSales2.DelayPaymentDiv) resList.Add("DelayPaymentDiv");
            if (searchClaimSales1.SalesInputCode != searchClaimSales2.SalesInputCode) resList.Add("SalesInputCode");
            if (searchClaimSales1.SalesInputName != searchClaimSales2.SalesInputName) resList.Add("SalesInputName");
            if (searchClaimSales1.FrontEmployeeCd != searchClaimSales2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (searchClaimSales1.FrontEmployeeNm != searchClaimSales2.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
            if (searchClaimSales1.SalesEmployeeCd != searchClaimSales2.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (searchClaimSales1.SalesEmployeeNm != searchClaimSales2.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (searchClaimSales1.TotalAmountDispWayCd != searchClaimSales2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (searchClaimSales1.TtlAmntDispRateApy != searchClaimSales2.TtlAmntDispRateApy) resList.Add("TtlAmntDispRateApy");
            if (searchClaimSales1.SalesTotalTaxInc != searchClaimSales2.SalesTotalTaxInc) resList.Add("SalesTotalTaxInc");
            if (searchClaimSales1.SalesTotalTaxExc != searchClaimSales2.SalesTotalTaxExc) resList.Add("SalesTotalTaxExc");
            if (searchClaimSales1.SalesSubtotalTaxInc != searchClaimSales2.SalesSubtotalTaxInc) resList.Add("SalesSubtotalTaxInc");
            if (searchClaimSales1.SalesSubtotalTaxExc != searchClaimSales2.SalesSubtotalTaxExc) resList.Add("SalesSubtotalTaxExc");
            if (searchClaimSales1.SalesNetPrice != searchClaimSales2.SalesNetPrice) resList.Add("SalesNetPrice");
            if (searchClaimSales1.SalesSubtotalTax != searchClaimSales2.SalesSubtotalTax) resList.Add("SalesSubtotalTax");
            if (searchClaimSales1.ItdedSalesOutTax != searchClaimSales2.ItdedSalesOutTax) resList.Add("ItdedSalesOutTax");
            if (searchClaimSales1.ItdedSalesInTax != searchClaimSales2.ItdedSalesInTax) resList.Add("ItdedSalesInTax");
            if (searchClaimSales1.SalSubttlSubToTaxFre != searchClaimSales2.SalSubttlSubToTaxFre) resList.Add("SalSubttlSubToTaxFre");
            if (searchClaimSales1.SalesOutTax != searchClaimSales2.SalesOutTax) resList.Add("SalesOutTax");
            if (searchClaimSales1.SalAmntConsTaxInclu != searchClaimSales2.SalAmntConsTaxInclu) resList.Add("SalAmntConsTaxInclu");
            if (searchClaimSales1.SalesDisTtlTaxExc != searchClaimSales2.SalesDisTtlTaxExc) resList.Add("SalesDisTtlTaxExc");
            if (searchClaimSales1.ItdedSalesDisOutTax != searchClaimSales2.ItdedSalesDisOutTax) resList.Add("ItdedSalesDisOutTax");
            if (searchClaimSales1.ItdedSalesDisInTax != searchClaimSales2.ItdedSalesDisInTax) resList.Add("ItdedSalesDisInTax");
            if (searchClaimSales1.ItdedSalesDisTaxFre != searchClaimSales2.ItdedSalesDisTaxFre) resList.Add("ItdedSalesDisTaxFre");
            if (searchClaimSales1.SalesDisOutTax != searchClaimSales2.SalesDisOutTax) resList.Add("SalesDisOutTax");
            if (searchClaimSales1.SalesDisTtlTaxInclu != searchClaimSales2.SalesDisTtlTaxInclu) resList.Add("SalesDisTtlTaxInclu");
            if (searchClaimSales1.TotalCost != searchClaimSales2.TotalCost) resList.Add("TotalCost");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchClaimSales1.ServiceDeposits != searchClaimSales2.ServiceDeposits) resList.Add("ServiceDeposits");
            if (searchClaimSales1.TaxAdjust != searchClaimSales2.TaxAdjust) resList.Add("TaxAdjust");
            if (searchClaimSales1.BalanceAdjust != searchClaimSales2.BalanceAdjust) resList.Add("BalanceAdjust");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchClaimSales1.ConsTaxLayMethod != searchClaimSales2.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (searchClaimSales1.ConsTaxRate != searchClaimSales2.ConsTaxRate) resList.Add("ConsTaxRate");
            if (searchClaimSales1.FractionProcCd != searchClaimSales2.FractionProcCd) resList.Add("FractionProcCd");
            if (searchClaimSales1.AccRecConsTax != searchClaimSales2.AccRecConsTax) resList.Add("AccRecConsTax");
            if (searchClaimSales1.AutoDepositCd != searchClaimSales2.AutoDepositCd) resList.Add("AutoDepositCd");
            if (searchClaimSales1.AutoDepositSlipNo != searchClaimSales2.AutoDepositSlipNo) resList.Add("AutoDepositSlipNo");
            if (searchClaimSales1.DepositAllowanceTtl != searchClaimSales2.DepositAllowanceTtl) resList.Add("DepositAllowanceTtl");
            if (searchClaimSales1.DepositAlwcBlnce != searchClaimSales2.DepositAlwcBlnce) resList.Add("DepositAlwcBlnce");
            if (searchClaimSales1.ClaimCode != searchClaimSales2.ClaimCode) resList.Add("ClaimCode");
            if (searchClaimSales1.ClaimName != searchClaimSales2.ClaimName) resList.Add("ClaimName");
            if (searchClaimSales1.ClaimName2 != searchClaimSales2.ClaimName2) resList.Add("ClaimName2");
            if (searchClaimSales1.ClaimSnm != searchClaimSales2.ClaimSnm) resList.Add("ClaimSnm");
            if (searchClaimSales1.CustomerCode != searchClaimSales2.CustomerCode) resList.Add("CustomerCode");
            if (searchClaimSales1.CustomerName != searchClaimSales2.CustomerName) resList.Add("CustomerName");
            if (searchClaimSales1.CustomerName2 != searchClaimSales2.CustomerName2) resList.Add("CustomerName2");
            if (searchClaimSales1.CustomerSnm != searchClaimSales2.CustomerSnm) resList.Add("CustomerSnm");
            if (searchClaimSales1.HonorificTitle != searchClaimSales2.HonorificTitle) resList.Add("HonorificTitle");
            if (searchClaimSales1.OutputNameCode != searchClaimSales2.OutputNameCode) resList.Add("OutputNameCode");
            if (searchClaimSales1.SlipAddressDiv != searchClaimSales2.SlipAddressDiv) resList.Add("SlipAddressDiv");
            if (searchClaimSales1.AddresseeCode != searchClaimSales2.AddresseeCode) resList.Add("AddresseeCode");
            if (searchClaimSales1.AddresseeName != searchClaimSales2.AddresseeName) resList.Add("AddresseeName");
            if (searchClaimSales1.AddresseeName2 != searchClaimSales2.AddresseeName2) resList.Add("AddresseeName2");
            if (searchClaimSales1.AddresseePostNo != searchClaimSales2.AddresseePostNo) resList.Add("AddresseePostNo");
            if (searchClaimSales1.AddresseeAddr1 != searchClaimSales2.AddresseeAddr1) resList.Add("AddresseeAddr1");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchClaimSales1.AddresseeAddr2 != searchClaimSales2.AddresseeAddr2) resList.Add("AddresseeAddr2");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchClaimSales1.AddresseeAddr3 != searchClaimSales2.AddresseeAddr3) resList.Add("AddresseeAddr3");
            if (searchClaimSales1.AddresseeAddr4 != searchClaimSales2.AddresseeAddr4) resList.Add("AddresseeAddr4");
            if (searchClaimSales1.AddresseeTelNo != searchClaimSales2.AddresseeTelNo) resList.Add("AddresseeTelNo");
            if (searchClaimSales1.AddresseeFaxNo != searchClaimSales2.AddresseeFaxNo) resList.Add("AddresseeFaxNo");
            if (searchClaimSales1.PartySaleSlipNum != searchClaimSales2.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (searchClaimSales1.SlipNote != searchClaimSales2.SlipNote) resList.Add("SlipNote");
            if (searchClaimSales1.SlipNote2 != searchClaimSales2.SlipNote2) resList.Add("SlipNote2");
            if (searchClaimSales1.SlipNote3 != searchClaimSales2.SlipNote3) resList.Add("SlipNote3");
            if (searchClaimSales1.RetGoodsReasonDiv != searchClaimSales2.RetGoodsReasonDiv) resList.Add("RetGoodsReasonDiv");
            if (searchClaimSales1.RetGoodsReason != searchClaimSales2.RetGoodsReason) resList.Add("RetGoodsReason");
            if (searchClaimSales1.DetailRowCount != searchClaimSales2.DetailRowCount) resList.Add("DetailRowCount");
            if (searchClaimSales1.EdiSendDate != searchClaimSales2.EdiSendDate) resList.Add("EdiSendDate");
            if (searchClaimSales1.EdiTakeInDate != searchClaimSales2.EdiTakeInDate) resList.Add("EdiTakeInDate");
            if (searchClaimSales1.UoeRemark1 != searchClaimSales2.UoeRemark1) resList.Add("UoeRemark1");
            if (searchClaimSales1.UoeRemark2 != searchClaimSales2.UoeRemark2) resList.Add("UoeRemark2");
            if (searchClaimSales1.SlipPrintDivCd != searchClaimSales2.SlipPrintDivCd) resList.Add("SlipPrintDivCd");
            if (searchClaimSales1.SlipPrintFinishCd != searchClaimSales2.SlipPrintFinishCd) resList.Add("SlipPrintFinishCd");
            if (searchClaimSales1.SalesSlipPrintDate != searchClaimSales2.SalesSlipPrintDate) resList.Add("SalesSlipPrintDate");
            if (searchClaimSales1.BusinessTypeCode != searchClaimSales2.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (searchClaimSales1.BusinessTypeName != searchClaimSales2.BusinessTypeName) resList.Add("BusinessTypeName");
            if (searchClaimSales1.DeliveredGoodsDiv != searchClaimSales2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (searchClaimSales1.DeliveredGoodsDivNm != searchClaimSales2.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (searchClaimSales1.SalesAreaCode != searchClaimSales2.SalesAreaCode) resList.Add("SalesAreaCode");
            if (searchClaimSales1.SalesAreaName != searchClaimSales2.SalesAreaName) resList.Add("SalesAreaName");
            if (searchClaimSales1.SlipPrtSetPaperId != searchClaimSales2.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
            if (searchClaimSales1.CompleteCd != searchClaimSales2.CompleteCd) resList.Add("CompleteCd");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchClaimSales1.ClaimType != searchClaimSales2.ClaimType) resList.Add("ClaimType");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchClaimSales1.SalesPriceFracProcCd != searchClaimSales2.SalesPriceFracProcCd) resList.Add("SalesPriceFracProcCd");
            if (searchClaimSales1.StockGoodsTtlTaxExc != searchClaimSales2.StockGoodsTtlTaxExc) resList.Add("StockGoodsTtlTaxExc");
            if (searchClaimSales1.PureGoodsTtlTaxExc != searchClaimSales2.PureGoodsTtlTaxExc) resList.Add("PureGoodsTtlTaxExc");
            if (searchClaimSales1.ListPricePrintDiv != searchClaimSales2.ListPricePrintDiv) resList.Add("ListPricePrintDiv");
            if (searchClaimSales1.EraNameDispCd1 != searchClaimSales2.EraNameDispCd1) resList.Add("EraNameDispCd1");
            if (searchClaimSales1.TotalDay != searchClaimSales2.TotalDay) resList.Add("TotalDay");
            if (searchClaimSales1.LastTotalAddUpDt != searchClaimSales2.LastTotalAddUpDt) resList.Add("LastTotalAddUpDt");
            if (searchClaimSales1.EnterpriseName != searchClaimSales2.EnterpriseName) resList.Add("EnterpriseName");
            if (searchClaimSales1.UpdEmployeeName != searchClaimSales2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (searchClaimSales1.ResultsAddUpSecNm != searchClaimSales2.ResultsAddUpSecNm) resList.Add("ResultsAddUpSecNm");
            if (searchClaimSales1.OutputName != searchClaimSales2.OutputName) resList.Add("OutputName");
            //-----ADD 2010/12/20----->>>>>
            if (searchClaimSales1.DepSalesSlipNum != searchClaimSales2.DepSalesSlipNum) resList.Add("DepSalesSlipNum");
            //-----ADD 2010/12/20-----<<<<<
            return resList;
        }
    }
}
