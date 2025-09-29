using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SuplierPayInfGet
	/// <summary>
	///                      仕入先元帳（支払履歴）抽出結果ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入先元帳（支払履歴）抽出結果ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/01/14  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SuplierPayInfGet
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

        /// <summary>今回返品・値引金額</summary>
        /// <remarks>印刷用　返品＋値引</remarks>
        private Int64 _thisStckPricRgdsDis;

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

		/// <summary>締済みフラグ</summary>
		/// <remarks>0:未処理,1:締済み</remarks>
		private Int32 _closeFlg;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>計上拠点名称</summary>
		private string _addUpSecName = "";


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

		/// public propaty name  :  AddUpDateJpFormal
		/// <summary>計上年月日 和暦プロパティ</summary>
		/// <value>YYYYMMDD 支払締を行なった日（相手先基準）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _addUpDate);}
			set{}
		}

		/// public propaty name  :  AddUpDateJpInFormal
		/// <summary>計上年月日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD 支払締を行なった日（相手先基準）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpDate);}
			set{}
		}

		/// public propaty name  :  AddUpDateAdFormal
		/// <summary>計上年月日 西暦プロパティ</summary>
		/// <value>YYYYMMDD 支払締を行なった日（相手先基準）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpDate);}
			set{}
		}

		/// public propaty name  :  AddUpDateAdInFormal
		/// <summary>計上年月日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD 支払締を行なった日（相手先基準）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _addUpDate);}
			set{}
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

		/// public propaty name  :  AddUpYearMonthJpFormal
		/// <summary>計上年月 和暦プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpYearMonthJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMM", _addUpYearMonth);}
			set{}
		}

		/// public propaty name  :  AddUpYearMonthJpInFormal
		/// <summary>計上年月 和暦(略)プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpYearMonthJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM", _addUpYearMonth);}
			set{}
		}

		/// public propaty name  :  AddUpYearMonthAdFormal
		/// <summary>計上年月 西暦プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpYearMonthAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM", _addUpYearMonth);}
			set{}
		}

		/// public propaty name  :  AddUpYearMonthAdInFormal
		/// <summary>計上年月 西暦(略)プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpYearMonthAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM", _addUpYearMonth);}
			set{}
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

        /// public propaty name  :  ThisStckPricRgdsDis
        /// <summary>今回返品・値引金額プロパティ</summary>
        /// <value>印刷用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回返品・値引金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisStckPricRgdsDis
        {
            get { return _thisStckPricRgdsDis; }
            set { _thisStckPricRgdsDis = value; }
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

		/// public propaty name  :  CAddUpUpdExecDateJpFormal
		/// <summary>締次更新実行年月日 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新実行年月日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CAddUpUpdExecDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _cAddUpUpdExecDate);}
			set{}
		}

		/// public propaty name  :  CAddUpUpdExecDateJpInFormal
		/// <summary>締次更新実行年月日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新実行年月日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CAddUpUpdExecDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _cAddUpUpdExecDate);}
			set{}
		}

		/// public propaty name  :  CAddUpUpdExecDateAdFormal
		/// <summary>締次更新実行年月日 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新実行年月日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CAddUpUpdExecDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _cAddUpUpdExecDate);}
			set{}
		}

		/// public propaty name  :  CAddUpUpdExecDateAdInFormal
		/// <summary>締次更新実行年月日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新実行年月日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CAddUpUpdExecDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _cAddUpUpdExecDate);}
			set{}
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

		/// public propaty name  :  StartCAddUpUpdDateJpFormal
		/// <summary>締次更新開始年月日 和暦プロパティ</summary>
		/// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新開始年月日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StartCAddUpUpdDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _startCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  StartCAddUpUpdDateJpInFormal
		/// <summary>締次更新開始年月日 和暦(略)プロパティ</summary>
		/// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新開始年月日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StartCAddUpUpdDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _startCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  StartCAddUpUpdDateAdFormal
		/// <summary>締次更新開始年月日 西暦プロパティ</summary>
		/// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新開始年月日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StartCAddUpUpdDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _startCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  StartCAddUpUpdDateAdInFormal
		/// <summary>締次更新開始年月日 西暦(略)プロパティ</summary>
		/// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新開始年月日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StartCAddUpUpdDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _startCAddUpUpdDate);}
			set{}
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

		/// public propaty name  :  LastCAddUpUpdDateJpFormal
		/// <summary>前回締次更新年月日 和暦プロパティ</summary>
		/// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回締次更新年月日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastCAddUpUpdDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _lastCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  LastCAddUpUpdDateJpInFormal
		/// <summary>前回締次更新年月日 和暦(略)プロパティ</summary>
		/// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回締次更新年月日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastCAddUpUpdDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _lastCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  LastCAddUpUpdDateAdFormal
		/// <summary>前回締次更新年月日 西暦プロパティ</summary>
		/// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回締次更新年月日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastCAddUpUpdDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _lastCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  LastCAddUpUpdDateAdInFormal
		/// <summary>前回締次更新年月日 西暦(略)プロパティ</summary>
		/// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回締次更新年月日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastCAddUpUpdDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _lastCAddUpUpdDate);}
			set{}
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

		/// public propaty name  :  EnterpriseName
		/// <summary>企業名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

		/// public propaty name  :  AddUpSecName
		/// <summary>計上拠点名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上拠点名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpSecName
		{
			get{return _addUpSecName;}
			set{_addUpSecName = value;}
		}


		/// <summary>
		/// 仕入先元帳（支払履歴）抽出結果ワークコンストラクタ
		/// </summary>
		/// <returns>SuplierPayInfGetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuplierPayInfGetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SuplierPayInfGet()
		{
		}

		/// <summary>
		/// 仕入先元帳（支払履歴）抽出結果ワークコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="addUpSecCode">計上拠点コード(集計の対象となっている拠点コード)</param>
		/// <param name="payeeCode">支払先コード(支払先の親コード)</param>
		/// <param name="payeeName">支払先名称</param>
		/// <param name="payeeName2">支払先名称2</param>
		/// <param name="payeeSnm">支払先略称</param>
		/// <param name="resultsSectCd">実績拠点コード(実績集計の対象となっている拠点コード)</param>
		/// <param name="supplierCd">仕入先コード(支払先の子コード（親レコードの場合０セット）)</param>
		/// <param name="supplierNm1">仕入先名1</param>
		/// <param name="supplierNm2">仕入先名2</param>
		/// <param name="supplierSnm">仕入先略称</param>
		/// <param name="addUpDate">計上年月日(YYYYMMDD 支払締を行なった日（相手先基準）)</param>
		/// <param name="addUpYearMonth">計上年月(YYYYMM)</param>
		/// <param name="lastTimePayment">前回支払金額</param>
		/// <param name="stockTtl2TmBfBlPay">仕入2回前残高（支払計）</param>
		/// <param name="stockTtl3TmBfBlPay">仕入3回前残高（支払計）</param>
		/// <param name="thisTimePayNrml">今回支払金額（通常支払）(支払額の合計金額)</param>
		/// <param name="thisTimeTtlBlcPay">今回繰越残高（支払計）(今回繰越残高＝前回支払額 ー　今回支払額合計（通常支払）)</param>
		/// <param name="ofsThisTimeStock">相殺後今回仕入金額(相殺結果)</param>
		/// <param name="ofsThisStockTax">相殺後今回仕入消費税(相殺結果)</param>
		/// <param name="thisStckPricRgds">今回返品金額(掛仕入：値引、返品を含まない 税抜きの仕入返品金額)</param>
		/// <param name="thisStcPrcTaxRgds">今回返品消費税(今回返品消費税＝返品外税額合計＋返品内税額合計)</param>
		/// <param name="thisStckPricDis">今回値引金額(掛仕入：税抜きの仕入値引き金額)</param>
		/// <param name="thisStcPrcTaxDis">今回値引消費税(今回値引消費税＝値引外税額合計＋値引内税額合計)</param>
		/// <param name="taxAdjust">消費税調整額</param>
		/// <param name="balanceAdjust">残高調整額</param>
		/// <param name="stockTotalPayBalance">仕入合計残高（支払計）(今回分の支払金額 今回繰越残高（支払計）＋今回純仕入金額＋今回純消費税＋残高調整＋消費税調整額)</param>
		/// <param name="cAddUpUpdExecDate">締次更新実行年月日(YYYYMMDD)</param>
		/// <param name="startCAddUpUpdDate">締次更新開始年月日("YYYYMMDD"  締次更新対象となる開始年月日)</param>
		/// <param name="lastCAddUpUpdDate">前回締次更新年月日("YYYYMMDD"  前回締次更新対象となった年月日)</param>
		/// <param name="stockSlipCount">仕入伝票枚数</param>
		/// <param name="closeFlg">締済みフラグ(0:未処理,1:締済み)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="addUpSecName">計上拠点名称</param>
		/// <returns>SuplierPayInfGetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuplierPayInfGetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public SuplierPayInfGet(string enterpriseCode, string addUpSecCode, Int32 payeeCode, string payeeName, string payeeName2, string payeeSnm, string resultsSectCd, Int32 supplierCd, string supplierNm1, string supplierNm2, string supplierSnm, DateTime addUpDate, DateTime addUpYearMonth, Int64 lastTimePayment, Int64 stockTtl2TmBfBlPay, Int64 stockTtl3TmBfBlPay, Int64 thisTimePayNrml, Int64 thisTimeTtlBlcPay, Int64 ofsThisTimeStock, Int64 ofsThisStockTax, Int64 thisStckPricRgds, Int64 thisStcPrcTaxRgds, Int64 thisStckPricDis, Int64 thisStcPrcTaxDis, Int64 thisStckPricRgdsDis, Int64 taxAdjust, Int64 balanceAdjust, Int64 stockTotalPayBalance, DateTime cAddUpUpdExecDate, DateTime startCAddUpUpdDate, DateTime lastCAddUpUpdDate, Int32 stockSlipCount, Int32 closeFlg, string enterpriseName, string addUpSecName)
		{
			this._enterpriseCode = enterpriseCode;
			this._addUpSecCode = addUpSecCode;
			this._payeeCode = payeeCode;
			this._payeeName = payeeName;
			this._payeeName2 = payeeName2;
			this._payeeSnm = payeeSnm;
			this._resultsSectCd = resultsSectCd;
			this._supplierCd = supplierCd;
			this._supplierNm1 = supplierNm1;
			this._supplierNm2 = supplierNm2;
			this._supplierSnm = supplierSnm;
			this.AddUpDate = addUpDate;
			this.AddUpYearMonth = addUpYearMonth;
			this._lastTimePayment = lastTimePayment;
			this._stockTtl2TmBfBlPay = stockTtl2TmBfBlPay;
			this._stockTtl3TmBfBlPay = stockTtl3TmBfBlPay;
			this._thisTimePayNrml = thisTimePayNrml;
			this._thisTimeTtlBlcPay = thisTimeTtlBlcPay;
			this._ofsThisTimeStock = ofsThisTimeStock;
			this._ofsThisStockTax = ofsThisStockTax;
			this._thisStckPricRgds = thisStckPricRgds;
			this._thisStcPrcTaxRgds = thisStcPrcTaxRgds;
			this._thisStckPricDis = thisStckPricDis;
            this._thisStckPricRgdsDis = thisStckPricRgdsDis;
			this._thisStcPrcTaxDis = thisStcPrcTaxDis;
			this._taxAdjust = taxAdjust;
			this._balanceAdjust = balanceAdjust;
			this._stockTotalPayBalance = stockTotalPayBalance;
			this.CAddUpUpdExecDate = cAddUpUpdExecDate;
			this.StartCAddUpUpdDate = startCAddUpUpdDate;
			this.LastCAddUpUpdDate = lastCAddUpUpdDate;
			this._stockSlipCount = stockSlipCount;
			this._closeFlg = closeFlg;
			this._enterpriseName = enterpriseName;
			this._addUpSecName = addUpSecName;

		}

		/// <summary>
		/// 仕入先元帳（支払履歴）抽出結果ワーク複製処理
		/// </summary>
		/// <returns>SuplierPayInfGetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSuplierPayInfGetクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SuplierPayInfGet Clone()
		{
            return new SuplierPayInfGet(this._enterpriseCode, this._addUpSecCode, this._payeeCode, this._payeeName, this._payeeName2, this._payeeSnm, this._resultsSectCd, this._supplierCd, this._supplierNm1, this._supplierNm2, this._supplierSnm, this._addUpDate, this._addUpYearMonth, this._lastTimePayment, this._stockTtl2TmBfBlPay, this._stockTtl3TmBfBlPay, this._thisTimePayNrml, this._thisTimeTtlBlcPay, this._ofsThisTimeStock, this._ofsThisStockTax, this._thisStckPricRgds, this._thisStcPrcTaxRgds, this._thisStckPricDis, this._thisStckPricRgdsDis, this._thisStcPrcTaxDis, this._taxAdjust, this._balanceAdjust, this._stockTotalPayBalance, this._cAddUpUpdExecDate, this._startCAddUpUpdDate, this._lastCAddUpUpdDate, this._stockSlipCount, this._closeFlg, this._enterpriseName, this._addUpSecName);
		}

		/// <summary>
		/// 仕入先元帳（支払履歴）抽出結果ワーク比較処理
		/// </summary>
		/// <param name="target">比較対象のSuplierPayInfGetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuplierPayInfGetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SuplierPayInfGet target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.AddUpSecCode == target.AddUpSecCode)
				 && (this.PayeeCode == target.PayeeCode)
				 && (this.PayeeName == target.PayeeName)
				 && (this.PayeeName2 == target.PayeeName2)
				 && (this.PayeeSnm == target.PayeeSnm)
				 && (this.ResultsSectCd == target.ResultsSectCd)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.SupplierNm1 == target.SupplierNm1)
				 && (this.SupplierNm2 == target.SupplierNm2)
				 && (this.SupplierSnm == target.SupplierSnm)
				 && (this.AddUpDate == target.AddUpDate)
				 && (this.AddUpYearMonth == target.AddUpYearMonth)
				 && (this.LastTimePayment == target.LastTimePayment)
				 && (this.StockTtl2TmBfBlPay == target.StockTtl2TmBfBlPay)
				 && (this.StockTtl3TmBfBlPay == target.StockTtl3TmBfBlPay)
				 && (this.ThisTimePayNrml == target.ThisTimePayNrml)
				 && (this.ThisTimeTtlBlcPay == target.ThisTimeTtlBlcPay)
				 && (this.OfsThisTimeStock == target.OfsThisTimeStock)
				 && (this.OfsThisStockTax == target.OfsThisStockTax)
				 && (this.ThisStckPricRgds == target.ThisStckPricRgds)
				 && (this.ThisStcPrcTaxRgds == target.ThisStcPrcTaxRgds)
				 && (this.ThisStckPricDis == target.ThisStckPricDis)
				 && (this.ThisStcPrcTaxDis == target.ThisStcPrcTaxDis)
				 && (this.TaxAdjust == target.TaxAdjust)
				 && (this.BalanceAdjust == target.BalanceAdjust)
				 && (this.StockTotalPayBalance == target.StockTotalPayBalance)
				 && (this.CAddUpUpdExecDate == target.CAddUpUpdExecDate)
				 && (this.StartCAddUpUpdDate == target.StartCAddUpUpdDate)
				 && (this.LastCAddUpUpdDate == target.LastCAddUpUpdDate)
				 && (this.StockSlipCount == target.StockSlipCount)
				 && (this.CloseFlg == target.CloseFlg)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.AddUpSecName == target.AddUpSecName));
		}

		/// <summary>
		/// 仕入先元帳（支払履歴）抽出結果ワーク比較処理
		/// </summary>
		/// <param name="suplierPayInfGet1">
		///                    比較するSuplierPayInfGetクラスのインスタンス
		/// </param>
		/// <param name="suplierPayInfGet2">比較するSuplierPayInfGetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuplierPayInfGetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SuplierPayInfGet suplierPayInfGet1, SuplierPayInfGet suplierPayInfGet2)
		{
			return ((suplierPayInfGet1.EnterpriseCode == suplierPayInfGet2.EnterpriseCode)
				 && (suplierPayInfGet1.AddUpSecCode == suplierPayInfGet2.AddUpSecCode)
				 && (suplierPayInfGet1.PayeeCode == suplierPayInfGet2.PayeeCode)
				 && (suplierPayInfGet1.PayeeName == suplierPayInfGet2.PayeeName)
				 && (suplierPayInfGet1.PayeeName2 == suplierPayInfGet2.PayeeName2)
				 && (suplierPayInfGet1.PayeeSnm == suplierPayInfGet2.PayeeSnm)
				 && (suplierPayInfGet1.ResultsSectCd == suplierPayInfGet2.ResultsSectCd)
				 && (suplierPayInfGet1.SupplierCd == suplierPayInfGet2.SupplierCd)
				 && (suplierPayInfGet1.SupplierNm1 == suplierPayInfGet2.SupplierNm1)
				 && (suplierPayInfGet1.SupplierNm2 == suplierPayInfGet2.SupplierNm2)
				 && (suplierPayInfGet1.SupplierSnm == suplierPayInfGet2.SupplierSnm)
				 && (suplierPayInfGet1.AddUpDate == suplierPayInfGet2.AddUpDate)
				 && (suplierPayInfGet1.AddUpYearMonth == suplierPayInfGet2.AddUpYearMonth)
				 && (suplierPayInfGet1.LastTimePayment == suplierPayInfGet2.LastTimePayment)
				 && (suplierPayInfGet1.StockTtl2TmBfBlPay == suplierPayInfGet2.StockTtl2TmBfBlPay)
				 && (suplierPayInfGet1.StockTtl3TmBfBlPay == suplierPayInfGet2.StockTtl3TmBfBlPay)
				 && (suplierPayInfGet1.ThisTimePayNrml == suplierPayInfGet2.ThisTimePayNrml)
				 && (suplierPayInfGet1.ThisTimeTtlBlcPay == suplierPayInfGet2.ThisTimeTtlBlcPay)
				 && (suplierPayInfGet1.OfsThisTimeStock == suplierPayInfGet2.OfsThisTimeStock)
				 && (suplierPayInfGet1.OfsThisStockTax == suplierPayInfGet2.OfsThisStockTax)
				 && (suplierPayInfGet1.ThisStckPricRgds == suplierPayInfGet2.ThisStckPricRgds)
				 && (suplierPayInfGet1.ThisStcPrcTaxRgds == suplierPayInfGet2.ThisStcPrcTaxRgds)
				 && (suplierPayInfGet1.ThisStckPricDis == suplierPayInfGet2.ThisStckPricDis)
				 && (suplierPayInfGet1.ThisStcPrcTaxDis == suplierPayInfGet2.ThisStcPrcTaxDis)
				 && (suplierPayInfGet1.TaxAdjust == suplierPayInfGet2.TaxAdjust)
				 && (suplierPayInfGet1.BalanceAdjust == suplierPayInfGet2.BalanceAdjust)
				 && (suplierPayInfGet1.StockTotalPayBalance == suplierPayInfGet2.StockTotalPayBalance)
				 && (suplierPayInfGet1.CAddUpUpdExecDate == suplierPayInfGet2.CAddUpUpdExecDate)
				 && (suplierPayInfGet1.StartCAddUpUpdDate == suplierPayInfGet2.StartCAddUpUpdDate)
				 && (suplierPayInfGet1.LastCAddUpUpdDate == suplierPayInfGet2.LastCAddUpUpdDate)
				 && (suplierPayInfGet1.StockSlipCount == suplierPayInfGet2.StockSlipCount)
				 && (suplierPayInfGet1.CloseFlg == suplierPayInfGet2.CloseFlg)
				 && (suplierPayInfGet1.EnterpriseName == suplierPayInfGet2.EnterpriseName)
				 && (suplierPayInfGet1.AddUpSecName == suplierPayInfGet2.AddUpSecName));
		}
		/// <summary>
		/// 仕入先元帳（支払履歴）抽出結果ワーク比較処理
		/// </summary>
		/// <param name="target">比較対象のSuplierPayInfGetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuplierPayInfGetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SuplierPayInfGet target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.AddUpSecCode != target.AddUpSecCode)resList.Add("AddUpSecCode");
			if(this.PayeeCode != target.PayeeCode)resList.Add("PayeeCode");
			if(this.PayeeName != target.PayeeName)resList.Add("PayeeName");
			if(this.PayeeName2 != target.PayeeName2)resList.Add("PayeeName2");
			if(this.PayeeSnm != target.PayeeSnm)resList.Add("PayeeSnm");
			if(this.ResultsSectCd != target.ResultsSectCd)resList.Add("ResultsSectCd");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.SupplierNm1 != target.SupplierNm1)resList.Add("SupplierNm1");
			if(this.SupplierNm2 != target.SupplierNm2)resList.Add("SupplierNm2");
			if(this.SupplierSnm != target.SupplierSnm)resList.Add("SupplierSnm");
			if(this.AddUpDate != target.AddUpDate)resList.Add("AddUpDate");
			if(this.AddUpYearMonth != target.AddUpYearMonth)resList.Add("AddUpYearMonth");
			if(this.LastTimePayment != target.LastTimePayment)resList.Add("LastTimePayment");
			if(this.StockTtl2TmBfBlPay != target.StockTtl2TmBfBlPay)resList.Add("StockTtl2TmBfBlPay");
			if(this.StockTtl3TmBfBlPay != target.StockTtl3TmBfBlPay)resList.Add("StockTtl3TmBfBlPay");
			if(this.ThisTimePayNrml != target.ThisTimePayNrml)resList.Add("ThisTimePayNrml");
			if(this.ThisTimeTtlBlcPay != target.ThisTimeTtlBlcPay)resList.Add("ThisTimeTtlBlcPay");
			if(this.OfsThisTimeStock != target.OfsThisTimeStock)resList.Add("OfsThisTimeStock");
			if(this.OfsThisStockTax != target.OfsThisStockTax)resList.Add("OfsThisStockTax");
			if(this.ThisStckPricRgds != target.ThisStckPricRgds)resList.Add("ThisStckPricRgds");
			if(this.ThisStcPrcTaxRgds != target.ThisStcPrcTaxRgds)resList.Add("ThisStcPrcTaxRgds");
			if(this.ThisStckPricDis != target.ThisStckPricDis)resList.Add("ThisStckPricDis");
			if(this.ThisStcPrcTaxDis != target.ThisStcPrcTaxDis)resList.Add("ThisStcPrcTaxDis");
			if(this.TaxAdjust != target.TaxAdjust)resList.Add("TaxAdjust");
			if(this.BalanceAdjust != target.BalanceAdjust)resList.Add("BalanceAdjust");
			if(this.StockTotalPayBalance != target.StockTotalPayBalance)resList.Add("StockTotalPayBalance");
			if(this.CAddUpUpdExecDate != target.CAddUpUpdExecDate)resList.Add("CAddUpUpdExecDate");
			if(this.StartCAddUpUpdDate != target.StartCAddUpUpdDate)resList.Add("StartCAddUpUpdDate");
			if(this.LastCAddUpUpdDate != target.LastCAddUpUpdDate)resList.Add("LastCAddUpUpdDate");
			if(this.StockSlipCount != target.StockSlipCount)resList.Add("StockSlipCount");
			if(this.CloseFlg != target.CloseFlg)resList.Add("CloseFlg");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.AddUpSecName != target.AddUpSecName)resList.Add("AddUpSecName");

			return resList;
		}

		/// <summary>
		/// 仕入先元帳（支払履歴）抽出結果ワーク比較処理
		/// </summary>
		/// <param name="suplierPayInfGet1">比較するSuplierPayInfGetクラスのインスタンス</param>
		/// <param name="suplierPayInfGet2">比較するSuplierPayInfGetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuplierPayInfGetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SuplierPayInfGet suplierPayInfGet1, SuplierPayInfGet suplierPayInfGet2)
		{
			ArrayList resList = new ArrayList();
			if(suplierPayInfGet1.EnterpriseCode != suplierPayInfGet2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(suplierPayInfGet1.AddUpSecCode != suplierPayInfGet2.AddUpSecCode)resList.Add("AddUpSecCode");
			if(suplierPayInfGet1.PayeeCode != suplierPayInfGet2.PayeeCode)resList.Add("PayeeCode");
			if(suplierPayInfGet1.PayeeName != suplierPayInfGet2.PayeeName)resList.Add("PayeeName");
			if(suplierPayInfGet1.PayeeName2 != suplierPayInfGet2.PayeeName2)resList.Add("PayeeName2");
			if(suplierPayInfGet1.PayeeSnm != suplierPayInfGet2.PayeeSnm)resList.Add("PayeeSnm");
			if(suplierPayInfGet1.ResultsSectCd != suplierPayInfGet2.ResultsSectCd)resList.Add("ResultsSectCd");
			if(suplierPayInfGet1.SupplierCd != suplierPayInfGet2.SupplierCd)resList.Add("SupplierCd");
			if(suplierPayInfGet1.SupplierNm1 != suplierPayInfGet2.SupplierNm1)resList.Add("SupplierNm1");
			if(suplierPayInfGet1.SupplierNm2 != suplierPayInfGet2.SupplierNm2)resList.Add("SupplierNm2");
			if(suplierPayInfGet1.SupplierSnm != suplierPayInfGet2.SupplierSnm)resList.Add("SupplierSnm");
			if(suplierPayInfGet1.AddUpDate != suplierPayInfGet2.AddUpDate)resList.Add("AddUpDate");
			if(suplierPayInfGet1.AddUpYearMonth != suplierPayInfGet2.AddUpYearMonth)resList.Add("AddUpYearMonth");
			if(suplierPayInfGet1.LastTimePayment != suplierPayInfGet2.LastTimePayment)resList.Add("LastTimePayment");
			if(suplierPayInfGet1.StockTtl2TmBfBlPay != suplierPayInfGet2.StockTtl2TmBfBlPay)resList.Add("StockTtl2TmBfBlPay");
			if(suplierPayInfGet1.StockTtl3TmBfBlPay != suplierPayInfGet2.StockTtl3TmBfBlPay)resList.Add("StockTtl3TmBfBlPay");
			if(suplierPayInfGet1.ThisTimePayNrml != suplierPayInfGet2.ThisTimePayNrml)resList.Add("ThisTimePayNrml");
			if(suplierPayInfGet1.ThisTimeTtlBlcPay != suplierPayInfGet2.ThisTimeTtlBlcPay)resList.Add("ThisTimeTtlBlcPay");
			if(suplierPayInfGet1.OfsThisTimeStock != suplierPayInfGet2.OfsThisTimeStock)resList.Add("OfsThisTimeStock");
			if(suplierPayInfGet1.OfsThisStockTax != suplierPayInfGet2.OfsThisStockTax)resList.Add("OfsThisStockTax");
			if(suplierPayInfGet1.ThisStckPricRgds != suplierPayInfGet2.ThisStckPricRgds)resList.Add("ThisStckPricRgds");
			if(suplierPayInfGet1.ThisStcPrcTaxRgds != suplierPayInfGet2.ThisStcPrcTaxRgds)resList.Add("ThisStcPrcTaxRgds");
			if(suplierPayInfGet1.ThisStckPricDis != suplierPayInfGet2.ThisStckPricDis)resList.Add("ThisStckPricDis");
			if(suplierPayInfGet1.ThisStcPrcTaxDis != suplierPayInfGet2.ThisStcPrcTaxDis)resList.Add("ThisStcPrcTaxDis");
			if(suplierPayInfGet1.TaxAdjust != suplierPayInfGet2.TaxAdjust)resList.Add("TaxAdjust");
			if(suplierPayInfGet1.BalanceAdjust != suplierPayInfGet2.BalanceAdjust)resList.Add("BalanceAdjust");
			if(suplierPayInfGet1.StockTotalPayBalance != suplierPayInfGet2.StockTotalPayBalance)resList.Add("StockTotalPayBalance");
			if(suplierPayInfGet1.CAddUpUpdExecDate != suplierPayInfGet2.CAddUpUpdExecDate)resList.Add("CAddUpUpdExecDate");
			if(suplierPayInfGet1.StartCAddUpUpdDate != suplierPayInfGet2.StartCAddUpUpdDate)resList.Add("StartCAddUpUpdDate");
			if(suplierPayInfGet1.LastCAddUpUpdDate != suplierPayInfGet2.LastCAddUpUpdDate)resList.Add("LastCAddUpUpdDate");
			if(suplierPayInfGet1.StockSlipCount != suplierPayInfGet2.StockSlipCount)resList.Add("StockSlipCount");
			if(suplierPayInfGet1.CloseFlg != suplierPayInfGet2.CloseFlg)resList.Add("CloseFlg");
			if(suplierPayInfGet1.EnterpriseName != suplierPayInfGet2.EnterpriseName)resList.Add("EnterpriseName");
			if(suplierPayInfGet1.AddUpSecName != suplierPayInfGet2.AddUpSecName)resList.Add("AddUpSecName");

			return resList;
		}
	}
}
