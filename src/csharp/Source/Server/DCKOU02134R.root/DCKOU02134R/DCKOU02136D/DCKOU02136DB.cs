using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StcRetGdsSlipTtlDataWork
    /// <summary>
    ///                      仕入返品伝票(鑑部)データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入返品伝票(鑑部)データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/02/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StcRetGdsSlipTtlDataWork
    {
        /// <summary>仕入先敬称</summary>
        private string _suppHonorificTitle = "";

        /// <summary>仕入先郵便番号</summary>
        private string _supplierPostNo = "";

        /// <summary>仕入先住所1（都道府県市区郡・町村・字）</summary>
        private string _supplierAddr1 = "";

        /// <summary>仕入先住所3（番地）</summary>
        private string _supplierAddr3 = "";

        /// <summary>仕入先住所4（アパート名称）</summary>
        private string _supplierAddr4 = "";

        /// <summary>仕入先電話番号</summary>
        private string _supplierTelNo = "";

        /// <summary>仕入先FAX番号</summary>
        private string _supplierTelNo2 = "";

        /// <summary>自社情報名称1</summary>
        private string _coInfName1 = "";

        /// <summary>自社情報名称2</summary>
        private string _coInfName2 = "";

        /// <summary>自社情報郵便番号</summary>
        private string _coInfPostNo = "";

        /// <summary>自社情報住所1（都道府県市区郡・町村・字）</summary>
        private string _coInfAddress1 = "";

        /// <summary>自社情報住所2（丁目）</summary>
        private Int32 _coInfAddress2;

        /// <summary>自社情報住所3（番地）</summary>
        private string _coInfAddress3 = "";

        /// <summary>自社情報住所4（アパート名称）</summary>
        private string _coInfAddress4 = "";

        /// <summary>自社情報電話番号1</summary>
        private string _coInfTelNo1 = "";

        /// <summary>自社情報電話番号2</summary>
        private string _coInfTelNo2 = "";

        /// <summary>自社情報電話番号3</summary>
        private string _coInfTelNo3 = "";

        /// <summary>自社情報電話番号タイトル1</summary>
        private string _coInfTelTitle1 = "";

        /// <summary>自社情報電話番号タイトル2</summary>
        private string _coInfTelTitle2 = "";

        /// <summary>自社情報電話番号タイトル3</summary>
        private string _coInfTelTitle3 = "";

        /// <summary>自社名称名称1</summary>
        private string _coNmName1 = "";

        /// <summary>自社名称名称2</summary>
        private string _coNmName2 = "";

        /// <summary>自社名称郵便番号</summary>
        private string _coNmPostNo = "";

        /// <summary>自社名称住所1（都道府県市区郡・町村・字）</summary>
        private string _coNmAddress1 = "";

        /// <summary>自社名称住所2（丁目）</summary>
        private Int32 _coNmAddress2;

        /// <summary>自社名称住所3（番地）</summary>
        private string _coNmAddress3 = "";

        /// <summary>自社名称住所4（アパート名称）</summary>
        private string _coNmAddress4 = "";

        /// <summary>自社名称電話番号1</summary>
        private string _coNmTelNo1 = "";

        /// <summary>自社名称電話番号2</summary>
        private string _coNmTelNo2 = "";

        /// <summary>自社名称電話番号3</summary>
        private string _coNmTelNo3 = "";

        /// <summary>自社名称電話番号タイトル1</summary>
        private string _coNmTelTitle1 = "";

        /// <summary>自社名称電話番号タイトル2</summary>
        private string _coNmTelTitle2 = "";

        /// <summary>自社名称電話番号タイトル3</summary>
        private string _coNmTelTitle3 = "";

        /// <summary>仕入形式</summary>
        private Int32 _supplierFormal;

        /// <summary>仕入伝票番号</summary>
        private Int32 _supplierSlipNo;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先名称</summary>
        private string _supplierNm1 = "";

        /// <summary>仕入先名称2</summary>
        private string _supplierNm2 = "";

        /// <summary>赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>仕入商品区分</summary>
        /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動),11:相殺,12:相殺(自動)</remarks>
        private Int32 _stockGoodsCd;

        /// <summary>買掛区分</summary>
        /// <remarks>0:買掛なし,1:買掛</remarks>
        private Int32 _accPayDivCd;

        /// <summary>相手先伝票番号</summary>
        /// <remarks>仕入先伝票番号に使用する</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>入力日</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _inputDay;

        /// <summary>入荷日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _arrivalGoodsDay;

        /// <summary>仕入日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _stockDate;

        /// <summary>仕入計上日付</summary>
        /// <remarks>仕入計上日</remarks>
        private DateTime _stockAddUpADate;

        /// <summary>仕入伝票区分</summary>
        /// <remarks>20:返品</remarks>
        private Int32 _supplierSlipCd;

        /// <summary>仕入入力者コード</summary>
        private string _stockInputCode = "";

        /// <summary>仕入入力者名称</summary>
        private string _stockInputName = "";

        /// <summary>仕入担当者コード</summary>
        private string _stockAgentCode = "";

        /// <summary>仕入担当者名称</summary>
        private string _stockAgentName = "";

        /// <summary>返品理由コード</summary>
        private Int32 _retGoodsReasonDiv;

        /// <summary>返品理由</summary>
        private string _retGoodsReason = "";

        /// <summary>仕入伝票備考1</summary>
        private string _supplierSlipNote1 = "";

        /// <summary>仕入伝票備考2</summary>
        private string _supplierSlipNote2 = "";

        /// <summary>仕入先総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _suppTtlAmntDspWayCd;

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

        /// <summary>仕入非課税対象額合計</summary>
        /// <remarks>非課税対象金額の集計</remarks>
        private Int64 _ttlItdedStcTaxFree;

        /// <summary>仕入金額消費税額</summary>
        /// <remarks>内税の場合:税込み/105*5,外税の場合:税抜き*5/100</remarks>
        private Int64 _stockPriceConsTax;

        /// <summary>仕入金額消費税額（内税）</summary>
        /// <remarks>※仕入金額消費税額 に含まれている内税分の金額、外税分は(仕入金額消費税額－仕入金額消費税額(内税))にて算出可能</remarks>
        private Int64 _stckPrcConsTaxInclu;

        /// <summary>仕入先消費税転嫁方式コード</summary>
        /// <remarks>0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税</remarks>
        private Int32 _suppCTaxLayCd;

        /// <summary>仕入値引金額計（税抜き）</summary>
        private Int64 _stckDisTtlTaxExc;

        /// <summary>仕入値引金額計（内税）</summary>
        private Int64 _stckDisTtlTaxInclu;


        /// public propaty name  :  SuppHonorificTitle
        /// <summary>仕入先敬称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SuppHonorificTitle
        {
            get { return _suppHonorificTitle; }
            set { _suppHonorificTitle = value; }
        }

        /// public propaty name  :  SupplierPostNo
        /// <summary>仕入先郵便番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierPostNo
        {
            get { return _supplierPostNo; }
            set { _supplierPostNo = value; }
        }

        /// public propaty name  :  SupplierAddr
        /// <summary>仕入先住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierAddr
        {
            get { return _supplierAddr1; }
            set { _supplierAddr1 = value; }
        }

        /// public propaty name  :  SupplierAddr3
        /// <summary>仕入先住所3（番地）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierAddr3
        {
            get { return _supplierAddr3; }
            set { _supplierAddr3 = value; }
        }

        /// public propaty name  :  SupplierAddr4
        /// <summary>仕入先住所4（アパート名称）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierAddr4
        {
            get { return _supplierAddr4; }
            set { _supplierAddr4 = value; }
        }

        /// public propaty name  :  SupplierTelNo
        /// <summary>仕入先電話番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先電話番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierTelNo
        {
            get { return _supplierTelNo; }
            set { _supplierTelNo = value; }
        }

        /// public propaty name  :  SupplierTelNo2
        /// <summary>仕入先FAX番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先FAX番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierTelNo2
        {
            get { return _supplierTelNo2; }
            set { _supplierTelNo2 = value; }
        }

        /// public propaty name  :  CoInfName1
        /// <summary>自社情報名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社情報名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoInfName1
        {
            get { return _coInfName1; }
            set { _coInfName1 = value; }
        }

        /// public propaty name  :  CoInfName2
        /// <summary>自社情報名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社情報名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoInfName2
        {
            get { return _coInfName2; }
            set { _coInfName2 = value; }
        }

        /// public propaty name  :  CoInfPostNo
        /// <summary>自社情報郵便番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社情報郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoInfPostNo
        {
            get { return _coInfPostNo; }
            set { _coInfPostNo = value; }
        }

        /// public propaty name  :  CoInfAddress1
        /// <summary>自社情報住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社情報住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoInfAddress1
        {
            get { return _coInfAddress1; }
            set { _coInfAddress1 = value; }
        }

        /// public propaty name  :  CoInfAddress2
        /// <summary>自社情報住所2（丁目）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社情報住所2（丁目）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CoInfAddress2
        {
            get { return _coInfAddress2; }
            set { _coInfAddress2 = value; }
        }

        /// public propaty name  :  CoInfAddress3
        /// <summary>自社情報住所3（番地）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社情報住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoInfAddress3
        {
            get { return _coInfAddress3; }
            set { _coInfAddress3 = value; }
        }

        /// public propaty name  :  CoInfAddress4
        /// <summary>自社情報住所4（アパート名称）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社情報住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoInfAddress4
        {
            get { return _coInfAddress4; }
            set { _coInfAddress4 = value; }
        }

        /// public propaty name  :  CoInfTelNo1
        /// <summary>自社情報電話番号1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社情報電話番号1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoInfTelNo1
        {
            get { return _coInfTelNo1; }
            set { _coInfTelNo1 = value; }
        }

        /// public propaty name  :  CoInfTelNo2
        /// <summary>自社情報電話番号2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社情報電話番号2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoInfTelNo2
        {
            get { return _coInfTelNo2; }
            set { _coInfTelNo2 = value; }
        }

        /// public propaty name  :  CoInfTelNo3
        /// <summary>自社情報電話番号3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社情報電話番号3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoInfTelNo3
        {
            get { return _coInfTelNo3; }
            set { _coInfTelNo3 = value; }
        }

        /// public propaty name  :  CoInfTelTitle1
        /// <summary>自社情報電話番号タイトル1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社情報電話番号タイトル1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoInfTelTitle1
        {
            get { return _coInfTelTitle1; }
            set { _coInfTelTitle1 = value; }
        }

        /// public propaty name  :  CoInfTelTitle2
        /// <summary>自社情報電話番号タイトル2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社情報電話番号タイトル2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoInfTelTitle2
        {
            get { return _coInfTelTitle2; }
            set { _coInfTelTitle2 = value; }
        }

        /// public propaty name  :  CoInfTelTitle3
        /// <summary>自社情報電話番号タイトル3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社情報電話番号タイトル3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoInfTelTitle3
        {
            get { return _coInfTelTitle3; }
            set { _coInfTelTitle3 = value; }
        }

        /// public propaty name  :  CoNmName1
        /// <summary>自社名称名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoNmName1
        {
            get { return _coNmName1; }
            set { _coNmName1 = value; }
        }

        /// public propaty name  :  CoNmName2
        /// <summary>自社名称名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoNmName2
        {
            get { return _coNmName2; }
            set { _coNmName2 = value; }
        }

        /// public propaty name  :  CoNmPostNo
        /// <summary>自社名称郵便番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoNmPostNo
        {
            get { return _coNmPostNo; }
            set { _coNmPostNo = value; }
        }

        /// public propaty name  :  CoNmAddress1
        /// <summary>自社名称住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoNmAddress1
        {
            get { return _coNmAddress1; }
            set { _coNmAddress1 = value; }
        }

        /// public propaty name  :  CoNmAddress2
        /// <summary>自社名称住所2（丁目）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称住所2（丁目）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CoNmAddress2
        {
            get { return _coNmAddress2; }
            set { _coNmAddress2 = value; }
        }

        /// public propaty name  :  CoNmAddress3
        /// <summary>自社名称住所3（番地）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoNmAddress3
        {
            get { return _coNmAddress3; }
            set { _coNmAddress3 = value; }
        }

        /// public propaty name  :  CoNmAddress4
        /// <summary>自社名称住所4（アパート名称）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoNmAddress4
        {
            get { return _coNmAddress4; }
            set { _coNmAddress4 = value; }
        }

        /// public propaty name  :  CoNmTelNo1
        /// <summary>自社名称電話番号1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称電話番号1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoNmTelNo1
        {
            get { return _coNmTelNo1; }
            set { _coNmTelNo1 = value; }
        }

        /// public propaty name  :  CoNmTelNo2
        /// <summary>自社名称電話番号2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称電話番号2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoNmTelNo2
        {
            get { return _coNmTelNo2; }
            set { _coNmTelNo2 = value; }
        }

        /// public propaty name  :  CoNmTelNo3
        /// <summary>自社名称電話番号3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称電話番号3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoNmTelNo3
        {
            get { return _coNmTelNo3; }
            set { _coNmTelNo3 = value; }
        }

        /// public propaty name  :  CoNmTelTitle1
        /// <summary>自社名称電話番号タイトル1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称電話番号タイトル1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoNmTelTitle1
        {
            get { return _coNmTelTitle1; }
            set { _coNmTelTitle1 = value; }
        }

        /// public propaty name  :  CoNmTelTitle2
        /// <summary>自社名称電話番号タイトル2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称電話番号タイトル2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoNmTelTitle2
        {
            get { return _coNmTelTitle2; }
            set { _coNmTelTitle2 = value; }
        }

        /// public propaty name  :  CoNmTelTitle3
        /// <summary>自社名称電話番号タイトル3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称電話番号タイトル3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CoNmTelTitle3
        {
            get { return _coNmTelTitle3; }
            set { _coNmTelTitle3 = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>仕入形式プロパティ</summary>
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
        /// <summary>仕入先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }

        /// public propaty name  :  SupplierNm2
        /// <summary>仕入先名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm2
        {
            get { return _supplierNm2; }
            set { _supplierNm2 = value; }
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

        /// public propaty name  :  SupplierSlipCd
        /// <summary>仕入伝票区分プロパティ</summary>
        /// <value>20:返品</value>
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

        /// public propaty name  :  TtlItdedStcTaxFree
        /// <summary>仕入非課税対象額合計プロパティ</summary>
        /// <value>非課税対象金額の集計</value>
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

        /// public propaty name  :  StockPriceConsTax
        /// <summary>仕入金額消費税額プロパティ</summary>
        /// <value>内税の場合:税込み/105*5,外税の場合:税抜き*5/100</value>
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

        /// public propaty name  :  StckPrcConsTaxInclu
        /// <summary>仕入金額消費税額（内税）プロパティ</summary>
        /// <value>※仕入金額消費税額 に含まれている内税分の金額、外税分は(仕入金額消費税額－仕入金額消費税額(内税))にて算出可能</value>
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

        /// public propaty name  :  StckDisTtlTaxExc
        /// <summary>仕入値引金額計（税抜き）プロパティ</summary>
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

        /// public propaty name  :  StckDisTtlTaxInclu
        /// <summary>仕入値引金額計（内税）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引金額計（内税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StckDisTtlTaxInclu
        {
            get { return _stckDisTtlTaxInclu; }
            set { _stckDisTtlTaxInclu = value; }
        }


        /// <summary>
        /// 仕入返品伝票(鑑部)データワークコンストラクタ
        /// </summary>
        /// <returns>StcRetGdsSlipTtlDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StcRetGdsSlipTtlDataWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StcRetGdsSlipTtlDataWork()
        {
        }
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StcRetGdsSlipTtlDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StcRetGdsSlipTtlDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StcRetGdsSlipTtlDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StcRetGdsSlipTtlDataWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StcRetGdsSlipTtlDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StcRetGdsSlipTtlDataWork || graph is ArrayList || graph is StcRetGdsSlipTtlDataWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StcRetGdsSlipTtlDataWork).FullName));

            if (graph != null && graph is StcRetGdsSlipTtlDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StcRetGdsSlipTtlDataWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StcRetGdsSlipTtlDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StcRetGdsSlipTtlDataWork[])graph).Length;
            }
            else if (graph is StcRetGdsSlipTtlDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //仕入先敬称
            serInfo.MemberInfo.Add(typeof(string)); //SuppHonorificTitle
            //仕入先郵便番号
            serInfo.MemberInfo.Add(typeof(string)); //SupplierPostNo
            //仕入先住所1（都道府県市区郡・町村・字）
            serInfo.MemberInfo.Add(typeof(string)); //SupplierAddr
            //仕入先住所3（番地）
            serInfo.MemberInfo.Add(typeof(string)); //SupplierAddr3
            //仕入先住所4（アパート名称）
            serInfo.MemberInfo.Add(typeof(string)); //SupplierAddr4
            //仕入先電話番号
            serInfo.MemberInfo.Add(typeof(string)); //SupplierTelNo
            //仕入先FAX番号
            serInfo.MemberInfo.Add(typeof(string)); //SupplierTelNo2
            //自社情報名称1
            serInfo.MemberInfo.Add(typeof(string)); //CoInfName1
            //自社情報名称2
            serInfo.MemberInfo.Add(typeof(string)); //CoInfName2
            //自社情報郵便番号
            serInfo.MemberInfo.Add(typeof(string)); //CoInfPostNo
            //自社情報住所1（都道府県市区郡・町村・字）
            serInfo.MemberInfo.Add(typeof(string)); //CoInfAddress1
            //自社情報住所2（丁目）
            serInfo.MemberInfo.Add(typeof(Int32)); //CoInfAddress2
            //自社情報住所3（番地）
            serInfo.MemberInfo.Add(typeof(string)); //CoInfAddress3
            //自社情報住所4（アパート名称）
            serInfo.MemberInfo.Add(typeof(string)); //CoInfAddress4
            //自社情報電話番号1
            serInfo.MemberInfo.Add(typeof(string)); //CoInfTelNo1
            //自社情報電話番号2
            serInfo.MemberInfo.Add(typeof(string)); //CoInfTelNo2
            //自社情報電話番号3
            serInfo.MemberInfo.Add(typeof(string)); //CoInfTelNo3
            //自社情報電話番号タイトル1
            serInfo.MemberInfo.Add(typeof(string)); //CoInfTelTitle1
            //自社情報電話番号タイトル2
            serInfo.MemberInfo.Add(typeof(string)); //CoInfTelTitle2
            //自社情報電話番号タイトル3
            serInfo.MemberInfo.Add(typeof(string)); //CoInfTelTitle3
            //自社名称名称1
            serInfo.MemberInfo.Add(typeof(string)); //CoNmName1
            //自社名称名称2
            serInfo.MemberInfo.Add(typeof(string)); //CoNmName2
            //自社名称郵便番号
            serInfo.MemberInfo.Add(typeof(string)); //CoNmPostNo
            //自社名称住所1（都道府県市区郡・町村・字）
            serInfo.MemberInfo.Add(typeof(string)); //CoNmAddress1
            //自社名称住所2（丁目）
            serInfo.MemberInfo.Add(typeof(Int32)); //CoNmAddress2
            //自社名称住所3（番地）
            serInfo.MemberInfo.Add(typeof(string)); //CoNmAddress3
            //自社名称住所4（アパート名称）
            serInfo.MemberInfo.Add(typeof(string)); //CoNmAddress4
            //自社名称電話番号1
            serInfo.MemberInfo.Add(typeof(string)); //CoNmTelNo1
            //自社名称電話番号2
            serInfo.MemberInfo.Add(typeof(string)); //CoNmTelNo2
            //自社名称電話番号3
            serInfo.MemberInfo.Add(typeof(string)); //CoNmTelNo3
            //自社名称電話番号タイトル1
            serInfo.MemberInfo.Add(typeof(string)); //CoNmTelTitle1
            //自社名称電話番号タイトル2
            serInfo.MemberInfo.Add(typeof(string)); //CoNmTelTitle2
            //自社名称電話番号タイトル3
            serInfo.MemberInfo.Add(typeof(string)); //CoNmTelTitle3
            //仕入形式
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先名称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //仕入先名称2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //赤伝区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //仕入商品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //買掛区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AccPayDivCd
            //相手先伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //入力日
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //入荷日
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsDay
            //仕入日
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
            //仕入計上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAddUpADate
            //仕入伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
            //仕入入力者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockInputCode
            //仕入入力者名称
            serInfo.MemberInfo.Add(typeof(string)); //StockInputName
            //仕入担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //仕入担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //返品理由コード
            serInfo.MemberInfo.Add(typeof(Int32)); //RetGoodsReasonDiv
            //返品理由
            serInfo.MemberInfo.Add(typeof(string)); //RetGoodsReason
            //仕入伝票備考1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote1
            //仕入伝票備考2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote2
            //仕入先総額表示方法区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppTtlAmntDspWayCd
            //仕入金額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPrice
            //仕入金額小計
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSubttlPrice
            //仕入金額計（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxInc
            //仕入金額計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxExc
            //仕入非課税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedStcTaxFree
            //仕入金額消費税額
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //仕入金額消費税額（内税）
            serInfo.MemberInfo.Add(typeof(Int64)); //StckPrcConsTaxInclu
            //仕入先消費税転嫁方式コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //仕入値引金額計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StckDisTtlTaxExc
            //仕入値引金額計（内税）
            serInfo.MemberInfo.Add(typeof(Int64)); //StckDisTtlTaxInclu


            serInfo.Serialize(writer, serInfo);
            if (graph is StcRetGdsSlipTtlDataWork)
            {
                StcRetGdsSlipTtlDataWork temp = (StcRetGdsSlipTtlDataWork)graph;

                SetStcRetGdsSlipTtlDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StcRetGdsSlipTtlDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StcRetGdsSlipTtlDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StcRetGdsSlipTtlDataWork temp in lst)
                {
                    SetStcRetGdsSlipTtlDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StcRetGdsSlipTtlDataWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 68;

        /// <summary>
        ///  StcRetGdsSlipTtlDataWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StcRetGdsSlipTtlDataWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStcRetGdsSlipTtlDataWork(System.IO.BinaryWriter writer, StcRetGdsSlipTtlDataWork temp)
        {
            //仕入先敬称
            writer.Write(temp.SuppHonorificTitle);
            //仕入先郵便番号
            writer.Write(temp.SupplierPostNo);
            //仕入先住所1（都道府県市区郡・町村・字）
            writer.Write(temp.SupplierAddr);
            //仕入先住所3（番地）
            writer.Write(temp.SupplierAddr3);
            //仕入先住所4（アパート名称）
            writer.Write(temp.SupplierAddr4);
            //仕入先電話番号
            writer.Write(temp.SupplierTelNo);
            //仕入先FAX番号
            writer.Write(temp.SupplierTelNo2);
            //自社情報名称1
            writer.Write(temp.CoInfName1);
            //自社情報名称2
            writer.Write(temp.CoInfName2);
            //自社情報郵便番号
            writer.Write(temp.CoInfPostNo);
            //自社情報住所1（都道府県市区郡・町村・字）
            writer.Write(temp.CoInfAddress1);
            //自社情報住所2（丁目）
            writer.Write(temp.CoInfAddress2);
            //自社情報住所3（番地）
            writer.Write(temp.CoInfAddress3);
            //自社情報住所4（アパート名称）
            writer.Write(temp.CoInfAddress4);
            //自社情報電話番号1
            writer.Write(temp.CoInfTelNo1);
            //自社情報電話番号2
            writer.Write(temp.CoInfTelNo2);
            //自社情報電話番号3
            writer.Write(temp.CoInfTelNo3);
            //自社情報電話番号タイトル1
            writer.Write(temp.CoInfTelTitle1);
            //自社情報電話番号タイトル2
            writer.Write(temp.CoInfTelTitle2);
            //自社情報電話番号タイトル3
            writer.Write(temp.CoInfTelTitle3);
            //自社名称名称1
            writer.Write(temp.CoNmName1);
            //自社名称名称2
            writer.Write(temp.CoNmName2);
            //自社名称郵便番号
            writer.Write(temp.CoNmPostNo);
            //自社名称住所1（都道府県市区郡・町村・字）
            writer.Write(temp.CoNmAddress1);
            //自社名称住所2（丁目）
            writer.Write(temp.CoNmAddress2);
            //自社名称住所3（番地）
            writer.Write(temp.CoNmAddress3);
            //自社名称住所4（アパート名称）
            writer.Write(temp.CoNmAddress4);
            //自社名称電話番号1
            writer.Write(temp.CoNmTelNo1);
            //自社名称電話番号2
            writer.Write(temp.CoNmTelNo2);
            //自社名称電話番号3
            writer.Write(temp.CoNmTelNo3);
            //自社名称電話番号タイトル1
            writer.Write(temp.CoNmTelTitle1);
            //自社名称電話番号タイトル2
            writer.Write(temp.CoNmTelTitle2);
            //自社名称電話番号タイトル3
            writer.Write(temp.CoNmTelTitle3);
            //仕入形式
            writer.Write(temp.SupplierFormal);
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //拠点コード
            writer.Write(temp.SectionCode);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先名称
            writer.Write(temp.SupplierNm1);
            //仕入先名称2
            writer.Write(temp.SupplierNm2);
            //赤伝区分
            writer.Write(temp.DebitNoteDiv);
            //仕入商品区分
            writer.Write(temp.StockGoodsCd);
            //買掛区分
            writer.Write(temp.AccPayDivCd);
            //相手先伝票番号
            writer.Write(temp.PartySaleSlipNum);
            //入力日
            writer.Write((Int64)temp.InputDay.Ticks);
            //入荷日
            writer.Write((Int64)temp.ArrivalGoodsDay.Ticks);
            //仕入日
            writer.Write((Int64)temp.StockDate.Ticks);
            //仕入計上日付
            writer.Write((Int64)temp.StockAddUpADate.Ticks);
            //仕入伝票区分
            writer.Write(temp.SupplierSlipCd);
            //仕入入力者コード
            writer.Write(temp.StockInputCode);
            //仕入入力者名称
            writer.Write(temp.StockInputName);
            //仕入担当者コード
            writer.Write(temp.StockAgentCode);
            //仕入担当者名称
            writer.Write(temp.StockAgentName);
            //返品理由コード
            writer.Write(temp.RetGoodsReasonDiv);
            //返品理由
            writer.Write(temp.RetGoodsReason);
            //仕入伝票備考1
            writer.Write(temp.SupplierSlipNote1);
            //仕入伝票備考2
            writer.Write(temp.SupplierSlipNote2);
            //仕入先総額表示方法区分
            writer.Write(temp.SuppTtlAmntDspWayCd);
            //仕入金額合計
            writer.Write(temp.StockTotalPrice);
            //仕入金額小計
            writer.Write(temp.StockSubttlPrice);
            //仕入金額計（税込み）
            writer.Write(temp.StockTtlPricTaxInc);
            //仕入金額計（税抜き）
            writer.Write(temp.StockTtlPricTaxExc);
            //仕入非課税対象額合計
            writer.Write(temp.TtlItdedStcTaxFree);
            //仕入金額消費税額
            writer.Write(temp.StockPriceConsTax);
            //仕入金額消費税額（内税）
            writer.Write(temp.StckPrcConsTaxInclu);
            //仕入先消費税転嫁方式コード
            writer.Write(temp.SuppCTaxLayCd);
            //仕入値引金額計（税抜き）
            writer.Write(temp.StckDisTtlTaxExc);
            //仕入値引金額計（内税）
            writer.Write(temp.StckDisTtlTaxInclu);

        }

        /// <summary>
        ///  StcRetGdsSlipTtlDataWorkインスタンス取得
        /// </summary>
        /// <returns>StcRetGdsSlipTtlDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StcRetGdsSlipTtlDataWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StcRetGdsSlipTtlDataWork GetStcRetGdsSlipTtlDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StcRetGdsSlipTtlDataWork temp = new StcRetGdsSlipTtlDataWork();

            //仕入先敬称
            temp.SuppHonorificTitle = reader.ReadString();
            //仕入先郵便番号
            temp.SupplierPostNo = reader.ReadString();
            //仕入先住所1（都道府県市区郡・町村・字）
            temp.SupplierAddr = reader.ReadString();
            //仕入先住所3（番地）
            temp.SupplierAddr3 = reader.ReadString();
            //仕入先住所4（アパート名称）
            temp.SupplierAddr4 = reader.ReadString();
            //仕入先電話番号
            temp.SupplierTelNo = reader.ReadString();
            //仕入先FAX番号
            temp.SupplierTelNo2 = reader.ReadString();
            //自社情報名称1
            temp.CoInfName1 = reader.ReadString();
            //自社情報名称2
            temp.CoInfName2 = reader.ReadString();
            //自社情報郵便番号
            temp.CoInfPostNo = reader.ReadString();
            //自社情報住所1（都道府県市区郡・町村・字）
            temp.CoInfAddress1 = reader.ReadString();
            //自社情報住所2（丁目）
            temp.CoInfAddress2 = reader.ReadInt32();
            //自社情報住所3（番地）
            temp.CoInfAddress3 = reader.ReadString();
            //自社情報住所4（アパート名称）
            temp.CoInfAddress4 = reader.ReadString();
            //自社情報電話番号1
            temp.CoInfTelNo1 = reader.ReadString();
            //自社情報電話番号2
            temp.CoInfTelNo2 = reader.ReadString();
            //自社情報電話番号3
            temp.CoInfTelNo3 = reader.ReadString();
            //自社情報電話番号タイトル1
            temp.CoInfTelTitle1 = reader.ReadString();
            //自社情報電話番号タイトル2
            temp.CoInfTelTitle2 = reader.ReadString();
            //自社情報電話番号タイトル3
            temp.CoInfTelTitle3 = reader.ReadString();
            //自社名称名称1
            temp.CoNmName1 = reader.ReadString();
            //自社名称名称2
            temp.CoNmName2 = reader.ReadString();
            //自社名称郵便番号
            temp.CoNmPostNo = reader.ReadString();
            //自社名称住所1（都道府県市区郡・町村・字）
            temp.CoNmAddress1 = reader.ReadString();
            //自社名称住所2（丁目）
            temp.CoNmAddress2 = reader.ReadInt32();
            //自社名称住所3（番地）
            temp.CoNmAddress3 = reader.ReadString();
            //自社名称住所4（アパート名称）
            temp.CoNmAddress4 = reader.ReadString();
            //自社名称電話番号1
            temp.CoNmTelNo1 = reader.ReadString();
            //自社名称電話番号2
            temp.CoNmTelNo2 = reader.ReadString();
            //自社名称電話番号3
            temp.CoNmTelNo3 = reader.ReadString();
            //自社名称電話番号タイトル1
            temp.CoNmTelTitle1 = reader.ReadString();
            //自社名称電話番号タイトル2
            temp.CoNmTelTitle2 = reader.ReadString();
            //自社名称電話番号タイトル3
            temp.CoNmTelTitle3 = reader.ReadString();
            //仕入形式
            temp.SupplierFormal = reader.ReadInt32();
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先名称
            temp.SupplierNm1 = reader.ReadString();
            //仕入先名称2
            temp.SupplierNm2 = reader.ReadString();
            //赤伝区分
            temp.DebitNoteDiv = reader.ReadInt32();
            //仕入商品区分
            temp.StockGoodsCd = reader.ReadInt32();
            //買掛区分
            temp.AccPayDivCd = reader.ReadInt32();
            //相手先伝票番号
            temp.PartySaleSlipNum = reader.ReadString();
            //入力日
            temp.InputDay = new DateTime(reader.ReadInt64());
            //入荷日
            temp.ArrivalGoodsDay = new DateTime(reader.ReadInt64());
            //仕入日
            temp.StockDate = new DateTime(reader.ReadInt64());
            //仕入計上日付
            temp.StockAddUpADate = new DateTime(reader.ReadInt64());
            //仕入伝票区分
            temp.SupplierSlipCd = reader.ReadInt32();
            //仕入入力者コード
            temp.StockInputCode = reader.ReadString();
            //仕入入力者名称
            temp.StockInputName = reader.ReadString();
            //仕入担当者コード
            temp.StockAgentCode = reader.ReadString();
            //仕入担当者名称
            temp.StockAgentName = reader.ReadString();
            //返品理由コード
            temp.RetGoodsReasonDiv = reader.ReadInt32();
            //返品理由
            temp.RetGoodsReason = reader.ReadString();
            //仕入伝票備考1
            temp.SupplierSlipNote1 = reader.ReadString();
            //仕入伝票備考2
            temp.SupplierSlipNote2 = reader.ReadString();
            //仕入先総額表示方法区分
            temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
            //仕入金額合計
            temp.StockTotalPrice = reader.ReadInt64();
            //仕入金額小計
            temp.StockSubttlPrice = reader.ReadInt64();
            //仕入金額計（税込み）
            temp.StockTtlPricTaxInc = reader.ReadInt64();
            //仕入金額計（税抜き）
            temp.StockTtlPricTaxExc = reader.ReadInt64();
            //仕入非課税対象額合計
            temp.TtlItdedStcTaxFree = reader.ReadInt64();
            //仕入金額消費税額
            temp.StockPriceConsTax = reader.ReadInt64();
            //仕入金額消費税額（内税）
            temp.StckPrcConsTaxInclu = reader.ReadInt64();
            //仕入先消費税転嫁方式コード
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //仕入値引金額計（税抜き）
            temp.StckDisTtlTaxExc = reader.ReadInt64();
            //仕入値引金額計（内税）
            temp.StckDisTtlTaxInclu = reader.ReadInt64();


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
        /// <returns>StcRetGdsSlipTtlDataWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StcRetGdsSlipTtlDataWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StcRetGdsSlipTtlDataWork temp = GetStcRetGdsSlipTtlDataWork(reader, serInfo);
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
                    retValue = (StcRetGdsSlipTtlDataWork[])lst.ToArray(typeof(StcRetGdsSlipTtlDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
