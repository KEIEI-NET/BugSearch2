using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   EstimateListCndtn
	/// <summary>
	///                      見積確認表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   見積確認表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/11/13  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class EstimateListCndtn
	{
        # region ■ private field ■

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード（複数指定）</summary>
		/// <remarks>（配列）</remarks>
		private string[] _sectionCodes = new string[0];

		/// <summary>開始見積日付</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _st_SalesDate;

		/// <summary>終了見積日付</summary>
		/// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_SalesDate;

		/// <summary>開始入力日付</summary>
		/// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _st_SearchSlipDate;

		/// <summary>終了入力日付</summary>
		/// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _ed_SearchSlipDate;

		/// <summary>開始得意先コード</summary>
		private Int32 _st_CustomerCode;

		/// <summary>終了得意先コード</summary>
		private Int32 _ed_CustomerCode;

		/// <summary>開始販売従業員コード</summary>
		private string _st_SalesEmployeeCd = "";

		/// <summary>終了販売従業員コード</summary>
		private string _ed_SalesEmployeeCd = "";

        /// <summary>見積タイプ</summary>
        /// <remarks>0:売上入力分,1:検索見積分,-1:全て</remarks>
        private Int32 _estimateDivide;

        /// <summary>発行タイプ</summary>
        /// <remarks>0:見積計上,-1:全て</remarks>
        private Int32 _printDiv;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";
        // 2011/11/11 add start ----------------------------------------------->>
        /// <summary>連携伝票出力区分</summary>
        /// <remarks>0:連携伝票を含まない,1:連携伝票を含む,2:連携伝票のみ対象</remarks>
        private Int32 _autoAnswerDivSCMRF;

        /// <summary>連携伝票対象区分</summary>
        /// <remarks>0:PCCforNS分を含む,1:BLﾊﾟｰﾂｵｰﾀﾞｰ分を含む</remarks>
        private Int16 _acceptOrOrderKindRF;
        // 2011/11/11 add end -------------------------------------------------<<
        # endregion  ■ private field ■

        # region ■ public propaty ■

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
		/// <summary>拠点コード（複数指定）プロパティ</summary>
		/// <value>（配列）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コード（複数指定）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  St_SalesDate
		/// <summary>開始見積日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始見積日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime St_SalesDate
		{
			get{return _st_SalesDate;}
			set{_st_SalesDate = value;}
		}

		/// public propaty name  :  Ed_SalesDate
		/// <summary>終了見積日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了見積日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime Ed_SalesDate
		{
			get{return _ed_SalesDate;}
			set{_ed_SalesDate = value;}
		}

		/// public propaty name  :  St_SearchSlipDate
		/// <summary>開始入力日付プロパティ</summary>
		/// <value>YYYYMMDD　（更新年月日）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime St_SearchSlipDate
		{
			get{return _st_SearchSlipDate;}
			set{_st_SearchSlipDate = value;}
		}

		/// public propaty name  :  Ed_SearchSlipDate
		/// <summary>終了入力日付プロパティ</summary>
		/// <value>YYYYMMDD　（更新年月日）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime Ed_SearchSlipDate
		{
			get{return _ed_SearchSlipDate;}
			set{_ed_SearchSlipDate = value;}
		}

		/// public propaty name  :  St_CustomerCode
		/// <summary>開始得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_CustomerCode
		{
			get{return _st_CustomerCode;}
			set{_st_CustomerCode = value;}
		}

		/// public propaty name  :  Ed_CustomerCode
		/// <summary>終了得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_CustomerCode
		{
			get{return _ed_CustomerCode;}
			set{_ed_CustomerCode = value;}
		}

		/// public propaty name  :  St_SalesEmployeeCd
		/// <summary>開始販売従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始販売従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_SalesEmployeeCd
		{
			get{return _st_SalesEmployeeCd;}
			set{_st_SalesEmployeeCd = value;}
		}

		/// public propaty name  :  Ed_SalesEmployeeCd
		/// <summary>終了販売従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了販売従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_SalesEmployeeCd
		{
			get{return _ed_SalesEmployeeCd;}
			set{_ed_SalesEmployeeCd = value;}
		}

        /// public propaty name  :  EstimateDivide
        /// <summary>見積タイププロパティ</summary>
        /// <value>0:売上入力分,1:検索見積分,-1:全て</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstimateDivide
        {
            get { return _estimateDivide; }
            set { _estimateDivide = value; }
        }

        /// public propaty name  :  PrintDiv
        /// <summary>発行タイププロパティ</summary>
        /// <value>0:見積計上,-1:全て</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintDiv
        {
            get { return _printDiv; }
            set { _printDiv = value; }
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

        # endregion ■ public propaty ■

        # region ■ private field (自動生成以外) ■
        /// <summary>
        /// 拠点オプション区分
        /// </summary>
        private bool _isOptSection = false;

        /// <summary>
        /// 全拠点選択区分
        /// </summary>
        private bool _isSelectAllSection = false;

        /// <summary>
        /// メモ印刷区分
        /// </summary>
        private MemoPrintDivState _memoPrintDiv;

        /// <summary>
        /// 改頁
        /// </summary>
        private Int32 _newPageType;

        // --- ADD 2009/04/01 -------------------------------->>>>>
        /// <summary>
        /// 日計印字
        /// </summary>
        private Int32 _printDailyFooter;
        // --- ADD 2009/04/01 --------------------------------<<<<<

        # endregion ■ private field (自動生成以外) ■

        # region ■ public propaty (自動生成以外) ■
        /// <summary>
        /// 拠点オプション区分プロパティ
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }

        /// <summary>
        /// 全拠点選択区分プロパティ
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }

        /// <summary>
        /// メモ印刷区分プロパティ
        /// </summary>
        public MemoPrintDivState MemoPrintDiv
        {
            get { return this._memoPrintDiv; }
            set { this._memoPrintDiv = value; }
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

        // --- ADD 2009/04/01 -------------------------------->>>>>
        /// <summary>
        /// 日計印字プロパティ
        /// </summary>
        public Int32 PrintDailyFooter
        {
            get { return this._printDailyFooter; }
            set { this._printDailyFooter = value; }
        }
        // --- ADD 2009/04/01 --------------------------------<<<<<

        // --- ADD 2011/11/11 -------------------------------->>>>>
        /// <summary>
        /// 連携伝票出力区分パティ
        /// </summary>
        public Int32 AutoAnswerDivSCMRF
        {
            get { return this._autoAnswerDivSCMRF; }
            set { this._autoAnswerDivSCMRF = value; }
        }

        /// <summary>
        /// 連携伝票対象区分パティ
        /// </summary>
        public Int16 AcceptOrOrderKindRF
        {
            get { return this._acceptOrOrderKindRF; }
            set { this._acceptOrOrderKindRF = value; }
        }
        // --- ADD 2011/11/11 --------------------------------<<<<<


        # endregion ■ public propaty (自動生成以外) ■

        # region ■ public Enum (自動生成以外) ■
        /// <summary>
        /// メモ印刷区分　列挙型
        /// </summary>
        public enum MemoPrintDivState
        {
            /// <summary>印刷しない</summary>
            None = 0,
            /// <summary>印刷する</summary>
            Print = 1,
        }
        # endregion ■ public Enum (自動生成以外) ■

        #region ■ public const (自動生成以外) ■
        /// <summary>共通 日付フォーマット</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

        /// <summary>共通 全て コード</summary>
        public const int ct_All_Code = -1;
        /// <summary>共通 全て 名称</summary>
        public const string ct_All_Name = "全て";
        #endregion

        # region ■ Constructor ■
        /// <summary>
        /// 見積確認表抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>EstimateListCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EstimateListCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EstimateListCndtn ()
        {
        }
        # endregion ■ Constructor ■
    }
}
