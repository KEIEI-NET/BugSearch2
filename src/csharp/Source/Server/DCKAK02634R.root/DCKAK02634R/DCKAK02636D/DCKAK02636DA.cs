using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   AccPaymentListCndtnWork
	/// <summary>
	///                      買掛残高一覧表抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   買掛残高一覧表抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   仕入先総括対応に伴う対応</br>
    /// <br>Programmer       :   30755 FSI菅原(庸)</br>
    /// <br>Date             :   2012/10/01</br>
    /// <br>UpdateNote       :   11570208-00 軽減税率対応</br>
    /// <br>Programmer       :   3H 劉星光</br>
    /// <br>Date	         :   2020/03/02</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class AccPaymentListCndtnWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定は{""}</remarks>
		private string[] _sectionCodes;

		/// <summary>計上年月日</summary>
		/// <remarks>YYYYMMDD ※処理月を締める日付。</remarks>
		private DateTime _addUpDate;

		/// <summary>対象年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonth;

		/// <summary>開始支払先コード</summary>
		private Int32 _st_PayeeCode;

		/// <summary>終了支払先コード</summary>
		private Int32 _ed_PayeeCode;

		/// <summary>出力金額区分</summary>
		/// <remarks>0:全て 1:0とﾌﾟﾗｽ 2:ﾌﾟﾗｽのみ 3:0のみ 4:0以外 5:0とﾏｲﾅｽ 6:ﾏｲﾅｽのみ</remarks>
		private Int32 _outMoneyDiv;

		/// <summary>支払内訳区分</summary>
		/// <remarks>0:印字する 1:印字しない</remarks>
		private Int32 _payDtlDiv;

        // --- ADD 2012/10/01 ---------->>>>>
		/// <summary>仕入先総括のオプションコード利用可否設定用</summary>
		/// <remarks>1:OFF 2:ON</remarks>
		private Int32 _optSuppEnable;

        /// <summary>拠点コード</summary>
        /// <remarks>計上拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>月次締更新履歴マスタ更新可否設定用</summary>
        /// <remarks>1:UPDATE 2:INSERT</remarks>
        private Int32 _monAddUpEnable;
        // --- ADD 2012/10/01 ----------<<<<<

        // --- ADD START 3H 劉星光 2020/03/02 ---------->>>>>
        /// <summary>税別内訳印字区分</summary>
        /// <remarks>0:印字する 1:印字しない</remarks>
        private Int32 _taxPrintDiv;

        /// <summary>税率1</summary>
        /// <remarks>税率1</remarks>
        private Double _taxRate1;

        /// <summary>税率2</summary>
        /// <remarks>税率2</remarks>
        private Double _taxRate2;
        // --- ADD END 3H 劉星光 2020/03/02 ----------<<<<<

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

		/// public propaty name  :  SectionCodes
		/// <summary>拠点コードプロパティ</summary>
		/// <value>(配列)　全社指定は{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  AddUpDate
		/// <summary>計上年月日プロパティ</summary>
		/// <value>YYYYMMDD ※処理月を締める日付。</value>
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
		/// <summary>対象年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   対象年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpYearMonth
		{
			get{return _addUpYearMonth;}
			set{_addUpYearMonth = value;}
		}

		/// public propaty name  :  St_PayeeCode
		/// <summary>開始支払先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始支払先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_PayeeCode
		{
			get{return _st_PayeeCode;}
			set{_st_PayeeCode = value;}
		}

		/// public propaty name  :  Ed_PayeeCode
		/// <summary>終了支払先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了支払先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_PayeeCode
		{
			get{return _ed_PayeeCode;}
			set{_ed_PayeeCode = value;}
		}

		/// public propaty name  :  OutMoneyDiv
		/// <summary>出力金額区分プロパティ</summary>
		/// <value>0:全て 1:0とﾌﾟﾗｽ 2:ﾌﾟﾗｽのみ 3:0のみ 4:0以外 5:0とﾏｲﾅｽ 6:ﾏｲﾅｽのみ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力金額区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OutMoneyDiv
		{
			get{return _outMoneyDiv;}
			set{_outMoneyDiv = value;}
		}

		/// public propaty name  :  PayDtlDiv
		/// <summary>支払内訳区分プロパティ</summary>
		/// <value>0:印字する 1:印字しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払内訳区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PayDtlDiv
		{
			get{return _payDtlDiv;}
			set{_payDtlDiv = value;}
		}

        // --- ADD 2012/10/01 ---------->>>>>
        /// public propaty name  :  OptSuppEnable
        /// <summary>仕入先総括のオプションコード利用可否設定用</summary>
        /// <value>1:OFF 2:ON</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先総括のオプションコード利用可否設定用</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OptSuppEnable
        {
            get { return _optSuppEnable; }
            set { _optSuppEnable = value; }
        }

        /// public propaty name  :  AddUpSecCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>計上拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  MonAddUpEnable
        /// <summary>月次締更新履歴マスタ更新可否設定用</summary>
        /// <value>1:UPDATE 2:INSERT</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月次締更新履歴マスタ更新可否設定用</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MonAddUpEnable
        {
            get { return _monAddUpEnable; }
            set { _monAddUpEnable = value; }
        }
        // --- ADD 2012/10/01 ----------<<<<<

        // --- ADD START 3H 劉星光 2020/03/02 ---------->>>>>
        /// <summary>税別内訳印字区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税別内訳印字区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxPrintDiv
        {
            get { return _taxPrintDiv; }
            set { _taxPrintDiv = value; }
        }

        /// public propaty name  :  TaxRate1
        /// <summary>税率1</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率1</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TaxRate1
        {
            get { return _taxRate1; }
            set { _taxRate1 = value; }
        }

        /// public propaty name  :  TaxRate2
        /// <summary>税率2</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率2</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TaxRate2
        {
            get { return _taxRate2; }
            set { _taxRate2 = value; }
        }
        // --- ADD END 3H 劉星光 2020/03/02 ----------<<<<<

		/// <summary>
		/// 買掛残高一覧表抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>AccPaymentListCndtnWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   AccPaymentListCndtnWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public AccPaymentListCndtnWork()
		{
		}

	}
}
