using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SCMAnsListSrchRst
	/// <summary>
	///                      SCM回答一覧検索結果クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM回答一覧検索結果クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/05/25</br>
	/// <br>Genarated Date   :   2011/05/20  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/7/17  柏原　頼人</br>
	/// <br>                 :   問発・回答種別、受信日時を追加</br>
	/// <br>Update Note      :   2010/5/31  柏原　頼人</br>
	/// <br>                 :   キャンセル区分を追加</br>
	/// <br>Update Note      :   2011/5/19  橋本　裕毅</br>
	/// <br>                 :   引当完了区分、確定日、問合せ・発注備考、</br>
	/// <br>                 :   SF-PM連携指示書番号を追加</br>
	/// <br>                 :   回答区分の補足説明の内容を修正</br>
    /// <br>Update Note      :   2011/7/25  阿間見　充</br>
    /// <br>                 :   受発注種別を追加</br>
	/// </remarks>
	[Serializable]
	public class SCMAnsListSrchRst
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
		/// <remarks>0:アクションなし 1:回答中 2:受付済み 10:一部回答 20:回答完了 30:承認 99:キャンセル</remarks>
		private Int32 _answerDivCd;

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

		/// <summary>陸運事務所番号</summary>
		private Int32 _numberPlate1Code;

		/// <summary>陸運事務局名称</summary>
		private string _numberPlate1Name = "";

		/// <summary>車両登録番号（種別）</summary>
		private string _numberPlate2 = "";

		/// <summary>車両登録番号（カナ）</summary>
		private string _numberPlate3 = "";

		/// <summary>車両登録番号（プレート番号）</summary>
		private Int32 _numberPlate4;

		/// <summary>型式指定番号</summary>
		private Int32 _modelDesignationNo;

		/// <summary>類別番号</summary>
		private Int32 _categoryNo;

		/// <summary>メーカーコード</summary>
		/// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _makerCode;

		/// <summary>車種名</summary>
		private string _modelName = "";

		/// <summary>車検証型式</summary>
		private string _carInspectCertModel = "";

		/// <summary>車台番号</summary>
		private string _frameNo = "";

		/// <summary>車台型式</summary>
		private string _frameModel = "";

		/// <summary>問発・回答種別</summary>
		/// <remarks>1:問合せ・発注 2:回答</remarks>
		private Int32 _inqOrdAnsDivCd;

		/// <summary>受信日時</summary>
		/// <remarks>（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _receiveDateTime;

		/// <summary>キャンセル区分</summary>
		/// <remarks>0:キャンセルなし 1:キャンセルあり</remarks>
		private Int16 _cancelDiv;

		/// <summary>確定日</summary>
		/// <remarks>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</remarks>
		private DateTime _judgementDate;

		/// <summary>SF-PM連携指示書番号</summary>
		/// <remarks>(半角全角混在)</remarks>
		private string _sfPmCprtInstSlipNo = "";

        /// <summary>受発注種別</summary>
        /// <remarks>0:通常,1:PCC-UOE</remarks>
        private Int16 _acceptOrOrderKind;

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
			get { return _createDateTime; }
			set { _createDateTime = value; }
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
			get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
			set { }
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
			get { return _updateDateTime; }
			set { _updateDateTime = value; }
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
			get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
			set { }
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
			get { return _logicalDeleteCode; }
			set { _logicalDeleteCode = value; }
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
			get { return _inqOriginalEpCd; }
			set { _inqOriginalEpCd = value; }
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
			get { return _inqOriginalSecCd; }
			set { _inqOriginalSecCd = value; }
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
			get { return _inqOtherEpCd; }
			set { _inqOtherEpCd = value; }
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
			get { return _inqOtherSecCd; }
			set { _inqOtherSecCd = value; }
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
			get { return _inquiryNumber; }
			set { _inquiryNumber = value; }
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
			get { return _updateDate; }
			set { _updateDate = value; }
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
			get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDate); }
			set { }
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
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDate); }
			set { }
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
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDate); }
			set { }
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
			get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDate); }
			set { }
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
			get { return _updateTime; }
			set { _updateTime = value; }
		}

		/// public propaty name  :  AnswerDivCd
		/// <summary>回答区分プロパティ</summary>
		/// <value>0:アクションなし 1:回答中 2:受付済み 10:一部回答 20:回答完了 30:承認 99:キャンセル</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AnswerDivCd
		{
			get { return _answerDivCd; }
			set { _answerDivCd = value; }
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
			get { return _inqOrdNote; }
			set { _inqOrdNote = value; }
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
			get { return _inqEmployeeCd; }
			set { _inqEmployeeCd = value; }
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
			get { return _inqEmployeeNm; }
			set { _inqEmployeeNm = value; }
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
			get { return _ansEmployeeCd; }
			set { _ansEmployeeCd = value; }
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
			get { return _ansEmployeeNm; }
			set { _ansEmployeeNm = value; }
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
			get { return _inquiryDate; }
			set { _inquiryDate = value; }
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
			get { return TDateTime.DateTimeToString("GGYYMMDD", _inquiryDate); }
			set { }
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
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _inquiryDate); }
			set { }
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
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _inquiryDate); }
			set { }
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
			get { return TDateTime.DateTimeToString("YY/MM/DD", _inquiryDate); }
			set { }
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
			get { return _inqOrdDivCd; }
			set { _inqOrdDivCd = value; }
		}

		/// public propaty name  :  NumberPlate1Code
		/// <summary>陸運事務所番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   陸運事務所番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NumberPlate1Code
		{
			get { return _numberPlate1Code; }
			set { _numberPlate1Code = value; }
		}

		/// public propaty name  :  NumberPlate1Name
		/// <summary>陸運事務局名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   陸運事務局名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string NumberPlate1Name
		{
			get { return _numberPlate1Name; }
			set { _numberPlate1Name = value; }
		}

		/// public propaty name  :  NumberPlate2
		/// <summary>車両登録番号（種別）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両登録番号（種別）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string NumberPlate2
		{
			get { return _numberPlate2; }
			set { _numberPlate2 = value; }
		}

		/// public propaty name  :  NumberPlate3
		/// <summary>車両登録番号（カナ）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両登録番号（カナ）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string NumberPlate3
		{
			get { return _numberPlate3; }
			set { _numberPlate3 = value; }
		}

		/// public propaty name  :  NumberPlate4
		/// <summary>車両登録番号（プレート番号）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両登録番号（プレート番号）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NumberPlate4
		{
			get { return _numberPlate4; }
			set { _numberPlate4 = value; }
		}

		/// public propaty name  :  ModelDesignationNo
		/// <summary>型式指定番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   型式指定番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelDesignationNo
		{
			get { return _modelDesignationNo; }
			set { _modelDesignationNo = value; }
		}

		/// public propaty name  :  CategoryNo
		/// <summary>類別番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   類別番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CategoryNo
		{
			get { return _categoryNo; }
			set { _categoryNo = value; }
		}

		/// public propaty name  :  MakerCode
		/// <summary>メーカーコードプロパティ</summary>
		/// <value>1～899:提供分, 900～ユーザー登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MakerCode
		{
			get { return _makerCode; }
			set { _makerCode = value; }
		}

		/// public propaty name  :  ModelName
		/// <summary>車種名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車種名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ModelName
		{
			get { return _modelName; }
			set { _modelName = value; }
		}

		/// public propaty name  :  CarInspectCertModel
		/// <summary>車検証型式プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車検証型式プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CarInspectCertModel
		{
			get { return _carInspectCertModel; }
			set { _carInspectCertModel = value; }
		}

		/// public propaty name  :  FrameNo
		/// <summary>車台番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車台番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FrameNo
		{
			get { return _frameNo; }
			set { _frameNo = value; }
		}

		/// public propaty name  :  FrameModel
		/// <summary>車台型式プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車台型式プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FrameModel
		{
			get { return _frameModel; }
			set { _frameModel = value; }
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
			get { return _inqOrdAnsDivCd; }
			set { _inqOrdAnsDivCd = value; }
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
			get { return _receiveDateTime; }
			set { _receiveDateTime = value; }
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
			get { return TDateTime.DateTimeToString("GGYYMMDD", _receiveDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _receiveDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _receiveDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("YY/MM/DD", _receiveDateTime); }
			set { }
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
			get { return _cancelDiv; }
			set { _cancelDiv = value; }
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
			get { return _judgementDate; }
			set { _judgementDate = value; }
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
			get { return TDateTime.DateTimeToString("GGYYMMDD", _judgementDate); }
			set { }
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
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _judgementDate); }
			set { }
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
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _judgementDate); }
			set { }
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
			get { return TDateTime.DateTimeToString("YY/MM/DD", _judgementDate); }
			set { }
		}

		/// public propaty name  :  SfPmCprtInstSlipNo
		/// <summary>SF-PM連携指示書番号プロパティ</summary>
		/// <value>(半角全角混在)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   SF-PM連携指示書番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SfPmCprtInstSlipNo
		{
			get { return _sfPmCprtInstSlipNo; }
			set { _sfPmCprtInstSlipNo = value; }
		}

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


		/// <summary>
		/// SCM回答一覧検索結果クラスコンストラクタ
		/// </summary>
		/// <returns>SCMAnsListSrchRstクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAnsListSrchRstクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMAnsListSrchRst()
		{
		}

		/// <summary>
		/// SCM回答一覧検索結果クラスコンストラクタ
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
		/// <param name="answerDivCd">回答区分(0:アクションなし 1:回答中 2:受付済み 10:一部回答 20:回答完了 30:承認 99:キャンセル)</param>
		/// <param name="inqOrdNote">問合せ・発注備考</param>
		/// <param name="inqEmployeeCd">問合せ従業員コード(問合せした従業員コード)</param>
		/// <param name="inqEmployeeNm">問合せ従業員名称(問合せした従業員名称)</param>
		/// <param name="ansEmployeeCd">回答従業員コード</param>
		/// <param name="ansEmployeeNm">回答従業員名称</param>
		/// <param name="inquiryDate">問合せ日(YYYYMMDD)</param>
		/// <param name="inqOrdDivCd">問合せ・発注種別(1:問合せ 2:発注)</param>
		/// <param name="numberPlate1Code">陸運事務所番号</param>
		/// <param name="numberPlate1Name">陸運事務局名称</param>
		/// <param name="numberPlate2">車両登録番号（種別）</param>
		/// <param name="numberPlate3">車両登録番号（カナ）</param>
		/// <param name="numberPlate4">車両登録番号（プレート番号）</param>
		/// <param name="modelDesignationNo">型式指定番号</param>
		/// <param name="categoryNo">類別番号</param>
		/// <param name="makerCode">メーカーコード(1～899:提供分, 900～ユーザー登録)</param>
		/// <param name="modelName">車種名</param>
		/// <param name="carInspectCertModel">車検証型式</param>
		/// <param name="frameNo">車台番号</param>
		/// <param name="frameModel">車台型式</param>
		/// <param name="inqOrdAnsDivCd">問発・回答種別(1:問合せ・発注 2:回答)</param>
		/// <param name="receiveDateTime">受信日時(（DateTime:精度は100ナノ秒）)</param>
		/// <param name="cancelDiv">キャンセル区分(0:キャンセルなし 1:キャンセルあり)</param>
		/// <param name="judgementDate">確定日(YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。)</param>
		/// <param name="sfPmCprtInstSlipNo">SF-PM連携指示書番号((半角全角混在))</param>
        /// <param name="acceptOrOrderKind ">受発注種別(0:通常,1:PCC-UOE)</param>
		/// <returns>SCMAnsListSrchRstクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAnsListSrchRstクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public SCMAnsListSrchRst(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime, Int32 answerDivCd, string inqOrdNote, string inqEmployeeCd, string inqEmployeeNm, string ansEmployeeCd, string ansEmployeeNm, DateTime inquiryDate, Int32 inqOrdDivCd, Int32 numberPlate1Code, string numberPlate1Name, string numberPlate2, string numberPlate3, Int32 numberPlate4, Int32 modelDesignationNo, Int32 categoryNo, Int32 makerCode, string modelName, string carInspectCertModel, string frameNo, string frameModel, Int32 inqOrdAnsDivCd, DateTime receiveDateTime, Int16 cancelDiv, DateTime judgementDate, string sfPmCprtInstSlipNo, Int16 acceptOrOrderKind)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._logicalDeleteCode = logicalDeleteCode;
			this._inqOriginalEpCd = inqOriginalEpCd;
			this._inqOriginalSecCd = inqOriginalSecCd;
			this._inqOtherEpCd = inqOtherEpCd;
			this._inqOtherSecCd = inqOtherSecCd;
			this._inquiryNumber = inquiryNumber;
			this.UpdateDate = updateDate;
			this._updateTime = updateTime;
			this._answerDivCd = answerDivCd;
			this._inqOrdNote = inqOrdNote;
			this._inqEmployeeCd = inqEmployeeCd;
			this._inqEmployeeNm = inqEmployeeNm;
			this._ansEmployeeCd = ansEmployeeCd;
			this._ansEmployeeNm = ansEmployeeNm;
			this.InquiryDate = inquiryDate;
			this._inqOrdDivCd = inqOrdDivCd;
			this._numberPlate1Code = numberPlate1Code;
			this._numberPlate1Name = numberPlate1Name;
			this._numberPlate2 = numberPlate2;
			this._numberPlate3 = numberPlate3;
			this._numberPlate4 = numberPlate4;
			this._modelDesignationNo = modelDesignationNo;
			this._categoryNo = categoryNo;
			this._makerCode = makerCode;
			this._modelName = modelName;
			this._carInspectCertModel = carInspectCertModel;
			this._frameNo = frameNo;
			this._frameModel = frameModel;
			this._inqOrdAnsDivCd = inqOrdAnsDivCd;
			this.ReceiveDateTime = receiveDateTime;
			this._cancelDiv = cancelDiv;
			this.JudgementDate = judgementDate;
			this._sfPmCprtInstSlipNo = sfPmCprtInstSlipNo;
            this._acceptOrOrderKind = acceptOrOrderKind;

		}

		/// <summary>
		/// SCM回答一覧検索結果クラス複製処理
		/// </summary>
		/// <returns>SCMAnsListSrchRstクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSCMAnsListSrchRstクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMAnsListSrchRst Clone()
		{
            return new SCMAnsListSrchRst(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._updateDate, this._updateTime, this._answerDivCd, this._inqOrdNote, this._inqEmployeeCd, this._inqEmployeeNm, this._ansEmployeeCd, this._ansEmployeeNm, this._inquiryDate, this._inqOrdDivCd, this._numberPlate1Code, this._numberPlate1Name, this._numberPlate2, this._numberPlate3, this._numberPlate4, this._modelDesignationNo, this._categoryNo, this._makerCode, this._modelName, this._carInspectCertModel, this._frameNo, this._frameModel, this._inqOrdAnsDivCd, this._receiveDateTime, this._cancelDiv, this._judgementDate, this._sfPmCprtInstSlipNo, this._acceptOrOrderKind);
		}

		/// <summary>
		/// SCM回答一覧検索結果クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSCMAnsListSrchRstクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAnsListSrchRstクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SCMAnsListSrchRst target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.InqOriginalEpCd == target.InqOriginalEpCd)
				 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
				 && (this.InqOtherEpCd == target.InqOtherEpCd)
				 && (this.InqOtherSecCd == target.InqOtherSecCd)
				 && (this.InquiryNumber == target.InquiryNumber)
				 && (this.UpdateDate == target.UpdateDate)
				 && (this.UpdateTime == target.UpdateTime)
				 && (this.AnswerDivCd == target.AnswerDivCd)
				 && (this.InqOrdNote == target.InqOrdNote)
				 && (this.InqEmployeeCd == target.InqEmployeeCd)
				 && (this.InqEmployeeNm == target.InqEmployeeNm)
				 && (this.AnsEmployeeCd == target.AnsEmployeeCd)
				 && (this.AnsEmployeeNm == target.AnsEmployeeNm)
				 && (this.InquiryDate == target.InquiryDate)
				 && (this.InqOrdDivCd == target.InqOrdDivCd)
				 && (this.NumberPlate1Code == target.NumberPlate1Code)
				 && (this.NumberPlate1Name == target.NumberPlate1Name)
				 && (this.NumberPlate2 == target.NumberPlate2)
				 && (this.NumberPlate3 == target.NumberPlate3)
				 && (this.NumberPlate4 == target.NumberPlate4)
				 && (this.ModelDesignationNo == target.ModelDesignationNo)
				 && (this.CategoryNo == target.CategoryNo)
				 && (this.MakerCode == target.MakerCode)
				 && (this.ModelName == target.ModelName)
				 && (this.CarInspectCertModel == target.CarInspectCertModel)
				 && (this.FrameNo == target.FrameNo)
				 && (this.FrameModel == target.FrameModel)
				 && (this.InqOrdAnsDivCd == target.InqOrdAnsDivCd)
				 && (this.ReceiveDateTime == target.ReceiveDateTime)
				 && (this.CancelDiv == target.CancelDiv)
				 && (this.JudgementDate == target.JudgementDate)
				 && (this.SfPmCprtInstSlipNo == target.SfPmCprtInstSlipNo)
                 && (this.AcceptOrOrderKind == target.AcceptOrOrderKind));
		}

		/// <summary>
		/// SCM回答一覧検索結果クラス比較処理
		/// </summary>
		/// <param name="sCMAnsListSrchRst1">
		///                    比較するSCMAnsListSrchRstクラスのインスタンス
		/// </param>
		/// <param name="sCMAnsListSrchRst2">比較するSCMAnsListSrchRstクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAnsListSrchRstクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SCMAnsListSrchRst sCMAnsListSrchRst1, SCMAnsListSrchRst sCMAnsListSrchRst2)
		{
			return ((sCMAnsListSrchRst1.CreateDateTime == sCMAnsListSrchRst2.CreateDateTime)
				 && (sCMAnsListSrchRst1.UpdateDateTime == sCMAnsListSrchRst2.UpdateDateTime)
				 && (sCMAnsListSrchRst1.LogicalDeleteCode == sCMAnsListSrchRst2.LogicalDeleteCode)
				 && (sCMAnsListSrchRst1.InqOriginalEpCd == sCMAnsListSrchRst2.InqOriginalEpCd)
				 && (sCMAnsListSrchRst1.InqOriginalSecCd == sCMAnsListSrchRst2.InqOriginalSecCd)
				 && (sCMAnsListSrchRst1.InqOtherEpCd == sCMAnsListSrchRst2.InqOtherEpCd)
				 && (sCMAnsListSrchRst1.InqOtherSecCd == sCMAnsListSrchRst2.InqOtherSecCd)
				 && (sCMAnsListSrchRst1.InquiryNumber == sCMAnsListSrchRst2.InquiryNumber)
				 && (sCMAnsListSrchRst1.UpdateDate == sCMAnsListSrchRst2.UpdateDate)
				 && (sCMAnsListSrchRst1.UpdateTime == sCMAnsListSrchRst2.UpdateTime)
				 && (sCMAnsListSrchRst1.AnswerDivCd == sCMAnsListSrchRst2.AnswerDivCd)
				 && (sCMAnsListSrchRst1.InqOrdNote == sCMAnsListSrchRst2.InqOrdNote)
				 && (sCMAnsListSrchRst1.InqEmployeeCd == sCMAnsListSrchRst2.InqEmployeeCd)
				 && (sCMAnsListSrchRst1.InqEmployeeNm == sCMAnsListSrchRst2.InqEmployeeNm)
				 && (sCMAnsListSrchRst1.AnsEmployeeCd == sCMAnsListSrchRst2.AnsEmployeeCd)
				 && (sCMAnsListSrchRst1.AnsEmployeeNm == sCMAnsListSrchRst2.AnsEmployeeNm)
				 && (sCMAnsListSrchRst1.InquiryDate == sCMAnsListSrchRst2.InquiryDate)
				 && (sCMAnsListSrchRst1.InqOrdDivCd == sCMAnsListSrchRst2.InqOrdDivCd)
				 && (sCMAnsListSrchRst1.NumberPlate1Code == sCMAnsListSrchRst2.NumberPlate1Code)
				 && (sCMAnsListSrchRst1.NumberPlate1Name == sCMAnsListSrchRst2.NumberPlate1Name)
				 && (sCMAnsListSrchRst1.NumberPlate2 == sCMAnsListSrchRst2.NumberPlate2)
				 && (sCMAnsListSrchRst1.NumberPlate3 == sCMAnsListSrchRst2.NumberPlate3)
				 && (sCMAnsListSrchRst1.NumberPlate4 == sCMAnsListSrchRst2.NumberPlate4)
				 && (sCMAnsListSrchRst1.ModelDesignationNo == sCMAnsListSrchRst2.ModelDesignationNo)
				 && (sCMAnsListSrchRst1.CategoryNo == sCMAnsListSrchRst2.CategoryNo)
				 && (sCMAnsListSrchRst1.MakerCode == sCMAnsListSrchRst2.MakerCode)
				 && (sCMAnsListSrchRst1.ModelName == sCMAnsListSrchRst2.ModelName)
				 && (sCMAnsListSrchRst1.CarInspectCertModel == sCMAnsListSrchRst2.CarInspectCertModel)
				 && (sCMAnsListSrchRst1.FrameNo == sCMAnsListSrchRst2.FrameNo)
				 && (sCMAnsListSrchRst1.FrameModel == sCMAnsListSrchRst2.FrameModel)
				 && (sCMAnsListSrchRst1.InqOrdAnsDivCd == sCMAnsListSrchRst2.InqOrdAnsDivCd)
				 && (sCMAnsListSrchRst1.ReceiveDateTime == sCMAnsListSrchRst2.ReceiveDateTime)
				 && (sCMAnsListSrchRst1.CancelDiv == sCMAnsListSrchRst2.CancelDiv)
				 && (sCMAnsListSrchRst1.JudgementDate == sCMAnsListSrchRst2.JudgementDate)
				 && (sCMAnsListSrchRst1.SfPmCprtInstSlipNo == sCMAnsListSrchRst2.SfPmCprtInstSlipNo)
                 && (sCMAnsListSrchRst1.AcceptOrOrderKind == sCMAnsListSrchRst2.AcceptOrOrderKind));
		}
		/// <summary>
		/// SCM回答一覧検索結果クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSCMAnsListSrchRstクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAnsListSrchRstクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SCMAnsListSrchRst target)
		{
			ArrayList resList = new ArrayList();
			if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
			if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
			if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (this.InquiryNumber != target.InquiryNumber) resList.Add("InquiryNumber");
			if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
			if (this.UpdateTime != target.UpdateTime) resList.Add("UpdateTime");
			if (this.AnswerDivCd != target.AnswerDivCd) resList.Add("AnswerDivCd");
			if (this.InqOrdNote != target.InqOrdNote) resList.Add("InqOrdNote");
			if (this.InqEmployeeCd != target.InqEmployeeCd) resList.Add("InqEmployeeCd");
			if (this.InqEmployeeNm != target.InqEmployeeNm) resList.Add("InqEmployeeNm");
			if (this.AnsEmployeeCd != target.AnsEmployeeCd) resList.Add("AnsEmployeeCd");
			if (this.AnsEmployeeNm != target.AnsEmployeeNm) resList.Add("AnsEmployeeNm");
			if (this.InquiryDate != target.InquiryDate) resList.Add("InquiryDate");
			if (this.InqOrdDivCd != target.InqOrdDivCd) resList.Add("InqOrdDivCd");
			if (this.NumberPlate1Code != target.NumberPlate1Code) resList.Add("NumberPlate1Code");
			if (this.NumberPlate1Name != target.NumberPlate1Name) resList.Add("NumberPlate1Name");
			if (this.NumberPlate2 != target.NumberPlate2) resList.Add("NumberPlate2");
			if (this.NumberPlate3 != target.NumberPlate3) resList.Add("NumberPlate3");
			if (this.NumberPlate4 != target.NumberPlate4) resList.Add("NumberPlate4");
			if (this.ModelDesignationNo != target.ModelDesignationNo) resList.Add("ModelDesignationNo");
			if (this.CategoryNo != target.CategoryNo) resList.Add("CategoryNo");
			if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
			if (this.ModelName != target.ModelName) resList.Add("ModelName");
			if (this.CarInspectCertModel != target.CarInspectCertModel) resList.Add("CarInspectCertModel");
			if (this.FrameNo != target.FrameNo) resList.Add("FrameNo");
			if (this.FrameModel != target.FrameModel) resList.Add("FrameModel");
			if (this.InqOrdAnsDivCd != target.InqOrdAnsDivCd) resList.Add("InqOrdAnsDivCd");
			if (this.ReceiveDateTime != target.ReceiveDateTime) resList.Add("ReceiveDateTime");
			if (this.CancelDiv != target.CancelDiv) resList.Add("CancelDiv");
			if (this.JudgementDate != target.JudgementDate) resList.Add("JudgementDate");
			if (this.SfPmCprtInstSlipNo != target.SfPmCprtInstSlipNo) resList.Add("SfPmCprtInstSlipNo");
            if (this.AcceptOrOrderKind != target.AcceptOrOrderKind) resList.Add("AcceptOrOrderKind");

			return resList;
		}

		/// <summary>
		/// SCM回答一覧検索結果クラス比較処理
		/// </summary>
		/// <param name="sCMAnsListSrchRst1">比較するSCMAnsListSrchRstクラスのインスタンス</param>
		/// <param name="sCMAnsListSrchRst2">比較するSCMAnsListSrchRstクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAnsListSrchRstクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SCMAnsListSrchRst sCMAnsListSrchRst1, SCMAnsListSrchRst sCMAnsListSrchRst2)
		{
			ArrayList resList = new ArrayList();
			if (sCMAnsListSrchRst1.CreateDateTime != sCMAnsListSrchRst2.CreateDateTime) resList.Add("CreateDateTime");
			if (sCMAnsListSrchRst1.UpdateDateTime != sCMAnsListSrchRst2.UpdateDateTime) resList.Add("UpdateDateTime");
			if (sCMAnsListSrchRst1.LogicalDeleteCode != sCMAnsListSrchRst2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (sCMAnsListSrchRst1.InqOriginalEpCd != sCMAnsListSrchRst2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (sCMAnsListSrchRst1.InqOriginalSecCd != sCMAnsListSrchRst2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (sCMAnsListSrchRst1.InqOtherEpCd != sCMAnsListSrchRst2.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (sCMAnsListSrchRst1.InqOtherSecCd != sCMAnsListSrchRst2.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (sCMAnsListSrchRst1.InquiryNumber != sCMAnsListSrchRst2.InquiryNumber) resList.Add("InquiryNumber");
			if (sCMAnsListSrchRst1.UpdateDate != sCMAnsListSrchRst2.UpdateDate) resList.Add("UpdateDate");
			if (sCMAnsListSrchRst1.UpdateTime != sCMAnsListSrchRst2.UpdateTime) resList.Add("UpdateTime");
			if (sCMAnsListSrchRst1.AnswerDivCd != sCMAnsListSrchRst2.AnswerDivCd) resList.Add("AnswerDivCd");
			if (sCMAnsListSrchRst1.InqOrdNote != sCMAnsListSrchRst2.InqOrdNote) resList.Add("InqOrdNote");
			if (sCMAnsListSrchRst1.InqEmployeeCd != sCMAnsListSrchRst2.InqEmployeeCd) resList.Add("InqEmployeeCd");
			if (sCMAnsListSrchRst1.InqEmployeeNm != sCMAnsListSrchRst2.InqEmployeeNm) resList.Add("InqEmployeeNm");
			if (sCMAnsListSrchRst1.AnsEmployeeCd != sCMAnsListSrchRst2.AnsEmployeeCd) resList.Add("AnsEmployeeCd");
			if (sCMAnsListSrchRst1.AnsEmployeeNm != sCMAnsListSrchRst2.AnsEmployeeNm) resList.Add("AnsEmployeeNm");
			if (sCMAnsListSrchRst1.InquiryDate != sCMAnsListSrchRst2.InquiryDate) resList.Add("InquiryDate");
			if (sCMAnsListSrchRst1.InqOrdDivCd != sCMAnsListSrchRst2.InqOrdDivCd) resList.Add("InqOrdDivCd");
			if (sCMAnsListSrchRst1.NumberPlate1Code != sCMAnsListSrchRst2.NumberPlate1Code) resList.Add("NumberPlate1Code");
			if (sCMAnsListSrchRst1.NumberPlate1Name != sCMAnsListSrchRst2.NumberPlate1Name) resList.Add("NumberPlate1Name");
			if (sCMAnsListSrchRst1.NumberPlate2 != sCMAnsListSrchRst2.NumberPlate2) resList.Add("NumberPlate2");
			if (sCMAnsListSrchRst1.NumberPlate3 != sCMAnsListSrchRst2.NumberPlate3) resList.Add("NumberPlate3");
			if (sCMAnsListSrchRst1.NumberPlate4 != sCMAnsListSrchRst2.NumberPlate4) resList.Add("NumberPlate4");
			if (sCMAnsListSrchRst1.ModelDesignationNo != sCMAnsListSrchRst2.ModelDesignationNo) resList.Add("ModelDesignationNo");
			if (sCMAnsListSrchRst1.CategoryNo != sCMAnsListSrchRst2.CategoryNo) resList.Add("CategoryNo");
			if (sCMAnsListSrchRst1.MakerCode != sCMAnsListSrchRst2.MakerCode) resList.Add("MakerCode");
			if (sCMAnsListSrchRst1.ModelName != sCMAnsListSrchRst2.ModelName) resList.Add("ModelName");
			if (sCMAnsListSrchRst1.CarInspectCertModel != sCMAnsListSrchRst2.CarInspectCertModel) resList.Add("CarInspectCertModel");
			if (sCMAnsListSrchRst1.FrameNo != sCMAnsListSrchRst2.FrameNo) resList.Add("FrameNo");
			if (sCMAnsListSrchRst1.FrameModel != sCMAnsListSrchRst2.FrameModel) resList.Add("FrameModel");
			if (sCMAnsListSrchRst1.InqOrdAnsDivCd != sCMAnsListSrchRst2.InqOrdAnsDivCd) resList.Add("InqOrdAnsDivCd");
			if (sCMAnsListSrchRst1.ReceiveDateTime != sCMAnsListSrchRst2.ReceiveDateTime) resList.Add("ReceiveDateTime");
			if (sCMAnsListSrchRst1.CancelDiv != sCMAnsListSrchRst2.CancelDiv) resList.Add("CancelDiv");
			if (sCMAnsListSrchRst1.JudgementDate != sCMAnsListSrchRst2.JudgementDate) resList.Add("JudgementDate");
			if (sCMAnsListSrchRst1.SfPmCprtInstSlipNo != sCMAnsListSrchRst2.SfPmCprtInstSlipNo) resList.Add("SfPmCprtInstSlipNo");
            if (sCMAnsListSrchRst1.AcceptOrOrderKind != sCMAnsListSrchRst2.AcceptOrOrderKind) resList.Add("AcceptOrOrderKind");

			return resList;
		}
	}
}
