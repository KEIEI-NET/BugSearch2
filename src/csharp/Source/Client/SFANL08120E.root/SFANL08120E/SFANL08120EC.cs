using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   FrePExCndD
	/// <summary>
	///                      自由帳票抽出条件明細マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   自由帳票抽出条件明細マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/03/15</br>
	/// <br>Genarated Date   :   2007/03/30  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class FrePExCndD
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

		/// <summary>抽出条件明細グループコード</summary>
		/// <remarks>抽出条件区分がコンボボックス型の時に使用</remarks>
		private Int32 _extraCondDetailGrpCd;

		/// <summary>抽出条件明細コード</summary>
		private Int32 _extraCondDetailCode;

		/// <summary>抽出条件明細名称</summary>
		private string _extraCondDetailName = "";

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

		/// public propaty name  :  ExtraCondDetailCode
		/// <summary>抽出条件明細コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出条件明細コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ExtraCondDetailCode
		{
			get { return _extraCondDetailCode; }
			set { _extraCondDetailCode = value; }
		}

		/// public propaty name  :  ExtraCondDetailName
		/// <summary>抽出条件明細名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出条件明細名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ExtraCondDetailName
		{
			get { return _extraCondDetailName; }
			set { _extraCondDetailName = value; }
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
		/// 自由帳票抽出条件明細マスタコンストラクタ
		/// </summary>
		/// <returns>FrePExCndDクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePExCndDクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePExCndD()
		{
		}

		/// <summary>
		/// 自由帳票抽出条件明細マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="extraCondDetailGrpCd">抽出条件明細グループコード(抽出条件区分がコンボボックス型の時に使用)</param>
		/// <param name="extraCondDetailCode">抽出条件明細コード</param>
		/// <param name="extraCondDetailName">抽出条件明細名称</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>FrePExCndDクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePExCndDクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePExCndD(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 extraCondDetailGrpCd, Int32 extraCondDetailCode, string extraCondDetailName, string enterpriseName, string updEmployeeName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._extraCondDetailGrpCd = extraCondDetailGrpCd;
			this._extraCondDetailCode = extraCondDetailCode;
			this._extraCondDetailName = extraCondDetailName;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// 自由帳票抽出条件明細マスタ複製処理
		/// </summary>
		/// <returns>FrePExCndDクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいFrePExCndDクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePExCndD Clone()
		{
			return new FrePExCndD(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._extraCondDetailGrpCd, this._extraCondDetailCode, this._extraCondDetailName, this._enterpriseName, this._updEmployeeName);
		}

		/// <summary>
		/// 自由帳票抽出条件明細マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のFrePExCndDクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePExCndDクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(FrePExCndD target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.ExtraCondDetailGrpCd == target.ExtraCondDetailGrpCd)
				 && (this.ExtraCondDetailCode == target.ExtraCondDetailCode)
				 && (this.ExtraCondDetailName == target.ExtraCondDetailName)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// 自由帳票抽出条件明細マスタ比較処理
		/// </summary>
		/// <param name="frePExCndD1">
		///                    比較するFrePExCndDクラスのインスタンス
		/// </param>
		/// <param name="frePExCndD2">比較するFrePExCndDクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePExCndDクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(FrePExCndD frePExCndD1, FrePExCndD frePExCndD2)
		{
			return ((frePExCndD1.CreateDateTime == frePExCndD2.CreateDateTime)
				 && (frePExCndD1.UpdateDateTime == frePExCndD2.UpdateDateTime)
				 && (frePExCndD1.EnterpriseCode == frePExCndD2.EnterpriseCode)
				 && (frePExCndD1.FileHeaderGuid == frePExCndD2.FileHeaderGuid)
				 && (frePExCndD1.UpdEmployeeCode == frePExCndD2.UpdEmployeeCode)
				 && (frePExCndD1.UpdAssemblyId1 == frePExCndD2.UpdAssemblyId1)
				 && (frePExCndD1.UpdAssemblyId2 == frePExCndD2.UpdAssemblyId2)
				 && (frePExCndD1.LogicalDeleteCode == frePExCndD2.LogicalDeleteCode)
				 && (frePExCndD1.ExtraCondDetailGrpCd == frePExCndD2.ExtraCondDetailGrpCd)
				 && (frePExCndD1.ExtraCondDetailCode == frePExCndD2.ExtraCondDetailCode)
				 && (frePExCndD1.ExtraCondDetailName == frePExCndD2.ExtraCondDetailName)
				 && (frePExCndD1.EnterpriseName == frePExCndD2.EnterpriseName)
				 && (frePExCndD1.UpdEmployeeName == frePExCndD2.UpdEmployeeName));
		}
		/// <summary>
		/// 自由帳票抽出条件明細マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のFrePExCndDクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePExCndDクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(FrePExCndD target)
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
			if (this.ExtraCondDetailGrpCd != target.ExtraCondDetailGrpCd) resList.Add("ExtraCondDetailGrpCd");
			if (this.ExtraCondDetailCode != target.ExtraCondDetailCode) resList.Add("ExtraCondDetailCode");
			if (this.ExtraCondDetailName != target.ExtraCondDetailName) resList.Add("ExtraCondDetailName");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
			if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// 自由帳票抽出条件明細マスタ比較処理
		/// </summary>
		/// <param name="frePExCndD1">比較するFrePExCndDクラスのインスタンス</param>
		/// <param name="frePExCndD2">比較するFrePExCndDクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePExCndDクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(FrePExCndD frePExCndD1, FrePExCndD frePExCndD2)
		{
			ArrayList resList = new ArrayList();
			if (frePExCndD1.CreateDateTime != frePExCndD2.CreateDateTime) resList.Add("CreateDateTime");
			if (frePExCndD1.UpdateDateTime != frePExCndD2.UpdateDateTime) resList.Add("UpdateDateTime");
			if (frePExCndD1.EnterpriseCode != frePExCndD2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (frePExCndD1.FileHeaderGuid != frePExCndD2.FileHeaderGuid) resList.Add("FileHeaderGuid");
			if (frePExCndD1.UpdEmployeeCode != frePExCndD2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
			if (frePExCndD1.UpdAssemblyId1 != frePExCndD2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
			if (frePExCndD1.UpdAssemblyId2 != frePExCndD2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
			if (frePExCndD1.LogicalDeleteCode != frePExCndD2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (frePExCndD1.ExtraCondDetailGrpCd != frePExCndD2.ExtraCondDetailGrpCd) resList.Add("ExtraCondDetailGrpCd");
			if (frePExCndD1.ExtraCondDetailCode != frePExCndD2.ExtraCondDetailCode) resList.Add("ExtraCondDetailCode");
			if (frePExCndD1.ExtraCondDetailName != frePExCndD2.ExtraCondDetailName) resList.Add("ExtraCondDetailName");
			if (frePExCndD1.EnterpriseName != frePExCndD2.EnterpriseName) resList.Add("EnterpriseName");
			if (frePExCndD1.UpdEmployeeName != frePExCndD2.UpdEmployeeName) resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}
