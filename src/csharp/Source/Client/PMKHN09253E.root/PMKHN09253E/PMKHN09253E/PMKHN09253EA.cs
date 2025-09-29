using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   EmpSalesTarget
    /// <summary>
    ///                      従業員別売上目標設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   従業員別売上目標設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2008/10/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class EmpSalesTarget
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

        /// <summary>目標設定区分</summary>
        /// <remarks>10：月間目標,20：個別期間目標</remarks>
        private Int32 _targetSetCd;

        /// <summary>目標対比区分</summary>
        /// <remarks>10:拠点,20:拠点+部門,21:拠点+部門+課,22:拠点+従業員,30:拠点+得意先,31:拠点+業種,32:拠点+販売ｴﾘｱ,33:拠点+販売ｴﾘｱ+得意先,40:拠点+ﾒｰｶｰ,41:拠点+ﾒｰｶｰ+商品</remarks>
        private Int32 _targetContrastCd;

        /// <summary>目標区分コード</summary>
        /// <remarks>月間目標：YYYYMM、個別期間目標：任意コード</remarks>
        private string _targetDivideCode = "";

        /// <summary>目標区分名称</summary>
        private string _targetDivideName = "";

        /// <summary>従業員区分</summary>
        /// <remarks>10:販売担当者 20:受付担当者 30:入力担当者</remarks>
        private Int32 _employeeDivCd;

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>従業員コード</summary>
        private string _employeeCode = "";

        /// <summary>適用開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyStaDate;

        /// <summary>適用終了日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyEndDate;

        /// <summary>売上目標金額</summary>
        private Int64 _salesTargetMoney;

        /// <summary>売上目標粗利額</summary>
        private Int64 _salesTargetProfit;

        /// <summary>売上目標数量</summary>
        private Double _salesTargetCount;

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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  TargetSetCd
        /// <summary>目標設定区分プロパティ</summary>
        /// <value>10：月間目標,20：個別期間目標</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   目標設定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TargetSetCd
        {
            get { return _targetSetCd; }
            set { _targetSetCd = value; }
        }

        /// public propaty name  :  TargetContrastCd
        /// <summary>目標対比区分プロパティ</summary>
        /// <value>10:拠点,20:拠点+部門,21:拠点+部門+課,22:拠点+従業員,30:拠点+得意先,31:拠点+業種,32:拠点+販売ｴﾘｱ,33:拠点+販売ｴﾘｱ+得意先,40:拠点+ﾒｰｶｰ,41:拠点+ﾒｰｶｰ+商品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   目標対比区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TargetContrastCd
        {
            get { return _targetContrastCd; }
            set { _targetContrastCd = value; }
        }

        /// public propaty name  :  TargetDivideCode
        /// <summary>目標区分コードプロパティ</summary>
        /// <value>月間目標：YYYYMM、個別期間目標：任意コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   目標区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TargetDivideCode
        {
            get { return _targetDivideCode; }
            set { _targetDivideCode = value; }
        }

        /// public propaty name  :  TargetDivideName
        /// <summary>目標区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   目標区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TargetDivideName
        {
            get { return _targetDivideName; }
            set { _targetDivideName = value; }
        }

        /// public propaty name  :  EmployeeDivCd
        /// <summary>従業員区分プロパティ</summary>
        /// <value>10:販売担当者 20:受付担当者 30:入力担当者</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployeeDivCd
        {
            get { return _employeeDivCd; }
            set { _employeeDivCd = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>部門コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
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

        /// public propaty name  :  ApplyStaDate
        /// <summary>適用開始日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyStaDateJpFormal
        /// <summary>適用開始日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ApplyStaDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _applyStaDate); }
            set { }
        }

        /// public propaty name  :  ApplyStaDateJpInFormal
        /// <summary>適用開始日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ApplyStaDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _applyStaDate); }
            set { }
        }

        /// public propaty name  :  ApplyStaDateAdFormal
        /// <summary>適用開始日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ApplyStaDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _applyStaDate); }
            set { }
        }

        /// public propaty name  :  ApplyStaDateAdInFormal
        /// <summary>適用開始日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ApplyStaDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _applyStaDate); }
            set { }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>適用終了日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
        }

        /// public propaty name  :  ApplyEndDateJpFormal
        /// <summary>適用終了日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ApplyEndDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _applyEndDate); }
            set { }
        }

        /// public propaty name  :  ApplyEndDateJpInFormal
        /// <summary>適用終了日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ApplyEndDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _applyEndDate); }
            set { }
        }

        /// public propaty name  :  ApplyEndDateAdFormal
        /// <summary>適用終了日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ApplyEndDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _applyEndDate); }
            set { }
        }

        /// public propaty name  :  ApplyEndDateAdInFormal
        /// <summary>適用終了日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ApplyEndDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _applyEndDate); }
            set { }
        }

        /// public propaty name  :  SalesTargetMoney
        /// <summary>売上目標金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney
        {
            get { return _salesTargetMoney; }
            set { _salesTargetMoney = value; }
        }

        /// public propaty name  :  SalesTargetProfit
        /// <summary>売上目標粗利額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit
        {
            get { return _salesTargetProfit; }
            set { _salesTargetProfit = value; }
        }

        /// public propaty name  :  SalesTargetCount
        /// <summary>売上目標数量プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesTargetCount
        {
            get { return _salesTargetCount; }
            set { _salesTargetCount = value; }
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
        /// 従業員別売上目標設定マスタコンストラクタ
        /// </summary>
        /// <returns>EmpSalesTargetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmpSalesTargetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <param name="targetSetCd">目標設定区分(10：月間目標,20：個別期間目標)</param>
        /// <param name="targetContrastCd">目標対比区分(10:拠点,20:拠点+部門,21:拠点+部門+課,22:拠点+従業員,30:拠点+得意先,31:拠点+業種,32:拠点+販売ｴﾘｱ,33:拠点+販売ｴﾘｱ+得意先,40:拠点+ﾒｰｶｰ,41:拠点+ﾒｰｶｰ+商品)</param>
        /// <param name="targetDivideCode">目標区分コード(月間目標：YYYYMM、個別期間目標：任意コード)</param>
        /// <param name="targetDivideName">目標区分名称</param>
        /// <param name="employeeDivCd">従業員区分(10:販売担当者 20:受付担当者 30:入力担当者)</param>
        /// <param name="subSectionCode">部門コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="applyStaDate">適用開始日(YYYYMMDD)</param>
        /// <param name="applyEndDate">適用終了日(YYYYMMDD)</param>
        /// <param name="salesTargetMoney">売上目標金額</param>
        /// <param name="salesTargetProfit">売上目標粗利額</param>
        /// <param name="salesTargetCount">売上目標数量</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>EmpSalesTargetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmpSalesTargetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EmpSalesTarget(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 targetSetCd, Int32 targetContrastCd, string targetDivideCode, string targetDivideName, Int32 employeeDivCd, Int32 subSectionCode, string employeeCode, DateTime applyStaDate, DateTime applyEndDate, Int64 salesTargetMoney, Int64 salesTargetProfit, Double salesTargetCount, string enterpriseName, string updEmployeeName)
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
            this._employeeDivCd = employeeDivCd;
            this._subSectionCode = subSectionCode;
            this._employeeCode = employeeCode;
            this.ApplyStaDate = applyStaDate;
            this.ApplyEndDate = applyEndDate;
            this._salesTargetMoney = salesTargetMoney;
            this._salesTargetProfit = salesTargetProfit;
            this._salesTargetCount = salesTargetCount;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// 従業員別売上目標設定マスタ複製処理
        /// </summary>
        /// <returns>EmpSalesTargetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいEmpSalesTargetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EmpSalesTarget Clone()
        {
            return new EmpSalesTarget(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._targetSetCd, this._targetContrastCd, this._targetDivideCode, this._targetDivideName, this._employeeDivCd, this._subSectionCode, this._employeeCode, this._applyStaDate, this._applyEndDate, this._salesTargetMoney, this._salesTargetProfit, this._salesTargetCount, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// 従業員別売上目標設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のEmpSalesTargetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmpSalesTargetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
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
                 && (this.EmployeeDivCd == target.EmployeeDivCd)
                 && (this.SubSectionCode == target.SubSectionCode)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.ApplyStaDate == target.ApplyStaDate)
                 && (this.ApplyEndDate == target.ApplyEndDate)
                 && (this.SalesTargetMoney == target.SalesTargetMoney)
                 && (this.SalesTargetProfit == target.SalesTargetProfit)
                 && (this.SalesTargetCount == target.SalesTargetCount)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// 従業員別売上目標設定マスタ比較処理
        /// </summary>
        /// <param name="empSalesTarget1">
        ///                    比較するEmpSalesTargetクラスのインスタンス
        /// </param>
        /// <param name="empSalesTarget2">比較するEmpSalesTargetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmpSalesTargetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(EmpSalesTarget empSalesTarget1, EmpSalesTarget empSalesTarget2)
        {
            return ((empSalesTarget1.CreateDateTime == empSalesTarget2.CreateDateTime)
                 && (empSalesTarget1.UpdateDateTime == empSalesTarget2.UpdateDateTime)
                 && (empSalesTarget1.EnterpriseCode == empSalesTarget2.EnterpriseCode)
                 && (empSalesTarget1.FileHeaderGuid == empSalesTarget2.FileHeaderGuid)
                 && (empSalesTarget1.UpdEmployeeCode == empSalesTarget2.UpdEmployeeCode)
                 && (empSalesTarget1.UpdAssemblyId1 == empSalesTarget2.UpdAssemblyId1)
                 && (empSalesTarget1.UpdAssemblyId2 == empSalesTarget2.UpdAssemblyId2)
                 && (empSalesTarget1.LogicalDeleteCode == empSalesTarget2.LogicalDeleteCode)
                 && (empSalesTarget1.SectionCode == empSalesTarget2.SectionCode)
                 && (empSalesTarget1.TargetSetCd == empSalesTarget2.TargetSetCd)
                 && (empSalesTarget1.TargetContrastCd == empSalesTarget2.TargetContrastCd)
                 && (empSalesTarget1.TargetDivideCode == empSalesTarget2.TargetDivideCode)
                 && (empSalesTarget1.TargetDivideName == empSalesTarget2.TargetDivideName)
                 && (empSalesTarget1.EmployeeDivCd == empSalesTarget2.EmployeeDivCd)
                 && (empSalesTarget1.SubSectionCode == empSalesTarget2.SubSectionCode)
                 && (empSalesTarget1.EmployeeCode == empSalesTarget2.EmployeeCode)
                 && (empSalesTarget1.ApplyStaDate == empSalesTarget2.ApplyStaDate)
                 && (empSalesTarget1.ApplyEndDate == empSalesTarget2.ApplyEndDate)
                 && (empSalesTarget1.SalesTargetMoney == empSalesTarget2.SalesTargetMoney)
                 && (empSalesTarget1.SalesTargetProfit == empSalesTarget2.SalesTargetProfit)
                 && (empSalesTarget1.SalesTargetCount == empSalesTarget2.SalesTargetCount)
                 && (empSalesTarget1.EnterpriseName == empSalesTarget2.EnterpriseName)
                 && (empSalesTarget1.UpdEmployeeName == empSalesTarget2.UpdEmployeeName));
        }
        /// <summary>
        /// 従業員別売上目標設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のEmpSalesTargetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmpSalesTargetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
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
            if (this.EmployeeDivCd != target.EmployeeDivCd) resList.Add("EmployeeDivCd");
            if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.ApplyStaDate != target.ApplyStaDate) resList.Add("ApplyStaDate");
            if (this.ApplyEndDate != target.ApplyEndDate) resList.Add("ApplyEndDate");
            if (this.SalesTargetMoney != target.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (this.SalesTargetProfit != target.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (this.SalesTargetCount != target.SalesTargetCount) resList.Add("SalesTargetCount");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// 従業員別売上目標設定マスタ比較処理
        /// </summary>
        /// <param name="empSalesTarget1">比較するEmpSalesTargetクラスのインスタンス</param>
        /// <param name="empSalesTarget2">比較するEmpSalesTargetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmpSalesTargetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(EmpSalesTarget empSalesTarget1, EmpSalesTarget empSalesTarget2)
        {
            ArrayList resList = new ArrayList();
            if (empSalesTarget1.CreateDateTime != empSalesTarget2.CreateDateTime) resList.Add("CreateDateTime");
            if (empSalesTarget1.UpdateDateTime != empSalesTarget2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (empSalesTarget1.EnterpriseCode != empSalesTarget2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (empSalesTarget1.FileHeaderGuid != empSalesTarget2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (empSalesTarget1.UpdEmployeeCode != empSalesTarget2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (empSalesTarget1.UpdAssemblyId1 != empSalesTarget2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (empSalesTarget1.UpdAssemblyId2 != empSalesTarget2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (empSalesTarget1.LogicalDeleteCode != empSalesTarget2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (empSalesTarget1.SectionCode != empSalesTarget2.SectionCode) resList.Add("SectionCode");
            if (empSalesTarget1.TargetSetCd != empSalesTarget2.TargetSetCd) resList.Add("TargetSetCd");
            if (empSalesTarget1.TargetContrastCd != empSalesTarget2.TargetContrastCd) resList.Add("TargetContrastCd");
            if (empSalesTarget1.TargetDivideCode != empSalesTarget2.TargetDivideCode) resList.Add("TargetDivideCode");
            if (empSalesTarget1.TargetDivideName != empSalesTarget2.TargetDivideName) resList.Add("TargetDivideName");
            if (empSalesTarget1.EmployeeDivCd != empSalesTarget2.EmployeeDivCd) resList.Add("EmployeeDivCd");
            if (empSalesTarget1.SubSectionCode != empSalesTarget2.SubSectionCode) resList.Add("SubSectionCode");
            if (empSalesTarget1.EmployeeCode != empSalesTarget2.EmployeeCode) resList.Add("EmployeeCode");
            if (empSalesTarget1.ApplyStaDate != empSalesTarget2.ApplyStaDate) resList.Add("ApplyStaDate");
            if (empSalesTarget1.ApplyEndDate != empSalesTarget2.ApplyEndDate) resList.Add("ApplyEndDate");
            if (empSalesTarget1.SalesTargetMoney != empSalesTarget2.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (empSalesTarget1.SalesTargetProfit != empSalesTarget2.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (empSalesTarget1.SalesTargetCount != empSalesTarget2.SalesTargetCount) resList.Add("SalesTargetCount");
            if (empSalesTarget1.EnterpriseName != empSalesTarget2.EnterpriseName) resList.Add("EnterpriseName");
            if (empSalesTarget1.UpdEmployeeName != empSalesTarget2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
