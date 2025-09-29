using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   NoteGuidHd
	/// <summary>
	///                      備考ガイドマスタ（ヘッダ）（ユーザ変更分）
	/// </summary>
	/// <remarks>
	/// <br>note             :   備考ガイドマスタ（ヘッダ）（ユーザ変更分）ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2005/10/06</br>
	/// <br>Genarated Date   :   2006/08/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class NoteGuidHd
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

		/// <summary>備考ガイド区分</summary>
		/// <remarks>1～100:顧客備考,201～205:客層区分1～5</remarks>
		private Int32 _noteGuideDivCode;

		/// <summary>備考ガイド区分名称</summary>
		private string _noteGuideDivName = "";

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

		/// public propaty name  :  NoteGuideDivCode
		/// <summary>備考ガイド区分プロパティ</summary>
        /// <value>1～100:顧客備考,201～205:客層区分1～5</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   備考ガイド区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NoteGuideDivCode
		{
			get
			{
				return _noteGuideDivCode;
			}
			set
			{
				_noteGuideDivCode = value;
			}
		}

		/// public propaty name  :  NoteGuideDivName
		/// <summary>備考ガイド区分名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   備考ガイド区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string NoteGuideDivName
		{
			get
			{
				return _noteGuideDivName;
			}
			set
			{
				_noteGuideDivName = value;
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


		/// <summary>
		/// 備考ガイドマスタ（ヘッダ）（ユーザ変更分）コンストラクタ
		/// </summary>
		/// <returns>NoteGuidHdクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoteGuidHdクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public NoteGuidHd()
		{
		}

		/// <summary>
		/// 備考ガイドマスタ（ヘッダ）（ユーザ変更分）コンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="noteGuideDivCode">備考ガイド区分(1～100:顧客備考,201～205:客層区分1～5)</param>
		/// <param name="noteGuideDivName">備考ガイド区分名称</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>NoteGuidHdクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoteGuidHdクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public NoteGuidHd(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 noteGuideDivCode, string noteGuideDivName, string enterpriseName, string updEmployeeName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._noteGuideDivCode = noteGuideDivCode;
			this._noteGuideDivName = noteGuideDivName;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// 備考ガイドマスタ（ヘッダ）（ユーザ変更分）複製処理
		/// </summary>
		/// <returns>NoteGuidHdクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいNoteGuidHdクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public NoteGuidHd Clone()
		{
			return new NoteGuidHd(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._noteGuideDivCode, this._noteGuideDivName, this._enterpriseName, this._updEmployeeName);
		}

		/// <summary>
		/// 備考ガイドマスタ（ヘッダ）（ユーザ変更分）比較処理
		/// </summary>
		/// <param name="target">比較対象のNoteGuidHdクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoteGuidHdクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(NoteGuidHd target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.NoteGuideDivCode == target.NoteGuideDivCode)
				 && (this.NoteGuideDivName == target.NoteGuideDivName)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// 備考ガイドマスタ（ヘッダ）（ユーザ変更分）比較処理
		/// </summary>
		/// <param name="noteGuidHd1">
		///                    比較するNoteGuidHdクラスのインスタンス
		/// </param>
		/// <param name="noteGuidHd2">比較するNoteGuidHdクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoteGuidHdクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(NoteGuidHd noteGuidHd1, NoteGuidHd noteGuidHd2)
		{
			return ((noteGuidHd1.CreateDateTime == noteGuidHd2.CreateDateTime)
				 && (noteGuidHd1.UpdateDateTime == noteGuidHd2.UpdateDateTime)
				 && (noteGuidHd1.EnterpriseCode == noteGuidHd2.EnterpriseCode)
				 && (noteGuidHd1.FileHeaderGuid == noteGuidHd2.FileHeaderGuid)
				 && (noteGuidHd1.UpdEmployeeCode == noteGuidHd2.UpdEmployeeCode)
				 && (noteGuidHd1.UpdAssemblyId1 == noteGuidHd2.UpdAssemblyId1)
				 && (noteGuidHd1.UpdAssemblyId2 == noteGuidHd2.UpdAssemblyId2)
				 && (noteGuidHd1.LogicalDeleteCode == noteGuidHd2.LogicalDeleteCode)
				 && (noteGuidHd1.NoteGuideDivCode == noteGuidHd2.NoteGuideDivCode)
				 && (noteGuidHd1.NoteGuideDivName == noteGuidHd2.NoteGuideDivName)
				 && (noteGuidHd1.EnterpriseName == noteGuidHd2.EnterpriseName)
				 && (noteGuidHd1.UpdEmployeeName == noteGuidHd2.UpdEmployeeName));
		}
		/// <summary>
		/// 備考ガイドマスタ（ヘッダ）（ユーザ変更分）比較処理
		/// </summary>
		/// <param name="target">比較対象のNoteGuidHdクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoteGuidHdクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(NoteGuidHd target)
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
			if (this.NoteGuideDivCode != target.NoteGuideDivCode)
				resList.Add("NoteGuideDivCode");
			if (this.NoteGuideDivName != target.NoteGuideDivName)
				resList.Add("NoteGuideDivName");
			if (this.EnterpriseName != target.EnterpriseName)
				resList.Add("EnterpriseName");
			if (this.UpdEmployeeName != target.UpdEmployeeName)
				resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// 備考ガイドマスタ（ヘッダ）（ユーザ変更分）比較処理
		/// </summary>
		/// <param name="noteGuidHd1">比較するNoteGuidHdクラスのインスタンス</param>
		/// <param name="noteGuidHd2">比較するNoteGuidHdクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoteGuidHdクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(NoteGuidHd noteGuidHd1, NoteGuidHd noteGuidHd2)
		{
			ArrayList resList = new ArrayList();
			if (noteGuidHd1.CreateDateTime != noteGuidHd2.CreateDateTime)
				resList.Add("CreateDateTime");
			if (noteGuidHd1.UpdateDateTime != noteGuidHd2.UpdateDateTime)
				resList.Add("UpdateDateTime");
			if (noteGuidHd1.EnterpriseCode != noteGuidHd2.EnterpriseCode)
				resList.Add("EnterpriseCode");
			if (noteGuidHd1.FileHeaderGuid != noteGuidHd2.FileHeaderGuid)
				resList.Add("FileHeaderGuid");
			if (noteGuidHd1.UpdEmployeeCode != noteGuidHd2.UpdEmployeeCode)
				resList.Add("UpdEmployeeCode");
			if (noteGuidHd1.UpdAssemblyId1 != noteGuidHd2.UpdAssemblyId1)
				resList.Add("UpdAssemblyId1");
			if (noteGuidHd1.UpdAssemblyId2 != noteGuidHd2.UpdAssemblyId2)
				resList.Add("UpdAssemblyId2");
			if (noteGuidHd1.LogicalDeleteCode != noteGuidHd2.LogicalDeleteCode)
				resList.Add("LogicalDeleteCode");
			if (noteGuidHd1.NoteGuideDivCode != noteGuidHd2.NoteGuideDivCode)
				resList.Add("NoteGuideDivCode");
			if (noteGuidHd1.NoteGuideDivName != noteGuidHd2.NoteGuideDivName)
				resList.Add("NoteGuideDivName");
			if (noteGuidHd1.EnterpriseName != noteGuidHd2.EnterpriseName)
				resList.Add("EnterpriseName");
			if (noteGuidHd1.UpdEmployeeName != noteGuidHd2.UpdEmployeeName)
				resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}
