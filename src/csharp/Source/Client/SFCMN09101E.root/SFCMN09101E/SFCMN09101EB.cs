using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   NoTypeMng
	/// <summary>
	///                      番号タイプ管理マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   番号タイプ管理マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2005/8/30</br>
	/// <br>Genarated Date   :   2006/08/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class NoTypeMng
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

		/// <summary>番号コード</summary>
		/// <remarks>1:顧客ｺｰﾄﾞ,2:車両管理番号,･･･つづきあり(項目詳細)</remarks>
		private Int32 _noCode;

		/// <summary>番号名称</summary>
		private string _noName = "";

		/// <summary>番号項目型</summary>
		/// <remarks>0:数値 1:文字</remarks>
		private Int32 _noItemPatternCd;

		/// <summary>番号桁数</summary>
		private Int32 _noCharcterCount;

		/// <summary>番号連番桁数</summary>
		private Int32 _consNoCharcterCount;

		/// <summary>番号表示位置区分</summary>
		/// <remarks>0:右詰め 1:左詰め</remarks>
		private Int32 _noDispPositionDivCd;

		/// <summary>番号採番区分</summary>
		/// <remarks>0:自動採番無し 1:自動採番有り</remarks>
		private Int32 _numberingDivCd;

		/// <summary>番号採番タイプ</summary>
		/// <remarks>0:連番 1:月更新ﾀｲﾌﾟ1 2:年更新ﾀｲﾌﾟ1 ※1</remarks>
		private Int32 _numberingTypeDivCd;

		/// <summary>番号採番範囲</summary>
		/// <remarks>0:企業通番(拠点括り無し) 1:企業通番(拠点括り有り) 2:拠点通番</remarks>
		private Int32 _numberingAmbitDivCd;

		/// <summary>番号リセットタイミング</summary>
		/// <remarks>0:設定終了番号 1:年 2:月 3:日</remarks>
		private Int32 _noResetTimingDivCd;

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

		/// public propaty name  :  NoItemPatternCd
		/// <summary>番号項目型プロパティ</summary>
		/// <value>0:数値 1:文字</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   番号項目型プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NoItemPatternCd
		{
			get
			{
				return _noItemPatternCd;
			}
			set
			{
				_noItemPatternCd = value;
			}
		}

		/// public propaty name  :  NoCharcterCount
		/// <summary>番号桁数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   番号桁数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NoCharcterCount
		{
			get
			{
				return _noCharcterCount;
			}
			set
			{
				_noCharcterCount = value;
			}
		}

		/// public propaty name  :  ConsNoCharcterCount
		/// <summary>番号連番桁数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   番号連番桁数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ConsNoCharcterCount
		{
			get
			{
				return _consNoCharcterCount;
			}
			set
			{
				_consNoCharcterCount = value;
			}
		}

		/// public propaty name  :  NoDispPositionDivCd
		/// <summary>番号表示位置区分プロパティ</summary>
		/// <value>0:右詰め 1:左詰め</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   番号表示位置区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NoDispPositionDivCd
		{
			get
			{
				return _noDispPositionDivCd;
			}
			set
			{
				_noDispPositionDivCd = value;
			}
		}

		/// public propaty name  :  NumberingDivCd
		/// <summary>番号採番区分プロパティ</summary>
		/// <value>0:自動採番無し 1:自動採番有り</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   番号採番区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NumberingDivCd
		{
			get
			{
				return _numberingDivCd;
			}
			set
			{
				_numberingDivCd = value;
			}
		}

		/// public propaty name  :  NumberingTypeDivCd
		/// <summary>番号採番タイププロパティ</summary>
		/// <value>0:連番 1:月更新ﾀｲﾌﾟ1 2:年更新ﾀｲﾌﾟ1 ※1</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   番号採番タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NumberingTypeDivCd
		{
			get
			{
				return _numberingTypeDivCd;
			}
			set
			{
				_numberingTypeDivCd = value;
			}
		}

		/// public propaty name  :  NumberingAmbitDivCd
		/// <summary>番号採番範囲プロパティ</summary>
		/// <value>0:企業通番(拠点括り無し) 1:企業通番(拠点括り有り) 2:拠点通番</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   番号採番範囲プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NumberingAmbitDivCd
		{
			get
			{
				return _numberingAmbitDivCd;
			}
			set
			{
				_numberingAmbitDivCd = value;
			}
		}

		/// public propaty name  :  NoResetTimingDivCd
		/// <summary>番号リセットタイミングプロパティ</summary>
		/// <value>0:設定終了番号 1:年 2:月 3:日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   番号リセットタイミングプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NoResetTimingDivCd
		{
			get
			{
				return _noResetTimingDivCd;
			}
			set
			{
				_noResetTimingDivCd = value;
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
		/// 番号タイプ管理マスタコンストラクタ
		/// </summary>
		/// <returns>NoTypeMngクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoTypeMngクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public NoTypeMng()
		{
		}

		/// <summary>
		/// 番号タイプ管理マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="noCode">番号コード(1:顧客ｺｰﾄﾞ,2:車両管理番号,･･･つづきあり(項目詳細))</param>
		/// <param name="noName">番号名称</param>
		/// <param name="noItemPatternCd">番号項目型(0:数値 1:文字)</param>
		/// <param name="noCharcterCount">番号桁数</param>
		/// <param name="consNoCharcterCount">番号連番桁数</param>
		/// <param name="noDispPositionDivCd">番号表示位置区分(0:右詰め 1:左詰め)</param>
		/// <param name="numberingDivCd">番号採番区分(0:自動採番無し 1:自動採番有り)</param>
		/// <param name="numberingTypeDivCd">番号採番タイプ(0:連番 1:月更新ﾀｲﾌﾟ1 2:年更新ﾀｲﾌﾟ1 ※1)</param>
		/// <param name="numberingAmbitDivCd">番号採番範囲(0:企業通番(拠点括り無し) 1:企業通番(拠点括り有り) 2:拠点通番)</param>
		/// <param name="noResetTimingDivCd">番号リセットタイミング(0:設定終了番号 1:年 2:月 3:日)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>NoTypeMngクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoTypeMngクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public NoTypeMng(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 noCode, string noName, Int32 noItemPatternCd, Int32 noCharcterCount, Int32 consNoCharcterCount, Int32 noDispPositionDivCd, Int32 numberingDivCd, Int32 numberingTypeDivCd, Int32 numberingAmbitDivCd, Int32 noResetTimingDivCd, string enterpriseName, string updEmployeeName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._noCode = noCode;
			this._noName = noName;
			this._noItemPatternCd = noItemPatternCd;
			this._noCharcterCount = noCharcterCount;
			this._consNoCharcterCount = consNoCharcterCount;
			this._noDispPositionDivCd = noDispPositionDivCd;
			this._numberingDivCd = numberingDivCd;
			this._numberingTypeDivCd = numberingTypeDivCd;
			this._numberingAmbitDivCd = numberingAmbitDivCd;
			this._noResetTimingDivCd = noResetTimingDivCd;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// 番号タイプ管理マスタ複製処理
		/// </summary>
		/// <returns>NoTypeMngクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいNoTypeMngクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public NoTypeMng Clone()
		{
			return new NoTypeMng(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._noCode, this._noName, this._noItemPatternCd, this._noCharcterCount, this._consNoCharcterCount, this._noDispPositionDivCd, this._numberingDivCd, this._numberingTypeDivCd, this._numberingAmbitDivCd, this._noResetTimingDivCd, this._enterpriseName, this._updEmployeeName);
		}

		/// <summary>
		/// 番号タイプ管理マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のNoTypeMngクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoTypeMngクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(NoTypeMng target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.NoCode == target.NoCode)
				 && (this.NoName == target.NoName)
				 && (this.NoItemPatternCd == target.NoItemPatternCd)
				 && (this.NoCharcterCount == target.NoCharcterCount)
				 && (this.ConsNoCharcterCount == target.ConsNoCharcterCount)
				 && (this.NoDispPositionDivCd == target.NoDispPositionDivCd)
				 && (this.NumberingDivCd == target.NumberingDivCd)
				 && (this.NumberingTypeDivCd == target.NumberingTypeDivCd)
				 && (this.NumberingAmbitDivCd == target.NumberingAmbitDivCd)
				 && (this.NoResetTimingDivCd == target.NoResetTimingDivCd)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// 番号タイプ管理マスタ比較処理
		/// </summary>
		/// <param name="noTypeMng1">
		///                    比較するNoTypeMngクラスのインスタンス
		/// </param>
		/// <param name="noTypeMng2">比較するNoTypeMngクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoTypeMngクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(NoTypeMng noTypeMng1, NoTypeMng noTypeMng2)
		{
			return ((noTypeMng1.CreateDateTime == noTypeMng2.CreateDateTime)
				 && (noTypeMng1.UpdateDateTime == noTypeMng2.UpdateDateTime)
				 && (noTypeMng1.EnterpriseCode == noTypeMng2.EnterpriseCode)
				 && (noTypeMng1.FileHeaderGuid == noTypeMng2.FileHeaderGuid)
				 && (noTypeMng1.UpdEmployeeCode == noTypeMng2.UpdEmployeeCode)
				 && (noTypeMng1.UpdAssemblyId1 == noTypeMng2.UpdAssemblyId1)
				 && (noTypeMng1.UpdAssemblyId2 == noTypeMng2.UpdAssemblyId2)
				 && (noTypeMng1.LogicalDeleteCode == noTypeMng2.LogicalDeleteCode)
				 && (noTypeMng1.NoCode == noTypeMng2.NoCode)
				 && (noTypeMng1.NoName == noTypeMng2.NoName)
				 && (noTypeMng1.NoItemPatternCd == noTypeMng2.NoItemPatternCd)
				 && (noTypeMng1.NoCharcterCount == noTypeMng2.NoCharcterCount)
				 && (noTypeMng1.ConsNoCharcterCount == noTypeMng2.ConsNoCharcterCount)
				 && (noTypeMng1.NoDispPositionDivCd == noTypeMng2.NoDispPositionDivCd)
				 && (noTypeMng1.NumberingDivCd == noTypeMng2.NumberingDivCd)
				 && (noTypeMng1.NumberingTypeDivCd == noTypeMng2.NumberingTypeDivCd)
				 && (noTypeMng1.NumberingAmbitDivCd == noTypeMng2.NumberingAmbitDivCd)
				 && (noTypeMng1.NoResetTimingDivCd == noTypeMng2.NoResetTimingDivCd)
				 && (noTypeMng1.EnterpriseName == noTypeMng2.EnterpriseName)
				 && (noTypeMng1.UpdEmployeeName == noTypeMng2.UpdEmployeeName));
		}
		/// <summary>
		/// 番号タイプ管理マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のNoTypeMngクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoTypeMngクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(NoTypeMng target)
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
			if (this.NoCode != target.NoCode)
				resList.Add("NoCode");
			if (this.NoName != target.NoName)
				resList.Add("NoName");
			if (this.NoItemPatternCd != target.NoItemPatternCd)
				resList.Add("NoItemPatternCd");
			if (this.NoCharcterCount != target.NoCharcterCount)
				resList.Add("NoCharcterCount");
			if (this.ConsNoCharcterCount != target.ConsNoCharcterCount)
				resList.Add("ConsNoCharcterCount");
			if (this.NoDispPositionDivCd != target.NoDispPositionDivCd)
				resList.Add("NoDispPositionDivCd");
			if (this.NumberingDivCd != target.NumberingDivCd)
				resList.Add("NumberingDivCd");
			if (this.NumberingTypeDivCd != target.NumberingTypeDivCd)
				resList.Add("NumberingTypeDivCd");
			if (this.NumberingAmbitDivCd != target.NumberingAmbitDivCd)
				resList.Add("NumberingAmbitDivCd");
			if (this.NoResetTimingDivCd != target.NoResetTimingDivCd)
				resList.Add("NoResetTimingDivCd");
			if (this.EnterpriseName != target.EnterpriseName)
				resList.Add("EnterpriseName");
			if (this.UpdEmployeeName != target.UpdEmployeeName)
				resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// 番号タイプ管理マスタ比較処理
		/// </summary>
		/// <param name="noTypeMng1">比較するNoTypeMngクラスのインスタンス</param>
		/// <param name="noTypeMng2">比較するNoTypeMngクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   NoTypeMngクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(NoTypeMng noTypeMng1, NoTypeMng noTypeMng2)
		{
			ArrayList resList = new ArrayList();
			if (noTypeMng1.CreateDateTime != noTypeMng2.CreateDateTime)
				resList.Add("CreateDateTime");
			if (noTypeMng1.UpdateDateTime != noTypeMng2.UpdateDateTime)
				resList.Add("UpdateDateTime");
			if (noTypeMng1.EnterpriseCode != noTypeMng2.EnterpriseCode)
				resList.Add("EnterpriseCode");
			if (noTypeMng1.FileHeaderGuid != noTypeMng2.FileHeaderGuid)
				resList.Add("FileHeaderGuid");
			if (noTypeMng1.UpdEmployeeCode != noTypeMng2.UpdEmployeeCode)
				resList.Add("UpdEmployeeCode");
			if (noTypeMng1.UpdAssemblyId1 != noTypeMng2.UpdAssemblyId1)
				resList.Add("UpdAssemblyId1");
			if (noTypeMng1.UpdAssemblyId2 != noTypeMng2.UpdAssemblyId2)
				resList.Add("UpdAssemblyId2");
			if (noTypeMng1.LogicalDeleteCode != noTypeMng2.LogicalDeleteCode)
				resList.Add("LogicalDeleteCode");
			if (noTypeMng1.NoCode != noTypeMng2.NoCode)
				resList.Add("NoCode");
			if (noTypeMng1.NoName != noTypeMng2.NoName)
				resList.Add("NoName");
			if (noTypeMng1.NoItemPatternCd != noTypeMng2.NoItemPatternCd)
				resList.Add("NoItemPatternCd");
			if (noTypeMng1.NoCharcterCount != noTypeMng2.NoCharcterCount)
				resList.Add("NoCharcterCount");
			if (noTypeMng1.ConsNoCharcterCount != noTypeMng2.ConsNoCharcterCount)
				resList.Add("ConsNoCharcterCount");
			if (noTypeMng1.NoDispPositionDivCd != noTypeMng2.NoDispPositionDivCd)
				resList.Add("NoDispPositionDivCd");
			if (noTypeMng1.NumberingDivCd != noTypeMng2.NumberingDivCd)
				resList.Add("NumberingDivCd");
			if (noTypeMng1.NumberingTypeDivCd != noTypeMng2.NumberingTypeDivCd)
				resList.Add("NumberingTypeDivCd");
			if (noTypeMng1.NumberingAmbitDivCd != noTypeMng2.NumberingAmbitDivCd)
				resList.Add("NumberingAmbitDivCd");
			if (noTypeMng1.NoResetTimingDivCd != noTypeMng2.NoResetTimingDivCd)
				resList.Add("NoResetTimingDivCd");
			if (noTypeMng1.EnterpriseName != noTypeMng2.EnterpriseName)
				resList.Add("EnterpriseName");
			if (noTypeMng1.UpdEmployeeName != noTypeMng2.UpdEmployeeName)
				resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}
