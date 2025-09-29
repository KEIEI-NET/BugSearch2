using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SCMAcOdrData
	/// <summary>
	///                      SCM受注データ
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM受注データヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/04/30</br>
	/// <br>Genarated Date   :   2009/08/05  (CSharp File Generated Date)</br>
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
    /// <br>Update Note      :   2010/06/22  工藤</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   キャンセル区分</br>
    /// <br>                 :   CMT連携区分</br>
	/// </remarks>
	public class SCMAcOdrData
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

		/// <summary>更新時分秒ミリ秒</summary>
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

		/// <summary>サーバー番号</summary>
		/// <remarks>PM7項目</remarks>
		private Int32 _serverNumber;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

        // ADD 2010/06/22 NS待機処理対応 ---------->>>>>
        /// <summary>キャンセル区分</summary>
        private short _cancelDiv;
        /// <summary>キャンセル区分</summary>
        /// <remarks>0:キャンセルなし 1:キャンセルあり</remarks>
        public short CancelDiv
        {
            get { return _cancelDiv; }
            set { _cancelDiv = value; }
        }

        /// <summary>CMT連携区分</summary>
        private short _CMTCooprtDiv;
        /// <summary>CMT連携区分</summary>
        /// <remarks>0:連携なし 1:連携あり</remarks>
        public short CMTCooprtDiv
        {
            get { return _CMTCooprtDiv; }
            set { _CMTCooprtDiv = value; }
        }
        // ADD 2010/06/22 NS待機処理対応 ----------<<<<<

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

		/// public propaty name  :  CreateDateTimeJpFormal
		/// <summary>作成日時 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeJpInFormal
		/// <summary>作成日時 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdFormal
		/// <summary>作成日時 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdInFormal
		/// <summary>作成日時 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
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

		/// public propaty name  :  UpdateDateTimeJpFormal
		/// <summary>更新日時 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeJpInFormal
		/// <summary>更新日時 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdFormal
		/// <summary>更新日時 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdInFormal
		/// <summary>更新日時 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
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

		/// public propaty name  :  JudgementDateJpFormal
		/// <summary>確定日 和暦プロパティ</summary>
		/// <value>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   確定日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string JudgementDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _judgementDate);}
			set{}
		}

		/// public propaty name  :  JudgementDateJpInFormal
		/// <summary>確定日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   確定日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string JudgementDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _judgementDate);}
			set{}
		}

		/// public propaty name  :  JudgementDateAdFormal
		/// <summary>確定日 西暦プロパティ</summary>
		/// <value>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   確定日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string JudgementDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _judgementDate);}
			set{}
		}

		/// public propaty name  :  JudgementDateAdInFormal
		/// <summary>確定日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   確定日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string JudgementDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _judgementDate);}
			set{}
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

		/// public propaty name  :  InquiryDateJpFormal
		/// <summary>問合せ日 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InquiryDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _inquiryDate);}
			set{}
		}

		/// public propaty name  :  InquiryDateJpInFormal
		/// <summary>問合せ日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InquiryDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _inquiryDate);}
			set{}
		}

		/// public propaty name  :  InquiryDateAdFormal
		/// <summary>問合せ日 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InquiryDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _inquiryDate);}
			set{}
		}

		/// public propaty name  :  InquiryDateAdInFormal
		/// <summary>問合せ日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InquiryDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _inquiryDate);}
			set{}
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

		/// public propaty name  :  ReceiveDateTimeJpFormal
		/// <summary>受信日時 和暦プロパティ</summary>
		/// <value>（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受信日時 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ReceiveDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _receiveDateTime);}
			set{}
		}

		/// public propaty name  :  ReceiveDateTimeJpInFormal
		/// <summary>受信日時 和暦(略)プロパティ</summary>
		/// <value>（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受信日時 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ReceiveDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _receiveDateTime);}
			set{}
		}

		/// public propaty name  :  ReceiveDateTimeAdFormal
		/// <summary>受信日時 西暦プロパティ</summary>
		/// <value>（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受信日時 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ReceiveDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _receiveDateTime);}
			set{}
		}

		/// public propaty name  :  ReceiveDateTimeAdInFormal
		/// <summary>受信日時 西暦(略)プロパティ</summary>
		/// <value>（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受信日時 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ReceiveDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _receiveDateTime);}
			set{}
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

		/// public propaty name  :  ServerNumber
		/// <summary>サーバー番号プロパティ</summary>
		/// <value>PM7項目</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   サーバー番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ServerNumber
		{
			get{return _serverNumber;}
			set{_serverNumber = value;}
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

		/// public propaty name  :  UpdEmployeeName
		/// <summary>更新従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
		}


		/// <summary>
		/// SCM受注データコンストラクタ
		/// </summary>
		/// <returns>SCMAcOdrDataクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDataクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMAcOdrData()
		{
		}

		/// <summary>
		/// SCM受注データコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="inqOriginalEpCd">問合せ元企業コード</param>
		/// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
		/// <param name="inqOtherEpCd">問合せ先企業コード</param>
		/// <param name="inqOtherSecCd">問合せ先拠点コード</param>
		/// <param name="inquiryNumber">問合せ番号</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="updateDate">更新年月日(YYYYMMDD)</param>
		/// <param name="updateTime">更新時分秒ミリ秒(HHMMSSXXX)</param>
		/// <param name="answerDivCd">回答区分(0:アクションなし 10:一部回答 20:回答完了 30:承認 99:キャンセル)</param>
		/// <param name="judgementDate">確定日(YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。)</param>
		/// <param name="inqOrdNote">問合せ・発注備考</param>
		/// <param name="appendingFile">添付ファイル</param>
		/// <param name="appendingFileNm">添付ファイル名</param>
		/// <param name="inqEmployeeCd">問合せ従業員コード(問合せした従業員コード)</param>
		/// <param name="inqEmployeeNm">問合せ従業員名称(問合せした従業員名称)</param>
		/// <param name="ansEmployeeCd">回答従業員コード</param>
		/// <param name="ansEmployeeNm">回答従業員名称</param>
		/// <param name="inquiryDate">問合せ日(YYYYMMDD)</param>
		/// <param name="acptAnOdrStatus">受注ステータス(10:見積,20:受注,30:売上)</param>
		/// <param name="salesSlipNum">売上伝票番号(見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。)</param>
		/// <param name="salesTotalTaxInc">売上伝票合計（税込み）(売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額)</param>
		/// <param name="salesSubtotalTax">売上小計（税）(値引後の税額（外税分、内税分の合計）)</param>
		/// <param name="inqOrdDivCd">問合せ・発注種別(1:問合せ 2:発注)</param>
		/// <param name="inqOrdAnsDivCd">問発・回答種別(1:問合せ・発注 2:回答)</param>
		/// <param name="receiveDateTime">受信日時(（DateTime:精度は100ナノ秒）)</param>
		/// <param name="answerCreateDiv">回答作成区分(0:自動, 1:手動（Web）, 2:手動（その他）)</param>
		/// <param name="serverNumber">サーバー番号(PM7項目)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>SCMAcOdrDataクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDataクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public SCMAcOdrData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, Int32 customerCode, DateTime updateDate, Int32 updateTime, Int32 answerDivCd, DateTime judgementDate, string inqOrdNote, Byte[] appendingFile, string appendingFileNm, string inqEmployeeCd, string inqEmployeeNm, string ansEmployeeCd, string ansEmployeeNm, DateTime inquiryDate, Int32 acptAnOdrStatus, string salesSlipNum, Int64 salesTotalTaxInc, Int64 salesSubtotalTax, Int32 inqOrdDivCd, Int32 inqOrdAnsDivCd, DateTime receiveDateTime, Int32 answerCreateDiv, Int32 serverNumber, string enterpriseName, string updEmployeeName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
			this._inqOriginalSecCd = inqOriginalSecCd;
			this._inqOtherEpCd = inqOtherEpCd;
			this._inqOtherSecCd = inqOtherSecCd;
			this._inquiryNumber = inquiryNumber;
			this._customerCode = customerCode;
			this.UpdateDate = updateDate;
			this._updateTime = updateTime;
			this._answerDivCd = answerDivCd;
			this.JudgementDate = judgementDate;
			this._inqOrdNote = inqOrdNote;
			this._appendingFile = appendingFile;
			this._appendingFileNm = appendingFileNm;
			this._inqEmployeeCd = inqEmployeeCd;
			this._inqEmployeeNm = inqEmployeeNm;
			this._ansEmployeeCd = ansEmployeeCd;
			this._ansEmployeeNm = ansEmployeeNm;
			this.InquiryDate = inquiryDate;
			this._acptAnOdrStatus = acptAnOdrStatus;
			this._salesSlipNum = salesSlipNum;
			this._salesTotalTaxInc = salesTotalTaxInc;
			this._salesSubtotalTax = salesSubtotalTax;
			this._inqOrdDivCd = inqOrdDivCd;
			this._inqOrdAnsDivCd = inqOrdAnsDivCd;
			this.ReceiveDateTime = receiveDateTime;
			this._answerCreateDiv = answerCreateDiv;
			this._serverNumber = serverNumber;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// SCM受注データ複製処理
		/// </summary>
		/// <returns>SCMAcOdrDataクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSCMAcOdrDataクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMAcOdrData Clone()
		{
			return new SCMAcOdrData(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._inqOriginalEpCd.Trim(),this._inqOriginalSecCd,this._inqOtherEpCd,this._inqOtherSecCd,this._inquiryNumber,this._customerCode,this._updateDate,this._updateTime,this._answerDivCd,this._judgementDate,this._inqOrdNote,this._appendingFile,this._appendingFileNm,this._inqEmployeeCd,this._inqEmployeeNm,this._ansEmployeeCd,this._ansEmployeeNm,this._inquiryDate,this._acptAnOdrStatus,this._salesSlipNum,this._salesTotalTaxInc,this._salesSubtotalTax,this._inqOrdDivCd,this._inqOrdAnsDivCd,this._receiveDateTime,this._answerCreateDiv,this._serverNumber,this._enterpriseName,this._updEmployeeName);//@@@@20230303
		}

		/// <summary>
		/// SCM受注データ比較処理
		/// </summary>
		/// <param name="target">比較対象のSCMAcOdrDataクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDataクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SCMAcOdrData target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim()) //@@@@20230303
				 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
				 && (this.InqOtherEpCd == target.InqOtherEpCd)
				 && (this.InqOtherSecCd == target.InqOtherSecCd)
				 && (this.InquiryNumber == target.InquiryNumber)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.UpdateDate == target.UpdateDate)
				 && (this.UpdateTime == target.UpdateTime)
				 && (this.AnswerDivCd == target.AnswerDivCd)
				 && (this.JudgementDate == target.JudgementDate)
				 && (this.InqOrdNote == target.InqOrdNote)
				 && (this.AppendingFile == target.AppendingFile)
				 && (this.AppendingFileNm == target.AppendingFileNm)
				 && (this.InqEmployeeCd == target.InqEmployeeCd)
				 && (this.InqEmployeeNm == target.InqEmployeeNm)
				 && (this.AnsEmployeeCd == target.AnsEmployeeCd)
				 && (this.AnsEmployeeNm == target.AnsEmployeeNm)
				 && (this.InquiryDate == target.InquiryDate)
				 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
				 && (this.SalesSlipNum == target.SalesSlipNum)
				 && (this.SalesTotalTaxInc == target.SalesTotalTaxInc)
				 && (this.SalesSubtotalTax == target.SalesSubtotalTax)
				 && (this.InqOrdDivCd == target.InqOrdDivCd)
				 && (this.InqOrdAnsDivCd == target.InqOrdAnsDivCd)
				 && (this.ReceiveDateTime == target.ReceiveDateTime)
				 && (this.AnswerCreateDiv == target.AnswerCreateDiv)
				 && (this.ServerNumber == target.ServerNumber)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// SCM受注データ比較処理
		/// </summary>
		/// <param name="sCMAcOdrData1">
		///                    比較するSCMAcOdrDataクラスのインスタンス
		/// </param>
		/// <param name="sCMAcOdrData2">比較するSCMAcOdrDataクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDataクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SCMAcOdrData sCMAcOdrData1, SCMAcOdrData sCMAcOdrData2)
		{
			return ((sCMAcOdrData1.CreateDateTime == sCMAcOdrData2.CreateDateTime)
				 && (sCMAcOdrData1.UpdateDateTime == sCMAcOdrData2.UpdateDateTime)
				 && (sCMAcOdrData1.EnterpriseCode == sCMAcOdrData2.EnterpriseCode)
				 && (sCMAcOdrData1.FileHeaderGuid == sCMAcOdrData2.FileHeaderGuid)
				 && (sCMAcOdrData1.UpdEmployeeCode == sCMAcOdrData2.UpdEmployeeCode)
				 && (sCMAcOdrData1.UpdAssemblyId1 == sCMAcOdrData2.UpdAssemblyId1)
				 && (sCMAcOdrData1.UpdAssemblyId2 == sCMAcOdrData2.UpdAssemblyId2)
				 && (sCMAcOdrData1.LogicalDeleteCode == sCMAcOdrData2.LogicalDeleteCode)
				 && (sCMAcOdrData1.InqOriginalEpCd.Trim() == sCMAcOdrData2.InqOriginalEpCd.Trim()) //@@@@20230303
				 && (sCMAcOdrData1.InqOriginalSecCd == sCMAcOdrData2.InqOriginalSecCd)
				 && (sCMAcOdrData1.InqOtherEpCd == sCMAcOdrData2.InqOtherEpCd)
				 && (sCMAcOdrData1.InqOtherSecCd == sCMAcOdrData2.InqOtherSecCd)
				 && (sCMAcOdrData1.InquiryNumber == sCMAcOdrData2.InquiryNumber)
				 && (sCMAcOdrData1.CustomerCode == sCMAcOdrData2.CustomerCode)
				 && (sCMAcOdrData1.UpdateDate == sCMAcOdrData2.UpdateDate)
				 && (sCMAcOdrData1.UpdateTime == sCMAcOdrData2.UpdateTime)
				 && (sCMAcOdrData1.AnswerDivCd == sCMAcOdrData2.AnswerDivCd)
				 && (sCMAcOdrData1.JudgementDate == sCMAcOdrData2.JudgementDate)
				 && (sCMAcOdrData1.InqOrdNote == sCMAcOdrData2.InqOrdNote)
				 && (sCMAcOdrData1.AppendingFile == sCMAcOdrData2.AppendingFile)
				 && (sCMAcOdrData1.AppendingFileNm == sCMAcOdrData2.AppendingFileNm)
				 && (sCMAcOdrData1.InqEmployeeCd == sCMAcOdrData2.InqEmployeeCd)
				 && (sCMAcOdrData1.InqEmployeeNm == sCMAcOdrData2.InqEmployeeNm)
				 && (sCMAcOdrData1.AnsEmployeeCd == sCMAcOdrData2.AnsEmployeeCd)
				 && (sCMAcOdrData1.AnsEmployeeNm == sCMAcOdrData2.AnsEmployeeNm)
				 && (sCMAcOdrData1.InquiryDate == sCMAcOdrData2.InquiryDate)
				 && (sCMAcOdrData1.AcptAnOdrStatus == sCMAcOdrData2.AcptAnOdrStatus)
				 && (sCMAcOdrData1.SalesSlipNum == sCMAcOdrData2.SalesSlipNum)
				 && (sCMAcOdrData1.SalesTotalTaxInc == sCMAcOdrData2.SalesTotalTaxInc)
				 && (sCMAcOdrData1.SalesSubtotalTax == sCMAcOdrData2.SalesSubtotalTax)
				 && (sCMAcOdrData1.InqOrdDivCd == sCMAcOdrData2.InqOrdDivCd)
				 && (sCMAcOdrData1.InqOrdAnsDivCd == sCMAcOdrData2.InqOrdAnsDivCd)
				 && (sCMAcOdrData1.ReceiveDateTime == sCMAcOdrData2.ReceiveDateTime)
				 && (sCMAcOdrData1.AnswerCreateDiv == sCMAcOdrData2.AnswerCreateDiv)
				 && (sCMAcOdrData1.ServerNumber == sCMAcOdrData2.ServerNumber)
				 && (sCMAcOdrData1.EnterpriseName == sCMAcOdrData2.EnterpriseName)
				 && (sCMAcOdrData1.UpdEmployeeName == sCMAcOdrData2.UpdEmployeeName));
		}
		/// <summary>
		/// SCM受注データ比較処理
		/// </summary>
		/// <param name="target">比較対象のSCMAcOdrDataクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDataクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SCMAcOdrData target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(this.InqOriginalSecCd != target.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(this.InqOtherEpCd != target.InqOtherEpCd)resList.Add("InqOtherEpCd");
			if(this.InqOtherSecCd != target.InqOtherSecCd)resList.Add("InqOtherSecCd");
			if(this.InquiryNumber != target.InquiryNumber)resList.Add("InquiryNumber");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.UpdateDate != target.UpdateDate)resList.Add("UpdateDate");
			if(this.UpdateTime != target.UpdateTime)resList.Add("UpdateTime");
			if(this.AnswerDivCd != target.AnswerDivCd)resList.Add("AnswerDivCd");
			if(this.JudgementDate != target.JudgementDate)resList.Add("JudgementDate");
			if(this.InqOrdNote != target.InqOrdNote)resList.Add("InqOrdNote");
			if(this.AppendingFile != target.AppendingFile)resList.Add("AppendingFile");
			if(this.AppendingFileNm != target.AppendingFileNm)resList.Add("AppendingFileNm");
			if(this.InqEmployeeCd != target.InqEmployeeCd)resList.Add("InqEmployeeCd");
			if(this.InqEmployeeNm != target.InqEmployeeNm)resList.Add("InqEmployeeNm");
			if(this.AnsEmployeeCd != target.AnsEmployeeCd)resList.Add("AnsEmployeeCd");
			if(this.AnsEmployeeNm != target.AnsEmployeeNm)resList.Add("AnsEmployeeNm");
			if(this.InquiryDate != target.InquiryDate)resList.Add("InquiryDate");
			if(this.AcptAnOdrStatus != target.AcptAnOdrStatus)resList.Add("AcptAnOdrStatus");
			if(this.SalesSlipNum != target.SalesSlipNum)resList.Add("SalesSlipNum");
			if(this.SalesTotalTaxInc != target.SalesTotalTaxInc)resList.Add("SalesTotalTaxInc");
			if(this.SalesSubtotalTax != target.SalesSubtotalTax)resList.Add("SalesSubtotalTax");
			if(this.InqOrdDivCd != target.InqOrdDivCd)resList.Add("InqOrdDivCd");
			if(this.InqOrdAnsDivCd != target.InqOrdAnsDivCd)resList.Add("InqOrdAnsDivCd");
			if(this.ReceiveDateTime != target.ReceiveDateTime)resList.Add("ReceiveDateTime");
			if(this.AnswerCreateDiv != target.AnswerCreateDiv)resList.Add("AnswerCreateDiv");
			if(this.ServerNumber != target.ServerNumber)resList.Add("ServerNumber");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// SCM受注データ比較処理
		/// </summary>
		/// <param name="sCMAcOdrData1">比較するSCMAcOdrDataクラスのインスタンス</param>
		/// <param name="sCMAcOdrData2">比較するSCMAcOdrDataクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDataクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SCMAcOdrData sCMAcOdrData1, SCMAcOdrData sCMAcOdrData2)
		{
			ArrayList resList = new ArrayList();
			if(sCMAcOdrData1.CreateDateTime != sCMAcOdrData2.CreateDateTime)resList.Add("CreateDateTime");
			if(sCMAcOdrData1.UpdateDateTime != sCMAcOdrData2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(sCMAcOdrData1.EnterpriseCode != sCMAcOdrData2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(sCMAcOdrData1.FileHeaderGuid != sCMAcOdrData2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(sCMAcOdrData1.UpdEmployeeCode != sCMAcOdrData2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(sCMAcOdrData1.UpdAssemblyId1 != sCMAcOdrData2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(sCMAcOdrData1.UpdAssemblyId2 != sCMAcOdrData2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(sCMAcOdrData1.LogicalDeleteCode != sCMAcOdrData2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(sCMAcOdrData1.InqOriginalEpCd.Trim() != sCMAcOdrData2.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(sCMAcOdrData1.InqOriginalSecCd != sCMAcOdrData2.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(sCMAcOdrData1.InqOtherEpCd != sCMAcOdrData2.InqOtherEpCd)resList.Add("InqOtherEpCd");
			if(sCMAcOdrData1.InqOtherSecCd != sCMAcOdrData2.InqOtherSecCd)resList.Add("InqOtherSecCd");
			if(sCMAcOdrData1.InquiryNumber != sCMAcOdrData2.InquiryNumber)resList.Add("InquiryNumber");
			if(sCMAcOdrData1.CustomerCode != sCMAcOdrData2.CustomerCode)resList.Add("CustomerCode");
			if(sCMAcOdrData1.UpdateDate != sCMAcOdrData2.UpdateDate)resList.Add("UpdateDate");
			if(sCMAcOdrData1.UpdateTime != sCMAcOdrData2.UpdateTime)resList.Add("UpdateTime");
			if(sCMAcOdrData1.AnswerDivCd != sCMAcOdrData2.AnswerDivCd)resList.Add("AnswerDivCd");
			if(sCMAcOdrData1.JudgementDate != sCMAcOdrData2.JudgementDate)resList.Add("JudgementDate");
			if(sCMAcOdrData1.InqOrdNote != sCMAcOdrData2.InqOrdNote)resList.Add("InqOrdNote");
			if(sCMAcOdrData1.AppendingFile != sCMAcOdrData2.AppendingFile)resList.Add("AppendingFile");
			if(sCMAcOdrData1.AppendingFileNm != sCMAcOdrData2.AppendingFileNm)resList.Add("AppendingFileNm");
			if(sCMAcOdrData1.InqEmployeeCd != sCMAcOdrData2.InqEmployeeCd)resList.Add("InqEmployeeCd");
			if(sCMAcOdrData1.InqEmployeeNm != sCMAcOdrData2.InqEmployeeNm)resList.Add("InqEmployeeNm");
			if(sCMAcOdrData1.AnsEmployeeCd != sCMAcOdrData2.AnsEmployeeCd)resList.Add("AnsEmployeeCd");
			if(sCMAcOdrData1.AnsEmployeeNm != sCMAcOdrData2.AnsEmployeeNm)resList.Add("AnsEmployeeNm");
			if(sCMAcOdrData1.InquiryDate != sCMAcOdrData2.InquiryDate)resList.Add("InquiryDate");
			if(sCMAcOdrData1.AcptAnOdrStatus != sCMAcOdrData2.AcptAnOdrStatus)resList.Add("AcptAnOdrStatus");
			if(sCMAcOdrData1.SalesSlipNum != sCMAcOdrData2.SalesSlipNum)resList.Add("SalesSlipNum");
			if(sCMAcOdrData1.SalesTotalTaxInc != sCMAcOdrData2.SalesTotalTaxInc)resList.Add("SalesTotalTaxInc");
			if(sCMAcOdrData1.SalesSubtotalTax != sCMAcOdrData2.SalesSubtotalTax)resList.Add("SalesSubtotalTax");
			if(sCMAcOdrData1.InqOrdDivCd != sCMAcOdrData2.InqOrdDivCd)resList.Add("InqOrdDivCd");
			if(sCMAcOdrData1.InqOrdAnsDivCd != sCMAcOdrData2.InqOrdAnsDivCd)resList.Add("InqOrdAnsDivCd");
			if(sCMAcOdrData1.ReceiveDateTime != sCMAcOdrData2.ReceiveDateTime)resList.Add("ReceiveDateTime");
			if(sCMAcOdrData1.AnswerCreateDiv != sCMAcOdrData2.AnswerCreateDiv)resList.Add("AnswerCreateDiv");
			if(sCMAcOdrData1.ServerNumber != sCMAcOdrData2.ServerNumber)resList.Add("ServerNumber");
			if(sCMAcOdrData1.EnterpriseName != sCMAcOdrData2.EnterpriseName)resList.Add("EnterpriseName");
			if(sCMAcOdrData1.UpdEmployeeName != sCMAcOdrData2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}
