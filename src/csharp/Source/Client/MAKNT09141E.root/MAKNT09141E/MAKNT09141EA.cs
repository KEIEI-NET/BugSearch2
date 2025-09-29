using System;
using System.Collections;
using System.Text;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:	 HolidaySetting
	/// <summary>
	/// 					 休業日設定マスタ
	/// </summary>
	/// <remarks>
	/// <br>note			 :	 休業日設定マスタヘッダファイル</br>
	/// <br>Programmer		 :	 NEPCO</br>
	/// <br>Date			 :	 </br>
	/// <br>Genarated Date	 :	 2006/12/19  (CSharp File Generated Date)</br>
	/// <br></br>
	/// </remarks>
	public class HolidaySetting
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

		/// <summary>適用年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _applyDate;

		/// <summary>適用区分</summary>
		/// <remarks>0:休業日　1:祝祭日</remarks>
		private Int32 _applyDateCd;

		/// <summary>拠点名称</summary>
		/// </remarks>
		private string _sectionName = "";

		/// public propaty name  :	CreateDateTime
		/// <summary>作成日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 作成日時プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
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

		/// public propaty name  :	CreateDateTimeJpFormal
		/// <summary>作成日時 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 作成日時 和暦プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
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

		/// public propaty name  :	CreateDateTimeJpInFormal
		/// <summary>作成日時 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 作成日時 和暦(略)プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
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

		/// public propaty name  :	CreateDateTimeAdFormal
		/// <summary>作成日時 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 作成日時 西暦プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
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

		/// public propaty name  :	CreateDateTimeAdInFormal
		/// <summary>作成日時 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 作成日時 西暦(略)プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
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

		/// public propaty name  :	UpdateDateTime
		/// <summary>更新日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 更新日時プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
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

		/// public propaty name  :	UpdateDateTimeJpFormal
		/// <summary>更新日時 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 更新日時 和暦プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
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

		/// public propaty name  :	UpdateDateTimeJpInFormal
		/// <summary>更新日時 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 更新日時 和暦(略)プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
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

		/// public propaty name  :	UpdateDateTimeAdFormal
		/// <summary>更新日時 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 更新日時 西暦プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
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

		/// public propaty name  :	UpdateDateTimeAdInFormal
		/// <summary>更新日時 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 更新日時 西暦(略)プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
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

		/// public propaty name  :	EnterpriseCode
		/// <summary>企業コードプロパティ</summary>
		/// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 企業コードプロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
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

		/// public propaty name  :	FileHeaderGuid
		/// <summary>GUIDプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 GUIDプロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
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

		/// public propaty name  :	UpdEmployeeCode
		/// <summary>更新従業員コードプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 更新従業員コードプロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
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

		/// public propaty name  :	UpdAssemblyId1
		/// <summary>更新アセンブリID1プロパティ</summary>
		/// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 更新アセンブリID1プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
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

		/// public propaty name  :	UpdAssemblyId2
		/// <summary>更新アセンブリID2プロパティ</summary>
		/// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 更新アセンブリID2プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
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

		/// public propaty name  :	LogicalDeleteCode
		/// <summary>論理削除区分プロパティ</summary>
		/// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 論理削除区分プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
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

		/// public propaty name  :	SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 拠点コードプロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
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
		/// public propaty name  :	ApplyDate
		/// <summary>適用年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 適用年月日プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public DateTime ApplyDate
		{
			get
			{
				return _applyDate;
			}
			set
			{
				_applyDate = value;
			}
		}

		/// public propaty name  :	ApplyDateJpFormal
		/// <summary>適用年月日 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 適用年月日 和暦プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public string ApplyDateJpFormal
		{
			get
			{
				return TDateTime.DateTimeToString("GGYYMMDD", _applyDate);
			}
			set
			{
			}
		}

		/// public propaty name  :	ApplyDateJpInFormal
		/// <summary>適用年月日 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 適用年月日 和暦(略)プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public string ApplyDateJpInFormal
		{
			get
			{
				return TDateTime.DateTimeToString("ggYY/MM/DD", _applyDate);
			}
			set
			{
			}
		}

		/// public propaty name  : ApplyDateAdFormal
		/// <summary>適用年月日 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 適用年月日 西暦プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public string ApplyDateAdFormal
		{
			get
			{
				return TDateTime.DateTimeToString("YYYY/MM/DD", _applyDate);
			}
			set
			{
			}
		}

		/// public propaty name  :	ApplyDateAdInFormal
		/// <summary>適用年月日 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 適用年月日 西暦(略)プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public string ApplyDateAdInFormal
		{
			get
			{
				return TDateTime.DateTimeToString("YY/MM/DD", _applyDate);
			}
			set
			{
			}
		}

		/// public propaty name  :	ApplyDateCd
		/// <summary>適用区分プロパティ</summary>
		/// <value>0:休業日　1:祝祭日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 適用区分プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public Int32 ApplyDateCd
		{
			get
			{
				return _applyDateCd;
			}
			set
			{
				_applyDateCd = value;
			}
		}

		/// public propaty name  :	SectionName
		/// <summary>拠点名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note			:　 拠点名称プロパティ</br>
		/// <br>Programmer		: 　NEPCO</br>
		/// </remarks>
		public string SectionName
		{
			get
			{
				return _sectionName;
			}
			set
			{
				_sectionName = value;
			}
		}

		/// <summary>
		/// 休業日設定マスタコンストラクタ
		/// </summary>
		/// <returns>HolidaySettingクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 HolidaySettingクラスの新しいインスタンスを生成します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public HolidaySetting()
		{
		}

		/// <summary>
		/// 休業日設定マスタコンストラクタ
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
		/// <param name="applyDate">適用年月日（YYYYMMDD）</param>
		/// <param name="applyDateCd">適用区分（0:休業日　1:祝祭日）</param>
		/// <param name="sectionName">拠点名称</param>
		/// <returns>HolidaySettingクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 HolidaySettingクラスの新しいインスタンスを生成します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public HolidaySetting(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, DateTime applyDate, Int32 applyDateCd, string sectionName)
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
			this._applyDate = applyDate;
			this._applyDateCd = applyDateCd;
			this._sectionName = sectionName;

		}

		/// <summary>
		/// 休業日設定マスタ複製処理
		/// </summary>
		/// <returns>HolidaySettingクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 自身の内容と等しいHolidaySettingクラスのインスタンスを返します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public HolidaySetting Clone()
		{
			return new HolidaySetting(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._applyDate, this._applyDateCd, this._sectionName);
		}

		/// <summary>
		/// 休業日設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のHolidaySettingクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 HolidaySettingクラスの内容が一致するか比較します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public bool Equals(HolidaySetting target)
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
				 && (this.ApplyDate == target.ApplyDate)
				 && (this.ApplyDateCd == target.ApplyDateCd)
				 && (this.SectionName == target.SectionName)
			);
		}

		/// <summary>
		/// 休業日設定マスタ比較処理
		/// </summary>
		/// <param name="holidaySetting1">
		/// 				   比較するHolidaySettingクラスのインスタンス
		/// </param>
		/// <param name="holidaySetting2">比較するHolidaySettingクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 HolidaySettingクラスの内容が一致するか比較します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public static bool Equals(HolidaySetting holidaySetting1, HolidaySetting holidaySetting2)
		{
			return ((holidaySetting1.CreateDateTime == holidaySetting2.CreateDateTime)
				 && (holidaySetting1.UpdateDateTime == holidaySetting2.UpdateDateTime)
				 && (holidaySetting1.EnterpriseCode == holidaySetting2.EnterpriseCode)
				 && (holidaySetting1.FileHeaderGuid == holidaySetting2.FileHeaderGuid)
				 && (holidaySetting1.UpdEmployeeCode == holidaySetting2.UpdEmployeeCode)
				 && (holidaySetting1.UpdAssemblyId1 == holidaySetting2.UpdAssemblyId1)
				 && (holidaySetting1.UpdAssemblyId2 == holidaySetting2.UpdAssemblyId2)
				 && (holidaySetting1.LogicalDeleteCode == holidaySetting2.LogicalDeleteCode)
				 && (holidaySetting1.SectionCode == holidaySetting2.SectionCode)
				 && (holidaySetting1.ApplyDate == holidaySetting2.ApplyDate)
				 && (holidaySetting1.ApplyDateCd == holidaySetting2.ApplyDateCd)
				 && (holidaySetting1.SectionName == holidaySetting2.SectionName)
				 );
		}
		/// <summary>
		/// 休業日設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のHolidaySettingクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 HolidaySettingクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public ArrayList Compare(HolidaySetting target)
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
			if (this.ApplyDate != target.ApplyDate)
				resList.Add("ApplyDate");
			if (this.ApplyDateCd != target.ApplyDateCd)
				resList.Add("ApplyDateCd");
			if (this.SectionName != target.SectionName)
				resList.Add("SectionName");

			return resList;
		}

		/// <summary>
		/// 休業日設定マスタ比較処理
		/// </summary>
		/// <param name="holidaySetting1">比較するHolidaySettingクラスのインスタンス</param>
		/// <param name="holidaySetting2">比較するHolidaySettingクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 HolidaySettingクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public static ArrayList Compare(HolidaySetting holidaySetting1, HolidaySetting holidaySetting2)
		{
			ArrayList resList = new ArrayList();
			if (holidaySetting1.CreateDateTime != holidaySetting2.CreateDateTime)
				resList.Add("CreateDateTime");
			if (holidaySetting1.UpdateDateTime != holidaySetting2.UpdateDateTime)
				resList.Add("UpdateDateTime");
			if (holidaySetting1.EnterpriseCode != holidaySetting2.EnterpriseCode)
				resList.Add("EnterpriseCode");
			if (holidaySetting1.FileHeaderGuid != holidaySetting2.FileHeaderGuid)
				resList.Add("FileHeaderGuid");
			if (holidaySetting1.UpdEmployeeCode != holidaySetting2.UpdEmployeeCode)
				resList.Add("UpdEmployeeCode");
			if (holidaySetting1.UpdAssemblyId1 != holidaySetting2.UpdAssemblyId1)
				resList.Add("UpdAssemblyId1");
			if (holidaySetting1.UpdAssemblyId2 != holidaySetting2.UpdAssemblyId2)
				resList.Add("UpdAssemblyId2");
			if (holidaySetting1.LogicalDeleteCode != holidaySetting2.LogicalDeleteCode)
				resList.Add("LogicalDeleteCode");
			if (holidaySetting1.SectionCode != holidaySetting2.SectionCode)
				resList.Add("SectionCode");
			if (holidaySetting1.ApplyDate != holidaySetting2.ApplyDate)
				resList.Add("ApplyDate");
			if (holidaySetting1.ApplyDateCd != holidaySetting2.ApplyDateCd)
				resList.Add("ApplyDateCd)");
			if (holidaySetting1.SectionName != holidaySetting2.SectionName)
				resList.Add("SectionName");

			return resList;
		}
	}
}
