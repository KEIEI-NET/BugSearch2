//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   SCM関連データデータパラメータ
//                  :   PMSCM01023D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2009.05.13
//----------------------------------------------------------------------
// Update Note      :   ○項目追加
//                        キャンセル区分 
//                        CMT連携区分
// Programmer       :   21024 佐々木 健
// Date             :   2010/05/26
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{

    # region delete
    /*                                
	/// public class name:   SCMAcOdrDataWork
    ///
	/// <summary>
	///                      SCM受注データワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM受注データワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/04/30</br>
	/// <br>Genarated Date   :   2009/05/29  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/05/18  杉村</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   受注ステータス</br>
	/// <br>                 :   売上伝票番号</br>
	/// <br>                 :   売上伝票合計（税込み）</br>
	/// <br>                 :   売上小計（税）</br>
	/// <br>Update Note      :   2009/05/26  杉村</br>
	/// <br>                 :   ○項目削除</br>
	/// <br>                 :   発注日</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   問合せ・発注種別</br>
	/// <br>                 :   問発・回答種別</br>
	/// <br>                 :   受信日時</br>
	/// <br>Update Note      :   2009/05/29  杉村</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   回答作成区分</br>
    /// <br></br>
    /// <br>Update Note      :   2010/05/26  21024 佐々木</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   キャンセル区分</br>
    /// <br>                 :   CMT連携区分</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SCMAcOdrDataWork : IFileHeader
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>更新従業員コード</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private string _updEmployeeCode = "";

		/// <summary>更新アセンブリID1</summary>
		/// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>更新アセンブリID2</summary>
		/// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>問合せ元企業コード</summary>
		private string _inqOriginalEpCd = "";

		/// <summary>問合せ元拠点コード</summary>
		private string _inqOriginalSecCd = "";

		/// <summary>問合せ先企業コード</summary>
		private string _inqOtherEpCd = "";

		/// <summary>問合せ先拠点コード</summary>
		private string _inqOtherSecCd = "";

		/// <summary>問合せ番号</summary>
		private Int64 _inquiryNumber;

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>更新年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>更新時間</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;

		/// <summary>回答区分</summary>
		/// <remarks>0:アクションなし 10:一部回答 20:回答完了 30:承認 99:キャンセル</remarks>
		private Int32 _answerDivCd;

		/// <summary>確定日</summary>
		/// <remarks>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</remarks>
		private DateTime _judgementDate;

		/// <summary>問合せ・発注備考</summary>
		private string _inqOrdNote = "";

		/// <summary>添付ファイル</summary>
		private Byte[] _appendingFile = new Byte[0];

		/// <summary>添付ファイル名</summary>
		private string _appendingFileNm = "";

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

		/// <summary>問合せ日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _inquiryDate;

		/// <summary>受注ステータス</summary>
		/// <remarks>10:見積,20:受注,30:売上</remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>売上伝票番号</summary>
		/// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
		private string _salesSlipNum = "";

		/// <summary>売上伝票合計（税込み）</summary>
		/// <remarks>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</remarks>
		private Int64 _salesTotalTaxInc;

		/// <summary>売上小計（税）</summary>
		/// <remarks>値引後の税額（外税分、内税分の合計）</remarks>
		private Int64 _salesSubtotalTax;

		/// <summary>問合せ・発注種別</summary>
		/// <remarks>1:問合せ 2:発注</remarks>
		private Int32 _inqOrdDivCd;

		/// <summary>問発・回答種別</summary>
		/// <remarks>1:問合せ・発注 2:回答</remarks>
		private Int32 _inqOrdAnsDivCd;

		/// <summary>受信日時</summary>
		/// <remarks>（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _receiveDateTime;

		/// <summary>回答作成区分</summary>
		/// <remarks>0:自動, 1:手動（Web）, 2:手動（その他）</remarks>
		private Int32 _answerCreateDiv;

        // 2010/05/26 Add >>>
        /// <summary>キャンセル区分</summary>
        /// <remarks>0:キャンセルなし 1:キャンセルあり</remarks>
        private Int16 _cancelDiv;

        /// <summary>CMT連携区分</summary>
        /// <remarks>0:連携なし 1:連携あり</remarks>
        private Int16 _cMTCooprtDiv;
        // 2010/05/26 Add <<<

		/// public propaty name  :  CreateDateTime
		/// <summary>作成日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>更新日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
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

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUIDプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>更新従業員コードプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>更新アセンブリID1プロパティ</summary>
		/// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>更新アセンブリID2プロパティ</summary>
		/// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>論理削除区分プロパティ</summary>
		/// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
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

		/// public propaty name  :  InquiryNumber
		/// <summary>問合せ番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 InquiryNumber
		{
			get{return _inquiryNumber;}
			set{_inquiryNumber = value;}
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

		/// public propaty name  :  UpdateTime
		/// <summary>更新時間プロパティ</summary>
		/// <value>HHMMSSXXX</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新時間プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UpdateTime
		{
			get{return _updateTime;}
			set{_updateTime = value;}
		}

		/// public propaty name  :  AnswerDivCd
		/// <summary>回答区分プロパティ</summary>
		/// <value>0:アクションなし 10:一部回答 20:回答完了 30:承認 99:キャンセル</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AnswerDivCd
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
		public DateTime JudgementDate
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

		/// public propaty name  :  AppendingFile
		/// <summary>添付ファイルプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   添付ファイルプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Byte[] AppendingFile
		{
			get{return _appendingFile;}
			set{_appendingFile = value;}
		}

		/// public propaty name  :  AppendingFileNm
		/// <summary>添付ファイル名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   添付ファイル名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AppendingFileNm
		{
			get{return _appendingFileNm;}
			set{_appendingFileNm = value;}
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

		/// public propaty name  :  InquiryDate
		/// <summary>問合せ日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime InquiryDate
		{
			get{return _inquiryDate;}
			set{_inquiryDate = value;}
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>受注ステータスプロパティ</summary>
		/// <value>10:見積,20:受注,30:売上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注ステータスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  SalesSlipNum
		/// <summary>売上伝票番号プロパティ</summary>
		/// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesSlipNum
		{
			get{return _salesSlipNum;}
			set{_salesSlipNum = value;}
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

		/// public propaty name  :  SalesSubtotalTax
		/// <summary>売上小計（税）プロパティ</summary>
		/// <value>値引後の税額（外税分、内税分の合計）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上小計（税）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesSubtotalTax
		{
			get{return _salesSubtotalTax;}
			set{_salesSubtotalTax = value;}
		}

		/// public propaty name  :  InqOrdDivCd
		/// <summary>問合せ・発注種別プロパティ</summary>
		/// <value>1:問合せ 2:発注</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ・発注種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InqOrdDivCd
		{
			get{return _inqOrdDivCd;}
			set{_inqOrdDivCd = value;}
		}

		/// public propaty name  :  InqOrdAnsDivCd
		/// <summary>問発・回答種別プロパティ</summary>
		/// <value>1:問合せ・発注 2:回答</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問発・回答種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InqOrdAnsDivCd
		{
			get{return _inqOrdAnsDivCd;}
			set{_inqOrdAnsDivCd = value;}
		}

		/// public propaty name  :  ReceiveDateTime
		/// <summary>受信日時プロパティ</summary>
		/// <value>（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受信日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime ReceiveDateTime
		{
			get{return _receiveDateTime;}
			set{_receiveDateTime = value;}
		}

		/// public propaty name  :  AnswerCreateDiv
		/// <summary>回答作成区分プロパティ</summary>
		/// <value>0:自動, 1:手動（Web）, 2:手動（その他）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答作成区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AnswerCreateDiv
		{
			get{return _answerCreateDiv;}
			set{_answerCreateDiv = value;}
		}

        // 2010/05/26 Add >>>
        /// public propaty name  :  CancelDiv
        /// <summary>キャンセル区分プロパティ</summary>
        /// <value>0:キャンセルなし 1:キャンセルあり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンセル区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 CancelDiv
        {
            get { return _cancelDiv; }
            set { _cancelDiv = value; }
        }

        /// public propaty name  :  CMTCooprtDiv
        /// <summary>CMT連携区分プロパティ</summary>
        /// <value>0:連携なし 1:連携あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   CMT連携区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 CMTCooprtDiv
        {
            get { return _cMTCooprtDiv; }
            set { _cMTCooprtDiv = value; }
        }
        // 2010/05/26 Add <<<

		/// <summary>
		/// SCM受注データワークコンストラクタ
		/// </summary>
		/// <returns>SCMAcOdrDataWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDataWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMAcOdrDataWork()
		{
		}

	}
*/

    # endregion

	/// public class name:   SCMAcOdrDataWork
	/// <summary>
	///                      SCM受注データワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM受注データワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/04/30</br>
	/// <br>Genarated Date   :   2011/05/20  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/05/18  杉村</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   受注ステータス</br>
	/// <br>                 :   売上伝票番号</br>
	/// <br>                 :   売上伝票合計（税込み）</br>
	/// <br>                 :   売上小計（税）</br>
	/// <br>Update Note      :   2009/05/26  杉村</br>
	/// <br>                 :   ○項目削除</br>
	/// <br>                 :   発注日</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   問合せ・発注種別</br>
	/// <br>                 :   問発・回答種別</br>
	/// <br>                 :   受信日時</br>
	/// <br>Update Note      :   2009/05/29  杉村</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   回答作成区分</br>
	/// <br>Update Note      :   2009/06/15  杉村</br>
	/// <br>                 :   ○キー変更</br>
	/// <br>                 :   3,9,11,13,14,15,17,18→3,9,11,13,14,15,17,18,29,30</br>
	/// <br>Update Note      :   2009/06/16  杉村</br>
	/// <br>                 :   ○項目削除</br>
	/// <br>                 :   問合せ元企業名称</br>
	/// <br>                 :   問合せ元拠点名称</br>
	/// <br>                 :   ○桁数変更</br>
	/// <br>                 :   問合せ元拠点コード　16→6</br>
	/// <br>                 :   ○キー変更</br>
	/// <br>                 :   3,9,11,13,14,15,17,18,29,30→3,9,10,11,12,13,15,16,27,28</br>
	/// <br>Update Note      :   2010/05/25  長内</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   キャンセル区分</br>
	/// <br>                 :   CMT連携区分</br>
	/// <br>Update Note      :   2011/2/17  長内</br>
	/// <br>                 :   ○CMT連携区分補足 修正</br>
	/// <br>                 :   11:問合せ自動回答 12:発注自動回答を追加</br>
	/// <br>Update Note      :   2011/5/19  長内</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   SF-PM連携指示書番号</br>
    /// <br>Update Note      :   2011/08/10 高峰</br>
    /// <br>			     :   PCCUOE自動回答対応</br>
    /// <br>Update Note      :   2012/04/12 30745 吉岡 孝憲</br>
    /// <br>			     :   障害No170 PS管理番号項目追加</br>
    /// <br>Update Note      :   2013/05/24  30747 三戸 伸悟</br>
    /// <br>                 :   2013/06/18配信分 SCM障害№10536対応</br>
    /// <br>                 :   タブレット使用区分追加</br>
    /// <br>Update Note      :   2012/05/24 30744 湯上 千加子</br>
    /// <br>			     :   SCM障害No10537対応 車両管理コード追加</br>
    /// <br>Update Note      :   2014/12/19 30744 湯上 千加子</br>
    /// <br>                 :   管理番号 11070266-00</br>
    /// <br>			     :   SCM高速化 PMNS対応 自動回答方式の追加</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SCMAcOdrDataWork : IFileHeader
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>更新従業員コード</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private string _updEmployeeCode = "";

		/// <summary>更新アセンブリID1</summary>
		/// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>更新アセンブリID2</summary>
		/// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>問合せ元企業コード</summary>
		private string _inqOriginalEpCd = "";

		/// <summary>問合せ元拠点コード</summary>
		private string _inqOriginalSecCd = "";

		/// <summary>問合せ先企業コード</summary>
		private string _inqOtherEpCd = "";

		/// <summary>問合せ先拠点コード</summary>
		private string _inqOtherSecCd = "";

		/// <summary>問合せ番号</summary>
		private Int64 _inquiryNumber;

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>更新年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>更新時間</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;

		/// <summary>回答区分</summary>
		/// <remarks>0:アクションなし 10:一部回答 20:回答完了 30:承認 99:キャンセル</remarks>
		private Int32 _answerDivCd;

		/// <summary>確定日</summary>
		/// <remarks>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</remarks>
		private DateTime _judgementDate;

		/// <summary>問合せ・発注備考</summary>
		private string _inqOrdNote = "";

		/// <summary>添付ファイル</summary>
        private Byte[] _appendingFile = new Byte[0];

		/// <summary>添付ファイル名</summary>
		private string _appendingFileNm = "";

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

		/// <summary>問合せ日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _inquiryDate;

		/// <summary>受注ステータス</summary>
		/// <remarks>10:見積,20:受注,30:売上</remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>売上伝票番号</summary>
		/// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
		private string _salesSlipNum = "";

		/// <summary>売上伝票合計（税込み）</summary>
		/// <remarks>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</remarks>
		private Int64 _salesTotalTaxInc;

		/// <summary>売上小計（税）</summary>
		/// <remarks>値引後の税額（外税分、内税分の合計）</remarks>
		private Int64 _salesSubtotalTax;

		/// <summary>問合せ・発注種別</summary>
		/// <remarks>1:問合せ 2:発注</remarks>
		private Int32 _inqOrdDivCd;

		/// <summary>問発・回答種別</summary>
		/// <remarks>1:問合せ・発注 2:回答</remarks>
		private Int32 _inqOrdAnsDivCd;

		/// <summary>受信日時</summary>
		/// <remarks>（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _receiveDateTime;

		/// <summary>回答作成区分</summary>
		/// <remarks>0:自動, 1:手動（Web）, 2:手動（その他）</remarks>
		private Int32 _answerCreateDiv;

		/// <summary>キャンセル区分</summary>
		/// <remarks>0:キャンセルなし 1:キャンセルあり</remarks>
		private Int16 _cancelDiv;

		/// <summary>CMT連携区分</summary>
		/// <remarks>0:連携なし 1:連携あり 11:問合せ自動回答 12:発注自動回答</remarks>
		private Int16 _cMTCooprtDiv;

		/// <summary>SF-PM連携指示書番号</summary>
		/// <remarks>得意先注番</remarks>
		private string _sfPmCprtInstSlipNo = "";

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>PM現在庫数</summary>
        /// <remarks>PM現在庫数</remarks>
        private double _pmPrsntCount;

        /// <summary>セット部品メーカーコード</summary>
        /// <remarks>セット部品メーカーコード</remarks>
        private Int32 _setPartsMkrCd;

        /// <summary>セット部品番号</summary>
        /// <remarks>セット部品番号</remarks>
        private String _setPartsNumber;

        /// <summary>セット部品親子番号</summary>
        /// <remarks>セット部品親子番号</remarks>
        private Int32 _setPartsMainSubNo;
        // -- ADD 2011/08/10   ------ <<<<<<

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>受発注種別</summary>
        /// <remarks>0:通常,1:PCC-UOE</remarks>
        private Int16 _acceptOrOrderKind;
        // -- ADD 2011/08/10   ------ <<<<<<
        // 2012/04/12 Add >>> 
        /// <summary>PS管理番号</summary>
        private Int32 _psMngNo;
        // 2012/04/12 Add <<<

        // --- ADD 2013/05/24 三戸 2013/06/18配信分 SCM障害№10536 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>タブレット使用区分</summary>
        /// <remarks>0：使用しない,1：使用する</remarks>
        private Int32 _tabUseDiv;
        // --- ADD 2013/05/24 三戸 2013/06/18配信分 SCM障害№10536 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2013/05/24 SCM障害№10537対応 ---------------------------------->>>>>
        /// <summary>車両管理コード</summary>
        private string _carMngCode = "";
        // ADD 2013/05/24 SCM障害№10537対応 ----------------------------------<<<<<

        // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
        /// <summary>自動回答方式</summary>
        private Int16 _autoAnsMthd;
        // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<

		/// public propaty name  :  CreateDateTime
		/// <summary>作成日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>更新日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
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

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUIDプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>更新従業員コードプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>更新アセンブリID1プロパティ</summary>
		/// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>更新アセンブリID2プロパティ</summary>
		/// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>論理削除区分プロパティ</summary>
		/// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
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

		/// public propaty name  :  InquiryNumber
		/// <summary>問合せ番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 InquiryNumber
		{
			get{return _inquiryNumber;}
			set{_inquiryNumber = value;}
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

		/// public propaty name  :  UpdateTime
		/// <summary>更新時間プロパティ</summary>
		/// <value>HHMMSSXXX</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新時間プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UpdateTime
		{
			get{return _updateTime;}
			set{_updateTime = value;}
		}

		/// public propaty name  :  AnswerDivCd
		/// <summary>回答区分プロパティ</summary>
		/// <value>0:アクションなし 10:一部回答 20:回答完了 30:承認 99:キャンセル</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AnswerDivCd
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
		public DateTime JudgementDate
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

		/// public propaty name  :  AppendingFile
		/// <summary>添付ファイルプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   添付ファイルプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Byte[] AppendingFile
		{
			get{return _appendingFile;}
			set{_appendingFile = value;}
		}

		/// public propaty name  :  AppendingFileNm
		/// <summary>添付ファイル名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   添付ファイル名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AppendingFileNm
		{
			get{return _appendingFileNm;}
			set{_appendingFileNm = value;}
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

		/// public propaty name  :  InquiryDate
		/// <summary>問合せ日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime InquiryDate
		{
			get{return _inquiryDate;}
			set{_inquiryDate = value;}
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>受注ステータスプロパティ</summary>
		/// <value>10:見積,20:受注,30:売上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注ステータスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  SalesSlipNum
		/// <summary>売上伝票番号プロパティ</summary>
		/// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesSlipNum
		{
			get{return _salesSlipNum;}
			set{_salesSlipNum = value;}
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

		/// public propaty name  :  SalesSubtotalTax
		/// <summary>売上小計（税）プロパティ</summary>
		/// <value>値引後の税額（外税分、内税分の合計）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上小計（税）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesSubtotalTax
		{
			get{return _salesSubtotalTax;}
			set{_salesSubtotalTax = value;}
		}

		/// public propaty name  :  InqOrdDivCd
		/// <summary>問合せ・発注種別プロパティ</summary>
		/// <value>1:問合せ 2:発注</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ・発注種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InqOrdDivCd
		{
			get{return _inqOrdDivCd;}
			set{_inqOrdDivCd = value;}
		}

		/// public propaty name  :  InqOrdAnsDivCd
		/// <summary>問発・回答種別プロパティ</summary>
		/// <value>1:問合せ・発注 2:回答</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問発・回答種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InqOrdAnsDivCd
		{
			get{return _inqOrdAnsDivCd;}
			set{_inqOrdAnsDivCd = value;}
		}

		/// public propaty name  :  ReceiveDateTime
		/// <summary>受信日時プロパティ</summary>
		/// <value>（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受信日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime ReceiveDateTime
		{
			get{return _receiveDateTime;}
			set{_receiveDateTime = value;}
		}

		/// public propaty name  :  AnswerCreateDiv
		/// <summary>回答作成区分プロパティ</summary>
		/// <value>0:自動, 1:手動（Web）, 2:手動（その他）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答作成区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AnswerCreateDiv
		{
			get{return _answerCreateDiv;}
			set{_answerCreateDiv = value;}
		}

		/// public propaty name  :  CancelDiv
		/// <summary>キャンセル区分プロパティ</summary>
		/// <value>0:キャンセルなし 1:キャンセルあり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   キャンセル区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int16 CancelDiv
		{
			get{return _cancelDiv;}
			set{_cancelDiv = value;}
		}

		/// public propaty name  :  CMTCooprtDiv
		/// <summary>CMT連携区分プロパティ</summary>
		/// <value>0:連携なし 1:連携あり 11:問合せ自動回答 12:発注自動回答</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   CMT連携区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int16 CMTCooprtDiv
		{
			get{return _cMTCooprtDiv;}
			set{_cMTCooprtDiv = value;}
		}

		/// public propaty name  :  SfPmCprtInstSlipNo
		/// <summary>SF-PM連携指示書番号プロパティ</summary>
		/// <value>得意先注番</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   SF-PM連携指示書番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SfPmCprtInstSlipNo
		{
			get{return _sfPmCprtInstSlipNo;}
			set{_sfPmCprtInstSlipNo = value;}
		}

        // -- ADD 2011/08/10   ------ >>>>>>
        /// public propaty name  :  PmPrsntCount
        /// <summary>PM現在庫数プロパティ</summary>
        /// <value>PM現在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM現在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double PmPrsntCount
        {
            get { return _pmPrsntCount; }
            set { _pmPrsntCount = value; }
        }

        /// public propaty name  :  SetPartsMkrCd
        /// <summary>セット部品メーカーコードプロパティ</summary>
        /// <value>セット部品メーカーコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット部品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SetPartsMkrCd
        {
            get { return _setPartsMkrCd; }
            set { _setPartsMkrCd = value; }
        }

        /// public propaty name  :  SetPartsNumber
        /// <summary>セット部品番号プロパティ</summary>
        /// <value>セット部品番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット部品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String SetPartsNumber
        {
            get { return _setPartsNumber; }
            set { _setPartsNumber = value; }
        }

        /// public propaty name  :  AcceptOrOrderKind
        /// <summary>セット部品親子番号プロパティ</summary>
        /// <value>セット部品親子番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット部品親子番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SetPartsMainSubNo
        {
            get { return _setPartsMainSubNo; }
            set { _setPartsMainSubNo = value; }
        }
        // -- ADD 2011/08/10   ------ <<<<<<

        // -- ADD 2011/08/10   ------ >>>>>>
        /// public propaty name  :  AcceptOrOrderKind
        /// <summary>受発注種別プロパティ</summary>
        /// <value>0:通常,1:PCC-UOE</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受発注種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AcceptOrOrderKind
        {
            get { return _acceptOrOrderKind; }
            set { _acceptOrOrderKind = value; }
        }
        // -- ADD 2011/08/10   ------ <<<<<<

        // 2012/04/12 Add >>> 
        /// public propaty name  :  PSMngNo
        /// <summary>PS管理番号</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PS管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PSMngNo
        {
            get { return _psMngNo; }
            set { _psMngNo = value; }
        }
        // 2012/04/12 Add <<<

        // --- ADD 2013/05/24 三戸 2013/06/18配信分 SCM障害№10536 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  TabUseDiv
        /// <summary>タブレット使用区分</summary>
        /// <value>0：使用しない,1：使用する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   タブレット使用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TabUseDiv
        {
            get { return _tabUseDiv; }
            set { _tabUseDiv = value; }
        }
        // --- ADD 2013/05/24 三戸 2013/06/18配信分 SCM障害№10536 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2013/05/24 SCM障害№10537対応 ---------------------------------->>>>>
        /// public propaty name  :  CarMngCode
        /// <summary>車両管理コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }
        // ADD 2013/05/24 SCM障害№10537対応 ----------------------------------<<<<<

        // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
        /// public propaty name  :  AutoAnsMthd
        /// <summary>自動回答方式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動回答方式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AutoAnsMthd
        {
            get { return _autoAnsMthd; }
            set { _autoAnsMthd = value; }
        }
        // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<


		/// <summary>
		/// SCM受注データワークコンストラクタ
		/// </summary>
		/// <returns>SCMAcOdrDataWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDataWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMAcOdrDataWork()
		{
		}

	}

# region delete
/*
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SCMAcOdrDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SCMAcOdrDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SCMAcOdrDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAcOdrDataWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMAcOdrDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMAcOdrDataWork || graph is ArrayList || graph is SCMAcOdrDataWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SCMAcOdrDataWork).FullName));

            if (graph != null && graph is SCMAcOdrDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMAcOdrDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMAcOdrDataWork[])graph).Length;
            }
            else if (graph is SCMAcOdrDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //問合せ元企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //問合せ元拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //問合せ先企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //問合せ先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //問合せ番号
            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //更新時間
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateTime
            //回答区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDivCd
            //確定日
            serInfo.MemberInfo.Add(typeof(Int32)); //JudgementDate
            //問合せ・発注備考
            serInfo.MemberInfo.Add(typeof(string)); //InqOrdNote
            //添付ファイル
            serInfo.MemberInfo.Add(typeof(Byte[])); //AppendingFile
            //添付ファイル名
            serInfo.MemberInfo.Add(typeof(string)); //AppendingFileNm
            //問合せ従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeCd
            //問合せ従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeNm
            //回答従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //AnsEmployeeCd
            //回答従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //AnsEmployeeNm
            //問合せ日
            serInfo.MemberInfo.Add(typeof(Int32)); //InquiryDate
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //売上伝票合計（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxInc
            //売上小計（税）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSubtotalTax
            //問合せ・発注種別
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdDivCd
            //問発・回答種別
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdAnsDivCd
            //受信日時
            serInfo.MemberInfo.Add(typeof(Int64)); //ReceiveDateTime
            //回答作成区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerCreateDiv
            // 2010/05/26 Add >>>
            //キャンセル区分
            serInfo.MemberInfo.Add(typeof(Int16)); //CancelDiv
            //CMT連携区分
            serInfo.MemberInfo.Add(typeof(Int16)); //CMTCooprtDiv
            // 2010/05/26 Add <<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SCMAcOdrDataWork)
            {
                SCMAcOdrDataWork temp = (SCMAcOdrDataWork)graph;

                SetSCMAcOdrDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMAcOdrDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMAcOdrDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMAcOdrDataWork temp in lst)
                {
                    SetSCMAcOdrDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMAcOdrDataWorkメンバ数(publicプロパティ数)
        /// </summary>
        // 2010/05/26 >>>
        //private const int currentMemberCount = 34;
        private const int currentMemberCount = 36;
        // 2010/05/16 <<<

        /// <summary>
        ///  SCMAcOdrDataWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAcOdrDataWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSCMAcOdrDataWork(System.IO.BinaryWriter writer, SCMAcOdrDataWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //問合せ元企業コード
            writer.Write(temp.InqOriginalEpCd);
            //問合せ元拠点コード
            writer.Write(temp.InqOriginalSecCd);
            //問合せ先企業コード
            writer.Write(temp.InqOtherEpCd);
            //問合せ先拠点コード
            writer.Write(temp.InqOtherSecCd);
            //問合せ番号
            writer.Write(temp.InquiryNumber);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //更新年月日
            writer.Write((Int64)temp.UpdateDate.Ticks);
            //更新時間
            writer.Write(temp.UpdateTime);
            //回答区分
            writer.Write(temp.AnswerDivCd);
            //確定日
            writer.Write((Int64)temp.JudgementDate.Ticks);
            //問合せ・発注備考
            writer.Write(temp.InqOrdNote);
            //添付ファイル
            writer.Write(temp.AppendingFile.Length);
            writer.Write(temp.AppendingFile);
            //添付ファイル名
            writer.Write(temp.AppendingFileNm);
            //問合せ従業員コード
            writer.Write(temp.InqEmployeeCd);
            //問合せ従業員名称
            writer.Write(temp.InqEmployeeNm);
            //回答従業員コード
            writer.Write(temp.AnsEmployeeCd);
            //回答従業員名称
            writer.Write(temp.AnsEmployeeNm);
            //問合せ日
            writer.Write((Int64)temp.InquiryDate.Ticks);
            //受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //売上伝票合計（税込み）
            writer.Write(temp.SalesTotalTaxInc);
            //売上小計（税）
            writer.Write(temp.SalesSubtotalTax);
            //問合せ・発注種別
            writer.Write(temp.InqOrdDivCd);
            //問発・回答種別
            writer.Write(temp.InqOrdAnsDivCd);
            //受信日時
            writer.Write((Int64)temp.ReceiveDateTime.Ticks);
            //回答作成区分
            writer.Write(temp.AnswerCreateDiv);
            // 2010/05/26 Add >>>
            //キャンセル区分
            writer.Write(temp.CancelDiv);
            //CMT連携区分
            writer.Write(temp.CMTCooprtDiv);
            // 2010/05/26 Add <<<
        }

        /// <summary>
        ///  SCMAcOdrDataWorkインスタンス取得
        /// </summary>
        /// <returns>SCMAcOdrDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAcOdrDataWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SCMAcOdrDataWork GetSCMAcOdrDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SCMAcOdrDataWork temp = new SCMAcOdrDataWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //問合せ元企業コード
            temp.InqOriginalEpCd = reader.ReadString();
            //問合せ元拠点コード
            temp.InqOriginalSecCd = reader.ReadString();
            //問合せ先企業コード
            temp.InqOtherEpCd = reader.ReadString();
            //問合せ先拠点コード
            temp.InqOtherSecCd = reader.ReadString();
            //問合せ番号
            temp.InquiryNumber = reader.ReadInt64();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //更新年月日
            temp.UpdateDate = new DateTime(reader.ReadInt64());
            //更新時間
            temp.UpdateTime = reader.ReadInt32();
            //回答区分
            temp.AnswerDivCd = reader.ReadInt32();
            //確定日
            temp.JudgementDate = new DateTime(reader.ReadInt64());
            //問合せ・発注備考
            temp.InqOrdNote = reader.ReadString();
            //添付ファイル
            int appendingFileLength = reader.ReadInt32();
            temp.AppendingFile = reader.ReadBytes(appendingFileLength);
            //添付ファイル名
            temp.AppendingFileNm = reader.ReadString();
            //問合せ従業員コード
            temp.InqEmployeeCd = reader.ReadString();
            //問合せ従業員名称
            temp.InqEmployeeNm = reader.ReadString();
            //回答従業員コード
            temp.AnsEmployeeCd = reader.ReadString();
            //回答従業員名称
            temp.AnsEmployeeNm = reader.ReadString();
            //問合せ日
            temp.InquiryDate = new DateTime(reader.ReadInt64());
            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //売上伝票合計（税込み）
            temp.SalesTotalTaxInc = reader.ReadInt64();
            //売上小計（税）
            temp.SalesSubtotalTax = reader.ReadInt64();
            //問合せ・発注種別
            temp.InqOrdDivCd = reader.ReadInt32();
            //問発・回答種別
            temp.InqOrdAnsDivCd = reader.ReadInt32();
            //受信日時
            temp.ReceiveDateTime = new DateTime(reader.ReadInt64());
            //回答作成区分
            temp.AnswerCreateDiv = reader.ReadInt32();
            // 2010/05/26 Add >>>
            //キャンセル区分
            temp.CancelDiv = reader.ReadInt16();
            //CMT連携区分
            temp.CMTCooprtDiv = reader.ReadInt16();
            // 2010/05/26 Add <<<


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
        /// <returns>SCMAcOdrDataWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAcOdrDataWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMAcOdrDataWork temp = GetSCMAcOdrDataWork(reader, serInfo);
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
                    retValue = (SCMAcOdrDataWork[])lst.ToArray(typeof(SCMAcOdrDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
*/
# endregion

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SCMAcOdrDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SCMAcOdrDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SCMAcOdrDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
	    #region ICustomSerializationSurrogate メンバ
    	
	    /// <summary>
	    ///  Ver5.10.1.0用のカスタムシリアライザです
	    /// </summary>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   SCMAcOdrDataWorkクラスのカスタムシリアライザを定義します</br>
	    /// <br>Programer        :   自動生成</br>
	    /// </remarks>
	    public void Serialize(System.IO.BinaryWriter writer, object graph)
	    {
		    // TODO:  SCMAcOdrDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
		    if(  writer == null )
			    throw new ArgumentNullException();

		    if( graph != null && !( graph is SCMAcOdrDataWork || graph is ArrayList || graph is SCMAcOdrDataWork[]) )
			    throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof(SCMAcOdrDataWork).FullName ) );

		    if( graph != null && graph is SCMAcOdrDataWork )
		    {
			    Type t = graph.GetType();
			    if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
		    }

		    //SerializationTypeInfo
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork" );

		    //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
		    int occurrence = 0;     //一般にゼロの場合もありえます
		    if( graph is ArrayList )
		    {
			    serInfo.RetTypeInfo = 0;
			    occurrence = ((ArrayList)graph).Count;
		    }else if( graph is SCMAcOdrDataWork[] )
		    {
			    serInfo.RetTypeInfo = 2;
			    occurrence = ((SCMAcOdrDataWork[])graph).Length;
		    }
		    else if( graph is SCMAcOdrDataWork )
		    {
			    serInfo.RetTypeInfo = 1;
			    occurrence = 1;
		    }

		    serInfo.Occurrence = occurrence;		 //繰り返し数	

		    //作成日時
		    serInfo.MemberInfo.Add( typeof(Int64) ); //CreateDateTime
		    //更新日時
		    serInfo.MemberInfo.Add( typeof(Int64) ); //UpdateDateTime
		    //企業コード
		    serInfo.MemberInfo.Add( typeof(string) ); //EnterpriseCode
		    //GUID
		    serInfo.MemberInfo.Add( typeof(byte[]) );  //FileHeaderGuid
		    //更新従業員コード
		    serInfo.MemberInfo.Add( typeof(string) ); //UpdEmployeeCode
		    //更新アセンブリID1
		    serInfo.MemberInfo.Add( typeof(string) ); //UpdAssemblyId1
		    //更新アセンブリID2
		    serInfo.MemberInfo.Add( typeof(string) ); //UpdAssemblyId2
		    //論理削除区分
		    serInfo.MemberInfo.Add( typeof(Int32) ); //LogicalDeleteCode
		    //問合せ元企業コード
		    serInfo.MemberInfo.Add( typeof(string) ); //InqOriginalEpCd
		    //問合せ元拠点コード
		    serInfo.MemberInfo.Add( typeof(string) ); //InqOriginalSecCd
		    //問合せ先企業コード
		    serInfo.MemberInfo.Add( typeof(string) ); //InqOtherEpCd
		    //問合せ先拠点コード
		    serInfo.MemberInfo.Add( typeof(string) ); //InqOtherSecCd
		    //問合せ番号
		    serInfo.MemberInfo.Add( typeof(Int64) ); //InquiryNumber
		    //得意先コード
		    serInfo.MemberInfo.Add( typeof(Int32) ); //CustomerCode
		    //更新年月日
		    serInfo.MemberInfo.Add( typeof(Int32) ); //UpdateDate
		    //更新時間
		    serInfo.MemberInfo.Add( typeof(Int32) ); //UpdateTime
		    //回答区分
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AnswerDivCd
		    //確定日
		    serInfo.MemberInfo.Add( typeof(Int32) ); //JudgementDate
		    //問合せ・発注備考
		    serInfo.MemberInfo.Add( typeof(string) ); //InqOrdNote
		    //添付ファイル
            serInfo.MemberInfo.Add(typeof(Byte[])); //AppendingFile
		    //添付ファイル名
		    serInfo.MemberInfo.Add( typeof(string) ); //AppendingFileNm
		    //問合せ従業員コード
		    serInfo.MemberInfo.Add( typeof(string) ); //InqEmployeeCd
		    //問合せ従業員名称
		    serInfo.MemberInfo.Add( typeof(string) ); //InqEmployeeNm
		    //回答従業員コード
		    serInfo.MemberInfo.Add( typeof(string) ); //AnsEmployeeCd
		    //回答従業員名称
		    serInfo.MemberInfo.Add( typeof(string) ); //AnsEmployeeNm
		    //問合せ日
		    serInfo.MemberInfo.Add( typeof(Int32) ); //InquiryDate
		    //受注ステータス
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AcptAnOdrStatus
		    //売上伝票番号
		    serInfo.MemberInfo.Add( typeof(string) ); //SalesSlipNum
		    //売上伝票合計（税込み）
		    serInfo.MemberInfo.Add( typeof(Int64) ); //SalesTotalTaxInc
		    //売上小計（税）
		    serInfo.MemberInfo.Add( typeof(Int64) ); //SalesSubtotalTax
		    //問合せ・発注種別
		    serInfo.MemberInfo.Add( typeof(Int32) ); //InqOrdDivCd
		    //問発・回答種別
		    serInfo.MemberInfo.Add( typeof(Int32) ); //InqOrdAnsDivCd
		    //受信日時
		    serInfo.MemberInfo.Add( typeof(Int32) ); //ReceiveDateTime
		    //回答作成区分
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AnswerCreateDiv
		    //キャンセル区分
		    serInfo.MemberInfo.Add( typeof(Int16) ); //CancelDiv
		    //CMT連携区分
		    serInfo.MemberInfo.Add( typeof(Int16) ); //CMTCooprtDiv
		    //SF-PM連携指示書番号
		    serInfo.MemberInfo.Add( typeof(string) ); //SfPmCprtInstSlipNo
            // -- ADD 2011/08/10   ------ >>>>>>
            //受発注種別
            serInfo.MemberInfo.Add(typeof(Int16)); //AcceptOrOrderKind
            // -- ADD 2011/08/10   ------ <<<<<<
            // --- ADD 2013/05/24 三戸 2013/06/18配信分 SCM障害№10536 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //タブレット使用区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TabUseDiv
            // --- ADD 2013/05/24 三戸 2013/06/18配信分 SCM障害№10536 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/24 SCM障害№10537対応 ---------------------------------->>>>>
            //車両管理コード
            serInfo.MemberInfo.Add(typeof(string)); //CarMngCode
            // ADD 2013/05/24 SCM障害№10537対応 ----------------------------------<<<<<

            // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            // 自動回答方式
            serInfo.MemberInfo.Add(typeof(Int16));  // AutoAnsMthd
            // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
	
		    serInfo.Serialize( writer, serInfo );
		    if( graph is SCMAcOdrDataWork )
		    {
			    SCMAcOdrDataWork temp = (SCMAcOdrDataWork)graph;

			    SetSCMAcOdrDataWork(writer, temp);
		    }
		    else
		    {
			    ArrayList lst= null;
			    if(graph is SCMAcOdrDataWork[])
			    {
				    lst = new ArrayList();
				    lst.AddRange((SCMAcOdrDataWork[])graph);
			    }
			    else
			    {
				    lst = (ArrayList)graph;	
			    }

			    foreach(SCMAcOdrDataWork temp in lst)
			    {
				    SetSCMAcOdrDataWork(writer, temp);
			    }

		    }

    		
	    }


	    /// <summary>
	    /// SCMAcOdrDataWorkメンバ数(publicプロパティ数)
	    /// </summary>
        //private const int currentMemberCount = 37; // DEL 2011/08/10
        // --- UPD 2013/05/24 三戸 2013/06/18配信分 SCM障害№10536 --------->>>>>>>>>>>>>>>>>>>>>>>>
        //private const int currentMemberCount = 38; // ADD 2011/08/10
        // UPD 2013/05/24 SCM障害№10537対応 ---------------------------------->>>>>
        //private const int currentMemberCount = 39;
        // UPD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
        //private const int currentMemberCount = 40;
        private const int currentMemberCount = 41;
        // UPD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
        // UPD 2013/05/24 SCM障害№10537対応 ----------------------------------<<<<<
        // --- UPD 2013/05/24 三戸 2013/06/18配信分 SCM障害№10536 ---------<<<<<<<<<<<<<<<<<<<<<<<<
    		
	    /// <summary>
	    ///  SCMAcOdrDataWorkインスタンス書き込み
	    /// </summary>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   SCMAcOdrDataWorkのインスタンスを書き込み</br>
	    /// <br>Programer        :   自動生成</br>
	    /// </remarks>
	    private void SetSCMAcOdrDataWork( System.IO.BinaryWriter writer, SCMAcOdrDataWork temp )
	    {
		    //作成日時
		    writer.Write( (Int64)temp.CreateDateTime.Ticks );
		    //更新日時
		    writer.Write( (Int64)temp.UpdateDateTime.Ticks );
		    //企業コード
		    writer.Write( temp.EnterpriseCode );
		    //GUID
		    byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
		    writer.Write( fileHeaderGuidArray.Length );
		    writer.Write( temp.FileHeaderGuid.ToByteArray() );
		    //更新従業員コード
		    writer.Write( temp.UpdEmployeeCode );
		    //更新アセンブリID1
		    writer.Write( temp.UpdAssemblyId1 );
		    //更新アセンブリID2
		    writer.Write( temp.UpdAssemblyId2 );
		    //論理削除区分
		    writer.Write( temp.LogicalDeleteCode );
		    //問合せ元企業コード
            writer.Write(temp.InqOriginalEpCd.Trim());	//@@@@20230303
		    //問合せ元拠点コード
		    writer.Write( temp.InqOriginalSecCd );
		    //問合せ先企業コード
		    writer.Write( temp.InqOtherEpCd );
		    //問合せ先拠点コード
		    writer.Write( temp.InqOtherSecCd );
		    //問合せ番号
		    writer.Write( temp.InquiryNumber );
		    //得意先コード
		    writer.Write( temp.CustomerCode );
		    //更新年月日
		    writer.Write( (Int64)temp.UpdateDate.Ticks );
		    //更新時間
		    writer.Write( temp.UpdateTime );
		    //回答区分
		    writer.Write( temp.AnswerDivCd );
		    //確定日
		    writer.Write( (Int64)temp.JudgementDate.Ticks );
		    //問合せ・発注備考
		    writer.Write( temp.InqOrdNote );
		    //添付ファイル
            writer.Write( temp.AppendingFile.Length );
            writer.Write( temp.AppendingFile );
		    //添付ファイル名
		    writer.Write( temp.AppendingFileNm );
		    //問合せ従業員コード
		    writer.Write( temp.InqEmployeeCd );
		    //問合せ従業員名称
		    writer.Write( temp.InqEmployeeNm );
		    //回答従業員コード
		    writer.Write( temp.AnsEmployeeCd );
		    //回答従業員名称
		    writer.Write( temp.AnsEmployeeNm );
		    //問合せ日
		    writer.Write( (Int64)temp.InquiryDate.Ticks );
		    //受注ステータス
		    writer.Write( temp.AcptAnOdrStatus );
		    //売上伝票番号
		    writer.Write( temp.SalesSlipNum );
		    //売上伝票合計（税込み）
		    writer.Write( temp.SalesTotalTaxInc );
		    //売上小計（税）
		    writer.Write( temp.SalesSubtotalTax );
		    //問合せ・発注種別
		    writer.Write( temp.InqOrdDivCd );
		    //問発・回答種別
		    writer.Write( temp.InqOrdAnsDivCd );
		    //受信日時
		    writer.Write( (Int64)temp.ReceiveDateTime.Ticks );
		    //回答作成区分
		    writer.Write( temp.AnswerCreateDiv );
		    //キャンセル区分
		    writer.Write( temp.CancelDiv );
		    //CMT連携区分
		    writer.Write( temp.CMTCooprtDiv );
		    //SF-PM連携指示書番号
		    writer.Write( temp.SfPmCprtInstSlipNo );
            // -- ADD 2011/08/10   ------ >>>>>>
            //受発注種別
            writer.Write(temp.AcceptOrOrderKind);
            // -- ADD 2011/08/10   ------ <<<<<<
            // --- ADD 2013/05/24 三戸 2013/06/18配信分 SCM障害№10536 --------->>>>>>>>>>>>>>>>>>>>>>>>
            writer.Write(temp.TabUseDiv);
            // --- ADD 2013/05/24 三戸 2013/06/18配信分 SCM障害№10536 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/24 SCM障害№10537対応 ---------------------------------->>>>>
            //車両管理コード
            writer.Write(temp.CarMngCode);
            // ADD 2013/05/24 SCM障害№10537対応 ----------------------------------<<<<<
            // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            // 自動回答方式
            writer.Write(temp.AutoAnsMthd);
            // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
        }

	    /// <summary>
	    ///  SCMAcOdrDataWorkインスタンス取得
	    /// </summary>
	    /// <returns>SCMAcOdrDataWorkクラスのインスタンス</returns>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   SCMAcOdrDataWorkのインスタンスを取得します</br>
	    /// <br>Programer        :   自動生成</br>
	    /// </remarks>
	    private SCMAcOdrDataWork GetSCMAcOdrDataWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	    {
		    // V5.1.0.0なので不要ですが、V5.1.0.1以降では
		    // serInfo.MemberInfo.Count < currentMemberCount
		    // のケースについての配慮が必要になります。

		    SCMAcOdrDataWork temp = new SCMAcOdrDataWork();

		    //作成日時
		    temp.CreateDateTime = new DateTime(reader.ReadInt64());
		    //更新日時
		    temp.UpdateDateTime = new DateTime(reader.ReadInt64());
		    //企業コード
		    temp.EnterpriseCode = reader.ReadString();
		    //GUID
		    int lenOfFileHeaderGuidArray = reader.ReadInt32();
		    byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
		    temp.FileHeaderGuid = new Guid( fileHeaderGuidArray );
		    //更新従業員コード
		    temp.UpdEmployeeCode = reader.ReadString();
		    //更新アセンブリID1
		    temp.UpdAssemblyId1 = reader.ReadString();
		    //更新アセンブリID2
		    temp.UpdAssemblyId2 = reader.ReadString();
		    //論理削除区分
		    temp.LogicalDeleteCode = reader.ReadInt32();
		    //問合せ元企業コード
            temp.InqOriginalEpCd = reader.ReadString().Trim();//@@@@20230303
		    //問合せ元拠点コード
		    temp.InqOriginalSecCd = reader.ReadString();
		    //問合せ先企業コード
		    temp.InqOtherEpCd = reader.ReadString();
		    //問合せ先拠点コード
		    temp.InqOtherSecCd = reader.ReadString();
		    //問合せ番号
		    temp.InquiryNumber = reader.ReadInt64();
		    //得意先コード
		    temp.CustomerCode = reader.ReadInt32();
		    //更新年月日
		    temp.UpdateDate = new DateTime(reader.ReadInt64());
		    //更新時間
		    temp.UpdateTime = reader.ReadInt32();
		    //回答区分
		    temp.AnswerDivCd = reader.ReadInt32();
		    //確定日
		    temp.JudgementDate = new DateTime(reader.ReadInt64());
		    //問合せ・発注備考
		    temp.InqOrdNote = reader.ReadString();
		    //添付ファイル
            int appendingFileLength = reader.ReadInt32();
            temp.AppendingFile = reader.ReadBytes(appendingFileLength);
            //添付ファイル名
            temp.AppendingFileNm = reader.ReadString();
            //問合せ従業員コード
		    temp.InqEmployeeCd = reader.ReadString();
		    //問合せ従業員名称
		    temp.InqEmployeeNm = reader.ReadString();
		    //回答従業員コード
		    temp.AnsEmployeeCd = reader.ReadString();
		    //回答従業員名称
		    temp.AnsEmployeeNm = reader.ReadString();
		    //問合せ日
		    temp.InquiryDate = new DateTime(reader.ReadInt64());
		    //受注ステータス
		    temp.AcptAnOdrStatus = reader.ReadInt32();
		    //売上伝票番号
		    temp.SalesSlipNum = reader.ReadString();
		    //売上伝票合計（税込み）
		    temp.SalesTotalTaxInc = reader.ReadInt64();
		    //売上小計（税）
		    temp.SalesSubtotalTax = reader.ReadInt64();
		    //問合せ・発注種別
		    temp.InqOrdDivCd = reader.ReadInt32();
		    //問発・回答種別
		    temp.InqOrdAnsDivCd = reader.ReadInt32();
		    //受信日時
		    temp.ReceiveDateTime = new DateTime(reader.ReadInt64());
		    //回答作成区分
		    temp.AnswerCreateDiv = reader.ReadInt32();
		    //キャンセル区分
		    temp.CancelDiv = reader.ReadInt16();
		    //CMT連携区分
		    temp.CMTCooprtDiv = reader.ReadInt16();
		    //SF-PM連携指示書番号
		    temp.SfPmCprtInstSlipNo = reader.ReadString();
            // -- ADD 2011/08/10   ------ >>>>>>
            //受発注種別
            temp.AcceptOrOrderKind = reader.ReadInt16();
            // -- ADD 2011/08/10   ------ <<<<<<
            // --- ADD 2013/05/24 三戸 2013/06/18配信分 SCM障害№10536 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //タブレット使用区分
            temp.TabUseDiv = reader.ReadInt32();
            // --- ADD 2013/05/24 三戸 2013/06/18配信分 SCM障害№10536 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/24 SCM障害№10537対応 ---------------------------------->>>>>
            //車両管理コード
            temp.CarMngCode = reader.ReadString();
            // ADD 2013/05/24 SCM障害№10537対応 ----------------------------------<<<<<

            // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            // 自動回答方式
            temp.AutoAnsMthd = reader.ReadInt16();
            // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
                			
		    //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
		    //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
		    //型情報にしたがって、ストリームから情報を読み出します...といっても
		    //読み出して捨てることになります。
		    for( int k = currentMemberCount ; k < serInfo.MemberInfo.Count ; ++k )
		    {
			    //byte[],char[]をデシリアライズする直前に、そのlengthが
			    //デシリアライズされているケースがある、byte[],char[]の
			    //デシリアライズにはlengthが必要なのでint型のデータをデ
			    //シリアライズした場合は、この値をこの変数に退避します。
			    int optCount = 0;   
			    object oMemberType = serInfo.MemberInfo[k];
			    if( oMemberType is Type )
			    {
				    Type t = (Type)oMemberType;
				    object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
				    if( t.Equals( typeof(int) ) )
				    {
					    optCount = Convert.ToInt32(oData);
				    }
				    else
				    {
					    optCount = 0;
				    }
			    }
			    else if( oMemberType is string )
			    {
				    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
				    object userData = formatter.Deserialize( reader );  //読み飛ばし
			    }
		    }
		    return temp;
	    }

	    /// <summary>
	    ///  Ver5.10.1.0用のカスタムデシリアライザです
	    /// </summary>
	    /// <returns>SCMAcOdrDataWorkクラスのインスタンス(object)</returns>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   SCMAcOdrDataWorkクラスのカスタムデシリアライザを定義します</br>
	    /// <br>Programer        :   自動生成</br>
	    /// </remarks>
	    public object Deserialize(System.IO.BinaryReader reader)
	    {
		    object retValue = null;
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
		    ArrayList lst = new ArrayList();
		    for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
		    {
			    SCMAcOdrDataWork temp = GetSCMAcOdrDataWork( reader, serInfo );
			    lst.Add( temp );
		    }
		    switch(serInfo.RetTypeInfo)
		    {
			    case 0:
				    retValue = lst;
				    break;
			    case 1:
				    retValue = lst[0];
				    break;
			    case 2:
				    retValue = (SCMAcOdrDataWork[])lst.ToArray(typeof(SCMAcOdrDataWork));
				    break;
		    }
		    return retValue;
	    }

	    #endregion
    }

}
