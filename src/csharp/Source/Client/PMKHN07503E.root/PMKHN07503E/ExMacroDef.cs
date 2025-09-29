using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExMacroDef
	/// <summary>
	///                      拡張マクロ文字定義マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   拡張マクロ文字定義マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2006/10/18  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class ExMacroDef
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

		/// <summary>拡張マクロ文字管理連番</summary>
		private Int32 _exMacroCharMngCnsNo;

		/// <summary>拡張マクロ文字名称</summary>
		private string _exMacroCharName = "";

		/// <summary>拡張マクロ文字</summary>
		/// <remarks>マクロ文字の最小定義</remarks>
		private string _exMacroCharcter = "";

		/// <summary>拡張マクロ文字展開文字数</summary>
		/// <remarks>マクロ文字を展開する(エディタ等)際のデフォルト文字数</remarks>
		private Int32 _exMacroCharDvlpCnt;

		/// <summary>拡張マクロ文字変換文字数</summary>
		/// <remarks>マクロ文字→データ値変換時の最大文字数</remarks>
		private Int32 _exMacroCharChngCnt;

		/// <summary>拡張マクロ文字変換DD</summary>
		private string _exMacroCharChngDd = "";

		/// <summary>拡張マクロ文字補足説明</summary>
		private string _exMacroCharAddExpla = "";

		/// <summary>拡張マクロ文字変換例</summary>
		private string _exMacroCharChgSample = "";

		/// <summary>拡張マクロ変換編集定義1</summary>
		/// <remarks>変換データが無い場合に置き換えるデフォルト文字列</remarks>
		private string _exMacroCharChgEdDef1 = "";

		/// <summary>拡張マクロ変換編集定義2</summary>
		/// <remarks>文字列編集区分0:編集無, 1:両トリム, 2:右トリム, 3:左トリム, 12:右詰編集, 15:センタリング</remarks>
		private Int32 _exMacroCharChgEdDef2;

		/// <summary>拡張マクロプライバシーポリシー</summary>
		/// <remarks>0:チェック無し, 1:チェックする</remarks>
        private Int32 _exMacroPrivacyPolicy = 0;

        /// <summary>拡張マクロ型種別</summary>
        /// <remarks>0:文字項目, 1:数値項目</remarks>
        private Int32 _exMacroTypeKind = 0;


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
			get{return _createDateTime;}
			set{_createDateTime = value;}
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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
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
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
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

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  ExMacroCharMngCnsNo
		/// <summary>拡張マクロ文字管理連番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拡張マクロ文字管理連番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ExMacroCharMngCnsNo
		{
			get{return _exMacroCharMngCnsNo;}
			set{_exMacroCharMngCnsNo = value;}
		}

		/// public propaty name  :  ExMacroCharName
		/// <summary>拡張マクロ文字名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拡張マクロ文字名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ExMacroCharName
		{
			get{return _exMacroCharName;}
			set{_exMacroCharName = value;}
		}

		/// public propaty name  :  ExMacroCharcter
		/// <summary>拡張マクロ文字プロパティ</summary>
		/// <value>マクロ文字の最小定義</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拡張マクロ文字プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ExMacroCharcter
		{
			get{return _exMacroCharcter;}
			set{_exMacroCharcter = value;}
		}

		/// public propaty name  :  ExMacroCharDvlpCnt
		/// <summary>拡張マクロ文字展開文字数プロパティ</summary>
		/// <value>マクロ文字を展開する(エディタ等)際のデフォルト文字数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拡張マクロ文字展開文字数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ExMacroCharDvlpCnt
		{
			get{return _exMacroCharDvlpCnt;}
			set{_exMacroCharDvlpCnt = value;}
		}

		/// public propaty name  :  ExMacroCharChngCnt
		/// <summary>拡張マクロ文字変換文字数プロパティ</summary>
		/// <value>マクロ文字→データ値変換時の最大文字数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拡張マクロ文字変換文字数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ExMacroCharChngCnt
		{
			get{return _exMacroCharChngCnt;}
			set{_exMacroCharChngCnt = value;}
		}

		/// public propaty name  :  ExMacroCharChngDd
		/// <summary>拡張マクロ文字変換DDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拡張マクロ文字変換DDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ExMacroCharChngDd
		{
			get{return _exMacroCharChngDd;}
			set{_exMacroCharChngDd = value;}
		}

		/// public propaty name  :  ExMacroCharAddExpla
		/// <summary>拡張マクロ文字補足説明プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拡張マクロ文字補足説明プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ExMacroCharAddExpla
		{
			get{return _exMacroCharAddExpla;}
			set{_exMacroCharAddExpla = value;}
		}

		/// public propaty name  :  ExMacroCharChgSample
		/// <summary>拡張マクロ文字変換例プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拡張マクロ文字変換例プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ExMacroCharChgSample
		{
			get{return _exMacroCharChgSample;}
			set{_exMacroCharChgSample = value;}
		}

		/// public propaty name  :  ExMacroCharChgEdDef1
		/// <summary>拡張マクロ変換編集定義1プロパティ</summary>
		/// <value>変換データが無い場合に置き換えるデフォルト文字列</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拡張マクロ変換編集定義1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ExMacroCharChgEdDef1
		{
			get{return _exMacroCharChgEdDef1;}
			set{_exMacroCharChgEdDef1 = value;}
		}

		/// public propaty name  :  ExMacroCharChgEdDef2
		/// <summary>拡張マクロ変換編集定義2プロパティ</summary>
		/// <value>文字列編集区分0:編集無, 1:両トリム, 2:右トリム, 3:左トリム, 12:右詰編集, 15:センタリング</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拡張マクロ変換編集定義2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ExMacroCharChgEdDef2
		{
			get{return _exMacroCharChgEdDef2;}
			set{_exMacroCharChgEdDef2 = value;}
		}

		/// public propaty name  :  ExMacroPrivacyPolicy
		/// <summary>拡張マクロプライバシーポリシープロパティ</summary>
		/// <value>0:チェック無し, 1:チェックする</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拡張マクロプライバシーポリシープロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ExMacroPrivacyPolicy
		{
			get{return _exMacroPrivacyPolicy;}
			set{_exMacroPrivacyPolicy = value;}
		}

        /// public propaty name  :  ExMacroPrivacyPolicy
        /// <summary>拡張マクロ型種別プロパティ</summary>
        /// <value>0:文字項目, 1:数値項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拡張マクロ型種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ExMacroTypeKind
        {
            get { return _exMacroTypeKind; }
            set { _exMacroTypeKind = value; }
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


		/// <summary>
		/// 拡張マクロ文字定義マスタコンストラクタ
		/// </summary>
		/// <returns>ExMacroDefクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExMacroDefクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExMacroDef()
		{
		}

		/// <summary>
		/// 拡張マクロ文字定義マスタコンストラクタ
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
		/// <param name="exMacroCharMngCnsNo">拡張マクロ文字管理連番</param>
		/// <param name="exMacroCharName">拡張マクロ文字名称</param>
		/// <param name="exMacroCharcter">拡張マクロ文字(マクロ文字の最小定義)</param>
		/// <param name="exMacroCharDvlpCnt">拡張マクロ文字展開文字数(マクロ文字を展開する(エディタ等)際のデフォルト文字数)</param>
		/// <param name="exMacroCharChngCnt">拡張マクロ文字変換文字数(マクロ文字→データ値変換時の最大文字数)</param>
		/// <param name="exMacroCharChngDd">拡張マクロ文字変換DD</param>
		/// <param name="exMacroCharAddExpla">拡張マクロ文字補足説明</param>
		/// <param name="exMacroCharChgSample">拡張マクロ文字変換例</param>
		/// <param name="exMacroCharChgEdDef1">拡張マクロ変換編集定義1(変換データが無い場合に置き換えるデフォルト文字列)</param>
		/// <param name="exMacroCharChgEdDef2">拡張マクロ変換編集定義2(文字列編集区分0:編集無, 1:両トリム, 2:右トリム, 3:左トリム, 12:右詰編集, 15:センタリング)</param>
		/// <param name="exMacroPrivacyPolicy">拡張マクロプライバシーポリシー(0:チェック無し, 1:チェックする)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>ExMacroDefクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExMacroDefクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExMacroDef(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string sectionCode,Int32 exMacroCharMngCnsNo,string exMacroCharName,string exMacroCharcter,Int32 exMacroCharDvlpCnt,Int32 exMacroCharChngCnt,string exMacroCharChngDd,string exMacroCharAddExpla,string exMacroCharChgSample,string exMacroCharChgEdDef1,Int32 exMacroCharChgEdDef2,Int32 exMacroPrivacyPolicy,string enterpriseName,string updEmployeeName)
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
			this._exMacroCharMngCnsNo = exMacroCharMngCnsNo;
			this._exMacroCharName = exMacroCharName;
			this._exMacroCharcter = exMacroCharcter;
			this._exMacroCharDvlpCnt = exMacroCharDvlpCnt;
			this._exMacroCharChngCnt = exMacroCharChngCnt;
			this._exMacroCharChngDd = exMacroCharChngDd;
			this._exMacroCharAddExpla = exMacroCharAddExpla;
			this._exMacroCharChgSample = exMacroCharChgSample;
			this._exMacroCharChgEdDef1 = exMacroCharChgEdDef1;
			this._exMacroCharChgEdDef2 = exMacroCharChgEdDef2;
			this._exMacroPrivacyPolicy = exMacroPrivacyPolicy;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// 拡張マクロ文字定義マスタ複製処理
		/// </summary>
		/// <returns>ExMacroDefクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいExMacroDefクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExMacroDef Clone()
		{
			return new ExMacroDef(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._sectionCode,this._exMacroCharMngCnsNo,this._exMacroCharName,this._exMacroCharcter,this._exMacroCharDvlpCnt,this._exMacroCharChngCnt,this._exMacroCharChngDd,this._exMacroCharAddExpla,this._exMacroCharChgSample,this._exMacroCharChgEdDef1,this._exMacroCharChgEdDef2,this._exMacroPrivacyPolicy,this._enterpriseName,this._updEmployeeName);
		}

		/// <summary>
		/// 拡張マクロ文字定義マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のExMacroDefクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExMacroDefクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ExMacroDef target)
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
				 && (this.ExMacroCharMngCnsNo == target.ExMacroCharMngCnsNo)
				 && (this.ExMacroCharName == target.ExMacroCharName)
				 && (this.ExMacroCharcter == target.ExMacroCharcter)
				 && (this.ExMacroCharDvlpCnt == target.ExMacroCharDvlpCnt)
				 && (this.ExMacroCharChngCnt == target.ExMacroCharChngCnt)
				 && (this.ExMacroCharChngDd == target.ExMacroCharChngDd)
				 && (this.ExMacroCharAddExpla == target.ExMacroCharAddExpla)
				 && (this.ExMacroCharChgSample == target.ExMacroCharChgSample)
				 && (this.ExMacroCharChgEdDef1 == target.ExMacroCharChgEdDef1)
				 && (this.ExMacroCharChgEdDef2 == target.ExMacroCharChgEdDef2)
				 && (this.ExMacroPrivacyPolicy == target.ExMacroPrivacyPolicy)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// 拡張マクロ文字定義マスタ比較処理
		/// </summary>
		/// <param name="exMacroDef1">
		///                    比較するExMacroDefクラスのインスタンス
		/// </param>
		/// <param name="exMacroDef2">比較するExMacroDefクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExMacroDefクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ExMacroDef exMacroDef1, ExMacroDef exMacroDef2)
		{
			return ((exMacroDef1.CreateDateTime == exMacroDef2.CreateDateTime)
				 && (exMacroDef1.UpdateDateTime == exMacroDef2.UpdateDateTime)
				 && (exMacroDef1.EnterpriseCode == exMacroDef2.EnterpriseCode)
				 && (exMacroDef1.FileHeaderGuid == exMacroDef2.FileHeaderGuid)
				 && (exMacroDef1.UpdEmployeeCode == exMacroDef2.UpdEmployeeCode)
				 && (exMacroDef1.UpdAssemblyId1 == exMacroDef2.UpdAssemblyId1)
				 && (exMacroDef1.UpdAssemblyId2 == exMacroDef2.UpdAssemblyId2)
				 && (exMacroDef1.LogicalDeleteCode == exMacroDef2.LogicalDeleteCode)
				 && (exMacroDef1.SectionCode == exMacroDef2.SectionCode)
				 && (exMacroDef1.ExMacroCharMngCnsNo == exMacroDef2.ExMacroCharMngCnsNo)
				 && (exMacroDef1.ExMacroCharName == exMacroDef2.ExMacroCharName)
				 && (exMacroDef1.ExMacroCharcter == exMacroDef2.ExMacroCharcter)
				 && (exMacroDef1.ExMacroCharDvlpCnt == exMacroDef2.ExMacroCharDvlpCnt)
				 && (exMacroDef1.ExMacroCharChngCnt == exMacroDef2.ExMacroCharChngCnt)
				 && (exMacroDef1.ExMacroCharChngDd == exMacroDef2.ExMacroCharChngDd)
				 && (exMacroDef1.ExMacroCharAddExpla == exMacroDef2.ExMacroCharAddExpla)
				 && (exMacroDef1.ExMacroCharChgSample == exMacroDef2.ExMacroCharChgSample)
				 && (exMacroDef1.ExMacroCharChgEdDef1 == exMacroDef2.ExMacroCharChgEdDef1)
				 && (exMacroDef1.ExMacroCharChgEdDef2 == exMacroDef2.ExMacroCharChgEdDef2)
				 && (exMacroDef1.ExMacroPrivacyPolicy == exMacroDef2.ExMacroPrivacyPolicy)
				 && (exMacroDef1.EnterpriseName == exMacroDef2.EnterpriseName)
				 && (exMacroDef1.UpdEmployeeName == exMacroDef2.UpdEmployeeName));
		}

		/// <summary>
		/// 拡張マクロ文字定義マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のExMacroDefクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExMacroDefクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ExMacroDef target)
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
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.ExMacroCharMngCnsNo != target.ExMacroCharMngCnsNo)resList.Add("ExMacroCharMngCnsNo");
			if(this.ExMacroCharName != target.ExMacroCharName)resList.Add("ExMacroCharName");
			if(this.ExMacroCharcter != target.ExMacroCharcter)resList.Add("ExMacroCharcter");
			if(this.ExMacroCharDvlpCnt != target.ExMacroCharDvlpCnt)resList.Add("ExMacroCharDvlpCnt");
			if(this.ExMacroCharChngCnt != target.ExMacroCharChngCnt)resList.Add("ExMacroCharChngCnt");
			if(this.ExMacroCharChngDd != target.ExMacroCharChngDd)resList.Add("ExMacroCharChngDd");
			if(this.ExMacroCharAddExpla != target.ExMacroCharAddExpla)resList.Add("ExMacroCharAddExpla");
			if(this.ExMacroCharChgSample != target.ExMacroCharChgSample)resList.Add("ExMacroCharChgSample");
			if(this.ExMacroCharChgEdDef1 != target.ExMacroCharChgEdDef1)resList.Add("ExMacroCharChgEdDef1");
			if(this.ExMacroCharChgEdDef2 != target.ExMacroCharChgEdDef2)resList.Add("ExMacroCharChgEdDef2");
			if(this.ExMacroPrivacyPolicy != target.ExMacroPrivacyPolicy)resList.Add("ExMacroPrivacyPolicy");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// 拡張マクロ文字定義マスタ比較処理
		/// </summary>
		/// <param name="exMacroDef1">比較するExMacroDefクラスのインスタンス</param>
		/// <param name="exMacroDef2">比較するExMacroDefクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExMacroDefクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ExMacroDef exMacroDef1, ExMacroDef exMacroDef2)
		{
			ArrayList resList = new ArrayList();
			if(exMacroDef1.CreateDateTime != exMacroDef2.CreateDateTime)resList.Add("CreateDateTime");
			if(exMacroDef1.UpdateDateTime != exMacroDef2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(exMacroDef1.EnterpriseCode != exMacroDef2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(exMacroDef1.FileHeaderGuid != exMacroDef2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(exMacroDef1.UpdEmployeeCode != exMacroDef2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(exMacroDef1.UpdAssemblyId1 != exMacroDef2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(exMacroDef1.UpdAssemblyId2 != exMacroDef2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(exMacroDef1.LogicalDeleteCode != exMacroDef2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(exMacroDef1.SectionCode != exMacroDef2.SectionCode)resList.Add("SectionCode");
			if(exMacroDef1.ExMacroCharMngCnsNo != exMacroDef2.ExMacroCharMngCnsNo)resList.Add("ExMacroCharMngCnsNo");
			if(exMacroDef1.ExMacroCharName != exMacroDef2.ExMacroCharName)resList.Add("ExMacroCharName");
			if(exMacroDef1.ExMacroCharcter != exMacroDef2.ExMacroCharcter)resList.Add("ExMacroCharcter");
			if(exMacroDef1.ExMacroCharDvlpCnt != exMacroDef2.ExMacroCharDvlpCnt)resList.Add("ExMacroCharDvlpCnt");
			if(exMacroDef1.ExMacroCharChngCnt != exMacroDef2.ExMacroCharChngCnt)resList.Add("ExMacroCharChngCnt");
			if(exMacroDef1.ExMacroCharChngDd != exMacroDef2.ExMacroCharChngDd)resList.Add("ExMacroCharChngDd");
			if(exMacroDef1.ExMacroCharAddExpla != exMacroDef2.ExMacroCharAddExpla)resList.Add("ExMacroCharAddExpla");
			if(exMacroDef1.ExMacroCharChgSample != exMacroDef2.ExMacroCharChgSample)resList.Add("ExMacroCharChgSample");
			if(exMacroDef1.ExMacroCharChgEdDef1 != exMacroDef2.ExMacroCharChgEdDef1)resList.Add("ExMacroCharChgEdDef1");
			if(exMacroDef1.ExMacroCharChgEdDef2 != exMacroDef2.ExMacroCharChgEdDef2)resList.Add("ExMacroCharChgEdDef2");
			if(exMacroDef1.ExMacroPrivacyPolicy != exMacroDef2.ExMacroPrivacyPolicy)resList.Add("ExMacroPrivacyPolicy");
			if(exMacroDef1.EnterpriseName != exMacroDef2.EnterpriseName)resList.Add("EnterpriseName");
			if(exMacroDef1.UpdEmployeeName != exMacroDef2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
        }


        //--------------------------------------------------------------------------------------------------
        //
        // 以下のコードは手動で作成したものなので、プロパティを再度自動生成した後も残すようにしてください
        //
        //--------------------------------------------------------------------------------------------------


        #region

        /// <summary>
        /// 拡張マクロ変換編集定義2  0:無編集
        /// </summary>
        public static int CharEditDiv_Default = 0; 
        /// <summary>
        /// 拡張マクロ変換編集定義2  1:両トリム
        /// </summary>
        public static int CharEditDiv_Trim = 1; 
        /// <summary>
        /// 拡張マクロ変換編集定義2  2:右トリム
        /// </summary>
        public static int CharEditDiv_TrimRight = 2;
        /// <summary>
        /// 拡張マクロ変換編集定義2  3:左トリム
        /// </summary>
        public static int CharEditDiv_TrimLeft = 3; 
        /// <summary>
        /// 拡張マクロ変換編集定義2  12:右詰編集
        /// </summary>
        public static int CharEditDiv_HRight = 12;
        /// <summary>
        /// 拡張マクロ変換編集定義2  15:センタリング
        /// </summary>
        public static int CharEditDiv_HCenter = 15; 

//        0:編集無, 1:両トリム, 2:右トリム, 3:左トリム, 12:右詰編集, 15:センタリング

        /// <summary>
        /// 拡張マクロ型種別  0:文字項目
        /// </summary>
        public static int TermType_String = 0;

        /// <summary>
        /// 拡張マクロ型種別  1:数値項目
        /// </summary>
        public static int TermType_Number = 1;

        /// <summary>
        /// 拡張マクロ型種別  10:日付項目(GGYYMMDD)
        /// </summary>
        public static int TermType_Date = 10; 


        #endregion


    }
}
