using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockSlipWork
    /// <summary>
    ///                      仕入データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/06/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockSlipWork : IFileHeader
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

        /// <summary>仕入形式</summary>
        /// <remarks>0:仕入,1:入荷,2:発注　（受注ステータス）</remarks>
        private Int32 _supplierFormal;

        /// <summary>仕入伝票番号</summary>
        /// <remarks>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>赤黒連結仕入伝票番号</summary>
        private Int32 _debitNLnkSuppSlipNo;

        /// <summary>仕入伝票区分</summary>
        /// <remarks>10:仕入,20:返品</remarks>
        private Int32 _supplierSlipCd;

        /// <summary>仕入商品区分</summary>
        /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動),11:相殺,12:相殺(自動)</remarks>
        private Int32 _stockGoodsCd;

        /// <summary>買掛区分</summary>
        /// <remarks>0:買掛なし,1:買掛</remarks>
        private Int32 _accPayDivCd;

        /// <summary>仕入拠点コード</summary>
        private string _stockSectionCd = "";

        /// <summary>仕入計上拠点コード</summary>
        /// <remarks>文字型 仕入計上対象の拠点コード(拠点制御の支払計上拠点のこと)</remarks>
        private string _stockAddUpSectionCd = "";

        /// <summary>仕入伝票更新区分</summary>
        /// <remarks>0:未更新,1:更新あり</remarks>
        private Int32 _stockSlipUpdateCd;

        /// <summary>入力日</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _inputDay;

        /// <summary>入荷日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _arrivalGoodsDay;

        /// <summary>仕入日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _stockDate;

        // ----- ADD 2011/12/15 ------->>>>>
        /// <summary>前回仕入日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _preStockDate;
        // ----- ADD 2011/12/15 -------<<<<<

        /// <summary>仕入計上日付</summary>
        /// <remarks>仕入計上日</remarks>
        private DateTime _stockAddUpADate;

        /// <summary>来勘区分</summary>
        /// <remarks>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</remarks>
        private Int32 _delayPaymentDiv;

        /// <summary>支払先コード</summary>
        /// <remarks>支払先(精算先)コード。支払締時は支払先単位で集計・計算。</remarks>
        private Int32 _payeeCode;

        /// <summary>支払先略称</summary>
        private string _payeeSnm = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先名1</summary>
        private string _supplierNm1 = "";

        /// <summary>仕入先名2</summary>
        private string _supplierNm2 = "";

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>業種コード</summary>
        private Int32 _businessTypeCode;

        /// <summary>業種名称</summary>
        private string _businessTypeName = "";

        /// <summary>販売エリアコード</summary>
        /// <remarks>地区コード</remarks>
        private Int32 _salesAreaCode;

        /// <summary>販売エリア名称</summary>
        private string _salesAreaName = "";

        /// <summary>仕入入力者コード</summary>
        private string _stockInputCode = "";

        /// <summary>仕入入力者名称</summary>
        private string _stockInputName = "";

        /// <summary>仕入担当者コード</summary>
        /// <remarks>発注者をセット</remarks>
        private string _stockAgentCode = "";

        /// <summary>仕入担当者名称</summary>
        /// <remarks>発注者をセット</remarks>
        private string _stockAgentName = "";

        /// <summary>仕入先総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _suppTtlAmntDspWayCd;

        /// <summary>総額表示掛率適用区分</summary>
        /// <remarks>0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率</remarks>
        private Int32 _ttlAmntDispRateApy;

        /// <summary>仕入金額合計</summary>
        /// <remarks>仕入金額合計＝仕入金額計（税込み）＋非課税対象額合計</remarks>
        private Int64 _stockTotalPrice;

        /// <summary>仕入金額小計</summary>
        /// <remarks>仕入金額小計＝仕入金額計（税抜き）＋非課税対象額合計</remarks>
        private Int64 _stockSubttlPrice;

        /// <summary>仕入金額計（税込み）</summary>
        /// <remarks>外税時：税抜き＋消費税、内税時：内税価格（税込）の集計</remarks>
        private Int64 _stockTtlPricTaxInc;

        /// <summary>仕入金額計（税抜き）</summary>
        /// <remarks>外税時：税抜価格の集計、内税時：内税価格（税込）の集計－消費税</remarks>
        private Int64 _stockTtlPricTaxExc;

        /// <summary>仕入正価金額</summary>
        /// <remarks>値引前の税抜仕入金額</remarks>
        private Int64 _stockNetPrice;

        /// <summary>仕入金額消費税額</summary>
        /// <remarks>仕入金額消費税額（外税）+仕入金額消費税額（内税）</remarks>
        private Int64 _stockPriceConsTax;

        /// <summary>仕入外税対象額合計</summary>
        /// <remarks>外税対象金額の集計（税抜、値引含まず）</remarks>
        private Int64 _ttlItdedStcOutTax;

        /// <summary>仕入内税対象額合計</summary>
        /// <remarks>内税対象金額の集計（税抜、値引含まず） </remarks>
        private Int64 _ttlItdedStcInTax;

        /// <summary>仕入非課税対象額合計</summary>
        /// <remarks>非課税対象金額の集計（値引含まず）</remarks>
        private Int64 _ttlItdedStcTaxFree;

        /// <summary>仕入金額消費税額（外税）</summary>
        /// <remarks>値引前の外税商品の消費税</remarks>
        private Int64 _stockOutTax;

        /// <summary>仕入金額消費税額（内税）</summary>
        /// <remarks>値引前の内税商品の消費税</remarks>
        private Int64 _stckPrcConsTaxInclu;

        /// <summary>仕入値引金額計（税抜き）</summary>
        /// <remarks>仕入値引外税対象額合計+仕入値引内税対象額合計+仕入値引非課税対象額合計</remarks>
        private Int64 _stckDisTtlTaxExc;

        /// <summary>仕入値引外税対象額合計</summary>
        /// <remarks>外税商品値引の外税対象額（税抜）</remarks>
        private Int64 _itdedStockDisOutTax;

        /// <summary>仕入値引内税対象額合計</summary>
        /// <remarks>内税商品値引の内税対象額（税抜）</remarks>
        private Int64 _itdedStockDisInTax;

        /// <summary>仕入値引非課税対象額合計</summary>
        /// <remarks>非課税商品値引の非課税対象額</remarks>
        private Int64 _itdedStockDisTaxFre;

        /// <summary>仕入値引消費税額（外税）</summary>
        /// <remarks>外税商品値引の消費税額</remarks>
        private Int64 _stockDisOutTax;

        /// <summary>仕入値引消費税額（内税）</summary>
        /// <remarks>内税商品値引の消費税額</remarks>
        private Int64 _stckDisTtlTaxInclu;

        /// <summary>消費税調整額</summary>
        private Int64 _taxAdjust;

        /// <summary>残高調整額</summary>
        private Int64 _balanceAdjust;

        /// <summary>仕入先消費税転嫁方式コード</summary>
        /// <remarks>0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税</remarks>
        private Int32 _suppCTaxLayCd;

        /// <summary>仕入先消費税税率</summary>
        private Double _supplierConsTaxRate;

        /// <summary>買掛消費税</summary>
        private Int64 _accPayConsTax;

        /// <summary>仕入端数処理区分</summary>
        /// <remarks>1:切捨て,2:四捨五入,3:切上げ　（消費税）</remarks>
        private Int32 _stockFractionProcCd;

        /// <summary>自動支払区分</summary>
        /// <remarks>0:通常支払,1:自動支払</remarks>
        private Int32 _autoPayment;

        /// <summary>自動支払伝票番号</summary>
        /// <remarks>自動支払時の支払伝票番号</remarks>
        private Int32 _autoPaySlipNum;

        /// <summary>返品理由コード</summary>
        private Int32 _retGoodsReasonDiv;

        /// <summary>返品理由</summary>
        private string _retGoodsReason = "";

        /// <summary>相手先伝票番号</summary>
        /// <remarks>仕入先伝票番号に使用する</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>仕入伝票備考1</summary>
        private string _supplierSlipNote1 = "";

        /// <summary>仕入伝票備考2</summary>
        private string _supplierSlipNote2 = "";

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

        /// <summary>仕入伝票発行日</summary>
        /// <remarks>入荷では入荷伝票発行日（発注書発行日もここを使用）</remarks>
        private DateTime _stockSlipPrintDate;

        /// <summary>伝票印刷設定用帳票ID</summary>
        /// <remarks>仕入形式とセットで伝票タイプ管理マスタを参照　（発注,入荷用）</remarks>
        private string _slipPrtSetPaperId = "";

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

        /// <summary>直送区分</summary>
        /// <remarks>0:直送なし,1:直送あり　（発注書の直送先印字制御）</remarks>
        private Int32 _directSendingCd;


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

        /// public propaty name  :  SupplierFormal
        /// <summary>仕入形式プロパティ</summary>
        /// <value>0:仕入,1:入荷,2:発注　（受注ステータス）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// <value>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる</value>
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

        /// public propaty name  :  DebitNLnkSuppSlipNo
        /// <summary>赤黒連結仕入伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤黒連結仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNLnkSuppSlipNo
        {
            get { return _debitNLnkSuppSlipNo; }
            set { _debitNLnkSuppSlipNo = value; }
        }

        /// public propaty name  :  SupplierSlipCd
        /// <summary>仕入伝票区分プロパティ</summary>
        /// <value>10:仕入,20:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipCd
        {
            get { return _supplierSlipCd; }
            set { _supplierSlipCd = value; }
        }

        /// public propaty name  :  StockGoodsCd
        /// <summary>仕入商品区分プロパティ</summary>
        /// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動),11:相殺,12:相殺(自動)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入商品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockGoodsCd
        {
            get { return _stockGoodsCd; }
            set { _stockGoodsCd = value; }
        }

        /// public propaty name  :  AccPayDivCd
        /// <summary>買掛区分プロパティ</summary>
        /// <value>0:買掛なし,1:買掛</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   買掛区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccPayDivCd
        {
            get { return _accPayDivCd; }
            set { _accPayDivCd = value; }
        }

        /// public propaty name  :  StockSectionCd
        /// <summary>仕入拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockSectionCd
        {
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
        }

        /// public propaty name  :  StockAddUpSectionCd
        /// <summary>仕入計上拠点コードプロパティ</summary>
        /// <value>文字型 仕入計上対象の拠点コード(拠点制御の支払計上拠点のこと)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAddUpSectionCd
        {
            get { return _stockAddUpSectionCd; }
            set { _stockAddUpSectionCd = value; }
        }

        /// public propaty name  :  StockSlipUpdateCd
        /// <summary>仕入伝票更新区分プロパティ</summary>
        /// <value>0:未更新,1:更新あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSlipUpdateCd
        {
            get { return _stockSlipUpdateCd; }
            set { _stockSlipUpdateCd = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>入力日プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsDay
        /// <summary>入荷日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ArrivalGoodsDay
        {
            get { return _arrivalGoodsDay; }
            set { _arrivalGoodsDay = value; }
        }

        /// public propaty name  :  StockDate
        /// <summary>仕入日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockDate
        {
            get { return _stockDate; }
            set { _stockDate = value; }
        }

        // ----- ADD 2011/12/15 ----------------------------->>>>>
        /// public propaty name  :  PreStockDate
        /// <summary>前回仕入日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回仕入日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PreStockDate
        {
            get { return _preStockDate; }
            set { _preStockDate = value; }
        }
        // ----- ADD 2011/12/15 -----------------------------<<<<<

        /// public propaty name  :  StockAddUpADate
        /// <summary>仕入計上日付プロパティ</summary>
        /// <value>仕入計上日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入計上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockAddUpADate
        {
            get { return _stockAddUpADate; }
            set { _stockAddUpADate = value; }
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

        /// public propaty name  :  PayeeCode
        /// <summary>支払先コードプロパティ</summary>
        /// <value>支払先(精算先)コード。支払締時は支払先単位で集計・計算。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  PayeeSnm
        /// <summary>支払先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
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

        /// public propaty name  :  SupplierNm1
        /// <summary>仕入先名1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }

        /// public propaty name  :  SupplierNm2
        /// <summary>仕入先名2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm2
        {
            get { return _supplierNm2; }
            set { _supplierNm2 = value; }
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

        /// public propaty name  :  StockInputCode
        /// <summary>仕入入力者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockInputCode
        {
            get { return _stockInputCode; }
            set { _stockInputCode = value; }
        }

        /// public propaty name  :  StockInputName
        /// <summary>仕入入力者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入入力者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockInputName
        {
            get { return _stockInputName; }
            set { _stockInputName = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>仕入担当者コードプロパティ</summary>
        /// <value>発注者をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  StockAgentName
        /// <summary>仕入担当者名称プロパティ</summary>
        /// <value>発注者をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }

        /// public propaty name  :  SuppTtlAmntDspWayCd
        /// <summary>仕入先総額表示方法区分プロパティ</summary>
        /// <value>0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先総額表示方法区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SuppTtlAmntDspWayCd
        {
            get { return _suppTtlAmntDspWayCd; }
            set { _suppTtlAmntDspWayCd = value; }
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

        /// public propaty name  :  StockTotalPrice
        /// <summary>仕入金額合計プロパティ</summary>
        /// <value>仕入金額合計＝仕入金額計（税込み）＋非課税対象額合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalPrice
        {
            get { return _stockTotalPrice; }
            set { _stockTotalPrice = value; }
        }

        /// public propaty name  :  StockSubttlPrice
        /// <summary>仕入金額小計プロパティ</summary>
        /// <value>仕入金額小計＝仕入金額計（税抜き）＋非課税対象額合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額小計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockSubttlPrice
        {
            get { return _stockSubttlPrice; }
            set { _stockSubttlPrice = value; }
        }

        /// public propaty name  :  StockTtlPricTaxInc
        /// <summary>仕入金額計（税込み）プロパティ</summary>
        /// <value>外税時：税抜き＋消費税、内税時：内税価格（税込）の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTtlPricTaxInc
        {
            get { return _stockTtlPricTaxInc; }
            set { _stockTtlPricTaxInc = value; }
        }

        /// public propaty name  :  StockTtlPricTaxExc
        /// <summary>仕入金額計（税抜き）プロパティ</summary>
        /// <value>外税時：税抜価格の集計、内税時：内税価格（税込）の集計－消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTtlPricTaxExc
        {
            get { return _stockTtlPricTaxExc; }
            set { _stockTtlPricTaxExc = value; }
        }

        /// public propaty name  :  StockNetPrice
        /// <summary>仕入正価金額プロパティ</summary>
        /// <value>値引前の税抜仕入金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入正価金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockNetPrice
        {
            get { return _stockNetPrice; }
            set { _stockNetPrice = value; }
        }

        /// public propaty name  :  StockPriceConsTax
        /// <summary>仕入金額消費税額プロパティ</summary>
        /// <value>仕入金額消費税額（外税）+仕入金額消費税額（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額消費税額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceConsTax
        {
            get { return _stockPriceConsTax; }
            set { _stockPriceConsTax = value; }
        }

        /// public propaty name  :  TtlItdedStcOutTax
        /// <summary>仕入外税対象額合計プロパティ</summary>
        /// <value>外税対象金額の集計（税抜、値引含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入外税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedStcOutTax
        {
            get { return _ttlItdedStcOutTax; }
            set { _ttlItdedStcOutTax = value; }
        }

        /// public propaty name  :  TtlItdedStcInTax
        /// <summary>仕入内税対象額合計プロパティ</summary>
        /// <value>内税対象金額の集計（税抜、値引含まず） </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入内税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedStcInTax
        {
            get { return _ttlItdedStcInTax; }
            set { _ttlItdedStcInTax = value; }
        }

        /// public propaty name  :  TtlItdedStcTaxFree
        /// <summary>仕入非課税対象額合計プロパティ</summary>
        /// <value>非課税対象金額の集計（値引含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入非課税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedStcTaxFree
        {
            get { return _ttlItdedStcTaxFree; }
            set { _ttlItdedStcTaxFree = value; }
        }

        /// public propaty name  :  StockOutTax
        /// <summary>仕入金額消費税額（外税）プロパティ</summary>
        /// <value>値引前の外税商品の消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額消費税額（外税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockOutTax
        {
            get { return _stockOutTax; }
            set { _stockOutTax = value; }
        }

        /// public propaty name  :  StckPrcConsTaxInclu
        /// <summary>仕入金額消費税額（内税）プロパティ</summary>
        /// <value>値引前の内税商品の消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額消費税額（内税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StckPrcConsTaxInclu
        {
            get { return _stckPrcConsTaxInclu; }
            set { _stckPrcConsTaxInclu = value; }
        }

        /// public propaty name  :  StckDisTtlTaxExc
        /// <summary>仕入値引金額計（税抜き）プロパティ</summary>
        /// <value>仕入値引外税対象額合計+仕入値引内税対象額合計+仕入値引非課税対象額合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引金額計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StckDisTtlTaxExc
        {
            get { return _stckDisTtlTaxExc; }
            set { _stckDisTtlTaxExc = value; }
        }

        /// public propaty name  :  ItdedStockDisOutTax
        /// <summary>仕入値引外税対象額合計プロパティ</summary>
        /// <value>外税商品値引の外税対象額（税抜）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引外税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedStockDisOutTax
        {
            get { return _itdedStockDisOutTax; }
            set { _itdedStockDisOutTax = value; }
        }

        /// public propaty name  :  ItdedStockDisInTax
        /// <summary>仕入値引内税対象額合計プロパティ</summary>
        /// <value>内税商品値引の内税対象額（税抜）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引内税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedStockDisInTax
        {
            get { return _itdedStockDisInTax; }
            set { _itdedStockDisInTax = value; }
        }

        /// public propaty name  :  ItdedStockDisTaxFre
        /// <summary>仕入値引非課税対象額合計プロパティ</summary>
        /// <value>非課税商品値引の非課税対象額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引非課税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedStockDisTaxFre
        {
            get { return _itdedStockDisTaxFre; }
            set { _itdedStockDisTaxFre = value; }
        }

        /// public propaty name  :  StockDisOutTax
        /// <summary>仕入値引消費税額（外税）プロパティ</summary>
        /// <value>外税商品値引の消費税額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引消費税額（外税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockDisOutTax
        {
            get { return _stockDisOutTax; }
            set { _stockDisOutTax = value; }
        }

        /// public propaty name  :  StckDisTtlTaxInclu
        /// <summary>仕入値引消費税額（内税）プロパティ</summary>
        /// <value>内税商品値引の消費税額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引消費税額（内税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StckDisTtlTaxInclu
        {
            get { return _stckDisTtlTaxInclu; }
            set { _stckDisTtlTaxInclu = value; }
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

        /// public propaty name  :  SuppCTaxLayCd
        /// <summary>仕入先消費税転嫁方式コードプロパティ</summary>
        /// <value>0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先消費税転嫁方式コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SuppCTaxLayCd
        {
            get { return _suppCTaxLayCd; }
            set { _suppCTaxLayCd = value; }
        }

        /// public propaty name  :  SupplierConsTaxRate
        /// <summary>仕入先消費税税率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先消費税税率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SupplierConsTaxRate
        {
            get { return _supplierConsTaxRate; }
            set { _supplierConsTaxRate = value; }
        }

        /// public propaty name  :  AccPayConsTax
        /// <summary>買掛消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   買掛消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AccPayConsTax
        {
            get { return _accPayConsTax; }
            set { _accPayConsTax = value; }
        }

        /// public propaty name  :  StockFractionProcCd
        /// <summary>仕入端数処理区分プロパティ</summary>
        /// <value>1:切捨て,2:四捨五入,3:切上げ　（消費税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入端数処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockFractionProcCd
        {
            get { return _stockFractionProcCd; }
            set { _stockFractionProcCd = value; }
        }

        /// public propaty name  :  AutoPayment
        /// <summary>自動支払区分プロパティ</summary>
        /// <value>0:通常支払,1:自動支払</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動支払区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoPayment
        {
            get { return _autoPayment; }
            set { _autoPayment = value; }
        }

        /// public propaty name  :  AutoPaySlipNum
        /// <summary>自動支払伝票番号プロパティ</summary>
        /// <value>自動支払時の支払伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動支払伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoPaySlipNum
        {
            get { return _autoPaySlipNum; }
            set { _autoPaySlipNum = value; }
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

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>相手先伝票番号プロパティ</summary>
        /// <value>仕入先伝票番号に使用する</value>
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

        /// public propaty name  :  SupplierSlipNote1
        /// <summary>仕入伝票備考1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSlipNote1
        {
            get { return _supplierSlipNote1; }
            set { _supplierSlipNote1 = value; }
        }

        /// public propaty name  :  SupplierSlipNote2
        /// <summary>仕入伝票備考2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票備考2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSlipNote2
        {
            get { return _supplierSlipNote2; }
            set { _supplierSlipNote2 = value; }
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

        /// public propaty name  :  StockSlipPrintDate
        /// <summary>仕入伝票発行日プロパティ</summary>
        /// <value>入荷では入荷伝票発行日（発注書発行日もここを使用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票発行日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockSlipPrintDate
        {
            get { return _stockSlipPrintDate; }
            set { _stockSlipPrintDate = value; }
        }

        /// public propaty name  :  SlipPrtSetPaperId
        /// <summary>伝票印刷設定用帳票IDプロパティ</summary>
        /// <value>仕入形式とセットで伝票タイプ管理マスタを参照　（発注,入荷用）</value>
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

        /// public propaty name  :  DirectSendingCd
        /// <summary>直送区分プロパティ</summary>
        /// <value>0:直送なし,1:直送あり　（発注書の直送先印字制御）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   直送区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DirectSendingCd
        {
            get { return _directSendingCd; }
            set { _directSendingCd = value; }
        }

        /// <summary>
        /// 同じ値を持つ異なるインスタンスの仕入伝票データを作成します。
        /// </summary>
        /// <returns>StockSlipWorkのクローン</returns>
        public StockSlipWork Clone()
        {
            StockSlipWork dst = new StockSlipWork();
            this.Clone(ref dst);
            return dst;
        }

        /// <summary>
        /// 同じ値を持つ異なるインスタンスの仕入伝票データを作成します。
        /// </summary>
        /// <param name="dst">StockSlipWork</param>
        public void Clone(ref StockSlipWork dst)
        {
            if (dst != null)
            {
                dst.CreateDateTime = this.CreateDateTime;            // 作成日時
                dst.UpdateDateTime = this.UpdateDateTime;            // 更新日時
                dst.EnterpriseCode = this.EnterpriseCode;            // 企業コード
                dst.FileHeaderGuid = this.FileHeaderGuid;            // GUID
                dst.UpdEmployeeCode = this.UpdEmployeeCode;          // 更新従業員コード
                dst.UpdAssemblyId1 = this.UpdAssemblyId1;            // 更新アセンブリID1
                dst.UpdAssemblyId2 = this.UpdAssemblyId2;            // 更新アセンブリID2
                dst.LogicalDeleteCode = this.LogicalDeleteCode;      // 論理削除区分
                dst.SupplierFormal = this.SupplierFormal;            // 仕入形式
                dst.SupplierSlipNo = this.SupplierSlipNo;            // 仕入伝票番号
                dst.SectionCode = this.SectionCode;                  // 拠点コード
                dst.SubSectionCode = this.SubSectionCode;            // 部門コード
                dst.DebitNoteDiv = this.DebitNoteDiv;                // 赤伝区分
                dst.DebitNLnkSuppSlipNo = this.DebitNLnkSuppSlipNo;  // 赤黒連結仕入伝票番号
                dst.SupplierSlipCd = this.SupplierSlipCd;            // 仕入伝票区分
                dst.StockGoodsCd = this.StockGoodsCd;                // 仕入商品区分
                dst.AccPayDivCd = this.AccPayDivCd;                  // 買掛区分
                dst.StockSectionCd = this.StockSectionCd;            // 仕入拠点コード
                dst.StockAddUpSectionCd = this.StockAddUpSectionCd;  // 仕入計上拠点コード
                dst.StockSlipUpdateCd = this.StockSlipUpdateCd;      // 仕入伝票更新区分
                dst.InputDay = this.InputDay;                        // 入力日
                dst.ArrivalGoodsDay = this.ArrivalGoodsDay;          // 入荷日
                dst.StockDate = this.StockDate;                      // 仕入日
                dst.PreStockDate = this.PreStockDate;                // 前回仕入日 // ADD 2011/12/15
                dst.StockAddUpADate = this.StockAddUpADate;          // 仕入計上日付
                dst.DelayPaymentDiv = this.DelayPaymentDiv;          // 来勘区分
                dst.PayeeCode = this.PayeeCode;                      // 支払先コード
                dst.PayeeSnm = this.PayeeSnm;                        // 支払先略称
                dst.SupplierCd = this.SupplierCd;                    // 仕入先コード
                dst.SupplierNm1 = this.SupplierNm1;                  // 仕入先名1
                dst.SupplierNm2 = this.SupplierNm2;                  // 仕入先名2
                dst.SupplierSnm = this.SupplierSnm;                  // 仕入先略称
                dst.BusinessTypeCode = this.BusinessTypeCode;        // 業種コード
                dst.BusinessTypeName = this.BusinessTypeName;        // 業種名称
                dst.SalesAreaCode = this.SalesAreaCode;              // 販売エリアコード
                dst.SalesAreaName = this.SalesAreaName;              // 販売エリア名称
                dst.StockInputCode = this.StockInputCode;            // 仕入入力者コード
                dst.StockInputName = this.StockInputName;            // 仕入入力者名称
                dst.StockAgentCode = this.StockAgentCode;            // 仕入担当者コード
                dst.StockAgentName = this.StockAgentName;            // 仕入担当者名称
                dst.SuppTtlAmntDspWayCd = this.SuppTtlAmntDspWayCd;  // 仕入先総額表示方法区分
                dst.TtlAmntDispRateApy = this.TtlAmntDispRateApy;    // 総額表示掛率適用区分
                dst.StockTotalPrice = this.StockTotalPrice;          // 仕入金額合計
                dst.StockSubttlPrice = this.StockSubttlPrice;        // 仕入金額小計
                dst.StockTtlPricTaxInc = this.StockTtlPricTaxInc;    // 仕入金額計（税込み）
                dst.StockTtlPricTaxExc = this.StockTtlPricTaxExc;    // 仕入金額計（税抜き）
                dst.StockNetPrice = this.StockNetPrice;              // 仕入正価金額
                dst.StockPriceConsTax = this.StockPriceConsTax;      // 仕入金額消費税額
                dst.TtlItdedStcOutTax = this.TtlItdedStcOutTax;      // 仕入外税対象額合計
                dst.TtlItdedStcInTax = this.TtlItdedStcInTax;        // 仕入内税対象額合計
                dst.TtlItdedStcTaxFree = this.TtlItdedStcTaxFree;    // 仕入非課税対象額合計
                dst.StockOutTax = this.StockOutTax;                  // 仕入金額消費税額（外税）
                dst.StckPrcConsTaxInclu = this.StckPrcConsTaxInclu;  // 仕入金額消費税額（内税）
                dst.StckDisTtlTaxExc = this.StckDisTtlTaxExc;        // 仕入値引金額計（税抜き）
                dst.ItdedStockDisOutTax = this.ItdedStockDisOutTax;  // 仕入値引外税対象額合計
                dst.ItdedStockDisInTax = this.ItdedStockDisInTax;    // 仕入値引内税対象額合計
                dst.ItdedStockDisTaxFre = this.ItdedStockDisTaxFre;  // 仕入値引非課税対象額合計
                dst.StockDisOutTax = this.StockDisOutTax;            // 仕入値引消費税額（外税）
                dst.StckDisTtlTaxInclu = this.StckDisTtlTaxInclu;    // 仕入値引消費税額（内税）
                dst.TaxAdjust = this.TaxAdjust;                      // 消費税調整額
                dst.BalanceAdjust = this.BalanceAdjust;              // 残高調整額
                dst.SuppCTaxLayCd = this.SuppCTaxLayCd;              // 仕入先消費税転嫁方式コード
                dst.SupplierConsTaxRate = this.SupplierConsTaxRate;  // 仕入先消費税税率
                dst.AccPayConsTax = this.AccPayConsTax;              // 買掛消費税
                dst.StockFractionProcCd = this.StockFractionProcCd;  // 仕入端数処理区分
                dst.AutoPayment = this.AutoPayment;                  // 自動支払区分
                dst.AutoPaySlipNum = this.AutoPaySlipNum;            // 自動支払伝票番号
                dst.RetGoodsReasonDiv = this.RetGoodsReasonDiv;      // 返品理由コード
                dst.RetGoodsReason = this.RetGoodsReason;            // 返品理由
                dst.PartySaleSlipNum = this.PartySaleSlipNum;        // 相手先伝票番号
                dst.SupplierSlipNote1 = this.SupplierSlipNote1;      // 仕入伝票備考1
                dst.SupplierSlipNote2 = this.SupplierSlipNote2;      // 仕入伝票備考2
                dst.DetailRowCount = this.DetailRowCount;            // 明細行数
                dst.EdiSendDate = this.EdiSendDate;                  // ＥＤＩ送信日
                dst.EdiTakeInDate = this.EdiTakeInDate;              // ＥＤＩ取込日
                dst.UoeRemark1 = this.UoeRemark1;                    // ＵＯＥリマーク１
                dst.UoeRemark2 = this.UoeRemark2;                    // ＵＯＥリマーク２
                dst.SlipPrintDivCd = this.SlipPrintDivCd;            // 伝票発行区分
                dst.SlipPrintFinishCd = this.SlipPrintFinishCd;      // 伝票発行済区分
                dst.StockSlipPrintDate = this.StockSlipPrintDate;    // 仕入伝票発行日
                dst.SlipPrtSetPaperId = this.SlipPrtSetPaperId;      // 伝票印刷設定用帳票ID
                dst.SlipAddressDiv = this.SlipAddressDiv;            // 伝票住所区分
                dst.AddresseeCode = this.AddresseeCode;              // 納品先コード
                dst.AddresseeName = this.AddresseeName;              // 納品先名称
                dst.AddresseeName2 = this.AddresseeName2;            // 納品先名称2
                dst.AddresseePostNo = this.AddresseePostNo;          // 納品先郵便番号
                dst.AddresseeAddr1 = this.AddresseeAddr1;            // 納品先住所1(都道府県市区郡・町村・字)
                dst.AddresseeAddr3 = this.AddresseeAddr3;            // 納品先住所3(番地)
                dst.AddresseeAddr4 = this.AddresseeAddr4;            // 納品先住所4(アパート名称)
                dst.AddresseeTelNo = this.AddresseeTelNo;            // 納品先電話番号
                dst.AddresseeFaxNo = this.AddresseeFaxNo;            // 納品先FAX番号
                dst.DirectSendingCd = this.DirectSendingCd;          // 直送区分
            }
        }

        /// <summary>
        /// 仕入データワークコンストラクタ
        /// </summary>
        /// <returns>StockSlipWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSlipWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockSlipWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockSlipWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockSlipWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockSlipWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSlipWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockSlipWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockSlipWork || graph is ArrayList || graph is StockSlipWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockSlipWork).FullName));

            if (graph != null && graph is StockSlipWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockSlipWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockSlipWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockSlipWork[])graph).Length;
            }
            else if (graph is StockSlipWork)
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
            //仕入形式
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //赤伝区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //赤黒連結仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNLnkSuppSlipNo
            //仕入伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
            //仕入商品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //買掛区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AccPayDivCd
            //仕入拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //仕入計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //StockAddUpSectionCd
            //仕入伝票更新区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipUpdateCd
            //入力日
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //入荷日
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsDay
            //仕入日
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
            //仕入日
            serInfo.MemberInfo.Add(typeof(Int32)); //PreStockDate // ADD 2011/12/15
            //仕入計上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAddUpADate
            //来勘区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DelayPaymentDiv
            //支払先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //支払先略称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先名1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //仕入先名2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //業種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessTypeCode
            //業種名称
            serInfo.MemberInfo.Add(typeof(string)); //BusinessTypeName
            //販売エリアコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //販売エリア名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //仕入入力者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockInputCode
            //仕入入力者名称
            serInfo.MemberInfo.Add(typeof(string)); //StockInputName
            //仕入担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //仕入担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //仕入先総額表示方法区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppTtlAmntDspWayCd
            //総額表示掛率適用区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TtlAmntDispRateApy
            //仕入金額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPrice
            //仕入金額小計
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSubttlPrice
            //仕入金額計（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxInc
            //仕入金額計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxExc
            //仕入正価金額
            serInfo.MemberInfo.Add(typeof(Int64)); //StockNetPrice
            //仕入金額消費税額
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //仕入外税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedStcOutTax
            //仕入内税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedStcInTax
            //仕入非課税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedStcTaxFree
            //仕入金額消費税額（外税）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockOutTax
            //仕入金額消費税額（内税）
            serInfo.MemberInfo.Add(typeof(Int64)); //StckPrcConsTaxInclu
            //仕入値引金額計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StckDisTtlTaxExc
            //仕入値引外税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedStockDisOutTax
            //仕入値引内税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedStockDisInTax
            //仕入値引非課税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedStockDisTaxFre
            //仕入値引消費税額（外税）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockDisOutTax
            //仕入値引消費税額（内税）
            serInfo.MemberInfo.Add(typeof(Int64)); //StckDisTtlTaxInclu
            //消費税調整額
            serInfo.MemberInfo.Add(typeof(Int64)); //TaxAdjust
            //残高調整額
            serInfo.MemberInfo.Add(typeof(Int64)); //BalanceAdjust
            //仕入先消費税転嫁方式コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //仕入先消費税税率
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierConsTaxRate
            //買掛消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //AccPayConsTax
            //仕入端数処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockFractionProcCd
            //自動支払区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoPayment
            //自動支払伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoPaySlipNum
            //返品理由コード
            serInfo.MemberInfo.Add(typeof(Int32)); //RetGoodsReasonDiv
            //返品理由
            serInfo.MemberInfo.Add(typeof(string)); //RetGoodsReason
            //相手先伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //仕入伝票備考1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote1
            //仕入伝票備考2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote2
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
            //仕入伝票発行日
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipPrintDate
            //伝票印刷設定用帳票ID
            serInfo.MemberInfo.Add(typeof(string)); //SlipPrtSetPaperId
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
            //直送区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DirectSendingCd


            serInfo.Serialize(writer, serInfo);
            if (graph is StockSlipWork)
            {
                StockSlipWork temp = (StockSlipWork)graph;

                SetStockSlipWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockSlipWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockSlipWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockSlipWork temp in lst)
                {
                    SetStockSlipWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockSlipWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 91; // DEL 2011/12/15
        private const int currentMemberCount = 92; // ADD 2011/12/15

        /// <summary>
        ///  StockSlipWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSlipWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockSlipWork(System.IO.BinaryWriter writer, StockSlipWork temp)
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
            //仕入形式
            writer.Write(temp.SupplierFormal);
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //拠点コード
            writer.Write(temp.SectionCode);
            //部門コード
            writer.Write(temp.SubSectionCode);
            //赤伝区分
            writer.Write(temp.DebitNoteDiv);
            //赤黒連結仕入伝票番号
            writer.Write(temp.DebitNLnkSuppSlipNo);
            //仕入伝票区分
            writer.Write(temp.SupplierSlipCd);
            //仕入商品区分
            writer.Write(temp.StockGoodsCd);
            //買掛区分
            writer.Write(temp.AccPayDivCd);
            //仕入拠点コード
            writer.Write(temp.StockSectionCd);
            //仕入計上拠点コード
            writer.Write(temp.StockAddUpSectionCd);
            //仕入伝票更新区分
            writer.Write(temp.StockSlipUpdateCd);
            //入力日
            writer.Write((Int64)temp.InputDay.Ticks);
            //入荷日
            writer.Write((Int64)temp.ArrivalGoodsDay.Ticks);
            //仕入日
            writer.Write((Int64)temp.StockDate.Ticks);
            //仕入日
            writer.Write((Int64)temp.PreStockDate.Ticks); // ADD 2011/12/15
            //仕入計上日付
            writer.Write((Int64)temp.StockAddUpADate.Ticks);
            //来勘区分
            writer.Write(temp.DelayPaymentDiv);
            //支払先コード
            writer.Write(temp.PayeeCode);
            //支払先略称
            writer.Write(temp.PayeeSnm);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先名1
            writer.Write(temp.SupplierNm1);
            //仕入先名2
            writer.Write(temp.SupplierNm2);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //業種コード
            writer.Write(temp.BusinessTypeCode);
            //業種名称
            writer.Write(temp.BusinessTypeName);
            //販売エリアコード
            writer.Write(temp.SalesAreaCode);
            //販売エリア名称
            writer.Write(temp.SalesAreaName);
            //仕入入力者コード
            writer.Write(temp.StockInputCode);
            //仕入入力者名称
            writer.Write(temp.StockInputName);
            //仕入担当者コード
            writer.Write(temp.StockAgentCode);
            //仕入担当者名称
            writer.Write(temp.StockAgentName);
            //仕入先総額表示方法区分
            writer.Write(temp.SuppTtlAmntDspWayCd);
            //総額表示掛率適用区分
            writer.Write(temp.TtlAmntDispRateApy);
            //仕入金額合計
            writer.Write(temp.StockTotalPrice);
            //仕入金額小計
            writer.Write(temp.StockSubttlPrice);
            //仕入金額計（税込み）
            writer.Write(temp.StockTtlPricTaxInc);
            //仕入金額計（税抜き）
            writer.Write(temp.StockTtlPricTaxExc);
            //仕入正価金額
            writer.Write(temp.StockNetPrice);
            //仕入金額消費税額
            writer.Write(temp.StockPriceConsTax);
            //仕入外税対象額合計
            writer.Write(temp.TtlItdedStcOutTax);
            //仕入内税対象額合計
            writer.Write(temp.TtlItdedStcInTax);
            //仕入非課税対象額合計
            writer.Write(temp.TtlItdedStcTaxFree);
            //仕入金額消費税額（外税）
            writer.Write(temp.StockOutTax);
            //仕入金額消費税額（内税）
            writer.Write(temp.StckPrcConsTaxInclu);
            //仕入値引金額計（税抜き）
            writer.Write(temp.StckDisTtlTaxExc);
            //仕入値引外税対象額合計
            writer.Write(temp.ItdedStockDisOutTax);
            //仕入値引内税対象額合計
            writer.Write(temp.ItdedStockDisInTax);
            //仕入値引非課税対象額合計
            writer.Write(temp.ItdedStockDisTaxFre);
            //仕入値引消費税額（外税）
            writer.Write(temp.StockDisOutTax);
            //仕入値引消費税額（内税）
            writer.Write(temp.StckDisTtlTaxInclu);
            //消費税調整額
            writer.Write(temp.TaxAdjust);
            //残高調整額
            writer.Write(temp.BalanceAdjust);
            //仕入先消費税転嫁方式コード
            writer.Write(temp.SuppCTaxLayCd);
            //仕入先消費税税率
            writer.Write(temp.SupplierConsTaxRate);
            //買掛消費税
            writer.Write(temp.AccPayConsTax);
            //仕入端数処理区分
            writer.Write(temp.StockFractionProcCd);
            //自動支払区分
            writer.Write(temp.AutoPayment);
            //自動支払伝票番号
            writer.Write(temp.AutoPaySlipNum);
            //返品理由コード
            writer.Write(temp.RetGoodsReasonDiv);
            //返品理由
            writer.Write(temp.RetGoodsReason);
            //相手先伝票番号
            writer.Write(temp.PartySaleSlipNum);
            //仕入伝票備考1
            writer.Write(temp.SupplierSlipNote1);
            //仕入伝票備考2
            writer.Write(temp.SupplierSlipNote2);
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
            //仕入伝票発行日
            writer.Write((Int64)temp.StockSlipPrintDate.Ticks);
            //伝票印刷設定用帳票ID
            writer.Write(temp.SlipPrtSetPaperId);
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
            //直送区分
            writer.Write(temp.DirectSendingCd);

        }

        /// <summary>
        ///  StockSlipWorkインスタンス取得
        /// </summary>
        /// <returns>StockSlipWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSlipWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockSlipWork GetStockSlipWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockSlipWork temp = new StockSlipWork();

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
            //仕入形式
            temp.SupplierFormal = reader.ReadInt32();
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //部門コード
            temp.SubSectionCode = reader.ReadInt32();
            //赤伝区分
            temp.DebitNoteDiv = reader.ReadInt32();
            //赤黒連結仕入伝票番号
            temp.DebitNLnkSuppSlipNo = reader.ReadInt32();
            //仕入伝票区分
            temp.SupplierSlipCd = reader.ReadInt32();
            //仕入商品区分
            temp.StockGoodsCd = reader.ReadInt32();
            //買掛区分
            temp.AccPayDivCd = reader.ReadInt32();
            //仕入拠点コード
            temp.StockSectionCd = reader.ReadString();
            //仕入計上拠点コード
            temp.StockAddUpSectionCd = reader.ReadString();
            //仕入伝票更新区分
            temp.StockSlipUpdateCd = reader.ReadInt32();
            //入力日
            temp.InputDay = new DateTime(reader.ReadInt64());
            //入荷日
            temp.ArrivalGoodsDay = new DateTime(reader.ReadInt64());
            //仕入日
            temp.StockDate = new DateTime(reader.ReadInt64());
            //仕入日
            temp.PreStockDate = new DateTime(reader.ReadInt64()); // ADD 2011/12/15
            //仕入計上日付
            temp.StockAddUpADate = new DateTime(reader.ReadInt64());
            //来勘区分
            temp.DelayPaymentDiv = reader.ReadInt32();
            //支払先コード
            temp.PayeeCode = reader.ReadInt32();
            //支払先略称
            temp.PayeeSnm = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先名1
            temp.SupplierNm1 = reader.ReadString();
            //仕入先名2
            temp.SupplierNm2 = reader.ReadString();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //業種コード
            temp.BusinessTypeCode = reader.ReadInt32();
            //業種名称
            temp.BusinessTypeName = reader.ReadString();
            //販売エリアコード
            temp.SalesAreaCode = reader.ReadInt32();
            //販売エリア名称
            temp.SalesAreaName = reader.ReadString();
            //仕入入力者コード
            temp.StockInputCode = reader.ReadString();
            //仕入入力者名称
            temp.StockInputName = reader.ReadString();
            //仕入担当者コード
            temp.StockAgentCode = reader.ReadString();
            //仕入担当者名称
            temp.StockAgentName = reader.ReadString();
            //仕入先総額表示方法区分
            temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
            //総額表示掛率適用区分
            temp.TtlAmntDispRateApy = reader.ReadInt32();
            //仕入金額合計
            temp.StockTotalPrice = reader.ReadInt64();
            //仕入金額小計
            temp.StockSubttlPrice = reader.ReadInt64();
            //仕入金額計（税込み）
            temp.StockTtlPricTaxInc = reader.ReadInt64();
            //仕入金額計（税抜き）
            temp.StockTtlPricTaxExc = reader.ReadInt64();
            //仕入正価金額
            temp.StockNetPrice = reader.ReadInt64();
            //仕入金額消費税額
            temp.StockPriceConsTax = reader.ReadInt64();
            //仕入外税対象額合計
            temp.TtlItdedStcOutTax = reader.ReadInt64();
            //仕入内税対象額合計
            temp.TtlItdedStcInTax = reader.ReadInt64();
            //仕入非課税対象額合計
            temp.TtlItdedStcTaxFree = reader.ReadInt64();
            //仕入金額消費税額（外税）
            temp.StockOutTax = reader.ReadInt64();
            //仕入金額消費税額（内税）
            temp.StckPrcConsTaxInclu = reader.ReadInt64();
            //仕入値引金額計（税抜き）
            temp.StckDisTtlTaxExc = reader.ReadInt64();
            //仕入値引外税対象額合計
            temp.ItdedStockDisOutTax = reader.ReadInt64();
            //仕入値引内税対象額合計
            temp.ItdedStockDisInTax = reader.ReadInt64();
            //仕入値引非課税対象額合計
            temp.ItdedStockDisTaxFre = reader.ReadInt64();
            //仕入値引消費税額（外税）
            temp.StockDisOutTax = reader.ReadInt64();
            //仕入値引消費税額（内税）
            temp.StckDisTtlTaxInclu = reader.ReadInt64();
            //消費税調整額
            temp.TaxAdjust = reader.ReadInt64();
            //残高調整額
            temp.BalanceAdjust = reader.ReadInt64();
            //仕入先消費税転嫁方式コード
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //仕入先消費税税率
            temp.SupplierConsTaxRate = reader.ReadDouble();
            //買掛消費税
            temp.AccPayConsTax = reader.ReadInt64();
            //仕入端数処理区分
            temp.StockFractionProcCd = reader.ReadInt32();
            //自動支払区分
            temp.AutoPayment = reader.ReadInt32();
            //自動支払伝票番号
            temp.AutoPaySlipNum = reader.ReadInt32();
            //返品理由コード
            temp.RetGoodsReasonDiv = reader.ReadInt32();
            //返品理由
            temp.RetGoodsReason = reader.ReadString();
            //相手先伝票番号
            temp.PartySaleSlipNum = reader.ReadString();
            //仕入伝票備考1
            temp.SupplierSlipNote1 = reader.ReadString();
            //仕入伝票備考2
            temp.SupplierSlipNote2 = reader.ReadString();
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
            //仕入伝票発行日
            temp.StockSlipPrintDate = new DateTime(reader.ReadInt64());
            //伝票印刷設定用帳票ID
            temp.SlipPrtSetPaperId = reader.ReadString();
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
            //直送区分
            temp.DirectSendingCd = reader.ReadInt32();


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
        /// <returns>StockSlipWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSlipWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockSlipWork temp = GetStockSlipWork(reader, serInfo);
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
                    retValue = (StockSlipWork[])lst.ToArray(typeof(StockSlipWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

    /// <summary>
    /// ダミー用の発注データ(ヘッダ)
    /// </summary>
    public class OrderSlipWork : StockSlipWork
    {

    }

    /// <summary>
    /// 仕入データのプライマリーキー項目
    /// </summary>
    public struct StockSlipPrimary
    {
        /// <summary>企業コード</summary>
        public string EnterpriseCode;
        /// <summary>仕入形式</summary>
        public int SupplierFormal;
        /// <summary>仕入伝票番号</summary>
        public int SupplierSlipNo;
    }

}
