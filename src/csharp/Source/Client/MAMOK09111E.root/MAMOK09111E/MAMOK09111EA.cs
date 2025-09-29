using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:	 EmpSalesTarget
    /// <summary>
    /// 					 従業員別売上目標設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note			 :	 従業員別売上目標設定マスタファイル</br>
    /// <br>Programmer		 :	 NEPCO</br>
    /// <br>Date			 :	 </br>
    /// <br>Genarated Date	 :	 2007.05.08  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note 	 :	 2007.10.01 鈴木 正臣</br>
    /// <br>                 流通.DC用に変更（項目の追加・削除）</br>
	/// <br>                     2007.11.21 上野 弘貴</br>
	/// <br>                 従業員別売上目標設定マスタ修正（項目の追加・削除）</br>
    /// </remarks>
    public class EmpSalesTarget
    {
        #region Private Member

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

        /// <summary>目標設定区分</summary>
        private Int32 _targetSetCd;

        /// <summary>目標対比区分</summary>
        private Int32 _targetContrastCd;

        /// <summary>目標区分コード</summary>
        private string _targetDivideCode = "";

        /// <summary>目標区分名称</summary>
        private string _targetDivideName = "";

        /// <summary>適用開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyStaDate;

        /// <summary>適用終了日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyEndDate;

		//----- ueno add---------- start 2007.11.21
		/// <summary>従業員区分</summary>
		private Int32 _employeeDivCd;
		//----- ueno add---------- end   2007.11.21
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>課コード</summary>
        private Int32 _minSectionCode;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>従業員コード</summary>
        private string _employeeCode = "";

        /// <summary>従業員名称</summary>
        private string _employeeName = "";

        /// <summary>売上目標金額</summary>
        private Int64 _salesTargetMoney;

        /// <summary>売上目標粗利額</summary>
        private Int64 _salesTargetProfit;

        /// <summary>売上目標数量</summary>
        private Double _salesTargetCount;

		//----- ueno del---------- start 2007.11.21
		///// <summary>平日比率</summary>
		//private Double _weekdayRatio;

		///// <summary>土日比率</summary>
		//private Double _satSunRatio;
		//----- ueno del---------- end   2007.11.21

        #endregion Private Member

        #region Public Propaty

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

        /// public propaty name  :	TargetSetCd
        /// <summary>目標設定区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 目標設定区分プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int32 TargetSetCd
        {
            get
            {
                return _targetSetCd;
            }
            set
            {
                _targetSetCd = value;
            }
        }

        /// public propaty name  :	TargetContrastCd
        /// <summary>目標対比区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 目標対比区分プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int32 TargetContrastCd
        {
            get
            {
                return _targetContrastCd;
            }
            set
            {
                _targetContrastCd = value;
            }
        }

        /// public propaty name  :	TargetDivideCode
        /// <summary>目標区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 目標区分コードプロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string TargetDivideCode
        {
            get
            {
                return _targetDivideCode;
            }
            set
            {
                _targetDivideCode = value;
            }
        }

        /// public propaty name  :	TargetDivideName
        /// <summary>目標区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 目標区分名称プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string TargetDivideName
        {
            get
            {
                return _targetDivideName;
            }
            set
            {
                _targetDivideName = value;
            }
        }

        /// public propaty name  :	ApplyStaDate
        /// <summary>適用開始日プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用開始日プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime ApplyStaDate
        {
            get
            {
                return _applyStaDate;
            }
            set
            {
                _applyStaDate = value;
            }
        }

        /// public propaty name  :	ApplyStaDateJpFormal
        /// <summary>適用開始日 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用開始日 和暦プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyStaDateJpFormal
        {
            get
            {
                return TDateTime.DateTimeToString("GGYYMMDD", _applyStaDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyStaDateJpInFormal
        /// <summary>適用開始日 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用開始日 和暦(略)プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyStaDateJpInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("ggYY/MM/DD", _applyStaDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyStaDateAdFormal
        /// <summary>適用開始日 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用開始日 西暦プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyStaDateAdFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YYYY/MM/DD", _applyStaDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyStaDateAdInFormal
        /// <summary>適用開始日 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用開始日 西暦(略)プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyStaDateAdInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YY/MM/DD", _applyStaDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyEndDate
        /// <summary>適用終了日プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用終了日プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime ApplyEndDate
        {
            get
            {
                return _applyEndDate;
            }
            set
            {
                _applyEndDate = value;
            }
        }

        /// public propaty name  :	ApplyEndDateJpFormal
        /// <summary>適用終了日 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用終了日 和暦プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyEndDateJpFormal
        {
            get
            {
                return TDateTime.DateTimeToString("GGYYMMDD", _applyEndDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyEndDateJpInFormal
        /// <summary>適用終了日 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用終了日 和暦(略)プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyEndDateJpInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("ggYY/MM/DD", _applyEndDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyEndDateAdFormal
        /// <summary>適用終了日 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用終了日 西暦プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyEndDateAdFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YYYY/MM/DD", _applyEndDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyEndDateAdInFormal
        /// <summary>適用終了日 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用終了日 西暦(略)プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyEndDateAdInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YY/MM/DD", _applyEndDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 従業員コードプロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
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

        /// public propaty name  :	Name
        /// <summary>従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 従業員名称プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string EmployeeName
        {
            get
            {
                return _employeeName;
            }
            set
            {
                _employeeName = value;
            }
        }

        /// public propaty name  :	SalesTargetMoney
        /// <summary>売上目標金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	売上目標金額プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int64 SalesTargetMoney
        {
            get
            {
                return _salesTargetMoney;
            }
            set
            {
                _salesTargetMoney = value;
            }
        }

        /// public propaty name  :	SalesTargetProfit
        /// <summary>売上目標粗利額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 売上目標粗利額プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int64 SalesTargetProfit
        {
            get
            {
                return _salesTargetProfit;
            }
            set
            {
                _salesTargetProfit = value;
            }
        }

        /// public propaty name  :	SalesTargetCount
        /// <summary>売上目標数量プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 売上目標数量プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Double SalesTargetCount
        {
            get
            {
                return _salesTargetCount;
            }
            set
            {
                _salesTargetCount = value;
            }
        }

		//----- ueno del---------- start 2007.11.21
		///// public propaty name  :	WeekdayRatio
		///// <summary>平日比率プロパティ</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 平日比率プロパティ</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public Double WeekdayRatio
		//{
		//    get
		//    {
		//        return _weekdayRatio;
		//    }
		//    set
		//    {
		//        _weekdayRatio = value;
		//    }
		//}

		///// public propaty name  :	SatSunRatio
		///// <summary>土日比率プロパティ</summary>
		///// <value>時刻（時間、分）商品入荷予定日</value>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 土日比率プロパティ</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public Double SatSunRatio
		//{
		//    get
		//    {
		//        return _satSunRatio;
		//    }
		//    set
		//    {
		//        _satSunRatio = value;
		//    }
		//}
		//----- ueno del---------- end   2007.11.21

		//----- ueno add---------- start 2007.11.21
		/// public propaty name  :	EmployeeDivCd
		/// <summary>従業員区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 従業員区分プロパティ</br>
		/// <br>Programer		 :	 30167 上野　弘貴</br>
		/// </remarks>
		public Int32 EmployeeDivCd
		{
			get
			{
				return _employeeDivCd;
			}
			set
			{
				_employeeDivCd = value;
			}
		}
		//----- ueno add---------- end   2007.11.21
        
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// public propaty name  :	SubSectionCode
        /// <summary>部門コードプロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 部門コード</br>
        /// <br>Programer		 :	 22018 鈴木 正臣</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get
            {
                return _subSectionCode;
            }
            set
            {
                _subSectionCode = value;
            }
        }
        /// public propaty name  :	MinSectionCode
        /// <summary>課コードプロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 課コード</br>
        /// <br>Programer		 :	 22018 鈴木 正臣</br>
        /// </remarks>
        public Int32 MinSectionCode
        {
            get
            {
                return _minSectionCode;
            }
            set
            {
                _minSectionCode = value;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        #endregion Public Propaty

        #region コンストラクタ
        /// <summary>
        /// 従業員別売上目標設定マスタコンストラクタ
        /// </summary>
        /// <returns>EmpSalesTargetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 EmpSalesTargetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public EmpSalesTarget()
        {
        }


        /// <summary>
        /// 従業員別売上目標設定マスタコンストラクタ
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
        /// <param name="targetSetCd">目標設定区分</param>
        /// <param name="targetContrastCd">目標対比区分</param>
        /// <param name="targetDivideCode">目標区分コード</param>
        /// <param name="targetDivideName">目標区分名称</param>
        /// <param name="applyStaDate">適用開始日(YYYYMMDD)</param>
        /// <param name="applyEndDate">適用終了日(YYYYMMDD)</param>
		/// <param name="employeeDivCd">従業員区分</param>
		/// <param name="subSectionCode">部門コード</param>
        /// <param name="minSectionCode">課コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="employeeName">従業員名称</param>
        /// <param name="salesTargetMoney">売上目標金額</param>
        /// <param name="salesTargetProfit">売上目標粗利額</param>
        /// <param name="salesTargetCount">売上目標数量</param>
        /// <param name="weekdayRatio">平日比率</param>
        /// <param name="satSunRatio">土日比率</param>
        /// <returns>EmpSalesTargetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 EmpSalesTargetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public EmpSalesTarget(
            DateTime createDateTime,
            DateTime updateDateTime,
            string enterpriseCode,
            Guid fileHeaderGuid,
            string updEmployeeCode,
            string updAssemblyId1,
            string updAssemblyId2,
            Int32 logicalDeleteCode,
            string sectionCode,
            Int32 targetSetCd,
            Int32 targetContrastCd,
            string targetDivideCode,
            string targetDivideName,
            DateTime applyStaDate,
            DateTime applyEndDate,
			//----- ueno add---------- start 2007.11.21
			Int32 employeeDivCd,
			//----- ueno add---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            Int32 subSectionCode,
            Int32 minSectionCode,
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            string employeeCode,
            string employeeName,
            Int64 salesTargetMoney,
            Int64 salesTargetProfit,
            Double salesTargetCount
			//----- ueno del---------- start 2007.11.21
			//Double weekdayRatio,
			//Double satSunRatio
			//----- ueno del---------- end   2007.11.21
			)
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
            this._targetSetCd = targetSetCd;
            this._targetContrastCd = targetContrastCd;
            this._targetDivideCode = targetDivideCode;
            this._targetDivideName = targetDivideName;
            this._applyStaDate = applyStaDate;
            this._applyEndDate = applyEndDate;
			//----- ueno add---------- start 2007.11.21
			this._employeeDivCd = employeeDivCd;
			//----- ueno add---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._subSectionCode = subSectionCode;
            this._minSectionCode = minSectionCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._employeeCode = employeeCode;
            this._employeeName = employeeName;
            this._salesTargetMoney = salesTargetMoney;
            this._salesTargetProfit = salesTargetProfit;
            this._salesTargetCount = salesTargetCount;
			//----- ueno del---------- start 2007.11.21
			//this._weekdayRatio = weekdayRatio;
			//this._satSunRatio = satSunRatio;
			//----- ueno del---------- end   2007.11.21
		}

        #endregion コンストラクタ

        #region Public Method

        #region ◆　従業員別売上目標設定マスタ複製処理
        /// <summary>
        /// 従業員別売上目標設定マスタ複製処理
        /// </summary>
        /// <returns>EmpSalesTargetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 自身の内容と等しいEmpSalesTargetクラスのインスタンスを返します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public EmpSalesTarget Clone()
        {
            return new EmpSalesTarget(this._createDateTime,
                               this._updateDateTime,
                               this._enterpriseCode,
                               this._fileHeaderGuid,
                               this._updEmployeeCode,
                               this._updAssemblyId1,
                               this._updAssemblyId2,
                               this._logicalDeleteCode,
                               this._sectionCode,
                               this._targetSetCd,
                               this._targetContrastCd,
                               this._targetDivideCode,
                               this._targetDivideName,
                               this._applyStaDate,
                               this._applyEndDate,
							   //----- ueno add---------- start 2007.11.21
							   this._employeeDivCd,
							   //----- ueno add---------- end   2007.11.21                               
                               // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                               this._subSectionCode,
                               this._minSectionCode,
                               // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                               this._employeeCode,
                               this._employeeName,
                               this._salesTargetMoney,
                               this._salesTargetProfit,
                               this._salesTargetCount
							   //----- ueno del---------- start 2007.11.21
							   //this._weekdayRatio,
                               //this._satSunRatio
							   //----- ueno del---------- end   2007.11.21
							   );
        }
        #endregion ◆　従業員別売上目標設定マスタ複製処理

        #region ◆　従業員別売上目標設定マスタ比較処理(EmpSalesTarget)
        /// <summary>
        /// 従業員別売上目標設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のEmpSalesTargetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 EmpSalesTargetクラスの内容が一致するか比較します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public bool Equals(EmpSalesTarget target)
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
                 && (this.TargetSetCd == target.TargetSetCd)
                 && (this.TargetContrastCd == target.TargetContrastCd)
                 && (this.TargetDivideCode == target.TargetDivideCode)
                 && (this.TargetDivideName == target.TargetDivideName)
                 && (this.ApplyStaDate == target.ApplyStaDate)
                 && (this.ApplyEndDate == target.ApplyEndDate)
				 //----- ueno add---------- start 2007.11.21
				 && (this.EmployeeDivCd == target.EmployeeDivCd)
				 //----- ueno add---------- end   2007.11.21
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                 && (this.SubSectionCode == target.SubSectionCode )
                 && (this.MinSectionCode == target.MinSectionCode )
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.EmployeeName == target.EmployeeName)
                 && (this.SalesTargetMoney == target.SalesTargetMoney)
                 && (this.SalesTargetProfit == target.SalesTargetProfit)
                 && (this.SalesTargetCount == target.SalesTargetCount)
				 //----- ueno del---------- start 2007.11.21
				 //&& (this.WeekdayRatio == target.WeekdayRatio)
                 //&& ( this.SatSunRatio == target.SatSunRatio )
				 //----- ueno del---------- end   2007.11.21
				 );
        }
        #endregion ◆　従業員別売上目標設定マスタ比較処理

        #region ◆　従業員別売上目標設定マスタ比較処理(EmpSalesTarget,ResvdDT)
        /// <summary>
        /// 従業員別売上目標設定マスタ比較処理
        /// </summary>
        /// <param name="salesMonTarget1">
        /// 				   比較するEmpSalesTargetクラスのインスタンス
        /// </param>
        /// <param name="salesMonTarget2">比較するEmpSalesTargetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 EmpSalesTargetクラスの内容が一致するか比較します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public static bool Equals(EmpSalesTarget salesMonTarget1, EmpSalesTarget salesMonTarget2)
        {
            return ((salesMonTarget1.CreateDateTime == salesMonTarget2.CreateDateTime)
                 && (salesMonTarget1.UpdateDateTime == salesMonTarget2.UpdateDateTime)
                 && (salesMonTarget1.EnterpriseCode == salesMonTarget2.EnterpriseCode)
                 && (salesMonTarget1.FileHeaderGuid == salesMonTarget2.FileHeaderGuid)
                 && (salesMonTarget1.UpdEmployeeCode == salesMonTarget2.UpdEmployeeCode)
                 && (salesMonTarget1.UpdAssemblyId1 == salesMonTarget2.UpdAssemblyId1)
                 && (salesMonTarget1.UpdAssemblyId2 == salesMonTarget2.UpdAssemblyId2)
                 && (salesMonTarget1.LogicalDeleteCode == salesMonTarget2.LogicalDeleteCode)
                 && (salesMonTarget1.SectionCode == salesMonTarget2.SectionCode)
                 && (salesMonTarget1.TargetSetCd == salesMonTarget2.TargetSetCd)
                 && (salesMonTarget1.TargetContrastCd == salesMonTarget2.TargetContrastCd)
                 && (salesMonTarget1.TargetDivideCode == salesMonTarget2.TargetDivideCode)
                 && (salesMonTarget1.TargetDivideName == salesMonTarget2.TargetDivideName)
                 && (salesMonTarget1.ApplyStaDate == salesMonTarget2.ApplyStaDate)
                 && (salesMonTarget1.ApplyEndDate == salesMonTarget2.ApplyEndDate)
				 //----- ueno add---------- start 2007.11.21
				 && (salesMonTarget1.EmployeeDivCd == salesMonTarget2.EmployeeDivCd)
				 //----- ueno add---------- end   2007.11.21
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                 && (salesMonTarget1.SubSectionCode == salesMonTarget2.SubSectionCode )
                 && (salesMonTarget1.MinSectionCode == salesMonTarget2.MinSectionCode )
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                 && ( salesMonTarget1.EmployeeCode == salesMonTarget2.EmployeeCode )
                 && (salesMonTarget1.EmployeeName == salesMonTarget2.EmployeeName)
                 && (salesMonTarget1.SalesTargetMoney == salesMonTarget2.SalesTargetMoney)
                 && (salesMonTarget1.SalesTargetProfit == salesMonTarget2.SalesTargetProfit)
                 && (salesMonTarget1.SalesTargetCount == salesMonTarget2.SalesTargetCount)
				 //----- ueno del---------- start 2007.11.21
				 //&& (salesMonTarget1.WeekdayRatio == salesMonTarget2.WeekdayRatio)
                 //&& ( salesMonTarget1.SatSunRatio == salesMonTarget2.SatSunRatio )
				 //----- ueno del---------- end   2007.11.21
				 );
        }
        #endregion ◆　従業員別売上目標設定マスタ比較処理(EmpSalesTarget,ResvdDT)

        #region ◆　従業員別売上目標設定マスタ比較結果リスト作成処理(EmpSalesTarget)
        /// <summary>
        /// 従業員別売上目標設定マスタ比較結果リスト作成処理
        /// </summary>
        /// <param name="target">比較対象のEmpSalesTargetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 EmpSalesTargetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public ArrayList Compare(EmpSalesTarget target)
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
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.TargetSetCd != target.TargetSetCd) resList.Add("TargetSetCd");
            if (this.TargetContrastCd != target.TargetContrastCd) resList.Add("TargetContrastCd");
            if (this.TargetDivideCode != target.TargetDivideCode) resList.Add("TargetDivideCode");
            if (this.TargetDivideName != target.TargetDivideName) resList.Add("TargetDivideName");
            if (this.ApplyStaDate != target.ApplyStaDate) resList.Add("ApplyStaDate");
            if (this.ApplyEndDate != target.ApplyEndDate) resList.Add("ApplyEndDate");
			//----- ueno add---------- start 2007.11.21
			if (this.EmployeeDivCd != target.EmployeeDivCd) resList.Add("EmployeeDivCd");
			//----- ueno add---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if ( this.SubSectionCode != target.SubSectionCode ) resList.Add("SubSectionCode");
            if ( this.MinSectionCode != target.MinSectionCode ) resList.Add("MinSectionCode");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            if ( this.EmployeeCode != target.EmployeeCode ) resList.Add("EmployeeCode");
            if (this.EmployeeName != target.EmployeeName) resList.Add("EmployeeName");
            if (this.SalesTargetMoney != target.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (this.SalesTargetProfit != target.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (this.SalesTargetCount != target.SalesTargetCount) resList.Add("SalesTargetCount");
			//----- ueno del---------- start 2007.11.21
			//if (this.WeekdayRatio != target.WeekdayRatio) resList.Add("WeekdayRatio");
            //if ( this.SatSunRatio != target.SatSunRatio ) resList.Add("SatSunRatio");
			//----- ueno del---------- end   2007.11.21

            return resList;
        }
        #endregion ◆　従業員別売上目標設定マスタ比較結果リスト作成処理(EmpSalesTarget)

        #region ◆　従業員別売上目標設定マスタ比較結果リスト作成処理(EmpSalesTarget,EmpSalesTarget)
        /// <summary>
        /// 従業員別売上目標設定マスタ比較処理
        /// </summary>
        /// <param name="salesMonTarget1">比較するEmpSalesTargetクラスのインスタンス</param>
        /// <param name="salesMonTarget2">比較するEmpSalesTargetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 EmpSalesTargetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public static ArrayList Compare(EmpSalesTarget salesMonTarget1, EmpSalesTarget salesMonTarget2)
        {
            ArrayList resList = new ArrayList();
            if (salesMonTarget1.CreateDateTime != salesMonTarget2.CreateDateTime) resList.Add("CreateDateTime");
            if (salesMonTarget1.UpdateDateTime != salesMonTarget2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (salesMonTarget1.EnterpriseCode != salesMonTarget2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (salesMonTarget1.FileHeaderGuid != salesMonTarget2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (salesMonTarget1.UpdEmployeeCode != salesMonTarget2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (salesMonTarget1.UpdAssemblyId1 != salesMonTarget2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (salesMonTarget1.UpdAssemblyId2 != salesMonTarget2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (salesMonTarget1.LogicalDeleteCode != salesMonTarget2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (salesMonTarget1.SectionCode != salesMonTarget2.SectionCode) resList.Add("SectionCode");
            if (salesMonTarget1.TargetSetCd != salesMonTarget2.TargetSetCd) resList.Add("TargetSetCd");
            if (salesMonTarget1.TargetContrastCd != salesMonTarget2.TargetContrastCd) resList.Add("TargetContrastCd");
            if (salesMonTarget1.TargetDivideCode != salesMonTarget2.TargetDivideCode) resList.Add("TargetDivideCode");
            if (salesMonTarget1.TargetDivideName != salesMonTarget2.TargetDivideName) resList.Add("TargetDivideName");
            if (salesMonTarget1.ApplyStaDate != salesMonTarget2.ApplyStaDate) resList.Add("ApplyStaDate");
            if (salesMonTarget1.ApplyEndDate != salesMonTarget2.ApplyEndDate) resList.Add("ApplyEndDate");
			//----- ueno add---------- start 2007.11.21
			if (salesMonTarget1.EmployeeDivCd != salesMonTarget2.EmployeeDivCd) resList.Add("EmployeeDivCd");
			//----- ueno add---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if (salesMonTarget1.SubSectionCode != salesMonTarget2.SubSectionCode ) resList.Add("SubSectionCode");
            if (salesMonTarget1.MinSectionCode != salesMonTarget2.MinSectionCode ) resList.Add("MinSectionCode");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            if ( salesMonTarget1.EmployeeCode != salesMonTarget2.EmployeeCode ) resList.Add("EmployeeCode");
            if (salesMonTarget1.EmployeeName != salesMonTarget2.EmployeeName) resList.Add("EmployeeName");
            if (salesMonTarget1.SalesTargetMoney != salesMonTarget2.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (salesMonTarget1.SalesTargetProfit != salesMonTarget2.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (salesMonTarget1.SalesTargetCount != salesMonTarget2.SalesTargetCount) resList.Add("SalesTargetCount");
			//----- ueno del---------- start 2007.11.21
			//if (salesMonTarget1.WeekdayRatio != salesMonTarget2.WeekdayRatio) resList.Add("WeekdayRatio");
            //if ( salesMonTarget1.SatSunRatio != salesMonTarget2.SatSunRatio ) resList.Add("SatSunRatio");
			//----- ueno del---------- end   2007.11.21

            return resList;
        }
        #endregion ◆　従業員別売上目標設定マスタ比較結果リスト作成処理(EmpSalesTarget,EmpSalesTarget)

        #endregion Public Method

//----- ueno add---------- start 2007.11.21

		/// <summary>従業員区分リスト</summary>
		public static SortedList _employeeDivCdSList;

		/// <summary>
		/// 静的コンストラクタ
		/// </summary>
		static EmpSalesTarget()
		{
			_employeeDivCdSList = MakeEmployeeDivCd();
		}

		/// <summary>
		/// 従業員区分リスト生成
		/// </summary>
		/// <returns>従業員区分のリスト</returns>
		/// <remarks>
		/// <br>Note	   : 従業員区分のリストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		private static SortedList MakeEmployeeDivCd()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(10, "販売担当者");
			retSortedList.Add(20, "受付担当者");
			retSortedList.Add(30, "入力担当者");
			return retSortedList;
		}

		/// <summary>
		/// 従業員区分名称取得処理
		/// </summary>
		/// <param name="employeeDivCd">従業員区分コード</param>
		/// <returns>従業員区分名称</returns>
		/// <remarks>
		/// <br>Note       : 従業員区分コードから従業員区分名称を取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		public static string GetEmployeeDivNm(int employeeDivCd)
		{
			string retStr = "";

			if (_employeeDivCdSList.ContainsKey((object)employeeDivCd))
			{
				retStr = _employeeDivCdSList[employeeDivCd].ToString();
			}
			return retStr;
		}
//----- ueno add---------- end   2007.11.21

    }
}
