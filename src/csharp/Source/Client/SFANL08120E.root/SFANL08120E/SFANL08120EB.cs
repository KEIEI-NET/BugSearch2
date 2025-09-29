using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	// ------------------------------------------------------------
	//  ※UsedFlgを追加
	//  ※チェック項目コードの初期値を-1に変更
	// ------------------------------------------------------------

	/// public class name:   FrePprECnd
	/// <summary>
	///                      自由帳票抽出条件設定マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   自由帳票抽出条件設定マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/03/15</br>
	/// <br>Genarated Date   :   2007/03/30  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class FrePprECnd
	{
		#region AutoGenerate PrivateMember
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

		/// <summary>出力ファイル名</summary>
		/// <remarks>フォームファイルID or フォーマットファイルID</remarks>
		private string _outputFormFileName = "";

		/// <summary>ユーザー帳票ID枝番号</summary>
		private Int32 _userPrtPprIdDerivNo;

		/// <summary>自由帳票抽出条件枝番</summary>
		private Int32 _frePrtPprExtraCondCd;

		/// <summary>表示順位</summary>
		private Int32 _displayOrder;

		/// <summary>抽出条件区分</summary>
		/// <remarks>0:使用不可,1:数値型,2:文字型（半角）,3:文字型（全角）,4:日付型,5:コンボ型,6:チェック型</remarks>
		private Int32 _extraConditionDivCd;

		/// <summary>抽出条件タイプ</summary>
		/// <remarks>0:一致,1:範囲,2:あいまい,3:期間</remarks>
		private Int32 _extraConditionTypeCd;

		/// <summary>抽出条件タイトル</summary>
		private string _extraConditionTitle = "";

		/// <summary>DD桁数</summary>
		private Int32 _dDCharCnt;

		/// <summary>DD名称</summary>
		/// <remarks>小文字で登録</remarks>
		private string _dDName = "";

		/// <summary>抽出開始コード（数値）</summary>
		private Int64 _stExtraNumCode;

		/// <summary>抽出終了コード（数値）</summary>
		private Int64 _edExtraNumCode;

		/// <summary>抽出開始コード（文字）</summary>
		private string _stExtraCharCode = "";

		/// <summary>抽出終了コード（文字）</summary>
		private string _edExtraCharCode = "";

		/// <summary>抽出開始日付（基準）</summary>
		/// <remarks>0:前々日,1:前日,2:本日,3:翌日,4:翌々日,5:日付指定</remarks>
		private Int32 _stExtraDateBaseCd;

		/// <summary>抽出開始日付（正負）</summary>
		/// <remarks>0:＋（プラス）,1:－（マイナス）</remarks>
		private Int32 _stExtraDateSignCd;

		/// <summary>抽出開始日付（数値）</summary>
		private Int32 _stExtraDateNum;

		/// <summary>抽出開始日付（単位）</summary>
		/// <remarks>0:日,1:週,2:月,3:年</remarks>
		private Int32 _stExtraDateUnitCd;

		/// <summary>抽出開始日付（日付）</summary>
		private Int32 _startExtraDate;

		/// <summary>抽出終了日付（基準）</summary>
		/// <remarks>0:前々日,1:前日,2:本日,3:翌日,4:翌々日,5:日付指定</remarks>
		private Int32 _edExtraDateBaseCd;

		/// <summary>抽出終了日付（正負）</summary>
		/// <remarks>0:＋（プラス）,1:－（マイナス）</remarks>
		private Int32 _edExtraDateSignCd;

		/// <summary>抽出終了日付（数値）</summary>
		private Int32 _edExtraDateNum;

		/// <summary>抽出終了日付（単位）</summary>
		/// <remarks>0:日,1:週,2:月,3:年</remarks>
		private Int32 _edExtraDateUnitCd;

		/// <summary>抽出終了日付（日付）</summary>
		private Int32 _endExtraDate;

		/// <summary>抽出条件明細グループコード</summary>
		/// <remarks>抽出条件区分がコンボボックス型の時に使用</remarks>
		private Int32 _extraCondDetailGrpCd;

		/// <summary>必須抽出条件区分</summary>
		/// <remarks>0:任意,1:必須</remarks>
		private Int32 _necessaryExtraCondCd;

		/// <summary>チェック項目コード1</summary>
		private Int32 _checkItemCode1 = -1;

		/// <summary>チェック項目コード2</summary>
		private Int32 _checkItemCode2 = -1;

		/// <summary>チェック項目コード3</summary>
		private Int32 _checkItemCode3 = -1;

		/// <summary>チェック項目コード4</summary>
		private Int32 _checkItemCode4 = -1;

		/// <summary>チェック項目コード5</summary>
		private Int32 _checkItemCode5 = -1;

		/// <summary>チェック項目コード6</summary>
		private Int32 _checkItemCode6 = -1;

		/// <summary>チェック項目コード7</summary>
		private Int32 _checkItemCode7 = -1;

		/// <summary>チェック項目コード8</summary>
		private Int32 _checkItemCode8 = -1;

		/// <summary>チェック項目コード9</summary>
		private Int32 _checkItemCode9 = -1;

		/// <summary>チェック項目コード10</summary>
		private Int32 _checkItemCode10 = -1;

		/// <summary>ファイル名称</summary>
		/// <remarks>DBのテーブルID</remarks>
		private string _fileNm = "";

		/// <summary>入力桁数</summary>
		/// <remarks>条件の入力制限で使用</remarks>
		private Int32 _inputCharCnt;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";
		#endregion

		#region AutoGenerate Property
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
			get { return _fileHeaderGuid; }
			set { _fileHeaderGuid = value; }
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
			get { return _updEmployeeCode; }
			set { _updEmployeeCode = value; }
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
			get { return _updAssemblyId1; }
			set { _updAssemblyId1 = value; }
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
			get { return _updAssemblyId2; }
			set { _updAssemblyId2 = value; }
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

		/// public propaty name  :  OutputFormFileName
		/// <summary>出力ファイル名プロパティ</summary>
		/// <value>フォームファイルID or フォーマットファイルID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力ファイル名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OutputFormFileName
		{
			get { return _outputFormFileName; }
			set { _outputFormFileName = value; }
		}

		/// public propaty name  :  UserPrtPprIdDerivNo
		/// <summary>ユーザー帳票ID枝番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ユーザー帳票ID枝番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UserPrtPprIdDerivNo
		{
			get { return _userPrtPprIdDerivNo; }
			set { _userPrtPprIdDerivNo = value; }
		}

		/// public propaty name  :  FrePrtPprExtraCondCd
		/// <summary>自由帳票抽出条件枝番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票抽出条件枝番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FrePrtPprExtraCondCd
		{
			get { return _frePrtPprExtraCondCd; }
			set { _frePrtPprExtraCondCd = value; }
		}

		/// public propaty name  :  DisplayOrder
		/// <summary>表示順位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   表示順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DisplayOrder
		{
			get { return _displayOrder; }
			set { _displayOrder = value; }
		}

		/// public propaty name  :  ExtraConditionDivCd
		/// <summary>抽出条件区分プロパティ</summary>
		/// <value>0:使用不可,1:数値型,2:文字型（半角）,3:文字型（全角）,4:日付型,5:コンボ型,6:チェック型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出条件区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ExtraConditionDivCd
		{
			get { return _extraConditionDivCd; }
			set { _extraConditionDivCd = value; }
		}

		/// public propaty name  :  ExtraConditionTypeCd
		/// <summary>抽出条件タイププロパティ</summary>
		/// <value>0:一致,1:範囲,2:あいまい,3:期間</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出条件タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ExtraConditionTypeCd
		{
			get { return _extraConditionTypeCd; }
			set { _extraConditionTypeCd = value; }
		}

		/// public propaty name  :  ExtraConditionTitle
		/// <summary>抽出条件タイトルプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出条件タイトルプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ExtraConditionTitle
		{
			get { return _extraConditionTitle; }
			set { _extraConditionTitle = value; }
		}

		/// public propaty name  :  DDCharCnt
		/// <summary>DD桁数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   DD桁数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DDCharCnt
		{
			get { return _dDCharCnt; }
			set { _dDCharCnt = value; }
		}

		/// public propaty name  :  DDName
		/// <summary>DD名称プロパティ</summary>
		/// <value>小文字で登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   DD名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DDName
		{
			get { return _dDName; }
			set { _dDName = value; }
		}

		/// public propaty name  :  StExtraNumCode
		/// <summary>抽出開始コード（数値）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出開始コード（数値）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StExtraNumCode
		{
			get { return _stExtraNumCode; }
			set { _stExtraNumCode = value; }
		}

		/// public propaty name  :  EdExtraNumCode
		/// <summary>抽出終了コード（数値）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出終了コード（数値）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 EdExtraNumCode
		{
			get { return _edExtraNumCode; }
			set { _edExtraNumCode = value; }
		}

		/// public propaty name  :  StExtraCharCode
		/// <summary>抽出開始コード（文字）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出開始コード（文字）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StExtraCharCode
		{
			get { return _stExtraCharCode; }
			set { _stExtraCharCode = value; }
		}

		/// public propaty name  :  EdExtraCharCode
		/// <summary>抽出終了コード（文字）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出終了コード（文字）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EdExtraCharCode
		{
			get { return _edExtraCharCode; }
			set { _edExtraCharCode = value; }
		}

		/// public propaty name  :  StExtraDateBaseCd
		/// <summary>抽出開始日付（基準）プロパティ</summary>
		/// <value>0:前々日,1:前日,2:本日,3:翌日,4:翌々日,5:日付指定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出開始日付（基準）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StExtraDateBaseCd
		{
			get { return _stExtraDateBaseCd; }
			set { _stExtraDateBaseCd = value; }
		}

		/// public propaty name  :  StExtraDateSignCd
		/// <summary>抽出開始日付（正負）プロパティ</summary>
		/// <value>0:＋（プラス）,1:－（マイナス）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出開始日付（正負）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StExtraDateSignCd
		{
			get { return _stExtraDateSignCd; }
			set { _stExtraDateSignCd = value; }
		}

		/// public propaty name  :  StExtraDateNum
		/// <summary>抽出開始日付（数値）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出開始日付（数値）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StExtraDateNum
		{
			get { return _stExtraDateNum; }
			set { _stExtraDateNum = value; }
		}

		/// public propaty name  :  StExtraDateUnitCd
		/// <summary>抽出開始日付（単位）プロパティ</summary>
		/// <value>0:日,1:週,2:月,3:年</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出開始日付（単位）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StExtraDateUnitCd
		{
			get { return _stExtraDateUnitCd; }
			set { _stExtraDateUnitCd = value; }
		}

		/// public propaty name  :  StartExtraDate
		/// <summary>抽出開始日付（日付）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出開始日付（日付）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartExtraDate
		{
			get { return _startExtraDate; }
			set { _startExtraDate = value; }
		}

		/// public propaty name  :  EdExtraDateBaseCd
		/// <summary>抽出終了日付（基準）プロパティ</summary>
		/// <value>0:前々日,1:前日,2:本日,3:翌日,4:翌々日,5:日付指定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出終了日付（基準）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdExtraDateBaseCd
		{
			get { return _edExtraDateBaseCd; }
			set { _edExtraDateBaseCd = value; }
		}

		/// public propaty name  :  EdExtraDateSignCd
		/// <summary>抽出終了日付（正負）プロパティ</summary>
		/// <value>0:＋（プラス）,1:－（マイナス）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出終了日付（正負）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdExtraDateSignCd
		{
			get { return _edExtraDateSignCd; }
			set { _edExtraDateSignCd = value; }
		}

		/// public propaty name  :  EdExtraDateNum
		/// <summary>抽出終了日付（数値）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出終了日付（数値）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdExtraDateNum
		{
			get { return _edExtraDateNum; }
			set { _edExtraDateNum = value; }
		}

		/// public propaty name  :  EdExtraDateUnitCd
		/// <summary>抽出終了日付（単位）プロパティ</summary>
		/// <value>0:日,1:週,2:月,3:年</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出終了日付（単位）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdExtraDateUnitCd
		{
			get { return _edExtraDateUnitCd; }
			set { _edExtraDateUnitCd = value; }
		}

		/// public propaty name  :  EndExtraDate
		/// <summary>抽出終了日付（日付）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出終了日付（日付）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EndExtraDate
		{
			get { return _endExtraDate; }
			set { _endExtraDate = value; }
		}

		/// public propaty name  :  ExtraCondDetailGrpCd
		/// <summary>抽出条件明細グループコードプロパティ</summary>
		/// <value>抽出条件区分がコンボボックス型の時に使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出条件明細グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ExtraCondDetailGrpCd
		{
			get { return _extraCondDetailGrpCd; }
			set { _extraCondDetailGrpCd = value; }
		}

		/// public propaty name  :  NecessaryExtraCondCd
		/// <summary>必須抽出条件区分プロパティ</summary>
		/// <value>0:任意,1:必須</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   必須抽出条件区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NecessaryExtraCondCd
		{
			get { return _necessaryExtraCondCd; }
			set { _necessaryExtraCondCd = value; }
		}

		/// public propaty name  :  CheckItemCode1
		/// <summary>チェック項目コード1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode1
		{
			get { return _checkItemCode1; }
			set { _checkItemCode1 = value; }
		}

		/// public propaty name  :  CheckItemCode2
		/// <summary>チェック項目コード2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode2
		{
			get { return _checkItemCode2; }
			set { _checkItemCode2 = value; }
		}

		/// public propaty name  :  CheckItemCode3
		/// <summary>チェック項目コード3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode3
		{
			get { return _checkItemCode3; }
			set { _checkItemCode3 = value; }
		}

		/// public propaty name  :  CheckItemCode4
		/// <summary>チェック項目コード4プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode4
		{
			get { return _checkItemCode4; }
			set { _checkItemCode4 = value; }
		}

		/// public propaty name  :  CheckItemCode5
		/// <summary>チェック項目コード5プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード5プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode5
		{
			get { return _checkItemCode5; }
			set { _checkItemCode5 = value; }
		}

		/// public propaty name  :  CheckItemCode6
		/// <summary>チェック項目コード6プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード6プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode6
		{
			get { return _checkItemCode6; }
			set { _checkItemCode6 = value; }
		}

		/// public propaty name  :  CheckItemCode7
		/// <summary>チェック項目コード7プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード7プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode7
		{
			get { return _checkItemCode7; }
			set { _checkItemCode7 = value; }
		}

		/// public propaty name  :  CheckItemCode8
		/// <summary>チェック項目コード8プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード8プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode8
		{
			get { return _checkItemCode8; }
			set { _checkItemCode8 = value; }
		}

		/// public propaty name  :  CheckItemCode9
		/// <summary>チェック項目コード9プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード9プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode9
		{
			get { return _checkItemCode9; }
			set { _checkItemCode9 = value; }
		}

		/// public propaty name  :  CheckItemCode10
		/// <summary>チェック項目コード10プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード10プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode10
		{
			get { return _checkItemCode10; }
			set { _checkItemCode10 = value; }
		}

		/// public propaty name  :  FileNm
		/// <summary>ファイル名称プロパティ</summary>
		/// <value>DBのテーブルID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ファイル名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FileNm
		{
			get { return _fileNm; }
			set { _fileNm = value; }
		}

		/// public propaty name  :  InputCharCnt
		/// <summary>入力桁数プロパティ</summary>
		/// <value>条件の入力制限で使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力桁数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InputCharCnt
		{
			get { return _inputCharCnt; }
			set { _inputCharCnt = value; }
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

		/// public propaty name  :  UpdEmployeeName
		/// <summary>更新従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get { return _updEmployeeName; }
			set { _updEmployeeName = value; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// 自由帳票抽出条件設定マスタコンストラクタ
		/// </summary>
		/// <returns>FrePprECndクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprECndクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePprECnd()
		{
		}

		/// <summary>
		/// 自由帳票抽出条件設定マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="outputFormFileName">出力ファイル名(フォームファイルID or フォーマットファイルID)</param>
		/// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番号</param>
		/// <param name="frePrtPprExtraCondCd">自由帳票抽出条件枝番</param>
		/// <param name="displayOrder">表示順位</param>
		/// <param name="extraConditionDivCd">抽出条件区分(0:使用不可,1:数値型,2:文字型（半角）,3:文字型（全角）,4:日付型,5:コンボ型,6:チェック型)</param>
		/// <param name="extraConditionTypeCd">抽出条件タイプ(0:一致,1:範囲,2:あいまい,3:期間)</param>
		/// <param name="extraConditionTitle">抽出条件タイトル</param>
		/// <param name="dDCharCnt">DD桁数</param>
		/// <param name="dDName">DD名称(小文字で登録)</param>
		/// <param name="stExtraNumCode">抽出開始コード（数値）</param>
		/// <param name="edExtraNumCode">抽出終了コード（数値）</param>
		/// <param name="stExtraCharCode">抽出開始コード（文字）</param>
		/// <param name="edExtraCharCode">抽出終了コード（文字）</param>
		/// <param name="stExtraDateBaseCd">抽出開始日付（基準）(0:前々日,1:前日,2:本日,3:翌日,4:翌々日,5:日付指定)</param>
		/// <param name="stExtraDateSignCd">抽出開始日付（正負）(0:＋（プラス）,1:－（マイナス）)</param>
		/// <param name="stExtraDateNum">抽出開始日付（数値）</param>
		/// <param name="stExtraDateUnitCd">抽出開始日付（単位）(0:日,1:週,2:月,3:年)</param>
		/// <param name="startExtraDate">抽出開始日付（日付）</param>
		/// <param name="edExtraDateBaseCd">抽出終了日付（基準）(0:前々日,1:前日,2:本日,3:翌日,4:翌々日,5:日付指定)</param>
		/// <param name="edExtraDateSignCd">抽出終了日付（正負）(0:＋（プラス）,1:－（マイナス）)</param>
		/// <param name="edExtraDateNum">抽出終了日付（数値）</param>
		/// <param name="edExtraDateUnitCd">抽出終了日付（単位）(0:日,1:週,2:月,3:年)</param>
		/// <param name="endExtraDate">抽出終了日付（日付）</param>
		/// <param name="extraCondDetailGrpCd">抽出条件明細グループコード(抽出条件区分がコンボボックス型の時に使用)</param>
		/// <param name="necessaryExtraCondCd">必須抽出条件区分(0:任意,1:必須)</param>
		/// <param name="checkItemCode1">チェック項目コード1</param>
		/// <param name="checkItemCode2">チェック項目コード2</param>
		/// <param name="checkItemCode3">チェック項目コード3</param>
		/// <param name="checkItemCode4">チェック項目コード4</param>
		/// <param name="checkItemCode5">チェック項目コード5</param>
		/// <param name="checkItemCode6">チェック項目コード6</param>
		/// <param name="checkItemCode7">チェック項目コード7</param>
		/// <param name="checkItemCode8">チェック項目コード8</param>
		/// <param name="checkItemCode9">チェック項目コード9</param>
		/// <param name="checkItemCode10">チェック項目コード10</param>
		/// <param name="fileNm">ファイル名称(DBのテーブルID)</param>
		/// <param name="inputCharCnt">入力桁数(条件の入力制限で使用)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>FrePprECndクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprECndクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePprECnd(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string outputFormFileName, Int32 userPrtPprIdDerivNo, Int32 frePrtPprExtraCondCd, Int32 displayOrder, Int32 extraConditionDivCd, Int32 extraConditionTypeCd, string extraConditionTitle, Int32 dDCharCnt, string dDName, Int64 stExtraNumCode, Int64 edExtraNumCode, string stExtraCharCode, string edExtraCharCode, Int32 stExtraDateBaseCd, Int32 stExtraDateSignCd, Int32 stExtraDateNum, Int32 stExtraDateUnitCd, Int32 startExtraDate, Int32 edExtraDateBaseCd, Int32 edExtraDateSignCd, Int32 edExtraDateNum, Int32 edExtraDateUnitCd, Int32 endExtraDate, Int32 extraCondDetailGrpCd, Int32 necessaryExtraCondCd, Int32 checkItemCode1, Int32 checkItemCode2, Int32 checkItemCode3, Int32 checkItemCode4, Int32 checkItemCode5, Int32 checkItemCode6, Int32 checkItemCode7, Int32 checkItemCode8, Int32 checkItemCode9, Int32 checkItemCode10, string fileNm, Int32 inputCharCnt, string enterpriseName, string updEmployeeName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._outputFormFileName = outputFormFileName;
			this._userPrtPprIdDerivNo = userPrtPprIdDerivNo;
			this._frePrtPprExtraCondCd = frePrtPprExtraCondCd;
			this._displayOrder = displayOrder;
			this._extraConditionDivCd = extraConditionDivCd;
			this._extraConditionTypeCd = extraConditionTypeCd;
			this._extraConditionTitle = extraConditionTitle;
			this._dDCharCnt = dDCharCnt;
			this._dDName = dDName;
			this._stExtraNumCode = stExtraNumCode;
			this._edExtraNumCode = edExtraNumCode;
			this._stExtraCharCode = stExtraCharCode;
			this._edExtraCharCode = edExtraCharCode;
			this._stExtraDateBaseCd = stExtraDateBaseCd;
			this._stExtraDateSignCd = stExtraDateSignCd;
			this._stExtraDateNum = stExtraDateNum;
			this._stExtraDateUnitCd = stExtraDateUnitCd;
			this._startExtraDate = startExtraDate;
			this._edExtraDateBaseCd = edExtraDateBaseCd;
			this._edExtraDateSignCd = edExtraDateSignCd;
			this._edExtraDateNum = edExtraDateNum;
			this._edExtraDateUnitCd = edExtraDateUnitCd;
			this._endExtraDate = endExtraDate;
			this._extraCondDetailGrpCd = extraCondDetailGrpCd;
			this._necessaryExtraCondCd = necessaryExtraCondCd;
			this._checkItemCode1 = checkItemCode1;
			this._checkItemCode2 = checkItemCode2;
			this._checkItemCode3 = checkItemCode3;
			this._checkItemCode4 = checkItemCode4;
			this._checkItemCode5 = checkItemCode5;
			this._checkItemCode6 = checkItemCode6;
			this._checkItemCode7 = checkItemCode7;
			this._checkItemCode8 = checkItemCode8;
			this._checkItemCode9 = checkItemCode9;
			this._checkItemCode10 = checkItemCode10;
			this._fileNm = fileNm;
			this._inputCharCnt = inputCharCnt;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}
		#endregion

		#region AutoGenerate PublicMethod
		/// <summary>
		/// 自由帳票抽出条件設定マスタ複製処理
		/// </summary>
		/// <returns>FrePprECndクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいFrePprECndクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePprECnd Clone()
		{
			return new FrePprECnd(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._outputFormFileName, this._userPrtPprIdDerivNo, this._frePrtPprExtraCondCd, this._displayOrder, this._extraConditionDivCd, this._extraConditionTypeCd, this._extraConditionTitle, this._dDCharCnt, this._dDName, this._stExtraNumCode, this._edExtraNumCode, this._stExtraCharCode, this._edExtraCharCode, this._stExtraDateBaseCd, this._stExtraDateSignCd, this._stExtraDateNum, this._stExtraDateUnitCd, this._startExtraDate, this._edExtraDateBaseCd, this._edExtraDateSignCd, this._edExtraDateNum, this._edExtraDateUnitCd, this._endExtraDate, this._extraCondDetailGrpCd, this._necessaryExtraCondCd, this._checkItemCode1, this._checkItemCode2, this._checkItemCode3, this._checkItemCode4, this._checkItemCode5, this._checkItemCode6, this._checkItemCode7, this._checkItemCode8, this._checkItemCode9, this._checkItemCode10, this._fileNm, this._inputCharCnt, this._enterpriseName, this._updEmployeeName);
		}

		/// <summary>
		/// 自由帳票抽出条件設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のFrePprECndクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprECndクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(FrePprECnd target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.OutputFormFileName == target.OutputFormFileName)
				 && (this.UserPrtPprIdDerivNo == target.UserPrtPprIdDerivNo)
				 && (this.FrePrtPprExtraCondCd == target.FrePrtPprExtraCondCd)
				 && (this.DisplayOrder == target.DisplayOrder)
				 && (this.ExtraConditionDivCd == target.ExtraConditionDivCd)
				 && (this.ExtraConditionTypeCd == target.ExtraConditionTypeCd)
				 && (this.ExtraConditionTitle == target.ExtraConditionTitle)
				 && (this.DDCharCnt == target.DDCharCnt)
				 && (this.DDName == target.DDName)
				 && (this.StExtraNumCode == target.StExtraNumCode)
				 && (this.EdExtraNumCode == target.EdExtraNumCode)
				 && (this.StExtraCharCode == target.StExtraCharCode)
				 && (this.EdExtraCharCode == target.EdExtraCharCode)
				 && (this.StExtraDateBaseCd == target.StExtraDateBaseCd)
				 && (this.StExtraDateSignCd == target.StExtraDateSignCd)
				 && (this.StExtraDateNum == target.StExtraDateNum)
				 && (this.StExtraDateUnitCd == target.StExtraDateUnitCd)
				 && (this.StartExtraDate == target.StartExtraDate)
				 && (this.EdExtraDateBaseCd == target.EdExtraDateBaseCd)
				 && (this.EdExtraDateSignCd == target.EdExtraDateSignCd)
				 && (this.EdExtraDateNum == target.EdExtraDateNum)
				 && (this.EdExtraDateUnitCd == target.EdExtraDateUnitCd)
				 && (this.EndExtraDate == target.EndExtraDate)
				 && (this.ExtraCondDetailGrpCd == target.ExtraCondDetailGrpCd)
				 && (this.NecessaryExtraCondCd == target.NecessaryExtraCondCd)
				 && (this.CheckItemCode1 == target.CheckItemCode1)
				 && (this.CheckItemCode2 == target.CheckItemCode2)
				 && (this.CheckItemCode3 == target.CheckItemCode3)
				 && (this.CheckItemCode4 == target.CheckItemCode4)
				 && (this.CheckItemCode5 == target.CheckItemCode5)
				 && (this.CheckItemCode6 == target.CheckItemCode6)
				 && (this.CheckItemCode7 == target.CheckItemCode7)
				 && (this.CheckItemCode8 == target.CheckItemCode8)
				 && (this.CheckItemCode9 == target.CheckItemCode9)
				 && (this.CheckItemCode10 == target.CheckItemCode10)
				 && (this.FileNm == target.FileNm)
				 && (this.InputCharCnt == target.InputCharCnt)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// 自由帳票抽出条件設定マスタ比較処理
		/// </summary>
		/// <param name="frePprECnd1">
		///                    比較するFrePprECndクラスのインスタンス
		/// </param>
		/// <param name="frePprECnd2">比較するFrePprECndクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprECndクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(FrePprECnd frePprECnd1, FrePprECnd frePprECnd2)
		{
			return ((frePprECnd1.CreateDateTime == frePprECnd2.CreateDateTime)
				 && (frePprECnd1.UpdateDateTime == frePprECnd2.UpdateDateTime)
				 && (frePprECnd1.EnterpriseCode == frePprECnd2.EnterpriseCode)
				 && (frePprECnd1.FileHeaderGuid == frePprECnd2.FileHeaderGuid)
				 && (frePprECnd1.UpdEmployeeCode == frePprECnd2.UpdEmployeeCode)
				 && (frePprECnd1.UpdAssemblyId1 == frePprECnd2.UpdAssemblyId1)
				 && (frePprECnd1.UpdAssemblyId2 == frePprECnd2.UpdAssemblyId2)
				 && (frePprECnd1.LogicalDeleteCode == frePprECnd2.LogicalDeleteCode)
				 && (frePprECnd1.OutputFormFileName == frePprECnd2.OutputFormFileName)
				 && (frePprECnd1.UserPrtPprIdDerivNo == frePprECnd2.UserPrtPprIdDerivNo)
				 && (frePprECnd1.FrePrtPprExtraCondCd == frePprECnd2.FrePrtPprExtraCondCd)
				 && (frePprECnd1.DisplayOrder == frePprECnd2.DisplayOrder)
				 && (frePprECnd1.ExtraConditionDivCd == frePprECnd2.ExtraConditionDivCd)
				 && (frePprECnd1.ExtraConditionTypeCd == frePprECnd2.ExtraConditionTypeCd)
				 && (frePprECnd1.ExtraConditionTitle == frePprECnd2.ExtraConditionTitle)
				 && (frePprECnd1.DDCharCnt == frePprECnd2.DDCharCnt)
				 && (frePprECnd1.DDName == frePprECnd2.DDName)
				 && (frePprECnd1.StExtraNumCode == frePprECnd2.StExtraNumCode)
				 && (frePprECnd1.EdExtraNumCode == frePprECnd2.EdExtraNumCode)
				 && (frePprECnd1.StExtraCharCode == frePprECnd2.StExtraCharCode)
				 && (frePprECnd1.EdExtraCharCode == frePprECnd2.EdExtraCharCode)
				 && (frePprECnd1.StExtraDateBaseCd == frePprECnd2.StExtraDateBaseCd)
				 && (frePprECnd1.StExtraDateSignCd == frePprECnd2.StExtraDateSignCd)
				 && (frePprECnd1.StExtraDateNum == frePprECnd2.StExtraDateNum)
				 && (frePprECnd1.StExtraDateUnitCd == frePprECnd2.StExtraDateUnitCd)
				 && (frePprECnd1.StartExtraDate == frePprECnd2.StartExtraDate)
				 && (frePprECnd1.EdExtraDateBaseCd == frePprECnd2.EdExtraDateBaseCd)
				 && (frePprECnd1.EdExtraDateSignCd == frePprECnd2.EdExtraDateSignCd)
				 && (frePprECnd1.EdExtraDateNum == frePprECnd2.EdExtraDateNum)
				 && (frePprECnd1.EdExtraDateUnitCd == frePprECnd2.EdExtraDateUnitCd)
				 && (frePprECnd1.EndExtraDate == frePprECnd2.EndExtraDate)
				 && (frePprECnd1.ExtraCondDetailGrpCd == frePprECnd2.ExtraCondDetailGrpCd)
				 && (frePprECnd1.NecessaryExtraCondCd == frePprECnd2.NecessaryExtraCondCd)
				 && (frePprECnd1.CheckItemCode1 == frePprECnd2.CheckItemCode1)
				 && (frePprECnd1.CheckItemCode2 == frePprECnd2.CheckItemCode2)
				 && (frePprECnd1.CheckItemCode3 == frePprECnd2.CheckItemCode3)
				 && (frePprECnd1.CheckItemCode4 == frePprECnd2.CheckItemCode4)
				 && (frePprECnd1.CheckItemCode5 == frePprECnd2.CheckItemCode5)
				 && (frePprECnd1.CheckItemCode6 == frePprECnd2.CheckItemCode6)
				 && (frePprECnd1.CheckItemCode7 == frePprECnd2.CheckItemCode7)
				 && (frePprECnd1.CheckItemCode8 == frePprECnd2.CheckItemCode8)
				 && (frePprECnd1.CheckItemCode9 == frePprECnd2.CheckItemCode9)
				 && (frePprECnd1.CheckItemCode10 == frePprECnd2.CheckItemCode10)
				 && (frePprECnd1.FileNm == frePprECnd2.FileNm)
				 && (frePprECnd1.InputCharCnt == frePprECnd2.InputCharCnt)
				 && (frePprECnd1.EnterpriseName == frePprECnd2.EnterpriseName)
				 && (frePprECnd1.UpdEmployeeName == frePprECnd2.UpdEmployeeName));
		}
		/// <summary>
		/// 自由帳票抽出条件設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のFrePprECndクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprECndクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(FrePprECnd target)
		{
			ArrayList resList = new ArrayList();
			if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
			if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
			if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
			if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
			if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
			if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
			if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
			if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (this.OutputFormFileName != target.OutputFormFileName) resList.Add("OutputFormFileName");
			if (this.UserPrtPprIdDerivNo != target.UserPrtPprIdDerivNo) resList.Add("UserPrtPprIdDerivNo");
			if (this.FrePrtPprExtraCondCd != target.FrePrtPprExtraCondCd) resList.Add("FrePrtPprExtraCondCd");
			if (this.DisplayOrder != target.DisplayOrder) resList.Add("DisplayOrder");
			if (this.ExtraConditionDivCd != target.ExtraConditionDivCd) resList.Add("ExtraConditionDivCd");
			if (this.ExtraConditionTypeCd != target.ExtraConditionTypeCd) resList.Add("ExtraConditionTypeCd");
			if (this.ExtraConditionTitle != target.ExtraConditionTitle) resList.Add("ExtraConditionTitle");
			if (this.DDCharCnt != target.DDCharCnt) resList.Add("DDCharCnt");
			if (this.DDName != target.DDName) resList.Add("DDName");
			if (this.StExtraNumCode != target.StExtraNumCode) resList.Add("StExtraNumCode");
			if (this.EdExtraNumCode != target.EdExtraNumCode) resList.Add("EdExtraNumCode");
			if (this.StExtraCharCode != target.StExtraCharCode) resList.Add("StExtraCharCode");
			if (this.EdExtraCharCode != target.EdExtraCharCode) resList.Add("EdExtraCharCode");
			if (this.StExtraDateBaseCd != target.StExtraDateBaseCd) resList.Add("StExtraDateBaseCd");
			if (this.StExtraDateSignCd != target.StExtraDateSignCd) resList.Add("StExtraDateSignCd");
			if (this.StExtraDateNum != target.StExtraDateNum) resList.Add("StExtraDateNum");
			if (this.StExtraDateUnitCd != target.StExtraDateUnitCd) resList.Add("StExtraDateUnitCd");
			if (this.StartExtraDate != target.StartExtraDate) resList.Add("StartExtraDate");
			if (this.EdExtraDateBaseCd != target.EdExtraDateBaseCd) resList.Add("EdExtraDateBaseCd");
			if (this.EdExtraDateSignCd != target.EdExtraDateSignCd) resList.Add("EdExtraDateSignCd");
			if (this.EdExtraDateNum != target.EdExtraDateNum) resList.Add("EdExtraDateNum");
			if (this.EdExtraDateUnitCd != target.EdExtraDateUnitCd) resList.Add("EdExtraDateUnitCd");
			if (this.EndExtraDate != target.EndExtraDate) resList.Add("EndExtraDate");
			if (this.ExtraCondDetailGrpCd != target.ExtraCondDetailGrpCd) resList.Add("ExtraCondDetailGrpCd");
			if (this.NecessaryExtraCondCd != target.NecessaryExtraCondCd) resList.Add("NecessaryExtraCondCd");
			if (this.CheckItemCode1 != target.CheckItemCode1) resList.Add("CheckItemCode1");
			if (this.CheckItemCode2 != target.CheckItemCode2) resList.Add("CheckItemCode2");
			if (this.CheckItemCode3 != target.CheckItemCode3) resList.Add("CheckItemCode3");
			if (this.CheckItemCode4 != target.CheckItemCode4) resList.Add("CheckItemCode4");
			if (this.CheckItemCode5 != target.CheckItemCode5) resList.Add("CheckItemCode5");
			if (this.CheckItemCode6 != target.CheckItemCode6) resList.Add("CheckItemCode6");
			if (this.CheckItemCode7 != target.CheckItemCode7) resList.Add("CheckItemCode7");
			if (this.CheckItemCode8 != target.CheckItemCode8) resList.Add("CheckItemCode8");
			if (this.CheckItemCode9 != target.CheckItemCode9) resList.Add("CheckItemCode9");
			if (this.CheckItemCode10 != target.CheckItemCode10) resList.Add("CheckItemCode10");
			if (this.FileNm != target.FileNm) resList.Add("FileNm");
			if (this.InputCharCnt != target.InputCharCnt) resList.Add("InputCharCnt");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
			if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// 自由帳票抽出条件設定マスタ比較処理
		/// </summary>
		/// <param name="frePprECnd1">比較するFrePprECndクラスのインスタンス</param>
		/// <param name="frePprECnd2">比較するFrePprECndクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprECndクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(FrePprECnd frePprECnd1, FrePprECnd frePprECnd2)
		{
			ArrayList resList = new ArrayList();
			if (frePprECnd1.CreateDateTime != frePprECnd2.CreateDateTime) resList.Add("CreateDateTime");
			if (frePprECnd1.UpdateDateTime != frePprECnd2.UpdateDateTime) resList.Add("UpdateDateTime");
			if (frePprECnd1.EnterpriseCode != frePprECnd2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (frePprECnd1.FileHeaderGuid != frePprECnd2.FileHeaderGuid) resList.Add("FileHeaderGuid");
			if (frePprECnd1.UpdEmployeeCode != frePprECnd2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
			if (frePprECnd1.UpdAssemblyId1 != frePprECnd2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
			if (frePprECnd1.UpdAssemblyId2 != frePprECnd2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
			if (frePprECnd1.LogicalDeleteCode != frePprECnd2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (frePprECnd1.OutputFormFileName != frePprECnd2.OutputFormFileName) resList.Add("OutputFormFileName");
			if (frePprECnd1.UserPrtPprIdDerivNo != frePprECnd2.UserPrtPprIdDerivNo) resList.Add("UserPrtPprIdDerivNo");
			if (frePprECnd1.FrePrtPprExtraCondCd != frePprECnd2.FrePrtPprExtraCondCd) resList.Add("FrePrtPprExtraCondCd");
			if (frePprECnd1.DisplayOrder != frePprECnd2.DisplayOrder) resList.Add("DisplayOrder");
			if (frePprECnd1.ExtraConditionDivCd != frePprECnd2.ExtraConditionDivCd) resList.Add("ExtraConditionDivCd");
			if (frePprECnd1.ExtraConditionTypeCd != frePprECnd2.ExtraConditionTypeCd) resList.Add("ExtraConditionTypeCd");
			if (frePprECnd1.ExtraConditionTitle != frePprECnd2.ExtraConditionTitle) resList.Add("ExtraConditionTitle");
			if (frePprECnd1.DDCharCnt != frePprECnd2.DDCharCnt) resList.Add("DDCharCnt");
			if (frePprECnd1.DDName != frePprECnd2.DDName) resList.Add("DDName");
			if (frePprECnd1.StExtraNumCode != frePprECnd2.StExtraNumCode) resList.Add("StExtraNumCode");
			if (frePprECnd1.EdExtraNumCode != frePprECnd2.EdExtraNumCode) resList.Add("EdExtraNumCode");
			if (frePprECnd1.StExtraCharCode != frePprECnd2.StExtraCharCode) resList.Add("StExtraCharCode");
			if (frePprECnd1.EdExtraCharCode != frePprECnd2.EdExtraCharCode) resList.Add("EdExtraCharCode");
			if (frePprECnd1.StExtraDateBaseCd != frePprECnd2.StExtraDateBaseCd) resList.Add("StExtraDateBaseCd");
			if (frePprECnd1.StExtraDateSignCd != frePprECnd2.StExtraDateSignCd) resList.Add("StExtraDateSignCd");
			if (frePprECnd1.StExtraDateNum != frePprECnd2.StExtraDateNum) resList.Add("StExtraDateNum");
			if (frePprECnd1.StExtraDateUnitCd != frePprECnd2.StExtraDateUnitCd) resList.Add("StExtraDateUnitCd");
			if (frePprECnd1.StartExtraDate != frePprECnd2.StartExtraDate) resList.Add("StartExtraDate");
			if (frePprECnd1.EdExtraDateBaseCd != frePprECnd2.EdExtraDateBaseCd) resList.Add("EdExtraDateBaseCd");
			if (frePprECnd1.EdExtraDateSignCd != frePprECnd2.EdExtraDateSignCd) resList.Add("EdExtraDateSignCd");
			if (frePprECnd1.EdExtraDateNum != frePprECnd2.EdExtraDateNum) resList.Add("EdExtraDateNum");
			if (frePprECnd1.EdExtraDateUnitCd != frePprECnd2.EdExtraDateUnitCd) resList.Add("EdExtraDateUnitCd");
			if (frePprECnd1.EndExtraDate != frePprECnd2.EndExtraDate) resList.Add("EndExtraDate");
			if (frePprECnd1.ExtraCondDetailGrpCd != frePprECnd2.ExtraCondDetailGrpCd) resList.Add("ExtraCondDetailGrpCd");
			if (frePprECnd1.NecessaryExtraCondCd != frePprECnd2.NecessaryExtraCondCd) resList.Add("NecessaryExtraCondCd");
			if (frePprECnd1.CheckItemCode1 != frePprECnd2.CheckItemCode1) resList.Add("CheckItemCode1");
			if (frePprECnd1.CheckItemCode2 != frePprECnd2.CheckItemCode2) resList.Add("CheckItemCode2");
			if (frePprECnd1.CheckItemCode3 != frePprECnd2.CheckItemCode3) resList.Add("CheckItemCode3");
			if (frePprECnd1.CheckItemCode4 != frePprECnd2.CheckItemCode4) resList.Add("CheckItemCode4");
			if (frePprECnd1.CheckItemCode5 != frePprECnd2.CheckItemCode5) resList.Add("CheckItemCode5");
			if (frePprECnd1.CheckItemCode6 != frePprECnd2.CheckItemCode6) resList.Add("CheckItemCode6");
			if (frePprECnd1.CheckItemCode7 != frePprECnd2.CheckItemCode7) resList.Add("CheckItemCode7");
			if (frePprECnd1.CheckItemCode8 != frePprECnd2.CheckItemCode8) resList.Add("CheckItemCode8");
			if (frePprECnd1.CheckItemCode9 != frePprECnd2.CheckItemCode9) resList.Add("CheckItemCode9");
			if (frePprECnd1.CheckItemCode10 != frePprECnd2.CheckItemCode10) resList.Add("CheckItemCode10");
			if (frePprECnd1.FileNm != frePprECnd2.FileNm) resList.Add("FileNm");
			if (frePprECnd1.InputCharCnt != frePprECnd2.InputCharCnt) resList.Add("InputCharCnt");
			if (frePprECnd1.EnterpriseName != frePprECnd2.EnterpriseName) resList.Add("EnterpriseName");
			if (frePprECnd1.UpdEmployeeName != frePprECnd2.UpdEmployeeName) resList.Add("UpdEmployeeName");

			return resList;
		}
		#endregion

		#region Property
		/// public propaty name  :  UsedFlg
		/// <summary>使用区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   使用区分プロパティ</br>
		/// <br>Programer        :   2007/04/03 22024 寺坂誉志</br>
		/// </remarks>
		public Int32 UsedFlg
		{
			get {
				if (_displayOrder <= 0 || _displayOrder >= 999)
					return 0;
				else
					return 1;
			}
			// Serialize時に名前解決失敗の原因となる為
			// setアクセサも用意
			set { }
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// 自由帳票抽出条件設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のFrePprECndクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note			:   FrePprECndクラスの内容が一致するか比較します</br>
		/// <br>Programer		:   2007/04/03 22024 寺坂誉志</br>
		/// </remarks>
		public bool EqualsWithoutSystemDate(FrePprECnd target)
		{
			bool isEqual;

			// 日付型の場合
			if (this.ExtraConditionDivCd == 4)
			{
				isEqual = ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.OutputFormFileName == target.OutputFormFileName)
				 && (this.UserPrtPprIdDerivNo == target.UserPrtPprIdDerivNo)
				 && (this.FrePrtPprExtraCondCd == target.FrePrtPprExtraCondCd)
				 && (this.DisplayOrder == target.DisplayOrder)
				 && (this.ExtraConditionDivCd == target.ExtraConditionDivCd)
				 && (this.ExtraConditionTypeCd == target.ExtraConditionTypeCd)
				 && (this.ExtraConditionTitle == target.ExtraConditionTitle)
				 && (this.DDCharCnt == target.DDCharCnt)
				 && (this.DDName == target.DDName)
				 && (this.StExtraNumCode == target.StExtraNumCode)
				 && (this.EdExtraNumCode == target.EdExtraNumCode)
				 && (this.StExtraCharCode == target.StExtraCharCode)
				 && (this.EdExtraCharCode == target.EdExtraCharCode)
				 && (this.StExtraDateBaseCd == target.StExtraDateBaseCd)
				 && (this.StExtraDateSignCd == target.StExtraDateSignCd)
				 && (this.StExtraDateNum == target.StExtraDateNum)
				 && (this.StExtraDateUnitCd == target.StExtraDateUnitCd)
				 && (this.EdExtraDateBaseCd == target.EdExtraDateBaseCd)
				 && (this.EdExtraDateSignCd == target.EdExtraDateSignCd)
				 && (this.EdExtraDateNum == target.EdExtraDateNum)
				 && (this.EdExtraDateUnitCd == target.EdExtraDateUnitCd)
				 && (this.ExtraCondDetailGrpCd == target.ExtraCondDetailGrpCd)
				 && (this.NecessaryExtraCondCd == target.NecessaryExtraCondCd)
				 && (this.CheckItemCode1 == target.CheckItemCode1)
				 && (this.CheckItemCode2 == target.CheckItemCode2)
				 && (this.CheckItemCode3 == target.CheckItemCode3)
				 && (this.CheckItemCode4 == target.CheckItemCode4)
				 && (this.CheckItemCode5 == target.CheckItemCode5)
				 && (this.CheckItemCode6 == target.CheckItemCode6)
				 && (this.CheckItemCode7 == target.CheckItemCode7)
				 && (this.CheckItemCode8 == target.CheckItemCode8)
				 && (this.CheckItemCode9 == target.CheckItemCode9)
				 && (this.CheckItemCode10 == target.CheckItemCode10)
				 && (this.FileNm == target.FileNm)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.UsedFlg == target.UsedFlg)
				 );

				if (isEqual)
				{
					switch (this.ExtraConditionTypeCd)
					{
						case 0:	// 一致
						{
							if (this.StExtraNumCode == 0)
								isEqual = this.StartExtraDate.Equals(target.StartExtraDate);
							break;
						}
						case 1:	// 範囲
						{
							if (this.StExtraNumCode == 0)
								isEqual = this.StartExtraDate.Equals(target.StartExtraDate);
							if (isEqual && this.EdExtraNumCode == 0)
								isEqual = this.EndExtraDate.Equals(target.EndExtraDate);
							break;
						}
						case 3:	// 開始日基準
						{
							if (this.StExtraDateBaseCd == 5)	// 日付指定
								isEqual = this.StartExtraDate.Equals(target.StartExtraDate);
							break;
						}
						case 4:	// 終了日基準
						{
							if (this.EdExtraDateBaseCd == 5)	// 日付指定
								isEqual = this.EndExtraDate.Equals(target.EndExtraDate);
							break;
						}
					}
				}
			}
			else
			{
				isEqual = this.Equals(target);
			}

			return isEqual;
		}
		#endregion
	}
}
