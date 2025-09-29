//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 入荷一覧表
// プログラム概要   : 入荷一覧表抽出情報クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2007/10/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 柴田 倫幸
// 修 正 日  2008/06/25  修正内容 : 仕様変更に伴う変更。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/08  修正内容 : 障害対応9803、11150、11153、12398
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_DCKOU02304E
	/// <summary>
	///                      入荷一覧表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   入荷一覧表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/10/18  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/01/28　(仕様変更による追加記述)</br>
    /// -----------------------------------------------------------------------------------------------------
    /// <br>UpdateNote	     : 仕様変更に伴う変更。</br>
    /// <br>Programmer	     : 30415 柴田 倫幸</br>
    /// <br>Date		     : 2008/06/25</br>
    /// -----------------------------------------------------------------------------------------------------
    /// <br>UpdateNote	     : 障害対応9803、11150、11153、12398</br>
    /// <br>Programmer	     : 30452 上野 俊治</br>
    /// <br>Date		     : 2009/04/08</br>
	/// </remarks>
	public class ExtrInfo_DCKOU02304E
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定は{""}</remarks>
		private string[] _sectionCodes ;

        /* --- DEL 2008/06/25 -------------------------------->>>>>
		/// <summary>開始得意先コード</summary>
		private Int32 _customerCodeSt;

		/// <summary>終了得意先コード</summary>
		private Int32 _customerCodeEd;
           --- DEL 2008/06/25 --------------------------------<<<<< */

        // --- ADD 2008/06/25 -------------------------------->>>>>
        /// <summary>開始仕入先コード</summary>
        private Int32 _supplierCdSt;

        /// <summary>終了仕入先コード</summary>
        private Int32 _supplierCdEd;
        // --- ADD 2008/06/25 --------------------------------<<<<< 

        /* --- DEL 2008/06/25 -------------------------------->>>>>
		/// <summary>開始仕入入力者コード</summary>
		private string _stockInputCodeSt = "";

		/// <summary>終了仕入入力者コード</summary>
		private string _stockInputCodeEd = "";
           --- DEL 2008/06/25 --------------------------------<<<<< */

		/// <summary>開始仕入担当者コード</summary>
		private string _stockAgentCodeSt = "";

		/// <summary>終了仕入担当者コード</summary>
		private string _stockAgentCodeEd = "";

		/// <summary>開始仕入伝票番号</summary>
        private Int32 _supplierSlipNoSt;

		/// <summary>終了仕入伝票番号</summary>
        private Int32 _supplierSlipNoEd;

		/// <summary>開始仕入日付</summary>
		/// <remarks>YYYYMMDD (未入力は0)</remarks>
		private Int32 _stockDateSt;

		/// <summary>終了仕入日付</summary>
		/// <remarks>YYYYMMDD (未入力は0)</remarks>
		private Int32 _stockDateEd;

		/// <summary>開始入荷日付</summary>
		/// <remarks>YYYYMMDD (未入力は0)</remarks>
		private Int32 _arrivalGoodsDaySt;

		/// <summary>終了入荷日付</summary>
		/// <remarks>YYYYMMDD (未入力は0)</remarks>
		private Int32 _arrivalGoodsDayEd;

		/// <summary>開始入力日付</summary>
		/// <remarks>YYYYMMDD (未入力は0)</remarks>
		private Int32 _inputDaySt;

		/// <summary>終了入力日付</summary>
		/// <remarks>YYYYMMDD (未入力は0)</remarks>
		private Int32 _inputDayEd;

		/// <summary>作表区分</summary>
		/// <remarks>0:全て印刷,1:残のみ</remarks>
		private Int32 _makeShowDiv;

		/// <summary>作表区分名称</summary>
		private string _makeShowDivName = "";

		/// <summary>伝票区分</summary>
		/// <remarks>0:入荷,1:返品,2:入荷＋返品</remarks>
		private Int32 _slipDiv;

		/// <summary>伝票区分名称</summary>
		private string _slipDivName = "";

		/// <summary>出力順</summary>
		/// <remarks>0:仕入先→入荷日→伝票番号、1:入荷日→仕入先→伝票番号、2:担当者→仕入先→入荷日→伝票番号、3:入荷日→伝票番号、4:伝票番号</remarks>
		private Int32 _sortOrder;

		/// <summary>赤伝区分</summary>
		/// <remarks>0:黒伝,1:赤伝,2:元黒,3:全て</remarks>
		private Int32 _debitNoteDiv;

		/// <summary>赤伝区分名称</summary>
		private string _debitNoteDivName = "";

        // --- ADD 2009/03/27 -------------------------------->>>>>
        /// <summary>改頁</summary>
        /// <remarks>0:拠点,1:仕入先,2:しない</remarks>
        private Int32 _newPageDiv;

        /// <summary>日計印字</summary>
        /// <remarks>0:する,1:しない</remarks>
        private Int32 _printDailyFooter;

        /// <summary>開始伝票番号(相手先伝票番号)</summary>
        private string _partySalesSlipNumSt;

        /// <summary>終了伝票番号(相手先伝票番号)</summary>
        private string _partySalesSlipNumEd;


        // --- ADD 2009/03/27 --------------------------------<<<<<

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
			get { return _sectionCodes; }
			set { _sectionCodes = value; }
		}

        /* --- DEL 2008/06/25 -------------------------------->>>>>
		/// public propaty name  :  CustomerCodeSt
		/// <summary>開始得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCodeSt
		{
			get { return _customerCodeSt; }
			set { _customerCodeSt = value; }
		}

		/// public propaty name  :  CustomerCodeEd
		/// <summary>終了得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCodeEd
		{
			get { return _customerCodeEd; }
			set { _customerCodeEd = value; }
		}
           --- DEL 2008/06/25 --------------------------------<<<<< */

        // --- ADD 2008/06/25 -------------------------------->>>>>
        /// public propaty name  :  CustomerCodeSt
        /// <summary>開始仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入先コードプロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SupplierCdSt
        {
            get { return _supplierCdSt; }
            set { _supplierCdSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>終了仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入先コードプロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SupplierCdEd
        {
            get { return _supplierCdEd; }
            set { _supplierCdEd = value; }
        }
        // --- ADD 2008/06/25 --------------------------------<<<<< 

        /* --- DEL 2008/06/25 -------------------------------->>>>>
		/// public propaty name  :  StockInputCodeSt
		/// <summary>開始仕入入力者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入入力者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockInputCodeSt
		{
			get { return _stockInputCodeSt; }
			set { _stockInputCodeSt = value; }
		}

		/// public propaty name  :  StockInputCodeEd
		/// <summary>終了仕入入力者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入入力者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockInputCodeEd
		{
			get { return _stockInputCodeEd; }
			set { _stockInputCodeEd = value; }
		}
           --- DEL 2008/06/25 --------------------------------<<<<< */

		/// public propaty name  :  StockAgentCodeSt
		/// <summary>開始仕入担当者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入担当者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAgentCodeSt
		{
			get { return _stockAgentCodeSt; }
			set { _stockAgentCodeSt = value; }
		}

		/// public propaty name  :  StockAgentCodeEd
		/// <summary>終了仕入担当者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入担当者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAgentCodeEd
		{
			get { return _stockAgentCodeEd; }
			set { _stockAgentCodeEd = value; }
		}

		/// public propaty name  :  SupplierSlipNoSt
		/// <summary>開始仕入伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 SupplierSlipNoSt
		{
			get { return _supplierSlipNoSt; }
			set { _supplierSlipNoSt = value; }
		}

		/// public propaty name  :  SupplierSlipNoEd
		/// <summary>終了仕入伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 SupplierSlipNoEd
		{
			get { return _supplierSlipNoEd; }
			set { _supplierSlipNoEd = value; }
		}

		/// public propaty name  :  StockDateSt
		/// <summary>開始仕入日付プロパティ</summary>
		/// <value>YYYYMMDD (未入力は0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockDateSt
		{
			get { return _stockDateSt; }
			set { _stockDateSt = value; }
		}

		/// public propaty name  :  StockDateEd
		/// <summary>終了仕入日付プロパティ</summary>
		/// <value>YYYYMMDD (未入力は0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockDateEd
		{
			get { return _stockDateEd; }
			set { _stockDateEd = value; }
		}

		/// public propaty name  :  ArrivalGoodsDaySt
		/// <summary>開始入荷日付プロパティ</summary>
		/// <value>YYYYMMDD (未入力は0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入荷日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ArrivalGoodsDaySt
		{
			get { return _arrivalGoodsDaySt; }
			set { _arrivalGoodsDaySt = value; }
		}

		/// public propaty name  :  ArrivalGoodsDayEd
		/// <summary>終了入荷日付プロパティ</summary>
		/// <value>YYYYMMDD (未入力は0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入荷日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ArrivalGoodsDayEd
		{
			get { return _arrivalGoodsDayEd; }
			set { _arrivalGoodsDayEd = value; }
		}

		/// public propaty name  :  InputDaySt
		/// <summary>開始入力日付プロパティ</summary>
		/// <value>YYYYMMDD (未入力は0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InputDaySt
		{
			get { return _inputDaySt; }
			set { _inputDaySt = value; }
		}

		/// public propaty name  :  InputDayEd
		/// <summary>終了入力日付プロパティ</summary>
		/// <value>YYYYMMDD (未入力は0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InputDayEd
		{
			get { return _inputDayEd; }
			set { _inputDayEd = value; }
		}

		/// public propaty name  :  MakeShowDiv
		/// <summary>作表区分プロパティ</summary>
		/// <value>0:全て印刷,1:残のみ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作表区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MakeShowDiv
		{
			get { return _makeShowDiv; }
			set { _makeShowDiv = value; }
		}

		/// public propaty name  :  MakeShowDivName
		/// <summary>作表区分名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作表区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MakeShowDivName
		{
			get { return _makeShowDivName; }
			set { _makeShowDivName = value; }
		}

		/// public propaty name  :  SlipDiv
		/// <summary>伝票区分プロパティ</summary>
		/// <value>0:入荷,1:返品,2:入荷＋返品</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipDiv
		{
			get { return _slipDiv; }
			set { _slipDiv = value; }
		}

		/// public propaty name  :  SlipDivName
		/// <summary>伝票区分名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipDivName
		{
			get { return _slipDivName; }
			set { _slipDivName = value; }
		}

		/// public propaty name  :  SortOrder
		/// <summary>出力順プロパティ</summary>
		/// <value>0:仕入先→入荷日→伝票番号、1:入荷日→仕入先→伝票番号、2:担当者→仕入先→入荷日→伝票番号、3:入荷日→伝票番号、4:伝票番号</value>
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

		/// public propaty name  :  DebitNoteDiv
		/// <summary>赤伝区分プロパティ</summary>
		/// <value>0:黒伝,1:赤伝,2:元黒,3:全て</value>
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

		/// public propaty name  :  SlipDivName
		/// <summary>赤伝区分名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   赤伝区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DebitNoteDivName
		{
			get { return _debitNoteDivName; }
			set { _debitNoteDivName = value; }
		}

        // --- ADD 2009/03/27 -------------------------------->>>>>
        /// public propaty name  :  NewPageDiv
        /// <summary>改頁区分プロパティ</summary>
        /// <value>0:拠点,1:仕入先,2:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NewPageDiv
        {
            get { return _newPageDiv; }
            set { _newPageDiv = value; }
        }

        /// public propaty name  :  PrintDailyFooter
        /// <summary>日計印字プロパティ</summary>
        /// <value>0:する,1:しない</value>
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

        /// public propaty name  :  PartySalesSlipNumSt
        /// <summary>開始伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySalesSlipNumSt
        {
            get { return _partySalesSlipNumSt; }
            set { _partySalesSlipNumSt = value; }
        }

        /// public propaty name  :  PartySalesSlipNumEd
        /// <summary>終了伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySalesSlipNumEd
        {
            get { return _partySalesSlipNumEd; }
            set { _partySalesSlipNumEd = value; }
        }
        // --- ADD 2009/03/27 --------------------------------<<<<<

		/// <summary>
		/// 入荷一覧表抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>ArrivalListParamWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ArrivalListParamWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_DCKOU02304E()
		{
		}

		/// <summary>
		/// 入荷一覧表抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCodes">拠点コード((配列))</param>
        /* --- DEL 2008/06/25 -------------------------------->>>>>
        /// <param name="customerCodeSt">開始得意先コード</param>
        /// <param name="customerCodeEd">終了得意先コード</param>
           --- DEL 2008/06/25 --------------------------------<<<<< */
        // --- ADD 2008/06/25 -------------------------------->>>>>
        /// <param name="supplierCdSt">開始仕入先コード</param>
        /// <param name="supplierCdEd">終了仕入先コード</param>
        // --- ADD 2008/06/25 --------------------------------<<<<< 
        /// <param name="stockInputCodeSt">開始仕入入力者コード</param>
		/// <param name="stockInputCodeEd">終了仕入入力者コード</param>
		/// <param name="stockAgentCodeSt">開始仕入担当者コード</param>
		/// <param name="stockAgentCodeEd">終了仕入担当者コード</param>
		/// <param name="supplierSlipNoSt">開始仕入伝票番号</param>
		/// <param name="supplierSlipNoEd">終了仕入伝票番号</param>
		/// <param name="stockDateSt">開始仕入日付(YYYYMMDD)</param>
		/// <param name="stockDateEd">終了仕入日付(YYYYMMDD)</param>
		/// <param name="arrivalGoodsDaySt">開始入荷日付(YYYYMMDD)</param>
		/// <param name="arrivalGoodsDayEd">終了入荷日付(YYYYMMDD)</param>
		/// <param name="inputDaySt">開始入力日付</param>
		/// <param name="inputDayEd">終了入力日付</param>
		/// <param name="makeShowDiv">作表区分(0:全て印刷,1:残のみ)</param>
		/// <param name="slipDiv">伝票区分(0:入荷,1:返品,2:入荷＋返品)</param>
		/// <param name="sortOrder">出力順(0:仕入先→入荷日→伝票番号、1:入荷日→仕入先→伝票番号、2:担当者→仕入先→入荷日→伝票番号、3:入荷日→伝票番号、4:伝票番号)</param>
		/// <param name="debitNoteDiv">赤伝区分(0:黒伝, 1:赤伝, 2:元黒, 3:全て)</param>
		/// <param name="debitNoteDivName">赤伝区分名称</param>
        /// <param name="newPageDiv">改頁区分</param>
        /// <param name="printDailyFooter">日計印字区分</param>
        /// <param name="partySalesSlipNumSt">開始相手先伝票番号</param>
        /// <param name="partySalesSlipNumEd">終了相手先伝票番号</param>
		/// <returns>ArrivalListParamWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipmentListCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		//public ExtrInfo_DCKOU02304E(string enterpriseCode, string[] sectionCodes, Int32 customerCodeSt, Int32 customerCodeEd, string stockInputCodeSt, string stockInputCodeEd, string stockAgentCodeSt, string stockAgentCodeEd, string supplierSlipNoSt, string supplierSlipNoEd, Int32 stockDateSt, Int32 stockDateEd, Int32 arrivalGoodsDaySt, Int32 arrivalGoodsDayEd, Int32 makeShowDiv, Int32 inputDaySt, Int32 inputDayEd, Int32 slipDiv, Int32 sortOrder, Int32 debitNoteDiv, string debitNoteDivName)  // DEL 2008/06/25
        //public ExtrInfo_DCKOU02304E(string enterpriseCode, string[] sectionCodes, string stockAgentCodeSt, string stockAgentCodeEd, Int32 supplierSlipNoSt, Int32 supplierSlipNoEd, Int32 stockDateSt, Int32 stockDateEd, Int32 arrivalGoodsDaySt, Int32 arrivalGoodsDayEd, Int32 makeShowDiv, Int32 inputDaySt, Int32 inputDayEd, Int32 slipDiv, Int32 sortOrder, Int32 debitNoteDiv, string debitNoteDivName) // DEL 2009/03/27
        public ExtrInfo_DCKOU02304E(string enterpriseCode, string[] sectionCodes, string stockAgentCodeSt, string stockAgentCodeEd, Int32 supplierSlipNoSt, Int32 supplierSlipNoEd, Int32 stockDateSt, Int32 stockDateEd, Int32 arrivalGoodsDaySt, Int32 arrivalGoodsDayEd, Int32 makeShowDiv, Int32 inputDaySt, Int32 inputDayEd, Int32 slipDiv, Int32 sortOrder, Int32 debitNoteDiv, string debitNoteDivName, Int32 newPageDiv, Int32 printDailyFooter, string partySalesSlipNumSt, string partySalesSlipNumEd) // ADD 2009/03/27
        {
			this._enterpriseCode = enterpriseCode;
			this._sectionCodes = sectionCodes;
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			this._customerCodeSt = customerCodeSt;
			this._customerCodeEd = customerCodeEd;
               --- DEL 2008/06/25 --------------------------------<<<<< */
            // --- ADD 2008/06/25 -------------------------------->>>>>
            this._supplierCdSt = SupplierCdSt;
            this._supplierCdEd = SupplierCdEd;
            // --- ADD 2008/06/25 --------------------------------<<<<< 
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			this._stockInputCodeSt = stockInputCodeSt;
			this._stockInputCodeEd = stockInputCodeEd;
               --- DEL 2008/06/25 --------------------------------<<<<< */
			this._stockAgentCodeSt = stockAgentCodeSt;
			this._stockAgentCodeEd = stockAgentCodeEd;
			this._supplierSlipNoSt = supplierSlipNoSt;
			this._supplierSlipNoEd = supplierSlipNoEd;
			this._stockDateSt = stockDateSt;
			this._stockDateEd = stockDateEd;
			this._arrivalGoodsDaySt = arrivalGoodsDaySt;
			this._arrivalGoodsDayEd = arrivalGoodsDayEd;
			this._inputDaySt = inputDaySt;
			this._inputDayEd = inputDayEd;
			this._slipDiv = slipDiv;
			this._makeShowDiv = makeShowDiv;
			this._sortOrder = sortOrder;
			this._debitNoteDiv = debitNoteDiv;
			this._debitNoteDivName = debitNoteDivName;
            // --- ADD 2009/03/27 -------------------------------->>>>>
            this._newPageDiv = newPageDiv;
            this._printDailyFooter = printDailyFooter;
            this._partySalesSlipNumSt = partySalesSlipNumSt;
            this._partySalesSlipNumEd = partySalesSlipNumEd;
            // --- ADD 2009/03/27 --------------------------------<<<<<
		}

		/// <summary>
		/// 入荷一覧表抽出条件クラス複製処理
		/// </summary>
		/// <returns>ShipmentListCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいShipmentListCndtnクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_DCKOU02304E Clone()
		{
			//return new ExtrInfo_DCKOU02304E(this._enterpriseCode, this._sectionCodes, this._customerCodeSt, this._customerCodeEd, this._stockInputCodeSt, this._stockInputCodeEd, this._stockAgentCodeSt, this._stockAgentCodeEd, this._supplierSlipNoSt, this._supplierSlipNoEd, this._stockDateSt, this._stockDateEd, this._arrivalGoodsDaySt, this._arrivalGoodsDayEd, this._makeShowDiv, this._slipDiv, this._inputDaySt, this._inputDayEd, this._sortOrder, this._debitNoteDiv, this._debitNoteDivName);  // DEL 2008/06/25
            //return new ExtrInfo_DCKOU02304E(this._enterpriseCode, this._sectionCodes, this._stockAgentCodeSt, this._stockAgentCodeEd, this._supplierSlipNoSt, this._supplierSlipNoEd, this._stockDateSt, this._stockDateEd, this._arrivalGoodsDaySt, this._arrivalGoodsDayEd, this._makeShowDiv, this._slipDiv, this._inputDaySt, this._inputDayEd, this._sortOrder, this._debitNoteDiv, this._debitNoteDivName);  // ADD 2008/06/25 // DEL 2009/03/27
            return new ExtrInfo_DCKOU02304E(this._enterpriseCode, this._sectionCodes, this._stockAgentCodeSt, this._stockAgentCodeEd, this._supplierSlipNoSt, this._supplierSlipNoEd, this._stockDateSt, this._stockDateEd, this._arrivalGoodsDaySt, this._arrivalGoodsDayEd, this._makeShowDiv, this._slipDiv, this._inputDaySt, this._inputDayEd, this._sortOrder, this._debitNoteDiv, this._debitNoteDivName, this._newPageDiv, this._printDailyFooter, this._partySalesSlipNumSt, this._partySalesSlipNumEd); // ADD 2009/03/27
        }

		/// <summary>
		/// 入荷一覧表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のShipmentListCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipmentListCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ExtrInfo_DCKOU02304E target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCodes == target.SectionCodes)
                /* --- DEL 2008/06/25 -------------------------------->>>>>
                && (this.CustomerCodeSt == target.CustomerCodeSt)
                && (this.CustomerCodeEd == target.CustomerCodeEd)
                   --- DEL 2008/06/25 --------------------------------<<<<< */
                 // --- ADD 2008/06/25 -------------------------------->>>>>
                 && (this.SupplierCdSt == target.SupplierCdSt)
                 && (this.SupplierCdEd == target.SupplierCdEd)
                 // --- ADD 2008/06/25 --------------------------------<<<<< 
                /* --- DEL 2008/06/25 -------------------------------->>>>>
                && (this.StockInputCodeSt == target.StockInputCodeSt)
                && (this.StockInputCodeEd == target.StockInputCodeEd)
                   --- DEL 2008/06/25 --------------------------------<<<<< */
				 && (this.StockAgentCodeSt == target.StockAgentCodeSt)
				 && (this.StockAgentCodeEd == target.StockAgentCodeEd)
				 && (this.SupplierSlipNoSt == target.SupplierSlipNoSt)
				 && (this.SupplierSlipNoEd == target.SupplierSlipNoEd)
				 && (this.StockDateSt == target.StockDateSt)
				 && (this.StockDateEd == target.StockDateEd)
				 && (this.ArrivalGoodsDaySt == target.ArrivalGoodsDaySt)
				 && (this.ArrivalGoodsDayEd == target.ArrivalGoodsDayEd)
				 && (this.InputDaySt == target.InputDaySt)
				 && (this.InputDayEd == target.InputDayEd)
				 && (this.MakeShowDiv == target.MakeShowDiv)
				 && (this.SlipDiv == target.SlipDiv)
				 && (this.SortOrder == target.SortOrder)
				 && (this.DebitNoteDiv == target.DebitNoteDiv)
				 && (this.DebitNoteDivName == target.DebitNoteDivName)
                // --- ADD 2009/03/27 -------------------------------->>>>>
                && (this.NewPageDiv == target.NewPageDiv)
                && (this.PrintDailyFooter == target.PrintDailyFooter)
                && (this.PartySalesSlipNumSt == target.PartySalesSlipNumSt)
                && (this.PartySalesSlipNumEd == target.PartySalesSlipNumEd)
                // --- ADD 2009/03/27 --------------------------------<<<<<
				 );
		}

		/// <summary>
		/// 入荷一覧表抽出条件クラス比較処理
		/// </summary>
		/// <param name="shipmentListCndtn1">
		///                    比較するShipmentListCndtnクラスのインスタンス
		/// </param>
		/// <param name="shipmentListCndtn2">比較するShipmentListCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipmentListCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ExtrInfo_DCKOU02304E shipmentListCndtn1, ExtrInfo_DCKOU02304E shipmentListCndtn2)
		{
			return ((shipmentListCndtn1.EnterpriseCode == shipmentListCndtn2.EnterpriseCode)
				 && (shipmentListCndtn1.SectionCodes == shipmentListCndtn2.SectionCodes)
                /* --- DEL 2008/06/25 -------------------------------->>>>>
                && (shipmentListCndtn1.CustomerCodeSt == shipmentListCndtn2.CustomerCodeSt)
                && (shipmentListCndtn1.CustomerCodeEd == shipmentListCndtn2.CustomerCodeEd)
                   --- DEL 2008/06/25 --------------------------------<<<<< */
                 // --- ADD 2008/06/25 -------------------------------->>>>>
                 && (shipmentListCndtn1.SupplierCdSt == shipmentListCndtn2.SupplierCdSt)
                 && (shipmentListCndtn1.SupplierCdEd == shipmentListCndtn2.SupplierCdEd)
                 // --- ADD 2008/06/25 --------------------------------<<<<< 
                /* --- DEL 2008/06/25 -------------------------------->>>>>
                && (shipmentListCndtn1.StockInputCodeSt == shipmentListCndtn2.StockInputCodeSt)
                && (shipmentListCndtn1.StockInputCodeEd == shipmentListCndtn2.StockInputCodeEd)
                   --- DEL 2008/06/25 --------------------------------<<<<< */
				 && (shipmentListCndtn1.StockAgentCodeSt == shipmentListCndtn2.StockAgentCodeSt)
				 && (shipmentListCndtn1.StockAgentCodeEd == shipmentListCndtn2.StockAgentCodeEd)
				 && (shipmentListCndtn1.StockDateSt == shipmentListCndtn2.StockDateSt)
				 && (shipmentListCndtn1.StockDateEd == shipmentListCndtn2.StockDateEd)
				 && (shipmentListCndtn1.ArrivalGoodsDaySt == shipmentListCndtn2.ArrivalGoodsDaySt)
				 && (shipmentListCndtn1.ArrivalGoodsDayEd == shipmentListCndtn2.ArrivalGoodsDayEd)
				 && (shipmentListCndtn1.InputDaySt == shipmentListCndtn2.InputDaySt)
				 && (shipmentListCndtn1.InputDayEd == shipmentListCndtn2.InputDayEd)
				 && (shipmentListCndtn1.MakeShowDiv == shipmentListCndtn2.MakeShowDiv)
				 && (shipmentListCndtn1.SlipDiv == shipmentListCndtn2.SlipDiv)
				 && (shipmentListCndtn1.SortOrder == shipmentListCndtn2.SortOrder)
				 && (shipmentListCndtn1.DebitNoteDiv == shipmentListCndtn2.DebitNoteDiv)
				 && (shipmentListCndtn1.DebitNoteDivName == shipmentListCndtn2.DebitNoteDivName)
                // --- ADD 2009/03/27 -------------------------------->>>>>
                && (shipmentListCndtn1.NewPageDiv == shipmentListCndtn2.NewPageDiv)
                && (shipmentListCndtn1.PrintDailyFooter == shipmentListCndtn2.PrintDailyFooter)
                && (shipmentListCndtn1.PartySalesSlipNumSt == shipmentListCndtn2.PartySalesSlipNumSt)
                && (shipmentListCndtn1.PartySalesSlipNumEd == shipmentListCndtn2.PartySalesSlipNumEd)
                // --- ADD 2009/03/27 --------------------------------<<<<<
				 );
		
		}
		/// <summary>
		/// 入荷一覧表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のShipmentListCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipmentListCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ExtrInfo_DCKOU02304E target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCodes != target.SectionCodes)resList.Add("SectionCodes");
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			if(this.CustomerCodeSt != target.CustomerCodeSt)resList.Add("CustomerCodeSt");
			if(this.CustomerCodeEd != target.CustomerCodeEd)resList.Add("CustomerCodeEd");
               --- DEL 2008/06/25 --------------------------------<<<<< */
            // --- ADD 2008/06/25 -------------------------------->>>>>
            if (this.SupplierCdSt != target.SupplierCdSt) resList.Add("SupplierCdSt");
            if (this.SupplierCdEd != target.SupplierCdEd) resList.Add("SupplierCdEd");
            // --- ADD 2008/06/25 --------------------------------<<<<< 
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			if(this.StockInputCodeSt != target.StockInputCodeSt)resList.Add("StockInputCodeSt");
			if(this.StockInputCodeEd != target.StockInputCodeEd)resList.Add("StockInputCodeEd");
               --- DEL 2008/06/25 --------------------------------<<<<< */
			if(this.StockAgentCodeSt != target.StockAgentCodeSt)resList.Add("StockAgentCodeSt");
			if(this.StockAgentCodeEd != target.StockAgentCodeEd)resList.Add("StockAgentCodeEd");
			if(this.StockDateSt != target.StockDateSt)resList.Add("StockDateSt");
			if(this.StockDateEd != target.StockDateEd)resList.Add("StockDateEd");
			if(this.ArrivalGoodsDaySt != target.ArrivalGoodsDaySt)resList.Add("ArrivalGoodsDaySt");
			if(this.ArrivalGoodsDayEd != target.ArrivalGoodsDayEd)resList.Add("ArrivalGoodsDayEd");
			if (this.InputDaySt != target.InputDaySt) resList.Add("InputDaySt");
			if (this.InputDayEd != target.InputDayEd) resList.Add("InputDayEd");
			if (this.MakeShowDiv != target.MakeShowDiv) resList.Add("MakeShowDiv");
			if(this.SlipDiv != target.SlipDiv)resList.Add("SlipDiv");
			if(this.SortOrder != target.SortOrder)resList.Add("SortOrder");
			if (this.DebitNoteDiv != target.DebitNoteDiv) resList.Add("DebitNoteDiv");
			if (this.DebitNoteDiv != target.DebitNoteDiv) resList.Add("DebitNoteDivName");
            // --- ADD 2009/03/27 -------------------------------->>>>>
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");
            if (this.PrintDailyFooter != target.PrintDailyFooter) resList.Add("PrintDailyFooter");
            if (this.PartySalesSlipNumSt != target.PartySalesSlipNumSt) resList.Add("PartySalesSlipNumSt");
            if (this.PartySalesSlipNumEd != target.PartySalesSlipNumEd) resList.Add("PartySalesSlipNumEd");
            // --- ADD 2009/03/27 --------------------------------<<<<<

			return resList;
		}

		/// <summary>
		/// 入荷一覧表抽出条件クラス比較処理
		/// </summary>
		/// <param name="shipmentListCndtn1">比較するShipmentListCndtnクラスのインスタンス</param>
		/// <param name="shipmentListCndtn2">比較するShipmentListCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipmentListCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ExtrInfo_DCKOU02304E shipmentListCndtn1, ExtrInfo_DCKOU02304E shipmentListCndtn2)
		{
			ArrayList resList = new ArrayList();
			if(shipmentListCndtn1.EnterpriseCode != shipmentListCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(shipmentListCndtn1.SectionCodes != shipmentListCndtn2.SectionCodes)resList.Add("SectionCodes");
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			if(shipmentListCndtn1.CustomerCodeSt != shipmentListCndtn2.CustomerCodeSt)resList.Add("CustomerCodeSt");
			if(shipmentListCndtn1.CustomerCodeEd != shipmentListCndtn2.CustomerCodeEd)resList.Add("CustomerCodeEd");
               --- DEL 2008/06/25 --------------------------------<<<<< */
            // --- ADD 2008/06/25 -------------------------------->>>>>
            if (shipmentListCndtn1.SupplierCdSt != shipmentListCndtn2.SupplierCdSt) resList.Add("SupplierCdSt");
            if (shipmentListCndtn1.SupplierCdEd != shipmentListCndtn2.SupplierCdEd) resList.Add("SupplierCdEd");
            // --- ADD 2008/06/25 --------------------------------<<<<< 
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			if(shipmentListCndtn1.StockInputCodeSt != shipmentListCndtn2.StockInputCodeSt)resList.Add("StockInputCodeSt");
			if(shipmentListCndtn1.StockInputCodeEd != shipmentListCndtn2.StockInputCodeEd)resList.Add("StockInputCodeEd");
               --- DEL 2008/06/25 --------------------------------<<<<< */
			if(shipmentListCndtn1.StockAgentCodeSt != shipmentListCndtn2.StockAgentCodeSt)resList.Add("StockAgentCodeSt");
			if(shipmentListCndtn1.StockAgentCodeEd != shipmentListCndtn2.StockAgentCodeEd)resList.Add("StockAgentCodeEd");
			if(shipmentListCndtn1.StockDateSt != shipmentListCndtn2.StockDateSt)resList.Add("StockDateSt");
			if(shipmentListCndtn1.StockDateEd != shipmentListCndtn2.StockDateEd)resList.Add("StockDateEd");
			if(shipmentListCndtn1.ArrivalGoodsDaySt != shipmentListCndtn2.ArrivalGoodsDaySt)resList.Add("ArrivalGoodsDaySt");
			if(shipmentListCndtn1.ArrivalGoodsDayEd != shipmentListCndtn2.ArrivalGoodsDayEd)resList.Add("ArrivalGoodsDayEd");
			if(shipmentListCndtn1.MakeShowDiv != shipmentListCndtn2.MakeShowDiv)resList.Add("MakeShowDiv");
			if(shipmentListCndtn1.SlipDiv != shipmentListCndtn2.SlipDiv)resList.Add("SlipDiv");
			if(shipmentListCndtn1.SortOrder != shipmentListCndtn2.SortOrder)resList.Add("SortOrder");
			if (shipmentListCndtn1.InputDaySt != shipmentListCndtn2.InputDaySt) resList.Add("InputDaySt");
			if (shipmentListCndtn1.InputDayEd != shipmentListCndtn2.InputDayEd) resList.Add("InputDayEd");
			if (shipmentListCndtn1.DebitNoteDiv != shipmentListCndtn2.DebitNoteDiv) resList.Add("DebitNoteDiv");
			if (shipmentListCndtn1.DebitNoteDiv != shipmentListCndtn2.DebitNoteDiv) resList.Add("DebitNoteDivName");
            // --- ADD 2009/03/27 -------------------------------->>>>>
            if (shipmentListCndtn1.NewPageDiv != shipmentListCndtn2.NewPageDiv) resList.Add("NewPageDiv");
            if (shipmentListCndtn1.PrintDailyFooter != shipmentListCndtn2.PrintDailyFooter) resList.Add("PrintDailyFooter");
            if (shipmentListCndtn1.PartySalesSlipNumSt != shipmentListCndtn2.PartySalesSlipNumSt) resList.Add("PartySalesSlipNumSt");
            if (shipmentListCndtn1.PartySalesSlipNumEd != shipmentListCndtn2.PartySalesSlipNumEd) resList.Add("PartySalesSlipNumEd");
            // --- ADD 2009/03/27 --------------------------------<<<<<

			return resList;
		}
	}
}
