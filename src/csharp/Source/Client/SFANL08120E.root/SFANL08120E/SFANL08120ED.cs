using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   FrePprSrtO
	/// <summary>
	///                      自由帳票ソート順位マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   自由帳票ソート順位マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   寺坂　誉志</br>
	/// <br>Genarated Date   :   2007/10/12  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class FrePprSrtO
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

		/// <summary>ソート順位コード</summary>
		private Int32 _sortingOrderCode;

		/// <summary>ソート順位</summary>
		/// <remarks>※１</remarks>
		private Int32 _sortingOrder;

		/// <summary>自由帳票項目名称</summary>
		private string _freePrtPaperItemNm = "";

		/// <summary>DD名称</summary>
		/// <remarks>小文字で登録</remarks>
		private string _dDName = "";

		/// <summary>ファイル名称</summary>
		/// <remarks>DBのテーブルID</remarks>
		private string _fileNm = "";

		/// <summary>昇順降順区分</summary>
		/// <remarks>0:なし,1:昇順,2:降順</remarks>
		private Int32 _sortingOrderDivCd;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";


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

		/// public propaty name  :  SortingOrderCode
		/// <summary>ソート順位コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ソート順位コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SortingOrderCode
		{
			get { return _sortingOrderCode; }
			set { _sortingOrderCode = value; }
		}

		/// public propaty name  :  SortingOrder
		/// <summary>ソート順位プロパティ</summary>
		/// <value>※１</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ソート順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SortingOrder
		{
			get { return _sortingOrder; }
			set { _sortingOrder = value; }
		}

		/// public propaty name  :  FreePrtPaperItemNm
		/// <summary>自由帳票項目名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票項目名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FreePrtPaperItemNm
		{
			get { return _freePrtPaperItemNm; }
			set { _freePrtPaperItemNm = value; }
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

		/// public propaty name  :  SortingOrderDivCd
		/// <summary>昇順降順区分プロパティ</summary>
		/// <value>0:なし,1:昇順,2:降順</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   昇順降順区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SortingOrderDivCd
		{
			get { return _sortingOrderDivCd; }
			set { _sortingOrderDivCd = value; }
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


		/// <summary>
		/// 自由帳票ソート順位マスタコンストラクタ
		/// </summary>
		/// <returns>FrePprSrtOクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprSrtOクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePprSrtO()
		{
		}

		/// <summary>
		/// 自由帳票ソート順位マスタコンストラクタ
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
		/// <param name="sortingOrderCode">ソート順位コード</param>
		/// <param name="sortingOrder">ソート順位(※１)</param>
		/// <param name="freePrtPaperItemNm">自由帳票項目名称</param>
		/// <param name="dDName">DD名称(小文字で登録)</param>
		/// <param name="fileNm">ファイル名称(DBのテーブルID)</param>
		/// <param name="sortingOrderDivCd">昇順降順区分(0:なし,1:昇順,2:降順)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>FrePprSrtOクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprSrtOクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePprSrtO(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string outputFormFileName, Int32 userPrtPprIdDerivNo, Int32 sortingOrderCode, Int32 sortingOrder, string freePrtPaperItemNm, string dDName, string fileNm, Int32 sortingOrderDivCd, string enterpriseName, string updEmployeeName)
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
			this._sortingOrderCode = sortingOrderCode;
			this._sortingOrder = sortingOrder;
			this._freePrtPaperItemNm = freePrtPaperItemNm;
			this._dDName = dDName;
			this._fileNm = fileNm;
			this._sortingOrderDivCd = sortingOrderDivCd;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// 自由帳票ソート順位マスタ複製処理
		/// </summary>
		/// <returns>FrePprSrtOクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいFrePprSrtOクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePprSrtO Clone()
		{
			return new FrePprSrtO(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._outputFormFileName, this._userPrtPprIdDerivNo, this._sortingOrderCode, this._sortingOrder, this._freePrtPaperItemNm, this._dDName, this._fileNm, this._sortingOrderDivCd, this._enterpriseName, this._updEmployeeName);
		}

		/// <summary>
		/// 自由帳票ソート順位マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のFrePprSrtOクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprSrtOクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(FrePprSrtO target)
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
				 && (this.SortingOrderCode == target.SortingOrderCode)
				 && (this.SortingOrder == target.SortingOrder)
				 && (this.FreePrtPaperItemNm == target.FreePrtPaperItemNm)
				 && (this.DDName == target.DDName)
				 && (this.FileNm == target.FileNm)
				 && (this.SortingOrderDivCd == target.SortingOrderDivCd)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// 自由帳票ソート順位マスタ比較処理
		/// </summary>
		/// <param name="frePprSrtO1">
		///                    比較するFrePprSrtOクラスのインスタンス
		/// </param>
		/// <param name="frePprSrtO2">比較するFrePprSrtOクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprSrtOクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(FrePprSrtO frePprSrtO1, FrePprSrtO frePprSrtO2)
		{
			return ((frePprSrtO1.CreateDateTime == frePprSrtO2.CreateDateTime)
				 && (frePprSrtO1.UpdateDateTime == frePprSrtO2.UpdateDateTime)
				 && (frePprSrtO1.EnterpriseCode == frePprSrtO2.EnterpriseCode)
				 && (frePprSrtO1.FileHeaderGuid == frePprSrtO2.FileHeaderGuid)
				 && (frePprSrtO1.UpdEmployeeCode == frePprSrtO2.UpdEmployeeCode)
				 && (frePprSrtO1.UpdAssemblyId1 == frePprSrtO2.UpdAssemblyId1)
				 && (frePprSrtO1.UpdAssemblyId2 == frePprSrtO2.UpdAssemblyId2)
				 && (frePprSrtO1.LogicalDeleteCode == frePprSrtO2.LogicalDeleteCode)
				 && (frePprSrtO1.OutputFormFileName == frePprSrtO2.OutputFormFileName)
				 && (frePprSrtO1.UserPrtPprIdDerivNo == frePprSrtO2.UserPrtPprIdDerivNo)
				 && (frePprSrtO1.SortingOrderCode == frePprSrtO2.SortingOrderCode)
				 && (frePprSrtO1.SortingOrder == frePprSrtO2.SortingOrder)
				 && (frePprSrtO1.FreePrtPaperItemNm == frePprSrtO2.FreePrtPaperItemNm)
				 && (frePprSrtO1.DDName == frePprSrtO2.DDName)
				 && (frePprSrtO1.FileNm == frePprSrtO2.FileNm)
				 && (frePprSrtO1.SortingOrderDivCd == frePprSrtO2.SortingOrderDivCd)
				 && (frePprSrtO1.EnterpriseName == frePprSrtO2.EnterpriseName)
				 && (frePprSrtO1.UpdEmployeeName == frePprSrtO2.UpdEmployeeName));
		}
		/// <summary>
		/// 自由帳票ソート順位マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のFrePprSrtOクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprSrtOクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(FrePprSrtO target)
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
			if (this.SortingOrderCode != target.SortingOrderCode) resList.Add("SortingOrderCode");
			if (this.SortingOrder != target.SortingOrder) resList.Add("SortingOrder");
			if (this.FreePrtPaperItemNm != target.FreePrtPaperItemNm) resList.Add("FreePrtPaperItemNm");
			if (this.DDName != target.DDName) resList.Add("DDName");
			if (this.FileNm != target.FileNm) resList.Add("FileNm");
			if (this.SortingOrderDivCd != target.SortingOrderDivCd) resList.Add("SortingOrderDivCd");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
			if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// 自由帳票ソート順位マスタ比較処理
		/// </summary>
		/// <param name="frePprSrtO1">比較するFrePprSrtOクラスのインスタンス</param>
		/// <param name="frePprSrtO2">比較するFrePprSrtOクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePprSrtOクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(FrePprSrtO frePprSrtO1, FrePprSrtO frePprSrtO2)
		{
			ArrayList resList = new ArrayList();
			if (frePprSrtO1.CreateDateTime != frePprSrtO2.CreateDateTime) resList.Add("CreateDateTime");
			if (frePprSrtO1.UpdateDateTime != frePprSrtO2.UpdateDateTime) resList.Add("UpdateDateTime");
			if (frePprSrtO1.EnterpriseCode != frePprSrtO2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (frePprSrtO1.FileHeaderGuid != frePprSrtO2.FileHeaderGuid) resList.Add("FileHeaderGuid");
			if (frePprSrtO1.UpdEmployeeCode != frePprSrtO2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
			if (frePprSrtO1.UpdAssemblyId1 != frePprSrtO2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
			if (frePprSrtO1.UpdAssemblyId2 != frePprSrtO2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
			if (frePprSrtO1.LogicalDeleteCode != frePprSrtO2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (frePprSrtO1.OutputFormFileName != frePprSrtO2.OutputFormFileName) resList.Add("OutputFormFileName");
			if (frePprSrtO1.UserPrtPprIdDerivNo != frePprSrtO2.UserPrtPprIdDerivNo) resList.Add("UserPrtPprIdDerivNo");
			if (frePprSrtO1.SortingOrderCode != frePprSrtO2.SortingOrderCode) resList.Add("SortingOrderCode");
			if (frePprSrtO1.SortingOrder != frePprSrtO2.SortingOrder) resList.Add("SortingOrder");
			if (frePprSrtO1.FreePrtPaperItemNm != frePprSrtO2.FreePrtPaperItemNm) resList.Add("FreePrtPaperItemNm");
			if (frePprSrtO1.DDName != frePprSrtO2.DDName) resList.Add("DDName");
			if (frePprSrtO1.FileNm != frePprSrtO2.FileNm) resList.Add("FileNm");
			if (frePprSrtO1.SortingOrderDivCd != frePprSrtO2.SortingOrderDivCd) resList.Add("SortingOrderDivCd");
			if (frePprSrtO1.EnterpriseName != frePprSrtO2.EnterpriseName) resList.Add("EnterpriseName");
			if (frePprSrtO1.UpdEmployeeName != frePprSrtO2.UpdEmployeeName) resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}
