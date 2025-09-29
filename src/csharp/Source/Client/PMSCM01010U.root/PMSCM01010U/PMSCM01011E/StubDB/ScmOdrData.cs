using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData.StubDB
{
	/// public class name:   ScmOdrData
	/// <summary>
	///                      SCM受発注データ
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM受発注データヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/2/20</br>
	/// <br>Genarated Date   :   2009/05/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/5/7  寺坂　誉志</br>
	/// <br>                 :   問合せ・発注種別,添付ファイル,</br>
	/// <br>                 :   添付ファイル名,発注日</br>
	/// <br>                 :   削除</br>
	/// <br>Update Note      :   2009/5/19  岩本　勇</br>
	/// <br>                 :   受信日時追加</br>
	/// <br>Update Note      :   2009/5/22  寺坂　誉志</br>
	/// <br>                 :   最新識別区分</br>
	/// <br>                 :   追加</br>
	/// </remarks>
	public class ScmOdrData
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

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

		/// <summary>更新年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>更新時分秒ミリ秒</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;

		/// <summary>回答区分</summary>
		/// <remarks>0:アクションなし 1:回答中 10:一部回答 20:回答完了 30:承認 99:キャンセル</remarks>
		private Int32 _answerDivCd;

		/// <summary>確定日</summary>
		/// <remarks>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</remarks>
		private DateTime _judgementDate;

		/// <summary>問合せ・発注備考</summary>
		private string _inqOrdNote = "";

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

		/// <summary>問合せ・発注種別</summary>
		/// <remarks>1:問合せ 2:発注</remarks>
		private Int32 _inqOrdDivCd;

		/// <summary>問発・回答種別</summary>
		/// <remarks>1:問合せ・発注 2:回答</remarks>
		private Int32 _inqOrdAnsDivCd;

		/// <summary>受信日時</summary>
		/// <remarks>（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _receiveDateTime;

		/// <summary>最新識別区分</summary>
		/// <remarks>0:最新データ 1:旧データ</remarks>
		private Int16 _latestDiscCode;


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
		/// <value>0:アクションなし 1:回答中 10:一部回答 20:回答完了 30:承認 99:キャンセル</value>
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

		/// public propaty name  :  LatestDiscCode
		/// <summary>最新識別区分プロパティ</summary>
		/// <value>0:最新データ 1:旧データ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最新識別区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int16 LatestDiscCode
		{
			get{return _latestDiscCode;}
			set{_latestDiscCode = value;}
		}


		/// <summary>
		/// SCM受発注データコンストラクタ
		/// </summary>
		/// <returns>ScmOdrDataクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdrDataクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmOdrData()
		{
		}

		/// <summary>
		/// SCM受発注データコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="inqOriginalEpCd">問合せ元企業コード</param>
		/// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
		/// <param name="inqOtherEpCd">問合せ先企業コード</param>
		/// <param name="inqOtherSecCd">問合せ先拠点コード</param>
		/// <param name="inquiryNumber">問合せ番号</param>
		/// <param name="updateDate">更新年月日(YYYYMMDD)</param>
		/// <param name="updateTime">更新時分秒ミリ秒(HHMMSSXXX)</param>
		/// <param name="answerDivCd">回答区分(0:アクションなし 1:回答中 10:一部回答 20:回答完了 30:承認 99:キャンセル)</param>
		/// <param name="judgementDate">確定日(YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。)</param>
		/// <param name="inqOrdNote">問合せ・発注備考</param>
		/// <param name="inqEmployeeCd">問合せ従業員コード(問合せした従業員コード)</param>
		/// <param name="inqEmployeeNm">問合せ従業員名称(問合せした従業員名称)</param>
		/// <param name="ansEmployeeCd">回答従業員コード</param>
		/// <param name="ansEmployeeNm">回答従業員名称</param>
		/// <param name="inquiryDate">問合せ日(YYYYMMDD)</param>
		/// <param name="inqOrdDivCd">問合せ・発注種別(1:問合せ 2:発注)</param>
		/// <param name="inqOrdAnsDivCd">問発・回答種別(1:問合せ・発注 2:回答)</param>
		/// <param name="receiveDateTime">受信日時(（DateTime:精度は100ナノ秒）)</param>
		/// <param name="latestDiscCode">最新識別区分(0:最新データ 1:旧データ)</param>
		/// <returns>ScmOdrDataクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdrDataクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmOdrData(DateTime createDateTime,DateTime updateDateTime,Int32 logicalDeleteCode,string inqOriginalEpCd,string inqOriginalSecCd,string inqOtherEpCd,string inqOtherSecCd,Int64 inquiryNumber,DateTime updateDate,Int32 updateTime,Int32 answerDivCd,DateTime judgementDate,string inqOrdNote,string inqEmployeeCd,string inqEmployeeNm,string ansEmployeeCd,string ansEmployeeNm,DateTime inquiryDate,Int32 inqOrdDivCd,Int32 inqOrdAnsDivCd,DateTime receiveDateTime,Int16 latestDiscCode)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._logicalDeleteCode = logicalDeleteCode;
			this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
			this._inqOriginalSecCd = inqOriginalSecCd;
			this._inqOtherEpCd = inqOtherEpCd;
			this._inqOtherSecCd = inqOtherSecCd;
			this._inquiryNumber = inquiryNumber;
			this.UpdateDate = updateDate;
			this._updateTime = updateTime;
			this._answerDivCd = answerDivCd;
			this._judgementDate = judgementDate;
			this._inqOrdNote = inqOrdNote;
			this._inqEmployeeCd = inqEmployeeCd;
			this._inqEmployeeNm = inqEmployeeNm;
			this._ansEmployeeCd = ansEmployeeCd;
			this._ansEmployeeNm = ansEmployeeNm;
			this._inquiryDate = inquiryDate;
			this._inqOrdDivCd = inqOrdDivCd;
			this._inqOrdAnsDivCd = inqOrdAnsDivCd;
			this._receiveDateTime = receiveDateTime;
			this._latestDiscCode = latestDiscCode;

		}

		/// <summary>
		/// SCM受発注データ複製処理
		/// </summary>
		/// <returns>ScmOdrDataクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいScmOdrDataクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmOdrData Clone()
		{
			return new ScmOdrData(this._createDateTime,this._updateDateTime,this._logicalDeleteCode,this._inqOriginalEpCd.Trim(),this._inqOriginalSecCd,this._inqOtherEpCd,this._inqOtherSecCd,this._inquiryNumber,this._updateDate,this._updateTime,this._answerDivCd,this._judgementDate,this._inqOrdNote,this._inqEmployeeCd,this._inqEmployeeNm,this._ansEmployeeCd,this._ansEmployeeNm,this._inquiryDate,this._inqOrdDivCd,this._inqOrdAnsDivCd,this._receiveDateTime,this._latestDiscCode);//@@@@20230303
		}

		/// <summary>
		/// SCM受発注データ比較処理
		/// </summary>
		/// <param name="target">比較対象のScmOdrDataクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdrDataクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ScmOdrData target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim()) //@@@@20230303
				 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
				 && (this.InqOtherEpCd == target.InqOtherEpCd)
				 && (this.InqOtherSecCd == target.InqOtherSecCd)
				 && (this.InquiryNumber == target.InquiryNumber)
				 && (this.UpdateDate == target.UpdateDate)
				 && (this.UpdateTime == target.UpdateTime)
				 && (this.AnswerDivCd == target.AnswerDivCd)
				 && (this.JudgementDate == target.JudgementDate)
				 && (this.InqOrdNote == target.InqOrdNote)
				 && (this.InqEmployeeCd == target.InqEmployeeCd)
				 && (this.InqEmployeeNm == target.InqEmployeeNm)
				 && (this.AnsEmployeeCd == target.AnsEmployeeCd)
				 && (this.AnsEmployeeNm == target.AnsEmployeeNm)
				 && (this.InquiryDate == target.InquiryDate)
				 && (this.InqOrdDivCd == target.InqOrdDivCd)
				 && (this.InqOrdAnsDivCd == target.InqOrdAnsDivCd)
				 && (this.ReceiveDateTime == target.ReceiveDateTime)
				 && (this.LatestDiscCode == target.LatestDiscCode));
		}

		/// <summary>
		/// SCM受発注データ比較処理
		/// </summary>
		/// <param name="scmOdrData1">
		///                    比較するScmOdrDataクラスのインスタンス
		/// </param>
		/// <param name="scmOdrData2">比較するScmOdrDataクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdrDataクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ScmOdrData scmOdrData1, ScmOdrData scmOdrData2)
		{
			return ((scmOdrData1.CreateDateTime == scmOdrData2.CreateDateTime)
				 && (scmOdrData1.UpdateDateTime == scmOdrData2.UpdateDateTime)
				 && (scmOdrData1.LogicalDeleteCode == scmOdrData2.LogicalDeleteCode)
				 && (scmOdrData1.InqOriginalEpCd.Trim() == scmOdrData2.InqOriginalEpCd.Trim()) //@@@@20230303
				 && (scmOdrData1.InqOriginalSecCd == scmOdrData2.InqOriginalSecCd)
				 && (scmOdrData1.InqOtherEpCd == scmOdrData2.InqOtherEpCd)
				 && (scmOdrData1.InqOtherSecCd == scmOdrData2.InqOtherSecCd)
				 && (scmOdrData1.InquiryNumber == scmOdrData2.InquiryNumber)
				 && (scmOdrData1.UpdateDate == scmOdrData2.UpdateDate)
				 && (scmOdrData1.UpdateTime == scmOdrData2.UpdateTime)
				 && (scmOdrData1.AnswerDivCd == scmOdrData2.AnswerDivCd)
				 && (scmOdrData1.JudgementDate == scmOdrData2.JudgementDate)
				 && (scmOdrData1.InqOrdNote == scmOdrData2.InqOrdNote)
				 && (scmOdrData1.InqEmployeeCd == scmOdrData2.InqEmployeeCd)
				 && (scmOdrData1.InqEmployeeNm == scmOdrData2.InqEmployeeNm)
				 && (scmOdrData1.AnsEmployeeCd == scmOdrData2.AnsEmployeeCd)
				 && (scmOdrData1.AnsEmployeeNm == scmOdrData2.AnsEmployeeNm)
				 && (scmOdrData1.InquiryDate == scmOdrData2.InquiryDate)
				 && (scmOdrData1.InqOrdDivCd == scmOdrData2.InqOrdDivCd)
				 && (scmOdrData1.InqOrdAnsDivCd == scmOdrData2.InqOrdAnsDivCd)
				 && (scmOdrData1.ReceiveDateTime == scmOdrData2.ReceiveDateTime)
				 && (scmOdrData1.LatestDiscCode == scmOdrData2.LatestDiscCode));
		}
		/// <summary>
		/// SCM受発注データ比較処理
		/// </summary>
		/// <param name="target">比較対象のScmOdrDataクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdrDataクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ScmOdrData target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(this.InqOriginalSecCd != target.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(this.InqOtherEpCd != target.InqOtherEpCd)resList.Add("InqOtherEpCd");
			if(this.InqOtherSecCd != target.InqOtherSecCd)resList.Add("InqOtherSecCd");
			if(this.InquiryNumber != target.InquiryNumber)resList.Add("InquiryNumber");
			if(this.UpdateDate != target.UpdateDate)resList.Add("UpdateDate");
			if(this.UpdateTime != target.UpdateTime)resList.Add("UpdateTime");
			if(this.AnswerDivCd != target.AnswerDivCd)resList.Add("AnswerDivCd");
			if(this.JudgementDate != target.JudgementDate)resList.Add("JudgementDate");
			if(this.InqOrdNote != target.InqOrdNote)resList.Add("InqOrdNote");
			if(this.InqEmployeeCd != target.InqEmployeeCd)resList.Add("InqEmployeeCd");
			if(this.InqEmployeeNm != target.InqEmployeeNm)resList.Add("InqEmployeeNm");
			if(this.AnsEmployeeCd != target.AnsEmployeeCd)resList.Add("AnsEmployeeCd");
			if(this.AnsEmployeeNm != target.AnsEmployeeNm)resList.Add("AnsEmployeeNm");
			if(this.InquiryDate != target.InquiryDate)resList.Add("InquiryDate");
			if(this.InqOrdDivCd != target.InqOrdDivCd)resList.Add("InqOrdDivCd");
			if(this.InqOrdAnsDivCd != target.InqOrdAnsDivCd)resList.Add("InqOrdAnsDivCd");
			if(this.ReceiveDateTime != target.ReceiveDateTime)resList.Add("ReceiveDateTime");
			if(this.LatestDiscCode != target.LatestDiscCode)resList.Add("LatestDiscCode");

			return resList;
		}

		/// <summary>
		/// SCM受発注データ比較処理
		/// </summary>
		/// <param name="scmOdrData1">比較するScmOdrDataクラスのインスタンス</param>
		/// <param name="scmOdrData2">比較するScmOdrDataクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdrDataクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ScmOdrData scmOdrData1, ScmOdrData scmOdrData2)
		{
			ArrayList resList = new ArrayList();
			if(scmOdrData1.CreateDateTime != scmOdrData2.CreateDateTime)resList.Add("CreateDateTime");
			if(scmOdrData1.UpdateDateTime != scmOdrData2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(scmOdrData1.LogicalDeleteCode != scmOdrData2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(scmOdrData1.InqOriginalEpCd.Trim() != scmOdrData2.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(scmOdrData1.InqOriginalSecCd != scmOdrData2.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(scmOdrData1.InqOtherEpCd != scmOdrData2.InqOtherEpCd)resList.Add("InqOtherEpCd");
			if(scmOdrData1.InqOtherSecCd != scmOdrData2.InqOtherSecCd)resList.Add("InqOtherSecCd");
			if(scmOdrData1.InquiryNumber != scmOdrData2.InquiryNumber)resList.Add("InquiryNumber");
			if(scmOdrData1.UpdateDate != scmOdrData2.UpdateDate)resList.Add("UpdateDate");
			if(scmOdrData1.UpdateTime != scmOdrData2.UpdateTime)resList.Add("UpdateTime");
			if(scmOdrData1.AnswerDivCd != scmOdrData2.AnswerDivCd)resList.Add("AnswerDivCd");
			if(scmOdrData1.JudgementDate != scmOdrData2.JudgementDate)resList.Add("JudgementDate");
			if(scmOdrData1.InqOrdNote != scmOdrData2.InqOrdNote)resList.Add("InqOrdNote");
			if(scmOdrData1.InqEmployeeCd != scmOdrData2.InqEmployeeCd)resList.Add("InqEmployeeCd");
			if(scmOdrData1.InqEmployeeNm != scmOdrData2.InqEmployeeNm)resList.Add("InqEmployeeNm");
			if(scmOdrData1.AnsEmployeeCd != scmOdrData2.AnsEmployeeCd)resList.Add("AnsEmployeeCd");
			if(scmOdrData1.AnsEmployeeNm != scmOdrData2.AnsEmployeeNm)resList.Add("AnsEmployeeNm");
			if(scmOdrData1.InquiryDate != scmOdrData2.InquiryDate)resList.Add("InquiryDate");
			if(scmOdrData1.InqOrdDivCd != scmOdrData2.InqOrdDivCd)resList.Add("InqOrdDivCd");
			if(scmOdrData1.InqOrdAnsDivCd != scmOdrData2.InqOrdAnsDivCd)resList.Add("InqOrdAnsDivCd");
			if(scmOdrData1.ReceiveDateTime != scmOdrData2.ReceiveDateTime)resList.Add("ReceiveDateTime");
			if(scmOdrData1.LatestDiscCode != scmOdrData2.LatestDiscCode)resList.Add("LatestDiscCode");

			return resList;
		}
	}
}
