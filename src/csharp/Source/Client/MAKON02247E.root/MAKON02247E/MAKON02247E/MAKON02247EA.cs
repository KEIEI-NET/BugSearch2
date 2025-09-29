//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入確認表
// プログラム概要   : 仕入確認表抽出条件クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2008/01/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 柴田 倫幸
// 修 正 日  2008/07/16  修正内容 : データ項目の追加/修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/14  修正内容 : 障害対応12394,12396,12401
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : cheq
// 修 正 日  2012/12/26  修正内容 : 2013/03/13配信分 Redmine#34098
//                                  罫線印字制御の追加対応
//----------------------------------------------------------------------------//
// 管理番号 11570208-00  作成担当 : 3H 尹安
// 修 正 日  2020/02/27  修正内容 : 軽減税率対応
//                                  税別内訳印字制御の追加対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_MAKON02247E
	/// <summary>
	///                      仕入確認表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入確認表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/01/16  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	     :   ・データ項目の追加/修正</br>
    /// <br>Programmer	     :   30415 柴田 倫幸</br>
    /// <br>Date		     :   2008/07/16</br>
    /// -----------------------------------------------------------------------------------	
    /// <br>UpdateNote	     :   ・障害対応12394,12396,12401</br>
    /// <br>Programmer	     :   30452 上野 俊治</br>
    /// <br>Date		     :   2009/04/14</br>
    /// -----------------------------------------------------------------------------------	
    /// <br>Update Note      :   2012/12/26 cheq</br>
    /// <br>管理番号         :   10806793-00 2013/03/13配信分</br>
    /// <br>                     Redmine#34098 罫線印字制御の追加対応</br>
    /// -----------------------------------------------------------------------------------	
    /// <br>Update Note      :  11570208-00 軽減税率対応</br>
    /// <br>Programmer       :  3H 尹安 </br>
    /// <br>Date		     :  2020/02/27</br>
    /// -----------------------------------------------------------------------------------	
    /// </remarks>
	public class ExtrInfo_MAKON02247E
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>全社選択</summary>
		/// <remarks>true:全社選択　false:各拠点選択</remarks>
		private Boolean _isSelectAllSection;

		/// <summary>全拠点レコード出力</summary>
		/// <remarks>true:全拠点レコードを出力する。false:全拠点レコードを出力しない</remarks>
		private Boolean _isOutputAllSecRec;

		/// <summary>仕入拠点コード</summary>
		/// <remarks>文字型　※配列項目</remarks>
		private string[] _stockSectionCd;

		/// <summary>仕入日(開始)</summary>
		/// <remarks>YYYYMMDD 未入力時は 0</remarks>
		private Int32 _stockDateSt;

		/// <summary>仕入日(終了)</summary>
		/// <remarks>YYYYMMDD 未入力時は 0</remarks>
		private Int32 _stockDateEd;

		/// <summary>入荷日(開始)</summary>
		/// <remarks>YYYYMMDD 未入力時は 0</remarks>
		private Int32 _arrivalGoodsDaySt;

		/// <summary>入荷日(終了)</summary>
		/// <remarks>YYYYMMDD 未入力時は 0</remarks>
		private Int32 _arrivalGoodsDayEd;

		/// <summary>入力日(開始)</summary>
		/// <remarks>YYYYMMDD 未入力時は 0</remarks>
		private Int32 _inputDaySt;

		/// <summary>入力日(終了)</summary>
		/// <remarks>YYYYMMDD 未入力時は 0</remarks>
		private Int32 _inputDayEd;

		/// <summary>発行タイプ</summary>
		/// <remarks>0:通常 1:訂正 2:削除 3:訂正+削除</remarks>
		private Int32 _printType;

		/// <summary>赤伝区分</summary>
		/// <remarks>-1:全て 0:黒伝 1:赤伝 2:元黒</remarks>
		private Int32 _debitNoteDiv;

		/// <summary>仕入形式</summary>
		/// <remarks>0:発注 1:仕入 2:仮仕入</remarks>
		private Int32 _supplierFormal;

		/// <summary>仕入伝票番号(開始)</summary>
		/// <remarks>発注伝票番号、仕入伝票番号、仮仕入伝票番号を兼ねる</remarks>
		private Int32 _supplierSlipNoSt;

		/// <summary>仕入伝票番号(終了)</summary>
		/// <remarks>発注伝票番号、仕入伝票番号、仮仕入伝票番号を兼ねる</remarks>
		private Int32 _supplierSlipNoEd;

		/// <summary>仕入担当者コード(開始)</summary>
		/// <remarks>未入力時は空文字("")</remarks>
		private string _stockAgentCodeSt = "";

		/// <summary>仕入担当者コード(終了)</summary>
		/// <remarks>未入力時は空文字("")</remarks>
		private string _stockAgentCodeEd = "";

		/// <summary>仕入伝票区分</summary>
		/// <remarks>0:全て 10:仕入 20:返品</remarks>
		private Int32 _supplierSlipCd;

		/// <summary>相手先伝票番号(開始)</summary>
		/// <remarks>未入力時は空文字("")</remarks>
		private string _partySaleSlipNumSt = "";

		/// <summary>相手先伝票番号(終了)</summary>
		/// <remarks>未入力時は空文字("")</remarks>
		private string _partySaleSlipNumEd = "";

        // --- DEL 2008/07/16 -------------------------------->>>>>
        ///// <summary>得意先コード(開始)</summary>
        //private Int32 _customerCodeSt;

        ///// <summary>得意先コード(終了)</summary>
        //private Int32 _customerCodeEd;
        // --- DEL 2008/07/16 --------------------------------<<<<< 

        // --- ADD 2008/07/16 -------------------------------->>>>>
        /// <summary>仕入先コード(開始)</summary>
        private Int32 _supplierCdSt;

        /// <summary>仕入先コード(終了)</summary>
        private Int32 _supplierCdEd;

        /// <summary>販売エリアコード(開始)</summary>
        private Int32 _salesAreaCodeSt;

        /// <summary>販売エリアコード(終了)</summary>
        private Int32 _salesAreaCodeEd;

        /// <summary>出力指定</summary>
        private Int32 _outputDesignated;

        /// <summary>仕入在庫取寄せ区分</summary>
        private Int32 _stockOrderDivCd;

        /// <summary>改頁区分</summary>
        private Int32 _newPageKind;
        // --- ADD 2008/07/16 --------------------------------<<<<< 

		/// <summary>出力順</summary>
		private Int32 _sortOrder;

		/// <summary>帳票タイプ識別</summary>
		private Int32 _printDiv;

		/// <summary>帳票タイプの識別名称</summary>
		private string _printDivName = "";

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>仕入計上拠点名称</summary>
		private string _stockAddUpSectionNm = "";

        // --- ADD 2009/04/14 -------------------------------->>>>>
        private Int32 _printDailyFooter;
        // --- ADD 2009/04/14 --------------------------------<<<<<

        //----- ADD 2012/12/26 cheq Redmine#34098 ----->>>>>
        /// <summary>罫線印字</summary>
        private Int32 _linePrintDiv;
        //----- ADD 2012/12/26 cheq Redmine#34098 -----<<<<<
        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
        /// <summary>税別内訳印字区分</summary>
        private Int32 _taxPrintDiv;

        /// <summary>XMLの税率１</summary>
        private string _taxRate1;

        /// <summary>XMLの税率１</summary>
        private string _taxRate2;

        /// public propaty name  :  TaxPrintDiv
        /// <summary>税別内訳印字区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税別内訳印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxPrintDiv
        {
            get { return _taxPrintDiv; }
            set { _taxPrintDiv = value; }
        }
        /// public propaty name  :  TaxRate1
        /// <summary>XMLの税率1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   XMLの税率1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TaxRate1
        {
            get { return _taxRate1; }
            set { _taxRate1 = value; }
        }

        /// public propaty name  :  TaxRate1
        /// <summary>XMLの税率２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   XMLの税率2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TaxRate2
        {
            get { return _taxRate2; }
            set { _taxRate2 = value; }
        }
        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<

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

		/// public propaty name  :  IsSelectAllSection
		/// <summary>全社選択プロパティ</summary>
		/// <value>true:全社選択　false:各拠点選択</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   全社選択プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean IsSelectAllSection
		{
			get { return _isSelectAllSection; }
			set { _isSelectAllSection = value; }
		}

		/// public propaty name  :  IsOutputAllSecRec
		/// <summary>全拠点レコード出力プロパティ</summary>
		/// <value>true:全拠点レコードを出力する。false:全拠点レコードを出力しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   全拠点レコード出力プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean IsOutputAllSecRec
		{
			get { return _isOutputAllSecRec; }
			set { _isOutputAllSecRec = value; }
		}

		/// public propaty name  :  StockSectionCd
		/// <summary>仕入拠点コードプロパティ</summary>
		/// <value>文字型　※配列項目</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] StockSectionCd
		{
			get { return _stockSectionCd; }
			set { _stockSectionCd = value; }
		}

		/// public propaty name  :  StockDateSt
		/// <summary>仕入日(開始)プロパティ</summary>
		/// <value>YYYYMMDD 未入力時は 0</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入日(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockDateSt
		{
			get { return _stockDateSt; }
			set { _stockDateSt = value; }
		}

		/// public propaty name  :  StockDateEd
		/// <summary>仕入日(終了)プロパティ</summary>
		/// <value>YYYYMMDD 未入力時は 0</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入日(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockDateEd
		{
			get { return _stockDateEd; }
			set { _stockDateEd = value; }
		}

		/// public propaty name  :  ArrivalGoodsDaySt
		/// <summary>入荷日(開始)プロパティ</summary>
		/// <value>YYYYMMDD 未入力時は 0</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入荷日(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ArrivalGoodsDaySt
		{
			get { return _arrivalGoodsDaySt; }
			set { _arrivalGoodsDaySt = value; }
		}

		/// public propaty name  :  ArrivalGoodsDayEd
		/// <summary>入荷日(終了)プロパティ</summary>
		/// <value>YYYYMMDD 未入力時は 0</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入荷日(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ArrivalGoodsDayEd
		{
			get { return _arrivalGoodsDayEd; }
			set { _arrivalGoodsDayEd = value; }
		}

		/// public propaty name  :  InputDaySt
		/// <summary>入力日(開始)プロパティ</summary>
		/// <value>YYYYMMDD 未入力時は 0</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InputDaySt
		{
			get { return _inputDaySt; }
			set { _inputDaySt = value; }
		}

		/// public propaty name  :  InputDayEd
		/// <summary>入力日(終了)プロパティ</summary>
		/// <value>YYYYMMDD 未入力時は 0</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InputDayEd
		{
			get { return _inputDayEd; }
			set { _inputDayEd = value; }
		}

		/// public propaty name  :  PrintType
		/// <summary>発行タイププロパティ</summary>
		/// <value>0:通常 1:訂正 2:削除 3:訂正+削除</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発行タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintType
		{
			get { return _printType; }
			set { _printType = value; }
		}

		/// public propaty name  :  DebitNoteDiv
		/// <summary>赤伝区分プロパティ</summary>
		/// <value>-1:全て 0:黒伝 1:赤伝 2:元黒</value>
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

		/// public propaty name  :  SupplierFormal
		/// <summary>仕入形式プロパティ</summary>
		/// <value>0:発注 1:仕入 2:仮仕入</value>
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

		/// public propaty name  :  SupplierSlipNoSt
		/// <summary>仕入伝票番号(開始)プロパティ</summary>
		/// <value>発注伝票番号、仕入伝票番号、仮仕入伝票番号を兼ねる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票番号(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierSlipNoSt
		{
			get { return _supplierSlipNoSt; }
			set { _supplierSlipNoSt = value; }
		}

		/// public propaty name  :  SupplierSlipNoEd
		/// <summary>仕入伝票番号(終了)プロパティ</summary>
		/// <value>発注伝票番号、仕入伝票番号、仮仕入伝票番号を兼ねる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票番号(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierSlipNoEd
		{
			get { return _supplierSlipNoEd; }
			set { _supplierSlipNoEd = value; }
		}

		/// public propaty name  :  StockAgentCodeSt
		/// <summary>仕入担当者コード(開始)プロパティ</summary>
		/// <value>未入力時は空文字("")</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入担当者コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAgentCodeSt
		{
			get { return _stockAgentCodeSt; }
			set { _stockAgentCodeSt = value; }
		}

		/// public propaty name  :  StockAgentCodeEd
		/// <summary>仕入担当者コード(終了)プロパティ</summary>
		/// <value>未入力時は空文字("")</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入担当者コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAgentCodeEd
		{
			get { return _stockAgentCodeEd; }
			set { _stockAgentCodeEd = value; }
		}

		/// public propaty name  :  SupplierSlipCd
		/// <summary>仕入伝票区分プロパティ</summary>
		/// <value>0:全て 10:仕入 20:返品</value>
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

		/// public propaty name  :  PartySaleSlipNumSt
		/// <summary>相手先伝票番号(開始)プロパティ</summary>
		/// <value>未入力時は空文字("")</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相手先伝票番号(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PartySaleSlipNumSt
		{
			get { return _partySaleSlipNumSt; }
			set { _partySaleSlipNumSt = value; }
		}

		/// public propaty name  :  PartySaleSlipNumEd
		/// <summary>相手先伝票番号(終了)プロパティ</summary>
		/// <value>未入力時は空文字("")</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相手先伝票番号(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PartySaleSlipNumEd
		{
			get { return _partySaleSlipNumEd; }
			set { _partySaleSlipNumEd = value; }
		}

        // --- DEL 2008/07/16 -------------------------------->>>>>
        ///// public propaty name  :  CustomerCodeSt
        ///// <summary>得意先コード(開始)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先コード(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustomerCodeSt
        //{
        //    get { return _customerCodeSt; }
        //    set { _customerCodeSt = value; }
        //}

        ///// public propaty name  :  CustomerCodeEd
        ///// <summary>得意先コード(終了)プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先コード(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustomerCodeEd
        //{
        //    get { return _customerCodeEd; }
        //    set { _customerCodeEd = value; }
        //}
        // --- DEL 2008/07/16 --------------------------------<<<<< 

        // --- ADD 2008/07/16 -------------------------------->>>>>
        /// public propaty name  :  SupplierCdSt
        /// <summary>仕入先コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード(開始)プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SupplierCdSt
        {
            get { return _supplierCdSt; }
            set { _supplierCdSt = value; }
        }

        /// public propaty name  :  SupplierCdEd
        /// <summary>仕入先コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード(終了)プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SupplierCdEd
        {
            get { return _supplierCdEd; }
            set { _supplierCdEd = value; }
        }

        /// public propaty name  :  SalesAreaCodeSt
        /// <summary>販売エリアコード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコード(開始)プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SalesAreaCodeSt
        {
            get { return _salesAreaCodeSt; }
            set { _salesAreaCodeSt = value; }
        }

        /// public propaty name  :  SalesAreaCodeEd
        /// <summary>販売エリアコード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコード(終了)プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SalesAreaCodeEd
        {
            get { return _salesAreaCodeEd; }
            set { _salesAreaCodeEd = value; }
        }

        /// public propaty name  :  OutputDesignated
        /// <summary>出力指定プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力指定プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 OutputDesignated
        {
            get { return _outputDesignated; }
            set { _outputDesignated = value; }
        }

        /// public propaty name  :  StockOrderDivCd
        /// <summary>仕入在庫取寄せ区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入在庫取寄せ区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 StockOrderDivCd
        {
            get { return _stockOrderDivCd; }
            set { _stockOrderDivCd = value; }
        }

        /// public propaty name  :  NewPageKind
        /// <summary>改頁区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 NewPageKind
        {
            get { return _newPageKind; }
            set { _newPageKind = value; }
        }
        // --- ADD 2008/07/16 --------------------------------<<<<< 

		/// public propaty name  :  SortOrder
		/// <summary>出力順プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力順プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SortOrder
		{
			get { return _sortOrder; }
			set { _sortOrder = value; }
		}

		/// public propaty name  :  PrintDiv
		/// <summary>帳票タイプ識別プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票タイプ識別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintDiv
		{
			get { return _printDiv; }
			set { _printDiv = value; }
		}

		/// public propaty name  :  PrintDivName
		/// <summary>帳票タイプの識別名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票タイプの識別名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrintDivName
		{
			get { return _printDivName; }
			set { _printDivName = value; }
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

		/// public propaty name  :  StockAddUpSectionNm
		/// <summary>仕入計上拠点名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入計上拠点名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAddUpSectionNm
		{
			get { return _stockAddUpSectionNm; }
			set { _stockAddUpSectionNm = value; }
		}

        // --- ADD 2009/04/14 -------------------------------->>>>>
        /// public propaty name  :  PrintDailyFooter
        /// <summary>日計印字プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   日計印字プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintDailyFooter
        {
            get { return _printDailyFooter; }
            set { _printDailyFooter = value; }
        }
        // --- ADD 2009/04/14 --------------------------------<<<<<

        //----- ADD 2012/12/26 cheq Redmine#34098 ----->>>>>
        /// public propaty name  :  LinePrintDiv
        /// <summary>罫線印字プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   罫線印字プロパティ</br>
        /// <br>Programer        :   cheq</br>
        /// <br>Date	         :   2012/12/26</br>
        /// </remarks>
        public Int32 LinePrintDiv
        {
            get { return _linePrintDiv; }
            set { _linePrintDiv = value; }
        }
        //----- ADD 2012/12/26 cheq Redmine#34098 -----<<<<<

		/// <summary>
		/// 仕入確認表抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_MAKON02247Eクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_MAKON02247Eクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_MAKON02247E()
		{
		}

		/// <summary>
		/// 仕入確認表抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="isSelectAllSection">全社選択(true:全社選択　false:各拠点選択)</param>
		/// <param name="isOutputAllSecRec">全拠点レコード出力(true:全拠点レコードを出力する。false:全拠点レコードを出力しない)</param>
		/// <param name="stockSectionCd">仕入拠点コード(文字型　※配列項目)</param>
		/// <param name="stockDateSt">仕入日(開始)(YYYYMMDD 未入力時は 0)</param>
		/// <param name="stockDateEd">仕入日(終了)(YYYYMMDD 未入力時は 0)</param>
		/// <param name="arrivalGoodsDaySt">入荷日(開始)(YYYYMMDD 未入力時は 0)</param>
		/// <param name="arrivalGoodsDayEd">入荷日(終了)(YYYYMMDD 未入力時は 0)</param>
		/// <param name="inputDaySt">入力日(開始)(YYYYMMDD 未入力時は 0)</param>
		/// <param name="inputDayEd">入力日(終了)(YYYYMMDD 未入力時は 0)</param>
		/// <param name="printType">発行タイプ(0:通常 1:訂正 2:削除 3:訂正+削除)</param>
		/// <param name="debitNoteDiv">赤伝区分(-1:全て 0:黒伝 1:赤伝 2:元黒)</param>
		/// <param name="supplierFormal">仕入形式(0:発注 1:仕入 2:仮仕入)</param>
		/// <param name="supplierSlipNoSt">仕入伝票番号(開始)(発注伝票番号、仕入伝票番号、仮仕入伝票番号を兼ねる)</param>
		/// <param name="supplierSlipNoEd">仕入伝票番号(終了)(発注伝票番号、仕入伝票番号、仮仕入伝票番号を兼ねる)</param>
		/// <param name="stockAgentCodeSt">仕入担当者コード(開始)(未入力時は空文字(""))</param>
		/// <param name="stockAgentCodeEd">仕入担当者コード(終了)(未入力時は空文字(""))</param>
		/// <param name="supplierSlipCd">仕入伝票区分(0:全て 10:仕入 20:返品)</param>
		/// <param name="partySaleSlipNumSt">相手先伝票番号(開始)(未入力時は空文字(""))</param>
		/// <param name="partySaleSlipNumEd">相手先伝票番号(終了)(未入力時は空文字(""))</param>
        /// <param name="customerCodeSt">仕入先コード(開始)</param>
        /// <param name="customerCodeEd">仕入先コード(終了)</param>
        /// <param name="SalesAreaCodeSt">販売エリアコード(開始)</param>
        /// <param name="SalesAreaCodeEd">販売エリアコード(終了)</param>		
        /// <param name="SalesAreaCodeSt">出力指定</param>
        /// <param name="SalesAreaCodeEd">仕入在庫取寄せ区分</param>	        
        /// <param name="sortOrder">出力順</param>
		/// <param name="printDiv">帳票タイプ識別</param>
		/// <param name="printDivName">帳票タイプの識別名称</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="stockAddUpSectionNm">仕入計上拠点名称</param>
        /// <param name="printDailyFooter">日計印字</param>
		/// <returns>ExtrInfo_MAKON02247Eクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_MAKON02247Eクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        //public ExtrInfo_MAKON02247E(string enterpriseCode, Boolean isSelectAllSection, Boolean isOutputAllSecRec, string[] stockSectionCd, Int32 stockDateSt, Int32 stockDateEd, Int32 arrivalGoodsDaySt, Int32 arrivalGoodsDayEd, Int32 inputDaySt, Int32 inputDayEd, Int32 printType, Int32 debitNoteDiv, Int32 supplierFormal, Int32 supplierSlipNoSt, Int32 supplierSlipNoEd, string stockAgentCodeSt, string stockAgentCodeEd, Int32 supplierSlipCd, string partySaleSlipNumSt, string partySaleSlipNumEd, Int32 customerCodeSt, Int32 customerCodeEd, Int32 sortOrder, Int32 printDiv, string printDivName, string enterpriseName, string stockAddUpSectionNm)  // DEL 2008/07/16
        //public ExtrInfo_MAKON02247E(string enterpriseCode, Boolean isSelectAllSection, Boolean isOutputAllSecRec, string[] stockSectionCd, Int32 stockDateSt, Int32 stockDateEd, Int32 arrivalGoodsDaySt, Int32 arrivalGoodsDayEd, Int32 inputDaySt, Int32 inputDayEd, Int32 printType, Int32 debitNoteDiv, Int32 supplierFormal, Int32 supplierSlipNoSt, Int32 supplierSlipNoEd, string stockAgentCodeSt, string stockAgentCodeEd, Int32 supplierSlipCd, string partySaleSlipNumSt, string partySaleSlipNumEd, Int32 supplierCdSt, Int32 supplierCdEd, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 outputDesignated, Int32 stockOrderDivCd, Int32 sortOrder, Int32 printDiv, string printDivName, string enterpriseName, string stockAddUpSectionNm) // ADD 2008/07/16 // DEL 2009/04/14
        public ExtrInfo_MAKON02247E(string enterpriseCode, Boolean isSelectAllSection, Boolean isOutputAllSecRec, string[] stockSectionCd, Int32 stockDateSt, Int32 stockDateEd, Int32 arrivalGoodsDaySt, Int32 arrivalGoodsDayEd, Int32 inputDaySt, Int32 inputDayEd, Int32 printType, Int32 debitNoteDiv, Int32 supplierFormal, Int32 supplierSlipNoSt, Int32 supplierSlipNoEd, string stockAgentCodeSt, string stockAgentCodeEd, Int32 supplierSlipCd, string partySaleSlipNumSt, string partySaleSlipNumEd, Int32 supplierCdSt, Int32 supplierCdEd, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 outputDesignated, Int32 stockOrderDivCd, Int32 sortOrder, Int32 printDiv, string printDivName, string enterpriseName, string stockAddUpSectionNm, Int32 printDailyFooter)  // ADD 2009/04/14
        {
			this._enterpriseCode = enterpriseCode;
			this._isSelectAllSection = isSelectAllSection;
			this._isOutputAllSecRec = isOutputAllSecRec;
			this._stockSectionCd = stockSectionCd;
			this._stockDateSt = stockDateSt;
			this._stockDateEd = stockDateEd;
			this._arrivalGoodsDaySt = arrivalGoodsDaySt;
			this._arrivalGoodsDayEd = arrivalGoodsDayEd;
			this._inputDaySt = inputDaySt;
			this._inputDayEd = inputDayEd;
			this._printType = printType;
			this._debitNoteDiv = debitNoteDiv;
			this._supplierFormal = supplierFormal;
			this._supplierSlipNoSt = supplierSlipNoSt;
			this._supplierSlipNoEd = supplierSlipNoEd;
			this._stockAgentCodeSt = stockAgentCodeSt;
			this._stockAgentCodeEd = stockAgentCodeEd;
			this._supplierSlipCd = supplierSlipCd;
			this._partySaleSlipNumSt = partySaleSlipNumSt;
			this._partySaleSlipNumEd = partySaleSlipNumEd;

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //this._customerCodeSt = customerCodeSt;
            //this._customerCodeEd = customerCodeEd;
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            this._supplierCdSt = supplierCdSt;          // 仕入先コード(開始)
            this._supplierCdEd = supplierCdEd;          // 仕入先コード(終了)
            this._salesAreaCodeSt = salesAreaCodeSt;    // 販売エリアコード(開始)
            this._salesAreaCodeEd = salesAreaCodeEd;    // 販売エリアコード(終了)
            this._outputDesignated = outputDesignated;  // 出力指定
            this._stockOrderDivCd = stockOrderDivCd;    // 仕入在庫取寄せ区分
            // --- ADD 2008/07/16 --------------------------------<<<<< 

			this._sortOrder = sortOrder;
			this._printDiv = printDiv;
			this._printDivName = printDivName;
			this._enterpriseName = enterpriseName;
			this._stockAddUpSectionNm = stockAddUpSectionNm;

            this._printDailyFooter = printDailyFooter; // ADD 2009/04/14
		}

		/// <summary>
		/// 仕入確認表抽出条件クラス複製処理
		/// </summary>
		/// <returns>ExtrInfo_MAKON02247Eクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいExtrInfo_MAKON02247Eクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_MAKON02247E Clone()
		{
			//return new ExtrInfo_MAKON02247E(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._stockSectionCd, this._stockDateSt, this._stockDateEd, this._arrivalGoodsDaySt, this._arrivalGoodsDayEd, this._inputDaySt, this._inputDayEd, this._printType, this._debitNoteDiv, this._supplierFormal, this._supplierSlipNoSt, this._supplierSlipNoEd, this._stockAgentCodeSt, this._stockAgentCodeEd, this._supplierSlipCd, this._partySaleSlipNumSt, this._partySaleSlipNumEd, this._customerCodeSt, this._customerCodeEd, this._sortOrder, this._printDiv, this._printDivName, this._enterpriseName, this._stockAddUpSectionNm);  // DEL 2008/07/16
            //return new ExtrInfo_MAKON02247E(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._stockSectionCd, this._stockDateSt, this._stockDateEd, this._arrivalGoodsDaySt, this._arrivalGoodsDayEd, this._inputDaySt, this._inputDayEd, this._printType, this._debitNoteDiv, this._supplierFormal, this._supplierSlipNoSt, this._supplierSlipNoEd, this._stockAgentCodeSt, this._stockAgentCodeEd, this._supplierSlipCd, this._partySaleSlipNumSt, this._partySaleSlipNumEd, this._supplierCdSt, this._supplierCdEd, this._salesAreaCodeSt, this._salesAreaCodeEd, this._outputDesignated, this._stockOrderDivCd, this._sortOrder, this._printDiv, this._printDivName, this._enterpriseName, this._stockAddUpSectionNm); // ADD 2008/07/16 // DEL 2009/04/14
            return new ExtrInfo_MAKON02247E(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._stockSectionCd, this._stockDateSt, this._stockDateEd, this._arrivalGoodsDaySt, this._arrivalGoodsDayEd, this._inputDaySt, this._inputDayEd, this._printType, this._debitNoteDiv, this._supplierFormal, this._supplierSlipNoSt, this._supplierSlipNoEd, this._stockAgentCodeSt, this._stockAgentCodeEd, this._supplierSlipCd, this._partySaleSlipNumSt, this._partySaleSlipNumEd, this._supplierCdSt, this._supplierCdEd, this._salesAreaCodeSt, this._salesAreaCodeEd, this._outputDesignated, this._stockOrderDivCd, this._sortOrder, this._printDiv, this._printDivName, this._enterpriseName, this._stockAddUpSectionNm, this._printDailyFooter); // ADD 2009/04/14
        }

		/// <summary>
		/// 仕入確認表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_MAKON02247Eクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_MAKON02247Eクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ExtrInfo_MAKON02247E target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.IsSelectAllSection == target.IsSelectAllSection)
				 && (this.IsOutputAllSecRec == target.IsOutputAllSecRec)
				 && (this.StockSectionCd == target.StockSectionCd)
				 && (this.StockDateSt == target.StockDateSt)
				 && (this.StockDateEd == target.StockDateEd)
				 && (this.ArrivalGoodsDaySt == target.ArrivalGoodsDaySt)
				 && (this.ArrivalGoodsDayEd == target.ArrivalGoodsDayEd)
				 && (this.InputDaySt == target.InputDaySt)
				 && (this.InputDayEd == target.InputDayEd)
				 && (this.PrintType == target.PrintType)
				 && (this.DebitNoteDiv == target.DebitNoteDiv)
				 && (this.SupplierFormal == target.SupplierFormal)
				 && (this.SupplierSlipNoSt == target.SupplierSlipNoSt)
				 && (this.SupplierSlipNoEd == target.SupplierSlipNoEd)
				 && (this.StockAgentCodeSt == target.StockAgentCodeSt)
				 && (this.StockAgentCodeEd == target.StockAgentCodeEd)
				 && (this.SupplierSlipCd == target.SupplierSlipCd)
				 && (this.PartySaleSlipNumSt == target.PartySaleSlipNumSt)
				 && (this.PartySaleSlipNumEd == target.PartySaleSlipNumEd)

                 // --- DEL 2008/07/16 -------------------------------->>>>>
                 //&& (this.CustomerCodeSt == target.CustomerCodeSt)
                 //&& (this.CustomerCodeEd == target.CustomerCodeEd)
                 // --- DEL 2008/07/16 --------------------------------<<<<< 

                 // --- ADD 2008/07/16 -------------------------------->>>>>
                 && (this.SupplierCdSt == target.SupplierCdSt)          // 仕入先コード(開始)
                 && (this.SupplierCdEd == target.SupplierCdEd)          // 仕入先コード(終了)
                 && (this.SalesAreaCodeSt == target.SalesAreaCodeSt)    // 販売エリアコード(開始)
                 && (this.SalesAreaCodeEd == target.SalesAreaCodeEd)    // 販売エリアコード(終了)
                 && (this.OutputDesignated == target.OutputDesignated)  // 出力指定
                 && (this.StockOrderDivCd == target.StockOrderDivCd)    // 仕入在庫取寄せ区分
                 // --- ADD 2008/07/16 --------------------------------<<<<< 

				 && (this.SortOrder == target.SortOrder)
				 && (this.PrintDiv == target.PrintDiv)
				 && (this.PrintDivName == target.PrintDivName)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.StockAddUpSectionNm == target.StockAddUpSectionNm)
                 && (this.PrintDailyFooter == target.PrintDailyFooter) // ADD 2009/04/14
                 );
		}

		/// <summary>
		/// 仕入確認表抽出条件クラス比較処理
		/// </summary>
		/// <param name="extrInfo_MAKON02247E1">
		///                    比較するExtrInfo_MAKON02247Eクラスのインスタンス
		/// </param>
		/// <param name="extrInfo_MAKON02247E2">比較するExtrInfo_MAKON02247Eクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_MAKON02247Eクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ExtrInfo_MAKON02247E extrInfo_MAKON02247E1, ExtrInfo_MAKON02247E extrInfo_MAKON02247E2)
		{
			return ((extrInfo_MAKON02247E1.EnterpriseCode == extrInfo_MAKON02247E2.EnterpriseCode)
				 && (extrInfo_MAKON02247E1.IsSelectAllSection == extrInfo_MAKON02247E2.IsSelectAllSection)
				 && (extrInfo_MAKON02247E1.IsOutputAllSecRec == extrInfo_MAKON02247E2.IsOutputAllSecRec)
				 && (extrInfo_MAKON02247E1.StockSectionCd == extrInfo_MAKON02247E2.StockSectionCd)
				 && (extrInfo_MAKON02247E1.StockDateSt == extrInfo_MAKON02247E2.StockDateSt)
				 && (extrInfo_MAKON02247E1.StockDateEd == extrInfo_MAKON02247E2.StockDateEd)
				 && (extrInfo_MAKON02247E1.ArrivalGoodsDaySt == extrInfo_MAKON02247E2.ArrivalGoodsDaySt)
				 && (extrInfo_MAKON02247E1.ArrivalGoodsDayEd == extrInfo_MAKON02247E2.ArrivalGoodsDayEd)
				 && (extrInfo_MAKON02247E1.InputDaySt == extrInfo_MAKON02247E2.InputDaySt)
				 && (extrInfo_MAKON02247E1.InputDayEd == extrInfo_MAKON02247E2.InputDayEd)
				 && (extrInfo_MAKON02247E1.PrintType == extrInfo_MAKON02247E2.PrintType)
				 && (extrInfo_MAKON02247E1.DebitNoteDiv == extrInfo_MAKON02247E2.DebitNoteDiv)
				 && (extrInfo_MAKON02247E1.SupplierFormal == extrInfo_MAKON02247E2.SupplierFormal)
				 && (extrInfo_MAKON02247E1.SupplierSlipNoSt == extrInfo_MAKON02247E2.SupplierSlipNoSt)
				 && (extrInfo_MAKON02247E1.SupplierSlipNoEd == extrInfo_MAKON02247E2.SupplierSlipNoEd)
				 && (extrInfo_MAKON02247E1.StockAgentCodeSt == extrInfo_MAKON02247E2.StockAgentCodeSt)
				 && (extrInfo_MAKON02247E1.StockAgentCodeEd == extrInfo_MAKON02247E2.StockAgentCodeEd)
				 && (extrInfo_MAKON02247E1.SupplierSlipCd == extrInfo_MAKON02247E2.SupplierSlipCd)
				 && (extrInfo_MAKON02247E1.PartySaleSlipNumSt == extrInfo_MAKON02247E2.PartySaleSlipNumSt)
				 && (extrInfo_MAKON02247E1.PartySaleSlipNumEd == extrInfo_MAKON02247E2.PartySaleSlipNumEd)

                 // --- DEL 2008/07/16 -------------------------------->>>>>
                 //&& (extrInfo_MAKON02247E1.CustomerCodeSt == extrInfo_MAKON02247E2.CustomerCodeSt)
                 //&& (extrInfo_MAKON02247E1.CustomerCodeEd == extrInfo_MAKON02247E2.CustomerCodeEd)
                // --- DEL 2008/07/16 --------------------------------<<<<< 

                // --- ADD 2008/07/16 -------------------------------->>>>>
                 && (extrInfo_MAKON02247E1.SupplierCdSt == extrInfo_MAKON02247E2.SupplierCdSt)          // 仕入先コード(開始)
                 && (extrInfo_MAKON02247E1.SupplierCdEd == extrInfo_MAKON02247E2.SupplierCdEd)          // 仕入先コード(終了) 
                 && (extrInfo_MAKON02247E1.SalesAreaCodeSt == extrInfo_MAKON02247E2.SalesAreaCodeSt)    // 販売エリアコード(開始)
                 && (extrInfo_MAKON02247E1.SalesAreaCodeEd == extrInfo_MAKON02247E2.SalesAreaCodeEd)    // 販売エリアコード(終了)
                 && (extrInfo_MAKON02247E1.OutputDesignated == extrInfo_MAKON02247E2.OutputDesignated)  // 出力指定
                 && (extrInfo_MAKON02247E1.StockOrderDivCd == extrInfo_MAKON02247E2.StockOrderDivCd)    // 仕入在庫取寄せ区分 
                // --- ADD 2008/07/16 --------------------------------<<<<< 

				 && (extrInfo_MAKON02247E1.SortOrder == extrInfo_MAKON02247E2.SortOrder)
				 && (extrInfo_MAKON02247E1.PrintDiv == extrInfo_MAKON02247E2.PrintDiv)
				 && (extrInfo_MAKON02247E1.PrintDivName == extrInfo_MAKON02247E2.PrintDivName)
				 && (extrInfo_MAKON02247E1.EnterpriseName == extrInfo_MAKON02247E2.EnterpriseName)
				 && (extrInfo_MAKON02247E1.StockAddUpSectionNm == extrInfo_MAKON02247E2.StockAddUpSectionNm)
                 && (extrInfo_MAKON02247E1.PrintDailyFooter == extrInfo_MAKON02247E2.PrintDailyFooter) // ADD 2009/04/14
                 );
		}
		/// <summary>
		/// 仕入確認表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_MAKON02247Eクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_MAKON02247Eクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ExtrInfo_MAKON02247E target)
		{
			ArrayList resList = new ArrayList();
			if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
			if (this.IsSelectAllSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
			if (this.IsOutputAllSecRec != target.IsOutputAllSecRec) resList.Add("IsOutputAllSecRec");
			if (this.StockSectionCd != target.StockSectionCd) resList.Add("StockSectionCd");
			if (this.StockDateSt != target.StockDateSt) resList.Add("StockDateSt");
			if (this.StockDateEd != target.StockDateEd) resList.Add("StockDateEd");
			if (this.ArrivalGoodsDaySt != target.ArrivalGoodsDaySt) resList.Add("ArrivalGoodsDaySt");
			if (this.ArrivalGoodsDayEd != target.ArrivalGoodsDayEd) resList.Add("ArrivalGoodsDayEd");
			if (this.InputDaySt != target.InputDaySt) resList.Add("InputDaySt");
			if (this.InputDayEd != target.InputDayEd) resList.Add("InputDayEd");
			if (this.PrintType != target.PrintType) resList.Add("PrintType");
			if (this.DebitNoteDiv != target.DebitNoteDiv) resList.Add("DebitNoteDiv");
			if (this.SupplierFormal != target.SupplierFormal) resList.Add("SupplierFormal");
			if (this.SupplierSlipNoSt != target.SupplierSlipNoSt) resList.Add("SupplierSlipNoSt");
			if (this.SupplierSlipNoEd != target.SupplierSlipNoEd) resList.Add("SupplierSlipNoEd");
			if (this.StockAgentCodeSt != target.StockAgentCodeSt) resList.Add("StockAgentCodeSt");
			if (this.StockAgentCodeEd != target.StockAgentCodeEd) resList.Add("StockAgentCodeEd");
			if (this.SupplierSlipCd != target.SupplierSlipCd) resList.Add("SupplierSlipCd");
			if (this.PartySaleSlipNumSt != target.PartySaleSlipNumSt) resList.Add("PartySaleSlipNumSt");
			if (this.PartySaleSlipNumEd != target.PartySaleSlipNumEd) resList.Add("PartySaleSlipNumEd");

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //if (this.CustomerCodeSt != target.CustomerCodeSt) resList.Add("CustomerCodeSt");
            //if (this.CustomerCodeEd != target.CustomerCodeEd) resList.Add("CustomerCodeEd");
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            if (this.SupplierCdSt != target.SupplierCdSt) resList.Add("SupplierCdSt");
            if (this.SupplierCdEd != target.SupplierCdEd) resList.Add("SupplierCdEd");
            if (this.SalesAreaCodeSt != target.SalesAreaCodeSt) resList.Add("SalesAreaCodeSt");
            if (this.SalesAreaCodeEd != target.SalesAreaCodeEd) resList.Add("SalesAreaCodeEd");
            if (this.OutputDesignated != target.OutputDesignated) resList.Add("OutputDesignated");
            if (this.StockOrderDivCd != target.StockOrderDivCd) resList.Add("StockOrderDivCd");
            // --- ADD 2008/07/16 --------------------------------<<<<< 

			if (this.SortOrder != target.SortOrder) resList.Add("SortOrder");
			if (this.PrintDiv != target.PrintDiv) resList.Add("PrintDiv");
			if (this.PrintDivName != target.PrintDivName) resList.Add("PrintDivName");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
			if (this.StockAddUpSectionNm != target.StockAddUpSectionNm) resList.Add("StockAddUpSectionNm");

            if (this.PrintDailyFooter != target.PrintDailyFooter) resList.Add("PrintDailyFooter"); // ADD 2009/04/14

			return resList;
		}

		/// <summary>
		/// 仕入確認表抽出条件クラス比較処理
		/// </summary>
		/// <param name="extrInfo_MAKON02247E1">比較するExtrInfo_MAKON02247Eクラスのインスタンス</param>
		/// <param name="extrInfo_MAKON02247E2">比較するExtrInfo_MAKON02247Eクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_MAKON02247Eクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ExtrInfo_MAKON02247E extrInfo_MAKON02247E1, ExtrInfo_MAKON02247E extrInfo_MAKON02247E2)
		{
			ArrayList resList = new ArrayList();
			if (extrInfo_MAKON02247E1.EnterpriseCode != extrInfo_MAKON02247E2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (extrInfo_MAKON02247E1.IsSelectAllSection != extrInfo_MAKON02247E2.IsSelectAllSection) resList.Add("IsSelectAllSection");
			if (extrInfo_MAKON02247E1.IsOutputAllSecRec != extrInfo_MAKON02247E2.IsOutputAllSecRec) resList.Add("IsOutputAllSecRec");
			if (extrInfo_MAKON02247E1.StockSectionCd != extrInfo_MAKON02247E2.StockSectionCd) resList.Add("StockSectionCd");
			if (extrInfo_MAKON02247E1.StockDateSt != extrInfo_MAKON02247E2.StockDateSt) resList.Add("StockDateSt");
			if (extrInfo_MAKON02247E1.StockDateEd != extrInfo_MAKON02247E2.StockDateEd) resList.Add("StockDateEd");
			if (extrInfo_MAKON02247E1.ArrivalGoodsDaySt != extrInfo_MAKON02247E2.ArrivalGoodsDaySt) resList.Add("ArrivalGoodsDaySt");
			if (extrInfo_MAKON02247E1.ArrivalGoodsDayEd != extrInfo_MAKON02247E2.ArrivalGoodsDayEd) resList.Add("ArrivalGoodsDayEd");
			if (extrInfo_MAKON02247E1.InputDaySt != extrInfo_MAKON02247E2.InputDaySt) resList.Add("InputDaySt");
			if (extrInfo_MAKON02247E1.InputDayEd != extrInfo_MAKON02247E2.InputDayEd) resList.Add("InputDayEd");
			if (extrInfo_MAKON02247E1.PrintType != extrInfo_MAKON02247E2.PrintType) resList.Add("PrintType");
			if (extrInfo_MAKON02247E1.DebitNoteDiv != extrInfo_MAKON02247E2.DebitNoteDiv) resList.Add("DebitNoteDiv");
			if (extrInfo_MAKON02247E1.SupplierFormal != extrInfo_MAKON02247E2.SupplierFormal) resList.Add("SupplierFormal");
			if (extrInfo_MAKON02247E1.SupplierSlipNoSt != extrInfo_MAKON02247E2.SupplierSlipNoSt) resList.Add("SupplierSlipNoSt");
			if (extrInfo_MAKON02247E1.SupplierSlipNoEd != extrInfo_MAKON02247E2.SupplierSlipNoEd) resList.Add("SupplierSlipNoEd");
			if (extrInfo_MAKON02247E1.StockAgentCodeSt != extrInfo_MAKON02247E2.StockAgentCodeSt) resList.Add("StockAgentCodeSt");
			if (extrInfo_MAKON02247E1.StockAgentCodeEd != extrInfo_MAKON02247E2.StockAgentCodeEd) resList.Add("StockAgentCodeEd");
			if (extrInfo_MAKON02247E1.SupplierSlipCd != extrInfo_MAKON02247E2.SupplierSlipCd) resList.Add("SupplierSlipCd");
			if (extrInfo_MAKON02247E1.PartySaleSlipNumSt != extrInfo_MAKON02247E2.PartySaleSlipNumSt) resList.Add("PartySaleSlipNumSt");
			if (extrInfo_MAKON02247E1.PartySaleSlipNumEd != extrInfo_MAKON02247E2.PartySaleSlipNumEd) resList.Add("PartySaleSlipNumEd");

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //if (extrInfo_MAKON02247E1.CustomerCodeSt != extrInfo_MAKON02247E2.CustomerCodeSt) resList.Add("CustomerCodeSt");
            //if (extrInfo_MAKON02247E1.CustomerCodeEd != extrInfo_MAKON02247E2.CustomerCodeEd) resList.Add("CustomerCodeEd");
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            if (extrInfo_MAKON02247E1.SupplierCdSt != extrInfo_MAKON02247E2.SupplierCdSt) resList.Add("SupplierCdSt");
            if (extrInfo_MAKON02247E1.SupplierCdEd != extrInfo_MAKON02247E2.SupplierCdEd) resList.Add("SupplierCdEd");
            if (extrInfo_MAKON02247E1.SalesAreaCodeSt != extrInfo_MAKON02247E2.SalesAreaCodeSt) resList.Add("SalesAreaCodeSt");
            if (extrInfo_MAKON02247E1.SalesAreaCodeEd != extrInfo_MAKON02247E2.SalesAreaCodeEd) resList.Add("SalesAreaCodeEd");
            if (extrInfo_MAKON02247E1.OutputDesignated != extrInfo_MAKON02247E2.OutputDesignated) resList.Add("OutputDesignated");
            if (extrInfo_MAKON02247E1.StockOrderDivCd != extrInfo_MAKON02247E2.StockOrderDivCd) resList.Add("StockOrderDivCd");
            // --- ADD 2008/07/16 --------------------------------<<<<< 
            
            if (extrInfo_MAKON02247E1.SortOrder != extrInfo_MAKON02247E2.SortOrder) resList.Add("SortOrder");
			if (extrInfo_MAKON02247E1.PrintDiv != extrInfo_MAKON02247E2.PrintDiv) resList.Add("PrintDiv");
			if (extrInfo_MAKON02247E1.PrintDivName != extrInfo_MAKON02247E2.PrintDivName) resList.Add("PrintDivName");
			if (extrInfo_MAKON02247E1.EnterpriseName != extrInfo_MAKON02247E2.EnterpriseName) resList.Add("EnterpriseName");
			if (extrInfo_MAKON02247E1.StockAddUpSectionNm != extrInfo_MAKON02247E2.StockAddUpSectionNm) resList.Add("StockAddUpSectionNm");

            if (extrInfo_MAKON02247E1.PrintDailyFooter != extrInfo_MAKON02247E2.PrintDailyFooter) resList.Add("PrintDailyFooter"); // ADD 2009/04/14

			return resList;
		}
	}
}
