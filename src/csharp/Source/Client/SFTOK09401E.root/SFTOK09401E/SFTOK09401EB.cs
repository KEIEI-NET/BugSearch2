using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   NoteGuidBd
	/// <summary>
	///                      備考ガイドマスタ（ボディ）（ユーザ変更分）
	/// </summary>
	/// <remarks>
	/// <br>note             :   備考ガイドマスタ（ボディ）（ユーザ変更分）ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2005/10/06</br>
	/// <br>Genarated Date   :   2006/08/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class NoteGuidBd
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

		/// <summary>備考ガイドコード</summary>
		private Int32 _noteGuideCode;

		/// <summary>備考ガイド名称</summary>
		private string _noteGuideName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";


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
			get{return _noteGuideDivCode;}
			set{_noteGuideDivCode = value;}
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
			get{return _noteGuideDivName;}
			set{_noteGuideDivName = value;}
		}

		/// public propaty name  :  NoteGuideCode
		/// <summary>備考ガイドコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   備考ガイドコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NoteGuideCode
		{
			get{return _noteGuideCode;}
			set{_noteGuideCode = value;}
		}

		/// public propaty name  :  NoteGuideName
		/// <summary>備考ガイド名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   備考ガイド名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string NoteGuideName
		{
			get{return _noteGuideName;}
			set{_noteGuideName = value;}
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


		/// <summary>
		/// 備考ガイドマスタ（ボディ）（ユーザ変更分）クラスコンストラクタ
		/// </summary>
		/// <returns>NoteGuidBdクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoteGuidBdクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public NoteGuidBd()
		{
		}

		/// <summary>
		/// 備考ガイドマスタ（ボディ）（ユーザ変更分）クラスコンストラクタ
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
		/// <param name="noteGuideCode">備考ガイドコード</param>
		/// <param name="noteGuideName">備考ガイド名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>NoteGuidBdクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoteGuidBdクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public NoteGuidBd(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 noteGuideDivCode,string noteGuideDivName,Int32 noteGuideCode,string noteGuideName,string updEmployeeName,string enterpriseName)
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
			this._noteGuideCode = noteGuideCode;
			this._noteGuideName = noteGuideName;
			this._updEmployeeName = updEmployeeName;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// 備考ガイドマスタ（ボディ）（ユーザ変更分）クラス複製処理
		/// </summary>
		/// <returns>NoteGuidBdクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいNoteGuidBdクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public NoteGuidBd Clone()
		{
			return new NoteGuidBd(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._noteGuideDivCode,this._noteGuideDivName,this._noteGuideCode,this._noteGuideName,this._updEmployeeName,this._enterpriseName);
		}

		/// <summary>
		/// 備考ガイドマスタ（ボディ）（ユーザ変更分）クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のNoteGuidBdクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoteGuidBdクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(NoteGuidBd target)
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
				 && (this.NoteGuideCode == target.NoteGuideCode)
				 && (this.NoteGuideName == target.NoteGuideName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// 備考ガイドマスタ（ボディ）（ユーザ変更分）クラス比較処理
		/// </summary>
		/// <param name="noteGuidBd1">
		///                    比較するNoteGuidBdクラスのインスタンス
		/// </param>
		/// <param name="noteGuidBd2">比較するNoteGuidBdクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoteGuidBdクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(NoteGuidBd noteGuidBd1, NoteGuidBd noteGuidBd2)
		{
			return ((noteGuidBd1.CreateDateTime == noteGuidBd2.CreateDateTime)
				 && (noteGuidBd1.UpdateDateTime == noteGuidBd2.UpdateDateTime)
				 && (noteGuidBd1.EnterpriseCode == noteGuidBd2.EnterpriseCode)
				 && (noteGuidBd1.FileHeaderGuid == noteGuidBd2.FileHeaderGuid)
				 && (noteGuidBd1.UpdEmployeeCode == noteGuidBd2.UpdEmployeeCode)
				 && (noteGuidBd1.UpdAssemblyId1 == noteGuidBd2.UpdAssemblyId1)
				 && (noteGuidBd1.UpdAssemblyId2 == noteGuidBd2.UpdAssemblyId2)
				 && (noteGuidBd1.LogicalDeleteCode == noteGuidBd2.LogicalDeleteCode)
				 && (noteGuidBd1.NoteGuideDivCode == noteGuidBd2.NoteGuideDivCode)
				 && (noteGuidBd1.NoteGuideDivName == noteGuidBd2.NoteGuideDivName)
				 && (noteGuidBd1.NoteGuideCode == noteGuidBd2.NoteGuideCode)
				 && (noteGuidBd1.NoteGuideName == noteGuidBd2.NoteGuideName)
				 && (noteGuidBd1.UpdEmployeeName == noteGuidBd2.UpdEmployeeName)
				 && (noteGuidBd1.EnterpriseName == noteGuidBd2.EnterpriseName));
		}
		/// <summary>
		/// 備考ガイドマスタ（ボディ）（ユーザ変更分）クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のNoteGuidBdクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoteGuidBdクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(NoteGuidBd target)
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
			if(this.NoteGuideDivCode != target.NoteGuideDivCode)resList.Add("NoteGuideDivCode");
			if(this.NoteGuideDivName != target.NoteGuideDivName)resList.Add("NoteGuideDivName");
			if(this.NoteGuideCode != target.NoteGuideCode)resList.Add("NoteGuideCode");
			if(this.NoteGuideName != target.NoteGuideName)resList.Add("NoteGuideName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// 備考ガイドマスタ（ボディ）（ユーザ変更分）クラス比較処理
		/// </summary>
		/// <param name="noteGuidBd1">比較するNoteGuidBdクラスのインスタンス</param>
		/// <param name="noteGuidBd2">比較するNoteGuidBdクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoteGuidBdクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(NoteGuidBd noteGuidBd1, NoteGuidBd noteGuidBd2)
		{
			ArrayList resList = new ArrayList();
			if(noteGuidBd1.CreateDateTime != noteGuidBd2.CreateDateTime)resList.Add("CreateDateTime");
			if(noteGuidBd1.UpdateDateTime != noteGuidBd2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(noteGuidBd1.EnterpriseCode != noteGuidBd2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(noteGuidBd1.FileHeaderGuid != noteGuidBd2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(noteGuidBd1.UpdEmployeeCode != noteGuidBd2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(noteGuidBd1.UpdAssemblyId1 != noteGuidBd2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(noteGuidBd1.UpdAssemblyId2 != noteGuidBd2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(noteGuidBd1.LogicalDeleteCode != noteGuidBd2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(noteGuidBd1.NoteGuideDivCode != noteGuidBd2.NoteGuideDivCode)resList.Add("NoteGuideDivCode");
			if(noteGuidBd1.NoteGuideDivName != noteGuidBd2.NoteGuideDivName)resList.Add("NoteGuideDivName");
			if(noteGuidBd1.NoteGuideCode != noteGuidBd2.NoteGuideCode)resList.Add("NoteGuideCode");
			if(noteGuidBd1.NoteGuideName != noteGuidBd2.NoteGuideName)resList.Add("NoteGuideName");
			if(noteGuidBd1.UpdEmployeeName != noteGuidBd2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(noteGuidBd1.EnterpriseName != noteGuidBd2.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}
	}
}
