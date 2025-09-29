using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 受注出荷確認表抽出条件クラス
	/// </summary>
	/// <returns>ExtrInfo_DCHNB02013Eクラスのインスタンス</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   自身の内容と等しいExtrInfo_DCHNB02013Eクラスのインスタンスを返します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>

	/// public class name:   ExtrInfo_DCHNB02013E
	/// <summary>
	///                      受注出荷確認表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// 受注出荷確認表抽出条件クラスヘッダファイル
	/// </remarks>
	public class ExtrInfo_DCHNB02013E
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>全社選択</summary>
		/// <remarks>true:全社選択 false:各拠点選択</remarks>
		private Boolean _isSelectAllSection;

		/// <summary>全拠点レコード出力</summary>
		/// <remarks>true:全拠点レコードを出力する。false:全拠点レコードを出力しない</remarks>
		private Boolean _isOutputAllSecRec;

		/// <summary>実績計上拠点コードリスト</summary>
		/// <remarks>文字型　※配列項目</remarks>
		private string[] _resultsAddUpSecList;

		/// <summary>受注ステータス[共通]</summary>
		private Int32 _acptAnOdrStatus;

		/// <summary>売上（受注）日付(開始)</summary>
		private Int32 _salesDateSt;

		/// <summary>売上（受注）日付(終了)</summary>
		private Int32 _salesDateEd;

		/// <summary>出荷日付(開始)</summary>
		private Int32 _shipmentDaySt;

		/// <summary>出荷日付(終了)</summary>
		private Int32 _shipmentDayEd;

		/// <summary>入力日付(開始)</summary>
		private Int32 _searchSlipDateSt;

		/// <summary>入力日付(終了)</summary>
		private Int32 _searchSlipDateEd;

		/// <summary>得意先コード(開始)</summary>
		private Int32 _customerCodeSt;

		/// <summary>得意先コード(終了)</summary>
		private Int32 _customerCodeEd;

		/// <summary>販売従業員（担当）コード(開始)</summary>
		private string _salesEmployeeCdSt = "";

		/// <summary>販売従業員（担当）コード(終了)</summary>
		private string _salesEmployeeCdEd = "";

		/// <summary>売上伝票番号[伝票]</summary>
		private string _salesSlipNum = "";

		/// <summary>赤伝区分[共通]</summary>
		private Int32 _debitNoteDiv;

		/// <summary>売上伝票区分[伝票]</summary>
		/// <remarks>0:売上,1:返品</remarks>
		private Int32 _salesSlipCd;

		/// <summary>売上伝票区分[明細]</summary>
		/// <remarks>0:売上,1:返品,2:値引,9:一式</remarks>
		private Int32 _salesSlipCdDtl;

		/// <summary>粗利チェック下限</summary>
		/// <remarks>粗利チェックの下限値（％で入力）　XX.X％　以上</remarks>
		private Double _grsProfitCheckLower;

		/// <summary>粗利チェック適正</summary>
		/// <remarks>粗利チェックの適正値（％で入力）　XX.X％　以上</remarks>
		private Double _grsProfitCheckBest;

		/// <summary>粗利チェック上限</summary>
		/// <remarks>粗利チェックの上限値（％で入力）　XX.X％　以上</remarks>
		private Double _grsProfitCheckUpper;

		/// <summary>粗利チェック2</summary>
		/// <remarks>粗利チェック2　XX.X％　以上</remarks>
		private Double _grossMarginLow2;

		/// <summary>粗利チェック3</summary>
		/// <remarks>粗利チェック3　XX.X％　以上</remarks>
		private Double _grossMarginBest2;

		/// <summary>粗利チェック4</summary>
		/// <remarks>粗利チェック4　XX.X％　以上</remarks>
		private Double _grossMarginUpper2;

		/// <summary>粗利チェックマーク1</summary>
		private string _grossMargin1Mark = "";

		/// <summary>粗利チェックマーク2</summary>
		private string _grossMargin2Mark = "";

		/// <summary>粗利チェックマーク3</summary>
		private string _grossMargin3Mark = "";

		/// <summary>粗利チェックマーク4</summary>
		private string _grossMargin4Mark = "";

        /// <summary>発行タイプ</summary>
        /// <remarks>0:受注,1:受注計上済み,2:貸出,3:貸出計上済み</remarks>
        private Int32 _publicationType;

        /// <summary>改頁</summary>
        private Int32 _newPageType;

		/// <summary>出力順</summary>
		private Int32 _sortOrder;

		/// <summary>帳票タイプ区分</summary>
		/// <remarks>（帳票のマスメン）『用途』項目と同じ</remarks>
		private Int32 _printDiv;

		/// <summary>帳票タイプ区分名称</summary>
		private string _printDivName = "";

        // --- ADD 2009/03/30 -------------------------------->>>>>
        /// <summary>原価・粗利出力</summary>
        private Int32 _costOut;

        /// <summary>日計印字</summary>
        private Int32 _printDailyFooter;
        // --- ADD 2009/03/30 --------------------------------<<<<<

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
			get { return _enterpriseCode; }
			set { _enterpriseCode = value; }
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

		/// public propaty name  :  ResultsAddUpSecList
		/// <summary>実績計上拠点コードリストプロパティ</summary>
		/// <value>文字型　※配列項目</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   実績計上拠点コードリストプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] ResultsAddUpSecList
		{
			get { return _resultsAddUpSecList; }
			set { _resultsAddUpSecList = value; }
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>受注ステータスプロパティ</summary>
		/// <value>20:受注 40:出荷</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注ステータスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcptAnOdrStatus
		{
			get { return _acptAnOdrStatus; }
			set { _acptAnOdrStatus = value; }
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
			get { return _salesDateSt; }
			set { _salesDateSt = value; }
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
			get { return _salesDateEd; }
			set { _salesDateEd = value; }
		}

		/// public propaty name  :  ShipmentDaySt
		/// <summary>出荷日付(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷日付(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ShipmentDaySt
		{
			get { return _shipmentDaySt; }
			set { _shipmentDaySt = value; }
		}

		/// public propaty name  :  ShipmentDayEd
		/// <summary>出荷日付(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷日付(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ShipmentDayEd
		{
			get { return _shipmentDayEd; }
			set { _shipmentDayEd = value; }
		}

		/// public propaty name  :  SearchSlipDateSt
		/// <summary>入力日付(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日付(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SearchSlipDateSt
		{
			get { return _searchSlipDateSt; }
			set { _searchSlipDateSt = value; }
		}

		/// public propaty name  :  SearchSlipDateEd
		/// <summary>入力日付(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日付(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SearchSlipDateEd
		{
			get { return _searchSlipDateEd; }
			set { _searchSlipDateEd = value; }
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
			get { return _customerCodeSt; }
			set { _customerCodeSt = value; }
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
			get { return _customerCodeEd; }
			set { _customerCodeEd = value; }
		}

		/// public propaty name  :  SalesEmployeeCdSt
		/// <summary>販売従業員コード(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売従業員コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesEmployeeCdSt
		{
			get { return _salesEmployeeCdSt; }
			set { _salesEmployeeCdSt = value; }
		}

		/// public propaty name  :  SalesEmployeeCdEd
		/// <summary>販売従業員コード(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売従業員コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesEmployeeCdEd
		{
			get { return _salesEmployeeCdEd; }
			set { _salesEmployeeCdEd = value; }
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
			get { return _debitNoteDiv; }
			set { _debitNoteDiv = value; }
		}

		/// public propaty name  :  SalesSlipCd
		/// <summary>売上伝票区分プロパティ</summary>
		/// <value>0:売上,1:返品　※全ては-1</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesSlipCd
		{
			get { return _salesSlipCd; }
			set { _salesSlipCd = value; }
		}

		/// public propaty name  :  SalesSlipCdDtl
		/// <summary>売上伝票区分[明細]プロパティ</summary>
		/// <value>0:売上,1:返品,2:値引,9:一式</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票区分[明細]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesSlipCdDtl
		{
			get { return _salesSlipCdDtl; }
			set { _salesSlipCdDtl = value; }
		}

		/// public propaty name  :  SalesSlipNum
		/// <summary>売上伝票番号[伝票]プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票番号[伝票]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesSlipNum
		{
			get { return _salesSlipNum; }
			set { _salesSlipNum = value; }
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
			get { return _grsProfitCheckLower; }
			set { _grsProfitCheckLower = value; }
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
			get { return _grsProfitCheckBest; }
			set { _grsProfitCheckBest = value; }
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
			get { return _grsProfitCheckUpper; }
			set { _grsProfitCheckUpper = value; }
		}

		/// public propaty name  :  GrsProfitCheckLower
		/// <summary>粗利チェック2プロパティ</summary>
		/// <value>粗利チェック2の値（％で入力）　XX.X％　以上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double GrossMarginLow2
		{
			get { return _grossMarginLow2; }
			set { _grossMarginLow2 = value; }
		}

		/// public propaty name  :  GrsProfitCheckLower
		/// <summary>粗利チェック3プロパティ</summary>
		/// <value>粗利チェック3の値（％で入力）　XX.X％　以上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double GrossMarginBest2
		{
			get { return _grossMarginBest2; }
			set { _grossMarginBest2 = value; }
		}

		/// public propaty name  :  GrsProfitCheckLower
		/// <summary>粗利チェック4プロパティ</summary>
		/// <value>粗利チェック4の値（％で入力）　XX.X％　以上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double GrossMarginUpper2
		{
			get { return _grossMarginUpper2; }
			set { _grossMarginUpper2 = value; }
		}

		/// public propaty name  :  GrossMargin1Mark
		/// <summary>粗利チェックマーク1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック1(マーク)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GrossMargin1Mark
		{
			get { return _grossMargin1Mark; }
			set { _grossMargin1Mark = value; }
		}

		/// public propaty name  :  GrossMargin2Mark
		/// <summary>粗利チェックマーク2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック2(マーク)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GrossMargin2Mark
		{
			get { return _grossMargin2Mark; }
			set { _grossMargin2Mark = value; }
		}

		/// public propaty name  :  GrossMargin3Mark
		/// <summary>粗利チェックマーク3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック3(マーク)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GrossMargin3Mark
		{
			get { return _grossMargin3Mark; }
			set { _grossMargin3Mark = value; }
		}

		/// public propaty name  :  GrossMargin4Mark
        /// <summary>発行タイププロパティ</summary>
        /// <value>0:受注,1:受注計上済み,2:貸出,3:貸出計上済み</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
		public string GrossMargin4Mark
		{
			get { return _grossMargin4Mark; }
			set { _grossMargin4Mark = value; }
		}

        /// public propaty name  :  PublicationType
        /// <summary>帳票タイプ区分プロパティ</summary>
        /// <value>1:受注確認表(合計) 2:受注確認表(明細) 3:出荷確認表(合計)  4:出荷確認表(明細)</value>
        /// -----------------------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票タイプ区分プロパティ</br>
        /// <br>Programer        :   Ai Mabuchi</br>
        /// </remarks>
        public Int32 PublicationType
        {
            get { return _publicationType; }
            set { _publicationType = value; }
        }

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
		/// <summary>帳票タイプ区分プロパティ</summary>
		/// <value>1:受注確認表(合計) 2:受注確認表(明細) 3:出荷確認表(合計)  4:出荷確認表(明細)</value>
		/// -----------------------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票タイプ区分プロパティ</br>
		/// <br>Programer        :   Ai Mabuchi</br>
		/// </remarks>
		public Int32 PrintDiv
		{
			get { return _printDiv; }
			set { _printDiv = value; }
		}

		/// public propaty name  :  PrintDivName
		/// <summary>帳票タイプ区分名称プロパティ</summary>
		/// -------------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票タイプ区分名称プロパティ</br>
		/// <br>Programer        :   Ai Mabuchi</br>
		/// </remarks>
		public string PrintDivName
		{
			get { return _printDivName; }
			set { _printDivName = value; }
		}

		//-------------------------------------------------------------------------------------

        // --- ADD 2009/03/30 -------------------------------->>>>>
        /// public propaty name  :  CostOut
        /// <summary>原価・粗利出力プロパティ</summary>
        /// -------------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価・粗利出力プロパティ</br>
        /// <br>Programer        :   Ai Mabuchi</br>
        /// </remarks>
        public Int32 CostOut
        {
            get { return _costOut; }
            set { _costOut = value; }
        }

        /// public propaty name  :  PrindDailyFooter
        /// <summary>日計印字プロパティ</summary>
        /// -------------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   日計印字プロパティ</br>
        /// <br>Programer        :   Ai Mabuchi</br>
        /// </remarks>
        public Int32 PrintDailyFooter
        {
            get { return _printDailyFooter; }
            set { _printDailyFooter = value; }
        }
        // --- ADD 2009/03/30 --------------------------------<<<<<

		#region 帳票タイプ区分列挙
		/// <summary>帳票タイプ区分列挙</summary>
		public enum PrintDivState
		{
			///<summary>伝票形式</summary>
			Slipform = 1,
			///<summary>明細形式</summary>
			Detialform = 2

		}
		#endregion

		/// <summary>
		/// 受注出荷確認表抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_DCHNB02013Eクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DCHNB02013Eクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_DCHNB02013E()
		{
		}

		/// <summary>
		/// 受注出荷確認表抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>		
		/// <param name="isSelectAllSection">全社選択(true:全社選択 false:各拠点選択)</param>
		/// <param name="isOutputAllSecRec">全拠点レコード出力(true:全拠点レコードを出力する。false:全拠点レコードを出力しない)</param>
		/// <param name="resultsAddUpSecList">実績計上拠点コードリスト(文字型　※配列項目)</param>
		/// <param name="acptAnOdrStatus">受注ステータス(20:受注 40:出荷)</param>
		/// <param name="salesDateSt">売上日付(開始)</param>
		/// <param name="salesDateEd">売上日付(終了)</param>
		/// <param name="shipmentDaySt">出荷日付(開始)</param>
		/// <param name="shipmentDayEd">出荷日付(終了)</param>
		/// <param name="searchSlipDateSt">入力日付(開始)</param>
		/// <param name="searchSlipDateEd">入力日付(終了)</param>
		/// <param name="customerCodeSt">得意先コード(開始)</param>
		/// <param name="customerCodeEd">得意先コード(終了)</param>
		/// <param name="salesEmployeeCdSt">販売従業員（担当者）コード(開始)</param>
		/// <param name="salesEmployeeCdEd">販売従業員（担当者）コード(終了)</param>
		/// <param name="debitNoteDiv">赤伝区分(0:黒伝,1:赤伝,2:元黒　　※全ては-1)</param>
		/// <param name="salesSlipCd">売上伝票区分(0:売上,1:返品　※全ては-1)</param>
		/// <param name="salesSlipCdDtl">売上伝票区分(0:売上,1:返品,2:値引,9:一式)</param>
		/// <param name="grsProfitCheckLower">粗利チェック下限(粗利チェックの下限値（％で入力）　XX.X％　以上)</param>
		/// <param name="grsProfitCheckBest">粗利チェック適正(粗利チェックの適正値（％で入力）　XX.X％　以上)</param>
		/// <param name="grsProfitCheckUpper">粗利チェック上限(粗利チェックの上限値（％で入力）　XX.X％　以上)</param>
		/// <param name="grossMargin1St">粗利チェック2(粗利チェック2の値（％で入力）　XX.X％　以上)</param>
		/// <param name="grossMargin2Ed">粗利チェック3(粗利チェック3の値（％で入力）　XX.X％　以上)</param>
		/// <param name="grossMargin3Ed">粗利チェック4(粗利チェック4の値（％で入力）　XX.X％　以上)</param>
		/// <param name="grossMargin1Mark">粗利チェックマーク1</param>
		/// <param name="grossMargin2Mark">粗利チェックマーク2</param>
		/// <param name="grossMargin3Mark">粗利チェックマーク3</param>
		/// <param name="grossMargin4Mark">粗利チェックマーク4</param>
        /// <param name="publicationType">発行タイプ</param>
        /// <param name="newPageType">改頁</param>
        /// <param name="sortOrder">出力順</param>
		/// <param name="printDiv">帳票タイプ区分</param>
		/// <param name="printDivName">帳票タイプ区分名称</param>
        /// <param name="constOut">原価・粗利出力</param>
        /// <param name="printDailyFooter">日計印字</param>

		/// <returns>ExtrInfo_DCHNB02013Eクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DCHNB02013Eクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>

		public ExtrInfo_DCHNB02013E(string enterpriseCode, Boolean isSelectAllSection, Boolean isOutputAllSecRec, string[] resultsAddUpSecList, Int32 acptAnOdrStatus, Int32 salesDateSt, Int32 salesDateEd, Int32 shipmentDaySt, Int32 shipmentDayEd, Int32 searchSlipDateSt, Int32 searchSlipDateEd, Int32 customerCodeSt, Int32 customerCodeEd, string salesEmployeeCdSt, string salesEmployeeCdEd, Int32 debitNoteDiv, Int32 salesSlipCd, Int32 salesSlipCdDtl, Double grsProfitCheckLower, Double grsProfitCheckBest, Double grsProfitCheckUpper, Double grossMargin1St, Double grossMargin2Ed, Double grossMargin3Ed, string grossMargin1Mark, string grossMargin2Mark, string grossMargin3Mark, string grossMargin4Mark, Int32 publicationType, Int32 newPageType, Int32 sortOrder , Int32 printDiv, string printDivName, Int32 constOut, Int32 printDailyFooter)
		{
			this._enterpriseCode = enterpriseCode;
			this._isSelectAllSection = isSelectAllSection;
			this._isOutputAllSecRec = isOutputAllSecRec;
			this._resultsAddUpSecList = resultsAddUpSecList;
			this._acptAnOdrStatus = acptAnOdrStatus;
			this._salesDateSt = salesDateSt;
			this._salesDateEd = salesDateEd;
			this._shipmentDaySt = shipmentDaySt;
			this._shipmentDayEd = shipmentDayEd;
			this._searchSlipDateSt = searchSlipDateSt;
			this._searchSlipDateEd = searchSlipDateEd;
			this._customerCodeSt = customerCodeSt;
			this._customerCodeEd = customerCodeEd;
			this._salesEmployeeCdSt = salesEmployeeCdSt;
			this._salesEmployeeCdEd = salesEmployeeCdEd;
			this._debitNoteDiv = debitNoteDiv;
			this._salesSlipCd = salesSlipCd;
			this._salesSlipCdDtl = salesSlipCdDtl;
			this._grsProfitCheckLower = grsProfitCheckLower;
			this._grsProfitCheckBest = grsProfitCheckBest;
			this._grsProfitCheckUpper = grsProfitCheckUpper;
			this._grossMarginLow2 = grossMargin1St;
			this._grossMarginBest2 = grossMargin2Ed;
			this._grossMarginUpper2 = grossMargin3Ed;
			this._grossMargin1Mark = grossMargin1Mark;
			this._grossMargin2Mark = grossMargin2Mark;
			this._grossMargin3Mark = grossMargin3Mark;
			this._grossMargin4Mark = grossMargin4Mark;
            this._publicationType = publicationType;
            this._newPageType = newPageType;
			this._sortOrder = sortOrder;
			this._printDiv = printDiv;
			this._printDivName = printDivName;
            // --- ADD 2009/03/30 -------------------------------->>>>>
            this._costOut = constOut;
            this._printDailyFooter = printDailyFooter;
            // --- ADD 2009/03/30 --------------------------------<<<<<

		}

		/// <summary>
		/// 受注出荷確認表抽出条件クラス複製処理
		/// </summary>
		/// <returns>ExtrInfo_DCHNB02013Eクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいExtrInfo_DCHNB02013Eクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_DCHNB02013E Clone()
		{
			return new ExtrInfo_DCHNB02013E(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._resultsAddUpSecList, this._acptAnOdrStatus, this._salesDateSt, this._salesDateEd, this._shipmentDaySt, this._shipmentDayEd, this._searchSlipDateSt, this._searchSlipDateEd, this._customerCodeSt, this._customerCodeEd, this._salesEmployeeCdSt, this._salesEmployeeCdEd, this._debitNoteDiv, this._salesSlipCd, this._salesSlipCdDtl, this._grsProfitCheckLower, this._grsProfitCheckBest, this._grsProfitCheckUpper, this._grossMarginLow2, this._grossMarginBest2, this._grossMarginUpper2, this._grossMargin1Mark, this._grossMargin2Mark, this._grossMargin3Mark, this._grossMargin4Mark, this._publicationType, this._newPageType, this._sortOrder , this._printDiv, this._printDivName, this._costOut, this._printDailyFooter);
		}

		/// <summary>
		/// 受注出荷確認表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_DCHNB02013Eクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DCHNB02013Eクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ExtrInfo_DCHNB02013E target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.IsSelectAllSection == target.IsSelectAllSection)
				 && (this.IsOutputAllSecRec == target.IsOutputAllSecRec)
				 && (this.ResultsAddUpSecList == target.ResultsAddUpSecList)
				 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
				 && (this.SalesDateSt == target.SalesDateSt)
				 && (this.SalesDateEd == target.SalesDateEd)
				 && (this.ShipmentDaySt == target.ShipmentDaySt)
				 && (this.ShipmentDayEd == target.ShipmentDayEd)
				 && (this.SearchSlipDateSt == target.SearchSlipDateSt)
				 && (this.SearchSlipDateEd == target.SearchSlipDateEd)
				 && (this.CustomerCodeSt == target.CustomerCodeSt)
				 && (this.SalesEmployeeCdSt == target.SalesEmployeeCdSt)
				 && (this.SalesEmployeeCdEd == target.SalesEmployeeCdEd)
				 && (this.DebitNoteDiv == target.DebitNoteDiv)
				 && (this.SalesSlipCd == target.SalesSlipCd)
				 && (this.SalesSlipCdDtl == target.SalesSlipCdDtl)
				 && (this.GrsProfitCheckLower == target.GrsProfitCheckLower)
				 && (this.GrsProfitCheckBest == target.GrsProfitCheckBest)
				 && (this.GrsProfitCheckUpper == target.GrsProfitCheckUpper)
				 && (this._grossMarginLow2 == target._grossMarginLow2)
				 && (this._grossMarginBest2 == target._grossMarginBest2)
				 && (this._grossMarginUpper2 == target._grossMarginUpper2)
				 && (this.GrossMargin1Mark == target.GrossMargin1Mark)
				 && (this.GrossMargin2Mark == target.GrossMargin2Mark)
				 && (this.GrossMargin3Mark == target.GrossMargin3Mark)
				 && (this.GrossMargin4Mark == target.GrossMargin4Mark)
                 && (this.PublicationType == target.PublicationType)
                 && (this.NewPageType == target.NewPageType)
				 && (this.SortOrder == target.SortOrder)
				 && (this.PrintDiv == target.PrintDiv)
				 && (this.PrintDivName == target.PrintDivName)
                // --- ADD 2009/03/30 -------------------------------->>>>>
                && (this.CostOut == target.CostOut)
                && (this.PrintDailyFooter == target.PrintDailyFooter)
                // --- ADD 2009/03/30 --------------------------------<<<<<
				 );

		}

		/// <summary>
		/// 受注出荷確認表抽出条件クラス比較処理
		/// </summary>
		/// <param name="extrInfo_DCHNB02013E1">
		///                    比較するExtrInfo_DCHNB02013Eクラスのインスタンス
		/// </param>
		/// <param name="extrInfo_DCHNB02013E2">比較するExtrInfo_DCHNB02013Eクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DCHNB02013Eクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ExtrInfo_DCHNB02013E extrInfo_DCHNB02013E1, ExtrInfo_DCHNB02013E extrInfo_DCHNB02013E2)
		{
			return ((extrInfo_DCHNB02013E1.EnterpriseCode == extrInfo_DCHNB02013E2.EnterpriseCode)
				 && (extrInfo_DCHNB02013E1.IsSelectAllSection == extrInfo_DCHNB02013E2.IsSelectAllSection)
				 && (extrInfo_DCHNB02013E1.IsOutputAllSecRec == extrInfo_DCHNB02013E2.IsOutputAllSecRec)
				 && (extrInfo_DCHNB02013E1.ResultsAddUpSecList == extrInfo_DCHNB02013E2.ResultsAddUpSecList)
				 && (extrInfo_DCHNB02013E1.AcptAnOdrStatus == extrInfo_DCHNB02013E2.AcptAnOdrStatus)
				 && (extrInfo_DCHNB02013E1.SalesDateSt == extrInfo_DCHNB02013E2.SalesDateSt)
				 && (extrInfo_DCHNB02013E1.SalesDateEd == extrInfo_DCHNB02013E2.SalesDateEd)
				 && (extrInfo_DCHNB02013E1.ShipmentDaySt == extrInfo_DCHNB02013E2.ShipmentDaySt)
				 && (extrInfo_DCHNB02013E1.ShipmentDayEd == extrInfo_DCHNB02013E2.ShipmentDayEd)
				 && (extrInfo_DCHNB02013E1.SearchSlipDateSt == extrInfo_DCHNB02013E2.SearchSlipDateSt)
				 && (extrInfo_DCHNB02013E1.SearchSlipDateEd == extrInfo_DCHNB02013E2.SearchSlipDateEd)
				 && (extrInfo_DCHNB02013E1.CustomerCodeSt == extrInfo_DCHNB02013E2.CustomerCodeSt)
				 && (extrInfo_DCHNB02013E1.CustomerCodeEd == extrInfo_DCHNB02013E2.CustomerCodeEd)
				 && (extrInfo_DCHNB02013E1.SalesEmployeeCdSt == extrInfo_DCHNB02013E2.SalesEmployeeCdSt)
				 && (extrInfo_DCHNB02013E1.SalesEmployeeCdEd == extrInfo_DCHNB02013E2.SalesEmployeeCdEd)
				 && (extrInfo_DCHNB02013E1.DebitNoteDiv == extrInfo_DCHNB02013E2.DebitNoteDiv)
				 && (extrInfo_DCHNB02013E1.SalesSlipCd == extrInfo_DCHNB02013E2.SalesSlipCd)
				 && (extrInfo_DCHNB02013E1.SalesSlipCdDtl == extrInfo_DCHNB02013E2.SalesSlipCdDtl)
				 && (extrInfo_DCHNB02013E1.GrsProfitCheckLower == extrInfo_DCHNB02013E2.GrsProfitCheckLower)
				 && (extrInfo_DCHNB02013E1.GrsProfitCheckBest == extrInfo_DCHNB02013E2.GrsProfitCheckBest)
				 && (extrInfo_DCHNB02013E1.GrsProfitCheckUpper == extrInfo_DCHNB02013E2.GrsProfitCheckUpper)
				 && (extrInfo_DCHNB02013E1.GrossMarginLow2 == extrInfo_DCHNB02013E2.GrossMarginLow2)
				 && (extrInfo_DCHNB02013E1.GrossMarginBest2 == extrInfo_DCHNB02013E2.GrossMarginBest2)
				 && (extrInfo_DCHNB02013E1.GrossMarginUpper2 == extrInfo_DCHNB02013E2.GrossMarginUpper2)
				 && (extrInfo_DCHNB02013E1.GrossMargin1Mark == extrInfo_DCHNB02013E2.GrossMargin1Mark)
				 && (extrInfo_DCHNB02013E1.GrossMargin2Mark == extrInfo_DCHNB02013E2.GrossMargin2Mark)
				 && (extrInfo_DCHNB02013E1.GrossMargin3Mark == extrInfo_DCHNB02013E2.GrossMargin3Mark)
				 && (extrInfo_DCHNB02013E1.GrossMargin4Mark == extrInfo_DCHNB02013E2.GrossMargin4Mark)
                 && (extrInfo_DCHNB02013E1.PublicationType == extrInfo_DCHNB02013E2.PublicationType)
                 && (extrInfo_DCHNB02013E1.NewPageType == extrInfo_DCHNB02013E2.NewPageType)
				 && (extrInfo_DCHNB02013E1.SortOrder == extrInfo_DCHNB02013E2.SortOrder)
				 && (extrInfo_DCHNB02013E1.PrintDiv == extrInfo_DCHNB02013E2.PrintDiv)
				 && (extrInfo_DCHNB02013E1.PrintDivName == extrInfo_DCHNB02013E2.PrintDivName)
                // --- ADD 2009/03/30 -------------------------------->>>>>
                && (extrInfo_DCHNB02013E1.CostOut == extrInfo_DCHNB02013E2.CostOut)
                && (extrInfo_DCHNB02013E1.PrintDailyFooter == extrInfo_DCHNB02013E2.PrintDailyFooter)
                // --- ADD 2009/03/30 --------------------------------<<<<<
				 );

		}
		/// <summary>
		/// 受注出荷確認表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_DCHNB02013Eクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DCHNB02013Eクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ExtrInfo_DCHNB02013E target)
		{
			ArrayList resList = new ArrayList();
			if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
			if (this.IsSelectAllSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
			if (this.IsOutputAllSecRec != target.IsOutputAllSecRec) resList.Add("IsOutputAllSecRec");
			if (this.ResultsAddUpSecList != target.ResultsAddUpSecList) resList.Add("ResultsAddUpSecList");
			if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
			if (this.SalesDateSt != target.SalesDateSt) resList.Add("SalesDateSt");
			if (this.SalesDateEd != target.SalesDateEd) resList.Add("SalesDateEd");
			if (this.ShipmentDaySt != target.ShipmentDaySt) resList.Add("ShipmentDaySt");
			if (this.ShipmentDayEd != target.ShipmentDayEd) resList.Add("ShipmentDayEd");
			if (this.SearchSlipDateSt != target.SearchSlipDateSt) resList.Add("SearchSlipDateSt");
			if (this.SearchSlipDateEd != target.SearchSlipDateEd) resList.Add("SearchSlipDateEd");
			if (this.CustomerCodeSt != target.CustomerCodeSt) resList.Add("CustomerCodeSt");
			if (this.CustomerCodeEd != target.CustomerCodeEd) resList.Add("CustomerCodeEd");
			if (this.SalesEmployeeCdSt != target.SalesEmployeeCdSt) resList.Add("SalesEmployeeCdSt");
			if (this.SalesEmployeeCdEd != target.SalesEmployeeCdEd) resList.Add("SalesEmployeeCdEd");
			if (this.DebitNoteDiv != target.DebitNoteDiv) resList.Add("DebitNoteDiv");
			if (this.SalesSlipCd != target.SalesSlipCd) resList.Add("SalesSlipCd");
			if (this.SalesSlipCdDtl != target.SalesSlipCdDtl) resList.Add("SalesSlipCdDtl");//売上伝票区分[明細]
			if (this.GrsProfitCheckLower != target.GrsProfitCheckLower) resList.Add("GrsProfitCheckLower");
			if (this.GrsProfitCheckBest != target.GrsProfitCheckBest) resList.Add("GrsProfitCheckBest");
			if (this.GrsProfitCheckUpper != target.GrsProfitCheckUpper) resList.Add("GrsProfitCheckUpper");
			if (this.GrossMarginLow2 != target.GrossMarginLow2) resList.Add("GrossMarginLow2");
			if (this.GrossMarginBest2 != target.GrossMarginBest2) resList.Add("GrossMarginBest2");
			if (this.GrossMarginUpper2 != target.GrossMarginUpper2) resList.Add("GrossMarginUpper2");
			if (this.GrossMargin1Mark != target.GrossMargin1Mark) resList.Add("GrossMargin1Mark");
			if (this.GrossMargin2Mark != target.GrossMargin2Mark) resList.Add("GrossMargin2Mark");
			if (this.GrossMargin3Mark != target.GrossMargin3Mark) resList.Add("GrossMargin3Mark");
			if (this.GrossMargin4Mark != target.GrossMargin4Mark) resList.Add("GrossMargin4Mark");
            if (this.PublicationType != target.PublicationType) resList.Add("PublicationType");
            if (this.NewPageType != target.NewPageType) resList.Add("NewPageType");
			if (this.SortOrder != target.SortOrder) resList.Add("SortOrder");
			if (this.PrintDiv != target.PrintDiv) resList.Add("PrintDiv");
			if (this.PrintDivName != target.PrintDivName) resList.Add("PrintDivName");
            // --- ADD 2009/03/30 -------------------------------->>>>>
            if (this.CostOut != target.CostOut) resList.Add("CostOut");
            if (this.PrintDailyFooter != target.PrintDailyFooter) resList.Add("PrintDailyFooter");
            // --- ADD 2009/03/30 --------------------------------<<<<<

			return resList;
		}

		/// <summary>
		/// 受注出荷確認表抽出条件クラス比較処理
		/// </summary>
		/// <param name="extrInfo_DCHNB02013E1">比較するExtrInfo_DCHNB02013Eクラスのインスタンス</param>
		/// <param name="extrInfo_DCHNB02013E2">比較するExtrInfo_DCHNB02013Eクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DCHNB02013Eクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ExtrInfo_DCHNB02013E extrInfo_DCHNB02013E1, ExtrInfo_DCHNB02013E extrInfo_DCHNB02013E2)
		{
			ArrayList resList = new ArrayList();
			if (extrInfo_DCHNB02013E1.EnterpriseCode != extrInfo_DCHNB02013E2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (extrInfo_DCHNB02013E1.IsSelectAllSection != extrInfo_DCHNB02013E2.IsSelectAllSection) resList.Add("IsSelectAllSection");
			if (extrInfo_DCHNB02013E1.IsOutputAllSecRec != extrInfo_DCHNB02013E2.IsOutputAllSecRec) resList.Add("IsOutputAllSecRec");
			if (extrInfo_DCHNB02013E1.ResultsAddUpSecList != extrInfo_DCHNB02013E2.ResultsAddUpSecList) resList.Add("ResultsAddUpSecList");
			if (extrInfo_DCHNB02013E1.AcptAnOdrStatus != extrInfo_DCHNB02013E2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
			if (extrInfo_DCHNB02013E1.SalesDateSt != extrInfo_DCHNB02013E2.SalesDateSt) resList.Add("SalesDateSt");
			if (extrInfo_DCHNB02013E1.SalesDateEd != extrInfo_DCHNB02013E2.SalesDateEd) resList.Add("SalesDateEd");
			if (extrInfo_DCHNB02013E1.ShipmentDaySt != extrInfo_DCHNB02013E2.ShipmentDaySt) resList.Add("ShipmentDaySt");
			if (extrInfo_DCHNB02013E1.ShipmentDayEd != extrInfo_DCHNB02013E2.ShipmentDayEd) resList.Add("ShipmentDayEd");
			if (extrInfo_DCHNB02013E1.SearchSlipDateSt != extrInfo_DCHNB02013E2.SearchSlipDateSt) resList.Add("SearchSlipDateSt");
			if (extrInfo_DCHNB02013E1.SearchSlipDateEd != extrInfo_DCHNB02013E2.SearchSlipDateEd) resList.Add("SearchSlipDateEd");
			if (extrInfo_DCHNB02013E1.CustomerCodeSt != extrInfo_DCHNB02013E2.CustomerCodeSt) resList.Add("CustomerCodeSt");
			if (extrInfo_DCHNB02013E1.CustomerCodeEd != extrInfo_DCHNB02013E2.CustomerCodeEd) resList.Add("CustomerCodeEd");
			if (extrInfo_DCHNB02013E1.SalesEmployeeCdSt != extrInfo_DCHNB02013E2.SalesEmployeeCdSt) resList.Add("SalesEmployeeCdSt");
			if (extrInfo_DCHNB02013E1.SalesEmployeeCdEd != extrInfo_DCHNB02013E2.SalesEmployeeCdEd) resList.Add("SalesEmployeeCdEd");
			if (extrInfo_DCHNB02013E1.DebitNoteDiv != extrInfo_DCHNB02013E2.DebitNoteDiv) resList.Add("DebitNoteDiv");
			if (extrInfo_DCHNB02013E1.SalesSlipCd != extrInfo_DCHNB02013E2.SalesSlipCd) resList.Add("SalesSlipCd");
			if (extrInfo_DCHNB02013E1.SalesSlipCdDtl != extrInfo_DCHNB02013E2.SalesSlipCdDtl) resList.Add("SalesSlipCdDtl");
			if (extrInfo_DCHNB02013E1.GrsProfitCheckLower != extrInfo_DCHNB02013E2.GrsProfitCheckLower) resList.Add("GrsProfitCheckLower");
			if (extrInfo_DCHNB02013E1.GrsProfitCheckBest != extrInfo_DCHNB02013E2.GrsProfitCheckBest) resList.Add("GrsProfitCheckBest");
			if (extrInfo_DCHNB02013E1.GrsProfitCheckUpper != extrInfo_DCHNB02013E2.GrsProfitCheckUpper) resList.Add("GrsProfitCheckUpper");
			if (extrInfo_DCHNB02013E1.GrossMarginLow2 != extrInfo_DCHNB02013E2.GrossMarginLow2) resList.Add("GrossMarginLow2");
			if (extrInfo_DCHNB02013E1.GrossMarginBest2 != extrInfo_DCHNB02013E2.GrossMarginBest2) resList.Add("GrossMarginBest2");
			if (extrInfo_DCHNB02013E1.GrossMarginUpper2 != extrInfo_DCHNB02013E2.GrossMarginUpper2) resList.Add("GrossMarginUpper2");
			if (extrInfo_DCHNB02013E1.GrossMargin1Mark != extrInfo_DCHNB02013E2.GrossMargin1Mark) resList.Add("GrossMargin1Mark");
			if (extrInfo_DCHNB02013E1.GrossMargin2Mark != extrInfo_DCHNB02013E2.GrossMargin2Mark) resList.Add("GrossMargin2Mark");
			if (extrInfo_DCHNB02013E1.GrossMargin3Mark != extrInfo_DCHNB02013E2.GrossMargin3Mark) resList.Add("GrossMargin3Mark");
			if (extrInfo_DCHNB02013E1.GrossMargin4Mark != extrInfo_DCHNB02013E2.GrossMargin4Mark) resList.Add("GrossMargin4Mark");
            if (extrInfo_DCHNB02013E1.PublicationType != extrInfo_DCHNB02013E2.PublicationType) resList.Add("PublicationType");
            if (extrInfo_DCHNB02013E1.NewPageType != extrInfo_DCHNB02013E2.NewPageType) resList.Add("NewPageType");
            if (extrInfo_DCHNB02013E1.SortOrder != extrInfo_DCHNB02013E2.SortOrder) resList.Add("SortOrder");
			if (extrInfo_DCHNB02013E1.PrintDiv != extrInfo_DCHNB02013E2.PrintDiv) resList.Add("PrintDiv");
			if (extrInfo_DCHNB02013E1.PrintDivName != extrInfo_DCHNB02013E2.PrintDivName) resList.Add("PrintDivName");
            // --- ADD 2009/03/30 -------------------------------->>>>>
            if (extrInfo_DCHNB02013E1.CostOut != extrInfo_DCHNB02013E2.CostOut) resList.Add("CostOut");
            if (extrInfo_DCHNB02013E1.PrintDailyFooter != extrInfo_DCHNB02013E2.PrintDailyFooter) resList.Add("PrintDailyFooter");
            // --- ADD 2009/03/30 --------------------------------<<<<<

			return resList;
		}

        #region ◆ 発行タイプ列挙体
        /// <summary> 発行タイプ列挙体 </summary>
        public enum PublicationTypeState
        {
            /// <summary> 受注 </summary>
            AcceptAnOrder = 0,
            /// <summary> 受注計上済 </summary>
            AcceptAnOrderAddUp = 1,
            // 2008.09.24 30413 犬飼 貸出と貸出計上済の値を変更 >>>>>>START
            /// <summary> 貸出 </summary>
            //Loan = 1,
            Loan = 2,
            /// <summary> 貸出計上済 </summary>
            //LoanAddUp = 2
            LoanAddUp = 3
            // 2008.09.24 30413 犬飼 貸出と貸出計上済の値を変更 <<<<<<END
        }
        #endregion ◆
	}
}
