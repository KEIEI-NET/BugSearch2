using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   LedgerCmnCndtn
	/// <summary>
	///                      元帳共通抽出条件UIデータクラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   元帳照会一括抽出条件UIデータクラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2005/09/09</br>
	/// <br>Genarated Date   :   2006/08/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   20081 疋田 勇人</br>
    /// <br>                 :   DC.NS用に変更</br>
    /// <br>Programmer       : 30009 渋谷 大輔</br>
    /// <br>Date             : 2009.01.21</br>
    /// <br>Note             : PM.NS用に修正</br>
    /// <br>Note             : ※PMで不要な処理があっても問題がなければそのままにしてあります※</br>
    /// </remarks>
	public class LedgerCmnCndtn
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

        /// <summary>拠点オプション導入区分</summary>
        private bool _isOptSection;

        /// <summary>本社機能プロパティ</summary>
        private bool _isMainOfficeFunc;

        /// <summary>選択計上拠点コード</summary>
        private ArrayList _addupSecCodeList;

        /// <summary>帳票タイプ区分</summary>
        /// <remarks>設定コードと同じ</remarks>
        private int _printDiv;

        /// <summary>帳票タイプ区分名称</summary>
        private string _printDivName = string.Empty;

		/// <summary>出力対象年月(開始)</summary>
		private Int32 _startTargetYearMonth;

		/// <summary>出力対象年月(終了)</summary>
		private Int32 _endTargetYearMonth;

		/// <summary>出力順</summary>
		private Int32 _printOder;

		/// <summary>得意先コード(開始)</summary>
		private Int32 _startCustomerCode;

		/// <summary>得意先コード(終了)</summary>
		private Int32 _endCustomerCode;

		/// <summary>得意先カナ(開始)</summary>
		/// <remarks>ALL空白=TOP</remarks>
		private string _startCustomerKana = "";

		/// <summary>得意先カナ(終了)</summary>
		/// <remarks>ALL空白=END</remarks>
		private string _endCustomerKana = "";

		/// <summary>顧客担当者区分</summary>
		/// <remarks>0:顧客担当者,1:集金担当者</remarks>
		private Int32 _customerAgentDivCd;

		/// <summary>従業員コード(開始)</summary>
		private string _startEmployeeCode = "";

		/// <summary>従業員コード(終了)</summary>
		private string _endEmployeeCode = "";

		/// <summary>出力帳票区分</summary>
		/// <remarks>0:請求残,1:売掛残,2:支払残,3買掛残:</remarks>
		private Int32 _listDivCode;

		/// <summary>印刷区分</summary>
		/// <remarks>0:月単位で印刷,1:指定最終月に範囲内の明細を一括印刷</remarks>
		private Int32 _printDivCode;

		/// <summary>請求書出力区分</summary>
		private bool _isJudgeBillOutputCode = false;

		/// <summary>繰越残０印刷区分</summary>
		/// <remarks>True:印刷する,False:印刷しない</remarks>
		private bool _isJudgeZeroPrint = false;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>計上拠点名称</summary>
		private string _addUpSecName = "";

        /// <summary>出力金額区分</summary>
        /// <remarks>設定コードと同じ</remarks>
        private OutMoneyDivState _outMoneyDiv;

        #region ■ Private Const
        // 帳票タイプ区分 ------------------------------------------------------------------
        /// <summary>帳票タイプ区分 得意先元帳(明細)</summary>
        public const string ct_PrintDiv_Detail = "明細タイプ";
        /// <summary>帳票タイプ区分 得意先元帳(伝票)</summary>
        public const string ct_PrintDiv_Slip = "伝票タイプ";

        // 出力金額区分 --------------------------------------------------------------------
        /// <summary>全て</summary>
        public const string ct_OutMoneyDiv_All = "全て出力";
        /// <summary>0+プラス金額</summary>
        public const string ct_OutMoneyDiv_ZeroPlus = "0とプラス金額を出力";
        /// <summary>プラス金額</summary>
        public const string ct_OutMoneyDiv_Plus = "プラス金額のみ出力";
        /// <summary>0出力</summary>
        public const string ct_OutMoneyDiv_Zero = "0のみ出力";
        /// <summary>プラス金額+マイナス金額</summary>
        public const string ct_OutMoneyDiv_PlusMinus = "プラス金額とマイナス金額";
        /// <summary>0+マイナス金額</summary>
        public const string ct_OutMoneyDiv_ZeroMinus = "0とマイナス金額を出力";
        /// <summary>マイナス金額</summary>
        public const string ct_OutMoneyDiv_Minus = "マイナス金額のみ出力";
        #endregion

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

        /// public propaty name  :  IsOptSection
        /// <summary>拠点オプション導入区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点オプション導入区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// public propaty name  :  IsMainOfficeFunc
        /// <summary>本社機能プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   本社機能プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// public propaty name  :  AddupSecCodeList
        /// <summary>選択計上拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  選択計上拠点コードプロパティ</br>
        /// <br>Programer        :  自動生成</br>
        /// </remarks>
        public ArrayList AddupSecCodeList
        {
            get { return _addupSecCodeList; }
            set { _addupSecCodeList = value; }
        }

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

		/// public propaty name  :  StartTargetYearMonth
		/// <summary>出力対象年月(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力対象年月(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartTargetYearMonth
		{
			get { return _startTargetYearMonth; }
			set { _startTargetYearMonth = value; }
		}

		/// public propaty name  :  EndTargetYearMonth
		/// <summary>出力対象年月(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力対象年月(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EndTargetYearMonth
		{
			get { return _endTargetYearMonth; }
			set { _endTargetYearMonth = value; }
		}

		/// public propaty name  :  PrintOder
		/// <summary>出力順プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力順プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintOder
		{
			get { return _printOder; }
			set { _printOder = value; }
		}

		/// public propaty name  :  StartCustomerCode
		/// <summary>得意先コード(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartCustomerCode
		{
			get { return _startCustomerCode; }
			set { _startCustomerCode = value; }
		}

		/// public propaty name  :  EndCustomerCode
		/// <summary>得意先コード(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EndCustomerCode
		{
			get { return _endCustomerCode; }
			set { _endCustomerCode = value; }
		}

		/// public propaty name  :  StartCustomerKana
		/// <summary>得意先カナ(開始)プロパティ</summary>
		/// <value>ALL空白=TOP</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先カナ(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StartCustomerKana
		{
			get { return _startCustomerKana; }
			set { _startCustomerKana = value; }
		}

		/// public propaty name  :  EndCustomerKana
		/// <summary>得意先カナ(終了)プロパティ</summary>
		/// <value>ALL空白=END</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先カナ(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EndCustomerKana
		{
			get { return _endCustomerKana; }
			set { _endCustomerKana = value; }
		}

		/// public propaty name  :  CustomerAgentDivCd
		/// <summary>顧客担当者区分プロパティ</summary>
		/// <value>0:顧客担当者,1:集金担当者</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   顧客担当者区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerAgentDivCd
		{
			get { return _customerAgentDivCd; }
			set { _customerAgentDivCd = value; }
		}

		/// public propaty name  :  StartEmployeeCode
		/// <summary>従業員コード(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   従業員コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StartEmployeeCode
		{
			get { return _startEmployeeCode; }
			set { _startEmployeeCode = value; }
		}

		/// public propaty name  :  EndEmployeeCode
		/// <summary>従業員コード(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   従業員コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EndEmployeeCode
		{
			get { return _endEmployeeCode; }
			set { _endEmployeeCode = value; }
		}

		/// public propaty name  :  ListDivCode
		/// <summary>出力帳票区分プロパティ</summary>
		/// <value>0:請求残,1:売掛残</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力帳票区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ListDivCode
		{
			get { return _listDivCode; }
			set { _listDivCode = value; }
		}

		/// public propaty name  :  PrintDivCode
		/// <summary>印刷区分プロパティ</summary>
		/// <value>0:月単位で印刷,1:指定最終月に範囲内の明細を一括印刷</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintDivCode
		{
			get { return _printDivCode; }
			set { _printDivCode = value; }
		}

		/// public propaty name  :  IsJudgeBillOutputCode
		/// <summary>請求書出力区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書出力区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool IsJudgeBillOutputCode
		{
			get { return _isJudgeBillOutputCode; }
			set { _isJudgeBillOutputCode = value; }
		}

		/// public propaty name  :  isJudgeZeroPrint
		/// <summary>繰越残０印刷区分プロパティ</summary>
		/// <value>True:印刷する,False:印刷しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   繰越残０印刷区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool IsJudgeZeroPrint
		{
			get { return _isJudgeZeroPrint; }
			set { _isJudgeZeroPrint = value; }
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

		/// public propaty name  :  AddUpSecName
		/// <summary>計上拠点名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上拠点名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpSecName
		{
			get { return _addUpSecName; }
			set { _addUpSecName = value; }
		}

        /// public propaty name  :  OutMoneyDiv
        /// <summary>出力金額区分プロパティ</summary>
        /// <value>設定の用途コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力金額区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OutMoneyDivState OutMoneyDiv
        {
            get { return _outMoneyDiv; }
            set { _outMoneyDiv = value; }
        }

        /// public propaty name  :  OutMoneyDivName
        /// <summary>出力金額区分名称プロパティ(読み取り専用)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力金額区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OutMoneyDivName
        {
            get
            {
                string outMoneyDivName = string.Empty;
                // 出力金額区分から名称を判断
                switch (this._outMoneyDiv)
                {
                    case OutMoneyDivState.All:		    // 全て
                        outMoneyDivName = ct_OutMoneyDiv_All;
                        break;
                    case OutMoneyDivState.ZeroPlus:	   // 0+プラス金額
                        outMoneyDivName = ct_OutMoneyDiv_ZeroPlus;
                        break;
                    case OutMoneyDivState.Plus:	       // プラス金額
                        outMoneyDivName = ct_OutMoneyDiv_Plus;
                        break;
                    case OutMoneyDivState.Zero:	       // 0出力
                        outMoneyDivName = ct_OutMoneyDiv_Zero;
                        break;
                    case OutMoneyDivState.PlusMinus:   // プラス金額+マイナス金額
                        outMoneyDivName = ct_OutMoneyDiv_PlusMinus;
                        break;
                    case OutMoneyDivState.ZeroMinus:   // 0+マイナス金額
                        outMoneyDivName = ct_OutMoneyDiv_ZeroMinus;
                        break;
                    case OutMoneyDivState.Minus:       // マイナス金額
                        outMoneyDivName = ct_OutMoneyDiv_Minus;
                        break;
                    default:
                        outMoneyDivName = string.Empty;
                        break;
                }
                return outMoneyDivName;
            }
        }

        #region ■ Public Enum
        #region ◆ 帳票タイプ区分列挙体
        /// <summary> 帳票タイプ区分列挙体 </summary>
        public enum PrintDivState
        {
            /// <summary> 明細タイプ </summary>
            Detail = 1,
            /// <summary> 伝票タイプ </summary>
            Slip = 2
        }
        #endregion

        #region ◆ 出力金額区分列挙体
        /// <summary> 出力金額区分列挙体 </summary>
        public enum OutMoneyDivState
        {
            /// <summary>全て</summary>
            All = 0,
            /// <summary>0+プラス金額</summary>
            ZeroPlus = 1,
            /// <summary>プラス金額</summary>
            Plus = 2,
            /// <summary>0出力</summary>
            Zero = 3,
            /// <summary>プラス金額+マイナス金額</summary>
            PlusMinus = 4,
            /// <summary>0+マイナス金額</summary>
            ZeroMinus = 5,
            /// <summary>マイナス金額</summary>
            Minus = 6
        }
        #endregion ◆
        #endregion ■ Public Enum

        /// <summary>
		/// 元帳一括抽出条件UIデータクラスコンストラクタ
		/// </summary>
		/// <returns>CsLedgerCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CsLedgerCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public LedgerCmnCndtn()
		{
		}

		/// <summary>
		/// 元帳一括抽出条件UIデータクラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="isOptSection">拠点オプション導入区分</param>
        /// <param name="isMainOfficeFunc">本社機能プロパティ</param>
        /// <param name="addupSecCodeList">選択計上拠点コード</param>
        /// <param name="printDiv">帳票タイプ区分</param>
        /// <param name="printDivName">帳票タイプ区分名称</param>
        /// <param name="startTargetYearMonth">出力対象年月(開始)</param>
		/// <param name="endTargetYearMonth">出力対象年月(終了)</param>
		/// <param name="printOder">出力順</param>
		/// <param name="startCustomerCode">得意先コード(開始)</param>
		/// <param name="endCustomerCode">得意先コード(終了)</param>
		/// <param name="startCustomerKana">得意先カナ(開始)(ALL空白=TOP)</param>
		/// <param name="endCustomerKana">得意先カナ(終了)(ALL空白=END)</param>
		/// <param name="customerAgentDivCd">顧客担当者区分(0:顧客担当者,1:集金担当者)</param>
		/// <param name="startEmployeeCode">従業員コード(開始)</param>
		/// <param name="endEmployeeCode">従業員コード(終了)</param>
		/// <param name="listDivCode">出力帳票区分(0:請求残,1:売掛残)</param>
		/// <param name="printDivCode">印刷区分(0:月単位で印刷,1:指定最終月に範囲内の明細を一括印刷)</param>
		/// <param name="isJudgeBillOutputCode">請求書出力区分</param>
		/// <param name="isJudgeZeroPrint">繰越残０印刷区分(True:印刷する,False:印刷しない)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="addUpSecName">計上拠点名称</param>
        /// <param name="outMoneyDiv">出力金額区分</param>
        /// <returns>CsLedgerCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CsLedgerCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public LedgerCmnCndtn(string enterpriseCode, bool isOptSection, bool isMainOfficeFunc, ArrayList addupSecCodeList, Int32 printDiv, string printDivName, Int32 startTargetYearMonth, Int32 endTargetYearMonth, Int32 printOder, Int32 startCustomerCode, Int32 endCustomerCode, string startCustomerKana, string endCustomerKana, Int32 customerAgentDivCd, string startEmployeeCode, string endEmployeeCode, Int32 listDivCode, Int32 printDivCode, bool isJudgeBillOutputCode, bool isJudgeZeroPrint, string enterpriseName, string addUpSecName, OutMoneyDivState outMoneyDiv)
		{
			this._enterpriseCode = enterpriseCode;
            this._isOptSection = isOptSection;
            this._isMainOfficeFunc = isMainOfficeFunc;
            this._addupSecCodeList = addupSecCodeList;
            this._printDiv = printDiv;
            this._printDivName = printDivName;
			this._startTargetYearMonth = startTargetYearMonth;
			this._endTargetYearMonth = endTargetYearMonth;
			this._printOder = printOder;
			this._startCustomerCode = startCustomerCode;
			this._endCustomerCode = endCustomerCode;
			this._startCustomerKana = startCustomerKana;
			this._endCustomerKana = endCustomerKana;
			this._customerAgentDivCd = customerAgentDivCd;
			this._startEmployeeCode = startEmployeeCode;
			this._endEmployeeCode = endEmployeeCode;
			this._listDivCode = listDivCode;
			this._printDivCode = printDivCode;
			this._isJudgeBillOutputCode = isJudgeBillOutputCode;
			this._isJudgeZeroPrint = isJudgeZeroPrint;
			this._enterpriseName = enterpriseName;
			this._addUpSecName = addUpSecName;
            this._outMoneyDiv = outMoneyDiv;
		}

		/// <summary>
		/// 元帳一括抽出条件UIデータクラス複製処理
		/// </summary>
		/// <returns>CsLedgerCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいCsLedgerCndtnクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public LedgerCmnCndtn Clone()
		{
            return new LedgerCmnCndtn(this._enterpriseCode, this._isOptSection, this._isMainOfficeFunc, this._addupSecCodeList, this._printDiv, this._printDivName, this._startTargetYearMonth, this._endTargetYearMonth, this._printOder, this._startCustomerCode, this._endCustomerCode, this._startCustomerKana, this._endCustomerKana, this._customerAgentDivCd, this._startEmployeeCode, this._endEmployeeCode, this._listDivCode, this._printDivCode, this._isJudgeBillOutputCode, this._isJudgeZeroPrint, this._enterpriseName, this._addUpSecName, this._outMoneyDiv);
		}

		/// <summary>
		/// 元帳一括抽出条件UIデータクラス比較処理
		/// </summary>
		/// <param name="target">比較対象のCsLedgerCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CsLedgerCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(LedgerCmnCndtn target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.IsOptSection == target.IsOptSection)
                 && (this.IsMainOfficeFunc == target.IsMainOfficeFunc)
                 && (this.AddupSecCodeList == target.AddupSecCodeList)
                 && (this.PrintDiv == target.PrintDiv)
                 && (this.PrintDivName == target.PrintDivName)
				 && (this.StartTargetYearMonth == target.StartTargetYearMonth)
				 && (this.EndTargetYearMonth == target.EndTargetYearMonth)
				 && (this.PrintOder == target.PrintOder)
				 && (this.StartCustomerCode == target.StartCustomerCode)
				 && (this.EndCustomerCode == target.EndCustomerCode)
				 && (this.StartCustomerKana == target.StartCustomerKana)
				 && (this.EndCustomerKana == target.EndCustomerKana)
				 && (this.CustomerAgentDivCd == target.CustomerAgentDivCd)
				 && (this.StartEmployeeCode == target.StartEmployeeCode)
				 && (this.EndEmployeeCode == target.EndEmployeeCode)
				 && (this.ListDivCode == target.ListDivCode)
				 && (this.PrintDivCode == target.PrintDivCode)
				 && (this.IsJudgeBillOutputCode == target.IsJudgeBillOutputCode)
				 && (this.IsJudgeZeroPrint == target.IsJudgeZeroPrint)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.AddUpSecName == target.AddUpSecName)
                 && (this.OutMoneyDiv == target.OutMoneyDiv));
		}

		/// <summary>
		/// 元帳一括抽出条件UIデータクラス比較処理
		/// </summary>
		/// <param name="csLedgerCndtn1">
		///                    比較するCsLedgerCndtnクラスのインスタンス
		/// </param>
		/// <param name="csLedgerCndtn2">比較するCsLedgerCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CsLedgerCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(LedgerCmnCndtn csLedgerCndtn1, LedgerCmnCndtn csLedgerCndtn2)
		{
			return ((csLedgerCndtn1.EnterpriseCode == csLedgerCndtn2.EnterpriseCode)
				 && (csLedgerCndtn1.IsOptSection == csLedgerCndtn2.IsOptSection)
                 && (csLedgerCndtn1.IsMainOfficeFunc == csLedgerCndtn2.IsMainOfficeFunc)
                 && (csLedgerCndtn1.AddupSecCodeList == csLedgerCndtn2.AddupSecCodeList)
                 && (csLedgerCndtn1.PrintDiv == csLedgerCndtn2.PrintDiv)
                 && (csLedgerCndtn1.PrintDivName == csLedgerCndtn2.PrintDivName)
                 && (csLedgerCndtn1.StartTargetYearMonth == csLedgerCndtn2.StartTargetYearMonth)
				 && (csLedgerCndtn1.EndTargetYearMonth == csLedgerCndtn2.EndTargetYearMonth)
				 && (csLedgerCndtn1.PrintOder == csLedgerCndtn2.PrintOder)
				 && (csLedgerCndtn1.StartCustomerCode == csLedgerCndtn2.StartCustomerCode)
				 && (csLedgerCndtn1.EndCustomerCode == csLedgerCndtn2.EndCustomerCode)
				 && (csLedgerCndtn1.StartCustomerKana == csLedgerCndtn2.StartCustomerKana)
				 && (csLedgerCndtn1.EndCustomerKana == csLedgerCndtn2.EndCustomerKana)
				 && (csLedgerCndtn1.CustomerAgentDivCd == csLedgerCndtn2.CustomerAgentDivCd)
				 && (csLedgerCndtn1.StartEmployeeCode == csLedgerCndtn2.StartEmployeeCode)
				 && (csLedgerCndtn1.EndEmployeeCode == csLedgerCndtn2.EndEmployeeCode)
				 && (csLedgerCndtn1.ListDivCode == csLedgerCndtn2.ListDivCode)
				 && (csLedgerCndtn1.PrintDivCode == csLedgerCndtn2.PrintDivCode)
				 && (csLedgerCndtn1.IsJudgeBillOutputCode == csLedgerCndtn2.IsJudgeBillOutputCode)
				 && (csLedgerCndtn1.IsJudgeZeroPrint == csLedgerCndtn2.IsJudgeZeroPrint)
				 && (csLedgerCndtn1.EnterpriseName == csLedgerCndtn2.EnterpriseName)
				 && (csLedgerCndtn1.AddUpSecName == csLedgerCndtn2.AddUpSecName)
                 && (csLedgerCndtn1.OutMoneyDiv == csLedgerCndtn2.OutMoneyDiv));
		}
		/// <summary>
		/// 元帳一括抽出条件UIデータクラス比較処理
		/// </summary>
		/// <param name="target">比較対象のCsLedgerCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CsLedgerCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(LedgerCmnCndtn target)
		{
			ArrayList resList = new ArrayList();
			if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.IsOptSection != target.IsOptSection) resList.Add("IsOptSection");
            if (this.IsMainOfficeFunc != target.IsMainOfficeFunc) resList.Add("IsMainOfficeFunc");
            if (this.AddupSecCodeList != target.AddupSecCodeList) resList.Add("AddupSecCodeList");
            if (this.PrintDiv != target.PrintDiv) resList.Add("PrintDiv");
            if (this.PrintDivName != target.PrintDivName) resList.Add("PrintDivName");
			if (this.StartTargetYearMonth != target.StartTargetYearMonth) resList.Add("StartTargetYearMonth");
			if (this.EndTargetYearMonth != target.EndTargetYearMonth) resList.Add("EndTargetYearMonth");
			if (this.PrintOder != target.PrintOder) resList.Add("PrintOder");
			if (this.StartCustomerCode != target.StartCustomerCode) resList.Add("StartCustomerCode");
			if (this.EndCustomerCode != target.EndCustomerCode) resList.Add("EndCustomerCode");
			if (this.StartCustomerKana != target.StartCustomerKana) resList.Add("StartCustomerKana");
			if (this.EndCustomerKana != target.EndCustomerKana) resList.Add("EndCustomerKana");
			if (this.CustomerAgentDivCd != target.CustomerAgentDivCd) resList.Add("CustomerAgentDivCd");
			if (this.StartEmployeeCode != target.StartEmployeeCode) resList.Add("StartEmployeeCode");
			if (this.EndEmployeeCode != target.EndEmployeeCode) resList.Add("EndEmployeeCode");
			if (this.ListDivCode != target.ListDivCode) resList.Add("ListDivCode");
			if (this.PrintDivCode != target.PrintDivCode) resList.Add("PrintDivCode");
			if (this.IsJudgeBillOutputCode != target.IsJudgeBillOutputCode) resList.Add("IsJudgeBillOutputCode");
			if (this.IsJudgeZeroPrint != target.IsJudgeZeroPrint) resList.Add("IsJudgeZeroPrint");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
			if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");
            if (this.OutMoneyDiv != target.OutMoneyDiv) resList.Add("OutMoneyDiv");

			return resList;
		}

		/// <summary>
		/// 元帳一括抽出条件UIデータクラス比較処理
		/// </summary>
		/// <param name="csLedgerCndtn1">比較するCsLedgerCndtnクラスのインスタンス</param>
		/// <param name="csLedgerCndtn2">比較するCsLedgerCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CsLedgerCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(LedgerCmnCndtn csLedgerCndtn1, LedgerCmnCndtn csLedgerCndtn2)
		{
			ArrayList resList = new ArrayList();
			if (csLedgerCndtn1.EnterpriseCode != csLedgerCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (csLedgerCndtn1.IsOptSection != csLedgerCndtn2.IsOptSection) resList.Add("IsOptSection");
            if (csLedgerCndtn1.IsMainOfficeFunc != csLedgerCndtn2.IsMainOfficeFunc) resList.Add("IsMainOfficeFunc");
            if (csLedgerCndtn1.AddupSecCodeList != csLedgerCndtn2.AddupSecCodeList) resList.Add("AddupSecCodeList");
            if (csLedgerCndtn1.PrintDiv != csLedgerCndtn2.PrintDiv) resList.Add("PrintDiv");
            if (csLedgerCndtn1.PrintDivName != csLedgerCndtn2.PrintDivName) resList.Add("PrintDivName");
			if (csLedgerCndtn1.StartTargetYearMonth != csLedgerCndtn2.StartTargetYearMonth) resList.Add("StartTargetYearMonth");
			if (csLedgerCndtn1.EndTargetYearMonth != csLedgerCndtn2.EndTargetYearMonth) resList.Add("EndTargetYearMonth");
			if (csLedgerCndtn1.PrintOder != csLedgerCndtn2.PrintOder) resList.Add("PrintOder");
			if (csLedgerCndtn1.StartCustomerCode != csLedgerCndtn2.StartCustomerCode) resList.Add("StartCustomerCode");
			if (csLedgerCndtn1.EndCustomerCode != csLedgerCndtn2.EndCustomerCode) resList.Add("EndCustomerCode");
			if (csLedgerCndtn1.StartCustomerKana != csLedgerCndtn2.StartCustomerKana) resList.Add("StartCustomerKana");
			if (csLedgerCndtn1.EndCustomerKana != csLedgerCndtn2.EndCustomerKana) resList.Add("EndCustomerKana");
			if (csLedgerCndtn1.CustomerAgentDivCd != csLedgerCndtn2.CustomerAgentDivCd) resList.Add("CustomerAgentDivCd");
			if (csLedgerCndtn1.StartEmployeeCode != csLedgerCndtn2.StartEmployeeCode) resList.Add("StartEmployeeCode");
			if (csLedgerCndtn1.EndEmployeeCode != csLedgerCndtn2.EndEmployeeCode) resList.Add("EndEmployeeCode");
			if (csLedgerCndtn1.ListDivCode != csLedgerCndtn2.ListDivCode) resList.Add("ListDivCode");
			if (csLedgerCndtn1.PrintDivCode != csLedgerCndtn2.PrintDivCode) resList.Add("PrintDivCode");
			if (csLedgerCndtn1.IsJudgeBillOutputCode != csLedgerCndtn2.IsJudgeBillOutputCode) resList.Add("IsJudgeBillOutputCode");
			if (csLedgerCndtn1.IsJudgeZeroPrint != csLedgerCndtn2.IsJudgeZeroPrint) resList.Add("IsJudgeZeroPrint");
			if (csLedgerCndtn1.EnterpriseName != csLedgerCndtn2.EnterpriseName) resList.Add("EnterpriseName");
			if (csLedgerCndtn1.AddUpSecName != csLedgerCndtn2.AddUpSecName) resList.Add("AddUpSecName");
            if (csLedgerCndtn1.OutMoneyDiv != csLedgerCndtn2.OutMoneyDiv) resList.Add("OutMoneyDiv");

			return resList;
		}
	}
}
