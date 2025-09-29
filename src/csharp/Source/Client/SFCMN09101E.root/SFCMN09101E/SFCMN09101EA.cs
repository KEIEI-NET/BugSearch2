using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   NoMngSet
	/// <summary>
	///                      番号管理設定マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   番号管理設定マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2005/8/30</br>
	/// <br>Genarated Date   :   2006/08/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class NoMngSet
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

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>番号コード</summary>
		/// <remarks>1:顧客ｺｰﾄﾞ,2:車両管理番号,･･･つづきあり(項目詳細)</remarks>
		private Int32 _noCode;

		/// <summary>番号現在値</summary>
		/// <remarks>番号現在値または論理削除ﾚｺｰﾄﾞ件数(項目詳細)</remarks>
		private Int64 _noPresentVal;

		/// <summary>設定開始番号</summary>
		private Int64 _settingStartNo;

		/// <summary>設定終了番号</summary>
		private Int64 _settingEndNo;

		/// <summary>番号増減幅</summary>
		private Int32 _noIncDecWidth;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

		/// <summary>番号名称</summary>
		private string _noName = "";


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
			get
			{
				return _createDateTime;
			}
			set
			{
				_createDateTime = value;
			}
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
			get
			{
				return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);
			}
			set
			{
			}
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
			get
			{
				return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);
			}
			set
			{
			}
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
			get
			{
				return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);
			}
			set
			{
			}
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
			get
			{
				return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);
			}
			set
			{
			}
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
			get
			{
				return _updateDateTime;
			}
			set
			{
				_updateDateTime = value;
			}
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
			get
			{
				return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);
			}
			set
			{
			}
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
			get
			{
				return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);
			}
			set
			{
			}
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
			get
			{
				return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);
			}
			set
			{
			}
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
			get
			{
				return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);
			}
			set
			{
			}
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
			get
			{
				return _enterpriseCode;
			}
			set
			{
				_enterpriseCode = value;
			}
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
			get
			{
				return _fileHeaderGuid;
			}
			set
			{
				_fileHeaderGuid = value;
			}
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
			get
			{
				return _updEmployeeCode;
			}
			set
			{
				_updEmployeeCode = value;
			}
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
			get
			{
				return _updAssemblyId1;
			}
			set
			{
				_updAssemblyId1 = value;
			}
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
			get
			{
				return _updAssemblyId2;
			}
			set
			{
				_updAssemblyId2 = value;
			}
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
			get
			{
				return _logicalDeleteCode;
			}
			set
			{
				_logicalDeleteCode = value;
			}
		}

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionCode
		{
			get
			{
				return _sectionCode;
			}
			set
			{
				_sectionCode = value;
			}
		}

		/// public propaty name  :  NoCode
		/// <summary>番号コードプロパティ</summary>
		/// <value>1:顧客ｺｰﾄﾞ,2:車両管理番号,･･･つづきあり(項目詳細)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   番号コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NoCode
		{
			get
			{
				return _noCode;
			}
			set
			{
				_noCode = value;
			}
		}

		/// public propaty name  :  NoPresentVal
		/// <summary>番号現在値プロパティ</summary>
		/// <value>番号現在値または論理削除ﾚｺｰﾄﾞ件数(項目詳細)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   番号現在値プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 NoPresentVal
		{
			get
			{
				return _noPresentVal;
			}
			set
			{
				_noPresentVal = value;
			}
		}

		/// public propaty name  :  SettingStartNo
		/// <summary>設定開始番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   設定開始番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SettingStartNo
		{
			get
			{
				return _settingStartNo;
			}
			set
			{
				_settingStartNo = value;
			}
		}

		/// public propaty name  :  SettingEndNo
		/// <summary>設定終了番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   設定終了番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SettingEndNo
		{
			get
			{
				return _settingEndNo;
			}
			set
			{
				_settingEndNo = value;
			}
		}

		/// public propaty name  :  NoIncDecWidth
		/// <summary>番号増減幅プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   番号増減幅プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NoIncDecWidth
		{
			get
			{
				return _noIncDecWidth;
			}
			set
			{
				_noIncDecWidth = value;
			}
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
			get
			{
				return _enterpriseName;
			}
			set
			{
				_enterpriseName = value;
			}
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
			get
			{
				return _updEmployeeName;
			}
			set
			{
				_updEmployeeName = value;
			}
		}

		/// public propaty name  :  NoName
		/// <summary>番号名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   番号名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string NoName
		{
			get
			{
				return _noName;
			}
			set
			{
				_noName = value;
			}
		}


		/// <summary>
		/// 番号管理設定マスタコンストラクタ
		/// </summary>
		/// <returns>NoMngSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoMngSetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public NoMngSet()
		{
		}

		/// <summary>
		/// 番号管理設定マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="noCode">番号コード(1:顧客ｺｰﾄﾞ,2:車両管理番号,･･･つづきあり(項目詳細))</param>
		/// <param name="noPresentVal">番号現在値(番号現在値または論理削除ﾚｺｰﾄﾞ件数(項目詳細))</param>
		/// <param name="settingStartNo">設定開始番号</param>
		/// <param name="settingEndNo">設定終了番号</param>
		/// <param name="noIncDecWidth">番号増減幅</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="noName">番号名称</param>
		/// <returns>NoMngSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoMngSetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public NoMngSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 noCode, Int64 noPresentVal, Int64 settingStartNo, Int64 settingEndNo, Int32 noIncDecWidth, string enterpriseName, string updEmployeeName, string noName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._sectionCode = sectionCode;
			this._noCode = noCode;
			this._noPresentVal = noPresentVal;
			this._settingStartNo = settingStartNo;
			this._settingEndNo = settingEndNo;
			this._noIncDecWidth = noIncDecWidth;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._noName = noName;

		}

		/// <summary>
		/// 番号管理設定マスタ複製処理
		/// </summary>
		/// <returns>NoMngSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいNoMngSetクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public NoMngSet Clone()
		{
			return new NoMngSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._noCode, this._noPresentVal, this._settingStartNo, this._settingEndNo, this._noIncDecWidth, this._enterpriseName, this._updEmployeeName, this._noName);
		}

		/// <summary>
		/// 番号管理設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のNoMngSetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoMngSetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(NoMngSet target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.NoCode == target.NoCode)
				 && (this.NoPresentVal == target.NoPresentVal)
				 && (this.SettingStartNo == target.SettingStartNo)
				 && (this.SettingEndNo == target.SettingEndNo)
				 && (this.NoIncDecWidth == target.NoIncDecWidth)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.NoName == target.NoName));
		}

		/// <summary>
		/// 番号管理設定マスタ比較処理
		/// </summary>
		/// <param name="noMngSet1">
		///                    比較するNoMngSetクラスのインスタンス
		/// </param>
		/// <param name="noMngSet2">比較するNoMngSetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoMngSetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(NoMngSet noMngSet1, NoMngSet noMngSet2)
		{
			return ((noMngSet1.CreateDateTime == noMngSet2.CreateDateTime)
				 && (noMngSet1.UpdateDateTime == noMngSet2.UpdateDateTime)
				 && (noMngSet1.EnterpriseCode == noMngSet2.EnterpriseCode)
				 && (noMngSet1.FileHeaderGuid == noMngSet2.FileHeaderGuid)
				 && (noMngSet1.UpdEmployeeCode == noMngSet2.UpdEmployeeCode)
				 && (noMngSet1.UpdAssemblyId1 == noMngSet2.UpdAssemblyId1)
				 && (noMngSet1.UpdAssemblyId2 == noMngSet2.UpdAssemblyId2)
				 && (noMngSet1.LogicalDeleteCode == noMngSet2.LogicalDeleteCode)
				 && (noMngSet1.SectionCode == noMngSet2.SectionCode)
				 && (noMngSet1.NoCode == noMngSet2.NoCode)
				 && (noMngSet1.NoPresentVal == noMngSet2.NoPresentVal)
				 && (noMngSet1.SettingStartNo == noMngSet2.SettingStartNo)
				 && (noMngSet1.SettingEndNo == noMngSet2.SettingEndNo)
				 && (noMngSet1.NoIncDecWidth == noMngSet2.NoIncDecWidth)
				 && (noMngSet1.EnterpriseName == noMngSet2.EnterpriseName)
				 && (noMngSet1.UpdEmployeeName == noMngSet2.UpdEmployeeName)
				 && (noMngSet1.NoName == noMngSet2.NoName));
		}
		/// <summary>
		/// 番号管理設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のNoMngSetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoMngSetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(NoMngSet target)
		{
			ArrayList resList = new ArrayList();
			if (this.CreateDateTime != target.CreateDateTime)
				resList.Add("CreateDateTime");
			if (this.UpdateDateTime != target.UpdateDateTime)
				resList.Add("UpdateDateTime");
			if (this.EnterpriseCode != target.EnterpriseCode)
				resList.Add("EnterpriseCode");
			if (this.FileHeaderGuid != target.FileHeaderGuid)
				resList.Add("FileHeaderGuid");
			if (this.UpdEmployeeCode != target.UpdEmployeeCode)
				resList.Add("UpdEmployeeCode");
			if (this.UpdAssemblyId1 != target.UpdAssemblyId1)
				resList.Add("UpdAssemblyId1");
			if (this.UpdAssemblyId2 != target.UpdAssemblyId2)
				resList.Add("UpdAssemblyId2");
			if (this.LogicalDeleteCode != target.LogicalDeleteCode)
				resList.Add("LogicalDeleteCode");
			if (this.SectionCode != target.SectionCode)
				resList.Add("SectionCode");
			if (this.NoCode != target.NoCode)
				resList.Add("NoCode");
			if (this.NoPresentVal != target.NoPresentVal)
				resList.Add("NoPresentVal");
			if (this.SettingStartNo != target.SettingStartNo)
				resList.Add("SettingStartNo");
			if (this.SettingEndNo != target.SettingEndNo)
				resList.Add("SettingEndNo");
			if (this.NoIncDecWidth != target.NoIncDecWidth)
				resList.Add("NoIncDecWidth");
			if (this.EnterpriseName != target.EnterpriseName)
				resList.Add("EnterpriseName");
			if (this.UpdEmployeeName != target.UpdEmployeeName)
				resList.Add("UpdEmployeeName");
			if (this.NoName != target.NoName)
				resList.Add("NoName");

			return resList;
		}

		/// <summary>
		/// 番号管理設定マスタ比較処理
		/// </summary>
		/// <param name="noMngSet1">比較するNoMngSetクラスのインスタンス</param>
		/// <param name="noMngSet2">比較するNoMngSetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoMngSetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(NoMngSet noMngSet1, NoMngSet noMngSet2)
		{
			ArrayList resList = new ArrayList();
			if (noMngSet1.CreateDateTime != noMngSet2.CreateDateTime)
				resList.Add("CreateDateTime");
			if (noMngSet1.UpdateDateTime != noMngSet2.UpdateDateTime)
				resList.Add("UpdateDateTime");
			if (noMngSet1.EnterpriseCode != noMngSet2.EnterpriseCode)
				resList.Add("EnterpriseCode");
			if (noMngSet1.FileHeaderGuid != noMngSet2.FileHeaderGuid)
				resList.Add("FileHeaderGuid");
			if (noMngSet1.UpdEmployeeCode != noMngSet2.UpdEmployeeCode)
				resList.Add("UpdEmployeeCode");
			if (noMngSet1.UpdAssemblyId1 != noMngSet2.UpdAssemblyId1)
				resList.Add("UpdAssemblyId1");
			if (noMngSet1.UpdAssemblyId2 != noMngSet2.UpdAssemblyId2)
				resList.Add("UpdAssemblyId2");
			if (noMngSet1.LogicalDeleteCode != noMngSet2.LogicalDeleteCode)
				resList.Add("LogicalDeleteCode");
			if (noMngSet1.SectionCode != noMngSet2.SectionCode)
				resList.Add("SectionCode");
			if (noMngSet1.NoCode != noMngSet2.NoCode)
				resList.Add("NoCode");
			if (noMngSet1.NoPresentVal != noMngSet2.NoPresentVal)
				resList.Add("NoPresentVal");
			if (noMngSet1.SettingStartNo != noMngSet2.SettingStartNo)
				resList.Add("SettingStartNo");
			if (noMngSet1.SettingEndNo != noMngSet2.SettingEndNo)
				resList.Add("SettingEndNo");
			if (noMngSet1.NoIncDecWidth != noMngSet2.NoIncDecWidth)
				resList.Add("NoIncDecWidth");
			if (noMngSet1.EnterpriseName != noMngSet2.EnterpriseName)
				resList.Add("EnterpriseName");
			if (noMngSet1.UpdEmployeeName != noMngSet2.UpdEmployeeName)
				resList.Add("UpdEmployeeName");
			if (noMngSet1.NoName != noMngSet2.NoName)
				resList.Add("NoName");

			return resList;
		}
	}
}
