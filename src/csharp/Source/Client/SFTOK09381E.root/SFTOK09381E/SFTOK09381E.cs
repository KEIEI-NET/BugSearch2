using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 取得対象データ定数（ユーザーガイド用）
	/// </summary>
	/// <br>Note       : ユーザーガイドマスタの取得対象データ（ガイド区分）の列挙型です。</br>
	/// <br>Programmer : 22024　寺坂　誉志</br>
	/// <br>Date       : 2005.06.14</br>
	public enum UserGdGuideDivCodeAcsData
	{
		/// <summary>
		/// 役職区分
		/// </summary>
		PostCode = 32,
		/// <summary>
		/// 業務区分
		/// </summary>
		BusinessCode = 31
	}

	/// public class name:   Employee
	/// <summary>
	///                      従業員クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   従業員クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2005/3/4</br>
	/// <br>Genarated Date   :   2005/03/19  (CSharp File Generated Date)</br>
	/// <br></br>
	/// <br>Update Note		 : 2006.06.20 23001 秋山　亮介</br>
	/// <br>                        1.レバレート原価類のDDの変更対応</br>
	/// <br>Update Note		 : 2006.07.31 22033 三崎  貴史</br>
	/// <br>                        1.namespace変更対応</br>
	/// <br>Update Note		 : 2012.05.09 30182 立谷　亮介</br>
	/// <br>						1.「売上伝票入力起動枚数」「得意先電子元帳起動枚数」項目追加</br>
	/// </remarks>
	public class Employee
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
		private Int32 _logicalDeleteCode;

		/// <summary>従業員コード</summary>
		private string _employeeCode = "";

		/// <summary>名称</summary>
		private string _name = "";

		/// <summary>カナ</summary>
		private string _kana = "";

		/// <summary>短縮名称</summary>
		private string _shortName = "";

		/// <summary>性別コード</summary>
		private Int32 _sexCode;

		/// <summary>性別名称</summary>
		/// <remarks>全角で管理</remarks>
		private string _sexName = "";

		/// <summary>生年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _birthday;

		/// <summary>電話番号（会社）</summary>
		private string _companyTelNo = "";

		/// <summary>電話番号（携帯）</summary>
		private string _portableTelNo = "";

		/// <summary>役職コード</summary>
		private Int32 _postCode;

		/// <summary>業務区分</summary>
		private Int32 _businessCode;

		/// <summary>受付・メカ区分</summary>
		private Int32 _frontMechaCode;

		/// <summary>社内外区分</summary>
		private Int32 _inOutsideCompanyCode;

		/// <summary>所属拠点コード</summary>
		private string _belongSectionCode = "";

		/// <summary>レバレート原価（一般）</summary>
		private Int64 _lvrRtCstGeneral;

		/// <summary>レバレート原価（車検）</summary>
		private Int64 _lvrRtCstCarInspect;

		/// <summary>レバレート原価（塗装）</summary>
		private Int64 _lvrRtCstBodyPaint;

		/// <summary>レバレート原価（鈑金）</summary>
		private Int64 _lvrRtCstBodyRepair;

		/// <summary>ログインID</summary>
		private string _loginId = "";

		/// <summary>ログインパスワード</summary>
		private string _loginPassword = "";

		/// <summary>ユーザー管理者フラグ</summary>
		private Int32 _userAdminFlag;

		/// <summary>入社日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _enterCompanyDate;

		/// <summary>退職日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _retirementDate;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

		/// <summary>役職名称</summary>
		private string _postName = "";

		/// <summary>業務区分名称</summary>
		private string _businessName = "";

		/// <summary>受付・メカ区分名称</summary>
		private string _frontMechaName = "";

		/// <summary>所属拠点名称</summary>
		private string _belongSectionName = "";

		/// <summary>社内外区分名称</summary>
		/// <remarks>社内,社外</remarks>
		private string _inOutsideCompanyName = "";

		/// <summary>ユーザー管理者表示名称</summary>
		private string _userAdminName = "";

        /// <summary>権限レベル1(職種)</summary>
        private int _authorityLevel1;

        /// <summary>権限レベル2(雇用形態)</summary>
        private int _authorityLevel2;

		// -- Add St 2012.05.29 30182 R.Tachiya --
		/// <summary>売上伝票入力起動枚数</summary>
		private int _salSlipInpBootCnt;

		/// <summary>得意先電子元帳起動枚数</summary>
		private int _custLedgerBootCnt;		
		// -- Add Ed 2012.05.29 30182 R.Tachiya --

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

		/// public propaty name  :  EmployeeCode
		/// <summary>従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EmployeeCode
		{
			get
			{
				return _employeeCode;
			}
			set
			{
				_employeeCode = value;
			}
		}

		/// public propaty name  :  Name
		/// <summary>名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		/// public propaty name  :  Kana
		/// <summary>カナプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Kana
		{
			get
			{
				return _kana;
			}
			set
			{
				_kana = value;
			}
		}

		/// public propaty name  :  ShortName
		/// <summary>短縮名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   短縮名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ShortName
		{
			get
			{
				return _shortName;
			}
			set
			{
				_shortName = value;
			}
		}

		/// public propaty name  :  SexCode
		/// <summary>性別コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   性別コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SexCode
		{
			get
			{
				return _sexCode;
			}
			set
			{
				_sexCode = value;
			}
		}

		/// public propaty name  :  SexName
		/// <summary>性別名称プロパティ</summary>
		/// <value>全角で管理</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   性別名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SexName
		{
			get
			{
				return _sexName;
			}
			set
			{
				_sexName = value;
			}
		}

		/// public propaty name  :  Birthday
		/// <summary>生年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   生年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Birthday
		{
			get
			{
				return _birthday;
			}
			set
			{
				_birthday = value;
			}
		}

		/// public propaty name  :  BirthdayJpFormal
		/// <summary>生年月日 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   生年月日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BirthdayJpFormal
		{
			get
			{
				return TDateTime.DateTimeToString("GGYYMMDD", _birthday);
			}
			set
			{
			}
		}

		/// public propaty name  :  BirthdayJpInFormal
		/// <summary>生年月日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   生年月日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BirthdayJpInFormal
		{
			get
			{
				return TDateTime.DateTimeToString("ggYY/MM/DD", _birthday);
			}
			set
			{
			}
		}

		/// public propaty name  :  BirthdayAdFormal
		/// <summary>生年月日 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   生年月日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BirthdayAdFormal
		{
			get
			{
				return TDateTime.DateTimeToString("YYYY/MM/DD", _birthday);
			}
			set
			{
			}
		}

		/// public propaty name  :  BirthdayAdInFormal
		/// <summary>生年月日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   生年月日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BirthdayAdInFormal
		{
			get
			{
				return TDateTime.DateTimeToString("YY/MM/DD", _birthday);
			}
			set
			{
			}
		}

		/// public propaty name  :  CompanyTelNo
		/// <summary>電話番号（会社）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（会社）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CompanyTelNo
		{
			get
			{
				return _companyTelNo;
			}
			set
			{
				_companyTelNo = value;
			}
		}

		/// public propaty name  :  PortableTelNo
		/// <summary>電話番号（携帯）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（携帯）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PortableTelNo
		{
			get
			{
				return _portableTelNo;
			}
			set
			{
				_portableTelNo = value;
			}
		}

		/// public propaty name  :  PostCode
		/// <summary>役職コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   役職コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PostCode
		{
			get
			{
				return _postCode;
			}
			set
			{
				_postCode = value;
			}
		}

		/// public propaty name  :  BusinessCode
		/// <summary>業務区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   業務区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BusinessCode
		{
			get
			{
				return _businessCode;
			}
			set
			{
				_businessCode = value;
			}
		}

		/// public propaty name  :  FrontMechaCode
		/// <summary>受付・メカ区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受付・メカ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FrontMechaCode
		{
			get
			{
				return _frontMechaCode;
			}
			set
			{
				_frontMechaCode = value;
			}
		}

		/// public propaty name  :  InOutsideCompanyCode
		/// <summary>社内外区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   社内外区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InOutsideCompanyCode
		{
			get
			{
				return _inOutsideCompanyCode;
			}
			set
			{
				_inOutsideCompanyCode = value;
			}
		}

		/// public propaty name  :  BelongSectionCode
		/// <summary>所属拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   所属拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BelongSectionCode
		{
			get
			{
				return _belongSectionCode;
			}
			set
			{
				_belongSectionCode = value;
			}
		}

		/// public propaty name  :  LvrRtCstGeneral
		/// <summary>レバレート原価（一般）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   レバレート原価（一般）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 LvrRtCstGeneral
		{
			get
			{
				return _lvrRtCstGeneral;
			}
			set
			{
				_lvrRtCstGeneral = value;
			}
		}

		/// public propaty name  :  LvrRtCstCarInspect
		/// <summary>レバレート原価（車検）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   レバレート原価（車検）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 LvrRtCstCarInspect
		{
			get
			{
				return _lvrRtCstCarInspect;
			}
			set
			{
				_lvrRtCstCarInspect = value;
			}
		}

		/// public propaty name  :  LvrRtCstBodyPaint
		/// <summary>レバレート原価（塗装）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   レバレート原価（塗装）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 LvrRtCstBodyPaint
		{
			get
			{
				return _lvrRtCstBodyPaint;
			}
			set
			{
				_lvrRtCstBodyPaint = value;
			}
		}

		/// public propaty name  :  LvrRtCstBodyRepair
		/// <summary>レバレート原価（鈑金）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   レバレート原価（鈑金）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 LvrRtCstBodyRepair
		{
			get
			{
				return _lvrRtCstBodyRepair;
			}
			set
			{
				_lvrRtCstBodyRepair = value;
			}
		}

		/// public propaty name  :  LoginId
		/// <summary>ログインIDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ログインIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LoginId
		{
			get
			{
				return _loginId;
			}
			set
			{
				_loginId = value;
			}
		}

		/// public propaty name  :  LoginPassword
		/// <summary>ログインパスワードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ログインパスワードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LoginPassword
		{
			get
			{
				return _loginPassword;
			}
			set
			{
				_loginPassword = value;
			}
		}

		/// public propaty name  :  UserAdminFlag
		/// <summary>ユーザー管理者フラグプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ユーザー管理者フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UserAdminFlag
		{
			get
			{
				return _userAdminFlag;
			}
			set
			{
				_userAdminFlag = value;
			}
		}

		/// public propaty name  :  EnterCompanyDate
		/// <summary>入社日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入社日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime EnterCompanyDate
		{
			get
			{
				return _enterCompanyDate;
			}
			set
			{
				_enterCompanyDate = value;
			}
		}

		/// public propaty name  :  EnterCompanyDateJpFormal
		/// <summary>入社日 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入社日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterCompanyDateJpFormal
		{
			get
			{
				return TDateTime.DateTimeToString("GGYYMMDD", _enterCompanyDate);
			}
			set
			{
			}
		}

		/// public propaty name  :  EnterCompanyDateJpInFormal
		/// <summary>入社日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入社日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterCompanyDateJpInFormal
		{
			get
			{
				return TDateTime.DateTimeToString("ggYY/MM/DD", _enterCompanyDate);
			}
			set
			{
			}
		}

		/// public propaty name  :  EnterCompanyDateAdFormal
		/// <summary>入社日 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入社日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterCompanyDateAdFormal
		{
			get
			{
				return TDateTime.DateTimeToString("YYYY/MM/DD", _enterCompanyDate);
			}
			set
			{
			}
		}

		/// public propaty name  :  EnterCompanyDateAdInFormal
		/// <summary>入社日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入社日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterCompanyDateAdInFormal
		{
			get
			{
				return TDateTime.DateTimeToString("YY/MM/DD", _enterCompanyDate);
			}
			set
			{
			}
		}

		/// public propaty name  :  RetirementDate
		/// <summary>退職日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   退職日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime RetirementDate
		{
			get
			{
				return _retirementDate;
			}
			set
			{
				_retirementDate = value;
			}
		}

		/// public propaty name  :  RetirementDateJpFormal
		/// <summary>退職日 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   退職日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RetirementDateJpFormal
		{
			get
			{
				return TDateTime.DateTimeToString("GGYYMMDD", _retirementDate);
			}
			set
			{
			}
		}

		/// public propaty name  :  RetirementDateJpInFormal
		/// <summary>退職日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   退職日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RetirementDateJpInFormal
		{
			get
			{
				return TDateTime.DateTimeToString("ggYY/MM/DD", _retirementDate);
			}
			set
			{
			}
		}

		/// public propaty name  :  RetirementDateAdFormal
		/// <summary>退職日 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   退職日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RetirementDateAdFormal
		{
			get
			{
				return TDateTime.DateTimeToString("YYYY/MM/DD", _retirementDate);
			}
			set
			{
			}
		}

		/// public propaty name  :  RetirementDateAdInFormal
		/// <summary>退職日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   退職日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RetirementDateAdInFormal
		{
			get
			{
				return TDateTime.DateTimeToString("YY/MM/DD", _retirementDate);
			}
			set
			{
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

		/// public propaty name  :  PostName
		/// <summary>役職名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   役職名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PostName
		{
			get
			{
				return _postName;
			}
			set
			{
				_postName = value;
			}
		}

		/// public propaty name  :  BusinessName
		/// <summary>業務区分名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   業務区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BusinessName
		{
			get
			{
				return _businessName;
			}
			set
			{
				_businessName = value;
			}
		}

		/// public propaty name  :  FrontMechaName
		/// <summary>受付・メカ区分名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受付・メカ区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FrontMechaName
		{
			get
			{
				return _frontMechaName;
			}
			set
			{
				_frontMechaName = value;
			}
		}

		/// public propaty name  :  BelongSectionName
		/// <summary>所属拠点名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   所属拠点名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BelongSectionName
		{
			get
			{
				return _belongSectionName;
			}
			set
			{
				_belongSectionName = value;
			}
		}

		/// public propaty name  :  InOutsideCompanyName
		/// <summary>社内外区分名称プロパティ</summary>
		/// <value>社内,社外</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   社内外区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InOutsideCompanyName
		{
			get
			{
				return _inOutsideCompanyName;
			}
			set
			{
				_inOutsideCompanyName = value;
			}
		}

		/// public propaty name  :  UserAdminName
		/// <summary>ユーザー管理者表示名称</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ユーザー管理者表示名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UserAdminName
		{
			get
			{
				return _userAdminName;
			}
			set
			{
				_userAdminName = value;
			}
		}

        /// public propaty name  :  AuthorityLevel1
        /// <summary>権限レベル1(職種)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   権限レベル1(職種)プロパティ</br>
        /// <br>Programer        :   20008 伊藤　豊</br>
        /// </remarks>
        public int AuthorityLevel1
        {
            get
            {
                return _authorityLevel1;
            }
            set
            {
                _authorityLevel1 = value;
            }
        }

        /// public propaty name  :  AuthorityLevel2
        /// <summary>権限レベル2(雇用形態)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   権限レベル2(雇用形態)プロパティ</br>
        /// <br>Programer        :   20008 伊藤　豊</br>
        /// </remarks>
        public int AuthorityLevel2
        {
            get
            {
                return _authorityLevel2;
            }
            set
            {
                _authorityLevel2 = value;
            }
        }

		// -- Add St 2012.05.29 30182 R.Tachiya --
		/// public propaty name  :  SalSlipInpBootCnt
		/// <summary>売上伝票入力起動枚数</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票入力起動枚数プロパティ</br>
		/// <br>Programer        :   30182 立谷　亮介</br>
		/// </remarks>
		public int SalSlipInpBootCnt
        {
            get
            {
				return _salSlipInpBootCnt;
            }
            set
            {
				_salSlipInpBootCnt = value;
            }
        }

		/// public propaty name  :  CustLedgerBootCnt
		/// <summary>得意先電子元帳起動枚数</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先電子元帳起動枚数プロパティ</br>
		/// <br>Programer        :   30182 立谷　亮介</br>
		/// </remarks>
		public int CustLedgerBootCnt
        {
            get
            {
				return _custLedgerBootCnt;
            }
            set
            {
				_custLedgerBootCnt = value;
            }
        }
		// -- Add Ed 2012.05.29 30182 R.Tachiya --

        /// <summary>
		/// 従業員マスタコンストラクタ
		/// </summary>
		/// <returns>Employeeクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Employeeクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Employee()
		{
		}

		/// <summary>
		/// 従業員マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分</param>
		/// <param name="employeeCode">従業員コード</param>
		/// <param name="name">名称</param>
		/// <param name="kana">カナ</param>
		/// <param name="shortName">短縮名称</param>
		/// <param name="sexCode">性別コード</param>
		/// <param name="sexName">性別名称(全角で管理)</param>
		/// <param name="birthday">生年月日(YYYYMMDD)</param>
		/// <param name="companyTelNo">電話番号（会社）</param>
		/// <param name="portableTelNo">電話番号（携帯）</param>
		/// <param name="postCode">役職コード</param>
		/// <param name="businessCode">業務区分</param>
		/// <param name="frontMechaCode">受付・メカ区分</param>
		/// <param name="inOutsideCompanyCode">社内外区分</param>
		/// <param name="belongSectionCode">所属拠点コード</param>
		/// <param name="lvrRtCstGeneral">レバレート原価（一般）</param>
		/// <param name="lvrRtCstCarInspect">レバレート原価（車検）</param>
		/// <param name="lvrRtCstBodyPaint">レバレート原価（塗装）</param>
		/// <param name="lvrRtCstBodyRepair">レバレート原価（鈑金）</param>
		/// <param name="loginId">ログインID</param>
		/// <param name="loginPassword">ログインパスワード</param>
		/// <param name="userAdminFlag">ユーザー管理者フラグ</param>
		/// <param name="enterCompanyDate">入社日(YYYYMMDD)</param>
		/// <param name="retirementDate">退職日(YYYYMMDD)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="postName">役職名称</param>
		/// <param name="businessName">業務区分名称</param>
		/// <param name="frontMechaName">受付・メカ区分名称</param>
		/// <param name="belongSectionName">所属拠点名称</param>
		/// <param name="inOutsideCompanyName">社内外区分名称(社内,社外)</param>
		/// <param name="userAdminName">ユーザー管理者表示名称</param>
        /// <param name="authorityLevel1">権限レベル1(職種)</param>
        /// <param name="authorityLevel2">権限レベル2(雇用形態)</param>
		/// <param name="salSlipInpBootCnt">売上伝票入力起動枚数</param>
		/// <param name="custLedgerBootCnt">得意先電子元帳起動枚数</param>
		/// <returns>Employeeクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Employeeクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Employee(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string employeeCode, string name, string kana, string shortName, Int32 sexCode, string sexName, DateTime birthday, string companyTelNo, string portableTelNo, Int32 postCode, Int32 businessCode, Int32 frontMechaCode, Int32 inOutsideCompanyCode, string belongSectionCode, Int64 lvrRtCstGeneral, Int64 lvrRtCstCarInspect, Int64 lvrRtCstBodyPaint, Int64 lvrRtCstBodyRepair, string loginId, string loginPassword, Int32 userAdminFlag, DateTime enterCompanyDate, DateTime retirementDate, string enterpriseName, string updEmployeeName, string postName, string businessName, string frontMechaName, string belongSectionName, string inOutsideCompanyName, string userAdminName, int authorityLevel1, int authorityLevel2, int salSlipInpBootCnt, int custLedgerBootCnt)// -- Add 2012.05.29 30182 R.Tachiya --
		//public Employee(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string employeeCode, string name, string kana, string shortName, Int32 sexCode, string sexName, DateTime birthday, string companyTelNo, string portableTelNo, Int32 postCode, Int32 businessCode, Int32 frontMechaCode, Int32 inOutsideCompanyCode, string belongSectionCode, Int64 lvrRtCstGeneral, Int64 lvrRtCstCarInspect, Int64 lvrRtCstBodyPaint, Int64 lvrRtCstBodyRepair, string loginId, string loginPassword, Int32 userAdminFlag, DateTime enterCompanyDate, DateTime retirementDate, string enterpriseName, string updEmployeeName, string postName, string businessName, string frontMechaName, string belongSectionName, string inOutsideCompanyName, string userAdminName, int authorityLevel1, int authorityLevel2)// -- Del 2012.05.29 30182 R.Tachiya --
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._employeeCode = employeeCode;
			this._name = name;
			this._kana = kana;
			this._shortName = shortName;
			this._sexCode = sexCode;
			this._sexName = sexName;
			this.Birthday = birthday;
			this._companyTelNo = companyTelNo;
			this._portableTelNo = portableTelNo;
			this._postCode = postCode;
			this._businessCode = businessCode;
			this._frontMechaCode = frontMechaCode;
			this._inOutsideCompanyCode = inOutsideCompanyCode;
			this._belongSectionCode = belongSectionCode;
			this._lvrRtCstGeneral = lvrRtCstGeneral;
			this._lvrRtCstCarInspect = lvrRtCstCarInspect;
			this._lvrRtCstBodyPaint = lvrRtCstBodyPaint;
			this._lvrRtCstBodyRepair = lvrRtCstBodyRepair;
			this._loginId = loginId;
			this._loginPassword = loginPassword;
			this._userAdminFlag = userAdminFlag;
			this.EnterCompanyDate = enterCompanyDate;
			this.RetirementDate = retirementDate;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._postName = postName;
			this._businessName = businessName;
			this._frontMechaName = frontMechaName;
			this._belongSectionName = belongSectionName;
			this._inOutsideCompanyName = inOutsideCompanyName;
			this._userAdminName = userAdminName;
            this._authorityLevel1 = authorityLevel1;
            this._authorityLevel2 = authorityLevel2;
			// -- Add St 2012.05.29 30182 R.Tachiya --
			this._salSlipInpBootCnt = salSlipInpBootCnt;
			this._custLedgerBootCnt = custLedgerBootCnt;
			// -- Add Ed 2012.05.29 30182 R.Tachiya --

		}

		/// <summary>
		/// 従業員マスタ複製処理
		/// </summary>
		/// <returns>Employeeクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいEmployeeクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Employee Clone()
		{
			return new Employee(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._employeeCode, this._name, this._kana, this._shortName, this._sexCode, this._sexName, this._birthday, this._companyTelNo, this._portableTelNo, this._postCode, this._businessCode, this._frontMechaCode, this._inOutsideCompanyCode, this._belongSectionCode, this._lvrRtCstGeneral, this._lvrRtCstCarInspect, this._lvrRtCstBodyPaint, this._lvrRtCstBodyRepair, this._loginId, this._loginPassword, this._userAdminFlag, this._enterCompanyDate, this._retirementDate, this._enterpriseName, this._updEmployeeName, this._postName, this._businessName, this._frontMechaName, this._belongSectionName, this._inOutsideCompanyName, this._userAdminName, this._authorityLevel1, this._authorityLevel2, this._salSlipInpBootCnt, this._custLedgerBootCnt);// -- Add 2012.05.29 30182 R.Tachiya --
			//return new Employee(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._employeeCode, this._name, this._kana, this._shortName, this._sexCode, this._sexName, this._birthday, this._companyTelNo, this._portableTelNo, this._postCode, this._businessCode, this._frontMechaCode, this._inOutsideCompanyCode, this._belongSectionCode, this._lvrRtCstGeneral, this._lvrRtCstCarInspect, this._lvrRtCstBodyPaint, this._lvrRtCstBodyRepair, this._loginId, this._loginPassword, this._userAdminFlag, this._enterCompanyDate, this._retirementDate, this._enterpriseName, this._updEmployeeName, this._postName, this._businessName, this._frontMechaName, this._belongSectionName, this._inOutsideCompanyName, this._userAdminName, this._authorityLevel1, this._authorityLevel2);// -- Del 2012.05.29 30182 R.Tachiya --
		}

		/// <summary>
		/// 従業員マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のEmployeeクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Employeeクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(Employee target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.EmployeeCode == target.EmployeeCode)
				 && (this.Name == target.Name)
				 && (this.Kana == target.Kana)
				 && (this.ShortName == target.ShortName)
				 && (this.SexCode == target.SexCode)
				 && (this.SexName == target.SexName)
				 && (this.Birthday == target.Birthday)
				 && (this.CompanyTelNo == target.CompanyTelNo)
				 && (this.PortableTelNo == target.PortableTelNo)
				 && (this.PostCode == target.PostCode)
				 && (this.BusinessCode == target.BusinessCode)
				 && (this.FrontMechaCode == target.FrontMechaCode)
				 && (this.InOutsideCompanyCode == target.InOutsideCompanyCode)
				 && (this.BelongSectionCode == target.BelongSectionCode)
				 && (this.LvrRtCstGeneral == target.LvrRtCstGeneral)
				 && (this.LvrRtCstCarInspect == target.LvrRtCstCarInspect)
				 && (this.LvrRtCstBodyPaint == target.LvrRtCstBodyPaint)
				 && (this.LvrRtCstBodyRepair == target.LvrRtCstBodyRepair)
				 && (this.LoginId == target.LoginId)
				 && (this.LoginPassword == target.LoginPassword)
				 && (this.UserAdminFlag == target.UserAdminFlag)
				 && (this.EnterCompanyDate == target.EnterCompanyDate)
				 && (this.RetirementDate == target.RetirementDate)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.PostName == target.PostName)
				 && (this.BusinessName == target.BusinessName)
				 && (this.FrontMechaName == target.FrontMechaName)
				 && (this.BelongSectionName == target.BelongSectionName)
				 && (this.InOutsideCompanyName == target.InOutsideCompanyName)
				 && (this.UserAdminName == target.UserAdminName)
				 && (this.AuthorityLevel1 == target.AuthorityLevel1)
				 && (this.AuthorityLevel2 == target.AuthorityLevel2)// -- Update 2012.05.29 30182 R.Tachiya --
				// -- Add St 2012.05.29 30182 R.Tachiya --
				 && (this.SalSlipInpBootCnt == target.SalSlipInpBootCnt)
				 && (this.CustLedgerBootCnt == target.CustLedgerBootCnt));
				// -- Add Ed 2012.05.29 30182 R.Tachiya --				
		}

		/// <summary>
		/// 従業員マスタ比較処理
		/// </summary>
		/// <param name="employee1">
		///                    比較するEmployeeクラスのインスタンス
		/// </param>
		/// <param name="employee2">比較するEmployeeクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Employeeクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(Employee employee1, Employee employee2)
		{
			return ((employee1.CreateDateTime == employee2.CreateDateTime)
				 && (employee1.UpdateDateTime == employee2.UpdateDateTime)
				 && (employee1.EnterpriseCode == employee2.EnterpriseCode)
				 && (employee1.FileHeaderGuid == employee2.FileHeaderGuid)
				 && (employee1.UpdEmployeeCode == employee2.UpdEmployeeCode)
				 && (employee1.UpdAssemblyId1 == employee2.UpdAssemblyId1)
				 && (employee1.UpdAssemblyId2 == employee2.UpdAssemblyId2)
				 && (employee1.LogicalDeleteCode == employee2.LogicalDeleteCode)
				 && (employee1.EmployeeCode == employee2.EmployeeCode)
				 && (employee1.Name == employee2.Name)
				 && (employee1.Kana == employee2.Kana)
				 && (employee1.ShortName == employee2.ShortName)
				 && (employee1.SexCode == employee2.SexCode)
				 && (employee1.SexName == employee2.SexName)
				 && (employee1.Birthday == employee2.Birthday)
				 && (employee1.CompanyTelNo == employee2.CompanyTelNo)
				 && (employee1.PortableTelNo == employee2.PortableTelNo)
				 && (employee1.PostCode == employee2.PostCode)
				 && (employee1.BusinessCode == employee2.BusinessCode)
				 && (employee1.FrontMechaCode == employee2.FrontMechaCode)
				 && (employee1.InOutsideCompanyCode == employee2.InOutsideCompanyCode)
				 && (employee1.BelongSectionCode == employee2.BelongSectionCode)
				 && (employee1.LvrRtCstGeneral == employee2.LvrRtCstGeneral)
				 && (employee1.LvrRtCstCarInspect == employee2.LvrRtCstCarInspect)
				 && (employee1.LvrRtCstBodyPaint == employee2.LvrRtCstBodyPaint)
				 && (employee1.LvrRtCstBodyRepair == employee2.LvrRtCstBodyRepair)
				 && (employee1.LoginId == employee2.LoginId)
				 && (employee1.LoginPassword == employee2.LoginPassword)
				 && (employee1.UserAdminFlag == employee2.UserAdminFlag)
				 && (employee1.EnterCompanyDate == employee2.EnterCompanyDate)
				 && (employee1.RetirementDate == employee2.RetirementDate)
				 && (employee1.EnterpriseName == employee2.EnterpriseName)
				 && (employee1.UpdEmployeeName == employee2.UpdEmployeeName)
				 && (employee1.PostName == employee2.PostName)
				 && (employee1.BusinessName == employee2.BusinessName)
				 && (employee1.FrontMechaName == employee2.FrontMechaName)
				 && (employee1.BelongSectionName == employee2.BelongSectionName)
				 && (employee1.InOutsideCompanyName == employee2.InOutsideCompanyName)
				 && (employee1.UserAdminName == employee2.UserAdminName)
                 && (employee1.AuthorityLevel1 == employee2.AuthorityLevel1)
				 && (employee1.AuthorityLevel2 == employee2.AuthorityLevel2)// -- Update 2012.05.29 30182 R.Tachiya --
				// -- Add St 2012.05.29 30182 R.Tachiya --
				 && (employee1.SalSlipInpBootCnt == employee2.SalSlipInpBootCnt)
				 && (employee1.CustLedgerBootCnt == employee2.CustLedgerBootCnt));
				// -- Add Ed 2012.05.29 30182 R.Tachiya --				
		}
		/// <summary>
		/// 従業員マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のEmployeeクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Employeeクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(Employee target)
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
			if (this.EmployeeCode != target.EmployeeCode)
				resList.Add("EmployeeCode");
			if (this.Name != target.Name)
				resList.Add("Name");
			if (this.Kana != target.Kana)
				resList.Add("Kana");
			if (this.ShortName != target.ShortName)
				resList.Add("ShortName");
			if (this.SexCode != target.SexCode)
				resList.Add("SexCode");
			if (this.SexName != target.SexName)
				resList.Add("SexName");
			if (this.Birthday != target.Birthday)
				resList.Add("Birthday");
			if (this.CompanyTelNo != target.CompanyTelNo)
				resList.Add("CompanyTelNo");
			if (this.PortableTelNo != target.PortableTelNo)
				resList.Add("PortableTelNo");
			if (this.PostCode != target.PostCode)
				resList.Add("PostCode");
			if (this.BusinessCode != target.BusinessCode)
				resList.Add("BusinessCode");
			if (this.FrontMechaCode != target.FrontMechaCode)
				resList.Add("FrontMechaCode");
			if (this.InOutsideCompanyCode != target.InOutsideCompanyCode)
				resList.Add("InOutsideCompanyCode");
			if (this.BelongSectionCode != target.BelongSectionCode)
				resList.Add("BelongSectionCode");
			if (this.LvrRtCstGeneral != target.LvrRtCstGeneral)
				resList.Add("LvrRtCstGeneral");
			if (this.LvrRtCstCarInspect != target.LvrRtCstCarInspect)
				resList.Add("LvrRtCstCarInspect");
			if (this.LvrRtCstBodyPaint != target.LvrRtCstBodyPaint)
				resList.Add("LvrRtCstBodyPaint");
			if (this.LvrRtCstBodyRepair != target.LvrRtCstBodyRepair)
				resList.Add("LvrRtCstBodyRepair");
			if (this.LoginId != target.LoginId)
				resList.Add("LoginId");
			if (this.LoginPassword != target.LoginPassword)
				resList.Add("LoginPassword");
			if (this.UserAdminFlag != target.UserAdminFlag)
				resList.Add("UserAdminFlag");
			if (this.EnterCompanyDate != target.EnterCompanyDate)
				resList.Add("EnterCompanyDate");
			if (this.RetirementDate != target.RetirementDate)
				resList.Add("RetirementDate");
			if (this.EnterpriseName != target.EnterpriseName)
				resList.Add("EnterpriseName");
			if (this.UpdEmployeeName != target.UpdEmployeeName)
				resList.Add("UpdEmployeeName");
			if (this.PostName != target.PostName)
				resList.Add("PostName");
			if (this.BusinessName != target.BusinessName)
				resList.Add("BusinessName");
			if (this.FrontMechaName != target.FrontMechaName)
				resList.Add("FrontMechaName");
			if (this.BelongSectionName != target.BelongSectionName)
				resList.Add("BelongSectionName");
			if (this.InOutsideCompanyName != target.InOutsideCompanyName)
				resList.Add("InOutsideCompanyName");
			if (this.UserAdminName != target.LoginPassword)
				resList.Add("UserAdminName");
            if (this.AuthorityLevel1 != target.AuthorityLevel1)
                resList.Add("AuthorityLevel1");
            if (this.AuthorityLevel2 != target.AuthorityLevel2)
                resList.Add("AuthorityLevel2");
			// -- Add St 2012.05.29 30182 R.Tachiya --
			if (this.SalSlipInpBootCnt != target.SalSlipInpBootCnt)
				resList.Add("SalSlipInpBootCnt");
			if (this.CustLedgerBootCnt != target.CustLedgerBootCnt)
				resList.Add("CustLedgerBootCnt");
			// -- Add Ed 2012.05.29 30182 R.Tachiya --				

			return resList;
		}

		/// <summary>
		/// 従業員マスタ比較処理
		/// </summary>
		/// <param name="employee1">比較するEmployeeクラスのインスタンス</param>
		/// <param name="employee2">比較するEmployeeクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Employeeクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(Employee employee1, Employee employee2)
		{
			ArrayList resList = new ArrayList();
			if (employee1.CreateDateTime != employee2.CreateDateTime)
				resList.Add("CreateDateTime");
			if (employee1.UpdateDateTime != employee2.UpdateDateTime)
				resList.Add("UpdateDateTime");
			if (employee1.EnterpriseCode != employee2.EnterpriseCode)
				resList.Add("EnterpriseCode");
			if (employee1.FileHeaderGuid != employee2.FileHeaderGuid)
				resList.Add("FileHeaderGuid");
			if (employee1.UpdEmployeeCode != employee2.UpdEmployeeCode)
				resList.Add("UpdEmployeeCode");
			if (employee1.UpdAssemblyId1 != employee2.UpdAssemblyId1)
				resList.Add("UpdAssemblyId1");
			if (employee1.UpdAssemblyId2 != employee2.UpdAssemblyId2)
				resList.Add("UpdAssemblyId2");
			if (employee1.LogicalDeleteCode != employee2.LogicalDeleteCode)
				resList.Add("LogicalDeleteCode");
			if (employee1.EmployeeCode != employee2.EmployeeCode)
				resList.Add("EmployeeCode");
			if (employee1.Name != employee2.Name)
				resList.Add("Name");
			if (employee1.Kana != employee2.Kana)
				resList.Add("Kana");
			if (employee1.ShortName != employee2.ShortName)
				resList.Add("ShortName");
			if (employee1.SexCode != employee2.SexCode)
				resList.Add("SexCode");
			if (employee1.SexName != employee2.SexName)
				resList.Add("SexName");
			if (employee1.Birthday != employee2.Birthday)
				resList.Add("Birthday");
			if (employee1.CompanyTelNo != employee2.CompanyTelNo)
				resList.Add("CompanyTelNo");
			if (employee1.PortableTelNo != employee2.PortableTelNo)
				resList.Add("PortableTelNo");
			if (employee1.PostCode != employee2.PostCode)
				resList.Add("PostCode");
			if (employee1.BusinessCode != employee2.BusinessCode)
				resList.Add("BusinessCode");
			if (employee1.FrontMechaCode != employee2.FrontMechaCode)
				resList.Add("FrontMechaCode");
			if (employee1.InOutsideCompanyCode != employee2.InOutsideCompanyCode)
				resList.Add("InOutsideCompanyCode");
			if (employee1.BelongSectionCode != employee2.BelongSectionCode)
				resList.Add("BelongSectionCode");
			if (employee1.LvrRtCstGeneral != employee2.LvrRtCstGeneral)
				resList.Add("LvrRtCstGeneral");
			if (employee1.LvrRtCstCarInspect != employee2.LvrRtCstCarInspect)
				resList.Add("LvrRtCstCarInspect");
			if (employee1.LvrRtCstBodyPaint != employee2.LvrRtCstBodyPaint)
				resList.Add("LvrRtCstBodyPaint");
			if (employee1.LvrRtCstBodyRepair != employee2.LvrRtCstBodyRepair)
				resList.Add("LvrRtCstBodyRepair");
			if (employee1.LoginId != employee2.LoginId)
				resList.Add("LoginId");
			if (employee1.LoginPassword != employee2.LoginPassword)
				resList.Add("LoginPassword");
			if (employee1.UserAdminFlag != employee2.UserAdminFlag)
				resList.Add("UserAdminFlag");
			if (employee1.EnterCompanyDate != employee2.EnterCompanyDate)
				resList.Add("EnterCompanyDate");
			if (employee1.RetirementDate != employee2.RetirementDate)
				resList.Add("RetirementDate");
			if (employee1.EnterpriseName != employee2.EnterpriseName)
				resList.Add("EnterpriseName");
			if (employee1.UpdEmployeeName != employee2.UpdEmployeeName)
				resList.Add("UpdEmployeeName");
			if (employee1.PostName != employee2.PostName)
				resList.Add("PostName");
			if (employee1.BusinessName != employee2.BusinessName)
				resList.Add("BusinessName");
			if (employee1.FrontMechaName != employee2.FrontMechaName)
				resList.Add("FrontMechaName");
			if (employee1.BelongSectionName != employee2.BelongSectionName)
				resList.Add("BelongSectionName");
			if (employee1.InOutsideCompanyName != employee2.InOutsideCompanyName)
				resList.Add("InOutsideCompanyName");
			if (employee1.UserAdminName != employee2.UserAdminName)
				resList.Add("UserAdminName");
            if (employee1.AuthorityLevel1 != employee2.AuthorityLevel1)
                resList.Add("AuthorityLevel1");
            if (employee1.AuthorityLevel2 != employee2.AuthorityLevel2)
                resList.Add("AuthorityLevel2");
			// -- Add St 2012.05.29 30182 R.Tachiya --
			if (employee1.SalSlipInpBootCnt != employee2.SalSlipInpBootCnt)
				resList.Add("SalSlipInpBootCnt");
			if (employee1.CustLedgerBootCnt != employee2.CustLedgerBootCnt)
				resList.Add("CustLedgerBootCnt");
			// -- Add Ed 2012.05.29 30182 R.Tachiya --				

			return resList;
		}
	}


    // 2009.03.02 自動生成へ置き換え(手動変更箇所：1.Equals→EqualsDtl 2.所属部門名称(belongSubSectionName)の追加) >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    #region 削除
    ///// public class name:   EmployeeDtl
    ///// <summary>
    /////                      従業員詳細ワーク
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   従業員詳細ワークヘッダファイル</br>
    ///// <br>Programmer       :   自動生成</br>
    ///// <br>Date             :   </br>
    ///// <br>Genarated Date   :   2007/08/29  (CSharp File Generated Date)</br>
    ///// <br>Update Note      : 2008/06/04 30414 忍　幸史</br>
    ///// <br>                   ・「所属課」「所属部署変更日」「旧所属拠点」「旧所属部門」「旧所属課」削除</br>
    ///// <br>Update Note      : UOE略称区分追加</br>
    ///// <br>Programmer       : 30009 渋谷 大輔</br>
    ///// <br>Date             : 2008.11.10</br>
    ///// </remarks>
    //public class EmployeeDtl
    //{
    //    /// <summary>作成日時</summary>
    //    /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
    //    private DateTime _createDateTime;

    //    /// <summary>更新日時</summary>
    //    /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
    //    private DateTime _updateDateTime;

    //    /// <summary>企業コード</summary>
    //    /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
    //    private string _enterpriseCode = "";

    //    /// <summary>GUID</summary>
    //    /// <remarks>共通ファイルヘッダ</remarks>
    //    private Guid _fileHeaderGuid;

    //    /// <summary>更新従業員コード</summary>
    //    /// <remarks>共通ファイルヘッダ</remarks>
    //    private string _updEmployeeCode = "";

    //    /// <summary>更新アセンブリID1</summary>
    //    /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
    //    private string _updAssemblyId1 = "";

    //    /// <summary>更新アセンブリID2</summary>
    //    /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
    //    private string _updAssemblyId2 = "";

    //    /// <summary>論理削除区分</summary>
    //    /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
    //    private Int32 _logicalDeleteCode;

    //    /// <summary>従業員コード</summary>
    //    private string _employeeCode = "";

    //    /// <summary>所属部門コード</summary>
    //    private Int32 _belongSubSectionCode;

    //    /// <summary>所属部門名称</summary>
    //    private string _belongSubSectionName = "";

    //    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //    /// <summary>所属課コード</summary>
    //    private Int32 _belongMinSectionCode;

    //    /// <summary>所属課名称</summary>
    //    private string _belongMinSectionName = "";
    //       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

    //    /// <summary>所属販売エリアコード</summary>
    //    private Int32 _belongSalesAreaCode;

    //    /// <summary>所属販売エリア名称</summary>
    //    private string _belongSalesAreaName = "";

    //    /// <summary>従業員分析コード１</summary>
    //    /// <remarks>年齢,グループ等分析用任意コードを設定</remarks>
    //    private Int32 _employAnalysCode1;

    //    /// <summary>従業員分析コード２</summary>
    //    /// <remarks>※マスタ管理しないため、コードはユーザー管理となる</remarks>
    //    private Int32 _employAnalysCode2;

    //    /// <summary>従業員分析コード３</summary>
    //    private Int32 _employAnalysCode3;

    //    /// <summary>従業員分析コード４</summary>
    //    private Int32 _employAnalysCode4;

    //    /// <summary>従業員分析コード５</summary>
    //    private Int32 _employAnalysCode5;

    //    /// <summary>従業員分析コード６</summary>
    //    private Int32 _employAnalysCode6;

    //    /// <summary>UOE略称区分</summary>
    //    private string _uOESnmDiv = "";

    //    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //    /// <summary>旧所属拠点コード</summary>
    //    private string _oldBelongSectionCd = "";

    //    /// <summary>旧所属部拠点名称</summary>
    //    private string _oldBelongSectionNm = "";

    //    /// <summary>旧所属部門コード</summary>
    //    private Int32 _oldBelongSubSecCd;

    //    /// <summary>旧所属部門名称</summary>
    //    private string _oldBelongSubSecNm = "";

    //    /// <summary>旧所属課コード</summary>
    //    private Int32 _oldBelongMinSecCd;

    //    /// <summary>旧所属課名称</summary>
    //    private string _oldBelongMinSecNm = "";

    //    /// <summary>所属部署変更日</summary>
    //    /// <remarks>YYYYMMDD</remarks>
    //    private DateTime _sectionChgDate;
    //       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

    //    /// public propaty name  :  CreateDateTime
    //    /// <summary>作成日時プロパティ</summary>
    //    /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   作成日時プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime CreateDateTime
    //    {
    //        get { return _createDateTime; }
    //        set { _createDateTime = value; }
    //    }

    //    /// public propaty name  :  UpdateDateTime
    //    /// <summary>更新日時プロパティ</summary>
    //    /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   更新日時プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime UpdateDateTime
    //    {
    //        get { return _updateDateTime; }
    //        set { _updateDateTime = value; }
    //    }

    //    /// public propaty name  :  EnterpriseCode
    //    /// <summary>企業コードプロパティ</summary>
    //    /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   企業コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EnterpriseCode
    //    {
    //        get { return _enterpriseCode; }
    //        set { _enterpriseCode = value; }
    //    }

    //    /// public propaty name  :  FileHeaderGuid
    //    /// <summary>GUIDプロパティ</summary>
    //    /// <value>共通ファイルヘッダ</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   GUIDプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Guid FileHeaderGuid
    //    {
    //        get { return _fileHeaderGuid; }
    //        set { _fileHeaderGuid = value; }
    //    }

    //    /// public propaty name  :  UpdEmployeeCode
    //    /// <summary>更新従業員コードプロパティ</summary>
    //    /// <value>共通ファイルヘッダ</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   更新従業員コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string UpdEmployeeCode
    //    {
    //        get { return _updEmployeeCode; }
    //        set { _updEmployeeCode = value; }
    //    }

    //    /// public propaty name  :  UpdAssemblyId1
    //    /// <summary>更新アセンブリID1プロパティ</summary>
    //    /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   更新アセンブリID1プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string UpdAssemblyId1
    //    {
    //        get { return _updAssemblyId1; }
    //        set { _updAssemblyId1 = value; }
    //    }

    //    /// public propaty name  :  UpdAssemblyId2
    //    /// <summary>更新アセンブリID2プロパティ</summary>
    //    /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   更新アセンブリID2プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string UpdAssemblyId2
    //    {
    //        get { return _updAssemblyId2; }
    //        set { _updAssemblyId2 = value; }
    //    }

    //    /// public propaty name  :  LogicalDeleteCode
    //    /// <summary>論理削除区分プロパティ</summary>
    //    /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   論理削除区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 LogicalDeleteCode
    //    {
    //        get { return _logicalDeleteCode; }
    //        set { _logicalDeleteCode = value; }
    //    }

    //    /// public propaty name  :  EmployeeCode
    //    /// <summary>従業員コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   従業員コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EmployeeCode
    //    {
    //        get { return _employeeCode; }
    //        set { _employeeCode = value; }
    //    }

    //    /// public propaty name  :  BelongSubSectionCode
    //    /// <summary>所属部門コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   所属部門コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 BelongSubSectionCode
    //    {
    //        get { return _belongSubSectionCode; }
    //        set { _belongSubSectionCode = value; }
    //    }

    //    /// public propaty name  :  BelongSubSectionName
    //    /// <summary>所属部門名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   所属部門名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string BelongSubSectionName
    //    {
    //        get { return _belongSubSectionName; }
    //        set { _belongSubSectionName = value; }
    //    }

    //    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //    /// public propaty name  :  BelongMinSectionCode
    //    /// <summary>所属課コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   所属課コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 BelongMinSectionCode
    //    {
    //        get { return _belongMinSectionCode; }
    //        set { _belongMinSectionCode = value; }
    //    }

    //    /// public propaty name  :  BelongMinSectionName
    //    /// <summary>所属課名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   所属課名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string BelongMinSectionName
    //    {
    //        get { return _belongMinSectionName; }
    //        set { _belongMinSectionName = value; }
    //    }
    //       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

    //    /// public propaty name  :  BelongSalesAreaCode
    //    /// <summary>所属販売エリアコードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   所属販売エリアコードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 BelongSalesAreaCode
    //    {
    //        get { return _belongSalesAreaCode; }
    //        set { _belongSalesAreaCode = value; }
    //    }

    //    /// public propaty name  :  BelongSalesAreaName
    //    /// <summary>所属販売エリア名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   所属販売エリア名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string BelongSalesAreaName
    //    {
    //        get { return _belongSalesAreaName; }
    //        set { _belongSalesAreaName = value; }
    //    }

    //    /// public propaty name  :  EmployAnalysCode1
    //    /// <summary>従業員分析コード１プロパティ</summary>
    //    /// <value>年齢,グループ等分析用任意コードを設定</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   従業員分析コード１プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 EmployAnalysCode1
    //    {
    //        get { return _employAnalysCode1; }
    //        set { _employAnalysCode1 = value; }
    //    }

    //    /// public propaty name  :  EmployAnalysCode2
    //    /// <summary>従業員分析コード２プロパティ</summary>
    //    /// <value>※マスタ管理しないため、コードはユーザー管理となる</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   従業員分析コード２プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 EmployAnalysCode2
    //    {
    //        get { return _employAnalysCode2; }
    //        set { _employAnalysCode2 = value; }
    //    }

    //    /// public propaty name  :  EmployAnalysCode3
    //    /// <summary>従業員分析コード３プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   従業員分析コード３プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 EmployAnalysCode3
    //    {
    //        get { return _employAnalysCode3; }
    //        set { _employAnalysCode3 = value; }
    //    }

    //    /// public propaty name  :  EmployAnalysCode4
    //    /// <summary>従業員分析コード４プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   従業員分析コード４プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 EmployAnalysCode4
    //    {
    //        get { return _employAnalysCode4; }
    //        set { _employAnalysCode4 = value; }
    //    }

    //    /// public propaty name  :  EmployAnalysCode5
    //    /// <summary>従業員分析コード５プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   従業員分析コード５プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 EmployAnalysCode5
    //    {
    //        get { return _employAnalysCode5; }
    //        set { _employAnalysCode5 = value; }
    //    }

    //    /// public propaty name  :  EmployAnalysCode6
    //    /// <summary>従業員分析コード６プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   従業員分析コード６プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 EmployAnalysCode6
    //    {
    //        get { return _employAnalysCode6; }
    //        set { _employAnalysCode6 = value; }
    //    }

    //    /// public propaty name  :  UOESnmDiv
    //    /// <summary>UOE略称区分プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   UOE略称区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string UOESnmDiv
    //    {
    //        get { return _uOESnmDiv; }
    //        set { _uOESnmDiv = value; }
    //    }

    //    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //    /// public propaty name  :  OldBelongSectionCd
    //    /// <summary>旧所属拠点コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   旧所属拠点コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string OldBelongSectionCd
    //    {
    //        get { return _oldBelongSectionCd; }
    //        set { _oldBelongSectionCd = value; }
    //    }

    //    /// public propaty name  :  OldBelongSectionNm
    //    /// <summary>旧所属部拠点名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   旧所属部拠点名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string OldBelongSectionNm
    //    {
    //        get { return _oldBelongSectionNm; }
    //        set { _oldBelongSectionNm = value; }
    //    }

    //    /// public propaty name  :  OldBelongSubSecCd
    //    /// <summary>旧所属部門コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   旧所属部門コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 OldBelongSubSecCd
    //    {
    //        get { return _oldBelongSubSecCd; }
    //        set { _oldBelongSubSecCd = value; }
    //    }

    //    /// public propaty name  :  OldBelongSubSecNm
    //    /// <summary>旧所属部門名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   旧所属部門名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string OldBelongSubSecNm
    //    {
    //        get { return _oldBelongSubSecNm; }
    //        set { _oldBelongSubSecNm = value; }
    //    }

    //    /// public propaty name  :  OldBelongMinSecCd
    //    /// <summary>旧所属課コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   旧所属課コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 OldBelongMinSecCd
    //    {
    //        get { return _oldBelongMinSecCd; }
    //        set { _oldBelongMinSecCd = value; }
    //    }

    //    /// public propaty name  :  OldBelongMinSecNm
    //    /// <summary>旧所属課名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   旧所属課名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string OldBelongMinSecNm
    //    {
    //        get { return _oldBelongMinSecNm; }
    //        set { _oldBelongMinSecNm = value; }
    //    }

    //    /// public propaty name  :  SectionChgDate
    //    /// <summary>所属部署変更日プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   所属部署変更日プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime SectionChgDate
    //    {
    //        get { return _sectionChgDate; }
    //        set { _sectionChgDate = value; }
    //    }
    //       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

    //    /// <summary>
    //    /// 従業員詳細ワークコンストラクタ
    //    /// </summary>
    //    /// <returns>EmployeeDtlクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   EmployeeDtlクラスの新しいインスタンスを生成します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public EmployeeDtl()
    //    {
    //    }

    //    /// <summary>
    //    /// 従業員詳細ワークコンストラクタ
    //    /// </summary>
    //    /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
    //    /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
    //    /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
    //    /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
    //    /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
    //    /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
    //    /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
    //    /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
    //    /// <param name="employeeCode">従業員コード</param>
    //    /// <param name="belongSubSectionCode">所属部門コード</param>
    //    /// <param name="belongSubSectionName">所属部門名称</param>
    //    /// <param name="belongSalesAreaCode">所属販売エリアコード</param>
    //    /// <param name="belongSalesAreaName">所属販売エリア名称</param>
    //    /// <param name="employAnalysCode1">従業員分析コード１(年齢,グループ等分析用任意コードを設定)</param>
    //    /// <param name="employAnalysCode2">従業員分析コード２(※マスタ管理しないため、コードはユーザー管理となる)</param>
    //    /// <param name="employAnalysCode3">従業員分析コード３</param>
    //    /// <param name="employAnalysCode4">従業員分析コード４</param>
    //    /// <param name="employAnalysCode5">従業員分析コード５</param>
    //    /// <param name="employAnalysCode6">従業員分析コード６</param>
    //    /// <param name="uOESnmDiv">UOE略称区分</param>
    //    /// <returns>EmployeeDtlクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   EmployeeDtlクラスの新しいインスタンスを生成します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //    public EmployeeDtl(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string employeeCode, Int32 belongSubSectionCode, string belongSubSectionName, Int32 belongMinSectionCode, string belongMinSectionName, Int32 belongSalesAreaCode, string belongSalesAreaName, Int32 employAnalysCode1, Int32 employAnalysCode2, Int32 employAnalysCode3, Int32 employAnalysCode4, Int32 employAnalysCode5, Int32 employAnalysCode6, string oldBelongSectionCd, string oldBelongSectionNm, Int32 oldBelongSubSecCd, string oldBelongSubSecNm, Int32 oldBelongMinSecCd, string oldBelongMinSecNm, DateTime sectionChgDate)
    //       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
    //    //2008.11.10 del start -------------------------------------------------------------->>
    //    //public EmployeeDtl(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string employeeCode, Int32 belongSubSectionCode, string belongSubSectionName, Int32 belongSalesAreaCode, string belongSalesAreaName, Int32 employAnalysCode1, Int32 employAnalysCode2, Int32 employAnalysCode3, Int32 employAnalysCode4, Int32 employAnalysCode5, Int32 employAnalysCode6)
    //    //2008.11.10 del end ----------------------------------------------------------------<<
    //    public EmployeeDtl(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string employeeCode, Int32 belongSubSectionCode, string belongSubSectionName, Int32 belongSalesAreaCode, string belongSalesAreaName, Int32 employAnalysCode1, Int32 employAnalysCode2, Int32 employAnalysCode3, Int32 employAnalysCode4, Int32 employAnalysCode5, Int32 employAnalysCode6, String uOESnmDiv)
    //    {
    //        this.CreateDateTime = createDateTime;
    //        this.UpdateDateTime = updateDateTime;
    //        this._enterpriseCode = enterpriseCode;
    //        this._fileHeaderGuid = fileHeaderGuid;
    //        this._updEmployeeCode = updEmployeeCode;
    //        this._updAssemblyId1 = updAssemblyId1;
    //        this._updAssemblyId2 = updAssemblyId2;
    //        this._logicalDeleteCode = logicalDeleteCode;
    //        this._employeeCode = employeeCode;
    //        this._belongSubSectionCode = belongSubSectionCode;
    //        this._belongSubSectionName = belongSubSectionName;

    //        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //        this._belongMinSectionCode = belongMinSectionCode;
    //        this._belongMinSectionName = belongMinSectionName;
    //           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

    //        this._belongSalesAreaCode = belongSalesAreaCode;
    //        this._belongSalesAreaName = belongSalesAreaName;
    //        this._employAnalysCode1 = employAnalysCode1;
    //        this._employAnalysCode2 = employAnalysCode2;
    //        this._employAnalysCode3 = employAnalysCode3;
    //        this._employAnalysCode4 = employAnalysCode4;
    //        this._employAnalysCode5 = employAnalysCode5;
    //        this._employAnalysCode6 = employAnalysCode6;

    //        //2008.11.10 add start -------------------------------------------------------------->>
    //        this._uOESnmDiv = uOESnmDiv;
    //        //2008.11.10 add end ----------------------------------------------------------------<<

    //        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //        this._oldBelongSectionCd = oldBelongSectionCd;
    //        this._oldBelongSectionNm = oldBelongSectionNm;
    //        this._oldBelongSubSecCd = oldBelongSubSecCd;
    //        this._oldBelongSubSecNm = oldBelongSubSecNm;
    //        this._oldBelongMinSecCd = oldBelongMinSecCd;
    //        this._oldBelongMinSecNm = oldBelongMinSecNm;
    //        this._sectionChgDate = sectionChgDate;
    //           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
    //    }

    //    /// <summary>
    //    /// 従業員詳細ワーク複製処理
    //    /// </summary>
    //    /// <returns>EmployeeDtlクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   自身の内容と等しいEmployeeDtlクラスのインスタンスを返します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public EmployeeDtl Clone()
    //    {
    //        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //        return new EmployeeDtl(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._employeeCode, this._belongSubSectionCode, this._belongSubSectionName, this._belongMinSectionCode, this._belongMinSectionName, this._belongSalesAreaCode, this._belongSalesAreaName, this._employAnalysCode1, this._employAnalysCode2, this._employAnalysCode3, this._employAnalysCode4, this._employAnalysCode5, this._employAnalysCode6, this._oldBelongSectionCd, this._oldBelongSectionNm, this._oldBelongSubSecCd, this._oldBelongSubSecNm, this._oldBelongMinSecCd, this._oldBelongMinSecNm, this._sectionChgDate);
    //           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
    //        //2008.11.10 del start -------------------------------------------------------------->>
    //        //return new EmployeeDtl(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._employeeCode, this._belongSubSectionCode, this._belongSubSectionName, this._belongSalesAreaCode, this._belongSalesAreaName, this._employAnalysCode1, this._employAnalysCode2, this._employAnalysCode3, this._employAnalysCode4, this._employAnalysCode5, this._employAnalysCode6);
    //        //2008.11.10 del end ----------------------------------------------------------------<<
    //        return new EmployeeDtl(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._employeeCode, this._belongSubSectionCode, this._belongSubSectionName, this._belongSalesAreaCode, this._belongSalesAreaName, this._employAnalysCode1, this._employAnalysCode2, this._employAnalysCode3, this._employAnalysCode4, this._employAnalysCode5, this._employAnalysCode6, this._uOESnmDiv);
    //    }

    //    /// <summary>
    //    /// 従業員詳細ワーク比較処理
    //    /// </summary>
    //    /// <param name="target">比較対象のEmployeeDtlクラスのインスタンス</param>
    //    /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   EmployeeDtlクラスの内容が一致するか比較します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public bool EqualsDtl(EmployeeDtl target)
    //    {
    //        return ((this.CreateDateTime == target.CreateDateTime)
    //             && (this.UpdateDateTime == target.UpdateDateTime)
    //             && (this.EnterpriseCode == target.EnterpriseCode)
    //             && (this.FileHeaderGuid == target.FileHeaderGuid)
    //             && (this.UpdEmployeeCode == target.UpdEmployeeCode)
    //             && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
    //             && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
    //             && (this.LogicalDeleteCode == target.LogicalDeleteCode)
    //             && (this.EmployeeCode == target.EmployeeCode)
    //             && (this.BelongSubSectionCode == target.BelongSubSectionCode)
    //             && (this.BelongSubSectionName == target.BelongSubSectionName)
    //            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //            && (this.BelongMinSectionCode == target.BelongMinSectionCode)
    //            && (this.BelongMinSectionName == target.BelongMinSectionName)
    //               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
    //             && (this.BelongSalesAreaCode == target.BelongSalesAreaCode)
    //             && (this.BelongSalesAreaName == target.BelongSalesAreaName)
    //             && (this.EmployAnalysCode1 == target.EmployAnalysCode1)
    //             && (this.EmployAnalysCode2 == target.EmployAnalysCode2)
    //             && (this.EmployAnalysCode3 == target.EmployAnalysCode3)
    //             && (this.EmployAnalysCode4 == target.EmployAnalysCode4)
    //             && (this.EmployAnalysCode5 == target.EmployAnalysCode5)
    //             && (this.EmployAnalysCode6 == target.EmployAnalysCode6)
    //            //2008.11.10 add start -------------------------------------------------------------->>
    //             && (this.UOESnmDiv == target.UOESnmDiv));
    //            //2008.11.10 add end ----------------------------------------------------------------<<
    //        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //        && (this.OldBelongSectionCd == target.OldBelongSectionCd)
    //        && (this.OldBelongSectionNm == target.OldBelongSectionNm)
    //        && (this.OldBelongSubSecCd == target.OldBelongSubSecCd)
    //        && (this.OldBelongSubSecNm == target.OldBelongSubSecNm)
    //        && (this.OldBelongMinSecCd == target.OldBelongMinSecCd)
    //        && (this.OldBelongMinSecNm == target.OldBelongMinSecNm)
    //        && (this.SectionChgDate == target.SectionChgDate));
    //           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
    //    }

    //    /// <summary>
    //    /// 従業員詳細ワーク比較処理
    //    /// </summary>
    //    /// <param name="employeeDtl1">
    //    ///                    比較するEmployeeDtlクラスのインスタンス
    //    /// </param>
    //    /// <param name="employeeDtl2">比較するEmployeeDtlクラスのインスタンス</param>
    //    /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   EmployeeDtlクラスの内容が一致するか比較します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public static bool EqualsDtl(EmployeeDtl employeeDtl1, EmployeeDtl employeeDtl2)
    //    {
    //        return ((employeeDtl1.CreateDateTime == employeeDtl2.CreateDateTime)
    //             && (employeeDtl1.UpdateDateTime == employeeDtl2.UpdateDateTime)
    //             && (employeeDtl1.EnterpriseCode == employeeDtl2.EnterpriseCode)
    //             && (employeeDtl1.FileHeaderGuid == employeeDtl2.FileHeaderGuid)
    //             && (employeeDtl1.UpdEmployeeCode == employeeDtl2.UpdEmployeeCode)
    //             && (employeeDtl1.UpdAssemblyId1 == employeeDtl2.UpdAssemblyId1)
    //             && (employeeDtl1.UpdAssemblyId2 == employeeDtl2.UpdAssemblyId2)
    //             && (employeeDtl1.LogicalDeleteCode == employeeDtl2.LogicalDeleteCode)
    //             && (employeeDtl1.EmployeeCode == employeeDtl2.EmployeeCode)
    //             && (employeeDtl1.BelongSubSectionCode == employeeDtl2.BelongSubSectionCode)
    //             && (employeeDtl1.BelongSubSectionName == employeeDtl2.BelongSubSectionName)
    //            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //            && (employeeDtl1.BelongMinSectionCode == employeeDtl2.BelongMinSectionCode)
    //            && (employeeDtl1.BelongMinSectionName == employeeDtl2.BelongMinSectionName)
    //               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
    //             && (employeeDtl1.BelongSalesAreaCode == employeeDtl2.BelongSalesAreaCode)
    //             && (employeeDtl1.BelongSalesAreaName == employeeDtl2.BelongSalesAreaName)
    //             && (employeeDtl1.EmployAnalysCode1 == employeeDtl2.EmployAnalysCode1)
    //             && (employeeDtl1.EmployAnalysCode2 == employeeDtl2.EmployAnalysCode2)
    //             && (employeeDtl1.EmployAnalysCode3 == employeeDtl2.EmployAnalysCode3)
    //             && (employeeDtl1.EmployAnalysCode4 == employeeDtl2.EmployAnalysCode4)
    //             && (employeeDtl1.EmployAnalysCode5 == employeeDtl2.EmployAnalysCode5)
    //             && (employeeDtl1.EmployAnalysCode6 == employeeDtl2.EmployAnalysCode6)
    //        //2008.11.10 add start -------------------------------------------------------------->>
    //             && (employeeDtl1.UOESnmDiv == employeeDtl2.UOESnmDiv));
    //        //2008.11.10 add end ----------------------------------------------------------------<<
    //        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //        && (employeeDtl1.OldBelongSectionCd == employeeDtl2.OldBelongSectionCd)
    //        && (employeeDtl1.OldBelongSectionNm == employeeDtl2.OldBelongSectionNm)
    //        && (employeeDtl1.OldBelongSubSecCd == employeeDtl2.OldBelongSubSecCd)
    //        && (employeeDtl1.OldBelongSubSecNm == employeeDtl2.OldBelongSubSecNm)
    //        && (employeeDtl1.OldBelongMinSecCd == employeeDtl2.OldBelongMinSecCd)
    //        && (employeeDtl1.OldBelongMinSecNm == employeeDtl2.OldBelongMinSecNm)
    //        && (employeeDtl1.SectionChgDate == employeeDtl2.SectionChgDate));
    //           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
    //    }
    //    /// <summary>
    //    /// 従業員詳細ワーク比較処理
    //    /// </summary>
    //    /// <param name="target">比較対象のEmployeeDtlクラスのインスタンス</param>
    //    /// <returns>一致しない項目のリスト</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   EmployeeDtlクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public ArrayList Compare(EmployeeDtl target)
    //    {
    //        ArrayList resList = new ArrayList();
    //        if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
    //        if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
    //        if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
    //        if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
    //        if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
    //        if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
    //        if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
    //        if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
    //        if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
    //        if (this.BelongSubSectionCode != target.BelongSubSectionCode) resList.Add("BelongSubSectionCode");
    //        if (this.BelongSubSectionName != target.BelongSubSectionName) resList.Add("BelongSubSectionName");
    //        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //        if (this.BelongMinSectionCode != target.BelongMinSectionCode) resList.Add("BelongMinSectionCode");
    //        if (this.BelongMinSectionName != target.BelongMinSectionName) resList.Add("BelongMinSectionName");
    //           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
    //        if (this.BelongSalesAreaCode != target.BelongSalesAreaCode) resList.Add("BelongSalesAreaCode");
    //        if (this.BelongSalesAreaName != target.BelongSalesAreaName) resList.Add("BelongSalesAreaName");
    //        if (this.EmployAnalysCode1 != target.EmployAnalysCode1) resList.Add("EmployAnalysCode1");
    //        if (this.EmployAnalysCode2 != target.EmployAnalysCode2) resList.Add("EmployAnalysCode2");
    //        if (this.EmployAnalysCode3 != target.EmployAnalysCode3) resList.Add("EmployAnalysCode3");
    //        if (this.EmployAnalysCode4 != target.EmployAnalysCode4) resList.Add("EmployAnalysCode4");
    //        if (this.EmployAnalysCode5 != target.EmployAnalysCode5) resList.Add("EmployAnalysCode5");
    //        if (this.EmployAnalysCode6 != target.EmployAnalysCode6) resList.Add("EmployAnalysCode6");
    //        //2008.11.10 add start -------------------------------------------------------------->>
    //        if (this.UOESnmDiv != target.UOESnmDiv) resList.Add("UOESnmDiv");
    //        //2008.11.10 add end ----------------------------------------------------------------<<
    //        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //        if (this.OldBelongSectionCd != target.OldBelongSectionCd) resList.Add("OldBelongSectionCd");
    //        if (this.OldBelongSectionNm != target.OldBelongSectionNm) resList.Add("OldBelongSectionNm");
    //        if (this.OldBelongSubSecCd != target.OldBelongSubSecCd) resList.Add("OldBelongSubSecCd");
    //        if (this.OldBelongSubSecNm != target.OldBelongSubSecNm) resList.Add("OldBelongSubSecNm");
    //        if (this.OldBelongMinSecCd != target.OldBelongMinSecCd) resList.Add("OldBelongMinSecCd");
    //        if (this.OldBelongMinSecNm != target.OldBelongMinSecNm) resList.Add("OldBelongMinSecNm");
    //        if (this.SectionChgDate != target.SectionChgDate) resList.Add("SectionChgDate");
    //           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

    //        return resList;
    //    }

    //    /// <summary>
    //    /// 従業員詳細ワーク比較処理
    //    /// </summary>
    //    /// <param name="employeeDtl1">比較するEmployeeDtlクラスのインスタンス</param>
    //    /// <param name="employeeDtl2">比較するEmployeeDtlクラスのインスタンス</param>
    //    /// <returns>一致しない項目のリスト</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   EmployeeDtlクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public static ArrayList Compare(EmployeeDtl employeeDtl1, EmployeeDtl employeeDtl2)
    //    {
    //        ArrayList resList = new ArrayList();
    //        if (employeeDtl1.CreateDateTime != employeeDtl2.CreateDateTime) resList.Add("CreateDateTime");
    //        if (employeeDtl1.UpdateDateTime != employeeDtl2.UpdateDateTime) resList.Add("UpdateDateTime");
    //        if (employeeDtl1.EnterpriseCode != employeeDtl2.EnterpriseCode) resList.Add("EnterpriseCode");
    //        if (employeeDtl1.FileHeaderGuid != employeeDtl2.FileHeaderGuid) resList.Add("FileHeaderGuid");
    //        if (employeeDtl1.UpdEmployeeCode != employeeDtl2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
    //        if (employeeDtl1.UpdAssemblyId1 != employeeDtl2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
    //        if (employeeDtl1.UpdAssemblyId2 != employeeDtl2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
    //        if (employeeDtl1.LogicalDeleteCode != employeeDtl2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
    //        if (employeeDtl1.EmployeeCode != employeeDtl2.EmployeeCode) resList.Add("EmployeeCode");
    //        if (employeeDtl1.BelongSubSectionCode != employeeDtl2.BelongSubSectionCode) resList.Add("BelongSubSectionCode");
    //        if (employeeDtl1.BelongSubSectionName != employeeDtl2.BelongSubSectionName) resList.Add("BelongSubSectionName");
    //        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //        if (employeeDtl1.BelongMinSectionCode != employeeDtl2.BelongMinSectionCode) resList.Add("BelongMinSectionCode");
    //        if (employeeDtl1.BelongMinSectionName != employeeDtl2.BelongMinSectionName) resList.Add("BelongMinSectionName");
    //           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
    //        if (employeeDtl1.BelongSalesAreaCode != employeeDtl2.BelongSalesAreaCode) resList.Add("BelongSalesAreaCode");
    //        if (employeeDtl1.BelongSalesAreaName != employeeDtl2.BelongSalesAreaName) resList.Add("BelongSalesAreaName");
    //        if (employeeDtl1.EmployAnalysCode1 != employeeDtl2.EmployAnalysCode1) resList.Add("EmployAnalysCode1");
    //        if (employeeDtl1.EmployAnalysCode2 != employeeDtl2.EmployAnalysCode2) resList.Add("EmployAnalysCode2");
    //        if (employeeDtl1.EmployAnalysCode3 != employeeDtl2.EmployAnalysCode3) resList.Add("EmployAnalysCode3");
    //        if (employeeDtl1.EmployAnalysCode4 != employeeDtl2.EmployAnalysCode4) resList.Add("EmployAnalysCode4");
    //        if (employeeDtl1.EmployAnalysCode5 != employeeDtl2.EmployAnalysCode5) resList.Add("EmployAnalysCode5");
    //        if (employeeDtl1.EmployAnalysCode6 != employeeDtl2.EmployAnalysCode6) resList.Add("EmployAnalysCode6");
    //        //2008.11.10 add start -------------------------------------------------------------->>
    //        if (employeeDtl1.UOESnmDiv != employeeDtl2.UOESnmDiv) resList.Add("UOESnmDiv");
    //        //2008.11.10 add end ----------------------------------------------------------------<<
    //        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
    //        if (employeeDtl1.OldBelongSectionCd != employeeDtl2.OldBelongSectionCd) resList.Add("OldBelongSectionCd");
    //        if (employeeDtl1.OldBelongSectionNm != employeeDtl2.OldBelongSectionNm) resList.Add("OldBelongSectionNm");
    //        if (employeeDtl1.OldBelongSubSecCd != employeeDtl2.OldBelongSubSecCd) resList.Add("OldBelongSubSecCd");
    //        if (employeeDtl1.OldBelongSubSecNm != employeeDtl2.OldBelongSubSecNm) resList.Add("OldBelongSubSecNm");
    //        if (employeeDtl1.OldBelongMinSecCd != employeeDtl2.OldBelongMinSecCd) resList.Add("OldBelongMinSecCd");
    //        if (employeeDtl1.OldBelongMinSecNm != employeeDtl2.OldBelongMinSecNm) resList.Add("OldBelongMinSecNm");
    //        if (employeeDtl1.SectionChgDate != employeeDtl2.SectionChgDate) resList.Add("SectionChgDate");
    //           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

    //        return resList;
    //    }
    //}
    #endregion

    /// public class name:   EmployeeDtl
    /// <summary>
    ///                      従業員詳細マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   従業員詳細マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/17</br>
    /// <br>Genarated Date   :   2009/03/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/7/4  長内</br>
    /// <br>                 :   追加項目</br>
    /// <br>                 :   UOE略称区分</br>
    /// <br>Update Note      :   2/3  杉村</br>
    /// <br>                 :   追加項目</br>
    /// <br>                 :   メールアドレス種別コード1</br>
    /// <br>                 :   メールアドレス種別名称1</br>
    /// <br>                 :   メールアドレス1</br>
    /// <br>                 :   メール送信区分コード1</br>
    /// <br>                 :   メールアドレス種別コード2</br>
    /// <br>                 :   メールアドレス種別名称2</br>
    /// <br>                 :   メールアドレス2</br>
    /// <br>                 :   メール送信区分コード2</br>
    /// </remarks>
    public class EmployeeDtl
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

        /// <summary>従業員コード</summary>
        private string _employeeCode = "";

        /// <summary>所属部門コード</summary>
        /// <remarks>※部門管理しない場合は、使用しない</remarks>
        private Int32 _belongSubSectionCode;

        /// <summary>従業員分析コード１</summary>
        /// <remarks>年齢,グループ等分析用任意コードを設定</remarks>
        private Int32 _employAnalysCode1;

        /// <summary>従業員分析コード２</summary>
        /// <remarks>※マスタ管理しないため、コードはユーザー管理となる</remarks>
        private Int32 _employAnalysCode2;

        /// <summary>従業員分析コード３</summary>
        private Int32 _employAnalysCode3;

        /// <summary>従業員分析コード４</summary>
        private Int32 _employAnalysCode4;

        /// <summary>従業員分析コード５</summary>
        private Int32 _employAnalysCode5;

        /// <summary>従業員分析コード６</summary>
        private Int32 _employAnalysCode6;

        /// <summary>UOE略称区分</summary>
        private string _uOESnmDiv = "";

        /// <summary>メールアドレス種別コード1</summary>
        /// <remarks>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</remarks>
        private Int32 _mailAddrKindCode1;

        /// <summary>メールアドレス種別名称1</summary>
        private string _mailAddrKindName1 = "";

        /// <summary>メールアドレス1</summary>
        private string _mailAddress1 = "";

        /// <summary>メール送信区分コード1</summary>
        /// <remarks>0:非送信,1:送信</remarks>
        private Int32 _mailSendCode1;

        /// <summary>メールアドレス種別コード2</summary>
        /// <remarks>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</remarks>
        private Int32 _mailAddrKindCode2;

        /// <summary>メールアドレス種別名称2</summary>
        private string _mailAddrKindName2 = "";

        /// <summary>メールアドレス2</summary>
        private string _mailAddress2 = "";

        /// <summary>メール送信区分コード2</summary>
        /// <remarks>0:非送信,1:送信</remarks>
        private Int32 _mailSendCode2;

        /// <summary>所属部門名称</summary>
        /// <remarks>※部門管理しない場合は、使用しない</remarks>
        private string _belongSubSectionName = "";

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

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  BelongSubSectionCode
        /// <summary>所属部門コードプロパティ</summary>
        /// <value>※部門管理しない場合は、使用しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   所属部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BelongSubSectionCode
        {
            get { return _belongSubSectionCode; }
            set { _belongSubSectionCode = value; }
        }

        /// public propaty name  :  EmployAnalysCode1
        /// <summary>従業員分析コード１プロパティ</summary>
        /// <value>年齢,グループ等分析用任意コードを設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員分析コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployAnalysCode1
        {
            get { return _employAnalysCode1; }
            set { _employAnalysCode1 = value; }
        }

        /// public propaty name  :  EmployAnalysCode2
        /// <summary>従業員分析コード２プロパティ</summary>
        /// <value>※マスタ管理しないため、コードはユーザー管理となる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員分析コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployAnalysCode2
        {
            get { return _employAnalysCode2; }
            set { _employAnalysCode2 = value; }
        }

        /// public propaty name  :  EmployAnalysCode3
        /// <summary>従業員分析コード３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員分析コード３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployAnalysCode3
        {
            get { return _employAnalysCode3; }
            set { _employAnalysCode3 = value; }
        }

        /// public propaty name  :  EmployAnalysCode4
        /// <summary>従業員分析コード４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員分析コード４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployAnalysCode4
        {
            get { return _employAnalysCode4; }
            set { _employAnalysCode4 = value; }
        }

        /// public propaty name  :  EmployAnalysCode5
        /// <summary>従業員分析コード５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員分析コード５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployAnalysCode5
        {
            get { return _employAnalysCode5; }
            set { _employAnalysCode5 = value; }
        }

        /// public propaty name  :  EmployAnalysCode6
        /// <summary>従業員分析コード６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員分析コード６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployAnalysCode6
        {
            get { return _employAnalysCode6; }
            set { _employAnalysCode6 = value; }
        }

        /// public propaty name  :  UOESnmDiv
        /// <summary>UOE略称区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE略称区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESnmDiv
        {
            get { return _uOESnmDiv; }
            set { _uOESnmDiv = value; }
        }

        /// public propaty name  :  MailAddrKindCode1
        /// <summary>メールアドレス種別コード1プロパティ</summary>
        /// <value>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailAddrKindCode1
        {
            get { return _mailAddrKindCode1; }
            set { _mailAddrKindCode1 = value; }
        }

        /// public propaty name  :  MailAddrKindName1
        /// <summary>メールアドレス種別名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddrKindName1
        {
            get { return _mailAddrKindName1; }
            set { _mailAddrKindName1 = value; }
        }

        /// public propaty name  :  MailAddress1
        /// <summary>メールアドレス1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddress1
        {
            get { return _mailAddress1; }
            set { _mailAddress1 = value; }
        }

        /// public propaty name  :  MailSendCode1
        /// <summary>メール送信区分コード1プロパティ</summary>
        /// <value>0:非送信,1:送信</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メール送信区分コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailSendCode1
        {
            get { return _mailSendCode1; }
            set { _mailSendCode1 = value; }
        }

        /// public propaty name  :  MailAddrKindCode2
        /// <summary>メールアドレス種別コード2プロパティ</summary>
        /// <value>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailAddrKindCode2
        {
            get { return _mailAddrKindCode2; }
            set { _mailAddrKindCode2 = value; }
        }

        /// public propaty name  :  MailAddrKindName2
        /// <summary>メールアドレス種別名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddrKindName2
        {
            get { return _mailAddrKindName2; }
            set { _mailAddrKindName2 = value; }
        }

        /// public propaty name  :  MailAddress2
        /// <summary>メールアドレス2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddress2
        {
            get { return _mailAddress2; }
            set { _mailAddress2 = value; }
        }

        /// public propaty name  :  MailSendCode2
        /// <summary>メール送信区分コード2プロパティ</summary>
        /// <value>0:非送信,1:送信</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メール送信区分コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailSendCode2
        {
            get { return _mailSendCode2; }
            set { _mailSendCode2 = value; }
        }

        /// public propaty name  :  BelongSubSectionName
        /// <summary>所属部門名称プロパティ</summary>
        /// <value>※部門管理しない場合は、使用しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   所属部門名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BelongSubSectionName
        {
            get { return _belongSubSectionName; }
            set { _belongSubSectionName = value; }
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
        /// 従業員詳細マスタコンストラクタ
        /// </summary>
        /// <returns>EmployeeDtlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeDtlクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EmployeeDtl()
        {
        }

        /// <summary>
        /// 従業員詳細マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="belongSubSectionCode">所属部門コード(※部門管理しない場合は、使用しない)</param>
        /// <param name="employAnalysCode1">従業員分析コード１(年齢,グループ等分析用任意コードを設定)</param>
        /// <param name="employAnalysCode2">従業員分析コード２(※マスタ管理しないため、コードはユーザー管理となる)</param>
        /// <param name="employAnalysCode3">従業員分析コード３</param>
        /// <param name="employAnalysCode4">従業員分析コード４</param>
        /// <param name="employAnalysCode5">従業員分析コード５</param>
        /// <param name="employAnalysCode6">従業員分析コード６</param>
        /// <param name="uOESnmDiv">UOE略称区分</param>
        /// <param name="mailAddrKindCode1">メールアドレス種別コード1(0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他)</param>
        /// <param name="mailAddrKindName1">メールアドレス種別名称1</param>
        /// <param name="mailAddress1">メールアドレス1</param>
        /// <param name="mailSendCode1">メール送信区分コード1(0:非送信,1:送信)</param>
        /// <param name="mailAddrKindCode2">メールアドレス種別コード2(0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他)</param>
        /// <param name="mailAddrKindName2">メールアドレス種別名称2</param>
        /// <param name="mailAddress2">メールアドレス2</param>
        /// <param name="mailSendCode2">メール送信区分コード2(0:非送信,1:送信)</param>
        /// <param name="belongSubSectionName">所属部門名称(※部門管理しない場合は、使用しない)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>EmployeeDtlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeDtlクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EmployeeDtl(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string employeeCode, Int32 belongSubSectionCode, Int32 employAnalysCode1, Int32 employAnalysCode2, Int32 employAnalysCode3, Int32 employAnalysCode4, Int32 employAnalysCode5, Int32 employAnalysCode6, string uOESnmDiv, Int32 mailAddrKindCode1, string mailAddrKindName1, string mailAddress1, Int32 mailSendCode1, Int32 mailAddrKindCode2, string mailAddrKindName2, string mailAddress2, Int32 mailSendCode2, string belongSubSectionName, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._employeeCode = employeeCode;
            this._belongSubSectionCode = belongSubSectionCode;
            this._employAnalysCode1 = employAnalysCode1;
            this._employAnalysCode2 = employAnalysCode2;
            this._employAnalysCode3 = employAnalysCode3;
            this._employAnalysCode4 = employAnalysCode4;
            this._employAnalysCode5 = employAnalysCode5;
            this._employAnalysCode6 = employAnalysCode6;
            this._uOESnmDiv = uOESnmDiv;
            this._mailAddrKindCode1 = mailAddrKindCode1;
            this._mailAddrKindName1 = mailAddrKindName1;
            this._mailAddress1 = mailAddress1;
            this._mailSendCode1 = mailSendCode1;
            this._mailAddrKindCode2 = mailAddrKindCode2;
            this._mailAddrKindName2 = mailAddrKindName2;
            this._mailAddress2 = mailAddress2;
            this._mailSendCode2 = mailSendCode2;
            this._belongSubSectionName = belongSubSectionName;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// 従業員詳細マスタ複製処理
        /// </summary>
        /// <returns>EmployeeDtlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいEmployeeDtlクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EmployeeDtl Clone()
        {
            return new EmployeeDtl(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._employeeCode, this._belongSubSectionCode, this._employAnalysCode1, this._employAnalysCode2, this._employAnalysCode3, this._employAnalysCode4, this._employAnalysCode5, this._employAnalysCode6, this._uOESnmDiv, this._mailAddrKindCode1, this._mailAddrKindName1, this._mailAddress1, this._mailSendCode1, this._mailAddrKindCode2, this._mailAddrKindName2, this._mailAddress2, this._mailSendCode2, this._belongSubSectionName, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// 従業員詳細マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のEmployeeDtlクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeDtlクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool EqualsDtl(EmployeeDtl target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.BelongSubSectionCode == target.BelongSubSectionCode)
                 && (this.EmployAnalysCode1 == target.EmployAnalysCode1)
                 && (this.EmployAnalysCode2 == target.EmployAnalysCode2)
                 && (this.EmployAnalysCode3 == target.EmployAnalysCode3)
                 && (this.EmployAnalysCode4 == target.EmployAnalysCode4)
                 && (this.EmployAnalysCode5 == target.EmployAnalysCode5)
                 && (this.EmployAnalysCode6 == target.EmployAnalysCode6)
                 && (this.UOESnmDiv == target.UOESnmDiv)
                 && (this.MailAddrKindCode1 == target.MailAddrKindCode1)
                 && (this.MailAddrKindName1 == target.MailAddrKindName1)
                 && (this.MailAddress1 == target.MailAddress1)
                 && (this.MailSendCode1 == target.MailSendCode1)
                 && (this.MailAddrKindCode2 == target.MailAddrKindCode2)
                 && (this.MailAddrKindName2 == target.MailAddrKindName2)
                 && (this.MailAddress2 == target.MailAddress2)
                 && (this.MailSendCode2 == target.MailSendCode2)
                 && (this.BelongSubSectionName == target.BelongSubSectionName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// 従業員詳細マスタ比較処理
        /// </summary>
        /// <param name="employeeDtl1">
        ///                    比較するEmployeeDtlクラスのインスタンス
        /// </param>
        /// <param name="employeeDtl2">比較するEmployeeDtlクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeDtlクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool EqualsDtl(EmployeeDtl employeeDtl1, EmployeeDtl employeeDtl2)
        {
            return ((employeeDtl1.CreateDateTime == employeeDtl2.CreateDateTime)
                 && (employeeDtl1.UpdateDateTime == employeeDtl2.UpdateDateTime)
                 && (employeeDtl1.EnterpriseCode == employeeDtl2.EnterpriseCode)
                 && (employeeDtl1.FileHeaderGuid == employeeDtl2.FileHeaderGuid)
                 && (employeeDtl1.UpdEmployeeCode == employeeDtl2.UpdEmployeeCode)
                 && (employeeDtl1.UpdAssemblyId1 == employeeDtl2.UpdAssemblyId1)
                 && (employeeDtl1.UpdAssemblyId2 == employeeDtl2.UpdAssemblyId2)
                 && (employeeDtl1.LogicalDeleteCode == employeeDtl2.LogicalDeleteCode)
                 && (employeeDtl1.EmployeeCode == employeeDtl2.EmployeeCode)
                 && (employeeDtl1.BelongSubSectionCode == employeeDtl2.BelongSubSectionCode)
                 && (employeeDtl1.EmployAnalysCode1 == employeeDtl2.EmployAnalysCode1)
                 && (employeeDtl1.EmployAnalysCode2 == employeeDtl2.EmployAnalysCode2)
                 && (employeeDtl1.EmployAnalysCode3 == employeeDtl2.EmployAnalysCode3)
                 && (employeeDtl1.EmployAnalysCode4 == employeeDtl2.EmployAnalysCode4)
                 && (employeeDtl1.EmployAnalysCode5 == employeeDtl2.EmployAnalysCode5)
                 && (employeeDtl1.EmployAnalysCode6 == employeeDtl2.EmployAnalysCode6)
                 && (employeeDtl1.UOESnmDiv == employeeDtl2.UOESnmDiv)
                 && (employeeDtl1.MailAddrKindCode1 == employeeDtl2.MailAddrKindCode1)
                 && (employeeDtl1.MailAddrKindName1 == employeeDtl2.MailAddrKindName1)
                 && (employeeDtl1.MailAddress1 == employeeDtl2.MailAddress1)
                 && (employeeDtl1.MailSendCode1 == employeeDtl2.MailSendCode1)
                 && (employeeDtl1.MailAddrKindCode2 == employeeDtl2.MailAddrKindCode2)
                 && (employeeDtl1.MailAddrKindName2 == employeeDtl2.MailAddrKindName2)
                 && (employeeDtl1.MailAddress2 == employeeDtl2.MailAddress2)
                 && (employeeDtl1.MailSendCode2 == employeeDtl2.MailSendCode2)
                 && (employeeDtl1.BelongSubSectionName == employeeDtl2.BelongSubSectionName)
                 && (employeeDtl1.EnterpriseName == employeeDtl2.EnterpriseName)
                 && (employeeDtl1.UpdEmployeeName == employeeDtl2.UpdEmployeeName));
        }
        /// <summary>
        /// 従業員詳細マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のEmployeeDtlクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeDtlクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(EmployeeDtl target)
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
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.BelongSubSectionCode != target.BelongSubSectionCode) resList.Add("BelongSubSectionCode");
            if (this.EmployAnalysCode1 != target.EmployAnalysCode1) resList.Add("EmployAnalysCode1");
            if (this.EmployAnalysCode2 != target.EmployAnalysCode2) resList.Add("EmployAnalysCode2");
            if (this.EmployAnalysCode3 != target.EmployAnalysCode3) resList.Add("EmployAnalysCode3");
            if (this.EmployAnalysCode4 != target.EmployAnalysCode4) resList.Add("EmployAnalysCode4");
            if (this.EmployAnalysCode5 != target.EmployAnalysCode5) resList.Add("EmployAnalysCode5");
            if (this.EmployAnalysCode6 != target.EmployAnalysCode6) resList.Add("EmployAnalysCode6");
            if (this.UOESnmDiv != target.UOESnmDiv) resList.Add("UOESnmDiv");
            if (this.MailAddrKindCode1 != target.MailAddrKindCode1) resList.Add("MailAddrKindCode1");
            if (this.MailAddrKindName1 != target.MailAddrKindName1) resList.Add("MailAddrKindName1");
            if (this.MailAddress1 != target.MailAddress1) resList.Add("MailAddress1");
            if (this.MailSendCode1 != target.MailSendCode1) resList.Add("MailSendCode1");
            if (this.MailAddrKindCode2 != target.MailAddrKindCode2) resList.Add("MailAddrKindCode2");
            if (this.MailAddrKindName2 != target.MailAddrKindName2) resList.Add("MailAddrKindName2");
            if (this.MailAddress2 != target.MailAddress2) resList.Add("MailAddress2");
            if (this.MailSendCode2 != target.MailSendCode2) resList.Add("MailSendCode2");
            if (this.BelongSubSectionName != target.BelongSubSectionName) resList.Add("BelongSubSectionName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// 従業員詳細マスタ比較処理
        /// </summary>
        /// <param name="employeeDtl1">比較するEmployeeDtlクラスのインスタンス</param>
        /// <param name="employeeDtl2">比較するEmployeeDtlクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeDtlクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(EmployeeDtl employeeDtl1, EmployeeDtl employeeDtl2)
        {
            ArrayList resList = new ArrayList();
            if (employeeDtl1.CreateDateTime != employeeDtl2.CreateDateTime) resList.Add("CreateDateTime");
            if (employeeDtl1.UpdateDateTime != employeeDtl2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (employeeDtl1.EnterpriseCode != employeeDtl2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (employeeDtl1.FileHeaderGuid != employeeDtl2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (employeeDtl1.UpdEmployeeCode != employeeDtl2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (employeeDtl1.UpdAssemblyId1 != employeeDtl2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (employeeDtl1.UpdAssemblyId2 != employeeDtl2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (employeeDtl1.LogicalDeleteCode != employeeDtl2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (employeeDtl1.EmployeeCode != employeeDtl2.EmployeeCode) resList.Add("EmployeeCode");
            if (employeeDtl1.BelongSubSectionCode != employeeDtl2.BelongSubSectionCode) resList.Add("BelongSubSectionCode");
            if (employeeDtl1.EmployAnalysCode1 != employeeDtl2.EmployAnalysCode1) resList.Add("EmployAnalysCode1");
            if (employeeDtl1.EmployAnalysCode2 != employeeDtl2.EmployAnalysCode2) resList.Add("EmployAnalysCode2");
            if (employeeDtl1.EmployAnalysCode3 != employeeDtl2.EmployAnalysCode3) resList.Add("EmployAnalysCode3");
            if (employeeDtl1.EmployAnalysCode4 != employeeDtl2.EmployAnalysCode4) resList.Add("EmployAnalysCode4");
            if (employeeDtl1.EmployAnalysCode5 != employeeDtl2.EmployAnalysCode5) resList.Add("EmployAnalysCode5");
            if (employeeDtl1.EmployAnalysCode6 != employeeDtl2.EmployAnalysCode6) resList.Add("EmployAnalysCode6");
            if (employeeDtl1.UOESnmDiv != employeeDtl2.UOESnmDiv) resList.Add("UOESnmDiv");
            if (employeeDtl1.MailAddrKindCode1 != employeeDtl2.MailAddrKindCode1) resList.Add("MailAddrKindCode1");
            if (employeeDtl1.MailAddrKindName1 != employeeDtl2.MailAddrKindName1) resList.Add("MailAddrKindName1");
            if (employeeDtl1.MailAddress1 != employeeDtl2.MailAddress1) resList.Add("MailAddress1");
            if (employeeDtl1.MailSendCode1 != employeeDtl2.MailSendCode1) resList.Add("MailSendCode1");
            if (employeeDtl1.MailAddrKindCode2 != employeeDtl2.MailAddrKindCode2) resList.Add("MailAddrKindCode2");
            if (employeeDtl1.MailAddrKindName2 != employeeDtl2.MailAddrKindName2) resList.Add("MailAddrKindName2");
            if (employeeDtl1.MailAddress2 != employeeDtl2.MailAddress2) resList.Add("MailAddress2");
            if (employeeDtl1.MailSendCode2 != employeeDtl2.MailSendCode2) resList.Add("MailSendCode2");
            if (employeeDtl1.BelongSubSectionName != employeeDtl2.BelongSubSectionName) resList.Add("BelongSubSectionName");
            if (employeeDtl1.EnterpriseName != employeeDtl2.EnterpriseName) resList.Add("EnterpriseName");
            if (employeeDtl1.UpdEmployeeName != employeeDtl2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
    // 2009.03.02 自動生成へ置き換え(手動変更箇所：1.Equals→EqualsDtl 2.所属部門名称(belongSubSectionName)の追加) <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
}
