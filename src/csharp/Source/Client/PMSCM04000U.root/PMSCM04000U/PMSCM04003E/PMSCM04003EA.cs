//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 問合せ一覧/受注検索ウィンドウ
// プログラム概要   : 画面データを保持する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/05/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/09  修正内容 : SCM障害№10384対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SCMInquiryOrder
	/// <summary>
	///                      SCM問い合わせ一覧画面情報保持クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM問い合わせ一覧抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/4/13</br>
	/// <br>Genarated Date   :   2009/05/26  (CSharp File Generated Date)</br>
    /// <br></br>
	/// <br>Update Note      :   売上伝票番号を追加（明細検索に使用）</br>
    /// <br>Programmer       :   21024　佐々木 健</br>
    /// <br>Date             :   2010/05/27</br>
    /// <br>Update Note      :   Redmine 26534 受発注種別を追加し、PCCforNSとBLパーツオーダーシステムの判断を可能とする</br>
    /// <br>Programmer       :   葛中華</br>
    /// <br>Date             :   2011/11/12</br>
    /// </remarks>
	public class SCMInquiryOrder
	{
		/// <summary>問合せ元企業コード</summary>
		private string _inqOriginalEpCd = "";

		/// <summary>問合せ元拠点コード</summary>
		private string _inqOriginalSecCd = "";

		/// <summary>問合せ先企業コード</summary>
		private string _inqOtherEpCd = "";

		/// <summary>問合せ先拠点コード</summary>
		private string _inqOtherSecCd = "";

		/// <summary>開始問合せ番号</summary>
		private Int64 _st_InquiryNumber;

		/// <summary>終了問合せ番号</summary>
		private Int64 _ed_InquiryNumber;

		/// <summary>更新年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>更新時分秒ミリ秒</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;

		/// <summary>問合せ・発注種別</summary>
		/// <remarks>1:問合せ 2:発注</remarks>
		private Int32[] _inqOrdDivCd;

		/// <summary>回答区分</summary>
		/// <remarks>0:アクションなし 1:回答中 10:一部回答 20:回答完了 30:承認 99:キャンセル</remarks>
		private Int32[] _answerDivCd;

		/// <summary>確定日</summary>
		/// <remarks>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</remarks>
		private Int32 _judgementDate;

		/// <summary>問合せ・発注備考</summary>
		private string _inqOrdNote;

		/// <summary>問合せ従業員コード</summary>
		/// <remarks>問合せした従業員コード</remarks>
		private string _inqEmployeeCd = "";

		/// <summary>問合せ従業員名称</summary>
		/// <remarks>問合せした従業員名称</remarks>
		private string _inqEmployeeNm = "";

		/// <summary>回答従業員コード</summary>
		private string _ansEmployeeCd = "";

		/// <summary>回答従業員名称</summary>
		private string _ansEmployeeNm = "";

		/// <summary>開始問合せ日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _st_InquiryDate;

		/// <summary>終了問合せ日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _ed_InquiryDate;

		/// <summary>開始得意先コード</summary>
		private Int32 _st_CustomerCode;

		/// <summary>終了得意先コード</summary>
		private Int32 _ed_CustomerCode;

		/// <summary>開始売上伝票番号</summary>
		/// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
		private string _st_SalesSlipNum = "";

		/// <summary>終了売上伝票番号</summary>
		/// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
		private string _ed_SalesSlipNum = "";

		/// <summary>受注ステータス</summary>
		/// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
		private Int32[] _acptAnOdrStatus;

		/// <summary>回答方法</summary>
		private Int32[] _awnserMethod;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>売上伝票合計（税込み）</summary>
		/// <remarks>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</remarks>
		private Int64 _salesTotalTaxInc;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        // 2010/05/27 Add >>>
        /// <summary>売上伝票番号</summary>
        private string _salesSlipNum = "";
        // 2010/05/27 Add <<<

        // ---- ADD gezh 2011/11/12 -------->>>>>
        /// <summary>連携対象区分</summary>
        private Int16[] _cooperationOptionDiv;
        // ---- ADD gezh 2011/11/12 --------<<<<<

        // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
        /// <summary>開始入庫予定日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _st_ExpectedCeDate;

        /// <summary>終了入庫予定日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _ed_ExpectedCeDate;
        // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
        
        /// public propaty name  :  InqOriginalEpCd
		/// <summary>問合せ元企業コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ元企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOriginalEpCd
		{
			get{return _inqOriginalEpCd;}
			set{_inqOriginalEpCd = value;}
		}

		/// public propaty name  :  InqOriginalSecCd
		/// <summary>問合せ元拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ元拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOriginalSecCd
		{
			get{return _inqOriginalSecCd;}
			set{_inqOriginalSecCd = value;}
		}

		/// public propaty name  :  InqOtherEpCd
		/// <summary>問合せ先企業コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ先企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOtherEpCd
		{
			get{return _inqOtherEpCd;}
			set{_inqOtherEpCd = value;}
		}

		/// public propaty name  :  InqOtherSecCd
		/// <summary>問合せ先拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ先拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOtherSecCd
		{
			get{return _inqOtherSecCd;}
			set{_inqOtherSecCd = value;}
		}

		/// public propaty name  :  St_InquiryNumber
		/// <summary>開始問合せ番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始問合せ番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 St_InquiryNumber
		{
			get{return _st_InquiryNumber;}
			set{_st_InquiryNumber = value;}
		}

		/// public propaty name  :  Ed_InquiryNumber
		/// <summary>終了問合せ番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了問合せ番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 Ed_InquiryNumber
		{
			get{return _ed_InquiryNumber;}
			set{_ed_InquiryNumber = value;}
		}

		/// public propaty name  :  UpdateDate
		/// <summary>更新年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDate
		{
			get{return _updateDate;}
			set{_updateDate = value;}
		}

		/// public propaty name  :  UpdateDateJpFormal
		/// <summary>更新年月日 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDate);}
			set{}
		}

		/// public propaty name  :  UpdateDateJpInFormal
		/// <summary>更新年月日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDate);}
			set{}
		}

		/// public propaty name  :  UpdateDateAdFormal
		/// <summary>更新年月日 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDate);}
			set{}
		}

		/// public propaty name  :  UpdateDateAdInFormal
		/// <summary>更新年月日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDate);}
			set{}
		}

		/// public propaty name  :  UpdateTime
		/// <summary>更新時分秒ミリ秒プロパティ</summary>
		/// <value>HHMMSSXXX</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新時分秒ミリ秒プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UpdateTime
		{
			get{return _updateTime;}
			set{_updateTime = value;}
		}

		/// public propaty name  :  InqOrdDivCd
		/// <summary>問合せ・発注種別プロパティ</summary>
		/// <value>1:問合せ 2:発注</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ・発注種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] InqOrdDivCd
		{
			get{return _inqOrdDivCd;}
			set{_inqOrdDivCd = value;}
		}

		/// public propaty name  :  AnswerDivCd
		/// <summary>回答区分プロパティ</summary>
		/// <value>0:アクションなし 1:回答中 10:一部回答 20:回答完了 30:承認 99:キャンセル</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32[] AnswerDivCd
		{
			get{return _answerDivCd;}
			set{_answerDivCd = value;}
		}

		/// public propaty name  :  JudgementDate
		/// <summary>確定日プロパティ</summary>
		/// <value>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   確定日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 JudgementDate
		{
			get{return _judgementDate;}
			set{_judgementDate = value;}
		}

		/// public propaty name  :  InqOrdNote
		/// <summary>問合せ・発注備考プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ・発注備考プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOrdNote
		{
			get{return _inqOrdNote;}
			set{_inqOrdNote = value;}
		}

		/// public propaty name  :  InqEmployeeCd
		/// <summary>問合せ従業員コードプロパティ</summary>
		/// <value>問合せした従業員コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqEmployeeCd
		{
			get{return _inqEmployeeCd;}
			set{_inqEmployeeCd = value;}
		}

		/// public propaty name  :  InqEmployeeNm
		/// <summary>問合せ従業員名称プロパティ</summary>
		/// <value>問合せした従業員名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqEmployeeNm
		{
			get{return _inqEmployeeNm;}
			set{_inqEmployeeNm = value;}
		}

		/// public propaty name  :  AnsEmployeeCd
		/// <summary>回答従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AnsEmployeeCd
		{
			get{return _ansEmployeeCd;}
			set{_ansEmployeeCd = value;}
		}

		/// public propaty name  :  AnsEmployeeNm
		/// <summary>回答従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AnsEmployeeNm
		{
			get{return _ansEmployeeNm;}
			set{_ansEmployeeNm = value;}
		}

		/// public propaty name  :  St_InquiryDate
		/// <summary>開始問合せ日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始問合せ日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_InquiryDate
		{
			get{return _st_InquiryDate;}
			set{_st_InquiryDate = value;}
		}

		/// public propaty name  :  Ed_InquiryDate
		/// <summary>終了問合せ日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了問合せ日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_InquiryDate
		{
			get{return _ed_InquiryDate;}
			set{_ed_InquiryDate = value;}
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

		/// public propaty name  :  St_SalesSlipNum
		/// <summary>開始売上伝票番号プロパティ</summary>
		/// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始売上伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_SalesSlipNum
		{
			get{return _st_SalesSlipNum;}
			set{_st_SalesSlipNum = value;}
		}

		/// public propaty name  :  Ed_SalesSlipNum
		/// <summary>終了売上伝票番号プロパティ</summary>
		/// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了売上伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_SalesSlipNum
		{
			get{return _ed_SalesSlipNum;}
			set{_ed_SalesSlipNum = value;}
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>受注ステータスプロパティ</summary>
		/// <value>10:見積,20:受注,30:売上,40:出荷</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注ステータスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32[] AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  AwnserMethod
		/// <summary>回答方法プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答方法プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32[] AwnserMethod
		{
			get{return _awnserMethod;}
			set{_awnserMethod = value;}
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

		/// public propaty name  :  SalesTotalTaxInc
		/// <summary>売上伝票合計（税込み）プロパティ</summary>
		/// <value>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票合計（税込み）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesTotalTaxInc
		{
			get{return _salesTotalTaxInc;}
			set{_salesTotalTaxInc = value;}
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

        // 2010/05/27 Add >>>
        /// <summary>売上伝票番号プロパティ</summary>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }
        // 2010/05/27 Add <<<
        // ---- ADD gezh 2011/11/12 --------------------------------------->>>>>
        /// public propaty name  :  CooperationOptionDiv
        /// <summary>連携対象区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連携対象区分プロパティ</br>
        /// <br>Programer        :   葛中華</br>
        /// </remarks>
        public Int16[] CooperationOptionDiv
        {
            get { return _cooperationOptionDiv; }
            set { _cooperationOptionDiv = value; }
        }
        // ---- ADD gezh 2011/11/12 ---------------------------------------<<<<<

        // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
        /// public propaty name  :  St_ExpectedCeDate
        /// <summary>開始入庫予定日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始入庫予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_ExpectedCeDate
        {
            get { return _st_ExpectedCeDate; }
            set { _st_ExpectedCeDate = value; }
        }

        /// public propaty name  :  Ed_ExpectedCeDate
        /// <summary>終了入庫予定日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了入庫予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_ExpectedCeDate
        {
            get { return _ed_ExpectedCeDate; }
            set { _ed_ExpectedCeDate = value; }
        }
        // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<

		/// <summary>
		/// SCM問い合わせ一覧抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>SCMInquiryOrderクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMInquiryOrderクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMInquiryOrder()
		{
		}

		/// <summary>
		/// SCM問い合わせ一覧抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="inqOriginalEpCd">問合せ元企業コード</param>
		/// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
		/// <param name="inqOtherEpCd">問合せ先企業コード</param>
		/// <param name="inqOtherSecCd">問合せ先拠点コード</param>
		/// <param name="st_InquiryNumber">開始問合せ番号</param>
		/// <param name="ed_InquiryNumber">終了問合せ番号</param>
		/// <param name="updateDate">更新年月日(YYYYMMDD)</param>
		/// <param name="updateTime">更新時分秒ミリ秒(HHMMSSXXX)</param>
		/// <param name="inqOrdDivCd">問合せ・発注種別(1:問合せ 2:発注)</param>
		/// <param name="answerDivCd">回答区分(0:アクションなし 1:回答中 10:一部回答 20:回答完了 30:承認 99:キャンセル)</param>
		/// <param name="judgementDate">確定日(YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。)</param>
		/// <param name="inqOrdNote">問合せ・発注備考</param>
		/// <param name="inqEmployeeCd">問合せ従業員コード(問合せした従業員コード)</param>
		/// <param name="inqEmployeeNm">問合せ従業員名称(問合せした従業員名称)</param>
		/// <param name="ansEmployeeCd">回答従業員コード</param>
		/// <param name="ansEmployeeNm">回答従業員名称</param>
		/// <param name="st_InquiryDate">開始問合せ日(YYYYMMDD)</param>
		/// <param name="ed_InquiryDate">終了問合せ日(YYYYMMDD)</param>
		/// <param name="st_CustomerCode">開始得意先コード</param>
		/// <param name="ed_CustomerCode">終了得意先コード</param>
		/// <param name="st_SalesSlipNum">開始売上伝票番号(見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。)</param>
		/// <param name="ed_SalesSlipNum">終了売上伝票番号(見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。)</param>
		/// <param name="acptAnOdrStatus">受注ステータス(10:見積,20:受注,30:売上,40:出荷)</param>
		/// <param name="awnserMethod">回答方法</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="salesTotalTaxInc">売上伝票合計（税込み）(売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額)</param>
		/// <param name="enterpriseName">企業名称</param>
        /// <param name="st_ExpectedCeDate">開始入庫予定日(YYYYMMDD)</param>  // ADD yugami 2013/05/10
        /// <param name="ed_ExpectedCeDate">終了入庫予定日(YYYYMMDD)</param>  // ADD yugami 2013/05/10
        /// <param name="salesSlipNum">連携対象区分</param> // ADD gezh 2011/11/12
		/// <returns>SCMInquiryOrderクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMInquiryOrderクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Note　　　　　　 :   Redmine 26534 受発注種別を追加し、PCCforNSとBLパーツオーダーシステムの判断を可能とする</br>
        /// <br>Programer        :   葛中華</br>
		/// </remarks>
        // 2010/05/27 >>>
        //public SCMInquiryOrder(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 st_InquiryNumber, Int64 ed_InquiryNumber, DateTime updateDate, Int32 updateTime, Int32[] inqOrdDivCd, Int32[] answerDivCd, Int32 judgementDate, string inqOrdNote, string inqEmployeeCd, string inqEmployeeNm, string ansEmployeeCd, string ansEmployeeNm, Int32 st_InquiryDate, Int32 ed_InquiryDate, Int32 st_CustomerCode, Int32 ed_CustomerCode, string st_SalesSlipNum, string ed_SalesSlipNum, Int32[] acptAnOdrStatus, Int32[] awnserMethod, string enterpriseCode, Int32 customerCode, Int64 salesTotalTaxInc, string enterpriseName)
        //public SCMInquiryOrder(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 st_InquiryNumber, Int64 ed_InquiryNumber, DateTime updateDate, Int32 updateTime, Int32[] inqOrdDivCd, Int32[] answerDivCd, Int32 judgementDate, string inqOrdNote, string inqEmployeeCd, string inqEmployeeNm, string ansEmployeeCd, string ansEmployeeNm, Int32 st_InquiryDate, Int32 ed_InquiryDate, Int32 st_CustomerCode, Int32 ed_CustomerCode, string st_SalesSlipNum, string ed_SalesSlipNum, Int32[] acptAnOdrStatus, Int32[] awnserMethod, string enterpriseCode, Int32 customerCode, Int64 salesTotalTaxInc, string enterpriseName, string salesSlipNum) // DEL gezh 2011/11/12
        // UPD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
        //public SCMInquiryOrder(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 st_InquiryNumber, Int64 ed_InquiryNumber, DateTime updateDate, Int32 updateTime, Int32[] inqOrdDivCd, Int32[] answerDivCd, Int32 judgementDate, string inqOrdNote, string inqEmployeeCd, string inqEmployeeNm, string ansEmployeeCd, string ansEmployeeNm, Int32 st_InquiryDate, Int32 ed_InquiryDate, Int32 st_CustomerCode, Int32 ed_CustomerCode, string st_SalesSlipNum, string ed_SalesSlipNum, Int32[] acptAnOdrStatus, Int32[] awnserMethod, string enterpriseCode, Int32 customerCode, Int64 salesTotalTaxInc, string enterpriseName, string salesSlipNum, Int16[] cooperationOptionDiv) // ADD gezh 2011/11/12
        public SCMInquiryOrder(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 st_InquiryNumber, Int64 ed_InquiryNumber, DateTime updateDate, Int32 updateTime, Int32[] inqOrdDivCd, Int32[] answerDivCd, Int32 judgementDate, string inqOrdNote, string inqEmployeeCd, string inqEmployeeNm, string ansEmployeeCd, string ansEmployeeNm, Int32 st_InquiryDate, Int32 ed_InquiryDate, Int32 st_CustomerCode, Int32 ed_CustomerCode, string st_SalesSlipNum, string ed_SalesSlipNum, Int32[] acptAnOdrStatus, Int32[] awnserMethod, string enterpriseCode, Int32 customerCode, Int64 salesTotalTaxInc, string enterpriseName, string salesSlipNum, Int16[] cooperationOptionDiv, Int32 st_ExpectedCeDate, Int32 ed_ExpectedCeDate)
        // UPD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
        // 2010/05/27 <<<
        {
			this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
			this._inqOriginalSecCd = inqOriginalSecCd;
			this._inqOtherEpCd = inqOtherEpCd;
			this._inqOtherSecCd = inqOtherSecCd;
			this._st_InquiryNumber = st_InquiryNumber;
			this._ed_InquiryNumber = ed_InquiryNumber;
			this.UpdateDate = updateDate;
			this._updateTime = updateTime;
			this._inqOrdDivCd = inqOrdDivCd;
			this._answerDivCd = answerDivCd;
			this._judgementDate = judgementDate;
			this._inqOrdNote = inqOrdNote;
			this._inqEmployeeCd = inqEmployeeCd;
			this._inqEmployeeNm = inqEmployeeNm;
			this._ansEmployeeCd = ansEmployeeCd;
			this._ansEmployeeNm = ansEmployeeNm;
			this._st_InquiryDate = st_InquiryDate;
			this._ed_InquiryDate = ed_InquiryDate;
			this._st_CustomerCode = st_CustomerCode;
			this._ed_CustomerCode = ed_CustomerCode;
			this._st_SalesSlipNum = st_SalesSlipNum;
			this._ed_SalesSlipNum = ed_SalesSlipNum;
			this._acptAnOdrStatus = acptAnOdrStatus;
			this._awnserMethod = awnserMethod;
			this._enterpriseCode = enterpriseCode;
			this._customerCode = customerCode;
			this._salesTotalTaxInc = salesTotalTaxInc;
			this._enterpriseName = enterpriseName;
            // 2010/05/27 Add >>>
            this._salesSlipNum = salesSlipNum;
            // 2010/05/27 Add <<<
            // ----ADD gezh 2011/11/12 ---------------------------------->>>>>
            this._cooperationOptionDiv = cooperationOptionDiv;
            // ----ADD gezh 2011/11/12 ----------------------------------<<<<<
            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            this._st_ExpectedCeDate = st_ExpectedCeDate;
            this._ed_ExpectedCeDate = ed_ExpectedCeDate;
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
        }

		/// <summary>
		/// SCM問い合わせ一覧抽出条件クラス複製処理
		/// </summary>
		/// <returns>SCMInquiryOrderクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSCMInquiryOrderクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Note　　　　　　 :   Redmine 26534 受発注種別を追加し、PCCforNSとBLパーツオーダーシステムの判断を可能とする</br>
        /// <br>Programer        :   葛中華</br>
		/// </remarks>
		public SCMInquiryOrder Clone()
		{
            // 2010/05/27 >>>
            //return new SCMInquiryOrder(this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._st_InquiryNumber, this._ed_InquiryNumber, this._updateDate, this._updateTime, this._inqOrdDivCd, this._answerDivCd, this._judgementDate, this._inqOrdNote, this._inqEmployeeCd, this._inqEmployeeNm, this._ansEmployeeCd, this._ansEmployeeNm, this._st_InquiryDate, this._ed_InquiryDate, this._st_CustomerCode, this._ed_CustomerCode, this._st_SalesSlipNum, this._ed_SalesSlipNum, this._acptAnOdrStatus, this._awnserMethod, this._enterpriseCode, this._customerCode, this._salesTotalTaxInc, this._enterpriseName);
            //return new SCMInquiryOrder(this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._st_InquiryNumber, this._ed_InquiryNumber, this._updateDate, this._updateTime, this._inqOrdDivCd, this._answerDivCd, this._judgementDate, this._inqOrdNote, this._inqEmployeeCd, this._inqEmployeeNm, this._ansEmployeeCd, this._ansEmployeeNm, this._st_InquiryDate, this._ed_InquiryDate, this._st_CustomerCode, this._ed_CustomerCode, this._st_SalesSlipNum, this._ed_SalesSlipNum, this._acptAnOdrStatus, this._awnserMethod, this._enterpriseCode, this._customerCode, this._salesTotalTaxInc, this._enterpriseName, this._salesSlipNum); // DEL gezh 2011/11/12
            // UPD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            //return new SCMInquiryOrder(this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._st_InquiryNumber, this._ed_InquiryNumber, this._updateDate, this._updateTime, this._inqOrdDivCd, this._answerDivCd, this._judgementDate, this._inqOrdNote, this._inqEmployeeCd, this._inqEmployeeNm, this._ansEmployeeCd, this._ansEmployeeNm, this._st_InquiryDate, this._ed_InquiryDate, this._st_CustomerCode, this._ed_CustomerCode, this._st_SalesSlipNum, this._ed_SalesSlipNum, this._acptAnOdrStatus, this._awnserMethod, this._enterpriseCode, this._customerCode, this._salesTotalTaxInc, this._enterpriseName, this._salesSlipNum, this._cooperationOptionDiv); // ADD gezh 2011/11/12
            return new SCMInquiryOrder(this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._st_InquiryNumber, this._ed_InquiryNumber, this._updateDate, this._updateTime, this._inqOrdDivCd, this._answerDivCd, this._judgementDate, this._inqOrdNote, this._inqEmployeeCd, this._inqEmployeeNm, this._ansEmployeeCd, this._ansEmployeeNm, this._st_InquiryDate, this._ed_InquiryDate, this._st_CustomerCode, this._ed_CustomerCode, this._st_SalesSlipNum, this._ed_SalesSlipNum, this._acptAnOdrStatus, this._awnserMethod, this._enterpriseCode, this._customerCode, this._salesTotalTaxInc, this._enterpriseName, this._salesSlipNum, this._cooperationOptionDiv, this._st_ExpectedCeDate, this._ed_ExpectedCeDate);//@@@@20230303
            // UPD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
            // 2010/05/27 <<<
        }

		/// <summary>
		/// SCM問い合わせ一覧抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSCMInquiryOrderクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMInquiryOrderクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Note　　　　　　 :   Redmine 26534 受発注種別を追加し、PCCforNSとBLパーツオーダーシステムの判断を可能とする</br>
        /// <br>Programer        :   葛中華</br>
		/// </remarks>
		public bool Equals(SCMInquiryOrder target)
		{
			return ((this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim()) //@@@@20230303
				 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
				 && (this.InqOtherEpCd == target.InqOtherEpCd)
				 && (this.InqOtherSecCd == target.InqOtherSecCd)
				 && (this.St_InquiryNumber == target.St_InquiryNumber)
				 && (this.Ed_InquiryNumber == target.Ed_InquiryNumber)
				 && (this.UpdateDate == target.UpdateDate)
				 && (this.UpdateTime == target.UpdateTime)
				 && (this.InqOrdDivCd == target.InqOrdDivCd)
				 && (this.AnswerDivCd == target.AnswerDivCd)
				 && (this.JudgementDate == target.JudgementDate)
				 && (this.InqOrdNote == target.InqOrdNote)
				 && (this.InqEmployeeCd == target.InqEmployeeCd)
				 && (this.InqEmployeeNm == target.InqEmployeeNm)
				 && (this.AnsEmployeeCd == target.AnsEmployeeCd)
				 && (this.AnsEmployeeNm == target.AnsEmployeeNm)
				 && (this.St_InquiryDate == target.St_InquiryDate)
				 && (this.Ed_InquiryDate == target.Ed_InquiryDate)
				 && (this.St_CustomerCode == target.St_CustomerCode)
				 && (this.Ed_CustomerCode == target.Ed_CustomerCode)
				 && (this.St_SalesSlipNum == target.St_SalesSlipNum)
				 && (this.Ed_SalesSlipNum == target.Ed_SalesSlipNum)
				 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
				 && (this.AwnserMethod == target.AwnserMethod)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.SalesTotalTaxInc == target.SalesTotalTaxInc)
                // 2010/05/27 Add >>>
                && ( this.SalesSlipNum == target.SalesSlipNum )
                // 2010/05/27 Add <<<
                // ----ADD gezh 2011/11/12 -------------------------------->>>>>
                && (this.CooperationOptionDiv == target.CooperationOptionDiv)
                // ----ADD gezh 2011/11/12 --------------------------------<<<<<
                // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
                && (this.St_ExpectedCeDate == target.St_ExpectedCeDate)
                && (this.Ed_ExpectedCeDate == target.Ed_ExpectedCeDate)
                // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
                 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// SCM問い合わせ一覧抽出条件クラス比較処理
		/// </summary>
		/// <param name="sCMInquiryOrder1">
		///                    比較するSCMInquiryOrderクラスのインスタンス
		/// </param>
		/// <param name="sCMInquiryOrder2">比較するSCMInquiryOrderクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMInquiryOrderクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Note　　　　　　 :   Redmine 26534 受発注種別を追加し、PCCforNSとBLパーツオーダーシステムの判断を可能とする</br>
        /// <br>Programer        :   葛中華</br>
		/// </remarks>
		public static bool Equals(SCMInquiryOrder sCMInquiryOrder1, SCMInquiryOrder sCMInquiryOrder2)
		{
			return ((sCMInquiryOrder1.InqOriginalEpCd.Trim() == sCMInquiryOrder2.InqOriginalEpCd.Trim()) //@@@@20230303
				 && (sCMInquiryOrder1.InqOriginalSecCd == sCMInquiryOrder2.InqOriginalSecCd)
				 && (sCMInquiryOrder1.InqOtherEpCd == sCMInquiryOrder2.InqOtherEpCd)
				 && (sCMInquiryOrder1.InqOtherSecCd == sCMInquiryOrder2.InqOtherSecCd)
				 && (sCMInquiryOrder1.St_InquiryNumber == sCMInquiryOrder2.St_InquiryNumber)
				 && (sCMInquiryOrder1.Ed_InquiryNumber == sCMInquiryOrder2.Ed_InquiryNumber)
				 && (sCMInquiryOrder1.UpdateDate == sCMInquiryOrder2.UpdateDate)
				 && (sCMInquiryOrder1.UpdateTime == sCMInquiryOrder2.UpdateTime)
				 && (sCMInquiryOrder1.InqOrdDivCd == sCMInquiryOrder2.InqOrdDivCd)
				 && (sCMInquiryOrder1.AnswerDivCd == sCMInquiryOrder2.AnswerDivCd)
				 && (sCMInquiryOrder1.JudgementDate == sCMInquiryOrder2.JudgementDate)
				 && (sCMInquiryOrder1.InqOrdNote == sCMInquiryOrder2.InqOrdNote)
				 && (sCMInquiryOrder1.InqEmployeeCd == sCMInquiryOrder2.InqEmployeeCd)
				 && (sCMInquiryOrder1.InqEmployeeNm == sCMInquiryOrder2.InqEmployeeNm)
				 && (sCMInquiryOrder1.AnsEmployeeCd == sCMInquiryOrder2.AnsEmployeeCd)
				 && (sCMInquiryOrder1.AnsEmployeeNm == sCMInquiryOrder2.AnsEmployeeNm)
				 && (sCMInquiryOrder1.St_InquiryDate == sCMInquiryOrder2.St_InquiryDate)
				 && (sCMInquiryOrder1.Ed_InquiryDate == sCMInquiryOrder2.Ed_InquiryDate)
				 && (sCMInquiryOrder1.St_CustomerCode == sCMInquiryOrder2.St_CustomerCode)
				 && (sCMInquiryOrder1.Ed_CustomerCode == sCMInquiryOrder2.Ed_CustomerCode)
				 && (sCMInquiryOrder1.St_SalesSlipNum == sCMInquiryOrder2.St_SalesSlipNum)
				 && (sCMInquiryOrder1.Ed_SalesSlipNum == sCMInquiryOrder2.Ed_SalesSlipNum)
				 && (sCMInquiryOrder1.AcptAnOdrStatus == sCMInquiryOrder2.AcptAnOdrStatus)
				 && (sCMInquiryOrder1.AwnserMethod == sCMInquiryOrder2.AwnserMethod)
				 && (sCMInquiryOrder1.EnterpriseCode == sCMInquiryOrder2.EnterpriseCode)
				 && (sCMInquiryOrder1.CustomerCode == sCMInquiryOrder2.CustomerCode)
				 && (sCMInquiryOrder1.SalesTotalTaxInc == sCMInquiryOrder2.SalesTotalTaxInc)
                // 2010/05/27 Add >>>
                && ( sCMInquiryOrder1.SalesSlipNum == sCMInquiryOrder2.SalesSlipNum )
                // 2010/05/27 Add <<<
                // ----ADD gezh 2011/11/12 -------------------------------->>>>>
                && (sCMInquiryOrder1.CooperationOptionDiv == sCMInquiryOrder2.CooperationOptionDiv)
                // ----ADD gezh 2011/11/12 --------------------------------<<<<<
                // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
                && (sCMInquiryOrder1.St_ExpectedCeDate == sCMInquiryOrder2.St_ExpectedCeDate)
                && (sCMInquiryOrder1.Ed_ExpectedCeDate == sCMInquiryOrder2.Ed_ExpectedCeDate)
                // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
                 && ( sCMInquiryOrder1.EnterpriseName == sCMInquiryOrder2.EnterpriseName ) );
		}
		/// <summary>
		/// SCM問い合わせ一覧抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSCMInquiryOrderクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMInquiryOrderクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Note　　　　　　 :   Redmine 26534 受発注種別を追加し、PCCforNSとBLパーツオーダーシステムの判断を可能とする</br>
        /// <br>Programer        :   葛中華</br>
		/// </remarks>
		public ArrayList Compare(SCMInquiryOrder target)
		{
			ArrayList resList = new ArrayList();
			if(this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(this.InqOriginalSecCd != target.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(this.InqOtherEpCd != target.InqOtherEpCd)resList.Add("InqOtherEpCd");
			if(this.InqOtherSecCd != target.InqOtherSecCd)resList.Add("InqOtherSecCd");
			if(this.St_InquiryNumber != target.St_InquiryNumber)resList.Add("St_InquiryNumber");
			if(this.Ed_InquiryNumber != target.Ed_InquiryNumber)resList.Add("Ed_InquiryNumber");
			if(this.UpdateDate != target.UpdateDate)resList.Add("UpdateDate");
			if(this.UpdateTime != target.UpdateTime)resList.Add("UpdateTime");
			if(this.InqOrdDivCd != target.InqOrdDivCd)resList.Add("InqOrdDivCd");
			if(this.AnswerDivCd != target.AnswerDivCd)resList.Add("AnswerDivCd");
			if(this.JudgementDate != target.JudgementDate)resList.Add("JudgementDate");
			if(this.InqOrdNote != target.InqOrdNote)resList.Add("InqOrdNote");
			if(this.InqEmployeeCd != target.InqEmployeeCd)resList.Add("InqEmployeeCd");
			if(this.InqEmployeeNm != target.InqEmployeeNm)resList.Add("InqEmployeeNm");
			if(this.AnsEmployeeCd != target.AnsEmployeeCd)resList.Add("AnsEmployeeCd");
			if(this.AnsEmployeeNm != target.AnsEmployeeNm)resList.Add("AnsEmployeeNm");
			if(this.St_InquiryDate != target.St_InquiryDate)resList.Add("St_InquiryDate");
			if(this.Ed_InquiryDate != target.Ed_InquiryDate)resList.Add("Ed_InquiryDate");
			if(this.St_CustomerCode != target.St_CustomerCode)resList.Add("St_CustomerCode");
			if(this.Ed_CustomerCode != target.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
			if(this.St_SalesSlipNum != target.St_SalesSlipNum)resList.Add("St_SalesSlipNum");
			if(this.Ed_SalesSlipNum != target.Ed_SalesSlipNum)resList.Add("Ed_SalesSlipNum");
			if(this.AcptAnOdrStatus != target.AcptAnOdrStatus)resList.Add("AcptAnOdrStatus");
			if(this.AwnserMethod != target.AwnserMethod)resList.Add("AwnserMethod");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.SalesTotalTaxInc != target.SalesTotalTaxInc)resList.Add("SalesTotalTaxInc");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            // 2010/05/27 Add >>>
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            // 2010/05/27 Add <<<
            // ----ADD gezh 2011/11/12 ----------------------------------------------------------------->>>>>
            if (this.CooperationOptionDiv != target.CooperationOptionDiv) resList.Add("CooperationOptionDiv");
            // ----ADD gezh 2011/11/12 -----------------------------------------------------------------<<<<<
            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            if (this.St_ExpectedCeDate != target.St_ExpectedCeDate) resList.Add("St_ExpectedCeDate");
            if (this.Ed_ExpectedCeDate != target.Ed_ExpectedCeDate) resList.Add("Ed_ExpectedCeDate");
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
            return resList;
		}

		/// <summary>
		/// SCM問い合わせ一覧抽出条件クラス比較処理
		/// </summary>
		/// <param name="sCMInquiryOrder1">比較するSCMInquiryOrderクラスのインスタンス</param>
		/// <param name="sCMInquiryOrder2">比較するSCMInquiryOrderクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMInquiryOrderクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Note　　　　　　 :   Redmine 26534 受発注種別を追加し、PCCforNSとBLパーツオーダーシステムの判断を可能とする</br>
        /// <br>Programer        :   葛中華</br>
		/// </remarks>
		public static ArrayList Compare(SCMInquiryOrder sCMInquiryOrder1, SCMInquiryOrder sCMInquiryOrder2)
		{
			ArrayList resList = new ArrayList();
			if(sCMInquiryOrder1.InqOriginalEpCd.Trim() != sCMInquiryOrder2.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(sCMInquiryOrder1.InqOriginalSecCd != sCMInquiryOrder2.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(sCMInquiryOrder1.InqOtherEpCd != sCMInquiryOrder2.InqOtherEpCd)resList.Add("InqOtherEpCd");
			if(sCMInquiryOrder1.InqOtherSecCd != sCMInquiryOrder2.InqOtherSecCd)resList.Add("InqOtherSecCd");
			if(sCMInquiryOrder1.St_InquiryNumber != sCMInquiryOrder2.St_InquiryNumber)resList.Add("St_InquiryNumber");
			if(sCMInquiryOrder1.Ed_InquiryNumber != sCMInquiryOrder2.Ed_InquiryNumber)resList.Add("Ed_InquiryNumber");
			if(sCMInquiryOrder1.UpdateDate != sCMInquiryOrder2.UpdateDate)resList.Add("UpdateDate");
			if(sCMInquiryOrder1.UpdateTime != sCMInquiryOrder2.UpdateTime)resList.Add("UpdateTime");
			if(sCMInquiryOrder1.InqOrdDivCd != sCMInquiryOrder2.InqOrdDivCd)resList.Add("InqOrdDivCd");
			if(sCMInquiryOrder1.AnswerDivCd != sCMInquiryOrder2.AnswerDivCd)resList.Add("AnswerDivCd");
			if(sCMInquiryOrder1.JudgementDate != sCMInquiryOrder2.JudgementDate)resList.Add("JudgementDate");
			if(sCMInquiryOrder1.InqOrdNote != sCMInquiryOrder2.InqOrdNote)resList.Add("InqOrdNote");
			if(sCMInquiryOrder1.InqEmployeeCd != sCMInquiryOrder2.InqEmployeeCd)resList.Add("InqEmployeeCd");
			if(sCMInquiryOrder1.InqEmployeeNm != sCMInquiryOrder2.InqEmployeeNm)resList.Add("InqEmployeeNm");
			if(sCMInquiryOrder1.AnsEmployeeCd != sCMInquiryOrder2.AnsEmployeeCd)resList.Add("AnsEmployeeCd");
			if(sCMInquiryOrder1.AnsEmployeeNm != sCMInquiryOrder2.AnsEmployeeNm)resList.Add("AnsEmployeeNm");
			if(sCMInquiryOrder1.St_InquiryDate != sCMInquiryOrder2.St_InquiryDate)resList.Add("St_InquiryDate");
			if(sCMInquiryOrder1.Ed_InquiryDate != sCMInquiryOrder2.Ed_InquiryDate)resList.Add("Ed_InquiryDate");
			if(sCMInquiryOrder1.St_CustomerCode != sCMInquiryOrder2.St_CustomerCode)resList.Add("St_CustomerCode");
			if(sCMInquiryOrder1.Ed_CustomerCode != sCMInquiryOrder2.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
			if(sCMInquiryOrder1.St_SalesSlipNum != sCMInquiryOrder2.St_SalesSlipNum)resList.Add("St_SalesSlipNum");
			if(sCMInquiryOrder1.Ed_SalesSlipNum != sCMInquiryOrder2.Ed_SalesSlipNum)resList.Add("Ed_SalesSlipNum");
			if(sCMInquiryOrder1.AcptAnOdrStatus != sCMInquiryOrder2.AcptAnOdrStatus)resList.Add("AcptAnOdrStatus");
			if(sCMInquiryOrder1.AwnserMethod != sCMInquiryOrder2.AwnserMethod)resList.Add("AwnserMethod");
			if(sCMInquiryOrder1.EnterpriseCode != sCMInquiryOrder2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(sCMInquiryOrder1.CustomerCode != sCMInquiryOrder2.CustomerCode)resList.Add("CustomerCode");
			if(sCMInquiryOrder1.SalesTotalTaxInc != sCMInquiryOrder2.SalesTotalTaxInc)resList.Add("SalesTotalTaxInc");
			if(sCMInquiryOrder1.EnterpriseName != sCMInquiryOrder2.EnterpriseName)resList.Add("EnterpriseName");
            // 2010/05/27 Add >>>
            if (sCMInquiryOrder1.SalesSlipNum != sCMInquiryOrder2.SalesSlipNum) resList.Add("SalesSlipNum");
            // 2010/05/27 Add <<<
            // ----ADD gezh 2011/11/12 ----------------------------------------------------------------------------------------->>>>>
            if (sCMInquiryOrder1.CooperationOptionDiv != sCMInquiryOrder2.CooperationOptionDiv) resList.Add("CooperationOptionDiv");
            // ----ADD gezh 2011/11/12 -----------------------------------------------------------------------------------------<<<<<
            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            if (sCMInquiryOrder1.St_ExpectedCeDate != sCMInquiryOrder2.St_ExpectedCeDate) resList.Add("St_ExpectedCeDate");
            if (sCMInquiryOrder1.Ed_ExpectedCeDate != sCMInquiryOrder2.Ed_ExpectedCeDate) resList.Add("Ed_ExpectedCeDate");
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
            return resList;
		}

        /// <summary>
        /// 回答区分
        /// </summary>
        public enum AnswerDivState
        {
            /// <summary>アクションなし(回答中)</summary>
            Non = 0,
            /// <summary>一部回答</summary>
            Part = 10,
            /// <summary>回答完了</summary>
            Complete = 20,
            /// <summary>キャンセル</summary>
            Cancel = 99
        }

        /// <summary>
        /// 回答方法
        /// </summary>
        public enum AnswerMethodState
        {
            /// <summary>自動</summary>
            Auto = 0,
            /// <summary>手動(Web)</summary>
            ManualWeb = 1,
            /// <summary>手動(その他)</summary>
            ManualOther = 2
        }

        /// <summary>
        /// 受注ステータス
        /// </summary>
        public enum AcptAnOdrStatusState
        {
            /// <summary>未設定</summary>
            NotSet = 0,
            /// <summary>見積</summary>
            Estimate = 10,
            /// <summary>受注</summary>
            Accept = 20,
            /// <summary>売上</summary>
            Sales = 30,
        }

        /// <summary>
        /// 問合せ・発注区分
        /// </summary>
        public enum InqOrdDivState
        {
            /// <summary>問合せ</summary>
            Estimate = 1,
            /// <summary>発注</summary>
            Accept = 2
        }
        // ADD gezh 2011/11/12 -------->>>>>
        /// <summary>
        /// 連携対象区分
        /// </summary>
        public enum CooperationOptionDivState
        {
            /// <summary>PCCforNS</summary>
            PCCNS = 0,
            /// <summary>BLﾊﾟｰﾂｵｰﾀﾞｰ</summary>
            BL = 1
        }
        // ADD gezh 2011/11/12 --------<<<<<
	}
}
