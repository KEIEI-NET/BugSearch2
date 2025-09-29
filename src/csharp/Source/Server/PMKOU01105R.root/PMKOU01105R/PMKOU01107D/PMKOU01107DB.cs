using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{

	/// public class name:   SupplierCheckResultWork
	/// <summary>
	///                      仕入チェック処理抽出結果クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入チェック処理抽出結果クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/12/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/10/21 李占川 PM1012PM.NS障害改良対応（８月分）</br>
    /// <br>Update Note      :   2012/08/30 凌小青  Redmine#31879の対応 UOE仕入データの区分を取得</br>
    /// <br>Update Note      :   2012/10/09 朱 猛  Redmine#31879の対応 赤伝区分を取得</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SupplierCheckResultWork : IFileHeader
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

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>仕入チェック区分（締次）</summary>
		/// <remarks>0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）</remarks>
		private Int32 _stockCheckDivCAddUp;

		/// <summary>仕入チェック区分（日次）</summary>
		/// <remarks>0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）</remarks>
		private Int32 _stockCheckDivDaily;

		/// <summary>仕入日</summary>
		/// <remarks>YYYYMMDD　（更新年月日）</remarks>
		private DateTime _stockDate;

		/// <summary>入力日</summary>
		/// <remarks>YYYYMMDD　（更新年月日）</remarks>
		private DateTime _inputDay;

		/// <summary>仕入伝票番号</summary>
		/// <remarks>発注伝票番号、仕入伝票番号、入荷伝票番号を兼ねる</remarks>
		private Int32 _supplierSlipNo;

		/// <summary>相手先伝票番号</summary>
		/// <remarks>仕入先伝票番号に使用する</remarks>
		private string _partySaleSlipNum = "";

		/// <summary>仕入金額（税込み）</summary>
		private Int64 _stockPriceTaxInc;

		/// <summary>仕入金額（税抜き）</summary>
		private Int64 _stockPriceTaxExc;

		/// <summary>仕入金額消費税額(明細)</summary>
		/// <remarks>仕入金額（税込み）- 仕入金額（税抜き）※消費税調整額も兼ねる</remarks>
		private Int64 _stockPriceConsTax;

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>仕入数</summary>
		private Double _stockCount;

		/// <summary>BL商品コード</summary>
		private Int32 _bLGoodsCode;

		/// <summary>商品名称</summary>
		private string _goodsName = "";

		/// <summary>仕入単価（税抜，浮動）</summary>
		/// <remarks>税抜き</remarks>
		private Double _stockUnitPriceFl;

		/// <summary>定価（税抜，浮動）</summary>
		/// <remarks>税抜き</remarks>
		private Double _listPriceTaxExcFl;

		/// <summary>売上単価（税抜，浮動）</summary>
		private Double _salesUnPrcTaxExcFl;

		/// <summary>売上金額（税抜き）</summary>
		private Int64 _salesMoneyTaxExc;

		/// <summary>売上日付</summary>
		/// <remarks>(YYYYMMDD)</remarks>
		private DateTime _salesDate;

		/// <summary>売上伝票番号</summary>
		private string _salesSlipNum = "";

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>得意先略称</summary>
		private string _customerSnm = "";

		/// <summary>販売従業員名称</summary>
		private string _salesEmployeeNm = "";

		/// <summary>受付従業員名称</summary>
		private string _frontEmployeeNm = "";

		/// <summary>売上入力者名称</summary>
		private string _salesInputName = "";

		/// <summary>ＵＯＥリマーク１</summary>
		/// <remarks>UserOrderEntory</remarks>
		private string _uoeRemark1 = "";

		/// <summary>ＵＯＥリマーク２</summary>
		private string _uoeRemark2 = "";

		/// <summary>仕入先コード</summary>
		private Int32 _supplierCd;

		/// <summary>仕入先略称</summary>
		private string _supplierSnm = "";

		/// <summary>仕入形式</summary>
		/// <remarks>0:仕入　（受注ステータス）</remarks>
		private Int32 _supplierFormal;

		/// <summary>仕入明細通番</summary>
		private Int64 _stockSlipDtlNum;

		/// <summary>変更前仕入単価（浮動）</summary>
		/// <remarks>税抜き、掛率算出結果</remarks>
		private Double _bfStockUnitPriceFl;

		/// <summary>仕入伝票区分</summary>
		/// <remarks>10:仕入,20:返品</remarks>
		private Int32 _supplierSlipCd;

		/// <summary>仕入商品区分</summary>
		/// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力</remarks>
		private Int32 _stockGoodsCd;

		/// <summary>仕入先消費税転嫁方式コード</summary>
		/// <remarks>0:伝票単位 1:明細単位 2:請求単位（請求先）3:請求単位（得意先）9:非課税</remarks>
		private Int32 _suppCTaxLayCd;

		/// <summary>仕入金額計（税込み）</summary>
		/// <remarks>外税時：税抜き＋消費税、内税時：内税価格（税込）の集計</remarks>
		private Int64 _stockTtlPricTaxInc;

		/// <summary>仕入金額計（税抜き）</summary>
		/// <remarks>外税時：税抜価格の集計、内税時：内税価格（税込）の集計－消費税</remarks>
		private Int64 _stockTtlPricTaxExc;

		/// <summary>仕入金額消費税額(伝票)</summary>
		/// <remarks>仕入金額消費税額（外税）+仕入金額消費税額（内税）</remarks>
		private Int64 _stockTtlPriceConsTax;

        // --- ADD 2010/10/21 ---------->>>>>
        /// <summary>仕入金額合計</summary>
        /// <remarks>仕入金額計（税込み）＋非課税対象額合計</remarks>
        private Int64 _stockTotalPrice;

        /// <summary>仕入金額小計</summary>
        /// <remarks>仕入金額計（税抜き）＋非課税対象額合計</remarks>
        private Int64 _stockSubttlPrice;
        // --- ADD 2010/10/21 ----------<<<<<

        //---ADD BY 朱 猛 on 2012/10/09 for Redmine#31879----->>>>>
        /// <summary> 赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _debitNoteDiv;
        //---ADD BY 朱 猛 on 2012/10/09 for Redmine#31879-----<<<<<

        //---ADD BY 凌小青 on 2012/08/30 for Redmine#31879----->>>>>
        /// <summary> 注文方法</summary>
        /// <remarks>0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録</remarks>
        private Int32 _wayToOrder;


        /// public propaty name  :  WayToOrder
        /// <summary>注文方法プロパティ</summary>
        /// <value>0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   注文方法プロパティ</br>
        /// <br>Programer        :   追加</br>
        /// </remarks>
        public Int32 WayToOrder
        {
            get { return _wayToOrder; }
            set { _wayToOrder = value; }
        }
        //---ADD BY 凌小青 on 2012/08/30 for Redmine#31879-----<<<<<

        //---ADD BY 朱 猛 on 2012/10/09 for Redmine#31879----->>>>>
        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>0:黒伝,1:赤伝,2:元黒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分プロパティ</br>
        /// <br>Programer        :   追加</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }
        //---ADD BY 朱 猛 on 2012/10/09 for Redmine#31879-----<<<<<

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
			get{return _createDateTime;}
			set{_createDateTime = value;}
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
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
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
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
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
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
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
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
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
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
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
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
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
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  StockCheckDivCAddUp
		/// <summary>仕入チェック区分（締次）プロパティ</summary>
		/// <value>0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入チェック区分（締次）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockCheckDivCAddUp
		{
			get{return _stockCheckDivCAddUp;}
			set{_stockCheckDivCAddUp = value;}
		}

		/// public propaty name  :  StockCheckDivDaily
		/// <summary>仕入チェック区分（日次）プロパティ</summary>
		/// <value>0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入チェック区分（日次）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockCheckDivDaily
		{
			get{return _stockCheckDivDaily;}
			set{_stockCheckDivDaily = value;}
		}

		/// public propaty name  :  StockDate
		/// <summary>仕入日プロパティ</summary>
		/// <value>YYYYMMDD　（更新年月日）</value>
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
			get{return _inputDay;}
			set{_inputDay = value;}
		}

		/// public propaty name  :  SupplierSlipNo
		/// <summary>仕入伝票番号プロパティ</summary>
		/// <value>発注伝票番号、仕入伝票番号、入荷伝票番号を兼ねる</value>
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

		/// public propaty name  :  StockPriceTaxInc
		/// <summary>仕入金額（税込み）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額（税込み）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockPriceTaxInc
		{
			get{return _stockPriceTaxInc;}
			set{_stockPriceTaxInc = value;}
		}

		/// public propaty name  :  StockPriceTaxExc
		/// <summary>仕入金額（税抜き）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額（税抜き）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockPriceTaxExc
		{
			get{return _stockPriceTaxExc;}
			set{_stockPriceTaxExc = value;}
		}

		/// public propaty name  :  StockPriceConsTax
		/// <summary>仕入金額消費税額(明細)プロパティ</summary>
		/// <value>仕入金額（税込み）- 仕入金額（税抜き）※消費税調整額も兼ねる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額消費税額(明細)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockPriceConsTax
		{
			get{return _stockPriceConsTax;}
			set{_stockPriceConsTax = value;}
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
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  StockCount
		/// <summary>仕入数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StockCount
		{
			get{return _stockCount;}
			set{_stockCount = value;}
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
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
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
			get{return _goodsName;}
			set{_goodsName = value;}
		}

		/// public propaty name  :  StockUnitPriceFl
		/// <summary>仕入単価（税抜，浮動）プロパティ</summary>
		/// <value>税抜き</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入単価（税抜，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StockUnitPriceFl
		{
			get{return _stockUnitPriceFl;}
			set{_stockUnitPriceFl = value;}
		}

		/// public propaty name  :  ListPriceTaxExcFl
		/// <summary>定価（税抜，浮動）プロパティ</summary>
		/// <value>税抜き</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価（税抜，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ListPriceTaxExcFl
		{
			get{return _listPriceTaxExcFl;}
			set{_listPriceTaxExcFl = value;}
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
			get{return _salesUnPrcTaxExcFl;}
			set{_salesUnPrcTaxExcFl = value;}
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
			get{return _salesMoneyTaxExc;}
			set{_salesMoneyTaxExc = value;}
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
			get{return _salesDate;}
			set{_salesDate = value;}
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
			get{return _salesSlipNum;}
			set{_salesSlipNum = value;}
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
			get{return _customerCode;}
			set{_customerCode = value;}
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
			get{return _customerSnm;}
			set{_customerSnm = value;}
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
			get{return _salesEmployeeNm;}
			set{_salesEmployeeNm = value;}
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
			get{return _frontEmployeeNm;}
			set{_frontEmployeeNm = value;}
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
			get{return _salesInputName;}
			set{_salesInputName = value;}
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

		/// public propaty name  :  SupplierFormal
		/// <summary>仕入形式プロパティ</summary>
		/// <value>0:仕入　（受注ステータス）</value>
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

		/// public propaty name  :  StockSlipDtlNum
		/// <summary>仕入明細通番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入明細通番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockSlipDtlNum
		{
			get{return _stockSlipDtlNum;}
			set{_stockSlipDtlNum = value;}
		}

		/// public propaty name  :  BfStockUnitPriceFl
		/// <summary>変更前仕入単価（浮動）プロパティ</summary>
		/// <value>税抜き、掛率算出結果</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   変更前仕入単価（浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double BfStockUnitPriceFl
		{
			get{return _bfStockUnitPriceFl;}
			set{_bfStockUnitPriceFl = value;}
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

		/// public propaty name  :  StockGoodsCd
		/// <summary>仕入商品区分プロパティ</summary>
		/// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力</value>
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

		/// public propaty name  :  SuppCTaxLayCd
		/// <summary>仕入先消費税転嫁方式コードプロパティ</summary>
		/// <value>0:伝票単位 1:明細単位 2:請求単位（請求先）3:請求単位（得意先）9:非課税</value>
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
		/// <value>外税時：税抜価格の集計、内税時：内税価格（税込）の集計－消費税</value>
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

		/// public propaty name  :  StockTtlPriceConsTax
		/// <summary>仕入金額消費税額(伝票)プロパティ</summary>
		/// <value>仕入金額消費税額（外税）+仕入金額消費税額（内税）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額消費税額(伝票)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockTtlPriceConsTax
		{
			get{return _stockTtlPriceConsTax;}
			set{_stockTtlPriceConsTax = value;}
		}

        // --- ADD 2010/10/21 ---------->>>>>
        /// public propaty name  :  StockTotalPrice
        /// <summary>仕入金額合計プロパティ</summary>
        /// <value>仕入金額計（税込み）＋非課税対象額合計</value>
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
        /// <value>仕入金額計（税抜き）＋非課税対象額合計</value>
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
        // --- ADD 2010/10/21 ----------<<<<<

		/// <summary>
		/// 仕入チェック処理抽出結果クラスワークコンストラクタ
		/// </summary>
		/// <returns>SupplierCheckResultWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SupplierCheckResultWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SupplierCheckResultWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SupplierCheckResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SupplierCheckResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SupplierCheckResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierCheckResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SupplierCheckResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SupplierCheckResultWork || graph is ArrayList || graph is SupplierCheckResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SupplierCheckResultWork).FullName));

            if (graph != null && graph is SupplierCheckResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SupplierCheckResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SupplierCheckResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SupplierCheckResultWork[])graph).Length;
            }
            else if (graph is SupplierCheckResultWork)
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
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //仕入チェック区分（締次）
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCheckDivCAddUp
            //仕入チェック区分（日次）
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCheckDivDaily
            //仕入日
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
            //入力日
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //相手先伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //仕入金額（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxInc
            //仕入金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //仕入金額消費税額(明細)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //仕入数
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //仕入単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //定価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //売上単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //売上金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //売上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //販売従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeNm
            //受付従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeNm
            //売上入力者名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputName
            //ＵＯＥリマーク１
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //ＵＯＥリマーク２
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //仕入形式
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //仕入明細通番
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNum
            //変更前仕入単価（浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //BfStockUnitPriceFl
            //仕入伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
            //仕入商品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //仕入先消費税転嫁方式コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //仕入金額計（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxInc
            //仕入金額計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxExc
            //仕入金額消費税額(伝票)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPriceConsTax
            // --- ADD 2010/10/21 ---------->>>>>
            //仕入金額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPrice
            //仕入金額小計
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSubttlPrice
            // --- ADD 2010/10/21 ----------<<<<<
            //注文方法
            serInfo.MemberInfo.Add(typeof(Int32)); //WayToOrder //ADD BY 凌小青 on 2012/08/30 for Redmine#31879
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv //赤伝区分 ADD BY 朱 猛 on 2012/10/09 for Redmine#31879


            serInfo.Serialize(writer, serInfo);
            if (graph is SupplierCheckResultWork)
            {
                SupplierCheckResultWork temp = (SupplierCheckResultWork)graph;

                SetSupplierCheckResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SupplierCheckResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SupplierCheckResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SupplierCheckResultWork temp in lst)
                {
                    SetSupplierCheckResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SupplierCheckResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        // --- UPD 2010/10/21 ---------->>>>>
        //private const int currentMemberCount = 46;
        //private const int currentMemberCount = 48;//DEL BY 凌小青 on 2012/08/30 for Redmine#31879
        //private const int currentMemberCount = 49;//ADD BY 凌小青 on 2012/08/30 for Redmine#31879
        private const int currentMemberCount = 50;//ADD BY 朱 猛 on 2012/10/09 for Redmine#31879
        // --- UPD 2010/10/21 ----------<<<<<

        /// <summary>
        ///  SupplierCheckResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierCheckResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSupplierCheckResultWork(System.IO.BinaryWriter writer, SupplierCheckResultWork temp)
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
            //拠点コード
            writer.Write(temp.SectionCode);
            //仕入チェック区分（締次）
            writer.Write(temp.StockCheckDivCAddUp);
            //仕入チェック区分（日次）
            writer.Write(temp.StockCheckDivDaily);
            //仕入日
            writer.Write((Int64)temp.StockDate.Ticks);
            //入力日
            writer.Write((Int64)temp.InputDay.Ticks);
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //相手先伝票番号
            writer.Write(temp.PartySaleSlipNum);
            //仕入金額（税込み）
            writer.Write(temp.StockPriceTaxInc);
            //仕入金額（税抜き）
            writer.Write(temp.StockPriceTaxExc);
            //仕入金額消費税額(明細)
            writer.Write(temp.StockPriceConsTax);
            //商品番号
            writer.Write(temp.GoodsNo);
            //仕入数
            writer.Write(temp.StockCount);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //商品名称
            writer.Write(temp.GoodsName);
            //仕入単価（税抜，浮動）
            writer.Write(temp.StockUnitPriceFl);
            //定価（税抜，浮動）
            writer.Write(temp.ListPriceTaxExcFl);
            //売上単価（税抜，浮動）
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //売上金額（税抜き）
            writer.Write(temp.SalesMoneyTaxExc);
            //売上日付
            writer.Write((Int64)temp.SalesDate.Ticks);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //販売従業員名称
            writer.Write(temp.SalesEmployeeNm);
            //受付従業員名称
            writer.Write(temp.FrontEmployeeNm);
            //売上入力者名称
            writer.Write(temp.SalesInputName);
            //ＵＯＥリマーク１
            writer.Write(temp.UoeRemark1);
            //ＵＯＥリマーク２
            writer.Write(temp.UoeRemark2);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //仕入形式
            writer.Write(temp.SupplierFormal);
            //仕入明細通番
            writer.Write(temp.StockSlipDtlNum);
            //変更前仕入単価（浮動）
            writer.Write(temp.BfStockUnitPriceFl);
            //仕入伝票区分
            writer.Write(temp.SupplierSlipCd);
            //仕入商品区分
            writer.Write(temp.StockGoodsCd);
            //仕入先消費税転嫁方式コード
            writer.Write(temp.SuppCTaxLayCd);
            //仕入金額計（税込み）
            writer.Write(temp.StockTtlPricTaxInc);
            //仕入金額計（税抜き）
            writer.Write(temp.StockTtlPricTaxExc);
            //仕入金額消費税額(伝票)
            writer.Write(temp.StockTtlPriceConsTax);
            // --- ADD 2010/10/21 ---------->>>>>
            //仕入金額合計
            writer.Write(temp.StockTotalPrice);
            //仕入金額小計
            writer.Write(temp.StockSubttlPrice);
            // --- ADD 2010/10/21 ----------<<<<<
            //注文方法
            writer.Write(temp.WayToOrder); //ADD BY 凌小青 on 2012/08/30 for Redmine#31879
            writer.Write(temp.DebitNoteDiv); //ADD BY 朱 猛 on 2012/10/09 for Redmine#31879

        }

        /// <summary>
        ///  SupplierCheckResultWorkインスタンス取得
        /// </summary>
        /// <returns>SupplierCheckResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierCheckResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SupplierCheckResultWork GetSupplierCheckResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SupplierCheckResultWork temp = new SupplierCheckResultWork();

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
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //仕入チェック区分（締次）
            temp.StockCheckDivCAddUp = reader.ReadInt32();
            //仕入チェック区分（日次）
            temp.StockCheckDivDaily = reader.ReadInt32();
            //仕入日
            temp.StockDate = new DateTime(reader.ReadInt64());
            //入力日
            temp.InputDay = new DateTime(reader.ReadInt64());
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //相手先伝票番号
            temp.PartySaleSlipNum = reader.ReadString();
            //仕入金額（税込み）
            temp.StockPriceTaxInc = reader.ReadInt64();
            //仕入金額（税抜き）
            temp.StockPriceTaxExc = reader.ReadInt64();
            //仕入金額消費税額(明細)
            temp.StockPriceConsTax = reader.ReadInt64();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //仕入数
            temp.StockCount = reader.ReadDouble();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //仕入単価（税抜，浮動）
            temp.StockUnitPriceFl = reader.ReadDouble();
            //定価（税抜，浮動）
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //売上単価（税抜，浮動）
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //売上金額（税抜き）
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //売上日付
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //販売従業員名称
            temp.SalesEmployeeNm = reader.ReadString();
            //受付従業員名称
            temp.FrontEmployeeNm = reader.ReadString();
            //売上入力者名称
            temp.SalesInputName = reader.ReadString();
            //ＵＯＥリマーク１
            temp.UoeRemark1 = reader.ReadString();
            //ＵＯＥリマーク２
            temp.UoeRemark2 = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //仕入形式
            temp.SupplierFormal = reader.ReadInt32();
            //仕入明細通番
            temp.StockSlipDtlNum = reader.ReadInt64();
            //変更前仕入単価（浮動）
            temp.BfStockUnitPriceFl = reader.ReadDouble();
            //仕入伝票区分
            temp.SupplierSlipCd = reader.ReadInt32();
            //仕入商品区分
            temp.StockGoodsCd = reader.ReadInt32();
            //仕入先消費税転嫁方式コード
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //仕入金額計（税込み）
            temp.StockTtlPricTaxInc = reader.ReadInt64();
            //仕入金額計（税抜き）
            temp.StockTtlPricTaxExc = reader.ReadInt64();
            //仕入金額消費税額(伝票)
            temp.StockTtlPriceConsTax = reader.ReadInt64();
            // --- ADD 2010/10/21 ---------->>>>>
            //仕入金額合計
            temp.StockTotalPrice = reader.ReadInt64();
            //仕入金額小計
            temp.StockSubttlPrice = reader.ReadInt64();
            // --- ADD 2010/10/21 ----------<<<<<
            //注文方法
            temp.WayToOrder = reader.ReadInt32(); //ADD BY 凌小青 on 2012/08/30 for Redmine#31879
            temp.DebitNoteDiv = reader.ReadInt32(); //赤伝区分 ADD BY 朱 猛 on 2012/10/09 for Redmine#31879


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
        /// <returns>SupplierCheckResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierCheckResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SupplierCheckResultWork temp = GetSupplierCheckResultWork(reader, serInfo);
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
                    retValue = (SupplierCheckResultWork[])lst.ToArray(typeof(SupplierCheckResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }



}