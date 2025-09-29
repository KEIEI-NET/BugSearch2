using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SuplierPayInfGetWork
	/// <summary>
	///                      仕入先元帳（支払履歴）抽出結果ワークワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入先元帳（支払履歴）抽出結果ワークワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/02/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   消費税転嫁方式が反映されずに表示される問題対応</br>
    /// <br>Programmer       :   FSI斎藤 和宏</br>
    /// <br>Date             :   2012/11/01</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SuplierPayInfGetWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>計上拠点コード</summary>
		/// <remarks>集計の対象となっている拠点コード</remarks>
		private string _addUpSecCode = "";

		/// <summary>支払先コード</summary>
		/// <remarks>支払先の親コード</remarks>
		private Int32 _payeeCode;

		/// <summary>支払先名称</summary>
		private string _payeeName = "";

		/// <summary>支払先名称2</summary>
		private string _payeeName2 = "";

		/// <summary>支払先略称</summary>
		private string _payeeSnm = "";

		/// <summary>実績拠点コード</summary>
		/// <remarks>実績集計の対象となっている拠点コード</remarks>
		private string _resultsSectCd = "";

		/// <summary>仕入先コード</summary>
		/// <remarks>支払先の子コード（親レコードの場合０セット）</remarks>
		private Int32 _supplierCd;

		/// <summary>仕入先名1</summary>
		private string _supplierNm1 = "";

		/// <summary>仕入先名2</summary>
		private string _supplierNm2 = "";

		/// <summary>仕入先略称</summary>
		private string _supplierSnm = "";

		/// <summary>計上年月日</summary>
		/// <remarks>YYYYMMDD 支払締を行なった日（相手先基準）</remarks>
		private DateTime _addUpDate;

		/// <summary>計上年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonth;

		/// <summary>前回支払金額</summary>
		private Int64 _lastTimePayment;

		/// <summary>仕入2回前残高（支払計）</summary>
		private Int64 _stockTtl2TmBfBlPay;

		/// <summary>仕入3回前残高（支払計）</summary>
		private Int64 _stockTtl3TmBfBlPay;

		/// <summary>今回支払金額（通常支払）</summary>
		/// <remarks>支払額の合計金額</remarks>
		private Int64 _thisTimePayNrml;

		/// <summary>今回繰越残高（支払計）</summary>
		/// <remarks>今回繰越残高＝前回支払額 ー　今回支払額合計（通常支払）</remarks>
		private Int64 _thisTimeTtlBlcPay;

		/// <summary>相殺後今回仕入金額</summary>
		/// <remarks>相殺結果</remarks>
		private Int64 _ofsThisTimeStock;

		/// <summary>相殺後今回仕入消費税</summary>
		/// <remarks>相殺結果</remarks>
		private Int64 _ofsThisStockTax;

		/// <summary>今回返品金額</summary>
		/// <remarks>掛仕入：値引、返品を含まない 税抜きの仕入返品金額</remarks>
		private Int64 _thisStckPricRgds;

		/// <summary>今回返品消費税</summary>
		/// <remarks>今回返品消費税＝返品外税額合計＋返品内税額合計</remarks>
		private Int64 _thisStcPrcTaxRgds;

		/// <summary>今回値引金額</summary>
		/// <remarks>掛仕入：税抜きの仕入値引き金額</remarks>
		private Int64 _thisStckPricDis;

		/// <summary>今回値引消費税</summary>
		/// <remarks>今回値引消費税＝値引外税額合計＋値引内税額合計</remarks>
		private Int64 _thisStcPrcTaxDis;

		/// <summary>消費税調整額</summary>
		private Int64 _taxAdjust;

		/// <summary>残高調整額</summary>
		private Int64 _balanceAdjust;

		/// <summary>仕入合計残高（支払計）</summary>
		/// <remarks>今回分の支払金額 今回繰越残高（支払計）＋今回純仕入金額＋今回純消費税＋残高調整＋消費税調整額</remarks>
		private Int64 _stockTotalPayBalance;

		/// <summary>締次更新実行年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _cAddUpUpdExecDate;

		/// <summary>締次更新開始年月日</summary>
		/// <remarks>"YYYYMMDD"  締次更新対象となる開始年月日</remarks>
		private DateTime _startCAddUpUpdDate;

		/// <summary>前回締次更新年月日</summary>
		/// <remarks>"YYYYMMDD"  前回締次更新対象となった年月日</remarks>
		private DateTime _lastCAddUpUpdDate;

		/// <summary>仕入伝票枚数</summary>
		private Int32 _stockSlipCount;

		/// <summary>今回仕入金額</summary>
		/// <remarks>掛仕入：値引、返品を含まない 税抜きの仕入金額</remarks>
		private Int64 _thisTimeStockPrice;

		/// <summary>今回仕入消費税</summary>
		/// <remarks>今回仕入消費税＝仕入外税額合計＋仕入内税額合計</remarks>
		private Int64 _thisStcPrcTax;

		/// <summary>締済みフラグ</summary>
		/// <remarks>0:未処理,1:締済み</remarks>
		private Int32 _closeFlg;

        // --- ADD 2012/11/01 ---------->>>>>
        /// <summary>消費税転嫁方式</summary>
        /// <remarks>0:伝票単位 1:明細単位 2:請求単位（請求先）3:請求単位（得意先）9:非課税</remarks>
        private Int32 _suppCTaxLayCd;
        // --- ADD 2012/11/01 ----------<<<<<

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

		/// public propaty name  :  AddUpSecCode
		/// <summary>計上拠点コードプロパティ</summary>
		/// <value>集計の対象となっている拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpSecCode
		{
			get{return _addUpSecCode;}
			set{_addUpSecCode = value;}
		}

		/// public propaty name  :  PayeeCode
		/// <summary>支払先コードプロパティ</summary>
		/// <value>支払先の親コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PayeeCode
		{
			get{return _payeeCode;}
			set{_payeeCode = value;}
		}

		/// public propaty name  :  PayeeName
		/// <summary>支払先名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払先名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PayeeName
		{
			get{return _payeeName;}
			set{_payeeName = value;}
		}

		/// public propaty name  :  PayeeName2
		/// <summary>支払先名称2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払先名称2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PayeeName2
		{
			get{return _payeeName2;}
			set{_payeeName2 = value;}
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
			get{return _payeeSnm;}
			set{_payeeSnm = value;}
		}

		/// public propaty name  :  ResultsSectCd
		/// <summary>実績拠点コードプロパティ</summary>
		/// <value>実績集計の対象となっている拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   実績拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ResultsSectCd
		{
			get{return _resultsSectCd;}
			set{_resultsSectCd = value;}
		}

		/// public propaty name  :  SupplierCd
		/// <summary>仕入先コードプロパティ</summary>
		/// <value>支払先の子コード（親レコードの場合０セット）</value>
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

		/// public propaty name  :  SupplierNm1
		/// <summary>仕入先名1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先名1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SupplierNm1
		{
			get{return _supplierNm1;}
			set{_supplierNm1 = value;}
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
			get{return _supplierNm2;}
			set{_supplierNm2 = value;}
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

		/// public propaty name  :  AddUpDate
		/// <summary>計上年月日プロパティ</summary>
		/// <value>YYYYMMDD 支払締を行なった日（相手先基準）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpDate
		{
			get{return _addUpDate;}
			set{_addUpDate = value;}
		}

		/// public propaty name  :  AddUpYearMonth
		/// <summary>計上年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpYearMonth
		{
			get{return _addUpYearMonth;}
			set{_addUpYearMonth = value;}
		}

		/// public propaty name  :  LastTimePayment
		/// <summary>前回支払金額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回支払金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 LastTimePayment
		{
			get{return _lastTimePayment;}
			set{_lastTimePayment = value;}
		}

		/// public propaty name  :  StockTtl2TmBfBlPay
		/// <summary>仕入2回前残高（支払計）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入2回前残高（支払計）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockTtl2TmBfBlPay
		{
			get{return _stockTtl2TmBfBlPay;}
			set{_stockTtl2TmBfBlPay = value;}
		}

		/// public propaty name  :  StockTtl3TmBfBlPay
		/// <summary>仕入3回前残高（支払計）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入3回前残高（支払計）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockTtl3TmBfBlPay
		{
			get{return _stockTtl3TmBfBlPay;}
			set{_stockTtl3TmBfBlPay = value;}
		}

		/// public propaty name  :  ThisTimePayNrml
		/// <summary>今回支払金額（通常支払）プロパティ</summary>
		/// <value>支払額の合計金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回支払金額（通常支払）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimePayNrml
		{
			get{return _thisTimePayNrml;}
			set{_thisTimePayNrml = value;}
		}

		/// public propaty name  :  ThisTimeTtlBlcPay
		/// <summary>今回繰越残高（支払計）プロパティ</summary>
		/// <value>今回繰越残高＝前回支払額 ー　今回支払額合計（通常支払）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回繰越残高（支払計）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimeTtlBlcPay
		{
			get{return _thisTimeTtlBlcPay;}
			set{_thisTimeTtlBlcPay = value;}
		}

		/// public propaty name  :  OfsThisTimeStock
		/// <summary>相殺後今回仕入金額プロパティ</summary>
		/// <value>相殺結果</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相殺後今回仕入金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 OfsThisTimeStock
		{
			get{return _ofsThisTimeStock;}
			set{_ofsThisTimeStock = value;}
		}

		/// public propaty name  :  OfsThisStockTax
		/// <summary>相殺後今回仕入消費税プロパティ</summary>
		/// <value>相殺結果</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相殺後今回仕入消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 OfsThisStockTax
		{
			get{return _ofsThisStockTax;}
			set{_ofsThisStockTax = value;}
		}

		/// public propaty name  :  ThisStckPricRgds
		/// <summary>今回返品金額プロパティ</summary>
		/// <value>掛仕入：値引、返品を含まない 税抜きの仕入返品金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回返品金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisStckPricRgds
		{
			get{return _thisStckPricRgds;}
			set{_thisStckPricRgds = value;}
		}

		/// public propaty name  :  ThisStcPrcTaxRgds
		/// <summary>今回返品消費税プロパティ</summary>
		/// <value>今回返品消費税＝返品外税額合計＋返品内税額合計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回返品消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisStcPrcTaxRgds
		{
			get{return _thisStcPrcTaxRgds;}
			set{_thisStcPrcTaxRgds = value;}
		}

		/// public propaty name  :  ThisStckPricDis
		/// <summary>今回値引金額プロパティ</summary>
		/// <value>掛仕入：税抜きの仕入値引き金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回値引金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisStckPricDis
		{
			get{return _thisStckPricDis;}
			set{_thisStckPricDis = value;}
		}

		/// public propaty name  :  ThisStcPrcTaxDis
		/// <summary>今回値引消費税プロパティ</summary>
		/// <value>今回値引消費税＝値引外税額合計＋値引内税額合計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回値引消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisStcPrcTaxDis
		{
			get{return _thisStcPrcTaxDis;}
			set{_thisStcPrcTaxDis = value;}
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
			get{return _taxAdjust;}
			set{_taxAdjust = value;}
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
			get{return _balanceAdjust;}
			set{_balanceAdjust = value;}
		}

		/// public propaty name  :  StockTotalPayBalance
		/// <summary>仕入合計残高（支払計）プロパティ</summary>
		/// <value>今回分の支払金額 今回繰越残高（支払計）＋今回純仕入金額＋今回純消費税＋残高調整＋消費税調整額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入合計残高（支払計）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockTotalPayBalance
		{
			get{return _stockTotalPayBalance;}
			set{_stockTotalPayBalance = value;}
		}

		/// public propaty name  :  CAddUpUpdExecDate
		/// <summary>締次更新実行年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新実行年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime CAddUpUpdExecDate
		{
			get{return _cAddUpUpdExecDate;}
			set{_cAddUpUpdExecDate = value;}
		}

		/// public propaty name  :  StartCAddUpUpdDate
		/// <summary>締次更新開始年月日プロパティ</summary>
		/// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新開始年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime StartCAddUpUpdDate
		{
			get{return _startCAddUpUpdDate;}
			set{_startCAddUpUpdDate = value;}
		}

		/// public propaty name  :  LastCAddUpUpdDate
		/// <summary>前回締次更新年月日プロパティ</summary>
		/// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回締次更新年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime LastCAddUpUpdDate
		{
			get{return _lastCAddUpUpdDate;}
			set{_lastCAddUpUpdDate = value;}
		}

		/// public propaty name  :  StockSlipCount
		/// <summary>仕入伝票枚数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票枚数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockSlipCount
		{
			get{return _stockSlipCount;}
			set{_stockSlipCount = value;}
		}

		/// public propaty name  :  ThisTimeStockPrice
		/// <summary>今回仕入金額プロパティ</summary>
		/// <value>掛仕入：値引、返品を含まない 税抜きの仕入金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回仕入金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimeStockPrice
		{
			get{return _thisTimeStockPrice;}
			set{_thisTimeStockPrice = value;}
		}

		/// public propaty name  :  ThisStcPrcTax
		/// <summary>今回仕入消費税プロパティ</summary>
		/// <value>今回仕入消費税＝仕入外税額合計＋仕入内税額合計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回仕入消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisStcPrcTax
		{
			get{return _thisStcPrcTax;}
			set{_thisStcPrcTax = value;}
		}

		/// public propaty name  :  CloseFlg
		/// <summary>締済みフラグプロパティ</summary>
		/// <value>0:未処理,1:締済み</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締済みフラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CloseFlg
		{
			get{return _closeFlg;}
			set{_closeFlg = value;}
		}

        // --- ADD 2012/11/01 ---------->>>>>
        /// public propaty name  :  SuppCTaxLayCd
        /// <summary>消費税転嫁方式プロパティ</summary>
        /// <value>0:伝票単位 1:明細単位 2:請求単位（請求先）3:請求単位（得意先）9:非課税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税転嫁方式プロパティ</br>
        /// <br>Programer        :   FSI斎藤 和宏</br>
        /// </remarks>
        public Int32 SuppCTaxLayCd
        {
            get { return _suppCTaxLayCd; }
            set { _suppCTaxLayCd = value; }
        }
        // --- ADD 2012/11/01 ----------<<<<<


		/// <summary>
		/// 仕入先元帳（支払履歴）抽出結果ワークワークコンストラクタ
		/// </summary>
		/// <returns>SuplierPayInfGetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuplierPayInfGetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SuplierPayInfGetWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SuplierPayInfGetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SuplierPayInfGetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SuplierPayInfGetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayInfGetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SuplierPayInfGetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SuplierPayInfGetWork || graph is ArrayList || graph is SuplierPayInfGetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SuplierPayInfGetWork).FullName));

            if (graph != null && graph is SuplierPayInfGetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuplierPayInfGetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SuplierPayInfGetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SuplierPayInfGetWork[])graph).Length;
            }
            else if (graph is SuplierPayInfGetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //支払先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //支払先名称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName
            //支払先名称2
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName2
            //支払先略称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //実績拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ResultsSectCd
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先名1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //仕入先名2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //計上年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //前回支払金額
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimePayment
            //仕入2回前残高（支払計）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtl2TmBfBlPay
            //仕入3回前残高（支払計）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtl3TmBfBlPay
            //今回支払金額（通常支払）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimePayNrml
            //今回繰越残高（支払計）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcPay
            //相殺後今回仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeStock
            //相殺後今回仕入消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisStockTax
            //今回返品金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricRgds
            //今回返品消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStcPrcTaxRgds
            //今回値引金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricDis
            //今回値引消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStcPrcTaxDis
            //消費税調整額
            serInfo.MemberInfo.Add(typeof(Int64)); //TaxAdjust
            //残高調整額
            serInfo.MemberInfo.Add(typeof(Int64)); //BalanceAdjust
            //仕入合計残高（支払計）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPayBalance
            //締次更新実行年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //CAddUpUpdExecDate
            //締次更新開始年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //StartCAddUpUpdDate
            //前回締次更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //LastCAddUpUpdDate
            //仕入伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCount
            //今回仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeStockPrice
            //今回仕入消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStcPrcTax
            //締済みフラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //CloseFlg
            // --- ADD 2012/11/01 ---------->>>>>
            //消費税転嫁方式
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            // --- ADD 2012/11/01 ----------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SuplierPayInfGetWork)
            {
                SuplierPayInfGetWork temp = (SuplierPayInfGetWork)graph;

                SetSuplierPayInfGetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SuplierPayInfGetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SuplierPayInfGetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SuplierPayInfGetWork temp in lst)
                {
                    SetSuplierPayInfGetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SuplierPayInfGetWorkメンバ数(publicプロパティ数)
        /// </summary>
        // --- ADD 2012/11/01 ---------->>>>>
        //private const int currentMemberCount = 34;
        private const int currentMemberCount = 35;
        // --- ADD 2012/11/01 ----------<<<<<

        /// <summary>
        ///  SuplierPayInfGetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayInfGetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSuplierPayInfGetWork(System.IO.BinaryWriter writer, SuplierPayInfGetWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //支払先コード
            writer.Write(temp.PayeeCode);
            //支払先名称
            writer.Write(temp.PayeeName);
            //支払先名称2
            writer.Write(temp.PayeeName2);
            //支払先略称
            writer.Write(temp.PayeeSnm);
            //実績拠点コード
            writer.Write(temp.ResultsSectCd);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先名1
            writer.Write(temp.SupplierNm1);
            //仕入先名2
            writer.Write(temp.SupplierNm2);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //計上年月日
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //計上年月
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //前回支払金額
            writer.Write(temp.LastTimePayment);
            //仕入2回前残高（支払計）
            writer.Write(temp.StockTtl2TmBfBlPay);
            //仕入3回前残高（支払計）
            writer.Write(temp.StockTtl3TmBfBlPay);
            //今回支払金額（通常支払）
            writer.Write(temp.ThisTimePayNrml);
            //今回繰越残高（支払計）
            writer.Write(temp.ThisTimeTtlBlcPay);
            //相殺後今回仕入金額
            writer.Write(temp.OfsThisTimeStock);
            //相殺後今回仕入消費税
            writer.Write(temp.OfsThisStockTax);
            //今回返品金額
            writer.Write(temp.ThisStckPricRgds);
            //今回返品消費税
            writer.Write(temp.ThisStcPrcTaxRgds);
            //今回値引金額
            writer.Write(temp.ThisStckPricDis);
            //今回値引消費税
            writer.Write(temp.ThisStcPrcTaxDis);
            //消費税調整額
            writer.Write(temp.TaxAdjust);
            //残高調整額
            writer.Write(temp.BalanceAdjust);
            //仕入合計残高（支払計）
            writer.Write(temp.StockTotalPayBalance);
            //締次更新実行年月日
            writer.Write((Int64)temp.CAddUpUpdExecDate.Ticks);
            //締次更新開始年月日
            writer.Write((Int64)temp.StartCAddUpUpdDate.Ticks);
            //前回締次更新年月日
            writer.Write((Int64)temp.LastCAddUpUpdDate.Ticks);
            //仕入伝票枚数
            writer.Write(temp.StockSlipCount);
            //今回仕入金額
            writer.Write(temp.ThisTimeStockPrice);
            //今回仕入消費税
            writer.Write(temp.ThisStcPrcTax);
            //締済みフラグ
            writer.Write(temp.CloseFlg);
            // --- ADD 2012/11/01 ---------->>>>>
            //消費税転嫁方式
            writer.Write(temp.SuppCTaxLayCd);
            // --- ADD 2012/11/01 ----------<<<<<
        }

        /// <summary>
        ///  SuplierPayInfGetWorkインスタンス取得
        /// </summary>
        /// <returns>SuplierPayInfGetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayInfGetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SuplierPayInfGetWork GetSuplierPayInfGetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SuplierPayInfGetWork temp = new SuplierPayInfGetWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //支払先コード
            temp.PayeeCode = reader.ReadInt32();
            //支払先名称
            temp.PayeeName = reader.ReadString();
            //支払先名称2
            temp.PayeeName2 = reader.ReadString();
            //支払先略称
            temp.PayeeSnm = reader.ReadString();
            //実績拠点コード
            temp.ResultsSectCd = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先名1
            temp.SupplierNm1 = reader.ReadString();
            //仕入先名2
            temp.SupplierNm2 = reader.ReadString();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //計上年月日
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //計上年月
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //前回支払金額
            temp.LastTimePayment = reader.ReadInt64();
            //仕入2回前残高（支払計）
            temp.StockTtl2TmBfBlPay = reader.ReadInt64();
            //仕入3回前残高（支払計）
            temp.StockTtl3TmBfBlPay = reader.ReadInt64();
            //今回支払金額（通常支払）
            temp.ThisTimePayNrml = reader.ReadInt64();
            //今回繰越残高（支払計）
            temp.ThisTimeTtlBlcPay = reader.ReadInt64();
            //相殺後今回仕入金額
            temp.OfsThisTimeStock = reader.ReadInt64();
            //相殺後今回仕入消費税
            temp.OfsThisStockTax = reader.ReadInt64();
            //今回返品金額
            temp.ThisStckPricRgds = reader.ReadInt64();
            //今回返品消費税
            temp.ThisStcPrcTaxRgds = reader.ReadInt64();
            //今回値引金額
            temp.ThisStckPricDis = reader.ReadInt64();
            //今回値引消費税
            temp.ThisStcPrcTaxDis = reader.ReadInt64();
            //消費税調整額
            temp.TaxAdjust = reader.ReadInt64();
            //残高調整額
            temp.BalanceAdjust = reader.ReadInt64();
            //仕入合計残高（支払計）
            temp.StockTotalPayBalance = reader.ReadInt64();
            //締次更新実行年月日
            temp.CAddUpUpdExecDate = new DateTime(reader.ReadInt64());
            //締次更新開始年月日
            temp.StartCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //前回締次更新年月日
            temp.LastCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //仕入伝票枚数
            temp.StockSlipCount = reader.ReadInt32();
            //今回仕入金額
            temp.ThisTimeStockPrice = reader.ReadInt64();
            //今回仕入消費税
            temp.ThisStcPrcTax = reader.ReadInt64();
            //締済みフラグ
            temp.CloseFlg = reader.ReadInt32();
            // --- ADD 2012/11/01 ---------->>>>>
            //消費税転嫁方式
            temp.SuppCTaxLayCd = reader.ReadInt32();
            // --- ADD 2012/11/01 ----------<<<<<


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
        /// <returns>SuplierPayInfGetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayInfGetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SuplierPayInfGetWork temp = GetSuplierPayInfGetWork(reader, serInfo);
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
                    retValue = (SuplierPayInfGetWork[])lst.ToArray(typeof(SuplierPayInfGetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
