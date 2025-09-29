using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   FrePprECndWork
	/// <summary>
	///                      自由帳票抽出条件設定ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   自由帳票抽出条件設定ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/03/15</br>
	/// <br>Genarated Date   :   2007/07/19  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class FrePprECndWork : IFileHeader
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
		/// <remarks>0:一致,1:範囲,2:あいまい,3:期間（開始日基準）,4:期間（終了日基準）,5:月一致,6:月範囲</remarks>
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
		private Int32 _checkItemCode1;

		/// <summary>チェック項目コード2</summary>
		private Int32 _checkItemCode2;

		/// <summary>チェック項目コード3</summary>
		private Int32 _checkItemCode3;

		/// <summary>チェック項目コード4</summary>
		private Int32 _checkItemCode4;

		/// <summary>チェック項目コード5</summary>
		private Int32 _checkItemCode5;

		/// <summary>チェック項目コード6</summary>
		private Int32 _checkItemCode6;

		/// <summary>チェック項目コード7</summary>
		private Int32 _checkItemCode7;

		/// <summary>チェック項目コード8</summary>
		private Int32 _checkItemCode8;

		/// <summary>チェック項目コード9</summary>
		private Int32 _checkItemCode9;

		/// <summary>チェック項目コード10</summary>
		private Int32 _checkItemCode10;

		/// <summary>ファイル名称</summary>
		/// <remarks>DBのテーブルID</remarks>
		private string _fileNm = "";

		/// <summary>入力桁数</summary>
		/// <remarks>条件の入力制限で使用</remarks>
		private Int32 _inputCharCnt;


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
		/// <value>0:一致,1:範囲,2:あいまい,3:期間（開始日基準）,4:期間（終了日基準）,5:月一致,6:月範囲</value>
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


		/// <summary>
		/// 自由帳票抽出条件設定ワークコンストラクタ
		/// </summary>
		/// <returns>FrePprECndWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprECndWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePprECndWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>FrePprECndWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   FrePprECndWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class FrePprECndWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprECndWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  FrePprECndWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is FrePprECndWork || graph is ArrayList || graph is FrePprECndWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(FrePprECndWork).FullName));

			if (graph != null && graph is FrePprECndWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FrePprECndWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is FrePprECndWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((FrePprECndWork[])graph).Length;
			}
			else if (graph is FrePprECndWork)
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
			//出力ファイル名
			serInfo.MemberInfo.Add(typeof(string)); //OutputFormFileName
			//ユーザー帳票ID枝番号
			serInfo.MemberInfo.Add(typeof(Int32)); //UserPrtPprIdDerivNo
			//自由帳票抽出条件枝番
			serInfo.MemberInfo.Add(typeof(Int32)); //FrePrtPprExtraCondCd
			//表示順位
			serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
			//抽出条件区分
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraConditionDivCd
			//抽出条件タイプ
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraConditionTypeCd
			//抽出条件タイトル
			serInfo.MemberInfo.Add(typeof(string)); //ExtraConditionTitle
			//DD桁数
			serInfo.MemberInfo.Add(typeof(Int32)); //DDCharCnt
			//DD名称
			serInfo.MemberInfo.Add(typeof(string)); //DDName
			//抽出開始コード（数値）
			serInfo.MemberInfo.Add(typeof(Int64)); //StExtraNumCode
			//抽出終了コード（数値）
			serInfo.MemberInfo.Add(typeof(Int64)); //EdExtraNumCode
			//抽出開始コード（文字）
			serInfo.MemberInfo.Add(typeof(string)); //StExtraCharCode
			//抽出終了コード（文字）
			serInfo.MemberInfo.Add(typeof(string)); //EdExtraCharCode
			//抽出開始日付（基準）
			serInfo.MemberInfo.Add(typeof(Int32)); //StExtraDateBaseCd
			//抽出開始日付（正負）
			serInfo.MemberInfo.Add(typeof(Int32)); //StExtraDateSignCd
			//抽出開始日付（数値）
			serInfo.MemberInfo.Add(typeof(Int32)); //StExtraDateNum
			//抽出開始日付（単位）
			serInfo.MemberInfo.Add(typeof(Int32)); //StExtraDateUnitCd
			//抽出開始日付（日付）
			serInfo.MemberInfo.Add(typeof(Int32)); //StartExtraDate
			//抽出終了日付（基準）
			serInfo.MemberInfo.Add(typeof(Int32)); //EdExtraDateBaseCd
			//抽出終了日付（正負）
			serInfo.MemberInfo.Add(typeof(Int32)); //EdExtraDateSignCd
			//抽出終了日付（数値）
			serInfo.MemberInfo.Add(typeof(Int32)); //EdExtraDateNum
			//抽出終了日付（単位）
			serInfo.MemberInfo.Add(typeof(Int32)); //EdExtraDateUnitCd
			//抽出終了日付（日付）
			serInfo.MemberInfo.Add(typeof(Int32)); //EndExtraDate
			//抽出条件明細グループコード
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraCondDetailGrpCd
			//必須抽出条件区分
			serInfo.MemberInfo.Add(typeof(Int32)); //NecessaryExtraCondCd
			//チェック項目コード1
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode1
			//チェック項目コード2
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode2
			//チェック項目コード3
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode3
			//チェック項目コード4
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode4
			//チェック項目コード5
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode5
			//チェック項目コード6
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode6
			//チェック項目コード7
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode7
			//チェック項目コード8
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode8
			//チェック項目コード9
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode9
			//チェック項目コード10
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode10
			//ファイル名称
			serInfo.MemberInfo.Add(typeof(string)); //FileNm
			//入力桁数
			serInfo.MemberInfo.Add(typeof(Int32)); //InputCharCnt


			serInfo.Serialize(writer, serInfo);
			if (graph is FrePprECndWork)
			{
				FrePprECndWork temp = (FrePprECndWork)graph;

				SetFrePprECndWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is FrePprECndWork[])
				{
					lst = new ArrayList();
					lst.AddRange((FrePprECndWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (FrePprECndWork temp in lst)
				{
					SetFrePprECndWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// FrePprECndWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 45;

		/// <summary>
		///  FrePprECndWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprECndWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetFrePprECndWork(System.IO.BinaryWriter writer, FrePprECndWork temp)
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
			//出力ファイル名
			writer.Write(temp.OutputFormFileName);
			//ユーザー帳票ID枝番号
			writer.Write(temp.UserPrtPprIdDerivNo);
			//自由帳票抽出条件枝番
			writer.Write(temp.FrePrtPprExtraCondCd);
			//表示順位
			writer.Write(temp.DisplayOrder);
			//抽出条件区分
			writer.Write(temp.ExtraConditionDivCd);
			//抽出条件タイプ
			writer.Write(temp.ExtraConditionTypeCd);
			//抽出条件タイトル
			writer.Write(temp.ExtraConditionTitle);
			//DD桁数
			writer.Write(temp.DDCharCnt);
			//DD名称
			writer.Write(temp.DDName);
			//抽出開始コード（数値）
			writer.Write(temp.StExtraNumCode);
			//抽出終了コード（数値）
			writer.Write(temp.EdExtraNumCode);
			//抽出開始コード（文字）
			writer.Write(temp.StExtraCharCode);
			//抽出終了コード（文字）
			writer.Write(temp.EdExtraCharCode);
			//抽出開始日付（基準）
			writer.Write(temp.StExtraDateBaseCd);
			//抽出開始日付（正負）
			writer.Write(temp.StExtraDateSignCd);
			//抽出開始日付（数値）
			writer.Write(temp.StExtraDateNum);
			//抽出開始日付（単位）
			writer.Write(temp.StExtraDateUnitCd);
			//抽出開始日付（日付）
			writer.Write(temp.StartExtraDate);
			//抽出終了日付（基準）
			writer.Write(temp.EdExtraDateBaseCd);
			//抽出終了日付（正負）
			writer.Write(temp.EdExtraDateSignCd);
			//抽出終了日付（数値）
			writer.Write(temp.EdExtraDateNum);
			//抽出終了日付（単位）
			writer.Write(temp.EdExtraDateUnitCd);
			//抽出終了日付（日付）
			writer.Write(temp.EndExtraDate);
			//抽出条件明細グループコード
			writer.Write(temp.ExtraCondDetailGrpCd);
			//必須抽出条件区分
			writer.Write(temp.NecessaryExtraCondCd);
			//チェック項目コード1
			writer.Write(temp.CheckItemCode1);
			//チェック項目コード2
			writer.Write(temp.CheckItemCode2);
			//チェック項目コード3
			writer.Write(temp.CheckItemCode3);
			//チェック項目コード4
			writer.Write(temp.CheckItemCode4);
			//チェック項目コード5
			writer.Write(temp.CheckItemCode5);
			//チェック項目コード6
			writer.Write(temp.CheckItemCode6);
			//チェック項目コード7
			writer.Write(temp.CheckItemCode7);
			//チェック項目コード8
			writer.Write(temp.CheckItemCode8);
			//チェック項目コード9
			writer.Write(temp.CheckItemCode9);
			//チェック項目コード10
			writer.Write(temp.CheckItemCode10);
			//ファイル名称
			writer.Write(temp.FileNm);
			//入力桁数
			writer.Write(temp.InputCharCnt);

		}

		/// <summary>
		///  FrePprECndWorkインスタンス取得
		/// </summary>
		/// <returns>FrePprECndWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprECndWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private FrePprECndWork GetFrePprECndWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			FrePprECndWork temp = new FrePprECndWork();

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
			//出力ファイル名
			temp.OutputFormFileName = reader.ReadString();
			//ユーザー帳票ID枝番号
			temp.UserPrtPprIdDerivNo = reader.ReadInt32();
			//自由帳票抽出条件枝番
			temp.FrePrtPprExtraCondCd = reader.ReadInt32();
			//表示順位
			temp.DisplayOrder = reader.ReadInt32();
			//抽出条件区分
			temp.ExtraConditionDivCd = reader.ReadInt32();
			//抽出条件タイプ
			temp.ExtraConditionTypeCd = reader.ReadInt32();
			//抽出条件タイトル
			temp.ExtraConditionTitle = reader.ReadString();
			//DD桁数
			temp.DDCharCnt = reader.ReadInt32();
			//DD名称
			temp.DDName = reader.ReadString();
			//抽出開始コード（数値）
			temp.StExtraNumCode = reader.ReadInt64();
			//抽出終了コード（数値）
			temp.EdExtraNumCode = reader.ReadInt64();
			//抽出開始コード（文字）
			temp.StExtraCharCode = reader.ReadString();
			//抽出終了コード（文字）
			temp.EdExtraCharCode = reader.ReadString();
			//抽出開始日付（基準）
			temp.StExtraDateBaseCd = reader.ReadInt32();
			//抽出開始日付（正負）
			temp.StExtraDateSignCd = reader.ReadInt32();
			//抽出開始日付（数値）
			temp.StExtraDateNum = reader.ReadInt32();
			//抽出開始日付（単位）
			temp.StExtraDateUnitCd = reader.ReadInt32();
			//抽出開始日付（日付）
			temp.StartExtraDate = reader.ReadInt32();
			//抽出終了日付（基準）
			temp.EdExtraDateBaseCd = reader.ReadInt32();
			//抽出終了日付（正負）
			temp.EdExtraDateSignCd = reader.ReadInt32();
			//抽出終了日付（数値）
			temp.EdExtraDateNum = reader.ReadInt32();
			//抽出終了日付（単位）
			temp.EdExtraDateUnitCd = reader.ReadInt32();
			//抽出終了日付（日付）
			temp.EndExtraDate = reader.ReadInt32();
			//抽出条件明細グループコード
			temp.ExtraCondDetailGrpCd = reader.ReadInt32();
			//必須抽出条件区分
			temp.NecessaryExtraCondCd = reader.ReadInt32();
			//チェック項目コード1
			temp.CheckItemCode1 = reader.ReadInt32();
			//チェック項目コード2
			temp.CheckItemCode2 = reader.ReadInt32();
			//チェック項目コード3
			temp.CheckItemCode3 = reader.ReadInt32();
			//チェック項目コード4
			temp.CheckItemCode4 = reader.ReadInt32();
			//チェック項目コード5
			temp.CheckItemCode5 = reader.ReadInt32();
			//チェック項目コード6
			temp.CheckItemCode6 = reader.ReadInt32();
			//チェック項目コード7
			temp.CheckItemCode7 = reader.ReadInt32();
			//チェック項目コード8
			temp.CheckItemCode8 = reader.ReadInt32();
			//チェック項目コード9
			temp.CheckItemCode9 = reader.ReadInt32();
			//チェック項目コード10
			temp.CheckItemCode10 = reader.ReadInt32();
			//ファイル名称
			temp.FileNm = reader.ReadString();
			//入力桁数
			temp.InputCharCnt = reader.ReadInt32();


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
		/// <returns>FrePprECndWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprECndWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				FrePprECndWork temp = GetFrePprECndWork(reader, serInfo);
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
					retValue = (FrePprECndWork[])lst.ToArray(typeof(FrePprECndWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}
