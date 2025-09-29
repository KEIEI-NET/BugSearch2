using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockConfSlipTtlWork
	/// <summary>
	///                      仕入確認表(伝票合計)データワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入確認表(伝票合計)データワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>-
	/// <br>Genarated Date   :   2009/01/09  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/06/30  田中</br>
	/// <br>                 :   Partsman.NS対応</br>
	/// <br>                 :   ・拠点ガイド名称→拠点ガイド略称に変更</br>
	/// <br>                 :   ・得意先コード・略称→仕入先コード・略称に変更</br>
	/// <br>                 :   ・買掛区分、ＵＯＥリマークの追加</br>
    /// <br>Update Note      :   2020/02/27 3H 尹安</br>
    /// <br>                 :   11570208-00 軽減税率対応</br>
    /// <br>Update Note      : 11800255-00　インボイス対応（税率別合計金額不具合修正） </br>
    /// <br>Date             : 2022/09/28</br>
    /// <br>                 : 陳艶丹 </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockConfSlipTtlWork
	{
		/// <summary>拠点コード</summary>
		/// <remarks>営業所コード</remarks>
        private string _stockSectionCd = "";

		/// <summary>拠点ガイド略称</summary>
		/// <remarks>帳票印字用</remarks>
		private string _sectionGuideSnm = "";

		/// <summary>仕入先コード</summary>
		private Int32 _supplierCd;

		/// <summary>仕入先略称</summary>
		private string _supplierSnm = "";

		/// <summary>入力日</summary>
		/// <remarks>入力日付</remarks>
		private Int32 _inputDay;

		/// <summary>入荷日</summary>
		/// <remarks>伝票日付</remarks>
        private Int32 _arrivalGoodsDay;

		/// <summary>仕入日</summary>
		/// <remarks>伝票日付</remarks>
		private DateTime _stockDate;

		/// <summary>仕入形式</summary>
		/// <remarks>0:仕入,1:入荷,2:発注　（受注ステータス）</remarks>
		private Int32 _supplierFormal;

		/// <summary>仕入伝票番号</summary>
		/// <remarks>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる　※仕入SEQ</remarks>
		private Int32 _supplierSlipNo;

		/// <summary>相手先伝票番号</summary>
		/// <remarks>仕入先伝票番号に使用する</remarks>
		private string _partySaleSlipNum = "";

		/// <summary>仕入伝票区分</summary>
		/// <remarks>10:仕入,20:返品</remarks>
		private Int32 _supplierSlipCd;

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
		/// <remarks>仕入金額</remarks>
		private Int64 _stockTtlPricTaxExc;

		/// <summary>仕入金額消費税額</summary>
		/// <remarks>消費税</remarks>
		private Int64 _stockPriceConsTax;

		/// <summary>仕入商品区分</summary>
		/// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動),11:相殺,12:相殺(自動)</remarks>
		private Int32 _stockGoodsCd;

		/// <summary>買掛区分</summary>
		/// <remarks>0:買掛なし,1:買掛</remarks>
		private Int32 _accPayDivCd;

		/// <summary>ＵＯＥリマーク１</summary>
		/// <remarks>UserOrderEntory</remarks>
		private string _uoeRemark1 = "";

		/// <summary>ＵＯＥリマーク２</summary>
		private string _uoeRemark2 = "";

		/// <summary>仕入先総額表示方法区分</summary>
		/// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
		private Int32 _suppTtlAmntDspWayCd;

		/// <summary>仕入先消費税転嫁方式コード</summary>
		/// <remarks>0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税</remarks>
		private Int32 _suppCTaxLayCd;

		/// <summary>仕入金額消費税額（内税）</summary>
		/// <remarks>値引前の内税商品の消費税</remarks>
		private Int64 _stckPrcConsTaxInclu;

		/// <summary>仕入値引消費税額（内税）</summary>
		/// <remarks>内税商品値引の消費税額</remarks>
		private Int64 _stckDisTtlTaxInclu;

		/// <summary>仕入値引消費税額（外税）</summary>
        /// <remarks>外税商品値引の消費税額</remarks>
		private Int64 _stockDisOutTax;

		/// <summary>仕入値引金額計（税抜き）</summary>
		/// <remarks>仕入値引外税対象額合計+仕入値引内税対象額合計+仕入値引非課税対象額合計</remarks>
		private Int64 _stckDisTtlTaxExc;

        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
        /// <summary>仕入先消費税税率</summary>
        private Double _supplierConsTaxRate;

        // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
        /// <summary>仕入金額非課税</summary>
        private Int64 _stockPriceTaxFreeCrf;

        /// <summary>仕入明細課税存在フラグ</summary>
        private bool _taxRateExistFlag;

        /// <summary>仕入明細非課税存在フラグ</summary>
        private bool _taxFreeExistFlag;
        // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<


        /// public propaty name  :  SupplierConsTaxRate
        /// <summary>仕入先消費税税率プロパティ</summary>
        /// <value>仕入先消費税税率</value>
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
        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<

        /// public propaty name  :  StockSectionCd
		/// <summary>拠点コードプロパティ</summary>
		/// <value>営業所コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public string StockSectionCd
		{
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
		}

		/// public propaty name  :  SectionGuideSnm
		/// <summary>拠点ガイド略称プロパティ</summary>
		/// <value>帳票印字用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点ガイド略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionGuideSnm
		{
			get{return _sectionGuideSnm;}
			set{_sectionGuideSnm = value;}
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
			get{return _supplierCd;}
			set{_supplierCd = value;}
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
			get{return _supplierSnm;}
			set{_supplierSnm = value;}
		}

		/// public propaty name  :  InputDay
		/// <summary>入力日プロパティ</summary>
		/// <value>入力日付</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 InputDay
		{
			get{return _inputDay;}
			set{_inputDay = value;}
		}

		/// public propaty name  :  ArrivalGoodsDay
		/// <summary>入荷日プロパティ</summary>
		/// <value>伝票日付</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入荷日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 ArrivalGoodsDay
		{
			get{return _arrivalGoodsDay;}
			set{_arrivalGoodsDay = value;}
		}

		/// public propaty name  :  StockDate
		/// <summary>仕入日プロパティ</summary>
		/// <value>伝票日付</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime StockDate
		{
			get{return _stockDate;}
			set{_stockDate = value;}
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
			get{return _supplierFormal;}
			set{_supplierFormal = value;}
		}

		/// public propaty name  :  SupplierSlipNo
		/// <summary>仕入伝票番号プロパティ</summary>
		/// <value>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる　※仕入SEQ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierSlipNo
		{
			get{return _supplierSlipNo;}
			set{_supplierSlipNo = value;}
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
			get{return _partySaleSlipNum;}
			set{_partySaleSlipNum = value;}
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
			get{return _supplierSlipCd;}
			set{_supplierSlipCd = value;}
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
			get{return _stockTotalPrice;}
			set{_stockTotalPrice = value;}
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
			get{return _stockSubttlPrice;}
			set{_stockSubttlPrice = value;}
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
			get{return _stockTtlPricTaxInc;}
			set{_stockTtlPricTaxInc = value;}
		}

		/// public propaty name  :  StockTtlPricTaxExc
		/// <summary>仕入金額計（税抜き）プロパティ</summary>
		/// <value>仕入金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額計（税抜き）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockTtlPricTaxExc
		{
			get{return _stockTtlPricTaxExc;}
			set{_stockTtlPricTaxExc = value;}
		}

		/// public propaty name  :  StockPriceConsTax
		/// <summary>仕入金額消費税額プロパティ</summary>
		/// <value>消費税</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額消費税額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockPriceConsTax
		{
			get{return _stockPriceConsTax;}
			set{_stockPriceConsTax = value;}
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
			get{return _stockGoodsCd;}
			set{_stockGoodsCd = value;}
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
			get{return _accPayDivCd;}
			set{_accPayDivCd = value;}
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
			get{return _uoeRemark1;}
			set{_uoeRemark1 = value;}
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
			get{return _uoeRemark2;}
			set{_uoeRemark2 = value;}
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
			get{return _suppTtlAmntDspWayCd;}
			set{_suppTtlAmntDspWayCd = value;}
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
			get{return _suppCTaxLayCd;}
			set{_suppCTaxLayCd = value;}
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
			get{return _stckPrcConsTaxInclu;}
			set{_stckPrcConsTaxInclu = value;}
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
			get{return _stckDisTtlTaxInclu;}
			set{_stckDisTtlTaxInclu = value;}
		}

        /// public propaty name  :  StockDisOutTax
		/// <summary>仕入値引消費税額（外税）プロパティ</summary>
		/// <value>値引前の外税商品の消費税</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入値引消費税額（外税）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int64 StockDisOutTax
		{
			get{return _stockDisOutTax;}
			set{_stockDisOutTax = value;}
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
			get{return _stckDisTtlTaxExc;}
			set{_stckDisTtlTaxExc = value;}
		}

        // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
        /// public propaty name  :  StockPriceTaxFreeCdrf
        /// <summary>仕入金額非課税</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額非課税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceTaxFreeCrf
        {
            get { return _stockPriceTaxFreeCrf; }
            set { _stockPriceTaxFreeCrf = value; }
        }

        /// public propaty name  :  TaxRateExistFlag
        /// <summary>仕入明細課税存在フラグ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  仕入明細課税存在フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool TaxRateExistFlag
        {
            get { return _taxRateExistFlag; }
            set { _taxRateExistFlag = value; }
        }

        /// public propaty name  :  TaxFreeExistFlag
        /// <summary>仕入明細非課税存在フラグ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  仕入明細非課税存在フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool TaxFreeExistFlag
        {
            get { return _taxFreeExistFlag; }
            set { _taxFreeExistFlag = value; }
        }
        // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<

		/// <summary>
		/// 仕入確認表(伝票合計)データワークコンストラクタ
		/// </summary>
		/// <returns>StockConfSlipTtlWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockConfSlipTtlWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockConfSlipTtlWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockConfSlipTtlWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockConfSlipTtlWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// <br>Update Note      :   11570208-00 軽減税率対応</br>
    /// <br>Programer        :   2020/02/27 3H 尹安</br>
    /// </remarks>
    public class StockConfSlipTtlWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockConfSlipTtlWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   11570208-00 軽減税率対応</br>
        /// <br>Programer        :   2020/02/27 3H 尹安</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockConfSlipTtlWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockConfSlipTtlWork || graph is ArrayList || graph is StockConfSlipTtlWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockConfSlipTtlWork).FullName));

            if (graph != null && graph is StockConfSlipTtlWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockConfSlipTtlWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockConfSlipTtlWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockConfSlipTtlWork[])graph).Length;
            }
            else if (graph is StockConfSlipTtlWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //入力日
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //入荷日
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsDay
            //仕入日
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
            //仕入形式
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //相手先伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //仕入伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
            //仕入金額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPrice
            //仕入金額小計
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSubttlPrice
            //仕入金額計（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxInc
            //仕入金額計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxExc
            //仕入金額消費税額
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //仕入商品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //買掛区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AccPayDivCd
            //ＵＯＥリマーク１
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //ＵＯＥリマーク２
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
            //仕入先総額表示方法区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppTtlAmntDspWayCd
            //仕入先消費税転嫁方式コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //仕入金額消費税額（内税）
            serInfo.MemberInfo.Add(typeof(Int64)); //StckPrcConsTaxInclu
            //仕入値引消費税額（内税）
            serInfo.MemberInfo.Add(typeof(Int64)); //StckDisTtlTaxInclu
            //仕入値引消費税額（外税）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockDisOutTax
            //仕入値引金額計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StckDisTtlTaxExc

            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            //仕入先消費税税率
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierConsTaxRate
            // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            // --- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）--------->>>>>>
            // 仕入金額非課税
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxFreeCdrf
            // 仕入明細課税存在フラグ
            serInfo.MemberInfo.Add(typeof(Boolean)); //TaxRateExistFlag
            // 仕入明細非課税存在フラグ
            serInfo.MemberInfo.Add(typeof(Boolean)); //TaxFreeExistFlag
            // --- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）---------<<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is StockConfSlipTtlWork)
            {
                StockConfSlipTtlWork temp = (StockConfSlipTtlWork)graph;

                SetStockConfSlipTtlWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockConfSlipTtlWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockConfSlipTtlWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockConfSlipTtlWork temp in lst)
                {
                    SetStockConfSlipTtlWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockConfSlipTtlWorkメンバ数(publicプロパティ数)
        /// </summary>
        // private const int currentMemberCount = 26; // --- DEL 3H 尹安 2020/02/27
        // --- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
        // private const int currentMemberCount = 27;    // --- ADD 3H 尹安 2020/02/27
        private const int currentMemberCount = 30;
        // --- UPD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<

        /// <summary>
        ///  StockConfSlipTtlWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockConfSlipTtlWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   11570208-00 軽減税率対応</br>
        /// <br>Programer        :   2020/02/27 3H 尹安</br>
        /// </remarks>
        private void SetStockConfSlipTtlWork(System.IO.BinaryWriter writer, StockConfSlipTtlWork temp)
        {
            //拠点コード
            writer.Write(temp.StockSectionCd);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //入力日
            writer.Write(temp.InputDay);
            //入荷日
            writer.Write(temp.ArrivalGoodsDay);
            //仕入日
            writer.Write((Int64)temp.StockDate.Ticks);
            //仕入形式
            writer.Write(temp.SupplierFormal);
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //相手先伝票番号
            writer.Write(temp.PartySaleSlipNum);
            //仕入伝票区分
            writer.Write(temp.SupplierSlipCd);
            //仕入金額合計
            writer.Write(temp.StockTotalPrice);
            //仕入金額小計
            writer.Write(temp.StockSubttlPrice);
            //仕入金額計（税込み）
            writer.Write(temp.StockTtlPricTaxInc);
            //仕入金額計（税抜き）
            writer.Write(temp.StockTtlPricTaxExc);
            //仕入金額消費税額
            writer.Write(temp.StockPriceConsTax);
            //仕入商品区分
            writer.Write(temp.StockGoodsCd);
            //買掛区分
            writer.Write(temp.AccPayDivCd);
            //ＵＯＥリマーク１
            writer.Write(temp.UoeRemark1);
            //ＵＯＥリマーク２
            writer.Write(temp.UoeRemark2);
            //仕入先総額表示方法区分
            writer.Write(temp.SuppTtlAmntDspWayCd);
            //仕入先消費税転嫁方式コード
            writer.Write(temp.SuppCTaxLayCd);
            //仕入金額消費税額（内税）
            writer.Write(temp.StckPrcConsTaxInclu);
            //仕入値引消費税額（内税）
            writer.Write(temp.StckDisTtlTaxInclu);
            //仕入値引消費税額（外税）
            writer.Write(temp.StockDisOutTax);
            //仕入値引金額計（税抜き）
            writer.Write(temp.StckDisTtlTaxExc);
            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            //仕入先消費税税率
            writer.Write(temp.SupplierConsTaxRate);
            // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            // --- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）--------->>>>>>
            // 仕入金額非課税
            writer.Write(temp.StockPriceTaxFreeCrf);
            // 仕入明細課税存在フラグ
            writer.Write(temp.TaxRateExistFlag);
            // 仕入明細非課税存在フラグ
            writer.Write(temp.TaxFreeExistFlag);
            // --- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）---------<<<<<<

        }

        /// <summary>
        ///  StockConfSlipTtlWorkインスタンス取得
        /// </summary>
        /// <returns>StockConfSlipTtlWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockConfSlipTtlWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   11570208-00 軽減税率対応</br>
        /// <br>Programer        :   2020/02/27 3H 尹安</br>
        /// </remarks>
        private StockConfSlipTtlWork GetStockConfSlipTtlWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockConfSlipTtlWork temp = new StockConfSlipTtlWork();

            //拠点コード
            temp.StockSectionCd = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //入力日
            temp.InputDay = reader.ReadInt32();
            //入荷日
            temp.ArrivalGoodsDay = reader.ReadInt32();
            //仕入日
            temp.StockDate = new DateTime(reader.ReadInt64());
            //仕入形式
            temp.SupplierFormal = reader.ReadInt32();
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //相手先伝票番号
            temp.PartySaleSlipNum = reader.ReadString();
            //仕入伝票区分
            temp.SupplierSlipCd = reader.ReadInt32();
            //仕入金額合計
            temp.StockTotalPrice = reader.ReadInt64();
            //仕入金額小計
            temp.StockSubttlPrice = reader.ReadInt64();
            //仕入金額計（税込み）
            temp.StockTtlPricTaxInc = reader.ReadInt64();
            //仕入金額計（税抜き）
            temp.StockTtlPricTaxExc = reader.ReadInt64();
            //仕入金額消費税額
            temp.StockPriceConsTax = reader.ReadInt64();
            //仕入商品区分
            temp.StockGoodsCd = reader.ReadInt32();
            //買掛区分
            temp.AccPayDivCd = reader.ReadInt32();
            //ＵＯＥリマーク１
            temp.UoeRemark1 = reader.ReadString();
            //ＵＯＥリマーク２
            temp.UoeRemark2 = reader.ReadString();
            //仕入先総額表示方法区分
            temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
            //仕入先消費税転嫁方式コード
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //仕入金額消費税額（内税）
            temp.StckPrcConsTaxInclu = reader.ReadInt64();
            //仕入値引消費税額（内税）
            temp.StckDisTtlTaxInclu = reader.ReadInt64();
            //仕入値引消費税額（外税）
            temp.StockDisOutTax = reader.ReadInt64();
            //仕入値引金額計（税抜き）
            temp.StckDisTtlTaxExc = reader.ReadInt64();
            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            //仕入先消費税税率
            temp.SupplierConsTaxRate = reader.ReadDouble();
            // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            // --- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）--------->>>>>>
            // 仕入金額非課税
            temp.StockPriceTaxFreeCrf = reader.ReadInt64();
            // 仕入明細課税存在フラグ
            temp.TaxRateExistFlag = reader.ReadBoolean();
            // 仕入明細非課税存在フラグ
            temp.TaxFreeExistFlag = reader.ReadBoolean();
            // --- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）---------<<<<<

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
        /// <returns>StockConfSlipTtlWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockConfSlipTtlWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockConfSlipTtlWork temp = GetStockConfSlipTtlWork(reader, serInfo);
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
                    retValue = (StockConfSlipTtlWork[])lst.ToArray(typeof(StockConfSlipTtlWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
