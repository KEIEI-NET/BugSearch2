//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売上確認表
// プログラム概要   : 売上確認表検索条件
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2008/07/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/13  修正内容 : 障害対応10247,11302,10743,11402
//----------------------------------------------------------------------------//
// 管理番号 10806793-00  作成担当 : 田建委
// 修 正 日  2013/01/04  修正内容 : 2013/03/13配信分 Redmine#34098
//                                  罫線印字制御の追加対応
//----------------------------------------------------------------------------//
// 管理番号 11570208-00  作成担当 : 3H 尹安
// 修 正 日  2020/02/27  修正内容 : 軽減税率対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_MAHNB02347E
	/// <summary>
	///                      売上確認表検索条件
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上確認表検索条件ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/07/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/04/13 30452 上野 俊治</br>
    /// <br>                     ・障害対応10247,11302,10743,11402</br>
    /// <br>Update Note      :   2013/01/04 田建委</br>
    /// <br>管理番号         :   10806793-00 2013/03/13配信分</br>
    /// <br>                     Redmine#34098 罫線印字制御の追加対応</br>
    /// <br>Update Note      :   2020/02/27 3H 尹安</br>
    /// <br>管理番号         :   11570208-00 軽減税率対応</br>
	/// </remarks>
	public class ExtrInfo_MAHNB02347E
	{

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>全社選択</summary>
		/// <remarks>true:全社選択 false:各拠点選択</remarks>
		private Boolean _isSelectAllSection;

		/// <summary>実績計上拠点コードリスト</summary>
		/// <remarks>文字型　※配列項目 全社指定は{""}</remarks>
		private string[] _resultsAddUpSecList;

		/// <summary>論理削除区分</summary>
		/// <remarks>0:有効,1:論理削除,2:保留,3:完全削除</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>売上日付(開始)</summary>
		private Int32 _salesDateSt;

		/// <summary>売上日付(終了)</summary>
		private Int32 _salesDateEd;

		/// <summary>伝票検索日付(開始)</summary>
		private Int32 _searchSlipDateSt;

		/// <summary>伝票検索日付(終了)</summary>
		private Int32 _searchSlipDateEd;

		/// <summary>出荷日付（開始）</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _shipmentDaySt;

		/// <summary>出荷日付（終了）</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _shipmentDayEd;

		/// <summary>得意先コード(開始)</summary>
		private Int32 _customerCodeSt;

		/// <summary>得意先コード(終了)</summary>
		private Int32 _customerCodeEd;

		/// <summary>仕入先コード(開始)</summary>
		private Int32 _supplierCdSt;

		/// <summary>仕入先コード(終了)</summary>
		private Int32 _supplierCdEd;

		/// <summary>赤伝区分</summary>
		/// <remarks>0:黒伝,1:赤伝,2:元黒　　※全ては-1</remarks>
		private Int32 _debitNoteDiv;

		/// <summary>売上伝票区分</summary>
		/// <remarks>0:売上,1:返品,2:返品＋行値引　※全ては-1</remarks>
		private Int32 _salesSlipCd;

		/// <summary>売上伝票番号(開始)</summary>
		private string _salesSlipNumSt = "";

		/// <summary>売上伝票番号(終了)</summary>
		private string _salesSlipNumEd = "";

		/// <summary>売上入力者コード(開始)</summary>
		/// <remarks>入力担当者（発行者）</remarks>
		private string _salesInputCodeSt = "";

		/// <summary>売上入力者コード(終了)</summary>
		/// <remarks>入力担当者（発行者）</remarks>
		private string _salesInputCodeEd = "";

		/// <summary>販売従業員コード(開始)</summary>
		/// <remarks>計上担当者（担当者）</remarks>
		private string _salesEmployeeCdSt = "";

		/// <summary>販売従業員コード(終了)</summary>
		/// <remarks>計上担当者（担当者）</remarks>
		private string _salesEmployeeCdEd = "";

		/// <summary>受付従業員コード（開始）</summary>
		/// <remarks>受付担当者（受注者）</remarks>
		private string _frontEmployeeCdSt = "";

		/// <summary>受付従業員コード（終了）</summary>
		/// <remarks>受付担当者（受注者）</remarks>
		private string _frontEmployeeCdEd = "";

		/// <summary>販売エリアコード(開始)</summary>
		/// <remarks>地区コード</remarks>
		private Int32 _salesAreaCodeSt;

		/// <summary>販売エリアコード(終了)</summary>
		/// <remarks>地区コード</remarks>
		private Int32 _salesAreaCodeEd;

		/// <summary>業種コード(開始)</summary>
		private Int32 _businessTypeCodeSt;

		/// <summary>業種コード(終了)</summary>
		private Int32 _businessTypeCodeEd;

		/// <summary>売上伝票更新区分</summary>
		/// <remarks>0:未更新,1:更新あり　※全ては-1</remarks>
		private Int32 _salesSlipUpdateCd;

		/// <summary>売上在庫取寄せ区分</summary>
		/// <remarks>0:取寄せ，1:在庫　　※全ては-1　注）売上確認表で注文方法＝「2:ｵﾝﾗｲﾝ発注」指定時は-1をセット</remarks>
		private Int32 _salesOrderDivCd;

		/// <summary>注文方法</summary>
		/// <remarks>0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録　※全ては-1</remarks>
		private Int32 _wayToOrder;

		/// <summary>粗利チェック下限</summary>
		/// <remarks>粗利チェックの下限値（％で入力）　XX.X％　以上</remarks>
		private Double _grsProfitCheckLower;

        /// <summary>粗利チェック2</summary>
        private Double _grossMarginSt;

        /// <summary>粗利チェック3</summary>
        private Double _grossMargin2Ed;

        /// <summary>粗利チェック4</summary>
        private Double _grossMargin3Ed;

		/// <summary>粗利チェック適正</summary>
		/// <remarks>粗利チェックの適正値（％で入力）　XX.X％　以上</remarks>
		private Double _grsProfitCheckBest;

		/// <summary>粗利チェック上限</summary>
		/// <remarks>粗利チェックの上限値（％で入力）　XX.X％　以上</remarks>
		private Double _grsProfitCheckUpper;

		/// <summary>粗利チェック1(マーク)</summary>
		private string _grossMargin1Mark = "";

		/// <summary>粗利チェック2(マーク)</summary>
		private string _grossMargin2Mark = "";

		/// <summary>粗利チェック3(マーク)</summary>
		private string _grossMargin3Mark = "";

		/// <summary>粗利チェック4(マーク)</summary>
		private string _grossMargin4Mark = "";

		/// <summary>売価ゼロのみ印字</summary>
		/// <remarks>0:指定なし,1:指定あり</remarks>
		private Int32 _zeroSalesPrint;

		/// <summary>原価ゼロのみ印字</summary>
		/// <remarks>0:指定なし,1:指定あり</remarks>
		private Int32 _zeroCostPrint;

		/// <summary>粗利ゼロのみ印字</summary>
		/// <remarks>0:指定なし,1:指定あり</remarks>
		private Int32 _zeroGrsProfitPrint;

		/// <summary>粗利ゼロ以下のみ印字</summary>
		/// <remarks>0:指定なし,1:指定あり</remarks>
		private Int32 _zeroUdrGrsProfitPrint;

		/// <summary>粗利率印字</summary>
		/// <remarks>0:指定なし,1:指定あり</remarks>
		private Int32 _grsProfitRatePrint;

		/// <summary>粗利率印字値</summary>
		private Double _grsProfitRatePrintVal;

		/// <summary>粗利率印字区分</summary>
		/// <remarks>0:以下,1:以上</remarks>
		private Int32 _grsProfitRatePrintDiv;

        /// <summary>出力順</summary>
        private Int32 _sortOrder;

        /// <summary>原価・粗利出力</summary>
        private Int32 _costOut;

        // --- ADD 2009/04/13 -------------------------------->>>>>
        /// <summary>日計印字</summary>
        private Int32 _printDailyFooter;
        // --- ADD 2009/04/13 --------------------------------<<<<<

        /// <summary>改頁</summary>
        private Int32 _newPageType;

        //----- ADD 2013/01/04 田建委 Redmine#34098 ----->>>>>
        /// <summary>罫線印字制御</summary>
        private Int32 _linePrintDiv;
        //----- ADD 2013/01/04 田建委 Redmine#34098 -----<<<<<
        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
        /// <summary>税別内訳印字区分</summary>
        private Int32 _taxPrintDiv;

        /// <summary>税率１</summary>
        private string _taxRate1;

        /// <summary>税率２</summary>
        private string _taxRate2;
        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        /// <summary>帳票タイプ区分</summary>
        /// <remarks>用途と同じ</remarks>
        private int _printDiv;

        /// <summary>帳票タイプ区分名称</summary>
        private string _printDivName = string.Empty;

        // 帳票タイプ区分
        /// <summary>帳票タイプ区分 伝票形式</summary>
        public const string ct_PrintDiv_Slipform = "伝票タイプ";
        /// <summary>帳票タイプ区分 明細形式</summary>
        public const string ct_PrintDiv_Detailsform = "明細タイプ";

        /// <summary>共通 日付フォーマット</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

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

		/// public propaty name  :  IsSelectAllSection
		/// <summary>全社選択プロパティ</summary>
		/// <value>true:全社選択 false:各拠点選択</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   全社選択プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean IsSelectAllSection
		{
			get{return _isSelectAllSection;}
			set{_isSelectAllSection = value;}
		}

		/// public propaty name  :  ResultsAddUpSecList
		/// <summary>実績計上拠点コードリストプロパティ</summary>
		/// <value>文字型　※配列項目 全社指定は{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   実績計上拠点コードリストプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] ResultsAddUpSecList
		{
			get{return _resultsAddUpSecList;}
			set{_resultsAddUpSecList = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>論理削除区分プロパティ</summary>
		/// <value>0:有効,1:論理削除,2:保留,3:完全削除</value>
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

		/// public propaty name  :  SalesDateSt
		/// <summary>売上日付(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上日付(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesDateSt
		{
			get{return _salesDateSt;}
			set{_salesDateSt = value;}
		}

		/// public propaty name  :  SalesDateEd
		/// <summary>売上日付(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上日付(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesDateEd
		{
			get{return _salesDateEd;}
			set{_salesDateEd = value;}
		}

		/// public propaty name  :  SearchSlipDateSt
		/// <summary>伝票検索日付(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票検索日付(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SearchSlipDateSt
		{
			get{return _searchSlipDateSt;}
			set{_searchSlipDateSt = value;}
		}

		/// public propaty name  :  SearchSlipDateEd
		/// <summary>伝票検索日付(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票検索日付(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SearchSlipDateEd
		{
			get{return _searchSlipDateEd;}
			set{_searchSlipDateEd = value;}
		}

		/// public propaty name  :  ShipmentDaySt
		/// <summary>出荷日付（開始）プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷日付（開始）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ShipmentDaySt
		{
			get{return _shipmentDaySt;}
			set{_shipmentDaySt = value;}
		}

		/// public propaty name  :  ShipmentDayEd
		/// <summary>出荷日付（終了）プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷日付（終了）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ShipmentDayEd
		{
			get{return _shipmentDayEd;}
			set{_shipmentDayEd = value;}
		}

		/// public propaty name  :  CustomerCodeSt
		/// <summary>得意先コード(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCodeSt
		{
			get{return _customerCodeSt;}
			set{_customerCodeSt = value;}
		}

		/// public propaty name  :  CustomerCodeEd
		/// <summary>得意先コード(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCodeEd
		{
			get{return _customerCodeEd;}
			set{_customerCodeEd = value;}
		}

		/// public propaty name  :  SupplierCdSt
		/// <summary>仕入先コード(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierCdSt
		{
			get{return _supplierCdSt;}
			set{_supplierCdSt = value;}
		}

		/// public propaty name  :  SupplierCdEd
		/// <summary>仕入先コード(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierCdEd
		{
			get{return _supplierCdEd;}
			set{_supplierCdEd = value;}
		}

		/// public propaty name  :  DebitNoteDiv
		/// <summary>赤伝区分プロパティ</summary>
		/// <value>0:黒伝,1:赤伝,2:元黒　　※全ては-1</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   赤伝区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DebitNoteDiv
		{
			get{return _debitNoteDiv;}
			set{_debitNoteDiv = value;}
		}

		/// public propaty name  :  SalesSlipCd
		/// <summary>売上伝票区分プロパティ</summary>
		/// <value>0:売上,1:返品,2:返品＋行値引　※全ては-1</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesSlipCd
		{
			get{return _salesSlipCd;}
			set{_salesSlipCd = value;}
		}

		/// public propaty name  :  SalesSlipNumSt
		/// <summary>売上伝票番号(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票番号(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesSlipNumSt
		{
			get{return _salesSlipNumSt;}
			set{_salesSlipNumSt = value;}
		}

		/// public propaty name  :  SalesSlipNumEd
		/// <summary>売上伝票番号(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票番号(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesSlipNumEd
		{
			get{return _salesSlipNumEd;}
			set{_salesSlipNumEd = value;}
		}

		/// public propaty name  :  SalesInputCodeSt
		/// <summary>売上入力者コード(開始)プロパティ</summary>
		/// <value>入力担当者（発行者）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上入力者コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesInputCodeSt
		{
			get{return _salesInputCodeSt;}
			set{_salesInputCodeSt = value;}
		}

		/// public propaty name  :  SalesInputCodeEd
		/// <summary>売上入力者コード(終了)プロパティ</summary>
		/// <value>入力担当者（発行者）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上入力者コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesInputCodeEd
		{
			get{return _salesInputCodeEd;}
			set{_salesInputCodeEd = value;}
		}

		/// public propaty name  :  SalesEmployeeCdSt
		/// <summary>販売従業員コード(開始)プロパティ</summary>
		/// <value>計上担当者（担当者）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売従業員コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesEmployeeCdSt
		{
			get{return _salesEmployeeCdSt;}
			set{_salesEmployeeCdSt = value;}
		}

		/// public propaty name  :  SalesEmployeeCdEd
		/// <summary>販売従業員コード(終了)プロパティ</summary>
		/// <value>計上担当者（担当者）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売従業員コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesEmployeeCdEd
		{
			get{return _salesEmployeeCdEd;}
			set{_salesEmployeeCdEd = value;}
		}

		/// public propaty name  :  FrontEmployeeCdSt
		/// <summary>受付従業員コード（開始）プロパティ</summary>
		/// <value>受付担当者（受注者）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受付従業員コード（開始）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FrontEmployeeCdSt
		{
			get{return _frontEmployeeCdSt;}
			set{_frontEmployeeCdSt = value;}
		}

		/// public propaty name  :  FrontEmployeeCdEd
		/// <summary>受付従業員コード（終了）プロパティ</summary>
		/// <value>受付担当者（受注者）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受付従業員コード（終了）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FrontEmployeeCdEd
		{
			get{return _frontEmployeeCdEd;}
			set{_frontEmployeeCdEd = value;}
		}

		/// public propaty name  :  SalesAreaCodeSt
		/// <summary>販売エリアコード(開始)プロパティ</summary>
		/// <value>地区コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売エリアコード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesAreaCodeSt
		{
			get{return _salesAreaCodeSt;}
			set{_salesAreaCodeSt = value;}
		}

		/// public propaty name  :  SalesAreaCodeEd
		/// <summary>販売エリアコード(終了)プロパティ</summary>
		/// <value>地区コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売エリアコード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesAreaCodeEd
		{
			get{return _salesAreaCodeEd;}
			set{_salesAreaCodeEd = value;}
		}

		/// public propaty name  :  BusinessTypeCodeSt
		/// <summary>業種コード(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   業種コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BusinessTypeCodeSt
		{
			get{return _businessTypeCodeSt;}
			set{_businessTypeCodeSt = value;}
		}

		/// public propaty name  :  BusinessTypeCodeEd
		/// <summary>業種コード(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   業種コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BusinessTypeCodeEd
		{
			get{return _businessTypeCodeEd;}
			set{_businessTypeCodeEd = value;}
		}

		/// public propaty name  :  SalesSlipUpdateCd
		/// <summary>売上伝票更新区分プロパティ</summary>
		/// <value>0:未更新,1:更新あり　※全ては-1</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票更新区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesSlipUpdateCd
		{
			get{return _salesSlipUpdateCd;}
			set{_salesSlipUpdateCd = value;}
		}

		/// public propaty name  :  SalesOrderDivCd
		/// <summary>売上在庫取寄せ区分プロパティ</summary>
		/// <value>0:取寄せ，1:在庫　　※全ては-1　注）売上確認表で注文方法＝「2:ｵﾝﾗｲﾝ発注」指定時は-1をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上在庫取寄せ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesOrderDivCd
		{
			get{return _salesOrderDivCd;}
			set{_salesOrderDivCd = value;}
		}

		/// public propaty name  :  WayToOrder
		/// <summary>注文方法プロパティ</summary>
		/// <value>0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録　※全ては-1</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   注文方法プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 WayToOrder
		{
			get{return _wayToOrder;}
			set{_wayToOrder = value;}
		}

		/// public propaty name  :  GrsProfitCheckLower
		/// <summary>粗利チェック下限プロパティ</summary>
		/// <value>粗利チェックの下限値（％で入力）　XX.X％　以上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック下限プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double GrsProfitCheckLower
		{
			get{return _grsProfitCheckLower;}
			set{_grsProfitCheckLower = value;}
		}

        /// public propaty name  :  GrsProfitCheckLower
        /// <summary>粗利チェック2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利チェック2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double GrossMarginSt
        {
            get { return _grossMarginSt; }
            set { _grossMarginSt = value; }
        }

        /// public propaty name  :  GrsProfitCheckLower
        /// <summary>粗利チェック3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利チェック3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double GrossMargin2Ed
        {
            get { return _grossMargin2Ed; }
            set { _grossMargin2Ed = value; }
        }

        /// public propaty name  :  GrsProfitCheckLower
        /// <summary>粗利チェック4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利チェック4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double GrossMargin3Ed
        {
            get { return _grossMargin3Ed; }
            set { _grossMargin3Ed = value; }
        }

		/// public propaty name  :  GrsProfitCheckBest
		/// <summary>粗利チェック適正プロパティ</summary>
		/// <value>粗利チェックの適正値（％で入力）　XX.X％　以上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック適正プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double GrsProfitCheckBest
		{
			get{return _grsProfitCheckBest;}
			set{_grsProfitCheckBest = value;}
		}

		/// public propaty name  :  GrsProfitCheckUpper
		/// <summary>粗利チェック上限プロパティ</summary>
		/// <value>粗利チェックの上限値（％で入力）　XX.X％　以上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック上限プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double GrsProfitCheckUpper
		{
			get{return _grsProfitCheckUpper;}
			set{_grsProfitCheckUpper = value;}
		}

		/// public propaty name  :  GrossMargin1Mark
		/// <summary>粗利チェック1(マーク)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック1(マーク)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GrossMargin1Mark
		{
			get{return _grossMargin1Mark;}
			set{_grossMargin1Mark = value;}
		}

		/// public propaty name  :  GrossMargin2Mark
		/// <summary>粗利チェック2(マーク)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック2(マーク)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GrossMargin2Mark
		{
			get{return _grossMargin2Mark;}
			set{_grossMargin2Mark = value;}
		}

		/// public propaty name  :  GrossMargin3Mark
		/// <summary>粗利チェック3(マーク)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック3(マーク)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GrossMargin3Mark
		{
			get{return _grossMargin3Mark;}
			set{_grossMargin3Mark = value;}
		}

		/// public propaty name  :  GrossMargin4Mark
		/// <summary>粗利チェック4(マーク)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック4(マーク)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GrossMargin4Mark
		{
			get{return _grossMargin4Mark;}
			set{_grossMargin4Mark = value;}
		}

		/// public propaty name  :  ZeroSalesPrint
		/// <summary>売価ゼロのみ印字プロパティ</summary>
		/// <value>0:指定なし,1:指定あり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売価ゼロのみ印字プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ZeroSalesPrint
		{
			get{return _zeroSalesPrint;}
			set{_zeroSalesPrint = value;}
		}

		/// public propaty name  :  ZeroCostPrint
		/// <summary>原価ゼロのみ印字プロパティ</summary>
		/// <value>0:指定なし,1:指定あり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   原価ゼロのみ印字プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ZeroCostPrint
		{
			get{return _zeroCostPrint;}
			set{_zeroCostPrint = value;}
		}

		/// public propaty name  :  ZeroGrsProfitPrint
		/// <summary>粗利ゼロのみ印字プロパティ</summary>
		/// <value>0:指定なし,1:指定あり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利ゼロのみ印字プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ZeroGrsProfitPrint
		{
			get{return _zeroGrsProfitPrint;}
			set{_zeroGrsProfitPrint = value;}
		}

		/// public propaty name  :  ZeroUdrGrsProfitPrint
		/// <summary>粗利ゼロ以下のみ印字プロパティ</summary>
		/// <value>0:指定なし,1:指定あり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利ゼロ以下のみ印字プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ZeroUdrGrsProfitPrint
		{
			get{return _zeroUdrGrsProfitPrint;}
			set{_zeroUdrGrsProfitPrint = value;}
		}

		/// public propaty name  :  GrsProfitRatePrint
		/// <summary>粗利率印字プロパティ</summary>
		/// <value>0:指定なし,1:指定あり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利率印字プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GrsProfitRatePrint
		{
			get{return _grsProfitRatePrint;}
			set{_grsProfitRatePrint = value;}
		}

		/// public propaty name  :  GrsProfitRatePrintVal
		/// <summary>粗利率印字値プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利率印字値プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double GrsProfitRatePrintVal
		{
			get{return _grsProfitRatePrintVal;}
			set{_grsProfitRatePrintVal = value;}
		}

		/// public propaty name  :  GrsProfitRatePrintDiv
		/// <summary>粗利率印字区分プロパティ</summary>
		/// <value>0:以下,1:以上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利率印字区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GrsProfitRatePrintDiv
		{
			get{return _grsProfitRatePrintDiv;}
			set{_grsProfitRatePrintDiv = value;}
		}

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

        /// public propaty name  :  CostOut
        /// <summary>原価・粗利出力プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価・粗利出力プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CostOut
        {
            get { return _costOut; }
            set { _costOut = value; }
        }

        // --- ADD 2009/04/13 -------------------------------->>>>>
        /// public propaty name  :  PrintDailyFooter
        /// <summary>日計印字プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   日計印字プロパティ</br>
        /// </remarks>
        public Int32 PrintDailyFooter
        {
            get { return _printDailyFooter; }
            set { _printDailyFooter = value; }
        }
        // --- ADD 2009/04/13 --------------------------------<<<<<

        /// public propaty name  :  NewPageType
        /// <summary>改頁プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NewPageType
        {
            get { return _newPageType; }
            set { _newPageType = value; }
        }
        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
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
        /// <summary>税率1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TaxRate1
        {
            get { return _taxRate1; }
            set { _taxRate1 = value; }
        }

        /// public propaty name  :  TaxRate2
        /// <summary>税率２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TaxRate2
        {
            get { return _taxRate2; }
            set { _taxRate2 = value; }
        }
        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<

        //----- ADD 2013/01/04 田建委 Redmine#34098 ----->>>>>
        /// public propaty name  :  LinePrintDiv
        /// <summary>罫線印字制御</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   罫線印字制御プロパティ</br>
        /// <br>Programer        :   田建委</br>
        /// <br>Date	         :   2013/01/04</br>
        /// </remarks>
        public Int32 LinePrintDiv
        {
            get { return _linePrintDiv; }
            set { _linePrintDiv = value; }
        }
        //----- ADD 2013/01/04 田建委 Redmine#34098 -----<<<<<

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

        //帳票設定 ---------------------------------------------------------------
        /// public propaty name  :  PrintDiv
        /// <summary>帳票タイプ区分プロパティ</summary>
        /// <value>設定の用途コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票タイプ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int PrintDiv
        {
            get { return _printDiv; }
            set { _printDiv = value; }
        }

        /// public propaty name  :  PrintDivName
        /// <summary>帳票タイプ区分プロパティ名称(読み取り専用)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票タイプ区分プロパティ名称</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrintDivName
        {
            get { return _printDivName; }
            set { _printDivName = value; }
        }

        /// <summary> 帳票タイプ区分列挙体 </summary>
        public enum PrintDivState
        {
            /// <summary> 伝票タイプ </summary>
            Slipform = 1,
            /// <summary> 明細タイプ </summary>
            Detailsform = 2,
        }

		/// <summary>
		/// 売上確認表検索条件コンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_MAHNB02347Eクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_MAHNB02347Eクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_MAHNB02347E()
		{
		}

		/// <summary>
		/// 売上確認表検索条件コンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="isSelectAllSection">全社選択(true:全社選択 false:各拠点選択)</param>
		/// <param name="resultsAddUpSecList">実績計上拠点コードリスト(文字型　※配列項目 全社指定は{""})</param>
		/// <param name="logicalDeleteCode">論理削除区分(0:有効,1:論理削除,2:保留,3:完全削除)</param>
		/// <param name="salesDateSt">売上日付(開始)</param>
		/// <param name="salesDateEd">売上日付(終了)</param>
		/// <param name="searchSlipDateSt">伝票検索日付(開始)</param>
		/// <param name="searchSlipDateEd">伝票検索日付(終了)</param>
		/// <param name="shipmentDaySt">出荷日付（開始）(YYYYMMDD)</param>
		/// <param name="shipmentDayEd">出荷日付（終了）(YYYYMMDD)</param>
		/// <param name="customerCodeSt">得意先コード(開始)</param>
		/// <param name="customerCodeEd">得意先コード(終了)</param>
		/// <param name="supplierCdSt">仕入先コード(開始)</param>
		/// <param name="supplierCdEd">仕入先コード(終了)</param>
		/// <param name="debitNoteDiv">赤伝区分(0:黒伝,1:赤伝,2:元黒　　※全ては-1)</param>
		/// <param name="salesSlipCd">売上伝票区分(0:売上,1:返品,2:返品＋行値引　※全ては-1)</param>
		/// <param name="salesSlipNumSt">売上伝票番号(開始)</param>
		/// <param name="salesSlipNumEd">売上伝票番号(終了)</param>
		/// <param name="salesInputCodeSt">売上入力者コード(開始)(入力担当者（発行者）)</param>
		/// <param name="salesInputCodeEd">売上入力者コード(終了)(入力担当者（発行者）)</param>
		/// <param name="salesEmployeeCdSt">販売従業員コード(開始)(計上担当者（担当者）)</param>
		/// <param name="salesEmployeeCdEd">販売従業員コード(終了)(計上担当者（担当者）)</param>
		/// <param name="frontEmployeeCdSt">受付従業員コード（開始）(受付担当者（受注者）)</param>
		/// <param name="frontEmployeeCdEd">受付従業員コード（終了）(受付担当者（受注者）)</param>
		/// <param name="salesAreaCodeSt">販売エリアコード(開始)(地区コード)</param>
		/// <param name="salesAreaCodeEd">販売エリアコード(終了)(地区コード)</param>
		/// <param name="businessTypeCodeSt">業種コード(開始)</param>
		/// <param name="businessTypeCodeEd">業種コード(終了)</param>
		/// <param name="salesSlipUpdateCd">売上伝票更新区分(0:未更新,1:更新あり　※全ては-1)</param>
		/// <param name="salesOrderDivCd">売上在庫取寄せ区分(0:取寄せ，1:在庫　　※全ては-1　注）売上確認表で注文方法＝「2:ｵﾝﾗｲﾝ発注」指定時は-1をセット)</param>
		/// <param name="wayToOrder">注文方法(0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録　※全ては-1)</param>
		/// <param name="grsProfitCheckLower">粗利チェック下限(粗利チェックの下限値（％で入力）　XX.X％　以上)</param>
        /// <param name="grossMarginSt">粗利チェック2</param>
        /// <param name="grossMargin2Ed">粗利チェック3</param>
        /// <param name="grossMargin3Ed">粗利チェック4</param>
        /// <param name="grsProfitCheckBest">粗利チェック適正(粗利チェックの適正値（％で入力）　XX.X％　以上)</param>
		/// <param name="grsProfitCheckUpper">粗利チェック上限(粗利チェックの上限値（％で入力）　XX.X％　以上)</param>
		/// <param name="grossMargin1Mark">粗利チェック1(マーク)</param>
		/// <param name="grossMargin2Mark">粗利チェック2(マーク)</param>
		/// <param name="grossMargin3Mark">粗利チェック3(マーク)</param>
		/// <param name="grossMargin4Mark">粗利チェック4(マーク)</param>
		/// <param name="zeroSalesPrint">売価ゼロのみ印字(0:指定なし,1:指定あり)</param>
		/// <param name="zeroCostPrint">原価ゼロのみ印字(0:指定なし,1:指定あり)</param>
		/// <param name="zeroGrsProfitPrint">粗利ゼロのみ印字(0:指定なし,1:指定あり)</param>
		/// <param name="zeroUdrGrsProfitPrint">粗利ゼロ以下のみ印字(0:指定なし,1:指定あり)</param>
		/// <param name="grsProfitRatePrint">粗利率印字(0:指定なし,1:指定あり)</param>
		/// <param name="grsProfitRatePrintVal">粗利率印字値</param>
		/// <param name="grsProfitRatePrintDiv">粗利率印字区分(0:以下,1:以上)</param>
        /// <param name="sortOrder">出力順</param>
        /// <param name="costOut">原価・粗利出力</param>
        /// <param name="printDailyFooter">日計印字</param>
        /// <param name="newPageType">改頁</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="taxPrintDiv">税別内訳印字</param>
        /// <param name="taxRate1">XMLの税率１</param>
        /// <param name="taxRate2">XMLの税率２</param>
		/// <returns>ExtrInfo_MAHNB02347Eクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_MAHNB02347Eクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Note             :   11570208-00 軽減税率対応</br>
        /// <br>Programer        :   2020/02/27 3H 尹安</br>
		/// </remarks>
        //public ExtrInfo_MAHNB02347E(string enterpriseCode, Boolean isSelectAllSection, string[] resultsAddUpSecList, Int32 logicalDeleteCode, Int32 salesDateSt, Int32 salesDateEd, Int32 searchSlipDateSt, Int32 searchSlipDateEd, Int32 shipmentDaySt, Int32 shipmentDayEd, Int32 customerCodeSt, Int32 customerCodeEd, Int32 supplierCdSt, Int32 supplierCdEd, Int32 debitNoteDiv, Int32 salesSlipCd, string salesSlipNumSt, string salesSlipNumEd, string salesInputCodeSt, string salesInputCodeEd, string salesEmployeeCdSt, string salesEmployeeCdEd, string frontEmployeeCdSt, string frontEmployeeCdEd, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 businessTypeCodeSt, Int32 businessTypeCodeEd, Int32 salesSlipUpdateCd, Int32 salesOrderDivCd, Int32 wayToOrder, Double grsProfitCheckLower, Double grossMarginSt, Double grossMargin2Ed, Double grossMargin3Ed, Double grsProfitCheckBest, Double grsProfitCheckUpper, string grossMargin1Mark, string grossMargin2Mark, string grossMargin3Mark, string grossMargin4Mark, Int32 zeroSalesPrint, Int32 zeroCostPrint, Int32 zeroGrsProfitPrint, Int32 zeroUdrGrsProfitPrint, Int32 grsProfitRatePrint, Double grsProfitRatePrintVal, Int32 grsProfitRatePrintDiv, Int32 sortOrder, Int32 costOut, Int32 printDailyFooter, Int32 newPageType, string enterpriseName)                  // --- DEL 3H 尹安 2020/02/27
        public ExtrInfo_MAHNB02347E(string enterpriseCode, Boolean isSelectAllSection, string[] resultsAddUpSecList, Int32 logicalDeleteCode, Int32 salesDateSt, Int32 salesDateEd, Int32 searchSlipDateSt, Int32 searchSlipDateEd, Int32 shipmentDaySt, Int32 shipmentDayEd, Int32 customerCodeSt, Int32 customerCodeEd, Int32 supplierCdSt, Int32 supplierCdEd, Int32 debitNoteDiv, Int32 salesSlipCd, string salesSlipNumSt, string salesSlipNumEd, string salesInputCodeSt, string salesInputCodeEd, string salesEmployeeCdSt, string salesEmployeeCdEd, string frontEmployeeCdSt, string frontEmployeeCdEd, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 businessTypeCodeSt, Int32 businessTypeCodeEd, Int32 salesSlipUpdateCd, Int32 salesOrderDivCd, Int32 wayToOrder, Double grsProfitCheckLower, Double grossMarginSt, Double grossMargin2Ed, Double grossMargin3Ed, Double grsProfitCheckBest, Double grsProfitCheckUpper, string grossMargin1Mark, string grossMargin2Mark, string grossMargin3Mark, string grossMargin4Mark, Int32 zeroSalesPrint, Int32 zeroCostPrint, Int32 zeroGrsProfitPrint, Int32 zeroUdrGrsProfitPrint, Int32 grsProfitRatePrint, Double grsProfitRatePrintVal, Int32 grsProfitRatePrintDiv, Int32 sortOrder, Int32 costOut, Int32 printDailyFooter, Int32 newPageType, string enterpriseName, Int32 taxPrintDiv,string taxRate1, string taxRate2) // --- ADD 3H 尹安 2020/02/27
		{
			this._enterpriseCode = enterpriseCode;
			this._isSelectAllSection = isSelectAllSection;
			this._resultsAddUpSecList = resultsAddUpSecList;
			this._logicalDeleteCode = logicalDeleteCode;
			this._salesDateSt = salesDateSt;
			this._salesDateEd = salesDateEd;
			this._searchSlipDateSt = searchSlipDateSt;
			this._searchSlipDateEd = searchSlipDateEd;
			this._shipmentDaySt = shipmentDaySt;
			this._shipmentDayEd = shipmentDayEd;
			this._customerCodeSt = customerCodeSt;
			this._customerCodeEd = customerCodeEd;
			this._supplierCdSt = supplierCdSt;
			this._supplierCdEd = supplierCdEd;
			this._debitNoteDiv = debitNoteDiv;
			this._salesSlipCd = salesSlipCd;
			this._salesSlipNumSt = salesSlipNumSt;
			this._salesSlipNumEd = salesSlipNumEd;
			this._salesInputCodeSt = salesInputCodeSt;
			this._salesInputCodeEd = salesInputCodeEd;
			this._salesEmployeeCdSt = salesEmployeeCdSt;
			this._salesEmployeeCdEd = salesEmployeeCdEd;
			this._frontEmployeeCdSt = frontEmployeeCdSt;
			this._frontEmployeeCdEd = frontEmployeeCdEd;
			this._salesAreaCodeSt = salesAreaCodeSt;
			this._salesAreaCodeEd = salesAreaCodeEd;
			this._businessTypeCodeSt = businessTypeCodeSt;
			this._businessTypeCodeEd = businessTypeCodeEd;
			this._salesSlipUpdateCd = salesSlipUpdateCd;
			this._salesOrderDivCd = salesOrderDivCd;
			this._wayToOrder = wayToOrder;
			this._grsProfitCheckLower = grsProfitCheckLower;
            this._grossMarginSt = grossMarginSt;
            this._grossMargin2Ed = grossMargin2Ed;
            this._grossMargin3Ed = grossMargin3Ed;
            this._grsProfitCheckBest = grsProfitCheckBest;
			this._grsProfitCheckUpper = grsProfitCheckUpper;
			this._grossMargin1Mark = grossMargin1Mark;
			this._grossMargin2Mark = grossMargin2Mark;
			this._grossMargin3Mark = grossMargin3Mark;
			this._grossMargin4Mark = grossMargin4Mark;
			this._zeroSalesPrint = zeroSalesPrint;
			this._zeroCostPrint = zeroCostPrint;
			this._zeroGrsProfitPrint = zeroGrsProfitPrint;
			this._zeroUdrGrsProfitPrint = zeroUdrGrsProfitPrint;
			this._grsProfitRatePrint = grsProfitRatePrint;
			this._grsProfitRatePrintVal = grsProfitRatePrintVal;
			this._grsProfitRatePrintDiv = grsProfitRatePrintDiv;
            this._sortOrder = sortOrder;
            this._costOut = costOut;
            this._printDailyFooter = printDailyFooter; // ADD 2009/04/13
            this._newPageType = newPageType;
            this._enterpriseName = enterpriseName;
            // ADD START 3H 尹安 2020/02/27 ------>>>>>
            this._taxPrintDiv = taxPrintDiv;
            this._taxRate1 = taxRate1;
            this._taxRate2 = taxRate2;
            // ADD END 3H 尹安 2020/02/27 ------<<<<<

		}

		/// <summary>
		/// 売上確認表検索条件複製処理
		/// </summary>
		/// <returns>ExtrInfo_MAHNB02347Eクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいExtrInfo_MAHNB02347Eクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Note             :   11570208-00 軽減税率対応</br>
        /// <br>Programer        :   2020/02/27 3H 尹安</br>
		/// </remarks>
        public ExtrInfo_MAHNB02347E Clone()
		{
            // return new ExtrInfo_MAHNB02347E(this._enterpriseCode, this._isSelectAllSection, this._resultsAddUpSecList, this._logicalDeleteCode, this._salesDateSt, this._salesDateEd, this._searchSlipDateSt, this._searchSlipDateEd, this._shipmentDaySt, this._shipmentDayEd, this._customerCodeSt, this._customerCodeEd, this._supplierCdSt, this._supplierCdEd, this._debitNoteDiv, this._salesSlipCd, this._salesSlipNumSt, this._salesSlipNumEd, this._salesInputCodeSt, this._salesInputCodeEd, this._salesEmployeeCdSt, this._salesEmployeeCdEd, this._frontEmployeeCdSt, this._frontEmployeeCdEd, this._salesAreaCodeSt, this._salesAreaCodeEd, this._businessTypeCodeSt, this._businessTypeCodeEd, this._salesSlipUpdateCd, this._salesOrderDivCd, this._wayToOrder, this._grsProfitCheckLower, this._grossMarginSt, this._grossMargin2Ed, this._grossMargin3Ed, this._grsProfitCheckBest, this._grsProfitCheckUpper, this._grossMargin1Mark, this._grossMargin2Mark, this._grossMargin3Mark, this._grossMargin4Mark, this._zeroSalesPrint, this._zeroCostPrint, this._zeroGrsProfitPrint, this._zeroUdrGrsProfitPrint, this._grsProfitRatePrint, this._grsProfitRatePrintVal, this._grsProfitRatePrintDiv, this._sortOrder, this._costOut, this._printDailyFooter, this._newPageType, this._enterpriseName);  // DEL 3H 尹安 2020/02/27
            return new ExtrInfo_MAHNB02347E(this._enterpriseCode, this._isSelectAllSection, this._resultsAddUpSecList, this._logicalDeleteCode, this._salesDateSt, this._salesDateEd, this._searchSlipDateSt, this._searchSlipDateEd, this._shipmentDaySt, this._shipmentDayEd, this._customerCodeSt, this._customerCodeEd, this._supplierCdSt, this._supplierCdEd, this._debitNoteDiv, this._salesSlipCd, this._salesSlipNumSt, this._salesSlipNumEd, this._salesInputCodeSt, this._salesInputCodeEd, this._salesEmployeeCdSt, this._salesEmployeeCdEd, this._frontEmployeeCdSt, this._frontEmployeeCdEd, this._salesAreaCodeSt, this._salesAreaCodeEd, this._businessTypeCodeSt, this._businessTypeCodeEd, this._salesSlipUpdateCd, this._salesOrderDivCd, this._wayToOrder, this._grsProfitCheckLower, this._grossMarginSt, this._grossMargin2Ed, this._grossMargin3Ed, this._grsProfitCheckBest, this._grsProfitCheckUpper, this._grossMargin1Mark, this._grossMargin2Mark, this._grossMargin3Mark, this._grossMargin4Mark, this._zeroSalesPrint, this._zeroCostPrint, this._zeroGrsProfitPrint, this._zeroUdrGrsProfitPrint, this._grsProfitRatePrint, this._grsProfitRatePrintVal, this._grsProfitRatePrintDiv, this._sortOrder, this._costOut, this._printDailyFooter, this._newPageType, this._enterpriseName,this._taxPrintDiv,this._taxRate1,this._taxRate2);  // ADD 3H 尹安 2020/02/27
		}

		/// <summary>
		/// 売上確認表検索条件比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_MAHNB02347Eクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_MAHNB02347Eクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Note             :   11570208-00 軽減税率対応</br>
        /// <br>Programer        :   2020/02/27 3H 尹安</br>
		/// </remarks>
        public bool Equals(ExtrInfo_MAHNB02347E target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.IsSelectAllSection == target.IsSelectAllSection)
				 && (this.ResultsAddUpSecList == target.ResultsAddUpSecList)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.SalesDateSt == target.SalesDateSt)
				 && (this.SalesDateEd == target.SalesDateEd)
				 && (this.SearchSlipDateSt == target.SearchSlipDateSt)
				 && (this.SearchSlipDateEd == target.SearchSlipDateEd)
				 && (this.ShipmentDaySt == target.ShipmentDaySt)
				 && (this.ShipmentDayEd == target.ShipmentDayEd)
				 && (this.CustomerCodeSt == target.CustomerCodeSt)
				 && (this.CustomerCodeEd == target.CustomerCodeEd)
				 && (this.SupplierCdSt == target.SupplierCdSt)
				 && (this.SupplierCdEd == target.SupplierCdEd)
				 && (this.DebitNoteDiv == target.DebitNoteDiv)
				 && (this.SalesSlipCd == target.SalesSlipCd)
				 && (this.SalesSlipNumSt == target.SalesSlipNumSt)
				 && (this.SalesSlipNumEd == target.SalesSlipNumEd)
				 && (this.SalesInputCodeSt == target.SalesInputCodeSt)
				 && (this.SalesInputCodeEd == target.SalesInputCodeEd)
				 && (this.SalesEmployeeCdSt == target.SalesEmployeeCdSt)
				 && (this.SalesEmployeeCdEd == target.SalesEmployeeCdEd)
				 && (this.FrontEmployeeCdSt == target.FrontEmployeeCdSt)
				 && (this.FrontEmployeeCdEd == target.FrontEmployeeCdEd)
				 && (this.SalesAreaCodeSt == target.SalesAreaCodeSt)
				 && (this.SalesAreaCodeEd == target.SalesAreaCodeEd)
				 && (this.BusinessTypeCodeSt == target.BusinessTypeCodeSt)
				 && (this.BusinessTypeCodeEd == target.BusinessTypeCodeEd)
				 && (this.SalesSlipUpdateCd == target.SalesSlipUpdateCd)
				 && (this.SalesOrderDivCd == target.SalesOrderDivCd)
				 && (this.WayToOrder == target.WayToOrder)
				 && (this.GrsProfitCheckLower == target.GrsProfitCheckLower)
                 && (this.GrossMarginSt == target.GrossMarginSt)
                 && (this.GrossMargin2Ed == target.GrossMargin2Ed)
                 && (this.GrossMargin3Ed == target.GrossMargin3Ed)
                 && (this.GrsProfitCheckBest == target.GrsProfitCheckBest)
				 && (this.GrsProfitCheckUpper == target.GrsProfitCheckUpper)
				 && (this.GrossMargin1Mark == target.GrossMargin1Mark)
				 && (this.GrossMargin2Mark == target.GrossMargin2Mark)
				 && (this.GrossMargin3Mark == target.GrossMargin3Mark)
				 && (this.GrossMargin4Mark == target.GrossMargin4Mark)
				 && (this.ZeroSalesPrint == target.ZeroSalesPrint)
				 && (this.ZeroCostPrint == target.ZeroCostPrint)
				 && (this.ZeroGrsProfitPrint == target.ZeroGrsProfitPrint)
				 && (this.ZeroUdrGrsProfitPrint == target.ZeroUdrGrsProfitPrint)
				 && (this.GrsProfitRatePrint == target.GrsProfitRatePrint)
				 && (this.GrsProfitRatePrintVal == target.GrsProfitRatePrintVal)
				 && (this.GrsProfitRatePrintDiv == target.GrsProfitRatePrintDiv)
                 && (this.SortOrder == target.SortOrder)
                 && (this.CostOut == target.CostOut)
                 && (this.PrintDailyFooter == target.PrintDailyFooter) // ADD 2009/04/13
                 && (this.NewPageType == target.NewPageType)
                 // ADD START 3H 尹安 2020/02/27 ---->>>>>
                 && (this.TaxPrintDiv == target.TaxPrintDiv)
                 && (this.TaxRate1 == target.TaxRate1)
                 && (this.TaxRate2 == target.TaxRate2)
                // ADD END 3H 尹安 2020/02/27 ----<<<<<
                 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// 売上確認表検索条件比較処理
		/// </summary>
        /// <param name="extrInfo_MAHNB02347E1">
		///                    比較するExtrInfo_MAHNB02347Eクラスのインスタンス
		/// </param>
        /// <param name="extrInfo_MAHNB02347E2">比較するExtrInfo_MAHNB02347Eクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_MAHNB02347Eクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Note             :   11570208-00 軽減税率対応</br>
        /// <br>Programer        :   2020/02/27 3H 尹安</br>
		/// </remarks>
        public static bool Equals(ExtrInfo_MAHNB02347E extrInfo_MAHNB02347E1, ExtrInfo_MAHNB02347E extrInfo_MAHNB02347E2)
		{
			return ((extrInfo_MAHNB02347E1.EnterpriseCode == extrInfo_MAHNB02347E2.EnterpriseCode)
				 && (extrInfo_MAHNB02347E1.IsSelectAllSection == extrInfo_MAHNB02347E2.IsSelectAllSection)
				 && (extrInfo_MAHNB02347E1.ResultsAddUpSecList == extrInfo_MAHNB02347E2.ResultsAddUpSecList)
				 && (extrInfo_MAHNB02347E1.LogicalDeleteCode == extrInfo_MAHNB02347E2.LogicalDeleteCode)
				 && (extrInfo_MAHNB02347E1.SalesDateSt == extrInfo_MAHNB02347E2.SalesDateSt)
				 && (extrInfo_MAHNB02347E1.SalesDateEd == extrInfo_MAHNB02347E2.SalesDateEd)
				 && (extrInfo_MAHNB02347E1.SearchSlipDateSt == extrInfo_MAHNB02347E2.SearchSlipDateSt)
				 && (extrInfo_MAHNB02347E1.SearchSlipDateEd == extrInfo_MAHNB02347E2.SearchSlipDateEd)
				 && (extrInfo_MAHNB02347E1.ShipmentDaySt == extrInfo_MAHNB02347E2.ShipmentDaySt)
				 && (extrInfo_MAHNB02347E1.ShipmentDayEd == extrInfo_MAHNB02347E2.ShipmentDayEd)
				 && (extrInfo_MAHNB02347E1.CustomerCodeSt == extrInfo_MAHNB02347E2.CustomerCodeSt)
				 && (extrInfo_MAHNB02347E1.CustomerCodeEd == extrInfo_MAHNB02347E2.CustomerCodeEd)
				 && (extrInfo_MAHNB02347E1.SupplierCdSt == extrInfo_MAHNB02347E2.SupplierCdSt)
				 && (extrInfo_MAHNB02347E1.SupplierCdEd == extrInfo_MAHNB02347E2.SupplierCdEd)
				 && (extrInfo_MAHNB02347E1.DebitNoteDiv == extrInfo_MAHNB02347E2.DebitNoteDiv)
				 && (extrInfo_MAHNB02347E1.SalesSlipCd == extrInfo_MAHNB02347E2.SalesSlipCd)
				 && (extrInfo_MAHNB02347E1.SalesSlipNumSt == extrInfo_MAHNB02347E2.SalesSlipNumSt)
				 && (extrInfo_MAHNB02347E1.SalesSlipNumEd == extrInfo_MAHNB02347E2.SalesSlipNumEd)
				 && (extrInfo_MAHNB02347E1.SalesInputCodeSt == extrInfo_MAHNB02347E2.SalesInputCodeSt)
				 && (extrInfo_MAHNB02347E1.SalesInputCodeEd == extrInfo_MAHNB02347E2.SalesInputCodeEd)
				 && (extrInfo_MAHNB02347E1.SalesEmployeeCdSt == extrInfo_MAHNB02347E2.SalesEmployeeCdSt)
				 && (extrInfo_MAHNB02347E1.SalesEmployeeCdEd == extrInfo_MAHNB02347E2.SalesEmployeeCdEd)
				 && (extrInfo_MAHNB02347E1.FrontEmployeeCdSt == extrInfo_MAHNB02347E2.FrontEmployeeCdSt)
				 && (extrInfo_MAHNB02347E1.FrontEmployeeCdEd == extrInfo_MAHNB02347E2.FrontEmployeeCdEd)
				 && (extrInfo_MAHNB02347E1.SalesAreaCodeSt == extrInfo_MAHNB02347E2.SalesAreaCodeSt)
				 && (extrInfo_MAHNB02347E1.SalesAreaCodeEd == extrInfo_MAHNB02347E2.SalesAreaCodeEd)
				 && (extrInfo_MAHNB02347E1.BusinessTypeCodeSt == extrInfo_MAHNB02347E2.BusinessTypeCodeSt)
				 && (extrInfo_MAHNB02347E1.BusinessTypeCodeEd == extrInfo_MAHNB02347E2.BusinessTypeCodeEd)
				 && (extrInfo_MAHNB02347E1.SalesSlipUpdateCd == extrInfo_MAHNB02347E2.SalesSlipUpdateCd)
				 && (extrInfo_MAHNB02347E1.SalesOrderDivCd == extrInfo_MAHNB02347E2.SalesOrderDivCd)
				 && (extrInfo_MAHNB02347E1.WayToOrder == extrInfo_MAHNB02347E2.WayToOrder)
				 && (extrInfo_MAHNB02347E1.GrsProfitCheckLower == extrInfo_MAHNB02347E2.GrsProfitCheckLower)
                 && (extrInfo_MAHNB02347E1.GrossMarginSt == extrInfo_MAHNB02347E2.GrossMarginSt)
                 && (extrInfo_MAHNB02347E1.GrossMargin2Ed == extrInfo_MAHNB02347E2.GrossMargin2Ed)
                 && (extrInfo_MAHNB02347E1.GrossMargin3Ed == extrInfo_MAHNB02347E2.GrossMargin3Ed)
                 && (extrInfo_MAHNB02347E1.GrsProfitCheckBest == extrInfo_MAHNB02347E2.GrsProfitCheckBest)
				 && (extrInfo_MAHNB02347E1.GrsProfitCheckUpper == extrInfo_MAHNB02347E2.GrsProfitCheckUpper)
				 && (extrInfo_MAHNB02347E1.GrossMargin1Mark == extrInfo_MAHNB02347E2.GrossMargin1Mark)
				 && (extrInfo_MAHNB02347E1.GrossMargin2Mark == extrInfo_MAHNB02347E2.GrossMargin2Mark)
				 && (extrInfo_MAHNB02347E1.GrossMargin3Mark == extrInfo_MAHNB02347E2.GrossMargin3Mark)
				 && (extrInfo_MAHNB02347E1.GrossMargin4Mark == extrInfo_MAHNB02347E2.GrossMargin4Mark)
				 && (extrInfo_MAHNB02347E1.ZeroSalesPrint == extrInfo_MAHNB02347E2.ZeroSalesPrint)
				 && (extrInfo_MAHNB02347E1.ZeroCostPrint == extrInfo_MAHNB02347E2.ZeroCostPrint)
				 && (extrInfo_MAHNB02347E1.ZeroGrsProfitPrint == extrInfo_MAHNB02347E2.ZeroGrsProfitPrint)
				 && (extrInfo_MAHNB02347E1.ZeroUdrGrsProfitPrint == extrInfo_MAHNB02347E2.ZeroUdrGrsProfitPrint)
				 && (extrInfo_MAHNB02347E1.GrsProfitRatePrint == extrInfo_MAHNB02347E2.GrsProfitRatePrint)
				 && (extrInfo_MAHNB02347E1.GrsProfitRatePrintVal == extrInfo_MAHNB02347E2.GrsProfitRatePrintVal)
				 && (extrInfo_MAHNB02347E1.GrsProfitRatePrintDiv == extrInfo_MAHNB02347E2.GrsProfitRatePrintDiv)
                 && (extrInfo_MAHNB02347E1.SortOrder == extrInfo_MAHNB02347E2.SortOrder)
                 && (extrInfo_MAHNB02347E1.CostOut == extrInfo_MAHNB02347E2.CostOut)
                 && (extrInfo_MAHNB02347E1.PrintDailyFooter == extrInfo_MAHNB02347E2.PrintDailyFooter) // ADD 2009/04/13
                 && (extrInfo_MAHNB02347E1.NewPageType == extrInfo_MAHNB02347E2.NewPageType)                 
                 // ADD START 3H 尹安 2020/02/27 ---->>>>>
                 && (extrInfo_MAHNB02347E1.TaxPrintDiv == extrInfo_MAHNB02347E2.TaxPrintDiv)
                 && (extrInfo_MAHNB02347E1.TaxRate1 == extrInfo_MAHNB02347E2.TaxRate1)
                 && (extrInfo_MAHNB02347E1.TaxRate2 == extrInfo_MAHNB02347E2.TaxRate2)
                // ADD END 3H 尹安 2020/02/27 ----<<<<<

                 && (extrInfo_MAHNB02347E1.EnterpriseName == extrInfo_MAHNB02347E2.EnterpriseName));
		}
		/// <summary>
		/// 売上確認表検索条件比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_MAHNB02347Eクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_MAHNB02347Eクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Note             :   11570208-00 軽減税率対応</br>
        /// <br>Programer        :   2020/02/27 3H 尹安</br>
		/// </remarks>
        public ArrayList Compare(ExtrInfo_MAHNB02347E target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.IsSelectAllSection != target.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if(this.ResultsAddUpSecList != target.ResultsAddUpSecList)resList.Add("ResultsAddUpSecList");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.SalesDateSt != target.SalesDateSt)resList.Add("SalesDateSt");
			if(this.SalesDateEd != target.SalesDateEd)resList.Add("SalesDateEd");
			if(this.SearchSlipDateSt != target.SearchSlipDateSt)resList.Add("SearchSlipDateSt");
			if(this.SearchSlipDateEd != target.SearchSlipDateEd)resList.Add("SearchSlipDateEd");
			if(this.ShipmentDaySt != target.ShipmentDaySt)resList.Add("ShipmentDaySt");
			if(this.ShipmentDayEd != target.ShipmentDayEd)resList.Add("ShipmentDayEd");
			if(this.CustomerCodeSt != target.CustomerCodeSt)resList.Add("CustomerCodeSt");
			if(this.CustomerCodeEd != target.CustomerCodeEd)resList.Add("CustomerCodeEd");
			if(this.SupplierCdSt != target.SupplierCdSt)resList.Add("SupplierCdSt");
			if(this.SupplierCdEd != target.SupplierCdEd)resList.Add("SupplierCdEd");
			if(this.DebitNoteDiv != target.DebitNoteDiv)resList.Add("DebitNoteDiv");
			if(this.SalesSlipCd != target.SalesSlipCd)resList.Add("SalesSlipCd");
			if(this.SalesSlipNumSt != target.SalesSlipNumSt)resList.Add("SalesSlipNumSt");
			if(this.SalesSlipNumEd != target.SalesSlipNumEd)resList.Add("SalesSlipNumEd");
			if(this.SalesInputCodeSt != target.SalesInputCodeSt)resList.Add("SalesInputCodeSt");
			if(this.SalesInputCodeEd != target.SalesInputCodeEd)resList.Add("SalesInputCodeEd");
			if(this.SalesEmployeeCdSt != target.SalesEmployeeCdSt)resList.Add("SalesEmployeeCdSt");
			if(this.SalesEmployeeCdEd != target.SalesEmployeeCdEd)resList.Add("SalesEmployeeCdEd");
			if(this.FrontEmployeeCdSt != target.FrontEmployeeCdSt)resList.Add("FrontEmployeeCdSt");
			if(this.FrontEmployeeCdEd != target.FrontEmployeeCdEd)resList.Add("FrontEmployeeCdEd");
			if(this.SalesAreaCodeSt != target.SalesAreaCodeSt)resList.Add("SalesAreaCodeSt");
			if(this.SalesAreaCodeEd != target.SalesAreaCodeEd)resList.Add("SalesAreaCodeEd");
			if(this.BusinessTypeCodeSt != target.BusinessTypeCodeSt)resList.Add("BusinessTypeCodeSt");
			if(this.BusinessTypeCodeEd != target.BusinessTypeCodeEd)resList.Add("BusinessTypeCodeEd");
			if(this.SalesSlipUpdateCd != target.SalesSlipUpdateCd)resList.Add("SalesSlipUpdateCd");
			if(this.SalesOrderDivCd != target.SalesOrderDivCd)resList.Add("SalesOrderDivCd");
			if(this.WayToOrder != target.WayToOrder)resList.Add("WayToOrder");
			if(this.GrsProfitCheckLower != target.GrsProfitCheckLower)resList.Add("GrsProfitCheckLower");
            if (this.GrossMarginSt != target.GrossMarginSt) resList.Add("GrossMarginSt");
            if (this.GrossMargin2Ed != target.GrossMargin2Ed) resList.Add("GrossMargin2Ed");
            if (this.GrossMargin3Ed != target.GrossMargin3Ed) resList.Add("GrossMargin3Ed");
            if (this.GrsProfitCheckBest != target.GrsProfitCheckBest) resList.Add("GrsProfitCheckBest");
			if(this.GrsProfitCheckUpper != target.GrsProfitCheckUpper)resList.Add("GrsProfitCheckUpper");
			if(this.GrossMargin1Mark != target.GrossMargin1Mark)resList.Add("GrossMargin1Mark");
			if(this.GrossMargin2Mark != target.GrossMargin2Mark)resList.Add("GrossMargin2Mark");
			if(this.GrossMargin3Mark != target.GrossMargin3Mark)resList.Add("GrossMargin3Mark");
			if(this.GrossMargin4Mark != target.GrossMargin4Mark)resList.Add("GrossMargin4Mark");
			if(this.ZeroSalesPrint != target.ZeroSalesPrint)resList.Add("ZeroSalesPrint");
			if(this.ZeroCostPrint != target.ZeroCostPrint)resList.Add("ZeroCostPrint");
			if(this.ZeroGrsProfitPrint != target.ZeroGrsProfitPrint)resList.Add("ZeroGrsProfitPrint");
			if(this.ZeroUdrGrsProfitPrint != target.ZeroUdrGrsProfitPrint)resList.Add("ZeroUdrGrsProfitPrint");
			if(this.GrsProfitRatePrint != target.GrsProfitRatePrint)resList.Add("GrsProfitRatePrint");
			if(this.GrsProfitRatePrintVal != target.GrsProfitRatePrintVal)resList.Add("GrsProfitRatePrintVal");
			if(this.GrsProfitRatePrintDiv != target.GrsProfitRatePrintDiv)resList.Add("GrsProfitRatePrintDiv");
            if (this.SortOrder != target.SortOrder) resList.Add("SortOrder");
            if (this.CostOut != target.CostOut) resList.Add("CostOut");
            if (this.PrintDailyFooter != target.PrintDailyFooter) resList.Add("PrintDailyFooter"); // ADD 2009/04/13
            if (this.NewPageType != target.NewPageType) resList.Add("NewPageType");
            // ADD START 3H 尹安 2020/02/27 ---->>>>>
            if (this.TaxPrintDiv != target.TaxPrintDiv) resList.Add("TaxPrintDiv");
            if (this.TaxRate1 != target.TaxRate1) resList.Add("TaxRate1");
            if (this.TaxRate2 != target.TaxRate2) resList.Add("TaxRate2");
            // ADD END 3H 尹安 2020/02/27 ----<<<<<
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// 売上確認表検索条件比較処理
		/// </summary>
        /// <param name="extrInfo_MAHNB02347E1">比較するExtrInfo_MAHNB02347Eクラスのインスタンス</param>
        /// <param name="extrInfo_MAHNB02347E2">比較するExtrInfo_MAHNB02347Eクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_MAHNB02347Eクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Note             :   11570208-00 軽減税率対応</br>
        /// <br>Programer        :   2020/02/27 3H 尹安</br>
		/// </remarks>
        public static ArrayList Compare(ExtrInfo_MAHNB02347E extrInfo_MAHNB02347E1, ExtrInfo_MAHNB02347E extrInfo_MAHNB02347E2)
		{
			ArrayList resList = new ArrayList();
			if(extrInfo_MAHNB02347E1.EnterpriseCode != extrInfo_MAHNB02347E2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(extrInfo_MAHNB02347E1.IsSelectAllSection != extrInfo_MAHNB02347E2.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if(extrInfo_MAHNB02347E1.ResultsAddUpSecList != extrInfo_MAHNB02347E2.ResultsAddUpSecList)resList.Add("ResultsAddUpSecList");
			if(extrInfo_MAHNB02347E1.LogicalDeleteCode != extrInfo_MAHNB02347E2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(extrInfo_MAHNB02347E1.SalesDateSt != extrInfo_MAHNB02347E2.SalesDateSt)resList.Add("SalesDateSt");
			if(extrInfo_MAHNB02347E1.SalesDateEd != extrInfo_MAHNB02347E2.SalesDateEd)resList.Add("SalesDateEd");
			if(extrInfo_MAHNB02347E1.SearchSlipDateSt != extrInfo_MAHNB02347E2.SearchSlipDateSt)resList.Add("SearchSlipDateSt");
			if(extrInfo_MAHNB02347E1.SearchSlipDateEd != extrInfo_MAHNB02347E2.SearchSlipDateEd)resList.Add("SearchSlipDateEd");
			if(extrInfo_MAHNB02347E1.ShipmentDaySt != extrInfo_MAHNB02347E2.ShipmentDaySt)resList.Add("ShipmentDaySt");
			if(extrInfo_MAHNB02347E1.ShipmentDayEd != extrInfo_MAHNB02347E2.ShipmentDayEd)resList.Add("ShipmentDayEd");
			if(extrInfo_MAHNB02347E1.CustomerCodeSt != extrInfo_MAHNB02347E2.CustomerCodeSt)resList.Add("CustomerCodeSt");
			if(extrInfo_MAHNB02347E1.CustomerCodeEd != extrInfo_MAHNB02347E2.CustomerCodeEd)resList.Add("CustomerCodeEd");
			if(extrInfo_MAHNB02347E1.SupplierCdSt != extrInfo_MAHNB02347E2.SupplierCdSt)resList.Add("SupplierCdSt");
			if(extrInfo_MAHNB02347E1.SupplierCdEd != extrInfo_MAHNB02347E2.SupplierCdEd)resList.Add("SupplierCdEd");
			if(extrInfo_MAHNB02347E1.DebitNoteDiv != extrInfo_MAHNB02347E2.DebitNoteDiv)resList.Add("DebitNoteDiv");
			if(extrInfo_MAHNB02347E1.SalesSlipCd != extrInfo_MAHNB02347E2.SalesSlipCd)resList.Add("SalesSlipCd");
			if(extrInfo_MAHNB02347E1.SalesSlipNumSt != extrInfo_MAHNB02347E2.SalesSlipNumSt)resList.Add("SalesSlipNumSt");
			if(extrInfo_MAHNB02347E1.SalesSlipNumEd != extrInfo_MAHNB02347E2.SalesSlipNumEd)resList.Add("SalesSlipNumEd");
			if(extrInfo_MAHNB02347E1.SalesInputCodeSt != extrInfo_MAHNB02347E2.SalesInputCodeSt)resList.Add("SalesInputCodeSt");
			if(extrInfo_MAHNB02347E1.SalesInputCodeEd != extrInfo_MAHNB02347E2.SalesInputCodeEd)resList.Add("SalesInputCodeEd");
			if(extrInfo_MAHNB02347E1.SalesEmployeeCdSt != extrInfo_MAHNB02347E2.SalesEmployeeCdSt)resList.Add("SalesEmployeeCdSt");
			if(extrInfo_MAHNB02347E1.SalesEmployeeCdEd != extrInfo_MAHNB02347E2.SalesEmployeeCdEd)resList.Add("SalesEmployeeCdEd");
			if(extrInfo_MAHNB02347E1.FrontEmployeeCdSt != extrInfo_MAHNB02347E2.FrontEmployeeCdSt)resList.Add("FrontEmployeeCdSt");
			if(extrInfo_MAHNB02347E1.FrontEmployeeCdEd != extrInfo_MAHNB02347E2.FrontEmployeeCdEd)resList.Add("FrontEmployeeCdEd");
			if(extrInfo_MAHNB02347E1.SalesAreaCodeSt != extrInfo_MAHNB02347E2.SalesAreaCodeSt)resList.Add("SalesAreaCodeSt");
			if(extrInfo_MAHNB02347E1.SalesAreaCodeEd != extrInfo_MAHNB02347E2.SalesAreaCodeEd)resList.Add("SalesAreaCodeEd");
			if(extrInfo_MAHNB02347E1.BusinessTypeCodeSt != extrInfo_MAHNB02347E2.BusinessTypeCodeSt)resList.Add("BusinessTypeCodeSt");
			if(extrInfo_MAHNB02347E1.BusinessTypeCodeEd != extrInfo_MAHNB02347E2.BusinessTypeCodeEd)resList.Add("BusinessTypeCodeEd");
			if(extrInfo_MAHNB02347E1.SalesSlipUpdateCd != extrInfo_MAHNB02347E2.SalesSlipUpdateCd)resList.Add("SalesSlipUpdateCd");
			if(extrInfo_MAHNB02347E1.SalesOrderDivCd != extrInfo_MAHNB02347E2.SalesOrderDivCd)resList.Add("SalesOrderDivCd");
			if(extrInfo_MAHNB02347E1.WayToOrder != extrInfo_MAHNB02347E2.WayToOrder)resList.Add("WayToOrder");
			if(extrInfo_MAHNB02347E1.GrsProfitCheckLower != extrInfo_MAHNB02347E2.GrsProfitCheckLower)resList.Add("GrsProfitCheckLower");
            if (extrInfo_MAHNB02347E1.GrossMarginSt != extrInfo_MAHNB02347E2.GrossMarginSt) resList.Add("GrossMarginSt");
            if (extrInfo_MAHNB02347E1.GrossMargin2Ed != extrInfo_MAHNB02347E2.GrossMargin2Ed) resList.Add("GrossMargin2Ed");
            if (extrInfo_MAHNB02347E1.GrossMargin3Ed != extrInfo_MAHNB02347E2.GrossMargin3Ed) resList.Add("GrossMargin3Ed");
            if (extrInfo_MAHNB02347E1.GrsProfitCheckBest != extrInfo_MAHNB02347E2.GrsProfitCheckBest) resList.Add("GrsProfitCheckBest");
			if(extrInfo_MAHNB02347E1.GrsProfitCheckUpper != extrInfo_MAHNB02347E2.GrsProfitCheckUpper)resList.Add("GrsProfitCheckUpper");
			if(extrInfo_MAHNB02347E1.GrossMargin1Mark != extrInfo_MAHNB02347E2.GrossMargin1Mark)resList.Add("GrossMargin1Mark");
			if(extrInfo_MAHNB02347E1.GrossMargin2Mark != extrInfo_MAHNB02347E2.GrossMargin2Mark)resList.Add("GrossMargin2Mark");
			if(extrInfo_MAHNB02347E1.GrossMargin3Mark != extrInfo_MAHNB02347E2.GrossMargin3Mark)resList.Add("GrossMargin3Mark");
			if(extrInfo_MAHNB02347E1.GrossMargin4Mark != extrInfo_MAHNB02347E2.GrossMargin4Mark)resList.Add("GrossMargin4Mark");
			if(extrInfo_MAHNB02347E1.ZeroSalesPrint != extrInfo_MAHNB02347E2.ZeroSalesPrint)resList.Add("ZeroSalesPrint");
			if(extrInfo_MAHNB02347E1.ZeroCostPrint != extrInfo_MAHNB02347E2.ZeroCostPrint)resList.Add("ZeroCostPrint");
			if(extrInfo_MAHNB02347E1.ZeroGrsProfitPrint != extrInfo_MAHNB02347E2.ZeroGrsProfitPrint)resList.Add("ZeroGrsProfitPrint");
			if(extrInfo_MAHNB02347E1.ZeroUdrGrsProfitPrint != extrInfo_MAHNB02347E2.ZeroUdrGrsProfitPrint)resList.Add("ZeroUdrGrsProfitPrint");
			if(extrInfo_MAHNB02347E1.GrsProfitRatePrint != extrInfo_MAHNB02347E2.GrsProfitRatePrint)resList.Add("GrsProfitRatePrint");
			if(extrInfo_MAHNB02347E1.GrsProfitRatePrintVal != extrInfo_MAHNB02347E2.GrsProfitRatePrintVal)resList.Add("GrsProfitRatePrintVal");
			if(extrInfo_MAHNB02347E1.GrsProfitRatePrintDiv != extrInfo_MAHNB02347E2.GrsProfitRatePrintDiv)resList.Add("GrsProfitRatePrintDiv");
            if (extrInfo_MAHNB02347E1.SortOrder != extrInfo_MAHNB02347E2.SortOrder) resList.Add("SortOrder");
            if (extrInfo_MAHNB02347E1.CostOut != extrInfo_MAHNB02347E2.CostOut) resList.Add("CostOut");
            if (extrInfo_MAHNB02347E1.PrintDailyFooter != extrInfo_MAHNB02347E2.PrintDailyFooter) resList.Add("PrintDailyFooter"); // ADD 2009/04/13
            if (extrInfo_MAHNB02347E1.NewPageType != extrInfo_MAHNB02347E2.NewPageType) resList.Add("NewPageType");
            // ADD START 3H 尹安 2020/02/27 ---->>>>>
            if (extrInfo_MAHNB02347E1.TaxPrintDiv != extrInfo_MAHNB02347E2.TaxPrintDiv) resList.Add("TaxPrintDiv");
            if (extrInfo_MAHNB02347E1.TaxRate1 != extrInfo_MAHNB02347E2.TaxRate1) resList.Add("TaxRate1");
            if (extrInfo_MAHNB02347E1.TaxRate2 != extrInfo_MAHNB02347E2.TaxRate2) resList.Add("TaxRate2");
            // ADD END 3H 尹安 2020/02/27 ----<<<<<            
            if (extrInfo_MAHNB02347E1.EnterpriseName != extrInfo_MAHNB02347E2.EnterpriseName) resList.Add("EnterpriseName");

			return resList;
		}
	}
}
